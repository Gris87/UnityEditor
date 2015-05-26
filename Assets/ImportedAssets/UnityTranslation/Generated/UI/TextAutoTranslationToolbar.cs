// This file generated from xml files in "Assets/Resources/res/values".
using UnityEngine;
using UnityEngine.UI;



namespace UnityTranslation
{
    /// <summary>
    /// Script for auto-translating Text component.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TextAutoTranslationToolbar : MonoBehaviour
    {
        /// <summary>
        /// Token identifier that used for localization.
        /// </summary>
        public R.sections.Toolbar.strings id;

        private Text mText;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            mText = GetComponent<Text>();

            Translator.addLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Script destroying callback.
        /// </summary>
        void OnDestroy()
        {
            Translator.removeLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Callback for language changed event.
        /// </summary>
        public void OnLanguageChanged()
        {
            mText.text = Translator.getString(id);
        }
    }
}
