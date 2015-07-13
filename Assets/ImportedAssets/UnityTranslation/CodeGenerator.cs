#if UNITY_EDITOR

// Use this definition to generate "Language.cs" and "PluralsRules.cs" from CLDR.
// Please become Unity Translation developer and commit your changes to https://github.com/Gris87/UnityTranslation
// #define I_AM_UNITY_TRANSLATION_DEVELOPER

// Use this definition if you want to force code generation
// #define FORCE_CODE_GENERATION



using UnityEngine;
using UnityTranslation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;



namespace UnityTranslationInternal
{
    public static class CodeGenerator
    {
        private class SectionTokens
        {
            public List<string>                              stringNames;
            public List<string>                              stringComments;
            public List<string>                              stringValues;

            public List<string>                              stringArrayNames;
            public List<string>                              stringArrayComments;
            public List<List<string>>                        stringArrayValuesComments;
            public List<List<string>>                        stringArrayValues;

            public List<string>                              pluralsNames;
            public List<string>                              pluralsComments;
            public List<Dictionary<PluralsQuantity, string>> pluralsValuesComments;
            public List<Dictionary<PluralsQuantity, string>> pluralsValues;



            public SectionTokens()
            {
                stringNames               = new List<string>();
                stringComments            = new List<string>();
                stringValues              = new List<string>();

                stringArrayNames          = new List<string>();
                stringArrayComments       = new List<string>();
                stringArrayValuesComments = new List<List<string>>();
                stringArrayValues         = new List<List<string>>();

                pluralsNames              = new List<string>();
                pluralsComments           = new List<string>();
                pluralsValuesComments     = new List<Dictionary<PluralsQuantity, string>>();
                pluralsValues             = new List<Dictionary<PluralsQuantity, string>>();
            }
        }


#if !FORCE_CODE_GENERATION
        private static bool sChangedCodeGenerator_cs            = false;

#if I_AM_UNITY_TRANSLATION_DEVELOPER
        private static bool sChangedGeneratedLanguage           = false;
        private static bool sChangedGeneratedPluralsRules       = false;
#endif

        private static bool sСhangedGeneratedAvailableLanguages = false;
        private static bool sChangedGeneratedR                  = false;
        private static bool sChangedGeneratedTranslator         = false;
#endif



        /// <summary>
        /// Generates source code required for UnityTranslation
        /// </summary>
        public static void Generate()
        {
#if !FORCE_CODE_GENERATION
            CheckPreviouslyGeneratedFiles();
#endif

#if I_AM_UNITY_TRANSLATION_DEVELOPER
            GenerateLanguage();
            GeneratePluralsRules();
#endif

            GenerateStringsXml();
            GenerateAvailableLanguages();

#if !FORCE_CODE_GENERATION
            bool generateFilesDependedOnR_cs = true;
#endif

            List<string> sectionIds = GenerateR();

            if (sectionIds == null)
            {
#if !FORCE_CODE_GENERATION
                generateFilesDependedOnR_cs = false;
#endif

                sectionIds = new List<string>();

                for (int i = 0; i < (int)R.sections.SectionID.Count; ++i)
                {
                    sectionIds.Add(((R.sections.SectionID)i).ToString());
                }
            }

#if FORCE_CODE_GENERATION
            GenerateTranslator(         sectionIds);
            GenerateTextAutoTranslation(sectionIds);
#else
            GenerateTranslator(         sectionIds, sChangedCodeGenerator_cs || generateFilesDependedOnR_cs);
            GenerateTextAutoTranslation(sectionIds, sChangedCodeGenerator_cs || generateFilesDependedOnR_cs);
#endif
        }

        /// <summary>
        /// Get path to generated file.
        /// </summary>
        /// <returns>Path to generated file.</returns>
        /// <param name="filename">Name of file.</param>
        private static string PathToGeneratedFile(string filename)
        {
            string res = null;

            DirectoryInfo assetsDir = new DirectoryInfo(Application.dataPath);
            FileInfo[] foundFiles = assetsDir.GetFiles(filename, SearchOption.AllDirectories);

            if (foundFiles.Length > 0)
            {
                res = foundFiles[0].FullName;
            }
            else
            {
                DirectoryInfo[] foundDirs = assetsDir.GetDirectories("UnityTranslation", SearchOption.AllDirectories);

                for (int i = 0; i < foundDirs.Length; ++i)
                {
                    if (File.Exists(foundDirs[i].FullName + "/CodeGenerator.cs"))
                    {
                        res = foundDirs[i].FullName + "/Generated/" + filename;

                        break;
                    }
                }

                if (res == null)
                {
                    res = Application.dataPath + "/" + filename;

                    Debug.LogError("Unexpected behaviour for getting path to \"" + filename + "\" file");
                }
            }

            return res.Replace('\\', '/');
        }

#if !FORCE_CODE_GENERATION
        /// <summary>
        /// Checks the previously generated files.
        /// </summary>
        private static void CheckPreviouslyGeneratedFiles()
        {
            if (IsApplicationRebuilded())
            {
                string generatedFolder = PathToGeneratedFile("CodeGenerator.cs");

                generatedFolder = generatedFolder.Remove(generatedFolder.LastIndexOf('/'));
                sChangedCodeGenerator_cs = CheckPreviouslyGeneratedFile(generatedFolder, "CodeGenerator.cs");

                generatedFolder += "/Generated";

#if I_AM_UNITY_TRANSLATION_DEVELOPER
                sChangedGeneratedLanguage           = sChangedCodeGenerator_cs || CheckPreviouslyGeneratedFile(generatedFolder, "Language.cs");
                sChangedGeneratedPluralsRules       = sChangedCodeGenerator_cs || CheckPreviouslyGeneratedFile(generatedFolder, "PluralsRules.cs");
#endif

                sСhangedGeneratedAvailableLanguages = sChangedCodeGenerator_cs || CheckPreviouslyGeneratedFile(generatedFolder, "AvailableLanguages.cs");
                sChangedGeneratedR                  = sChangedCodeGenerator_cs || CheckPreviouslyGeneratedFile(generatedFolder, "R.cs");
                sChangedGeneratedTranslator         = sChangedCodeGenerator_cs || CheckPreviouslyGeneratedFile(generatedFolder, "Translator.cs");
            }
        }
#endif

        /// <summary>
        /// Verifies that application rebuilded.
        /// </summary>
        /// <returns><c>true</c>, if application rebuilded, <c>false</c> otherwise.</returns>
        private static bool IsApplicationRebuilded()
        {
            bool res = false;

            string binaryFile = Application.dataPath + "/../Library/ScriptAssemblies/Assembly-CSharp.dll";
            string tempFile   = Application.temporaryCachePath + "/UnityTranslation/Assembly-CSharp.dll";

            if (File.Exists(binaryFile))
            {
                byte[] newBinary = File.ReadAllBytes(binaryFile);

                if (File.Exists(tempFile))
                {
                    byte[] oldBinary = File.ReadAllBytes(tempFile);

                    res = !oldBinary.SequenceEqual(newBinary);
                }
                else
                {
                    res = true;
                }

                if (res)
                {
                    // Debug.Log("Application rebuilded");
                    Directory.CreateDirectory(Application.temporaryCachePath + "/UnityTranslation");
                    File.WriteAllBytes(tempFile, newBinary);
                }
            }

            return res;
        }

        /// <summary>
        /// Checks the previously generated file.
        /// </summary>
        /// <returns><c>true</c>, if file generated in previous build, <c>false</c> otherwise.</returns>
        /// <param name="generatedFolder">Path to Generated folder.</param>
        /// <param name="filename">Name of file.</param>
        private static bool CheckPreviouslyGeneratedFile(string generatedFolder, string filename)
        {
            bool res = false;

            string generatedFile = generatedFolder + "/" + filename;
            string tempFile      = Application.temporaryCachePath + "/UnityTranslation/" + filename;

            if (File.Exists(generatedFile))
            {
                string newText = File.ReadAllText(generatedFile, Encoding.UTF8);

                if (File.Exists(tempFile))
                {
                    string oldText = File.ReadAllText(tempFile,  Encoding.UTF8);

                    res = (oldText != newText);
                }
                else
                {
                    res = true;
                }

                if (res)
                {
                    // Debug.Log("File \"" + filename + "\" regenerated in previous build");
                    Directory.CreateDirectory(Application.temporaryCachePath + "/UnityTranslation");
                    File.WriteAllText(tempFile, newText, Encoding.UTF8);
                }
            }
            else
            {
                Debug.LogError("File \"" + filename + "\" not found");
            }

            return res;
        }

#if I_AM_UNITY_TRANSLATION_DEVELOPER
        /// <summary>
        /// Generates Language.cs file
        /// </summary>
        private static void GenerateLanguage()
        {
            string cldrLanguagesFile = Application.dataPath           + "/../3rd_party/CLDR/json-full/main/en/languages.json";
            string tempLanguagesFile = Application.temporaryCachePath + "/UnityTranslation/languages.json";

            string targetFile = Application.dataPath + "/Scripts/UnityTranslation/Generated/Language.cs";

            byte[] cldrFileBytes = null;

            #region Check that Language.cs is up to date
            if (!File.Exists(cldrLanguagesFile))
            {
                Debug.LogError("File \"" + cldrLanguagesFile + "\" not found");

                return;
            }

            cldrFileBytes = File.ReadAllBytes(cldrLanguagesFile);

#if !FORCE_CODE_GENERATION
            if (
                !sChangedGeneratedLanguage
                &&
                File.Exists(targetFile)
                &&
                File.Exists(tempLanguagesFile)
               )
            {
                byte[] tempFileBytes = File.ReadAllBytes(tempLanguagesFile);

                if (cldrFileBytes.SequenceEqual(tempFileBytes))
                {
                    return;
                }
            }
#endif
            #endregion

            #region Generating Language.cs file
            Debug.Log("Generating \"Language.cs\" file");

            string cldrFileText = Encoding.UTF8.GetString(cldrFileBytes);
            JSONObject json = new JSONObject(cldrFileText);

            if (json.type == JSONObject.Type.OBJECT)
            {
                int maxCodeLength         = 0;
                int maxNameLength         = 0;
                int maxSystemNameLength   = 0;
                int maxLanguageNameLength = 0;

                List<string> languageCodes               = new List<string>();
                List<string> languageEnums               = new List<string>();
                List<string> languageNames               = new List<string>();
                List<string> languageToSystemLanguages   = new List<string>();
                List<string> languageFromSystemLanguages = new List<string>();

                #region Parse JSON
                bool good = true;

                json.GetField("main", delegate(JSONObject mainJson)
                {
                    mainJson.GetField("en", delegate(JSONObject enJson)
                    {
                        enJson.GetField("localeDisplayNames", delegate(JSONObject localeDisplayNamesJson)
                        {
                            localeDisplayNamesJson.GetField("languages", delegate(JSONObject languagesJson)
                            {
                                for (int i = 0; i < languagesJson.list.Count; ++i)
                                {
                                    if (languagesJson.keys[i] == "root")
                                    {
                                        continue;
                                    }

                                    JSONObject languageJson = languagesJson.list[i];

                                    string temp = "";

                                    string[] tokens = languageJson.str.Split(' ', '.', '-');

                                    for (int j = 0; j < tokens.Length; ++j)
                                    {
                                        if (tokens[j].Length > 0)
                                        {
                                            temp += tokens[j].Substring(0, 1).ToUpper() + tokens[j].Substring(1).ToLower();
                                        }
                                    }

                                    string languageEnum = "";

                                    for (int j = 0; j < temp.Length; ++j)
                                    {
                                        char ch = temp[j];

                                        if (
                                            (ch >= 'a') && (ch <= 'z')
                                            ||
                                            (ch >= 'A') && (ch <= 'Z')
                                            )
                                        {
                                            languageEnum += ch;
                                        }
                                        else
                                        if (ch == 700) // if (ch == 'ʼ')
                                        {
                                            // Nothing
                                        }
                                        else
                                        if (ch == 229) // if (ch == 'å')
                                        {
                                            languageEnum += 'a';
                                        }
                                        else
                                        if (ch == 231) // if (ch == 'ç')
                                        {
                                            languageEnum += 'c';
                                        }
                                        else
                                        if (ch == 252) // if (ch == 'ü')
                                        {
                                            languageEnum += 'u';
                                        }
                                        else
                                        if (ch == 245) // if (ch == 'õ')
                                        {
                                            languageEnum += 'o';
                                        }
                                        else
                                        {
                                            Debug.LogError("Unhandled character \"" + ch + "\" (" + (int)ch + ") in \"" + temp + "\" while parsing \"CLDR/json-full/main/en/languages.json\" file");
                                        }
                                    }

                                    string languageCode = languagesJson.keys[i];
                                    string languageName = languageJson.str;

                                    if (languageCode.Length > maxCodeLength)
                                    {
                                        maxCodeLength = languageCode.Length;
                                    }

                                    if (languageName.Length > maxNameLength)
                                    {
                                        maxNameLength = languageName.Length;
                                    }

                                    languageCodes.Add(languageCode);
                                    languageEnums.Add(languageEnum);
                                    languageNames.Add(languageName);
                                }
                            },
                            delegate(string name)
                            {
                                good = false;

                                Debug.LogError("Entry \"" + name + "\" not found in \"" + cldrLanguagesFile + "\"");
                            });
                        },
                        delegate(string name)
                        {
                            good = false;

                            Debug.LogError("Entry \"" + name + "\" not found in \"" + cldrLanguagesFile + "\"");
                        });
                    },
                    delegate(string name)
                    {
                        good = false;

                        Debug.LogError("Entry \"" + name + "\" not found in \"" + cldrLanguagesFile + "\"");
                    });
                },
                delegate(string name)
                {
                    good = false;

                    Debug.LogError("Entry \"" + name + "\" not found in \"" + cldrLanguagesFile + "\"");
                });

                if (!good)
                {
                    return;
                }
                #endregion

                #region System languages
                string[] systemLanguages = Enum.GetNames(typeof(SystemLanguage));

                for (int i = 0; i < languageEnums.Count; ++i)
                {
                    int index = -1;

                    for (int j = 0; j < systemLanguages.Length; ++j)
                    {
                        if (languageEnums[i].Contains(systemLanguages[j]))
                        {
                            if (
                                index < 0
                                ||
                                systemLanguages[j].Length < systemLanguages[index].Length
                               )
                            {
                                index = j;
                            }
                        }
                    }

                    string systemLanguage;

                    if (index >= 0)
                    {
                        systemLanguage = systemLanguages[index];
                    }
                    else
                    {
                        systemLanguage = "English";
                    }

                    if (systemLanguage.Length > maxSystemNameLength)
                    {
                        maxSystemNameLength = systemLanguage.Length;
                    }

                    languageToSystemLanguages.Add(systemLanguage);
                }

                for (int i = 0; i < (int)SystemLanguage.Unknown; ++i)
                {
                    string systemLanguage = ((SystemLanguage)i).ToString();

                    int index = -1;

                    for (int j = 0; j < languageEnums.Count; ++j)
                    {
                        if (languageEnums[j].Contains(systemLanguage))
                        {
                            if (
                                index < 0
                                ||
                                languageEnums[j].Length < languageEnums[index].Length
                               )
                            {
                                index = j;
                            }
                        }
                    }

                    string language;

                    if (index >= 0)
                    {
                        language = languageEnums[index];
                    }
                    else
                    {
                        if (systemLanguage.Contains("Chinese"))
                        {
                            language = "Chinese";
                        }
                        else
                        {
                            language = "Default";
                        }
                    }

                    if (language.Length > maxLanguageNameLength)
                    {
                        maxLanguageNameLength = language.Length;
                    }

                    languageFromSystemLanguages.Add(language);
                }
                #endregion

                string res = "// This file generated from \"CLDR/json-full/main/en/languages.json\" file.\n" +
                             "using UnityEngine;\n" +
                             "\n" +
                             "\n" +
                             "\n" +
                             "namespace UnityTranslation\n" +
                             "{\n" +
                             "    /// <summary>\n" +
                             "    /// Language. This enumeration contains list of supported languages.\n" +
                             "    /// </summary>\n" +
                             "    public enum Language\n" +
                             "    {\n" +
                             "        /// <summary>\n" +
                             "        /// Default language. Equivalent for English.\n" +
                             "        /// </summary>\n" +
                             "        Default\n";

                for (int i = 0; i < languageNames.Count; ++i)
                {
                    res += "        ,\n" +
                           "        /// <summary>\n" +
                           "        /// " + languageNames[i] + ". Code: " + languageCodes[i] + "\n" +
                           "        /// </summary>\n" +
                           "        " + languageEnums[i] + "\n";
                }

                res += "        ,\n" +
                       "        /// <summary>\n" +
                       "        /// Total amount of languages.\n" +
                       "        /// </summary>\n" +
                       "        Count // Should be last\n" +
                       "    }\n" +
                       "\n" +
                       "    /// <summary>\n" +
                       "    /// This class provides methods for converting language code to Language enum and Language enum to language code\n" +
                       "    /// </summary>\n" +
                       "    public static class LanguageCode\n" +
                       "    {\n" +
                       "        /// <summary>\n" +
                       "        /// Array of language codes for each Language enum value.\n" +
                       "        /// </summary>\n" +
                       "        public static readonly string[] codes = new string[]\n" +
                       "        {\n" +
                       string.Format("              {0,-" + (maxCodeLength + 2) + "} // Default\n", "\"\"");

                for (int i = 0; i < languageCodes.Count; ++i)
                {
                    res += string.Format("            , {0,-" + (maxCodeLength + 2) + "} // {1}\n", "\"" + languageCodes[i] + "\"", languageEnums[i]);
                }

                res += "        };\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Converts Language enum value to language code\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Language code.</returns>\n" +
                       "        /// <param name=\"language\">Language enum value</param>\n" +
                       "        public static string LanguageToCode(Language language)\n" +
                       "        {\n" +
                       "            return codes[(int)language];\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Converts language code to Language enum value\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Language enum value.</returns>\n" +
                       "        /// <param name=\"code\">Language code</param>\n" +
                       "        public static Language CodeToLanguage(string code)\n" +
                       "        {\n" +
                       "            for (int i = 0; i < (int)Language.Count; ++i)\n" +
                       "            {\n" +
                       "                if (codes[i] == code)\n" +
                       "                {\n" +
                       "                    return (Language)i;\n" +
                       "                }\n" +
                       "            }\n" +
                       "\n" +
                       "            return Language.Count;\n" +
                       "        }\n" +
                       "    }\n" +
                       "\n" +
                       "    /// <summary>\n" +
                       "    /// This class provides methods for converting language name to Language enum and Language enum to language name\n" +
                       "    /// </summary>\n" +
                       "    public static class LanguageName\n" +
                       "    {\n" +
                       "        /// <summary>\n" +
                       "        /// Array of language names for each Language enum value.\n" +
                       "        /// </summary>\n" +
                       "        public static readonly string[] names = new string[]\n" +
                       "        {\n" +
                        string.Format("              {0,-" + (maxNameLength + 2) + "} // Default\n", "\"\"");

                for (int i = 0; i < languageNames.Count; ++i)
                {
                    res += string.Format("            , {0,-" + (maxNameLength + 2) + "} // {1}\n", "\"" + languageNames[i] + "\"", languageEnums[i]);
                }

                res += "        };\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Converts Language enum value to language name\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Language name.</returns>\n" +
                       "        /// <param name=\"language\">Language enum value</param>\n" +
                       "        public static string LanguageToName(Language language)\n" +
                       "        {\n" +
                       "            return names[(int)language];\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Converts language name to Language enum value\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Language enum value.</returns>\n" +
                       "        /// <param name=\"name\">Language name</param>\n" +
                       "        public static Language NameToLanguage(string name)\n" +
                       "        {\n" +
                       "            for (int i = 0; i < (int)Language.Count; ++i)\n" +
                       "            {\n" +
                       "                if (names[i] == name)\n" +
                       "                {\n" +
                       "                    return (Language)i;\n" +
                       "                }\n" +
                       "            }\n" +
                       "\n" +
                       "            return Language.Count;\n" +
                       "        }\n" +
                       "    }\n" +
                       "\n" +
                       "    /// <summary>\n" +
                       "    /// This class provides methods for converting SystemLanguage enum to Language enum and Language enum to SystemLanguage enum\n" +
                       "    /// </summary>\n" +
                       "    public static class LanguageSystemName\n" +
                       "    {\n" +
                       "        /// <summary>\n" +
                       "        /// Array of SystemLanguage enum values for each Language enum value.\n" +
                       "        /// </summary>\n" +
                       "        public static readonly SystemLanguage[] systemLanguages = new SystemLanguage[]\n" +
                       "        {\n" +
                       string.Format("              SystemLanguage.{0,-" + maxSystemNameLength + "} // Default\n", "English");

                for (int i = 0; i < languageToSystemLanguages.Count; ++i)
                {
                    res += string.Format("            , SystemLanguage.{0,-" + maxSystemNameLength + "} // {1}\n", languageToSystemLanguages[i], languageEnums[i]);
                }

                res += "        };\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Array of Language enum values for each SystemLanguage enum value.\n" +
                       "        /// </summary>\n" +
                       "        public static readonly Language[] languages = new Language[]\n" +
                       "        {\n";

                for (int i = 0; i < languageFromSystemLanguages.Count; ++i)
                {
                    if (i > 0)
                    {
                        res += string.Format("            , Language.{0,-" + maxLanguageNameLength + "} // {1}\n", languageFromSystemLanguages[i], "SystemLanguage." + ((SystemLanguage)i).ToString());
                    }
                    else
                    {
                        res += string.Format("              Language.{0,-" + maxLanguageNameLength + "} // {1}\n", languageFromSystemLanguages[i], "SystemLanguage." + ((SystemLanguage)i).ToString());
                    }
                }

                res += "        };\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Converts Language enum value to SystemLanguage enum value\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>SystemLanguage enum value.</returns>\n" +
                       "        /// <param name=\"language\">Language enum value</param>\n" +
                       "        public static SystemLanguage LanguageToSystemLanguage(Language language)\n" +
                       "        {\n" +
                       "            return systemLanguages[(int)language];\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Converts SystemLanguage enum value to Language enum value\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Language enum value.</returns>\n" +
                       "        /// <param name=\"language\">SystemLanguage enum value</param>\n" +
                       "        public static Language SystemLanguageToLanguage(SystemLanguage language)\n" +
                       "        {\n" +
                       "            return languages[(int)language];\n" +
                       "        }\n" +
                       "    }\n" +
                       "}\n";

                File.WriteAllText(targetFile, res, Encoding.UTF8);
            }
            else
            {
                Debug.LogError("Incorrect file format in \"" + cldrLanguagesFile + "\"");

                return;
            }
            #endregion

            #region Caching CLDR languages file
            Debug.Log("Caching CLDR languages file in \"" + tempLanguagesFile + "\"");
            Directory.CreateDirectory(Application.temporaryCachePath + "/UnityTranslation");
            File.WriteAllBytes(tempLanguagesFile, cldrFileBytes);
            #endregion
        }

        /// <summary>
        /// Generates PluralsRules.cs file
        /// </summary>
        private static void GeneratePluralsRules()
        {
            string cldrPluralsFile = Application.dataPath           + "/../3rd_party/CLDR/json-full/supplemental/plurals.json";
            string tempPluralsFile = Application.temporaryCachePath + "/UnityTranslation/plurals.json";

            string targetFile = Application.dataPath + "/Scripts/UnityTranslation/Generated/PluralsRules.cs";

            byte[] cldrFileBytes = null;

            #region Check that PluralsRules.cs is up to date
            if (!File.Exists(cldrPluralsFile))
            {
                Debug.LogError("File \"" + cldrPluralsFile + "\" not found");

                return;
            }

            cldrFileBytes = File.ReadAllBytes(cldrPluralsFile);

#if !FORCE_CODE_GENERATION
            if (
                !sChangedGeneratedLanguage
                &&
                !sChangedGeneratedPluralsRules
                &&
                File.Exists(targetFile)
                &&
                File.Exists(tempPluralsFile)
               )
            {
                byte[] tempFileBytes = File.ReadAllBytes(tempPluralsFile);

                if (cldrFileBytes.SequenceEqual(tempFileBytes))
                {
                    return;
                }
            }
#endif
            #endregion

            #region Generating PluralsRules.cs file
            Debug.Log("Generating \"PluralsRules.cs\" file");

            string cldrFileText = Encoding.UTF8.GetString(cldrFileBytes);
            JSONObject json = new JSONObject(cldrFileText);

            if (json.type == JSONObject.Type.OBJECT)
            {
                List<List<Language>>                      languages = new List<List<Language>>();
                List<Dictionary<PluralsQuantity, string>> plurals   = new List<Dictionary<PluralsQuantity, string>>();

                #region Parse JSON
                bool good = true;

                json.GetField("supplemental", delegate(JSONObject supplementalJson)
                {
                    supplementalJson.GetField("plurals-type-cardinal", delegate(JSONObject pluralsJson)
                    {
                        for (int i = 0; i < pluralsJson.list.Count; ++i)
                        {
                            if (pluralsJson.keys[i] == "root")
                            {
                                continue;
                            }

                            JSONObject languageJson = pluralsJson.list[i];

                            List<Language> languagesList = new List<Language>();

                            for (int j = 0; j < LanguageCode.codes.Length; ++j)
                            {
                                if (
                                    LanguageCode.codes[j] == pluralsJson.keys[i]
                                    ||
                                    LanguageCode.codes[j].StartsWith(pluralsJson.keys[i] + "-")
                                   )
                                {
                                    languagesList.Add((Language)j);
                                }
                            }

                            if (languagesList.Count == 0)
                            {
                                Debug.LogWarning("Unexpected language code \"" + pluralsJson.keys[i] + "\" in \"" + cldrPluralsFile + "\". Skipped");

                                continue;
                            }

                            Dictionary<PluralsQuantity, string> languagePlurals = new Dictionary<PluralsQuantity, string>();

                            for (int j = 0; j < languageJson.list.Count; ++j)
                            {
                                PluralsQuantity quantity;

                                if (languageJson.keys[j] == "pluralRule-count-zero")
                                {
                                    quantity = PluralsQuantity.Zero;
                                }
                                else
                                if (languageJson.keys[j] == "pluralRule-count-one")
                                {
                                    quantity = PluralsQuantity.One;
                                }
                                else
                                if (languageJson.keys[j] == "pluralRule-count-two")
                                {
                                    quantity = PluralsQuantity.Two;
                                }
                                else
                                if (languageJson.keys[j] == "pluralRule-count-few")
                                {
                                    quantity = PluralsQuantity.Few;
                                }
                                else
                                if (languageJson.keys[j] == "pluralRule-count-many")
                                {
                                    quantity = PluralsQuantity.Many;
                                }
                                else
                                if (languageJson.keys[j] == "pluralRule-count-other")
                                {
                                    quantity = PluralsQuantity.Other;
                                }
                                else
                                {
                                    good = false;

                                    Debug.LogError("Unexpected plurals \"" + languageJson.keys[j] + "\" found for language code \"" + pluralsJson.keys[i] + "\" in \"" + cldrPluralsFile + "\"");

                                    break;
                                }

                                languagePlurals[quantity] = languageJson.list[j].str;
                            }

                            if (!good)
                            {
                                break;
                            }

                            int index = -1;

                            for (int j = 0; j < plurals.Count; ++j)
                            {
                                index = j;

                                for (int k = 0; k < (int)PluralsQuantity.Count; ++k)
                                {
                                    string leftString;
                                    string rightString;

                                    plurals[j].TryGetValue(     (PluralsQuantity)k, out leftString);
                                    languagePlurals.TryGetValue((PluralsQuantity)k, out rightString);

                                    if (leftString == null && rightString == null)
                                    {
                                        continue;
                                    }

                                    if (
                                        leftString != null && rightString == null
                                        ||
                                        leftString == null && rightString != null
                                       )
                                    {
                                        index = -1;
                                        break;
                                    }

                                    int charIndex = leftString.IndexOf('@');

                                    if (charIndex >= 0)
                                    {
                                        leftString = leftString.Substring(0, charIndex).Trim();
                                    }

                                    charIndex = rightString.IndexOf('@');

                                    if (charIndex >= 0)
                                    {
                                        rightString = rightString.Substring(0, charIndex).Trim();
                                    }

                                    if (leftString != rightString)
                                    {
                                        index = -1;
                                        break;
                                    }
                                }

                                if (index >= 0)
                                {
                                    break;
                                }
                            }

                            if (index >= 0)
                            {
                                languages[index].AddRange(languagesList);
                            }
                            else
                            {
                                languages.Add(languagesList);
                                plurals.Add(languagePlurals);
                            }
                        }
                    },
                    delegate(string name)
                    {
                        good = false;

                        Debug.LogError("Entry \"" + name + "\" not found in \"" + cldrPluralsFile + "\"");
                    });
                },
                delegate(string name)
                {
                    good = false;

                    Debug.LogError("Entry \"" + name + "\" not found in \"" + cldrPluralsFile + "\"");
                });

                if (!good)
                {
                    return;
                }

                #region Move English plurals to the beginning
                for (int i = 0; i < languages.Count; ++i)
                {
                    if (languages[i].Contains(Language.English))
                    {
                        List<Language>                      englishLanguages = languages[i];
                        Dictionary<PluralsQuantity, string> englishPlurals   = plurals[i];

                        languages.RemoveAt(i);
                        plurals.RemoveAt(i);

                        languages.Insert(0, englishLanguages);
                        plurals.Insert(0, englishPlurals);

                        break;
                    }
                }
                #endregion

                #endregion

                string res = "// This file generated from \"CLDR/json-full/supplemental/plurals.json\" file.\n" +
                             "using System;\n" +
                             "\n" +
                             "\n" +
                             "\n" +
                             "namespace UnityTranslationInternal\n" +
                             "{\n" +
                             "    /// <summary>\n" +
                             "    /// Container for all plurals rules for each language.\n" +
                             "    /// </summary>\n" +
                             "    public static class PluralsRules\n" +
                             "    {\n" +
                             "        /// <summary>\n" +
                             "        /// Delegate function that returns PluralsQuantity related to provided quantity.\n" +
                             "        /// </summary>\n" +
                             "        /// <returns>PluralsQuantity value</returns>\n" +
                             "        /// <param name=\"quantity\">Quantity</param>\n" +
                             "        public delegate PluralsQuantity PluralsFunction(double quantity);\n" +
                             "\n" +
                             "        /// <summary>\n" +
                             "        /// Array of functions for getting PluralsQuantity.\n" +
                             "        /// </summary>\n" +
                             "        public static readonly PluralsFunction[] pluralsFunctions = new PluralsFunction[]\n" +
                             "        {\n" +
                             "              PluralsDefaultFunction  // Default\n";

                for (int i = 1; i < (int)Language.Count; ++i)
                {
                    Language language = (Language)i;

                    int index = -1;

                    for (int j = 0; j < languages.Count; ++j)
                    {
                        if (languages[j].Contains(language))
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index >= 0)
                    {
                        if (index == 0)
                        {
                            res += "            , PluralsDefaultFunction  // " + language + "\n";
                        }
                        else
                        {
                            res += string.Format("            , {0,-23} // {1}\n", "PluralsFunction" + index, language);
                        }
                    }
                    else
                    {
                        res += "            , PluralsFallbackFunction // " + language + "\n";
                    }
                }

                res += "        };\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Fallback function for any language without plurals rules that just return PluralsQuantity.Other.\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>PluralsQuantity.Other.</returns>\n" +
                       "        /// <param name=\"quantity\">Quantity.</param>\n" +
                       "        private static PluralsQuantity PluralsFallbackFunction(double quantity)\n" +
                       "        {\n" +
                       "            return PluralsQuantity.Other;\n" +
                       "        }\n";

                for (int i = 0; i < languages.Count; ++i)
                {
                    string functionName = (i == 0)? "PluralsDefaultFunction" : ("PluralsFunction" + i);

                    res += "\n" +
                           "        /// <summary>\n";

                    if (i == 0)
                    {
                        res += "        /// <para>Default function for languages that has the same plurals rules as for English</para>\n";
                    }
                    else
                    {
                        res += "        /// <para>Some function for getting PluralsQuantity</para>\n";
                    }

                    res += "        /// <para>Used in languages:</para>\n";

                    for (int j = 0; j < languages[i].Count; ++j)
                    {
                        res += "        /// <para>" + languages[i][j] + "</para>\n";
                    }

                    res += "        /// </summary>\n" +
                           "        /// <returns>PluralsQuantity related to provided quantity.</returns>\n" +
                           "        /// <param name=\"quantity\">Quantity.</param>\n" +
                           "        private static PluralsQuantity " + functionName + "(double quantity)\n" +
                           "        {\n";

                    List<string> additionalLines = new List<string>();
                    List<string> conditions      = new List<string>();

                    for (int j = 0; j < (int)PluralsQuantity.Other; ++j)
                    {
                        string pluralsCondition;

                        if (plurals[i].TryGetValue((PluralsQuantity)j, out pluralsCondition))
                        {
                            conditions.Add("            if (" + TransformPluralsCondition(pluralsCondition, ref additionalLines) + ") // " + pluralsCondition + "\n" +
                                           "            {\n" +
                                           "                return PluralsQuantity." + (PluralsQuantity)j + ";\n" +
                                           "            }");
                        }
                    }

                    if (additionalLines.Count > 0)
                    {
                        for (int j = 0; j < additionalLines.Count; ++j)
                        {
                            if (additionalLines[j] == "")
                            {
                                res += "\n";
                            }
                            else
                            {
                                res += "            " + additionalLines[j] + "\n";
                            }
                        }

                        res += "\n";
                    }

                    for (int j = 0; j < conditions.Count; ++j)
                    {
                        res += conditions[j] + "\n" +
                               "\n";
                    }

                    res += "            return PluralsQuantity.Other;\n" +
                           "        }\n";
                }

                res += "    }\n" +
                       "}\n";

                File.WriteAllText(targetFile, res, Encoding.UTF8);
                File.WriteAllText(Application.temporaryCachePath + "/UnityTranslation/PluralsRules.cs", res, Encoding.UTF8);
            }
            else
            {
                Debug.LogError("Incorrect file format in \"" + cldrPluralsFile + "\"");

                return;
            }
            #endregion

            #region Caching CLDR plurals file
            Debug.Log("Caching CLDR plurals file in \"" + tempPluralsFile + "\"");
            Directory.CreateDirectory(Application.temporaryCachePath + "/UnityTranslation");
            File.WriteAllBytes(tempPluralsFile, cldrFileBytes);
            #endregion
        }

        /// <summary>
        /// Transforms the plurals condition in C# syntax.
        /// </summary>
        /// <returns>Plurals condition in C# syntax.</returns>
        /// <param name="condition">Plurals condition.</param>
        /// <param name="additionalLines">Additional lines if needed.</param>
        private static string TransformPluralsCondition(string condition, ref List<string> additionalLines)
        {
            int index = condition.IndexOf('@');

            if (index >= 0)
            {
                condition = condition.Substring(0, index).Trim();
            }

            condition = condition.Replace("or",  " || ").Replace("and", " && ");
            condition = condition.Replace("%",   " % " ).Replace("=",   " == ").Replace("! ==",   " != ");

            do
            {
                string oldCondition = condition;

                condition = condition.Replace("  ", " ");

                if (condition == oldCondition)
                {
                    break;
                }
            } while (true);

            condition = condition.Replace(", ",  "," ).Replace(" ,",  ",");
            condition = condition.Replace(".. ", "..").Replace(" ..", "..");



            bool containsN = condition.Contains("n");
            bool containsI = condition.Contains("i");
            bool containsV = condition.Contains("v");
            bool containsW = condition.Contains("w");
            bool containsF = condition.Contains("f");
            bool containsT = condition.Contains("t");

            if (
                containsN
                ||
                containsI
                ||
                containsV
                ||
                containsW
                ||
                containsF
                ||
                containsT
               )
            {
                string newAdditionalLine = "double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)";

                if (!additionalLines.Contains(newAdditionalLine))
                {
                    additionalLines.Add(newAdditionalLine);
                }

                if (containsI)
                {
                    newAdditionalLine = "int    i = (int)Math.Floor(n);       // integer digits of n";

                    if (!additionalLines.Contains(newAdditionalLine))
                    {
                        additionalLines.Add(newAdditionalLine);
                    }
                }

                if (
                    containsV
                    ||
                    containsW
                    ||
                    containsF
                    ||
                    containsT
                   )
                {
                    newAdditionalLine = "int    v = 3;                        // number of visible fraction digits in n, with trailing zeros";

                    if (!additionalLines.Contains(newAdditionalLine))
                    {
                        additionalLines.Add(newAdditionalLine);
                        additionalLines.Add("int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros");
                        additionalLines.Add("");
                        additionalLines.Add("if (f == 0)");
                        additionalLines.Add("{");
                        additionalLines.Add("    v = 0;");
                        additionalLines.Add("}");
                        additionalLines.Add("else");
                        additionalLines.Add("{");
                        additionalLines.Add("    while ((f > 0) && (f % 10 == 0))");
                        additionalLines.Add("    {");
                        additionalLines.Add("        f /= 10;");
                        additionalLines.Add("        --v;");
                        additionalLines.Add("    }");
                        additionalLines.Add("}");
                    }

                    if (
                        containsW
                        ||
                        containsT
                       )
                    {
                        if (containsW)
                        {
                            newAdditionalLine = "int    w = v;                        // number of visible fraction digits in n, without trailing zeros";

                            if (!additionalLines.Contains(newAdditionalLine))
                            {
                                additionalLines.Add("");
                                additionalLines.Add(newAdditionalLine);
                            }
                        }

                        if (containsT)
                        {
                            newAdditionalLine = "int    t = f;                        // visible fractional digits in n, without trailing zeros";

                            if (!additionalLines.Contains(newAdditionalLine))
                            {
                                additionalLines.Add("");
                                additionalLines.Add(newAdditionalLine);
                            }
                        }
                    }
                }
            }

            if (condition.Contains("n % 1000000"))
            {
                string newAdditionLine = "double n_mod_1000000 = n % 1000000;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("n % 1000000", "n_mod_1000000");
            }

            if (condition.Contains("n % 100"))
            {
                string newAdditionLine = "double n_mod_100 = n % 100;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("n % 100", "n_mod_100");
            }

            if (condition.Contains("n % 10"))
            {
                string newAdditionLine = "double n_mod_10 = n % 10;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("n % 10", "n_mod_10");
            }

            if (condition.Contains("i % 100"))
            {
                string newAdditionLine = "int i_mod_100 = i % 100;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("i % 100", "i_mod_100");
            }

            if (condition.Contains("i % 10"))
            {
                string newAdditionLine = "int i_mod_10 = i % 10;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("i % 10", "i_mod_10");
            }

            if (condition.Contains("f % 100"))
            {
                string newAdditionLine = "int f_mod_100 = f % 100;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("f % 100", "f_mod_100");
            }

            if (condition.Contains("f % 10"))
            {
                string newAdditionLine = "int f_mod_10 = f % 10;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("f % 10", "f_mod_10");
            }

            if (condition.Contains("t % 100"))
            {
                string newAdditionLine = "int t_mod_100 = t % 100;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("t % 100", "t_mod_100");
            }

            if (condition.Contains("t % 10"))
            {
                string newAdditionLine = "int t_mod_10 = t % 10;";

                if (!additionalLines.Contains(newAdditionLine))
                {
                    additionalLines.Add(newAdditionLine);
                }

                condition = condition.Replace("t % 10", "t_mod_10");
            }

            List<string> conditionTokens = new List<string>(condition.Split(' '));

            if (conditionTokens.Count == 0)
            {
                Debug.LogError("Impossible to transform condition \"" + condition + "\"");

                return "false";
            }

            for (int i = 0; i < conditionTokens.Count; ++i)
            {
                if (
                    conditionTokens[i].Contains(',')
                    ||
                    conditionTokens[i].Contains("..")
                   )
                {
                    if (i < 2)
                    {
                        Debug.LogError("Impossible to transform condition \"" + condition + "\". Incorrect syntax");

                        return "false";
                    }

                    string varName      = conditionTokens[i - 2];
                    string operatorType = conditionTokens[i - 1];
                    string rangeList    = conditionTokens[i];

                    if (operatorType != "==" && operatorType != "!=")
                    {
                        Debug.LogError("Impossible to transform condition \"" + condition + "\". Incorrect operator \"" + operatorType + "\"");

                        return "false";
                    }

                    string[] separator = new string[] { ".." };

                    List<string[]> ranges = new List<string[]>();

                    foreach (string rangeEnum in rangeList.Split(','))
                    {
                        ranges.Add(rangeEnum.Split(separator, StringSplitOptions.None));
                    }

                    string replacement = "";

                    if (operatorType == "==")
                    {
                        for (int j = 0; j < ranges.Count; ++j)
                        {
                            if (j > 0)
                            {
                                replacement += " || ";
                            }

                            if (ranges[j].Length == 1)
                            {
                                replacement += varName + " == " + ranges[j][0];
                            }
                            else
                            if (ranges[j].Length == 2)
                            {
                                replacement += "(" + varName + " >= " + ranges[j][0] + " && " + varName + " <= " + ranges[j][1] + ")";
                            }
                            else
                            {
                                Debug.LogError("Impossible to transform condition \"" + condition + "\". Incorrect range \"" + rangeList + "\"");

                                return "false";
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < ranges.Count; ++j)
                        {
                            if (j > 0)
                            {
                                replacement += " && ";
                            }

                            if (ranges[j].Length == 1)
                            {
                                replacement += varName + " != " + ranges[j][0];
                            }
                            else
                            if (ranges[j].Length == 2)
                            {
                                replacement += "(" + varName + " < " + ranges[j][0] + " || " + varName + " > " + ranges[j][1] + ")";
                            }
                            else
                            {
                                Debug.LogError("Impossible to transform condition \"" + condition + "\". Incorrect range \"" + rangeList + "\"");

                                return "false";
                            }
                        }
                     }

                    if (ranges.Count > 1)
                    {
                        replacement = "(" + replacement + ")";
                    }

                    i -= 2;

                    conditionTokens.RemoveAt(i);
                    conditionTokens.RemoveAt(i);

                    conditionTokens[i] = replacement;
                }
            }

            string res = "";

            for (int i = 0; i < conditionTokens.Count; ++i)
            {
                if (i > 0)
                {
                    res += " ";
                }

                res += conditionTokens[i];
            }

            return res;
        }
#endif

        /// <summary>
        /// Generates Assets/Resources/res/values/strings.xml file if absent
        /// </summary>
        private static void GenerateStringsXml()
        {
            string valuesFolder   = Application.dataPath + "/Resources/res/values";
            string stringsXmlFile = valuesFolder + "/strings.xml";

            if (!File.Exists(stringsXmlFile))
            {
                Debug.Log("Generating \"Assets/Resources/res/values/strings.xml\" file");

                Directory.CreateDirectory(valuesFolder);

                File.WriteAllText(stringsXmlFile
                                  , "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                                    "<resources>\n" +
                                    "\n" +
                                    "    <!-- Application name -->\n" +
                                    "    <string name=\"app_name\">Application name</string>\n" +
                                    "\n" +
                                    "</resources>"
                                  , Encoding.UTF8);

                Debug.LogWarning("Resource \"Assets/Resources/res/values/strings.xml\" generated. Please rebuild your application. You have to switch focus to another application to let Unity check that project structure was changed.");
            }
        }

        /// <summary>
        /// Generates AvailableLanguages.cs file
        /// </summary>
        private static void GenerateAvailableLanguages()
        {
            List<string> valuesFolders       = new List<string>();
            string       valuesFoldersString = "";

            #region Getting list of languages in Assets/Resources/res
            DirectoryInfo   resDir = new DirectoryInfo(Application.dataPath + "/Resources/res");
            DirectoryInfo[] dirs   = resDir.GetDirectories();

            for (int i = 0; i < dirs.Length; ++i)
            {
                string dirName = dirs[i].Name;

                if (dirName.StartsWith("values-"))
                {
                    string locale = dirName.Substring(7);

                    valuesFolders.Add(locale);
                    valuesFoldersString += locale + "\n";
                }
                else
                if (dirName != "values")
                {
                    Debug.LogError("Unexpected folder name \"" + dirName + "\" in \"Assets/Resources/res\"");

                    return;
                }
            }
            #endregion

            string tempValuesFolderFile = Application.temporaryCachePath + "/UnityTranslation/valuesFolders.txt";

            string targetFile = PathToGeneratedFile("AvailableLanguages.cs");

            #region Check that AvailableLanguages.cs is up to date
#if !FORCE_CODE_GENERATION
            if (
#if I_AM_UNITY_TRANSLATION_DEVELOPER
                !sChangedGeneratedLanguage
                &&
#endif
                !sСhangedGeneratedAvailableLanguages
                &&
                File.Exists(targetFile)
                &&
                File.Exists(tempValuesFolderFile)
               )
            {
                string tempFileText = File.ReadAllText(tempValuesFolderFile);

                if (valuesFoldersString == tempFileText)
                {
                    return;
                }
            }
#endif
            #endregion

            #region Generating AvailableLanguages.cs file
            Debug.Log("Generating \"AvailableLanguages.cs\" file");

            string[]                     languageCodes     = LanguageCode.codes;
            Dictionary<Language, string> languageRealCodes = new Dictionary<Language, string>();

            for (int i = 0; i < valuesFolders.Count; ++i)
            {
                int index = -1;

                for (int j = 1; j < languageCodes.Length; ++j)
                {
                    string originalLanguageCode = languageCodes[j];
                    string languageCode         = originalLanguageCode;

                    int dashIndex = languageCode.IndexOf('-');

                    if (dashIndex >= 0)
                    {
                        languageCode = languageCode.Insert(dashIndex + 1, "r");
                    }

                    if (
                        valuesFolders[i].StartsWith(originalLanguageCode)
                        ||
                        valuesFolders[i].StartsWith(languageCode)
                        )
                    {
                        if (
                            index < 0
                            ||
                            languageCodes[j].Length > languageCodes[index].Length
                           )
                        {
                            index = j;
                        }
                    }
                }

                if (index < 0)
                {
                    Debug.LogError("Unknown language code \"" + valuesFolders[i] + "\" found in \"Assets/Resources/res\"");

                    return;
                }

                languageRealCodes[(Language)index] = valuesFolders[i];
            }

            int maxCodeLength     = 0;
            int maxRealCodeLength = 0;

            foreach (Language language in languageRealCodes.Keys)
            {
                string languageCode     = language.ToString();
                string languageRealCode = languageRealCodes[language];

                if (languageCode.Length > maxCodeLength)
                {
                    maxCodeLength = languageCode.Length;
                }

                if (languageRealCode.Length > maxRealCodeLength)
                {
                    maxRealCodeLength = languageRealCode.Length;
                }
            }

            string res = "// This file generated according to the list of \"Assets/Resources/res/values-*\" folders.\n" +
                         "using System.Collections.Generic;\n" +
                         "\n" +
                         "\n" +
                         "\n" +
                         "namespace UnityTranslation\n" +
                         "{\n" +
                         "    /// <summary>\n" +
                         "    /// Container for all languages specified in \"Assets/Resources/res\"\n" +
                         "    /// </summary>\n" +
                         "    public static class AvailableLanguages\n" +
                         "    {\n" +
                         "        /// <summary>\n" +
                         "        /// List of all languages specified in \"Assets/Resources/res\"\n" +
                         "        /// </summary>\n" +
                         "        public static readonly Dictionary<Language, string> list = new Dictionary<Language, string>\n" +
                         "        {\n" +
                         string.Format("              {{ Language.{0,-" + (maxCodeLength + 1) + "} {1,-" + (maxRealCodeLength + 2) + "} }}\n", "Default,", "\"\"");

            foreach (Language language in languageRealCodes.Keys)
            {
                res += string.Format("            , {{ Language.{0,-" + (maxCodeLength + 1) + "} {1,-" + (maxRealCodeLength + 2) + "} }}\n", language.ToString() + ",", "\"" + languageRealCodes[language] + "\"");
            }

            res += "        };\n" +
                   "    }\n" +
                   "}\n";

            File.WriteAllText(targetFile, res, Encoding.UTF8);
            File.WriteAllText(Application.temporaryCachePath + "/UnityTranslation/AvailableLanguages.cs", res, Encoding.UTF8);
            #endregion

            #region Caching valuesFolders.txt file
            Debug.Log("Caching valuesFolders.txt file in \"" + tempValuesFolderFile + "\"");
            Directory.CreateDirectory(Application.temporaryCachePath + "/UnityTranslation");
            File.WriteAllText(tempValuesFolderFile, valuesFoldersString);
            #endregion
        }

        /// <summary>
        /// Generates R.cs file for all specified tokens
        /// </summary>
        /// <returns>List of sections ID if regenerated or null.</returns>
        private static List<string> GenerateR()
        {
            string tempValuesPath = Application.temporaryCachePath + "/UnityTranslation/values";

            if (!Directory.Exists(tempValuesPath))
            {
                Directory.CreateDirectory(tempValuesPath);
            }

            DirectoryInfo valuesDir     = new DirectoryInfo(Application.dataPath + "/Resources/res/values");
            DirectoryInfo tempValuesDir = new DirectoryInfo(tempValuesPath);

            FileInfo[] xmlFiles     = valuesDir.GetFiles("*.xml");
            FileInfo[] tempXmlFiles = tempValuesDir.GetFiles("*.xml");

            string targetFile = PathToGeneratedFile("R.cs");

            #region Check that R.cs is up to date
#if !FORCE_CODE_GENERATION
            if (
                !sChangedGeneratedR
                &&
                File.Exists(targetFile)
                &&
                xmlFiles.Length == tempXmlFiles.Length
               )
            {
                bool good = true;

                for (int i = 0; i < xmlFiles.Length; ++i)
                {
                    if (xmlFiles[i].Name != tempXmlFiles[i].Name)
                    {
                        good = false;
                        break;
                    }
                }

                if (good)
                {
                    for (int i = 0; i < xmlFiles.Length; ++i)
                    {
                        byte[] leftBytes  = File.ReadAllBytes(xmlFiles[i].FullName);
                        byte[] rightBytes = File.ReadAllBytes(tempXmlFiles[i].FullName);

                        if (!leftBytes.SequenceEqual(rightBytes))
                        {
                            good = false;
                            break;
                        }
                    }

                    if (good)
                    {
                        return null;
                    }
                }
            }
#endif
            #endregion

            #region Move strings.xml to the beginning
            int index = -1;

            for (int i = 0; i < xmlFiles.Length; ++i)
            {
                if (xmlFiles[i].Name == "strings.xml")
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                if (index > 0)
                {
                    FileInfo stringsFileInfo = xmlFiles[index];

                    for (int i = index; i > 0; --i)
                    {
                        xmlFiles[i] = xmlFiles[i - 1];
                    }

                    xmlFiles[0] = stringsFileInfo;
                }
            }
            else
            {
                Debug.LogError("strings.xml file not found in \"Assets/Resources/res/values\"");
            }
            #endregion

            #region Generating R.cs file
            Debug.Log("Generating \"R.cs\" file");

            int maxNameLength = 0;

            List<SectionTokens> sections   = new List<SectionTokens>();
            List<string>        sectionIds = new List<string>();

            #region Getting section IDs
            // First is strings.xml
            for (int i = 1; i < xmlFiles.Length; ++i)
            {
                string sectionId     = "";
                bool   goodSectionId = true;



                string filename = xmlFiles[i].Name;

                if (filename.Length > maxNameLength)
                {
                    maxNameLength = filename.Length;
                }

                filename = filename.Remove(filename.Length - 4);



                bool nextCharCapital = true;

                for (int j = 0; j < filename.Length; ++j)
                {
                    char ch = filename[j];

                    if (
                        ch >= 'a' && ch <= 'z'
                        ||
                        ch >= 'A' && ch <= 'Z'
                       )
                    {
                        if (nextCharCapital)
                        {
                            nextCharCapital = false;

                            sectionId += Char.ToUpper(ch);
                        }
                        else
                        {
                            sectionId += ch;
                        }
                    }
                    else
                    {
                        if (ch >= '0' && ch <= '9')
                        {
                            if (sectionId != "")
                            {
                                sectionId += ch;
                            }
                            else
                            {
                                goodSectionId = false;
                            }
                        }

                        nextCharCapital = true;
                    }
                }

                if (
                    sectionId == ""
                    ||
                    sectionId == "Equals"
                    ||
                    sectionId == "ReferenceEquals"
                    ||
                    sectionId == "SectionID"
                    ||
                    sectionId == "xmlFiles"
                   )
                {
                    goodSectionId = false;

                    sectionId = "Section" + i;
                }

                if (!goodSectionId)
                {
                    Debug.LogWarning("Generated not good section ID \"" + sectionId + "\" for file name \"" + xmlFiles[i].Name + "\". Please try to rename xml file");
                }

                if (sectionIds.Contains(sectionId))
                {
                    Debug.LogError("Generated duplicate section ID \"" + sectionId + "\" for file name \"" + xmlFiles[i].Name + "\". Please try to rename xml file");

                    return null;
                }

                sectionIds.Add(sectionId);
            }
            #endregion

            #region Parse xml files
            for (int i = 0; i < xmlFiles.Length; ++i)
            {
                SectionTokens sectionTokens = ParseXmlTokens(xmlFiles[i].FullName);

                if (sectionTokens == null)
                {
                    return null;
                }

                sections.Add(sectionTokens);
            }
            #endregion

            string res = "// This file generated from xml files in \"Assets/Resources/res/values\".\n" +
                         "using System.Collections.Generic;\n" +
                         "\n" +
                         "\n" +
                         "\n" +
                         "namespace UnityTranslation\n" +
                         "{\n" +
                         "    /// <summary>\n" +
                         "    /// Container for all tokens specified in xml files in \"Assets/Resources/res/values\".\n" +
                         "    /// </summary>\n" +
                         "    public static class R\n" +
                         "    {\n";

            res += GenerateCodeForSectionTokens(sections[0], "strings.xml", "        ");

            res += "\n" +
                   "        /// <summary>\n" +
                   "        /// Container for dynamically loadable tokens specified in non strings.xml files.\n" +
                   "        /// </summary>\n" +
                   "        public static class sections\n" +
                   "        {\n" +
                   "            /// <summary>\n" +
                   "            /// Section ID. This enumeration contains list of dynamically loadable sections.\n" +
                   "            /// </summary>\n" +
                   "            public enum SectionID\n" +
                   "            {\n";

            for (int i = 0; i < sectionIds.Count; ++i)
            {
                res += "                /// <summary>\n" +
                       "                /// Section ID for \"" + xmlFiles[i + 1].Name + "\" file.\n" +
                       "                /// </summary>\n" +
                       "                " + sectionIds[i] + "\n" +
                       "                ,\n";
            }

            res += "                /// <summary>\n" +
                   "                /// Total amount of sections.\n" +
                   "                /// </summary>\n" +
                   "                Count // Should be last\n" +
                   "            }\n" +
                   "\n" +
                   "            /// <summary>\n" +
                   "            /// Names of xml files for each section.\n" +
                   "            /// </summary>\n" +
                   "            public static readonly string[] xmlFiles = new string[]\n" +
                   "            {\n";

            for (int i = 0; i < sectionIds.Count; ++i)
            {
                if (i > 0)
                {
                    res += string.Format("                , {0,-" + (maxNameLength + 2) + "} // {1}\n", "\"" + xmlFiles[i + 1].Name + "\"", sectionIds[i]);
                }
                else
                {
                    res += string.Format("                  {0,-" + (maxNameLength + 2) + "} // {1}\n", "\"" + xmlFiles[i + 1].Name + "\"", sectionIds[i]);
                }
            }

            res += "            };\n";

            for (int i = 0; i < sectionIds.Count; ++i)
            {
                res += "\n" +
                       "            /// <summary>\n" +
                       "            /// Container for all tokens specified in \"Assets/Resources/res/values/" + xmlFiles[i + 1].Name + "\" file.\n" +
                       "            /// </summary>\n" +
                       "            public static class " + sectionIds[i] + "\n" +
                       "            {\n" +
                       GenerateCodeForSectionTokens(sections[i + 1], xmlFiles[i + 1].Name, "                ") +
                       "            }\n";
            }

            res += "        }\n" +
                   "\n" +
                   "        /// <summary>\n" +
                   "        /// <para>Container for all token IDs in strings.xml (index 0) and in another sections</para>\n" +
                   "        /// <para>Each element of tokenIds is an array with 3 elements inside:</para>\n" +
                   "        /// <para>0: strings tokens</para>\n" +
                   "        /// <para>1: array tokens</para>\n" +
                   "        /// <para>2: plurals tokens</para>\n" +
                   "        /// </summary>\n" +
                   "        public static readonly Dictionary<string, int>[][] tokenIds = new Dictionary<string, int>[][]\n" +
                   "        {\n";

            for (int i = 0; i <= sectionIds.Count; ++i)
            {
                string prefix;

                if (i > 0)
                {
                    prefix = "R.sections." + sectionIds[i - 1] + ".";

                    res += "            ,\n" +
                           "            new Dictionary<string, int>[] // " + sectionIds[i - 1] + "\n";
                }
                else
                {
                    prefix = "R.";

                    res += "            new Dictionary<string, int>[] // Global\n";
                }

                res += "            {\n" +
                       "                new Dictionary<string, int> // strings\n" +
                       "                {\n";

                int maxTokenNameLength = 0;

                for (int j = 0; j < sections[i].stringNames.Count; ++j)
                {
                    if (sections[i].stringNames[j].Length > maxTokenNameLength)
                    {
                        maxTokenNameLength = sections[i].stringNames[j].Length;
                    }
                }

                for (int j = 0; j < sections[i].stringNames.Count; ++j)
                {
                    if (j > 0)
                    {
                        res += string.Format("                    , {{ {0,-" + (maxTokenNameLength + 2) + "}, {1,-" + (maxTokenNameLength + 15) + "} }}\n", "\"" + sections[i].stringNames[j] + "\"", "(int)" + prefix + "strings." + sections[i].stringNames[j]);
                    }
                    else
                    {
                        res += string.Format("                      {{ {0,-" + (maxTokenNameLength + 2) + "}, {1,-" + (maxTokenNameLength + 15) + "} }}\n", "\"" + sections[i].stringNames[j] + "\"", "(int)" + prefix + "strings." + sections[i].stringNames[j]);
                    }
                }

                res += "                }\n" +
                       "                ,\n" +
                       "                new Dictionary<string, int> // array\n" +
                       "                {\n";

                maxTokenNameLength = 0;

                for (int j = 0; j < sections[i].stringArrayNames.Count; ++j)
                {
                    if (sections[i].stringArrayNames[j].Length > maxTokenNameLength)
                    {
                        maxTokenNameLength = sections[i].stringArrayNames[j].Length;
                    }
                }

                for (int j = 0; j < sections[i].stringArrayNames.Count; ++j)
                {
                    if (j > 0)
                    {
                        res += string.Format("                    , {{ {0,-" + (maxTokenNameLength + 2) + "}, {1,-" + (maxTokenNameLength + 13) + "} }}\n", "\"" + sections[i].stringArrayNames[j] + "\"", "(int)" + prefix + "array." + sections[i].stringArrayNames[j]);
                    }
                    else
                    {
                        res += string.Format("                      {{ {0,-" + (maxTokenNameLength + 2) + "}, {1,-" + (maxTokenNameLength + 13) + "} }}\n", "\"" + sections[i].stringArrayNames[j] + "\"", "(int)" + prefix + "array." + sections[i].stringArrayNames[j]);
                    }
                }

                res += "                }\n" +
                       "                ,\n" +
                       "                new Dictionary<string, int> // plurals\n" +
                       "                {\n";

                maxTokenNameLength = 0;

                for (int j = 0; j < sections[i].pluralsNames.Count; ++j)
                {
                    if (sections[i].pluralsNames[j].Length > maxTokenNameLength)
                    {
                        maxTokenNameLength = sections[i].pluralsNames[j].Length;
                    }
                }

                for (int j = 0; j < sections[i].pluralsNames.Count; ++j)
                {
                    if (j > 0)
                    {
                        res += string.Format("                    , {{ {0,-" + (maxTokenNameLength + 2) + "}, {1,-" + (maxTokenNameLength + 14) + "} }}\n", "\"" + sections[i].pluralsNames[j] + "\"", "(int)" + prefix + "plurals." + sections[i].pluralsNames[j]);
                    }
                    else
                    {
                        res += string.Format("                      {{ {0,-" + (maxTokenNameLength + 2) + "}, {1,-" + (maxTokenNameLength + 14) + "} }}\n", "\"" + sections[i].pluralsNames[j] + "\"", "(int)" + prefix + "plurals." + sections[i].pluralsNames[j]);
                    }
                }

                res += "                }\n" +
                       "            }\n";
            }

            res += "        };\n" +
                   "    }\n" +
                   "}\n";

            File.WriteAllText(targetFile, res, Encoding.UTF8);
            #endregion

            #region Caching xml files
            Debug.Log("Caching xml files in \"" + tempValuesPath + "\"");

            for (int i = 0; i < tempXmlFiles.Length; ++i)
            {
                tempXmlFiles[i].Delete();
            }

            for (int i = 0; i < xmlFiles.Length; ++i)
            {
                xmlFiles[i].CopyTo(tempValuesPath + "/" + xmlFiles[i].Name, true);
            }
            #endregion

            return sectionIds;
        }

        /// <summary>
        /// Parse xml file and return SectionTokens instance with all tokens.
        /// </summary>
        /// <returns>SectionTokens instance.</returns>
        /// <param name="path">Path to xml file.</param>
        private static SectionTokens ParseXmlTokens(string path)
        {
            SectionTokens res = new SectionTokens();

            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                bool resourcesFound = false;

                while (reader.Read())
                {
                    if (reader.Name == "resources")
                    {
                        resourcesFound = true;

                        string lastComment = null;

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Comment)
                            {
                                lastComment = reader.Value.Trim();
                            }
                            else
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                if (reader.Name == "string")
                                {
                                    string tokenName = reader.GetAttribute("name");

                                    if (!Utils.CheckTokenName(tokenName, reader.Name, res.stringNames))
                                    {
                                        return null;
                                    }

                                    res.stringNames.Add(tokenName);
                                    res.stringComments.Add(lastComment);
                                    res.stringValues.Add(Utils.ProcessTokenValue(reader.ReadString()));

                                    lastComment = null;
                                }
                                else
                                if (reader.Name == "string-array")
                                {
                                    string tokenName = reader.GetAttribute("name");

                                    if (!Utils.CheckTokenName(tokenName, reader.Name, res.stringArrayNames))
                                    {
                                        return null;
                                    }

                                    List<string> values         = new List<string>();
                                    List<string> valuesComments = new List<string>();

                                    string lastValueComment = null;

                                    while (reader.Read())
                                    {
                                        if (reader.NodeType == XmlNodeType.Comment)
                                        {
                                            lastValueComment = reader.Value.Trim();
                                        }
                                        else
                                        if (reader.NodeType == XmlNodeType.Element)
                                        {
                                            if (reader.Name == "item")
                                            {
                                                valuesComments.Add(lastValueComment);
                                                values.Add(Utils.ProcessTokenValue(reader.ReadString()));

                                                lastValueComment = null;
                                            }
                                            else
                                            {
                                                Debug.LogError("Unexpected tag <" + reader.Name + "> found in tag <string-array> in \"Assets/Resources/res/values/strings.xml\"");

                                                return null;
                                            }
                                        }
                                        else
                                        if (reader.NodeType == XmlNodeType.EndElement)
                                        {
                                            if (reader.Name == "string-array")
                                            {
                                                break;
                                            }
                                        }
                                    }

                                    res.stringArrayNames.Add(tokenName);
                                    res.stringArrayComments.Add(lastComment);
                                    res.stringArrayValues.Add(values);
                                    res.stringArrayValuesComments.Add(valuesComments);

                                    lastComment = null;
                                }
                                else
                                if (reader.Name == "plurals")
                                {
                                    string tokenName = reader.GetAttribute("name");

                                    if (!Utils.CheckTokenName(tokenName, reader.Name, res.pluralsNames))
                                    {
                                        return null;
                                    }

                                    Dictionary<PluralsQuantity, string> values         = new Dictionary<PluralsQuantity, string>();
                                    Dictionary<PluralsQuantity, string> valuesComments = new Dictionary<PluralsQuantity, string>();

                                    string lastValueComment = null;

                                    while (reader.Read())
                                    {
                                        if (reader.NodeType == XmlNodeType.Comment)
                                        {
                                            lastValueComment = reader.Value.Trim();
                                        }
                                        else
                                        if (reader.NodeType == XmlNodeType.Element)
                                        {
                                            if (reader.Name == "item")
                                            {
                                                PluralsQuantity quantity = PluralsQuantity.Count; // Nothing

                                                string quantityValue = reader.GetAttribute("quantity");

                                                if (quantityValue == null)
                                                {
                                                    Debug.LogError("Attribute \"quantity\" not found for tag <item> in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/res/values/strings.xml\"");

                                                    return null;
                                                }

                                                if (quantityValue == "")
                                                {
                                                    Debug.LogError("Attribute \"quantity\" empty for tag <item> in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/res/values/strings.xml\"");

                                                    return null;
                                                }

                                                if (quantityValue == "zero")
                                                {
                                                    quantity = PluralsQuantity.Zero;
                                                }
                                                else
                                                if (quantityValue == "one")
                                                {
                                                    quantity = PluralsQuantity.One;
                                                }
                                                else
                                                if (quantityValue == "two")
                                                {
                                                    quantity = PluralsQuantity.Two;
                                                }
                                                else
                                                if (quantityValue == "few")
                                                {
                                                    quantity = PluralsQuantity.Few;
                                                }
                                                else
                                                if (quantityValue == "many")
                                                {
                                                    quantity = PluralsQuantity.Many;
                                                }
                                                else
                                                if (quantityValue == "other")
                                                {
                                                    quantity = PluralsQuantity.Other;
                                                }
                                                else
                                                {
                                                    Debug.LogError("Unknown attribute \"quantity\" value \"" + quantityValue + "\" for tag <item> in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/res/values/strings.xml\"");

                                                    return null;
                                                }

                                                if (!values.ContainsKey(quantity))
                                                {
                                                    valuesComments[quantity] = lastValueComment;
                                                    values[quantity]         = Utils.ProcessTokenValue(reader.ReadString());
                                                }
                                                else
                                                {
                                                    Debug.LogError("Duplicate <item> tag with attribute \"quantity\" value \"" + quantityValue + "\" in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/res/values/strings.xml\"");

                                                    return null;
                                                }

                                                lastValueComment = null;
                                            }
                                            else
                                            {
                                                Debug.LogError("Unexpected tag <" + reader.Name + "> found in tag <plurals> in \"Assets/Resources/res/values/strings.xml\"");

                                                return null;
                                            }
                                        }
                                        else
                                        if (reader.NodeType == XmlNodeType.EndElement)
                                        {
                                            if (reader.Name == "plurals")
                                            {
                                                break;
                                            }
                                        }
                                    }

                                    res.pluralsNames.Add(tokenName);
                                    res.pluralsComments.Add(lastComment);
                                    res.pluralsValues.Add(values);
                                    res.pluralsValuesComments.Add(valuesComments);

                                    lastComment = null;
                                }
                                else
                                {
                                    Debug.LogError("Unexpected tag <" + reader.Name + "> found in tag <resources> in \"Assets/Resources/res/values/strings.xml\"");

                                    return null;
                                }
                            }
                        }

                        break;
                    }
                }

                if (!resourcesFound)
                {
                    Debug.LogError("Tag <resources> not found in \"Assets/Resources/res/values/strings.xml\"");

                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Exception occured while parsing \"Assets/Resources/res/values/strings.xml\"");
                Debug.LogException(e);

                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return res;
        }

        /// <summary>
        /// Generates source code for section tokens in R.cs file.
        /// </summary>
        /// <returns>Source code for section tokens.</returns>
        /// <param name="section">SectionTokens instance.</param>
        /// <param name="filename">Name of file.</param>
        /// <param name="indent">Indentation string.</param>
        private static string GenerateCodeForSectionTokens(SectionTokens section, string filename, string indent)
        {
            string res = indent + "/// <summary>\n" +
                         indent + "/// Enumeration of all string tags in \"Assets/Resources/res/values/" + filename + "\"\n" +
                         indent + "/// </summary>\n" +
                         indent + "public enum strings\n" +
                         indent + "{\n";

            for (int i = 0; i < section.stringNames.Count; ++i)
            {
                string[] separators = new string[] { "\n", "\\n" };

                string[] commentLines = section.stringComments[i] == null ? null : section.stringComments[i].Split(separators, StringSplitOptions.None);
                string[] valueLines   =                                            section.stringValues[i].Split(separators, StringSplitOptions.None);

                res += indent + "    /// <summary>\n";

                if (commentLines != null)
                {
                    for (int j = 0; j < commentLines.Length; ++j)
                    {
                        res += indent + "    /// <para>" + SecurityElement.Escape(commentLines[j]) + "</para>\n";
                    }
                }

                res += indent + "    /// <para>Value:</para>\n";

                if (valueLines != null)
                {
                    for (int j = 0; j < valueLines.Length; ++j)
                    {
                        res += indent + "    ///   <para>" + SecurityElement.Escape(valueLines[j]) + "</para>\n";
                    }
                }

                res += indent + "    /// </summary>\n" +
                       indent + "    " + section.stringNames[i] + "\n" +
                       indent + "    ,\n";
            }

            res += indent + "    /// <summary>\n" +
                   indent + "    /// Total amount of strings.\n" +
                   indent + "    /// </summary>\n" +
                   indent + "    Count // Should be last\n" +
                   indent + "}\n" +
                   "\n" +
                   indent + "/// <summary>\n" +
                   indent + "/// Enumeration of all string-array tags in \"Assets/Resources/res/values/" + filename + "\"\n" +
                   indent + "/// </summary>\n" +
                   indent + "public enum array\n" +
                   indent + "{\n";

            for (int i = 0; i < section.stringArrayNames.Count; ++i)
            {
                string[] separators = new string[] { "\n", "\\n" };

                string[] commentLines = section.stringArrayComments[i] == null ? null : section.stringArrayComments[i].Split(separators, StringSplitOptions.None);

                res += indent + "    /// <summary>\n";

                if (commentLines != null)
                {
                    for (int j = 0; j < commentLines.Length; ++j)
                    {
                        res += indent + "    /// <para>" + commentLines[j] + "</para>\n";
                    }
                }

                res += indent + "    /// <para>Value:</para>\n";

                for (int j = 0; j < section.stringArrayValues[i].Count; ++j)
                {
                    string[] valueCommentLines = section.stringArrayValuesComments[i][j] == null ? null : section.stringArrayValuesComments[i][j].Split(separators, StringSplitOptions.None);
                    string[] valueLines        =                                                          section.stringArrayValues[i][j].Split(separators, StringSplitOptions.None);

                    res += indent + "    ///   <para>- Item " + (j + 1) + ":</para>\n";

                    if (valueCommentLines != null)
                    {
                        for (int k = 0; k < valueCommentLines.Length; ++k)
                        {
                            res += indent + "    ///     <para>// " + valueCommentLines[k] + "</para>\n";
                        }
                    }

                    for (int k = 0; k < valueLines.Length; ++k)
                    {
                        res += indent + "    ///     <para>" + valueLines[k] + "</para>\n";
                    }
                }

                res += indent + "    /// </summary>\n" +
                       indent + "    " + section.stringArrayNames[i] + "\n" +
                       indent + "    ,\n";
            }

            res += indent + "    /// <summary>\n" +
                   indent + "    /// Total amount of string-arrays.\n" +
                   indent + "    /// </summary>\n" +
                   indent + "    Count // Should be last\n" +
                   indent + "}\n" +
                   "\n" +
                   indent + "/// <summary>\n" +
                   indent + "/// Enumeration of all plurals tags in \"Assets/Resources/res/values/" + filename + "\"\n" +
                   indent + "/// </summary>\n" +
                   indent + "public enum plurals\n" +
                   indent + "{\n";

            for (int i = 0; i < section.pluralsNames.Count; ++i)
            {
                string[] separators = new string[] { "\n", "\\n" };

                string[] commentLines = section.pluralsComments[i] == null ? null : section.pluralsComments[i].Split(separators, StringSplitOptions.None);

                res += indent + "    /// <summary>\n";

                if (commentLines != null)
                {
                    for (int j = 0; j < commentLines.Length; ++j)
                    {
                        res += indent + "    /// <para>" + commentLines[j] + "</para>\n";
                    }
                }

                res += indent + "    /// <para>Value:</para>\n";

                for (int j = 0; j < (int)PluralsQuantity.Count; ++j)
                {
                    PluralsQuantity quantity = (PluralsQuantity)j;
                    string valueComment;
                    string value;

                    if (
                        section.pluralsValuesComments[i].TryGetValue(quantity, out valueComment)
                        &&
                        section.pluralsValues[i].TryGetValue(quantity, out value)
                        )
                    {
                        string[] valueCommentLines = valueComment == null ? null : valueComment.Split(separators, StringSplitOptions.None);
                        string[] valueLines        =                               value.Split(separators, StringSplitOptions.None);

                        res += indent + "    ///   <para>- " + quantity + ":</para>\n";

                        if (valueCommentLines != null)
                        {
                            for (int k = 0; k < valueCommentLines.Length; ++k)
                            {
                                res += indent + "    ///     <para>// " + valueCommentLines[k] + "</para>\n";
                            }
                        }

                        for (int k = 0; k < valueLines.Length; ++k)
                        {
                            res += indent + "    ///     <para>" + valueLines[k] + "</para>\n";
                        }
                    }
                }

                res += indent + "    /// </summary>\n" +
                       indent + "    " + section.pluralsNames[i] + "\n" +
                       indent + "    ,\n";
            }

            res += indent + "    /// <summary>\n" +
                   indent + "    /// Total amount of plurals.\n" +
                   indent + "    /// </summary>\n" +
                   indent + "    Count // Should be last\n" +
                   indent + "}\n";

            return res;
        }

#if FORCE_CODE_GENERATION
        /// <summary>
        /// Generates Translator.cs file
        /// </summary>
        /// <param name="sectionIds">Sections identifiers.</param>
        private static void GenerateTranslator(List<string> sectionIds)
#else
        /// <summary>
        /// Generates Translator.cs file
        /// </summary>
        /// <param name="sectionIds">Sections identifiers.</param>
        /// <param name="forceGeneration">If set to <c>true</c> force code generation.</param>
        private static void GenerateTranslator(List<string> sectionIds, bool forceGeneration)
#endif
        {
            string targetFile = PathToGeneratedFile("Translator.cs");

            #region Check that Translator.cs is up to date
#if !FORCE_CODE_GENERATION
            if (
                !forceGeneration
                &&
                !sChangedGeneratedTranslator
                &&
                File.Exists(targetFile)
               )
            {
                return;
            }
#endif
            #endregion

            #region Generating Translator.cs file
            Debug.Log("Generating \"Translator.cs\" file");

            string res = "// This file generated from xml files in \"Assets/Resources/res/values\".\n" +
                         "using UnityEngine.Events;\n" +
                         "\n" +
                         "\n" +
                         "\n" +
                         "namespace UnityTranslation\n" +
                         "{\n" +
                         "    /// <summary>\n" +
                         "    /// UnityTranslation Translator class that has methods for getting localized strings.\n" +
                         "    /// Translator provide localization in the same way as in Android localization system.\n" +
                         "    ///\n" +
                         "    /// See also: <a UnityTranslationInternal=\"http://developer.android.com/guide/topics/resources/string-resource.html\">String Resources</a>\n" +
                         "    /// </summary>\n" +
                         "    public static class Translator\n" +
                         "    {\n" +
                         "        #region Trasparent access to UnityTranslationInternal.Translator public members\n" +
                         "\n" +
                         "        #region Properties\n" +
                         "\n" +
                         "        #region language\n" +
                         "        /// <summary>\n" +
                         "        /// Gets or sets currently used language.\n" +
                         "        /// Please note that if you want to add new language you have to create values folder in Assets/Resources/res folder.\n" +
                         "        /// Language code should be one of specified language codes in Language.cs\n" +
                         "        /// </summary>\n" +
                         "        /// <value>Current language.</value>\n" +
                         "        public static Language language\n" +
                         "        {\n" +
                         "            get\n" +
                         "            {\n" +
                         "                return UnityTranslationInternal.Translator.language;\n" +
                         "            }\n" +
                         "\n" +
                         "            set\n" +
                         "            {\n" +
                         "                UnityTranslationInternal.Translator.language = value;\n" +
                         "            }\n" +
                         "        }\n" +
                         "        #endregion\n" +
                         "\n" +
                         "        #endregion\n" +
                         "\n" +
                         "\n" +
                         "\n" +
                         "        /// <summary>\n" +
                         "        /// Adds specified language changed listener and invoke it.\n" +
                         "        /// </summary>\n" +
                         "        /// <param name=\"listener\">Language changed listener.</param>\n" +
                         "        public static void AddLanguageChangedListener(UnityAction listener)\n" +
                         "        {\n" +
                         "            UnityTranslationInternal.Translator.AddLanguageChangedListener(listener);\n" +
                         "        }\n" +
                         "\n" +
                         "        /// <summary>\n" +
                         "        /// Removes specified language changed listener.\n" +
                         "        /// </summary>\n" +
                         "        /// <param name=\"listener\">Language changed listener.</param>\n" +
                         "        public static void RemoveLanguageChangedListener(UnityAction listener)\n" +
                         "        {\n" +
                         "            UnityTranslationInternal.Translator.RemoveLanguageChangedListener(listener);\n" +
                         "        }\n" +
                         "\n" +
                         "        /// <summary>\n" +
                         "        /// Load tokens for specified section.\n" +
                         "        /// </summary>\n" +
                         "        /// <param name=\"section\">Section ID.</param>\n" +
                         "        public static void LoadSection(R.sections.SectionID section)\n" +
                         "        {\n" +
                         "            UnityTranslationInternal.Translator.LoadSection(section, true);\n" +
                         "        }\n" +
                         "\n" +
                         "        /// <summary>\n" +
                         "        /// Unload tokens for specified section.\n" +
                         "        /// </summary>\n" +
                         "        /// <param name=\"section\">Section ID.</param>\n" +
                         "        public static void UnloadSection(R.sections.SectionID section)\n" +
                         "        {\n" +
                         "            UnityTranslationInternal.Translator.UnloadSection(section);\n" +
                         "        }\n" +
                         "\n" +
                         "        /// <summary>\n" +
                         "        /// Determines if specified section is loaded.\n" +
                         "        /// </summary>\n" +
                         "        /// <returns><c>true</c> if section is loaded; otherwise, <c>false</c>.</returns>\n" +
                         "        /// <param name=\"section\">Section ID.</param>\n" +
                         "        public static bool IsSectionLoaded(R.sections.SectionID section)\n" +
                         "        {\n" +
                         "            return UnityTranslationInternal.Translator.IsSectionLoaded(section);\n" +
                         "        }\n" +
                         "        #endregion\n" +
                         "\n" +
                         "        #region Generated code\n";

            for (int i = 0; i <= sectionIds.Count; ++i) // 0 - strings.xml, 1..Count - sections
            {
                string prefix;
                string tokensId;
                string loadSectionCall;

                if (i == 0)
                {
                    prefix          = "R.";
                    tokensId        = "0";
                    loadSectionCall = "";
                }
                else
                {
                    prefix          = "R.sections." + sectionIds[i - 1] + ".";
                    tokensId        = "(int)R.sections.SectionID." + sectionIds[i - 1] + " + 1";
                    loadSectionCall = "            UnityTranslationInternal.Translator.LoadSection(R.sections.SectionID." + sectionIds[i - 1] + ", false);\n" +
                                      "\n";

                    res += "\n";
                }

                res += "        /// <summary>\n" +
                       "        /// Return the string value associated with a particular resource ID.\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Localized string.</returns>\n" +
                       "        /// <param name=\"id\">String resource ID.</param>\n" +
                       "        public static string GetString(" + prefix + "strings id)\n" +
                       "        {\n" +
                       loadSectionCall +
                       "            if (\n" +
                       "                UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage != null\n" +
                       "                &&\n" +
                       "                UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage.stringValues[(int)id] != null\n" +
                       "               )\n" +
                       "            {\n" +
                       "                return UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage.stringValues[(int)id];\n" +
                       "            }\n" +
                       "            else\n" +
                       "            {\n" +
                       "                return UnityTranslationInternal.Translator.tokens[" + tokensId + "].defaultLanguage.stringValues[(int)id];\n" +
                       "            }\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Return the string value associated with a particular resource ID, substituting the format arguments as defined in string.Format.\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Localized string.</returns>\n" +
                       "        /// <param name=\"id\">String resource ID.</param>\n" +
                       "        /// <param name=\"formatArgs\">Format arguments.</param>\n" +
                       "        public static string GetString(" + prefix + "strings id, params object[] formatArgs)\n" +
                       "        {\n" +
                       "            return string.Format(GetString(id), formatArgs);\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Return the string array associated with a particular resource ID.\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Localized string array.</returns>\n" +
                       "        /// <param name=\"id\">String array resource ID.</param>\n" +
                       "        public static string[] GetStringArray(" + prefix + "array id)\n" +
                       "        {\n" +
                       loadSectionCall +
                       "            if (\n" +
                       "                UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage != null\n" +
                       "                &&\n" +
                       "                UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage.stringArrayValues[(int)id] != null\n" +
                       "               )\n" +
                       "            {\n" +
                       "                return UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage.stringArrayValues[(int)id];\n" +
                       "            }\n" +
                       "            else\n" +
                       "            {\n" +
                       "                return UnityTranslationInternal.Translator.tokens[" + tokensId + "].defaultLanguage.stringArrayValues[(int)id];\n" +
                       "            }\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Return the string necessary for grammatically correct pluralization of the given resource ID for the given quantity.\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Localized string.</returns>\n" +
                       "        /// <param name=\"id\">Plurals resource ID.</param>\n" +
                       "        /// <param name=\"quantity\">Quantity.</param>\n" +
                       "        public static string GetQuantityString(" + prefix + "plurals id, double quantity)\n" +
                       "        {\n" +
                       loadSectionCall +
                       "            string[]                                 pluralsValues;\n" +
                       "            UnityTranslationInternal.PluralsQuantity pluralsQuantity;\n" +
                       "\n" +
                       "            if (\n" +
                       "                UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage != null\n" +
                       "                &&\n" +
                       "                UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage.pluralsValues[(int)id] != null\n" +
                       "               )\n" +
                       "            {\n" +
                       "                pluralsValues   = UnityTranslationInternal.Translator.tokens[" + tokensId + "].selectedLanguage.pluralsValues[(int)id];\n" +
                       "                pluralsQuantity = UnityTranslationInternal.PluralsRules.pluralsFunctions[(int)UnityTranslationInternal.Translator.language](quantity);\n" +
                       "            }\n" +
                       "            else\n" +
                       "            {\n" +
                       "                pluralsValues   = UnityTranslationInternal.Translator.tokens[" + tokensId + "].defaultLanguage.pluralsValues[(int)id];\n" +
                       "                pluralsQuantity = UnityTranslationInternal.PluralsRules.pluralsFunctions[0](quantity);\n" +
                       "            }\n" +
                       "\n" +
                       "            for (int i = (int)pluralsQuantity ; i < (int)UnityTranslationInternal.PluralsQuantity.Count; ++i)\n" +
                       "            {\n" +
                       "                if (pluralsValues[i] != null)\n" +
                       "                {\n" +
                       "                    return pluralsValues[i];\n" +
                       "                }\n" +
                       "            }\n" +
                       "\n" +
                       "            for (int i = (int)pluralsQuantity - 1 ; i >= 0; --i)\n" +
                       "            {\n" +
                       "                if (pluralsValues[i] != null)\n" +
                       "                {\n" +
                       "                    return pluralsValues[i];\n" +
                       "                }\n" +
                       "            }\n" +
                       "\n" +
                       "            return \"\";\n" +
                       "        }\n" +
                       "\n" +
                       "        /// <summary>\n" +
                       "        /// Formats the string necessary for grammatically correct pluralization of the given resource ID for the given quantity, using the given arguments.\n" +
                       "        /// </summary>\n" +
                       "        /// <returns>Localized string.</returns>\n" +
                       "        /// <param name=\"id\">Plurals resource ID.</param>\n" +
                       "        /// <param name=\"quantity\">Quantity.</param>\n" +
                       "        /// <param name=\"formatArgs\">Format arguments.</param>\n" +
                       "        public static string GetQuantityString(" + prefix + "plurals id, double quantity, params object[] formatArgs)\n" +
                       "        {\n" +
                       "            return string.Format(GetQuantityString(id, quantity), formatArgs);\n" +
                       "        }\n";
            }

            res += "        #endregion\n" +
                   "    }\n" +
                   "}\n";

            File.WriteAllText(targetFile, res, Encoding.UTF8);
            File.WriteAllText(Application.temporaryCachePath + "/UnityTranslation/Translator.cs", res, Encoding.UTF8);
            #endregion
        }

#if FORCE_CODE_GENERATION
        /// <summary>
        /// Generates TextAutoTranslation.cs file
        /// </summary>
        /// <param name="sectionIds">Sections identifiers.</param>
        private static void GenerateTextAutoTranslation(List<string> sectionIds)
#else
        /// <summary>
        /// Generates TextAutoTranslation.cs file
        /// </summary>
        /// <param name="sectionIds">Sections identifiers.</param>
        /// <param name="forceGeneration">If set to <c>true</c> force code generation.</param>
        private static void GenerateTextAutoTranslation(List<string> sectionIds, bool forceGeneration)
#endif
        {
            string tempUiPath = Application.temporaryCachePath + "/UnityTranslation/UI";

            if (!Directory.Exists(tempUiPath))
            {
                Directory.CreateDirectory(tempUiPath);
            }

            string targetFile = PathToGeneratedFile("TextAutoTranslation.cs");

            DirectoryInfo targetDir = new DirectoryInfo(targetFile.Remove(targetFile.LastIndexOf('/')));
            DirectoryInfo tempUiDir = new DirectoryInfo(tempUiPath);

            FileInfo[] targetFiles = targetDir.GetFiles("TextAutoTranslation*.cs");
            FileInfo[] tempFiles   = tempUiDir.GetFiles("TextAutoTranslation*.cs");



            #region Check that TextAutoTranslation.cs is up to date
#if !FORCE_CODE_GENERATION
            if (
                !forceGeneration
                &&
                File.Exists(targetFile)
                &&
                targetFiles.Length == tempFiles.Length
               )
            {
                bool good = true;

                for (int i = 0; i < targetFiles.Length; ++i)
                {
                    if (targetFiles[i].Name != tempFiles[i].Name)
                    {
                        good = false;
                        break;
                    }
                }

                if (good)
                {
                    for (int i = 0; i < targetFiles.Length; ++i)
                    {
                        byte[] leftBytes  = File.ReadAllBytes(targetFiles[i].FullName);
                        byte[] rightBytes = File.ReadAllBytes(tempFiles[i].FullName);

                        if (!leftBytes.SequenceEqual(rightBytes))
                        {
                            good = false;
                            break;
                        }
                    }

                    if (good)
                    {
                        return;
                    }
                }
            }
#endif
            #endregion

            // Remove .cs extension
            targetFile = targetFile.Remove(targetFile.Length - 3);

            #region Remove all previously generated files
            for (int i = 0; i < targetFiles.Length; ++i)
            {
                targetFiles[i].Delete();
            }

            for (int i = 0; i < tempFiles.Length; ++i)
            {
                tempFiles[i].Delete();
            }
            #endregion

            for (int i = 0; i <= sectionIds.Count; ++i) // 0 - strings.xml, 1..Count - sections
            {
                string postfix = (i == 0) ? ".cs" : sectionIds[i - 1] + ".cs";

                #region Generating TextAutoTranslation*.cs files
                Debug.Log("Generating \"TextAutoTranslation" + postfix + "\" file");

                string res = "// This file generated from xml files in \"Assets/Resources/res/values\".\n" +
                             "using UnityEngine;\n" +
                             "using UnityEngine.UI;\n" +
                             "\n" +
                             "\n" +
                             "\n" +
                             "namespace UnityTranslation\n" +
                             "{\n" +
                             "    /// <summary>\n" +
                             "    /// Script for auto-translating Text component.\n" +
                             "    /// </summary>\n" +
                             "    [RequireComponent(typeof(Text))]\n" +
                             "    public class TextAutoTranslation" + ((i == 0) ? "" : sectionIds[i - 1]) + " : MonoBehaviour\n" +
                             "    {\n" +
                             "        /// <summary>\n" +
                             "        /// Token identifier that used for localization.\n" +
                             "        /// </summary>\n" +
                             "        public " + ((i == 0) ? "R.strings" : "R.sections." + sectionIds[i - 1] + ".strings") + " id;\n" +
                             "\n" +
                             "        private Text mText;\n" +
                             "\n" +
                             "\n" +
                             "\n" +
                             "        /// <summary>\n" +
                             "        /// Script starting callback.\n" +
                             "        /// </summary>\n" +
                             "        void Start()\n" +
                             "        {\n" +
                             "            mText = GetComponent<Text>();\n" +
                             "            mText.text = Translator.GetString(id);\n" +
                             "\n" +
                             "            Translator.AddLanguageChangedListener(OnLanguageChanged);\n" +
                             "        }\n" +
                             "\n" +
                             "        /// <summary>\n" +
                             "        /// Script destroying callback.\n" +
                             "        /// </summary>\n" +
                             "        void OnDestroy()\n" +
                             "        {\n" +
                             "            Translator.RemoveLanguageChangedListener(OnLanguageChanged);\n" +
                             "        }\n" +
                             "\n" +
                             "        /// <summary>\n" +
                             "        /// Callback for language changed event.\n" +
                             "        /// </summary>\n" +
                             "        public void OnLanguageChanged()\n" +
                             "        {\n" +
                             "            mText.text = Translator.GetString(id);\n" +
                             "        }\n" +
                             "    }\n" +
                             "}\n";

                File.WriteAllText(targetFile + postfix, res, Encoding.UTF8);
                File.WriteAllText(tempUiPath + "/TextAutoTranslation" + postfix, res, Encoding.UTF8);
                #endregion
            }
        }
    }
}
#endif
