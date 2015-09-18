using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Project
{
    /// <summary>
    /// Script that realize project dock widget behaviour.
    /// </summary>
    public class ProjectDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Project.ProjectDockWidgetScript"/> class.
        /// </summary>
        private ProjectDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created ProjectDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.Project.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.project;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Project.ProjectDockWidgetScript"/> class.
        /// </summary>
        public static ProjectDockWidgetScript Create()
        {
            DebugEx.Verbose("ProjectDockWidgetScript.Create()");

            if (Global.projectDockWidgetScript == null)
            {
                //***************************************************************************
                // Project GameObject
                //***************************************************************************
                #region Project GameObject
                GameObject project = new GameObject("Project");
                Utils.InitUIObject(project, Global.dockingAreaScript.transform);

                //===========================================================================
                // ProjectDockWidgetScript Component
                //===========================================================================
                #region ProjectDockWidgetScript Component
                Global.projectDockWidgetScript = project.AddComponent<ProjectDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.projectDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            DebugEx.Verbose("ProjectDockWidgetScript.CreateContent()");

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Project.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("ProjectDockWidgetScript.OnDestroy()");

            if (Global.projectDockWidgetScript == this)
            {
                Global.projectDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in ProjectDockWidgetScript.OnDestroy()");
            }
        }
    }
}
