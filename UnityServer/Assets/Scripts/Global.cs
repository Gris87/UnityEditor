using UnityEngine;

using Common.UI.DockWidgets;
using UI.Windows.AboutDialog;
using UI.Windows.MainWindow;
using UI.Windows.MainWindow.DockWidgets.Servers;
using UI.Windows.MainWindow.MainMenu;
using UI.Windows.MainWindow.Toolbar;



/// <summary>
/// Class with global data.
/// </summary>
public static class Global
{
    /// <summary>
    /// Windows transform.
    /// </summary>
    public static Transform windowsTransform = null;

    /// <summary>
    /// Main window script.
    /// </summary>
    public static MainWindowScript mainWindowScript = null;

    /// <summary>
    /// MainMenu script.
    /// </summary>
    public static MainMenuScript mainMenuScript = null;

    /// <summary>
    /// Toolbar script.
    /// </summary>
    public static ToolbarScript toolbarScript = null;

    /// <summary>
    /// DockingArea script.
    /// </summary>
    public static DockingAreaScript dockingAreaScript = null;

    /// <summary>
    /// ServersDockWidget script.
    /// </summary>
    public static ServersDockWidgetScript serversDockWidgetScript = null;

    /// <summary>
    /// About dialog script.
    /// </summary>
    public static AboutDialogScript aboutDialogScript = null;
}
