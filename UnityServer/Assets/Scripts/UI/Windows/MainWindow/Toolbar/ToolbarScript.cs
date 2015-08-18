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
    }
}
