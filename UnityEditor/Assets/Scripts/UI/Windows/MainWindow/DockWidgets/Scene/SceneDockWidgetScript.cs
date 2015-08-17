using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Scene
{
    /// <summary>
    /// Script that realize scene dock widget behaviour.
    /// </summary>
    public class SceneDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Scene.SceneDockWidgetScript"/> class.
        /// </summary>
        private SceneDockWidgetScript()
            : base()
        {
            image   = Assets.Windows.MainWindow.DockWidgets.Scene.Textures.icon;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.scene;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Scene.SceneDockWidgetScript"/> class.
        /// </summary>
        public static SceneDockWidgetScript Create()
        {
            if (Global.sceneDockWidgetScript == null)
            {
                //***************************************************************************
                // Scene GameObject
                //***************************************************************************
                #region Scene GameObject
                GameObject scene = new GameObject("Scene");
                Utils.InitUIObject(scene, Global.dockingAreaScript.transform);

                //===========================================================================
                // SceneDockWidgetScript Component
                //===========================================================================
                #region SceneDockWidgetScript Component
                Global.sceneDockWidgetScript = scene.AddComponent<SceneDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.sceneDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Scene.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (Global.sceneDockWidgetScript == this)
            {
                Global.sceneDockWidgetScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in SceneDockWidgetScript.OnDestroy");
            }
        }
    }
}
