using UnityEngine;

using UI.Popups;
using UI.Toasts;
using UI.Tooltips;
using UI.Windows.MainWindow.DockWidgets;
using UI.Windows.MainWindow.MainMenu;
using UI.Windows.MainWindow.Toolbar;



/// <summary>
/// Class with global data.
/// </summary>
public static class Global
{
	/// <summary>
	/// MainMenu script.
	/// </summary>
	public static MainMenuScript mainMenuScript;

	/// <summary>
	/// Toolbar script.
	/// </summary>
	public static ToolbarScript toolbarScript;

	/// <summary>
	/// DockingArea script.
	/// </summary>
	public static DockingAreaScript dockingAreaScript;

	/// <summary>
	/// PopupMenuArea transform.
	/// </summary>
	public static Transform popupMenuAreaTransform;

	/// <summary>
	/// PopupMenuArea script.
	/// </summary>
	public static PopupMenuAreaScript popupMenuAreaScript;

	/// <summary>
	/// TooltipArea script.
	/// </summary>
	public static TooltipAreaScript tooltipAreaScript;

	/// <summary>
	/// ToastArea script.
	/// </summary>
	public static ToastAreaScript toastAreaScript;
}
