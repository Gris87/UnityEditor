using System.Collections.Generic;
using UnityEngine;
using UnityTranslation;

using Common;
using Common.UI.MenuItems;
using Common.UI.Popups;
using UI.Windows.AboutDialog;



namespace UI.Windows.MainWindow.MainMenu
{
	/// <summary>
	/// Script that realize main menu behaviour.
	/// </summary>
	public class MainMenuScript : MonoBehaviour, IShortcutHandler
	{
		private MainMenuUI     mUi;
		private List<MenuItem> mShortcuts;
	    private PopupMenu      mPopupMenu;



	    /// <summary>
	    /// Script starting callback.
	    /// </summary>
	    void Start()
	    {
			mUi        = new MainMenuUI(this);
			mShortcuts = new List<MenuItem>();	        
			mPopupMenu = null;

			mUi.SetupUI();
	    }

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			mUi.Release();
		}

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
        {
			if (Global.mainWindowScript.selected && InputControl.anyKeyDown)
			{
				foreach (MenuItem menuItem in mShortcuts)
				{
					if (menuItem.HandleShortcut())
					{
						break;
					}
				}
			}
		}

		/// <summary>
		/// Registers the shortcut.
		/// </summary>
		/// <param name="shortcut">Shortcut.</param>
		public void RegisterShortcut(MenuItem shortcut)
		{
			mShortcuts.Add(shortcut);
		}

		/// <summary>
		/// Deregisters the shortcut.
		/// </summary>
		/// <param name="shortcut">Shortcut.</param>
		public void DeregisterShortcut(MenuItem shortcut)
		{
			if (!mShortcuts.Remove(shortcut))
			{
				Debug.LogError("Failed to deregister shortcut for \"" + shortcut.name + "\"");
			}
		}
        
	    /// <summary>
	    /// Creates and displays popup menu for specified menu item.
	    /// </summary>
	    /// <param name="node"><see cref="Common.TreeNode`1"/> instance.</param>
	    public void OnShowMenuSubItems(TreeNode<CustomMenuItem> node)
	    {
			if (node.data is MenuItem)
			{
				MenuItem item = node.data as MenuItem;
				Debug.Log("MainMenuScript.OnShowMenuSubItems(" + item.name + ")");
				
				if (mPopupMenu != null)
				{
					mPopupMenu.Destroy();
				}
				
				mPopupMenu = new PopupMenu(node);
				mPopupMenu.OnDestroy.AddListener(OnPopupMenuDestroyed);

				int index = node.parent.children.IndexOf(node);

				RectTransform menuItemTransform = transform.GetChild(0).GetChild(0).GetChild(index).GetComponent<RectTransform>(); // ScrollArea/Content/NODE
				Vector3[] menuItemCorners = Utils.GetWindowCorners(menuItemTransform);
				
				mPopupMenu.Show(menuItemCorners[2].x, menuItemCorners[2].y);
			}
			else
			{
				Debug.LogError("Unknown menu item type");
			}
	    }

	    /// <summary>
	    /// Handler for popup menu destroy event.
	    /// </summary>
	    public void OnPopupMenuDestroyed()
	    {
	        Debug.Log("MainMenuScript.OnPopupMenuDestroyed");

	        mPopupMenu = null;
	    }

	    #region Handlers for menu items
	    #region File
	    /// <summary>
	    /// Handler for File.
	    /// </summary>
	    public void OnFileMenu()
	    {
	        OnShowMenuSubItems(mUi.fileMenu);
	    }

	    /// <summary>
	    /// Handler for File -> New Scene.
	    /// </summary>
	    public void OnFile_NewScene()
	    {
	        Debug.Log("MainMenuScript.OnFile_NewScene");
			// TODO: Implement MainMenuScript.OnFile_NewScene
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Open Scene.
	    /// </summary>
	    public void OnFile_OpenScene()
	    {
	        Debug.Log("MainMenuScript.OnFile_OpenScene");
			// TODO: Implement MainMenuScript.OnFile_OpenScene
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Save Scene.
	    /// </summary>
	    public void OnFile_SaveScene()
	    {
	        Debug.Log("MainMenuScript.OnFile_SaveScene");
			// TODO: Implement MainMenuScript.OnFile_SaveScene
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Save Scene as...
	    /// </summary>
	    public void OnFile_SaveSceneAs()
	    {
	        Debug.Log("MainMenuScript.OnFile_SaveSceneAs");
			// TODO: Implement MainMenuScript.OnFile_SaveSceneAs
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> New Project...
	    /// </summary>
	    public void OnFile_NewProject()
	    {
	        Debug.Log("MainMenuScript.OnFile_NewProject");
			// TODO: Implement MainMenuScript.OnFile_NewProject
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Open Project...
	    /// </summary>
	    public void OnFile_OpenProject()
	    {
	        Debug.Log("MainMenuScript.OnFile_OpenProject");
			// TODO: Implement MainMenuScript.OnFile_OpenProject
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Save Project.
	    /// </summary>
	    public void OnFile_SaveProject()
	    {
	        Debug.Log("MainMenuScript.OnFile_SaveProject");
			// TODO: Implement MainMenuScript.OnFile_SaveProject
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Build Settings...
	    /// </summary>
	    public void OnFile_BuildSettings()
	    {
	        Debug.Log("MainMenuScript.OnFile_BuildSettings");
			// TODO: Implement MainMenuScript.OnFile_BuildSettings
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Build & Run.
	    /// </summary>
	    public void OnFile_BuildAndRun()
	    {
	        Debug.Log("MainMenuScript.OnFile_BuildAndRun");
			// TODO: Implement MainMenuScript.OnFile_BuildAndRun
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Build in Cloud...
	    /// </summary>
	    public void OnFile_BuildInCloud()
	    {
	        Debug.Log("MainMenuScript.OnFile_BuildInCloud");
			// TODO: Implement MainMenuScript.OnFile_BuildInCloud
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for File -> Exit.
	    /// </summary>
	    public void OnFile_Exit()
	    {
	        Debug.Log("MainMenuScript.OnFile_Exit");
	        Application.Quit();
	    }
	    #endregion

	    #region Edit
	    /// <summary>
	    /// Handler for Edit.
	    /// </summary>
	    public void OnEditMenu()
	    {
	        OnShowMenuSubItems(mUi.editMenu);
	    }

	    /// <summary>
	    /// Handler for Edit -> Undo.
	    /// </summary>
	    public void OnEdit_Undo()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Undo");
			// TODO: Implement MainMenuScript.OnEdit_Undo
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Redo.
	    /// </summary>
	    public void OnEdit_Redo()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Redo");
			// TODO: Implement MainMenuScript.OnEdit_Redo
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Cut.
	    /// </summary>
	    public void OnEdit_Cut()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Cut");
			// TODO: Implement MainMenuScript.OnEdit_Cut
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Copy.
	    /// </summary>
	    public void OnEdit_Copy()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Copy");
			// TODO: Implement MainMenuScript.OnEdit_Copy
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Paste.
	    /// </summary>
	    public void OnEdit_Paste()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Paste");
			// TODO: Implement MainMenuScript.OnEdit_Paste
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Duplicate.
	    /// </summary>
	    public void OnEdit_Duplicate()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Duplicate");
			// TODO: Implement MainMenuScript.OnEdit_Duplicate
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Delete.
	    /// </summary>
	    public void OnEdit_Delete()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Delete");
			// TODO: Implement MainMenuScript.OnEdit_Delete
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Frame Selected.
	    /// </summary>
	    public void OnEdit_FrameSelected()
	    {
	        Debug.Log("MainMenuScript.OnEdit_FrameSelected");
			// TODO: Implement MainMenuScript.OnEdit_FrameSelected
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Lock View to Selected.
	    /// </summary>
	    public void OnEdit_LockViewToSelected()
	    {
	        Debug.Log("MainMenuScript.OnEdit_LockViewToSelected");
			// TODO: Implement MainMenuScript.OnEdit_LockViewToSelected
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Find.
	    /// </summary>
	    public void OnEdit_Find()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Find");
			// TODO: Implement MainMenuScript.OnEdit_Find
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Select All.
	    /// </summary>
	    public void OnEdit_SelectAll()
	    {
	        Debug.Log("MainMenuScript.OnEdit_SelectAll");
			// TODO: Implement MainMenuScript.OnEdit_SelectAll
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Preferences...
	    /// </summary>
	    public void OnEdit_Preferences()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Preferences");
			// TODO: Implement MainMenuScript.OnEdit_Preferences
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Modules...
	    /// </summary>
	    public void OnEdit_Modules()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Modules");
			// TODO: Implement MainMenuScript.OnEdit_Modules
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Play.
	    /// </summary>
	    public void OnEdit_Play()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Play");
			// TODO: Implement MainMenuScript.OnEdit_Play
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Pause.
	    /// </summary>
	    public void OnEdit_Pause()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Pause");
			// TODO: Implement MainMenuScript.OnEdit_Pause
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Step.
	    /// </summary>
	    public void OnEdit_Step()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Step");
			// TODO: Implement MainMenuScript.OnEdit_Step
			
			AppUtils.ShowContributeMessage();
	    }

	    #region Edit -> Selection
	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 1.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection1()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection1");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection1
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 2.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection2()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection2");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection2
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 3.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection3()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection3");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection3
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 4.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection4()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection4");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection4
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 5.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection5()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection5");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection5
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 6.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection6()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection6");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection6
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 7.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection7()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection7");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection7
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 8.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection8()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection8");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection8
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 9.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection9()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection9");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection9
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Load Selection 0.
	    /// </summary>
	    public void OnEdit_Selection_LoadSelection0()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection0");
			// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection0
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 1.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection1()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection1");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection1
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 2.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection2()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection2");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection2
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 3.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection3()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection3");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection3
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 4.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection4()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection4");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection4
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 5.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection5()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection5");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection5
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 6.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection6()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection6");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection6
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 7.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection7()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection7");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection7
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 8.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection8()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection8");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection8
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 9.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection9()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection9");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection9
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Selection -> Save Selection 0.
	    /// </summary>
	    public void OnEdit_Selection_SaveSelection0()
	    {
	        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection0");
			// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection0
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #region Edit -> Project Settings
	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Input.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Input()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Input");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Input
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Tags and Layers.
	    /// </summary>
	    public void OnEdit_ProjectSettings_TagsAndLayers()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Audio.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Audio()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Audio");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Audio
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Time.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Time()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Time");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Time
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Player.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Player()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Player");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Player
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Physics.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Physics()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Physics 2D.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Physics2D()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics2D");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics2D
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Quality.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Quality()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Quality");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Quality
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Graphics.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Graphics()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Graphics");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Graphics
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Network.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Network()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Network");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Network
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Editor.
	    /// </summary>
	    public void OnEdit_ProjectSettings_Editor()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Editor");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Editor
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Project Settings -> Script Execution Order.
	    /// </summary>
	    public void OnEdit_ProjectSettings_ScriptExecutionOrder()
	    {
	        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder");
			// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #region Edit -> Network Emulation
	    /// <summary>
	    /// Handler for Edit -> Network Emulation -> None.
	    /// </summary>
	    public void OnEdit_NetworkEmulation_None()
	    {
	        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_None");
			// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_None
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Network Emulation -> Broadband.
	    /// </summary>
	    public void OnEdit_NetworkEmulation_Broadband()
	    {
	        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_Broadband");
			// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_Broadband
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Network Emulation -> DSL.
	    /// </summary>
	    public void OnEdit_NetworkEmulation_DSL()
	    {
	        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DSL");
			// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DSL
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Network Emulation -> ISDN.
	    /// </summary>
	    public void OnEdit_NetworkEmulation_ISDN()
	    {
	        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_ISDN");
			// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_ISDN
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Network Emulation -> Dial-Up.
	    /// </summary>
	    public void OnEdit_NetworkEmulation_DialUp()
	    {
	        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DialUp");
			// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DialUp
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #region Edit -> Graphics Emulation
	    /// <summary>
	    /// Handler for Edit -> Graphics Emulation -> No Emulation.
	    /// </summary>
	    public void OnEdit_GraphicsEmulation_NoEmulation()
	    {
	        Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation");
			// TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Graphics Emulation -> Shader Model 3.
	    /// </summary>
	    public void OnEdit_GraphicsEmulation_ShaderModel3()
	    {
	        Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel3");
			// TODO: Implement MainMenuScript.OnEdit_ReOnEdit_GraphicsEmulation_ShaderModel3do
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Edit -> Graphics Emulation -> Shader Model 2.
	    /// </summary>
	    public void OnEdit_GraphicsEmulation_ShaderModel2()
	    {
	        Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2");
			// TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    /// <summary>
	    /// Handler for Edit -> Snap Settings...
	    /// </summary>
	    public void OnEdit_SnapSettings()
	    {
	        Debug.Log("MainMenuScript.OnEdit_SnapSettings");
			// TODO: Implement MainMenuScript.OnEdit_SnapSettings
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #region Assets
	    /// <summary>
	    /// Handler for Assets.
	    /// </summary>
	    public void OnAssetsMenu()
	    {
	        OnShowMenuSubItems(mUi.assetsMenu);
	    }

	    #region Assets -> Create
	    /// <summary>
	    /// Handler for Assets -> Create -> Folder.
	    /// </summary>
	    public void OnAssets_Create_Folder()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Folder");
			// TODO: Implement MainMenuScript.OnAssets_Create_Folder
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> C# Script.
	    /// </summary>
	    public void OnAssets_Create_CSharpScript()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_CSharpScript");
			// TODO: Implement MainMenuScript.OnAssets_Create_CSharpScript
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Javascript.
	    /// </summary>
	    public void OnAssets_Create_Javascript()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Javascript");
			// TODO: Implement MainMenuScript.OnAssets_Create_Javascript
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Shader.
	    /// </summary>
	    public void OnAssets_Create_Shader()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Shader");
			// TODO: Implement MainMenuScript.OnAssets_Create_Shader
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Compute Shader.
	    /// </summary>
	    public void OnAssets_Create_ComputeShader()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_ComputeShader");
			// TODO: Implement MainMenuScript.OnAssets_Create_ComputeShader
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Prefab.
	    /// </summary>
	    public void OnAssets_Create_Prefab()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Prefab");
			// TODO: Implement MainMenuScript.OnAssets_Create_Prefab
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Audio Mixer.
	    /// </summary>
	    public void OnAssets_Create_AudioMixer()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_AudioMixer");
			// TODO: Implement MainMenuScript.OnAssets_Create_AudioMixer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Material.
	    /// </summary>
	    public void OnAssets_Create_Material()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Material");
			// TODO: Implement MainMenuScript.OnAssets_Create_Material
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Lens Flare.
	    /// </summary>
	    public void OnAssets_Create_LensFlare()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_LensFlare");
			// TODO: Implement MainMenuScript.OnAssets_Create_LensFlare
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    /// <summary>
	    /// Handler for Assets -> Create -> Render Texture.
	    /// </summary>
	    public void OnAssets_Create_RenderTexture()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_RenderTexture");
			// TODO: Implement MainMenuScript.OnAssets_Create_RenderTexture
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    /// <summary>
	    /// Handler for Assets -> Create -> Lightmap Parameters.
	    /// </summary>
	    public void OnAssets_Create_LightmapParameters()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_LightmapParameters");
			// TODO: Implement MainMenuScript.OnAssets_Create_LightmapParameters
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Animator Controller.
	    /// </summary>
	    public void OnAssets_Create_AnimatorController()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_AnimatorController");
			// TODO: Implement MainMenuScript.OnAssets_Create_AnimatorController
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Animation.
	    /// </summary>
	    public void OnAssets_Create_Animation()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Animation");
			// TODO: Implement MainMenuScript.OnAssets_Create_Animation
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Animator Override Contoller.
	    /// </summary>
	    public void OnAssets_Create_AnimatorOverrideContoller()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_AnimatorOverrideContoller");
			// TODO: Implement MainMenuScript.OnAssets_Create_AnimatorOverrideContoller
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Avatar Mask.
	    /// </summary>
	    public void OnAssets_Create_AvatarMask()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_AvatarMask");
			// TODO: Implement MainMenuScript.OnAssets_Create_AvatarMask
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Physic Material.
	    /// </summary>
	    public void OnAssets_Create_PhysicMaterial()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_PhysicMaterial");
			// TODO: Implement MainMenuScript.OnAssets_Create_PhysicMaterial
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Physic2D Material.
	    /// </summary>
	    public void OnAssets_Create_Physic2dMaterial()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Physic2dMaterial");
			// TODO: Implement MainMenuScript.OnAssets_Create_Physic2dMaterial
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> GUI Skin.
	    /// </summary>
	    public void OnAssets_Create_GuiSkin()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_GuiSkin");
			// TODO: Implement MainMenuScript.OnAssets_Create_GuiSkin
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Custom Font.
	    /// </summary>
	    public void OnAssets_Create_CustomFont()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_CustomFont");
			// TODO: Implement MainMenuScript.OnAssets_Create_CustomFont
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Create -> Shader Variant Collection.
	    /// </summary>
	    public void OnAssets_Create_ShaderVariantCollection()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_ShaderVariantCollection");
			// TODO: Implement MainMenuScript.OnAssets_Create_ShaderVariantCollection
			
			AppUtils.ShowContributeMessage();
	    }

	    #region Assets -> Create -> Legacy
	    /// <summary>
	    /// Handler for Assets -> Create -> Legacy -> Cubemap.
	    /// </summary>
	    public void OnAssets_Create_Legacy_Cubemap()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Create_Legacy_Cubemap");
			// TODO: Implement MainMenuScript.OnAssets_Create_Legacy_Cubemap
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #endregion

	    /// <summary>
	    /// Handler for Assets -> Show In Explorer.
	    /// </summary>
	    public void OnAssets_ShowInExplorer()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ShowInExplorer");
			// TODO: Implement MainMenuScript.OnAssets_ShowInExplorer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Open.
	    /// </summary>
	    public void OnAssets_Open()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Open");
			// TODO: Implement MainMenuScript.OnAssets_Open
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Delete.
	    /// </summary>
	    public void OnAssets_Delete()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Delete");
			// TODO: Implement MainMenuScript.OnAssets_Delete
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import New Asset...
	    /// </summary>
	    public void OnAssets_ImportNewAsset()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportNewAsset");
			// TODO: Implement MainMenuScript.OnAssets_ImportNewAsset
			
			AppUtils.ShowContributeMessage();
	    }

	    #region Assets -> Import Package
	    /// <summary>
	    /// Handler for Assets -> Import Package -> Custom Package...
	    /// </summary>
	    public void OnAssets_ImportPackage_CustomPackage()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_CustomPackage");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_CustomPackage
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> 2D.
	    /// </summary>
	    public void OnAssets_ImportPackage_2d()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_2d");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Cameras.
	    /// </summary>
	    public void OnAssets_ImportPackage_Cameras()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Cameras");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Cameras
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Characters.
	    /// </summary>
	    public void OnAssets_ImportPackage_Characters()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Characters");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Characters
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> CrossPlatformInput.
	    /// </summary>
	    public void OnAssets_ImportPackage_CrossPlatformInput()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Effects.
	    /// </summary>
	    public void OnAssets_ImportPackage_Effects()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Effects");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Effects
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Environment.
	    /// </summary>
	    public void OnAssets_ImportPackage_Environment()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Environment");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Environment
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> ParticleSystems.
	    /// </summary>
	    public void OnAssets_ImportPackage_ParticleSystems()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_ParticleSystems");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_ParticleSystems
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Prototyping.
	    /// </summary>
	    public void OnAssets_ImportPackage_Prototyping()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Prototyping");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Prototyping
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Utility.
	    /// </summary>
	    public void OnAssets_ImportPackage_Utility()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Utility");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Utility
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Import Package -> Vehicles.
	    /// </summary>
	    public void OnAssets_ImportPackage_Vehicles()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Vehicles");
			// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Vehicles
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    /// <summary>
	    /// Handler for Assets -> Export Package...
	    /// </summary>
	    public void OnAssets_ExportPackage()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ExportPackage");
			// TODO: Implement MainMenuScript.OnAssets_ExportPackage
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Find References In Scene.
	    /// </summary>
	    public void OnAssets_FindReferencesInScene()
	    {
	        Debug.Log("MainMenuScript.OnAssets_FindReferencesInScene");
			// TODO: Implement MainMenuScript.OnAssets_FindReferencesInScene
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Select Dependencies.
	    /// </summary>
	    public void OnAssets_SelectDependencies()
	    {
	        Debug.Log("MainMenuScript.OnAssets_SelectDependencies");
			// TODO: Implement MainMenuScript.OnAssets_SelectDependencies
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Refresh.
	    /// </summary>
	    public void OnAssets_Refresh()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Refresh");
			// TODO: Implement MainMenuScript.OnAssets_Refresh
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Reimport.
	    /// </summary>
	    public void OnAssets_Reimport()
	    {
	        Debug.Log("MainMenuScript.OnAssets_Reimport");
			// TODO: Implement MainMenuScript.OnAssets_Reimport
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Reimport All.
	    /// </summary>
	    public void OnAssets_ReimportAll()
	    {
	        Debug.Log("MainMenuScript.OnAssets_ReimportAll");
			// TODO: Implement MainMenuScript.OnAssets_ReimportAll
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    /// <summary>
	    /// Handler for Assets -> Run API Updater...
	    /// </summary>
	    public void OnAssets_RunApiUpdater()
	    {
	        Debug.Log("MainMenuScript.OnAssets_RunApiUpdater");
			// TODO: Implement MainMenuScript.OnAssets_RunApiUpdater
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Assets -> Sync MonoDevelop Project.
	    /// </summary>
	    public void OnAssets_SyncMonoDevelopProject()
	    {
	        Debug.Log("MainMenuScript.OnAssets_SyncMonoDevelopProject");
			// TODO: Implement MainMenuScript.OnAssets_SyncMonoDevelopProject
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #region GameObject
	    /// <summary>
	    /// Handler for GameObject.
	    /// </summary>
	    public void OnGameObjectMenu()
	    {
	        OnShowMenuSubItems(mUi.gameObjectMenu);
	    }

	    /// <summary>
	    /// Handler for GameObject -> Create Empty.
	    /// </summary>
	    public void OnGameObject_CreateEmpty()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_CreateEmpty");
			// TODO: Implement MainMenuScript.OnGameObject_CreateEmpty
			
			AppUtils.ShowContributeMessage();
	    }
	        
	    /// <summary>
	    /// Handler for GameObject -> Create Empty Child.
	    /// </summary>
	    public void OnGameObject_CreateEmptyChild()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_CreateEmptyChild");
			// TODO: Implement MainMenuScript.OnGameObject_CreateEmptyChild
			
			AppUtils.ShowContributeMessage();
	    }
	            
	    #region GameObject -> 3D Object
	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Cube.
	    /// </summary>
	    public void OnGameObject_3dObject_Cube()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Cube");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Cube
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Sphere.
	    /// </summary>
	    public void OnGameObject_3dObject_Sphere()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Sphere");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Sphere
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Capsule.
	    /// </summary>
	    public void OnGameObject_3dObject_Capsule()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Capsule");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Capsule
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Cylinder.
	    /// </summary>
	    public void OnGameObject_3dObject_Cylinder()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Cylinder");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Cylinder
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Plane.
	    /// </summary>
	    public void OnGameObject_3dObject_Plane()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Plane");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Plane
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Quad.
	    /// </summary>
	    public void OnGameObject_3dObject_Quad()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Quad");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Quad
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Ragdoll...
	    /// </summary>
	    public void OnGameObject_3dObject_Ragdoll()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Ragdoll");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Ragdoll
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Terrain.
	    /// </summary>
	    public void OnGameObject_3dObject_Terrain()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Terrain");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Terrain
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Tree.
	    /// </summary>
	    public void OnGameObject_3dObject_Tree()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_Tree");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_Tree
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> Wind Zone.
	    /// </summary>
	    public void OnGameObject_3dObject_WindZone()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_WindZone");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_WindZone
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    /// <summary>
	    /// Handler for GameObject -> 3D Object -> 3D Text.
	    /// </summary>
	    public void OnGameObject_3dObject_3dText()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_3dObject_3dText");
			// TODO: Implement MainMenuScript.OnGameObject_3dObject_3dText
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region GameObject -> 2D Object    
	    /// <summary>
	    /// Handler for GameObject -> 2D Object -> Sprite.
	    /// </summary>
	    public void OnGameObject_2dObject_Sprite()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_2dObject_Sprite");
			// TODO: Implement MainMenuScript.OnGameObject_2dObject_Sprite
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region GameObject -> Light
	    /// <summary>
	    /// Handler for GameObject -> Light -> Directional Light.
	    /// </summary>
	    public void OnGameObject_Light_DirectionalLight()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Light_DirectionalLight");
			// TODO: Implement MainMenuScript.OnGameObject_Light_DirectionalLight
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Light -> Point Light.
	    /// </summary>
	    public void OnGameObject_Light_PointLight()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Light_PointLight");
			// TODO: Implement MainMenuScript.OnGameObject_Light_PointLight
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Light -> Spotlight.
	    /// </summary>
	    public void OnGameObject_Light_Spotlight()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Light_Spotlight");
			// TODO: Implement MainMenuScript.OnGameObject_Light_Spotlight
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Light -> Area Light.
	    /// </summary>
	    public void OnGameObject_Light_AreaLight()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Light_AreaLight");
			// TODO: Implement MainMenuScript.OnGameObject_Light_AreaLight
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Light -> Reflection Probe.
	    /// </summary>
	    public void OnGameObject_Light_ReflectionProbe()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Light_ReflectionProbe");
			// TODO: Implement MainMenuScript.OnGameObject_Light_ReflectionProbe
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Light -> Light Probe Group.
	    /// </summary>
	    public void OnGameObject_Light_LightProbeGroup()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Light_LightProbeGroup");
			// TODO: Implement MainMenuScript.OnGameObject_Light_LightProbeGroup
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region GameObject -> Audio
	    /// <summary>
	    /// Handler for GameObject -> Audio -> Audio Source.
	    /// </summary>
	    public void OnGameObject_Audio_AudioSource()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Audio_AudioSource");
			// TODO: Implement MainMenuScript.OnGameObject_Audio_AudioSource
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Audio -> Audio Reverb Zone.
	    /// </summary>
	    public void OnGameObject_Audio_AudioReverbZone()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Audio_AudioReverbZone");
			// TODO: Implement MainMenuScript.OnGameObject_Audio_AudioReverbZone
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region GameObject -> UI
	    /// <summary>
	    /// Handler for GameObject -> UI -> Panel.
	    /// </summary>
	    public void OnGameObject_Ui_Panel()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Panel");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Panel
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Button.
	    /// </summary>
	    public void OnGameObject_Ui_Button()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Button");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Button
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Text.
	    /// </summary>
	    public void OnGameObject_Ui_Text()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Text");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Text
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Image.
	    /// </summary>
	    public void OnGameObject_Ui_Image()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Image");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Image
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Raw Image.
	    /// </summary>
	    public void OnGameObject_Ui_RawImage()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_RawImage");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_RawImage
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Slider.
	    /// </summary>
	    public void OnGameObject_Ui_Slider()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Slider");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Slider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Scrollbar.
	    /// </summary>
	    public void OnGameObject_Ui_Scrollbar()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Scrollbar");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Scrollbar
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Toggle.
	    /// </summary>
	    public void OnGameObject_Ui_Toggle()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Toggle");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Toggle
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Input Field.
	    /// </summary>
	    public void OnGameObject_Ui_InputField()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_InputField");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_InputField
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Canvas.
	    /// </summary>
	    public void OnGameObject_Ui_Canvas()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_Canvas");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_Canvas
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> UI -> Event System.
	    /// </summary>
	    public void OnGameObject_Ui_EventSystem()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Ui_EventSystem");
			// TODO: Implement MainMenuScript.OnGameObject_Ui_EventSystem
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    /// <summary>
	    /// Handler for GameObject -> Particle System.
	    /// </summary>
	    public void OnGameObject_ParticleSystem()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_ParticleSystem");
			// TODO: Implement MainMenuScript.OnGameObject_ParticleSystem
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Camera.
	    /// </summary>
	    public void OnGameObject_Camera()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_Camera");
			// TODO: Implement MainMenuScript.OnGameObject_Camera
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Center On Children.
	    /// </summary>
	    public void OnGameObject_CenterOnChildren()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_CenterOnChildren");
			// TODO: Implement MainMenuScript.OnGameObject_CenterOnChildren
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Make Parent.
	    /// </summary>
	    public void OnGameObject_MakeParent()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_MakeParent");
			// TODO: Implement MainMenuScript.OnGameObject_MakeParent
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Clear Parent.
	    /// </summary>
	    public void OnGameObject_ClearParent()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_ClearParent");
			// TODO: Implement MainMenuScript.OnGameObject_ClearParent
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Apply Changes To Prefab.
	    /// </summary>
	    public void OnGameObject_ApplyChangesToPrefab()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_ApplyChangesToPrefab");
			// TODO: Implement MainMenuScript.OnGameObject_ApplyChangesToPrefab
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Break Prefab Instance.
	    /// </summary>
	    public void OnGameObject_BreakPrefabInstance()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_BreakPrefabInstance");
			// TODO: Implement MainMenuScript.OnGameObject_BreakPrefabInstance
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Set as first sibling.
	    /// </summary>
	    public void OnGameObject_SetAsFirstSibling()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_SetAsFirstSibling");
			// TODO: Implement MainMenuScript.OnGameObject_SetAsFirstSibling
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Set as last sibling.
	    /// </summary>
	    public void OnGameObject_SetAsLastSibling()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_SetAsLastSibling");
			// TODO: Implement MainMenuScript.OnGameObject_SetAsLastSibling
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Move To View.
	    /// </summary>
	    public void OnGameObject_MoveToView()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_MoveToView");
			// TODO: Implement MainMenuScript.OnGameObject_MoveToView
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Align With View.
	    /// </summary>
	    public void OnGameObject_AlignWithView()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_AlignWithView");
			// TODO: Implement MainMenuScript.OnGameObject_AlignWithView
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Align View to Selected.
	    /// </summary>
	    public void OnGameObject_AlignViewToSelected()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_AlignViewToSelected");
			// TODO: Implement MainMenuScript.OnGameObject_AlignViewToSelected
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for GameObject -> Toggle Active State.
	    /// </summary>
	    public void OnGameObject_ToggleActiveState()
	    {
	        Debug.Log("MainMenuScript.OnGameObject_ToggleActiveState");
			// TODO: Implement MainMenuScript.OnGameObject_ToggleActiveState
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component
	    /// <summary>
	    /// Handler for Component.
	    /// </summary>
	    public void OnComponentMenu()
	    {
	        OnShowMenuSubItems(mUi.componentMenu);
	    }

	    /// <summary>
	    /// Handler for Component -> Add...
	    /// </summary>
	    public void OnComponent_Add()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Add");
			// TODO: Implement MainMenuScript.OnComponent_Add
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    #region Component -> Mesh
	    /// <summary>
	    /// Handler for Component -> Mesh -> Mesh Filter.
	    /// </summary>
	    public void OnComponent_Mesh_MeshFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Mesh_MeshFilter");
			// TODO: Implement MainMenuScript.OnComponent_Mesh_MeshFilter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Mesh -> Text Mesh.
	    /// </summary>
	    public void OnComponent_Mesh_TextMesh()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Mesh_TextMesh");
			// TODO: Implement MainMenuScript.OnComponent_Mesh_TextMesh
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Mesh -> Mesh Renderer.
	    /// </summary>
	    public void OnComponent_Mesh_MeshRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Mesh_MeshRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Mesh_MeshRenderer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Mesh -> Skinned Mesh Renderer.
	    /// </summary>
	    public void OnComponent_Mesh_SkinnedMeshRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Effects
	    /// <summary>
	    /// Handler for Component -> Effects -> Particle System.
	    /// </summary>
	    public void OnComponent_Effects_ParticleSystem()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_ParticleSystem");
			// TODO: Implement MainMenuScript.OnComponent_Effects_ParticleSystem
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Trail Renderer.
	    /// </summary>
	    public void OnComponent_Effects_TrailRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_TrailRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Effects_TrailRenderer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Line Renderer.
	    /// </summary>
	    public void OnComponent_Effects_LineRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LineRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LineRenderer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Lens Flare.
	    /// </summary>
	    public void OnComponent_Effects_LensFlare()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LensFlare");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LensFlare
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Halo.
	    /// </summary>
	    public void OnComponent_Effects_Halo()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_Halo");
			// TODO: Implement MainMenuScript.OnComponent_Effects_Halo
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Projector.
	    /// </summary>
	    public void OnComponent_Effects_Projector()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_Projector");
	        // TODO: Implement MainMenuScript.OnComponent_Effects_Projector

			AppUtils.ShowContributeMessage();
	    }
	    
	    #region Component -> Effects -> Legacy Particles
	    /// <summary>
	    /// Handler for Component -> Effects -> Legacy Particles -> Ellipsoid Particle Emitter.
	    /// </summary>
	    public void OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Legacy Particles -> Mesh Particle Emitter.
	    /// </summary>
	    public void OnComponent_Effects_LegacyParticles_MeshParticleEmitter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Legacy Particles -> Particle Animator.
	    /// </summary>
	    public void OnComponent_Effects_LegacyParticles_ParticleAnimator()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Legacy Particles -> World Particle Collider.
	    /// </summary>
	    public void OnComponent_Effects_LegacyParticles_WorldParticleCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Effects -> Legacy Particles -> Particle Renderer.
	    /// </summary>
	    public void OnComponent_Effects_LegacyParticles_ParticleRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #endregion
	    
	    #region Component -> Physics
	    /// <summary>
	    /// Handler for Component -> Physics -> Rigidbody.
	    /// </summary>
	    public void OnComponent_Physics_Rigidbody()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_Rigidbody");
			// TODO: Implement MainMenuScript.OnComponent_Physics_Rigidbody
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Character Controller.
	    /// </summary>
	    public void OnComponent_Physics_CharacterController()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_CharacterController");
			// TODO: Implement MainMenuScript.OnComponent_Physics_CharacterController
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Box Collider.
	    /// </summary>
	    public void OnComponent_Physics_BoxCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_BoxCollider");
			// TODO: Implement MainMenuScript.OnComponent_Physics_BoxCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Sphere Collider.
	    /// </summary>
	    public void OnComponent_Physics_SphereCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_SphereCollider");
			// TODO: Implement MainMenuScript.OnComponent_Physics_SphereCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Capsule Collider.
	    /// </summary>
	    public void OnComponent_Physics_CapsuleCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_CapsuleCollider");
			// TODO: Implement MainMenuScript.OnComponent_Physics_CapsuleCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Mesh Collider.
	    /// </summary>
	    public void OnComponent_Physics_MeshCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_MeshCollider");
			// TODO: Implement MainMenuScript.OnComponent_Physics_MeshCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Wheel Collider.
	    /// </summary>
	    public void OnComponent_Physics_WheelCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_WheelCollider");
			// TODO: Implement MainMenuScript.OnComponent_Physics_WheelCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Terrain Collider.
	    /// </summary>
	    public void OnComponent_Physics_TerrainCollider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_TerrainCollider");
			// TODO: Implement MainMenuScript.OnComponent_Physics_TerrainCollider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Cloth.
	    /// </summary>
	    public void OnComponent_Physics_Cloth()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_Cloth");
			// TODO: Implement MainMenuScript.OnComponent_Physics_Cloth
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Hinge Joint.
	    /// </summary>
	    public void OnComponent_Physics_HingeJoint()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_HingeJoint");
			// TODO: Implement MainMenuScript.OnComponent_Physics_HingeJoint
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Fixed Joint.
	    /// </summary>
	    public void OnComponent_Physics_FixedJoint()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_FixedJoint");
			// TODO: Implement MainMenuScript.OnComponent_Physics_FixedJoint
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Spring Joint.
	    /// </summary>
	    public void OnComponent_Physics_SpringJoint()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_SpringJoint");
			// TODO: Implement MainMenuScript.OnComponent_Physics_SpringJoint
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Character Joint.
	    /// </summary>
	    public void OnComponent_Physics_CharacterJoint()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_CharacterJoint");
			// TODO: Implement MainMenuScript.OnComponent_Physics_CharacterJoint
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Configurable Joint.
	    /// </summary>
	    public void OnComponent_Physics_ConfigurableJoint()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_ConfigurableJoint");
			// TODO: Implement MainMenuScript.OnComponent_Physics_ConfigurableJoint
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics -> Constant Force.
	    /// </summary>
	    public void OnComponent_Physics_ConstantForce()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics_ConstantForce");
	        // TODO: Implement MainMenuScript.OnComponent_Physics_ConstantForce			
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Physics 2D
	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Rigidbody 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_Rigidbody2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_Rigidbody2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_Rigidbody2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Circle Collider 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_CircleCollider2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_CircleCollider2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_CircleCollider2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Box Collider 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_BoxCollider2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_BoxCollider2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_BoxCollider2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Edge Collider 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_EdgeCollider2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_EdgeCollider2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_EdgeCollider2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Polygon Collider 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_PolygonCollider2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_PolygonCollider2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_PolygonCollider2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Spring Joint 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_SpringJoint2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_SpringJoint2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_SpringJoint2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Distance Joint 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_DistanceJoint2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_DistanceJoint2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_DistanceJoint2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Hinge Joint 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_HingeJoint2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_HingeJoint2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_HingeJoint2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Slider Joint 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_SliderJoint2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_SliderJoint2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_SliderJoint2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Wheel Joint 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_WheelJoint2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_WheelJoint2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_WheelJoint2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Constant Force 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_ConstantForce2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_ConstantForce2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_ConstantForce2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Area Effector 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_AreaEffector2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_AreaEffector2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_AreaEffector2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Point Effector 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_PointEffector2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_PointEffector2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_PointEffector2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Platform Effector 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_PlatformEffector2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_PlatformEffector2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_PlatformEffector2d
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Physics 2D -> Surface Effector 2D.
	    /// </summary>
	    public void OnComponent_Physics2d_SurfaceEffector2d()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d");
			// TODO: Implement MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Navigation
	    /// <summary>
	    /// Handler for Component -> Navigation -> Nav Mesh Agent.
	    /// </summary>
	    public void OnComponent_Navigation_NavMeshAgent()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Navigation_NavMeshAgent");
			// TODO: Implement MainMenuScript.OnComponent_Navigation_NavMeshAgent
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Navigation -> Off Mesh Link.
	    /// </summary>
	    public void OnComponent_Navigation_OffMeshLink()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Navigation_OffMeshLink");
			// TODO: Implement MainMenuScript.OnComponent_Navigation_OffMeshLink
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Navigation -> Nav Mesh Obstacle.
	    /// </summary>
	    public void OnComponent_Navigation_NavMeshObstacle()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Navigation_NavMeshObstacle");
			// TODO: Implement MainMenuScript.OnComponent_Navigation_NavMeshObstacle
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Audio
	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Listener.
	    /// </summary>
	    public void OnComponent_Audio_AudioListener()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioListener");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioListener
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Source.
	    /// </summary>
	    public void OnComponent_Audio_AudioSource()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioSource");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioSource
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Reverb Zone.
	    /// </summary>
	    public void OnComponent_Audio_AudioReverbZone()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioReverbZone");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioReverbZone
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Low Pass Filter.
	    /// </summary>
	    public void OnComponent_Audio_AudioLowPassFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioLowPassFilter");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioLowPassFilter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio High Pass Filter.
	    /// </summary>
	    public void OnComponent_Audio_AudioHighPassFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioHighPassFilter");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioHighPassFilter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Echo Filter.
	    /// </summary>
	    public void OnComponent_Audio_AudioEchoFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioEchoFilter");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioEchoFilter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Distortion Filter.
	    /// </summary>
	    public void OnComponent_Audio_AudioDistortionFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioDistortionFilter");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioDistortionFilter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Reverb Filter.
	    /// </summary>
	    public void OnComponent_Audio_AudioReverbFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioReverbFilter");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioReverbFilter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Audio -> Audio Chorus Filter.
	    /// </summary>
	    public void OnComponent_Audio_AudioChorusFilter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Audio_AudioChorusFilter");
			// TODO: Implement MainMenuScript.OnComponent_Audio_AudioChorusFilter
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Rendering
	    /// <summary>
	    /// Handler for Component -> Rendering -> Camera.
	    /// </summary>
	    public void OnComponent_Rendering_Camera()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_Camera");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_Camera
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Skybox.
	    /// </summary>
	    public void OnComponent_Rendering_Skybox()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_Skybox");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_Skybox
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Flare Layer.
	    /// </summary>
	    public void OnComponent_Rendering_FlareLayer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_FlareLayer");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_FlareLayer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> GUI Layer.
	    /// </summary>
	    public void OnComponent_Rendering_GuiLayer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_GuiLayer");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_GuiLayer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Light.
	    /// </summary>
	    public void OnComponent_Rendering_Light()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_Light");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_Light
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Light Probe Group.
	    /// </summary>
	    public void OnComponent_Rendering_LightProbeGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_LightProbeGroup");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_LightProbeGroup
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Reflection Probe.
	    /// </summary>
	    public void OnComponent_Rendering_ReflectionProbe()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_ReflectionProbe");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_ReflectionProbe
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Occlusion Area.
	    /// </summary>
	    public void OnComponent_Rendering_OcclusionArea()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_OcclusionArea");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_OcclusionArea
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Occlusion Portal.
	    /// </summary>
	    public void OnComponent_Rendering_OcclusionPortal()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_OcclusionPortal");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_OcclusionPortal
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> LOD Group.
	    /// </summary>
	    public void OnComponent_Rendering_LodGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_LodGroup");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_LodGroup
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Sprite Renderer.
	    /// </summary>
	    public void OnComponent_Rendering_SpriteRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_SpriteRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_SpriteRenderer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> Canvas Renderer.
	    /// </summary>
	    public void OnComponent_Rendering_CanvasRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_CanvasRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_CanvasRenderer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> GUI Texture.
	    /// </summary>
	    public void OnComponent_Rendering_GuiTexture()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_GuiTexture");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_GuiTexture
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Rendering -> GUI Text.
	    /// </summary>
	    public void OnComponent_Rendering_GuiText()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Rendering_GuiText");
			// TODO: Implement MainMenuScript.OnComponent_Rendering_GuiText
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Layout
	    /// <summary>
	    /// Handler for Component -> Layout -> Rect Transform.
	    /// </summary>
	    public void OnComponent_Layout_RectTransform()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_RectTransform");
			// TODO: Implement MainMenuScript.OnComponent_Layout_RectTransform
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Canvas.
	    /// </summary>
	    public void OnComponent_Layout_Canvas()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_Canvas");
			// TODO: Implement MainMenuScript.OnComponent_Layout_Canvas
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Canvas Group.
	    /// </summary>
	    public void OnComponent_Layout_CanvasGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_CanvasGroup");
			// TODO: Implement MainMenuScript.OnComponent_Layout_CanvasGroup
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Canvas Scaler.
	    /// </summary>
	    public void OnComponent_Layout_CanvasScaler()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_CanvasScaler");
			// TODO: Implement MainMenuScript.OnComponent_Layout_CanvasScaler
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Layout Element.
	    /// </summary>
	    public void OnComponent_Layout_LayoutElement()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_LayoutElement");
			// TODO: Implement MainMenuScript.OnComponent_Layout_LayoutElement
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Content Size Fitter.
	    /// </summary>
	    public void OnComponent_Layout_ContentSizeFitter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_ContentSizeFitter");
			// TODO: Implement MainMenuScript.OnComponent_Layout_ContentSizeFitter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Aspect Ratio Fitter.
	    /// </summary>
	    public void OnComponent_Layout_AspectRatioFitter()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_AspectRatioFitter");
			// TODO: Implement MainMenuScript.OnComponent_Layout_AspectRatioFitter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Horizontal Layout Group.
	    /// </summary>
	    public void OnComponent_Layout_HorizontalLayoutGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup");
			// TODO: Implement MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Vertical Layout Group.
	    /// </summary>
	    public void OnComponent_Layout_VerticalLayoutGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_VerticalLayoutGroup");
			// TODO: Implement MainMenuScript.OnComponent_Layout_VerticalLayoutGroup
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Layout -> Grid Layout Group.
	    /// </summary>
	    public void OnComponent_Layout_GridLayoutGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Layout_GridLayoutGroup");
			// TODO: Implement MainMenuScript.OnComponent_Layout_GridLayoutGroup
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Miscellaneous
	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Animator.
	    /// </summary>
	    public void OnComponent_Miscellaneous_Animator()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Animator");
			// TODO: Implement MainMenuScript.OnComponent_Miscellaneous_Animator
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Animation.
	    /// </summary>
	    public void OnComponent_Miscellaneous_Animation()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Animation");
			// TODO: Implement MainMenuScript.OnComponent_Miscellaneous_Animation
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Network View.
	    /// </summary>
	    public void OnComponent_Miscellaneous_NetworkView()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_NetworkView");
			// TODO: Implement MainMenuScript.OnComponent_Miscellaneous_NetworkView
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Wind Zone.
	    /// </summary>
	    public void OnComponent_Miscellaneous_WindZone()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_WindZone");
			// TODO: Implement MainMenuScript.OnComponent_Miscellaneous_WindZone
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Terrain.
	    /// </summary>
	    public void OnComponent_Miscellaneous_Terrain()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Terrain");
			// TODO: Implement MainMenuScript.OnComponent_Miscellaneous_Terrain
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Billboard Renderer.
	    /// </summary>
	    public void OnComponent_Miscellaneous_BillboardRenderer()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer");
			// TODO: Implement MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> Event
	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Event System.
	    /// </summary>
	    public void OnComponent_Event_EventSystem()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_EventSystem");
			// TODO: Implement MainMenuScript.OnComponent_Event_EventSystem
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Event Trigger.
	    /// </summary>
	    public void OnComponent_Event_EventTrigger()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_EventTrigger");
			// TODO: Implement MainMenuScript.OnComponent_Event_EventTrigger
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Physics 2D Raycaster.
	    /// </summary>
	    public void OnComponent_Event_Physics2dRaycaster()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_Physics2dRaycaster");
			// TODO: Implement MainMenuScript.OnComponent_Event_Physics2dRaycaster
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Physics Raycaster.
	    /// </summary>
	    public void OnComponent_Event_PhysicsRaycaster()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_PhysicsRaycaster");
			// TODO: Implement MainMenuScript.OnComponent_Event_PhysicsRaycaster
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Standalone Input Module.
	    /// </summary>
	    public void OnComponent_Event_StandaloneInputModule()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_StandaloneInputModule");
			// TODO: Implement MainMenuScript.OnComponent_Event_StandaloneInputModule
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Touch Input Module.
	    /// </summary>
	    public void OnComponent_Event_TouchInputModule()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_TouchInputModule");
			// TODO: Implement MainMenuScript.OnComponent_Event_TouchInputModule
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> Miscellaneous -> Graphic Raycaster.
	    /// </summary>
	    public void OnComponent_Event_GraphicRaycaster()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Event_GraphicRaycaster");
			// TODO: Implement MainMenuScript.OnComponent_Event_GraphicRaycaster
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Component -> UI
	    
	    #region Component -> UI -> Effects
	    /// <summary>
	    /// Handler for Component -> UI -> Effects -> Shadow.
	    /// </summary>
	    public void OnComponent_Ui_Effects_Shadow()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Effects_Shadow");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Effects_Shadow
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Effects -> Outline.
	    /// </summary>
	    public void OnComponent_Ui_Effects_Outline()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Effects_Outline");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Effects_Outline
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Effects -> Position As UV1.
	    /// </summary>
	    public void OnComponent_Ui_Effects_PositionAsUv1()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    /// <summary>
	    /// Handler for Component -> UI -> Image.
	    /// </summary>
	    public void OnComponent_Ui_Image()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Image");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Image
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Text.
	    /// </summary>
	    public void OnComponent_Ui_Text()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Text");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Text
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Raw Image.
	    /// </summary>
	    public void OnComponent_Ui_RawImage()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_RawImage");
			// TODO: Implement MainMenuScript.OnComponent_Ui_RawImage
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Mask.
	    /// </summary>
	    public void OnComponent_Ui_Mask()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Mask");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Mask
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Button.
	    /// </summary>
	    public void OnComponent_Ui_Button()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Button");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Button
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Input Field.
	    /// </summary>
	    public void OnComponent_Ui_InputField()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_InputField");
			// TODO: Implement MainMenuScript.OnComponent_Ui_InputField
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Scrollbar.
	    /// </summary>
	    public void OnComponent_Ui_Scrollbar()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Scrollbar");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Scrollbar
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Scroll Rect.
	    /// </summary>
	    public void OnComponent_Ui_ScrollRect()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_ScrollRect");
			// TODO: Implement MainMenuScript.OnComponent_Ui_ScrollRect
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Slider.
	    /// </summary>
	    public void OnComponent_Ui_Slider()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Slider");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Slider
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Toggle.
	    /// </summary>
	    public void OnComponent_Ui_Toggle()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Toggle");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Toggle
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Toggle Group.
	    /// </summary>
	    public void OnComponent_Ui_ToggleGroup()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_ToggleGroup");
			// TODO: Implement MainMenuScript.OnComponent_Ui_ToggleGroup
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Component -> UI -> Selectable.
	    /// </summary>
	    public void OnComponent_Ui_Selectable()
	    {
	        Debug.Log("MainMenuScript.OnComponent_Ui_Selectable");
			// TODO: Implement MainMenuScript.OnComponent_Ui_Selectable
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #endregion
	    
	    #region Window
	    /// <summary>
	    /// Handler for Window.
	    /// </summary>
	    public void OnWindowMenu()
	    {
	        OnShowMenuSubItems(mUi.windowMenu);
	    }

	    /// <summary>
	    /// Handler for Window -> Next Window.
	    /// </summary>
	    public void OnWindow_NextWindow()
	    {
			Debug.Log("MainMenuScript.OnWindow_NextWindow");
			// TODO: Implement MainMenuScript.OnWindow_NextWindow
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Previous Window.
	    /// </summary>
	    public void OnWindow_PreviousWindow()
	    {
			Debug.Log("MainMenuScript.OnWindow_PreviousWindow");
			// TODO: Implement MainMenuScript.OnWindow_PreviousWindow
			
			AppUtils.ShowContributeMessage();
	    }
	    
	    #region Window -> Layouts
	    /// <summary>
	    /// Handler for Window -> Layouts -> 2 by 3.
	    /// </summary>
	    public void OnWindow_Layouts_2_by_3()
	    {
			Debug.Log("MainMenuScript.OnWindow_Layouts_2_by_3");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_2_by_3
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> 4 Split.
	    /// </summary>
	    public void OnWindow_Layouts_4_split()
	    {
			Debug.Log("MainMenuScript.OnWindow_Layouts_4_split");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_4_split
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> Default.
	    /// </summary>
	    public void OnWindow_Layouts_Default()
	    {
			Debug.Log("MainMenuScript.OnWindow_Layouts_Default");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_Default
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> Tall.
	    /// </summary>
	    public void OnWindow_Layouts_Tall()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Layouts_Tall");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_Tall
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> Wide.
	    /// </summary>
	    public void OnWindow_Layouts_Wide()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Layouts_Wide");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_Wide
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> Save Layout.
	    /// </summary>
	    public void OnWindow_Layouts_SaveLayout()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Layouts_SaveLayout");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_SaveLayout
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> Delete Layout.
	    /// </summary>
	    public void OnWindow_Layouts_DeleteLayout()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Layouts_DeleteLayout");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_DeleteLayout
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Layouts -> Revert Factory Settings.
	    /// </summary>
	    public void OnWindow_Layouts_RevertFactorySettings()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Layouts_RevertFactorySettings");
			// TODO: Implement MainMenuScript.OnWindow_Layouts_RevertFactorySettings
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

		#region Window -> Screenshot
		/// <summary>
		/// Handler for Window -> Screenshot -> Set Window Size.
		/// </summary>
		public void OnWindow_Screenshot_SetWindowSize()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SetWindowSize");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SetWindowSize
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Set Window Size Small.
		/// </summary>
		public void OnWindow_Screenshot_SetWindowSizeSmall()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Snap View.
		/// </summary>
		public void OnWindow_Screenshot_SnapView()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapView");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SnapView
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Snap View Toolbar.
		/// </summary>
		public void OnWindow_Screenshot_SnapViewToolbar()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapViewToolbar");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SnapViewToolbar
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Snap View Extended Right.
		/// </summary>
		public void OnWindow_Screenshot_SnapViewExtendedRight()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapViewExtendedRight");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SnapViewExtendedRight
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Snap Component.
		/// </summary>
		public void OnWindow_Screenshot_SnapComponent()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapComponent");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SnapComponent
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Snap Game View Content.
		/// </summary>
		public void OnWindow_Screenshot_SnapGameViewContent()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapGameViewContent");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_SnapGameViewContent
			
			AppUtils.ShowContributeMessage();
		}

		/// <summary>
		/// Handler for Window -> Screenshot -> Toggle DeveloperBuild.
		/// </summary>
		public void OnWindow_Screenshot_ToggleDeveloperBuild()
		{
			Debug.Log("MainMenuScript.OnWindow_Screenshot_ToggleDeveloperBuild");
			// TODO: Implement MainMenuScript.OnWindow_Screenshot_ToggleDeveloperBuild
			
			AppUtils.ShowContributeMessage();
		}
		#endregion

	    /// <summary>
	    /// Handler for Window -> Scene.
	    /// </summary>
	    public void OnWindow_Scene()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Scene");
			// TODO: Implement MainMenuScript.OnWindow_Scene
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Game.
	    /// </summary>
	    public void OnWindow_Game()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Game");
			// TODO: Implement MainMenuScript.OnWindow_Game
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Inspector.
	    /// </summary>
	    public void OnWindow_Inspector()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Inspector");
			// TODO: Implement MainMenuScript.OnWindow_Inspector
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Hierarchy.
	    /// </summary>
	    public void OnWindow_Hierarchy()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Hierarchy");
			// TODO: Implement MainMenuScript.OnWindow_Hierarchy
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Project.
	    /// </summary>
	    public void OnWindow_Project()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Project");
			// TODO: Implement MainMenuScript.OnWindow_Project
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Animation.
	    /// </summary>
	    public void OnWindow_Animation()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Animation");
			// TODO: Implement MainMenuScript.OnWindow_Animation
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Profiler.
	    /// </summary>
	    public void OnWindow_Profiler()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Profiler");
			// TODO: Implement MainMenuScript.OnWindow_Profiler
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Audio Mixer.
	    /// </summary>
	    public void OnWindow_AudioMixer()
	    {
	        Debug.Log("MainMenuScript.OnWindow_AudioMixer");
			// TODO: Implement MainMenuScript.OnWindow_AudioMixer
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Asset Store.
	    /// </summary>
	    public void OnWindow_AssetStore()
	    {
	        Debug.Log("MainMenuScript.OnWindow_AssetStore");
			// TODO: Implement MainMenuScript.OnWindow_AssetStore
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Version Control.
	    /// </summary>
	    public void OnWindow_VersionControl()
	    {
	        Debug.Log("MainMenuScript.OnWindow_VersionControl");
			// TODO: Implement MainMenuScript.OnWindow_VersionControl
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Animator Parameter.
	    /// </summary>
	    public void OnWindow_AnimatorParameter()
	    {
	        Debug.Log("MainMenuScript.OnWindow_AnimatorParameter");
			// TODO: Implement MainMenuScript.OnWindow_AnimatorParameter
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Animator.
	    /// </summary>
	    public void OnWindow_Animator()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Animator");
			// TODO: Implement MainMenuScript.OnWindow_Animator
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Sprite Packer.
	    /// </summary>
	    public void OnWindow_SpritePacker()
	    {
	        Debug.Log("MainMenuScript.OnWindow_SpritePacker");
			// TODO: Implement MainMenuScript.OnWindow_SpritePacker
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Lighting.
	    /// </summary>
	    public void OnWindow_Lighting()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Lighting");
			// TODO: Implement MainMenuScript.OnWindow_Lighting
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Occlusion Culling.
	    /// </summary>
	    public void OnWindow_OcclusionCulling()
	    {
	        Debug.Log("MainMenuScript.OnWindow_OcclusionCulling");
			// TODO: Implement MainMenuScript.OnWindow_OcclusionCulling
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Frame Debugger.
	    /// </summary>
	    public void OnWindow_FrameDebugger()
	    {
	        Debug.Log("MainMenuScript.OnWindow_FrameDebugger");
			// TODO: Implement MainMenuScript.OnWindow_FrameDebugger
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Navigation.
	    /// </summary>
	    public void OnWindow_Navigation()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Navigation");
			// TODO: Implement MainMenuScript.OnWindow_Navigation
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Window -> Console.
	    /// </summary>
	    public void OnWindow_Console()
	    {
	        Debug.Log("MainMenuScript.OnWindow_Console");
			// TODO: Implement MainMenuScript.OnWindow_Console
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion
	    
	    #region Help
	    /// <summary>
	    /// Handler for Help.
	    /// </summary>
	    public void OnHelpMenu()
	    {
	        OnShowMenuSubItems(mUi.helpMenu);
	    }

	    /// <summary>
	    /// Handler for Help -> About Unity...
	    /// </summary>
	    public void OnHelp_AboutUnity()
	    {
			AboutDialogScript.Create().Show();
	    }

	    /// <summary>
	    /// Handler for Help -> Manage License...
	    /// </summary>
	    public void OnHelp_ManageLicense()
	    {
			Debug.Log("MainMenuScript.OnHelp_ManageLicense");
			// TODO: Implement MainMenuScript.OnHelp_ManageLicense
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Unity Manual.
	    /// </summary>
	    public void OnHelp_UnityManual()
	    {
			Debug.Log("MainMenuScript.OnHelp_UnityManual");
			// TODO: Implement MainMenuScript.OnHelp_UnityManual
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Scripting Reference.
	    /// </summary>
	    public void OnHelp_ScriptingReference()
	    {
			Debug.Log("MainMenuScript.OnHelp_ScriptingReference");
			// TODO: Implement MainMenuScript.OnHelp_ScriptingReference
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Unity Connect.
	    /// </summary>
	    public void OnHelp_UnityConnect()
	    {
			Debug.Log("MainMenuScript.OnHelp_UnityConnect");
			// TODO: Implement MainMenuScript.OnHelp_UnityConnect
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Unity Forum.
	    /// </summary>
	    public void OnHelp_UnityForum()
	    {
			Debug.Log("MainMenuScript.OnHelp_UnityForum");
			// TODO: Implement MainMenuScript.OnHelp_UnityForum
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Unity Answers.
	    /// </summary>
	    public void OnHelp_UnityAnswers()
	    {
			Debug.Log("MainMenuScript.OnHelp_UnityAnswers");
			// TODO: Implement MainMenuScript.OnHelp_UnityAnswers
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Unity Feedback.
	    /// </summary>
	    public void OnHelp_UnityFeedback()
	    {
			Debug.Log("MainMenuScript.OnHelp_UnityFeedback");
			// TODO: Implement MainMenuScript.OnHelp_UnityFeedback
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Check for Updates.
	    /// </summary>    
	    public void OnHelp_CheckForUpdates()
	    {
			Debug.Log("MainMenuScript.OnHelp_CheckForUpdates");
			// TODO: Implement MainMenuScript.OnHelp_CheckForUpdates
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Download Beta...
	    /// </summary>
	    public void OnHelp_DownloadBeta()
	    {
			Debug.Log("MainMenuScript.OnHelp_DownloadBeta");
			// TODO: Implement MainMenuScript.OnHelp_DownloadBeta
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Release Notes.
	    /// </summary>
	    public void OnHelp_ReleaseNotes()
	    {
			Debug.Log("MainMenuScript.OnHelp_ReleaseNotes");
			// TODO: Implement MainMenuScript.OnHelp_ReleaseNotes
			
			AppUtils.ShowContributeMessage();
	    }

	    /// <summary>
	    /// Handler for Help -> Report a Bug...
	    /// </summary>
	    public void OnHelp_ReportABug()
	    {
			Debug.Log("MainMenuScript.OnHelp_ReportABug");
			// TODO: Implement MainMenuScript.OnHelp_ReportABug
			
			AppUtils.ShowContributeMessage();
	    }
	    #endregion

	    #endregion
	}
}
