using UnityEngine;

using Common.UI.DockWidgets;
using UI.Windows.AboutDialog;
using UI.Windows.MainWindow;
using UI.Windows.MainWindow.DockWidgets.Animation;
using UI.Windows.MainWindow.DockWidgets.Animator;
using UI.Windows.MainWindow.DockWidgets.AnimatorParameter;
using UI.Windows.MainWindow.DockWidgets.AssetStore;
using UI.Windows.MainWindow.DockWidgets.AudioMixer;
using UI.Windows.MainWindow.DockWidgets.Console;
using UI.Windows.MainWindow.DockWidgets.FrameDebugger;
using UI.Windows.MainWindow.DockWidgets.Game;
using UI.Windows.MainWindow.DockWidgets.Hierarchy;
using UI.Windows.MainWindow.DockWidgets.Inspector;
using UI.Windows.MainWindow.DockWidgets.Lighting;
using UI.Windows.MainWindow.DockWidgets.Navigation;
using UI.Windows.MainWindow.DockWidgets.OcclusionCulling;
using UI.Windows.MainWindow.DockWidgets.Profiler;
using UI.Windows.MainWindow.DockWidgets.Project;
using UI.Windows.MainWindow.DockWidgets.Scene;
using UI.Windows.MainWindow.DockWidgets.SpritePacker;
using UI.Windows.MainWindow.DockWidgets.VersionControl;
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
    /// AudioMixerDockWidget script.
    /// </summary>
    public static AudioMixerDockWidgetScript audioMixerDockWidgetScript = null;

    /// <summary>
    /// AssetStoreDockWidget script.
    /// </summary>
    public static AssetStoreDockWidgetScript assetStoreDockWidgetScript = null;

    /// <summary>
    /// VersionControlDockWidget script.
    /// </summary>
    public static VersionControlDockWidgetScript versionControlDockWidgetScript = null;

    /// <summary>
    /// AnimatorParameterDockWidget script.
    /// </summary>
    public static AnimatorParameterDockWidgetScript animatorParameterDockWidgetScript = null;

    /// <summary>
    /// AnimatorDockWidget script.
    /// </summary>
    public static AnimatorDockWidgetScript animatorDockWidgetScript = null;

    /// <summary>
    /// SpritePackerDockWidget script.
    /// </summary>
    public static SpritePackerDockWidgetScript spritePackerDockWidgetScript = null;

    /// <summary>
    /// LightingDockWidget script.
    /// </summary>
    public static LightingDockWidgetScript lightingDockWidgetScript = null;

    /// <summary>
    /// OcclusionCullingDockWidget script.
    /// </summary>
    public static OcclusionCullingDockWidgetScript occlusionCullingDockWidgetScript = null;

    /// <summary>
    /// FrameDebuggerDockWidget script.
    /// </summary>
    public static FrameDebuggerDockWidgetScript frameDebuggerDockWidgetScript = null;

    /// <summary>
    /// NavigationDockWidget script.
    /// </summary>
    public static NavigationDockWidgetScript navigationDockWidgetScript = null;

    /// <summary>
    /// ConsoleDockWidget script.
    /// </summary>
    public static ConsoleDockWidgetScript consoleDockWidgetScript = null;

    /// <summary>
    /// About dialog script.
    /// </summary>
    public static AboutDialogScript aboutDialogScript = null;
}
