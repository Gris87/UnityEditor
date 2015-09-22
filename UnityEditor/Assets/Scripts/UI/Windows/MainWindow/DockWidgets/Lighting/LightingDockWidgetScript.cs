using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Lighting
{
    /// <summary>
    /// Script that realize lighting dock widget behaviour.
    /// </summary>
    public class LightingDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Lighting.LightingDockWidgetScript"/> class.
        /// </summary>
        private LightingDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created LightingDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.Lighting.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.lighting;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Lighting.LightingDockWidgetScript"/> class.
        /// </summary>
        public static LightingDockWidgetScript Create()
        {
            DebugEx.Verbose("LightingDockWidgetScript.Create()");

            if (Global.lightingDockWidgetScript == null)
            {
                //***************************************************************************
                // Lighting GameObject
                //***************************************************************************
                #region Lighting GameObject
                GameObject lighting = new GameObject("Lighting");
                Utils.InitUIObject(lighting, Global.dockingAreaScript.transform);

                //===========================================================================
                // LightingDockWidgetScript Component
                //===========================================================================
                #region LightingDockWidgetScript Component
                Global.lightingDockWidgetScript = lighting.AddComponent<LightingDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.lightingDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
			DebugEx.VerboseFormat("LightingDockWidgetScript.CreateContent(contentTransform = {0})", contentTransform);

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Lighting.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("LightingDockWidgetScript.OnDestroy()");

            if (Global.lightingDockWidgetScript == this)
            {
                Global.lightingDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in LightingDockWidgetScript.OnDestroy()");
            }
        }
    }
}
