using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Servers
{
    /// <summary>
    /// Script that realize servers dock widget behaviour.
    /// </summary>
    public class ServersDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Servers.ServersDockWidgetScript"/> class.
        /// </summary>
        private ServersDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created ServersDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.Servers.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.servers;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Servers.ServersDockWidgetScript"/> class.
        /// </summary>
        public static ServersDockWidgetScript Create()
        {
            DebugEx.Verbose("ServersDockWidgetScript.Create()");

            if (Global.serversDockWidgetScript == null)
            {
                //***************************************************************************
                // Servers GameObject
                //***************************************************************************
                #region Servers GameObject
                GameObject servers = new GameObject("Servers");
                Utils.InitUIObject(servers, Global.dockingAreaScript.transform);

                //===========================================================================
                // ServersDockWidgetScript Component
                //===========================================================================
                #region ServersDockWidgetScript Component
                Global.serversDockWidgetScript = servers.AddComponent<ServersDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.serversDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            DebugEx.VerboseFormat("ServersDockWidgetScript.CreateContent(contentTransform = {0})", contentTransform);

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Servers.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("ServersDockWidgetScript.OnDestroy()");

            if (Global.serversDockWidgetScript == this)
            {
                Global.serversDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in ServersDockWidgetScript.OnDestroy()");
            }
        }
    }
}
