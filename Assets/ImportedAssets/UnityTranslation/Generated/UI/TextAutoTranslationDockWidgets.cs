﻿// This file generated from xml files in "Assets/Resources/res/values".
using UnityEngine;
using UnityEngine.UI;



namespace UnityTranslation
{
    /// <summary>
    /// Script for auto-translating Text component.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TextAutoTranslationDockWidgets : MonoBehaviour
    {
        /// <summary>
        /// Token identifier that used for localization.
        /// </summary>
        public R.sections.DockWidgets.strings id;

        private Text mText;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            mText = GetComponent<Text>();
            mText.text = Translator.GetString(id);

            Translator.AddLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Script destroying callback.
        /// </summary>
        void OnDestroy()
        {
            Translator.RemoveLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Callback for language changed event.
        /// </summary>
        public void OnLanguageChanged()
        {
            mText.text = Translator.GetString(id);
        }
    }
}
