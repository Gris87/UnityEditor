using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.AudioMixer
{
    /// <summary>
    /// Script that realize audioMixer dock widget behaviour.
    /// </summary>
    public class AudioMixerDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.AudioMixer.AudioMixerDockWidgetScript"/> class.
        /// </summary>
        private AudioMixerDockWidgetScript()
            : base()
        {
            image   = Assets.Windows.MainWindow.DockWidgets.AudioMixer.Textures.icon;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.audio_mixer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.AudioMixer.AudioMixerDockWidgetScript"/> class.
        /// </summary>
        public static AudioMixerDockWidgetScript Create()
        {
            if (Global.audioMixerDockWidgetScript == null)
            {
                //***************************************************************************
                // AudioMixer GameObject
                //***************************************************************************
                #region AudioMixer GameObject
                GameObject audioMixer = new GameObject("AudioMixer");
                Utils.InitUIObject(audioMixer, Global.dockingAreaScript.transform);

                //===========================================================================
                // AudioMixerDockWidgetScript Component
                //===========================================================================
                #region AudioMixerDockWidgetScript Component
                Global.audioMixerDockWidgetScript = audioMixer.AddComponent<AudioMixerDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.audioMixerDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            backgroundColor = Assets.Windows.MainWindow.DockWidgets.AudioMixer.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (Global.audioMixerDockWidgetScript == this)
            {
                Global.audioMixerDockWidgetScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in AudioMixerDockWidgetScript.OnDestroy");
            }
        }
    }
}
