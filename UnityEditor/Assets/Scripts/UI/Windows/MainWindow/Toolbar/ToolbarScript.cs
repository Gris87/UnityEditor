using UnityEngine;

using Common;
using Common.App;



namespace UI.Windows.MainWindow.Toolbar
{
    /// <summary>
    /// Script that realize toolbar behaviour.
    /// </summary>
    public class ToolbarScript : MonoBehaviour
    {
        private ToolbarUI mUi;



        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.Toolbar.ToolbarScript"/> class.
        /// </summary>
        public ToolbarScript()
            : base()
        {
            DebugEx.Verbose("Created ToolbarScript object");

            mUi = null;
        }

        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            DebugEx.Verbose("ToolbarScript.Start()");

            mUi = new ToolbarUI(this);

            mUi.SetupUI();
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("ToolbarScript.OnDestroy()");

            mUi.Release();
        }

        /// <summary>
        /// Handler for resize event.
        /// </summary>
        public void OnResize()
        {
            DebugEx.Verbose("ToolbarScript.OnResize()");

            if (mUi != null)
            {
                mUi.OnResize();
            }
        }

        /// <summary>
        /// Handler for Hand tool selection.
        /// </summary>
        public void OnToolHandClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnToolHandClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnToolHandClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Move tool selection.
        /// </summary>
        public void OnToolMoveClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnToolMoveClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnToolMoveClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Rotate tool selection.
        /// </summary>
        public void OnToolRotateClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnToolRotateClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnToolRotateClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Scale tool selection.
        /// </summary>
        public void OnToolScaleClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnToolScaleClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnToolScaleClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for RectTransform tool selection.
        /// </summary>
        public void OnToolRectTransformClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnToolRectTransformClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnToolRectTransformClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for base point selection.
        /// </summary>
        public void OnBasePointClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnBasePointClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnBasePointClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for coordinate system selection.
        /// </summary>
        public void OnCoordinateSystemClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnCoordinateSystemClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnCoordinateSystemClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for play button.
        /// </summary>
        public void OnPlayClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnPlayClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnPlayClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for pause button.
        /// </summary>
        public void OnPauseClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnPauseClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnPauseClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for step button.
        /// </summary>
        public void OnStepClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnStepClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnStepClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for layers popup button.
        /// </summary>
        public void OnLayersClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnLayersClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnLayersClicked

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for layout popup button.
        /// </summary>
        public void OnLayoutClicked()
        {
            DebugEx.UserInteraction("ToolbarScript.OnLayoutClicked()");
            // TODO: [Minor] Implement ToolbarScript.OnLayoutClicked

            AppUtils.ShowContributeMessage();
        }
    }
}
