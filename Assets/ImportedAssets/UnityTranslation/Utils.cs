using UnityEngine;
using System.Collections.Generic;


namespace UnityTranslationInternal
{
    /// <summary>
    /// Class with utilities for UnityTranslation.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Checks the name of the token.
        /// </summary>
        /// <returns><c>true</c>, if token name is correct, <c>false</c> otherwise.</returns>
        /// <param name="tokenName">Token name.</param>
        /// <param name="tagName">Tag name.</param>
        /// <param name="tokenNames">List of token names.</param>
        public static bool checkTokenName(string tokenName, string tagName, List<string> tokenNames)
        {
            if (tokenName == null)
            {
                Debug.LogError("Attribute \"name\" not found for tag <" + tagName + "> in \"Assets/Resources/res/values/strings.xml\"");

                return false;
            }

            if (tokenName == "")
            {
                Debug.LogError("Attribute \"name\" empty for tag <" + tagName + "> in \"Assets/Resources/res/values/strings.xml\"");

                return false;
            }

            if (tokenName[0] >= '0' && tokenName[0] <= '9')
            {
                Debug.LogError("Attribute \"name\" for tag <" + tagName + "> starts with a digit (\"" + tokenName + "\") in \"Assets/Resources/res/values/strings.xml\"");

                return false;
            }

            for (int i = 0; i < tokenName.Length; ++i)
            {
                char ch = tokenName[i];

                if (
                    (ch < 'a' || ch > 'z')
                    &&
                    (ch < 'A' || ch > 'Z')
                    &&
                    (ch < '0' || ch > '9')
                    &&
                    ch != '_'
                    )
                {
                    Debug.LogError("Attribute \"name\" for tag <" + tagName + "> has unsupported character \"" + ch + "\" in value \"" + tokenName + "\" in \"Assets/Resources/res/values/strings.xml\"");

                    return false;
                }
            }

            if (tokenNames.Contains(tokenName))
            {
                Debug.LogError("Attribute \"name\" for tag <" + tagName + "> has duplicate value \"" + tokenName + "\" in \"Assets/Resources/res/values/strings.xml\"");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Processes the token value and replaces \\u sentences with unicode chars.
        /// </summary>
        /// <returns>Processed token value.</returns>
        /// <param name="value">Original token value.</param>
        public static string processTokenValue(string value)
        {
            string res = value.Trim();

            for (int i = 0; i < res.Length; ++i)
            {
                if (res[i] == '\n')
                {
                    res = res.Remove(i, 1).Insert(i, " ");
                    ++i;

                    while (i < res.Length && (res[i] == ' ' || res[i] == '\t' || res[i] == '\n'))
                    {
                        res = res.Remove(i, 1);
                    }
                }
                else
                if (res[i] == '\\')
                {
                    if (i < res.Length - 1)
                    {
                        if (res[i + 1] == '\\')
                        {
                            res = res.Remove(i, 1);
                        }
                        else
                        if (res[i + 1] == '\"')
                        {
                            res = res.Remove(i, 1);
                        }
                        else
                        if (res[i + 1] == '\'')
                        {
                            res = res.Remove(i, 1);
                        }
                        else
                        if (res[i + 1] == 'n')
                        {
                            res = res.Remove(i, 2).Insert(i, "\n");
                        }
                        else
                        if (res[i + 1] == 't')
                        {
                            res = res.Remove(i, 2).Insert(i, "\t");
                        }
                        else
                        if (res[i + 1] == 'u')
                        {
                            if (i < res.Length - 5)
                            {
                                string charHex = res.Substring(i + 2, 4);

                                int unicodeChar;

                                if (int.TryParse(charHex, System.Globalization.NumberStyles.HexNumber, null, out unicodeChar))
                                {
                                    res = res.Remove(i, 6).Insert(i, char.ConvertFromUtf32(unicodeChar));
                                }
                                else
                                {
                                    Debug.LogWarning("Incorrect unicode char in token value: " + value);
                                }
                            }
                            else
                            {
                                Debug.LogWarning("Incorrect unicode char in token value: " + value);

                                break;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Unexpected escape character at the end of token value: " + value);
                    }
                }
            }

            return res;
        }
    }
}
