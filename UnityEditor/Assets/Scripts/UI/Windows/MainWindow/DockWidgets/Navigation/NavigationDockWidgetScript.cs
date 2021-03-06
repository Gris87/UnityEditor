using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Navigation
{
    /// <summary>
    /// Script that realize navigation dock widget behaviour.
    /// </summary>
    public class NavigationDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Navigation.NavigationDockWidgetScript"/> class.
        /// </summary>
        private NavigationDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created NavigationDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.Navigation.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.navigation;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Navigation.NavigationDockWidgetScript"/> class.
        /// </summary>
        public static NavigationDockWidgetScript Create()
        {
            DebugEx.Verbose("NavigationDockWidgetScript.Create()");

            if (Global.navigationDockWidgetScript == null)
            {
                //***************************************************************************
                // Navigation GameObject
                //***************************************************************************
                #region Navigation GameObject
                GameObject navigation = new GameObject("Navigation");
                Utils.InitUIObject(navigation, Global.dockingAreaScript.transform);

                //===========================================================================
                // NavigationDockWidgetScript Component
                //===========================================================================
                #region NavigationDockWidgetScript Component
                Global.navigationDockWidgetScript = navigation.AddComponent<NavigationDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.navigationDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            DebugEx.VerboseFormat("NavigationDockWidgetScript.CreateContent(contentTransform = {0})", contentTransform);

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Navigation.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("NavigationDockWidgetScript.OnDestroy()");

            if (Global.navigationDockWidgetScript == this)
            {
                Global.navigationDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in NavigationDockWidgetScript.OnDestroy()");
            }
        }
    }
}
