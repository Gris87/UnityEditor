using UnityEngine;

using Common;
using Common.UI.Windows;



namespace UI.Windows.MainWindow
{
    /// <summary>
    /// Script that realize main window behaviour.
    /// </summary>
    public class MainWindowScript : WindowScript
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
        /// </summary>
        private MainWindowScript()
            : base()
        {
            DebugEx.Verbose("Created MainWindowScript object");

            frame           = WindowFrameType.Frameless;
            state           = WindowState.FullScreen;
            backgroundColor = Assets.Windows.MainWindow.Colors.background;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
        /// </summary>
        public static MainWindowScript Create()
        {
            DebugEx.Verbose("MainWindowScript.Create()");

            if (Global.mainWindowScript == null)
            {
                //***************************************************************************
                // MainWindow GameObject
                //***************************************************************************
                #region MainWindow GameObject
                GameObject mainWindow = new GameObject("MainWindow");
                Utils.InitUIObject(mainWindow, Global.windowsTransform);

                //===========================================================================
                // MainWindowScript Component
                //===========================================================================
                #region MainWindowScript Component
                Global.mainWindowScript = mainWindow.AddComponent<MainWindowScript>();
                #endregion
                #endregion
            }

            return Global.mainWindowScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        /// <param name="width">Width of content.</param>
        /// <param name="height">Height of content.</param>
        protected override void CreateContent(Transform contentTransform, out float width, out float height)
        {
            DebugEx.VerboseFormat("MainWindowScript.CreateContent(contentTransform = {0})", contentTransform);

            width  = 0f;
            height = 0f;

            // TODO: [Major] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();

            DebugEx.Verbose("MainWindowScript.OnDestroy()");

            if (Global.mainWindowScript == this)
            {
                Global.mainWindowScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in MainWindowScript.OnDestroy()");
            }
        }
    }
}
