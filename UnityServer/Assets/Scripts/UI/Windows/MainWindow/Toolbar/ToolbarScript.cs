using UnityEngine;

using Common;



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
    }
}
