using UnityEngine;

using Common.UI.DockWidgets;
using UI.Windows.AboutDialog;
using UI.Windows.MainWindow;
using UI.Windows.MainWindow.DockWidgets.Animation;
using UI.Windows.MainWindow.DockWidgets.Game;
using UI.Windows.MainWindow.DockWidgets.Hierarchy;
using UI.Windows.MainWindow.DockWidgets.Inspector;
using UI.Windows.MainWindow.DockWidgets.Profiler;
using UI.Windows.MainWindow.DockWidgets.Project;
using UI.Windows.MainWindow.DockWidgets.Scene;
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
	/// SceneDockWidget script.
	/// </summary>
	public static SceneDockWidgetScript sceneDockWidgetScript = null;

	/// <summary>
	/// GameDockWidget script.
	/// </summary>
	public static GameDockWidgetScript gameDockWidgetScript = null;

	/// <summary>
	/// InspectorDockWidget script.
	/// </summary>
	public static InspectorDockWidgetScript inspectorDockWidgetScript = null;

	/// <summary>
	/// HierarchyDockWidget script.
	/// </summary>
	public static HierarchyDockWidgetScript hierarchyDockWidgetScript = null;

	/// <summary>
	/// ProjectDockWidget script.
	/// </summary>
	public static ProjectDockWidgetScript projectDockWidgetScript = null;

	/// <summary>
	/// AnimationDockWidget script.
	/// </summary>
	public static AnimationDockWidgetScript animationDockWidgetScript = null;

	/// <summary>
	/// ProfilerDockWidget script.
	/// </summary>
	public static ProfilerDockWidgetScript profilerDockWidgetScript = null;

	/// <summary>
	/// About dialog script.
	/// </summary>
	public static AboutDialogScript aboutDialogScript = null;
}
