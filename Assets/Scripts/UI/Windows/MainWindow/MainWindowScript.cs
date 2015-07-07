using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.UI.DockWidgets;
using Common.UI.Windows;
using UI.Windows.MainWindow.DockWidgets.Animation; // TODO: [Minor] Remove it
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



namespace UI.Windows.MainWindow
{
	/// <summary>
	/// Script that realize main window behaviour.
	/// </summary>
	public class MainWindowScript : WindowScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
		/// </summary>
		private MainWindowScript()
			: base()
		{
			frame           = WindowFrameType.Frameless;
			state           = WindowState.FullScreen;
			backgroundColor = Assets.Windows.MainWindow.Colors.background;
			allowClose      = false;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
		/// </summary>
		public static MainWindowScript Create()
		{
			if (Global.mainWindowScript == null)
			{
				//***************************************************************************
				// MainWindow GameObject
				//***************************************************************************
				#region MainWindow GameObject
				GameObject mainWindow = new GameObject("MainWindow");
				Utils.InitUIObject(mainWindow, Global.windowsTransform);
				
				//===========================================================================
				// MainWindowScript Component
				//===========================================================================
				#region MainWindowScript Component
				Global.mainWindowScript = mainWindow.AddComponent<MainWindowScript>();
				#endregion
				#endregion
			}
			
			return Global.mainWindowScript;
		}

		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected override void CreateContent(Transform contentTransform, out float width, out float height)
		{
			width  = 0f;
			height = 0f;

			float mainMenuHeight = 20f;
			float toolbarHeight  = 32f;

			//***************************************************************************
			// MainMenu GameObject
			//***************************************************************************
			#region MainMenu GameObject
			GameObject mainMenu = new GameObject("MainMenu");
			Utils.InitUIObject(mainMenu, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform mainMenuTransform = mainMenu.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(mainMenuTransform, mainMenuHeight);
			#endregion
			
			//===========================================================================
			// MainMenuScript Component
			//===========================================================================
			#region MainMenuScript Component
			Global.mainMenuScript = mainMenu.AddComponent<MainMenuScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// Toolbar GameObject
			//***************************************************************************
			#region Toolbar GameObject
			GameObject toolbar = new GameObject("Toolbar");
			Utils.InitUIObject(toolbar, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toolbarTransform = toolbar.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(toolbarTransform, toolbarHeight, mainMenuHeight);
			#endregion
			
			//===========================================================================
			// ToolbarScript Component
			//===========================================================================
			#region ToolbarScript Component
			Global.toolbarScript = toolbar.AddComponent<ToolbarScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// DockingArea GameObject
			//***************************************************************************
			#region DockingArea GameObject
			GameObject dockingArea = new GameObject("DockingArea");
			Utils.InitUIObject(dockingArea, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, mainMenuHeight + toolbarHeight, 0f, 0f);
			#endregion
			
			//===========================================================================
			// DockingAreaScript Component
			//===========================================================================
			#region DockingAreaScript Component
			Global.dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
			#endregion
			#endregion

			LoadDockWidgets();
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (Global.mainWindowScript == this)
			{
				Global.mainWindowScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in MainWindowScript.OnDestroy");
			}
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		protected override void OnResize()
		{
			if (Global.toolbarScript != null)
			{
				Global.toolbarScript.OnResize();
			}

			if (Global.dockingAreaScript != null)
			{
				Global.dockingAreaScript.OnResize();
            }
		}

		/// <summary>
		/// Loads dock widgets layout.
		/// </summary>
		private void LoadDockWidgets()
		{
			// TODO: [Minor] Remove it
			SceneDockWidgetScript.Create().InsertToDockingArea(Global.dockingAreaScript);
			GameDockWidgetScript.Create().InsertToDockingGroup(Global.dockingAreaScript.dockingGroupScript, 1);
			InspectorDockWidgetScript.Create().InsertToDockingArea(Global.dockingAreaScript, DockingAreaOrientation.Vertical, 0);
			HierarchyDockWidgetScript.Create().InsertToDockingArea(Global.dockingAreaScript, DockingAreaOrientation.Horizontal, 0);
			ProjectDockWidgetScript.Create().InsertToDockingArea(Global.dockingAreaScript, DockingAreaOrientation.Horizontal, 2);
		}
	}
}

