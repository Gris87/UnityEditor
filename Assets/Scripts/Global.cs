using UnityEngine;

using Common.UI;
using UI.Popups;
using UI.Toasts;
using UI.Tooltips;
using UI.Windows.AboutDialog;
using UI.Windows.MainWindow;
using UI.Windows.MainWindow.DockWidgets;
using UI.Windows.MainWindow.MainMenu;
using UI.Windows.MainWindow.Toolbar;



/// <summary>
/// Class with global data.
/// </summary>
public static class Global
{
	/// <summary>
	/// ResizeListener script.
	/// </summary>
	public static ResizeListenerScript resizeListenerScript = null;

	/// <summary>
	/// Windows transform.
	/// </summary>
	public static Transform windowsTransform = null;

	/// <summary>
	/// PopupMenuArea transform.
	/// </summary>
	public static Transform popupMenuAreaTransform = null;

	/// <summary>
	/// PopupMenuArea script.
	/// </summary>
	public static PopupMenuAreaScript popupMenuAreaScript = null;

	/// <summary>
	/// TooltipArea script.
	/// </summary>
	public static TooltipAreaScript tooltipAreaScript = null;

	/// <summary>
	/// ToastArea script.
	/// </summary>
	public static ToastAreaScript toastAreaScript = null;

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
	/// About dialog script.
	/// </summary>
	public static AboutDialogScript aboutDialogScript = null;
}
