using UnityEngine;
using UnityTranslation;



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
            mUi = null;
        }

        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            mUi = new ToolbarUI(this);

            mUi.SetupUI();
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            mUi.Release();
        }

        /// <summary>
        /// Handler for resize event.
        /// </summary>
        public void OnResize()
        {
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
            Debug.Log("ToolbarScript.OnToolHandClicked");
            // TODO: [Minor] Implement ToolbarScript.OnToolHandClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Move tool selection.
        /// </summary>
        public void OnToolMoveClicked()
        {
            Debug.Log("ToolbarScript.OnToolMoveClicked");
            // TODO: [Minor] Implement ToolbarScript.OnToolMoveClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Rotate tool selection.
        /// </summary>
        public void OnToolRotateClicked()
        {
            Debug.Log("ToolbarScript.OnToolRotateClicked");
            // TODO: [Minor] Implement ToolbarScript.OnToolRotateClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Scale tool selection.
        /// </summary>
        public void OnToolScaleClicked()
        {
            Debug.Log("ToolbarScript.OnToolScaleClicked");
            // TODO: [Minor] Implement ToolbarScript.OnToolScaleClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for RectTransform tool selection.
        /// </summary>
        public void OnToolRectTransformClicked()
        {
            Debug.Log("ToolbarScript.OnToolRectTransformClicked");
            // TODO: [Minor] Implement ToolbarScript.OnToolRectTransformClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for base point selection.
        /// </summary>
        public void OnBasePointClicked()
        {
            Debug.Log("ToolbarScript.OnBasePointClicked");
            // TODO: [Minor] Implement ToolbarScript.OnBasePointClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for coordinate system selection.
        /// </summary>
        public void OnCoordinateSystemClicked()
        {
            Debug.Log("ToolbarScript.OnCoordinateSystemClicked");
            // TODO: [Minor] Implement ToolbarScript.OnCoordinateSystemClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for play button.
        /// </summary>
        public void OnPlayClicked()
        {
            Debug.Log("ToolbarScript.OnPlayClicked");
            // TODO: [Minor] Implement ToolbarScript.OnPlayClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for pause button.
        /// </summary>
        public void OnPauseClicked()
        {
            Debug.Log("ToolbarScript.OnPauseClicked");
            // TODO: [Minor] Implement ToolbarScript.OnPauseClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for step button.
        /// </summary>
        public void OnStepClicked()
        {
            Debug.Log("ToolbarScript.OnStepClicked");
            // TODO: [Minor] Implement ToolbarScript.OnStepClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for layers popup button.
        /// </summary>
        public void OnLayersClicked()
        {
            Debug.Log("ToolbarScript.OnLayersClicked");
            // TODO: [Minor] Implement ToolbarScript.OnLayersClicked

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for layout popup button.
        /// </summary>
        public void OnLayoutClicked()
        {
            Debug.Log("ToolbarScript.OnLayoutClicked");
            // TODO: [Minor] Implement ToolbarScript.OnLayoutClicked

            AppCommonUtils.ShowContributeMessage();
        }
    }
}
