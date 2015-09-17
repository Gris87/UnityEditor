using Common;



namespace UI.Windows.MainWindow.Toolbar
{
    /// <summary>
    /// Toolbar user interface.
    /// </summary>
    public class ToolbarUI
    {
        //private ToolbarScript mScript;



        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.Toolbar.ToolbarUI"/> class.
        /// </summary>
        /// <param name="script">Toolbar script.</param>
        public ToolbarUI(ToolbarScript script)
        {
            DebugEx.Verbose("Created ToolbarUI object");

            //mScript = script;
        }

        /// <summary>
        /// Setup user interface.
        /// </summary>
        public void SetupUI()
        {
            DebugEx.Verbose("ToolbarUI.SetupUI()");

            CreateUI();
        }

        /// <summary>
        /// Creates user interface.
        /// </summary>
        private void CreateUI()
        {
            DebugEx.Verbose("ToolbarUI.CreateUI()");

            // TODO: [Minor] Implement Create UI
        }
    }
}
