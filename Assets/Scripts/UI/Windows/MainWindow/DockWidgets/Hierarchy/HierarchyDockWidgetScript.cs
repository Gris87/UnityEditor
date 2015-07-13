using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Hierarchy
{
    /// <summary>
    /// Script that realize hierarchy dock widget behaviour.
    /// </summary>
    public class HierarchyDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Hierarchy.HierarchyDockWidgetScript"/> class.
        /// </summary>
        private HierarchyDockWidgetScript()
            : base()
        {
            image   = Assets.Windows.MainWindow.DockWidgets.Hierarchy.Textures.icon;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.hierarchy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Hierarchy.HierarchyDockWidgetScript"/> class.
        /// </summary>
        public static HierarchyDockWidgetScript Create()
        {
            if (Global.hierarchyDockWidgetScript == null)
            {
                //***************************************************************************
                // Hierarchy GameObject
                //***************************************************************************
                #region Hierarchy GameObject
                GameObject hierarchy = new GameObject("Hierarchy");
                Utils.InitUIObject(hierarchy, Global.dockingAreaScript.transform);

                //===========================================================================
                // HierarchyDockWidgetScript Component
                //===========================================================================
                #region HierarchyDockWidgetScript Component
                Global.hierarchyDockWidgetScript = hierarchy.AddComponent<HierarchyDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.hierarchyDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Hierarchy.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (Global.hierarchyDockWidgetScript == this)
            {
                Global.hierarchyDockWidgetScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in HierarchyDockWidgetScript.OnDestroy");
            }
        }
    }
}
