using UnityEngine;

using Common.App;
using Common.App.Net;
using Common.UI.DockWidgets;
using UI.Windows.MainWindow;



/// <summary>
/// Class with global data.
/// </summary>
public static class Global
{
    /// <summary>
    /// Client script.
    /// </summary>
    public static ClientScript clientScript = null;

    /// <summary>
    /// Windows transform.
    /// </summary>
    public static Transform windowsTransform = null;

    /// <summary>
    /// Main window script.
    /// </summary>
    public static MainWindowScript mainWindowScript = null;

    /// <summary>
    /// DockingArea script.
    /// </summary>
    public static DockingAreaScript dockingAreaScript = null;
}
