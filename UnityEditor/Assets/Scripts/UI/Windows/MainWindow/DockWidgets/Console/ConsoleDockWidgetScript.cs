using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Console
{
    /// <summary>
    /// Script that realize console dock widget behaviour.
    /// </summary>
    public class ConsoleDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Console.ConsoleDockWidgetScript"/> class.
        /// </summary>
        private ConsoleDockWidgetScript()
            : base()
        {
            image   = Assets.Windows.MainWindow.DockWidgets.Console.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.console;
        }

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="UI.Windows.MainWindow.DockWidgets.Console.ConsoleDockWidgetScript"/> class.
		/// </summary>
        public static ConsoleDockWidgetScript Create()
        {
            if (Global.consoleDockWidgetScript == null)
            {
                //***************************************************************************
                // Console GameObject
                //***************************************************************************
                #region Console GameObject
                GameObject console = new GameObject("Console");
                Utils.InitUIObject(console, Global.dockingAreaScript.transform);

                //===========================================================================
                // ConsoleDockWidgetScript Component
                //===========================================================================
                #region ConsoleDockWidgetScript Component
                Global.consoleDockWidgetScript = console.AddComponent<ConsoleDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.consoleDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Console.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (Global.consoleDockWidgetScript == this)
            {
                Global.consoleDockWidgetScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in ConsoleDockWidgetScript.OnDestroy");
            }
        }
    }
}
