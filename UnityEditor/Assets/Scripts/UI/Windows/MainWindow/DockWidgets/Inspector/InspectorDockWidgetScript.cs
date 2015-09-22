using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Inspector
{
    /// <summary>
    /// Script that realize inspector dock widget behaviour.
    /// </summary>
    public class InspectorDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Inspector.InspectorDockWidgetScript"/> class.
        /// </summary>
        private InspectorDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created InspectorDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.Inspector.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.inspector;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Inspector.InspectorDockWidgetScript"/> class.
        /// </summary>
        public static InspectorDockWidgetScript Create()
        {
            DebugEx.Verbose("InspectorDockWidgetScript.Create()");

            if (Global.inspectorDockWidgetScript == null)
            {
                //***************************************************************************
                // Inspector GameObject
                //***************************************************************************
                #region Inspector GameObject
                GameObject inspector = new GameObject("Inspector");
                Utils.InitUIObject(inspector, Global.dockingAreaScript.transform);

                //===========================================================================
                // InspectorDockWidgetScript Component
                //===========================================================================
                #region InspectorDockWidgetScript Component
                Global.inspectorDockWidgetScript = inspector.AddComponent<InspectorDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.inspectorDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
			DebugEx.VerboseFormat("InspectorDockWidgetScript.CreateContent(contentTransform = {0})", contentTransform);

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Inspector.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("InspectorDockWidgetScript.OnDestroy()");

            if (Global.inspectorDockWidgetScript == this)
            {
                Global.inspectorDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in InspectorDockWidgetScript.OnDestroy()");
            }
        }
    }
}
