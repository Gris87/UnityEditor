using UnityEngine;
using UnityEngine.Events;
using UnityTranslation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;



namespace UnityTranslationInternal
{
    /// <summary>
    /// UnityTranslation internal Translator class that has methods for getting localized strings.
    /// Translator provide localization in the same way as in Android localization system.
    ///
    /// See also: <a UnityTranslationInternal="http://developer.android.com/guide/topics/resources/string-resource.html">String Resources</a>
    public static class Translator
    {
        /// <summary>
        /// Group of localized strings that cached for a single language.
        /// </summary>
        public class SectionLocaleTokens
        {
            /// <summary>
            /// Array of cached string values for a single language.
            /// </summary>
            public string[]   stringValues;

            /// <summary>
            /// Array of cached string arrays for a single language.
            /// </summary>
            public string[][] stringArrayValues;

            /// <summary>
            /// Array of cached plurals values for a single language.
            /// </summary>
            public string[][] pluralsValues;



            /// <summary>
            /// Initializes a new instance of the <see cref="UnityTranslationInternal.Translator.SectionLocaleTokens"/> class.
            /// </summary>
            /// <param name="stringCount">String count.</param>
            /// <param name="stringArrayCount">String array count.</param>
            /// <param name="pluralsCount">Plurals count.</param>
            public SectionLocaleTokens(int stringCount, int stringArrayCount, int pluralsCount)
            {
                stringValues      = new string[stringCount];
                stringArrayValues = new string[stringArrayCount][];
                pluralsValues     = new string[pluralsCount][];
            }
        }

        /// <summary>
        /// Default strings and localized strings of selected language for a single section.
        /// </summary>
        public class SectionTokens
        {
            /// <summary>
            /// Default language strings for a single section.
            /// </summary>
            public SectionLocaleTokens defaultLanguage;

            /// <summary>
            /// Selected language strings for a single section.
            /// </summary>
            public SectionLocaleTokens selectedLanguage;



            /// <summary>
            /// Initializes a new instance of the <see cref="UnityTranslationInternal.Translator.SectionTokens"/> class.
            /// </summary>
            public SectionTokens()
            {
                defaultLanguage  = null;
                selectedLanguage = null;
            }
        }



        /// <summary>
        /// Array of tokens for strings.xml and for each section.
        /// </summary>
        public static SectionTokens[] tokens;

        private static Language                                        mLanguage              = Language.Default;
        private static UnityEvent                                      mLanguageChangedAction = null;
        private static Dictionary<R.sections.SectionID, SectionTokens> mLoadedSections        = null;


        #region Properties

        #region language
        /// <summary>
        /// Gets or sets currently used language.
        /// Please note that if you want to add new language you have to create values folder in Assets/Resources/res folder.
        /// Language code should be one of specified language codes in Language.cs
        /// </summary>
        /// <value>Current language.</value>
        public static Language language
        {
            get
            {
                return mLanguage;
            }

            set
            {
                if (mLanguage != value)
                {
                    string locale;

                    if (AvailableLanguages.list.TryGetValue(value, out locale))
                    {
                        mLanguage = value;

                        if (mLanguage == Language.Default)
                        {
                            tokens[0].selectedLanguage = null;

                            foreach (R.sections.SectionID section in mLoadedSections.Keys)
                            {
                                tokens[(int)section + 1].selectedLanguage = null;
                            }
                        }
                        else
                        {
                            string xmlFile                     = "strings.xml";
                            Dictionary<string, int>[] tokenIds = R.tokenIds[0];
                            int stringCount                    = tokenIds[0].Count;
                            int stringArrayCount               = tokenIds[1].Count;
                            int pluralsCount                   = tokenIds[2].Count;

                            tokens[0].selectedLanguage = parseXmlTokens(xmlFile, locale, tokenIds, stringCount, stringArrayCount, pluralsCount);

                            foreach (R.sections.SectionID section in mLoadedSections.Keys)
                            {
                                xmlFile          = R.sections.xmlFiles[(int)section];
                                tokenIds         = R.tokenIds[(int)section + 1];
                                stringCount      = tokenIds[0].Count;
                                stringArrayCount = tokenIds[1].Count;
                                pluralsCount     = tokenIds[2].Count;

                                tokens[(int)section + 1].selectedLanguage = parseXmlTokens(xmlFile, locale, tokenIds, stringCount, stringArrayCount, pluralsCount);
                            }
                        }

                        mLanguageChangedAction.Invoke();
                    }
                    else
                    {
                        Debug.LogError("Impossible to change language to " + value + " because it's not specified in \"Assets/Resources/res\" folder");
                    }
                }
            }
        }
        #endregion

        #endregion



        static Translator()
        {
            #if UNITY_EDITOR
            CodeGenerator.generate();
            #endif

            mLanguageChangedAction = new UnityEvent();

            mLoadedSections = new Dictionary<R.sections.SectionID, SectionTokens>();

            #region Initialize default tokens
            tokens    = new SectionTokens[(int)R.sections.SectionID.Count + 1];
            tokens[0] = new SectionTokens();

            string xmlFile                     = "strings.xml";
            Dictionary<string, int>[] tokenIds = R.tokenIds[0];
            int stringCount                    = tokenIds[0].Count;
            int stringArrayCount               = tokenIds[1].Count;
            int pluralsCount                   = tokenIds[2].Count;

            tokens[0].defaultLanguage = parseXmlTokens(xmlFile, "", tokenIds, stringCount, stringArrayCount, pluralsCount);
            #endregion

            #region Set language according to system language
            Language selectLanguage = LanguageSystemName.systemLanguageToLanguage(Application.systemLanguage);

            if (AvailableLanguages.list.ContainsKey(selectLanguage))
            {
                language = selectLanguage;
            }
            #endregion
        }

        /// <summary>
        /// Adds specified language changed listener.
        /// </summary>
        /// <param name="listener">Language changed listener.</param>
        public static void addLanguageChangedListener(UnityAction listener)
        {
            mLanguageChangedAction.AddListener(listener);
        }

        /// <summary>
        /// Removes specified language changed listener.
        /// </summary>
        /// <param name="listener">Language changed listener.</param>
        public static void removeLanguageChangedListener(UnityAction listener)
        {
            mLanguageChangedAction.RemoveListener(listener);
        }

        /// <summary>
        /// Load tokens for specified section.
        /// </summary>
        /// <param name="section">Section ID.</param>
        /// <param name="showWarning">If set to <c>true</c> show warning about already loaded section.</param>
        public static void LoadSection(R.sections.SectionID section, bool showWarning)
        {
            if (tokens[(int)section + 1] == null)
            {
                tokens[(int)section + 1] = new SectionTokens();

                string xmlFile                     = R.sections.xmlFiles[(int)section];
                Dictionary<string, int>[] tokenIds = R.tokenIds[(int)section + 1];
                int stringCount                    = tokenIds[0].Count;
                int stringArrayCount               = tokenIds[1].Count;
                int pluralsCount                   = tokenIds[2].Count;

                tokens[(int)section + 1].defaultLanguage = parseXmlTokens(xmlFile, "", tokenIds, stringCount, stringArrayCount, pluralsCount);

                if (mLanguage != Language.Default)
                {
                    string locale = AvailableLanguages.list[mLanguage];
                    tokens[(int)section + 1].selectedLanguage = parseXmlTokens(xmlFile, locale, tokenIds, stringCount, stringArrayCount, pluralsCount);
                }

                mLoadedSections[section] = tokens[(int)section + 1];
            }
            else
            {
                if (showWarning)
                {
                    Debug.LogWarning("Section \"" + section + "\" already loaded");
                }
            }
        }

        /// <summary>
        /// Unload tokens for specified section.
        /// </summary>
        /// <param name="section">Section ID.</param>
        public static void UnloadSection(R.sections.SectionID section)
        {
            if (tokens[(int)section + 1] != null)
            {
                tokens[(int)section + 1] = null;
                mLoadedSections.Remove(section);
            }
            else
            {
                Debug.LogWarning("Section \"" + section + "\" already unloaded");
            }
        }

        /// <summary>
        /// Determines if specified section is loaded.
        /// </summary>
        /// <returns><c>true</c> if section is loaded; otherwise, <c>false</c>.</returns>
        /// <param name="section">Section ID.</param>
        public static bool IsSectionLoaded(R.sections.SectionID section)
        {
            return (tokens[(int)section + 1] != null);
        }

        /// <summary>
        /// Parse xml file and return SectionLocaleTokens instance with all tokens.
        /// </summary>
        /// <returns>SectionLocaleTokens instance.</returns>
        /// <param name="filename">Name of file.</param>
        /// <param name="locale">Language code.</param>
        /// <param name="tokenIds">Token identifiers.</param>
        /// <param name="stringCount">String count.</param>
        /// <param name="stringArrayCount">String array count.</param>
        /// <param name="pluralsCount">Plurals count.</param>
        private static SectionLocaleTokens parseXmlTokens(string filename, string locale, Dictionary<string, int>[] tokenIds, int stringCount, int stringArrayCount, int pluralsCount)
        {
            SectionLocaleTokens res = null;

            filename = filename.Remove(filename.Length - 4);

            do
            {
                string xmlResPath = "res/values" + ((locale != "") ? ("-" + locale) : "") + "/" + filename;

                TextAsset xmlFile = Resources.Load(xmlResPath, typeof(TextAsset)) as TextAsset;

                if (xmlFile != null)
                {
                    if (res == null)
                    {
                        res = new SectionLocaleTokens(stringCount, stringArrayCount, pluralsCount);
                    }

                    XmlTextReader reader = null;

                    try
                    {
                        reader = new XmlTextReader(new MemoryStream(xmlFile.bytes, false));
                        reader.WhitespaceHandling = WhitespaceHandling.None;

                        bool resourcesFound = false;

                        while (reader.Read())
                        {
                            if (reader.Name == "resources")
                            {
                                resourcesFound = true;

                                List<string> stringNames      = new List<string>();
                                List<string> stringArrayNames = new List<string>();
                                List<string> pluralsNames     = new List<string>();

                                while (reader.Read())
                                {
                                    if (reader.NodeType == XmlNodeType.Element)
                                    {
                                        if (reader.Name == "string")
                                        {
                                            string tokenName = reader.GetAttribute("name");

                                            if (Utils.checkTokenName(tokenName, reader.Name, stringNames))
                                            {
                                                stringNames.Add(tokenName);

                                                int index;

                                                if (tokenIds[0].TryGetValue(tokenName, out index))
                                                {
                                                    if (res.stringValues[index] == null)
                                                    {
                                                        res.stringValues[index] = Utils.processTokenValue(reader.ReadString());
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("Tag <string> with unknown token name \"" + tokenName + "\" found in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                }
                                            }
                                        }
                                        else
                                            if (reader.Name == "string-array")
                                        {
                                            string tokenName = reader.GetAttribute("name");

                                            if (Utils.checkTokenName(tokenName, reader.Name, stringArrayNames))
                                            {
                                                List<string> values = new List<string>();

                                                while (reader.Read())
                                                {
                                                    if (reader.NodeType == XmlNodeType.Element)
                                                    {
                                                        if (reader.Name == "item")
                                                        {
                                                            values.Add(Utils.processTokenValue(reader.ReadString()));
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("Unexpected tag <" + reader.Name + "> found in tag <string-array> in \"Assets/Resources/" + xmlResPath + ".xml\"");
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

                                                stringArrayNames.Add(tokenName);

                                                int index;

                                                if (tokenIds[1].TryGetValue(tokenName, out index))
                                                {
                                                    if (res.stringArrayValues[index] == null)
                                                    {
                                                        res.stringArrayValues[index] = values.ToArray();
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("Tag <string-array> with unknown token name \"" + tokenName + "\" found in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                }
                                            }
                                        }
                                        else
                                            if (reader.Name == "plurals")
                                        {
                                            string tokenName = reader.GetAttribute("name");

                                            if (Utils.checkTokenName(tokenName, reader.Name, pluralsNames))
                                            {
                                                string[] values = new string[(int)PluralsQuantity.Count];

                                                while (reader.Read())
                                                {
                                                    if (reader.NodeType == XmlNodeType.Element)
                                                    {
                                                        if (reader.Name == "item")
                                                        {
                                                            PluralsQuantity quantity = PluralsQuantity.Count; // Nothing

                                                            string quantityValue = reader.GetAttribute("quantity");

                                                            if (quantityValue == null)
                                                            {
                                                                Debug.LogError("Attribute \"quantity\" not found for tag <item> in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                            }
                                                            else
                                                            if (quantityValue == "")
                                                            {
                                                                Debug.LogError("Attribute \"quantity\" empty for tag <item> in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                            }
                                                            else
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
                                                                Debug.LogError("Unknown attribute \"quantity\" value \"" + quantityValue + "\" for tag <item> in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                            }

                                                            if (quantity != PluralsQuantity.Count)
                                                            {
                                                                if (values[(int)quantity] == null)
                                                                {
                                                                    values[(int)quantity] = Utils.processTokenValue(reader.ReadString());
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("Duplicate <item> tag with attribute \"quantity\" value \"" + quantityValue + "\" in tag <plurals> with name \"" + tokenName + "\" in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("Unexpected tag <" + reader.Name + "> found in tag <plurals> in \"Assets/Resources/" + xmlResPath + ".xml\"");
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

                                                pluralsNames.Add(tokenName);

                                                int index;

                                                if (tokenIds[2].TryGetValue(tokenName, out index))
                                                {
                                                    if (res.pluralsValues[index] == null)
                                                    {
                                                        res.pluralsValues[index] = values;
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("Tag <plurals> with unknown token name \"" + tokenName + "\" found in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("Unexpected tag <" + reader.Name + "> found in tag <resources> in \"Assets/Resources/" + xmlResPath + ".xml\"");
                                        }
                                    }
                                }

                                break;
                            }
                        }

                        if (!resourcesFound)
                        {
                            Debug.LogError("Tag <resources> not found in \"Assets/Resources/" + xmlResPath + ".xml\"");
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Exception occured while parsing \"Assets/Resources/" + xmlResPath + ".xml\"");
                        Debug.LogException(e);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }

                if (locale != "")
                {
                    int index = locale.LastIndexOf('-');

                    if (index < 0)
                    {
                        break;
                    }

                    locale = locale.Remove(index);
                }
                else
                {
                    break;
                }
            } while (true);

            return res;
        }
    }
}
