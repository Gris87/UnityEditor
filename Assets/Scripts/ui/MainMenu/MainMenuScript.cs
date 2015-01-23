using UnityEngine;
using UnityEngine.UI;

using common;
using common.ui;



/// <summary>
/// Script that realize main menu behaviour.
/// </summary>
public class MainMenuScript : MonoBehaviour
{
	/// <summary>
	/// Menu item button prefab.
	/// </summary>
    public Button menuButton = null;



	#region Menu items
	private TreeNode<MenuItem> mItems = null;

	#region File
	private TreeNode<MenuItem> mFileMenu          = null;

//	private TreeNode<MenuItem> mNewSceneItem      = null;
//	private TreeNode<MenuItem> mOpenSceneItem     = null;

//	private TreeNode<MenuItem> mSaveSceneItem     = null;
//	private TreeNode<MenuItem> mSaveSceneAsItem   = null;

//	private TreeNode<MenuItem> mNewProjectItem    = null;
//	private TreeNode<MenuItem> mOpenProjectItem   = null;
//	private TreeNode<MenuItem> mSaveProjectItem   = null;

//	private TreeNode<MenuItem> mBuildSettingsItem = null;
//	private TreeNode<MenuItem> mBuildAndRunItem   = null;

//	private TreeNode<MenuItem> mExitItem          = null;
	#endregion

	#region Edit
	private TreeNode<MenuItem> mEditMenu               = null;

//	private TreeNode<MenuItem> mUndoItem               = null;
//	private TreeNode<MenuItem> mRedoItem               = null;

//	private TreeNode<MenuItem> mCutItem                = null;
//	private TreeNode<MenuItem> mCopyItem               = null;
//	private TreeNode<MenuItem> mPasteItem              = null;

//	private TreeNode<MenuItem> mDuplicateItem          = null;
//	private TreeNode<MenuItem> mDeleteItem             = null;

//	private TreeNode<MenuItem> mFrameSelectedItem      = null;
//	private TreeNode<MenuItem> mLockViewToSelectedItem = null;
//	private TreeNode<MenuItem> mFindItem               = null;
//	private TreeNode<MenuItem> mSelectAllItem          = null;

//	private TreeNode<MenuItem> mPreferencesItem        = null;
//	private TreeNode<MenuItem> mModulesItem            = null;

//	private TreeNode<MenuItem> mPlayItem               = null;
//	private TreeNode<MenuItem> mPauseItem              = null;
//	private TreeNode<MenuItem> mStepItem               = null;

	#region Edit->Selection
	private TreeNode<MenuItem> mSelectionItem      = null;

//	private TreeNode<MenuItem> mLoadSelection1Item = null;
//	private TreeNode<MenuItem> mLoadSelection2Item = null;
//	private TreeNode<MenuItem> mLoadSelection3Item = null;
//	private TreeNode<MenuItem> mLoadSelection4Item = null;
//	private TreeNode<MenuItem> mLoadSelection5Item = null;
//	private TreeNode<MenuItem> mLoadSelection6Item = null;
//	private TreeNode<MenuItem> mLoadSelection7Item = null;
//	private TreeNode<MenuItem> mLoadSelection8Item = null;
//	private TreeNode<MenuItem> mLoadSelection9Item = null;
//	private TreeNode<MenuItem> mLoadSelection0Item = null;

//	private TreeNode<MenuItem> mSaveSelection1Item = null;
//	private TreeNode<MenuItem> mSaveSelection2Item = null;
//	private TreeNode<MenuItem> mSaveSelection3Item = null;
//	private TreeNode<MenuItem> mSaveSelection4Item = null;
//	private TreeNode<MenuItem> mSaveSelection5Item = null;
//	private TreeNode<MenuItem> mSaveSelection6Item = null;
//	private TreeNode<MenuItem> mSaveSelection7Item = null;
//	private TreeNode<MenuItem> mSaveSelection8Item = null;
//	private TreeNode<MenuItem> mSaveSelection9Item = null;
//	private TreeNode<MenuItem> mSaveSelection0Item = null;
	#endregion

	#region Edit->Project Settings
	private TreeNode<MenuItem> mProjectSettingsItem      = null;

//	private TreeNode<MenuItem> mInputItem                = null;
//	private TreeNode<MenuItem> mTagsAndLayersItem        = null;
//	private TreeNode<MenuItem> mAudioItem                = null;
//	private TreeNode<MenuItem> mTimeItem                 = null;
//	private TreeNode<MenuItem> mPlayerItem               = null;
//	private TreeNode<MenuItem> mPhysicsItem              = null;
//	private TreeNode<MenuItem> mPhysics2DItem            = null;
//	private TreeNode<MenuItem> mQualityItem              = null;
//	private TreeNode<MenuItem> mGraphicsItem             = null;
//	private TreeNode<MenuItem> mNetworkItem              = null;
//	private TreeNode<MenuItem> mEditorItem               = null;
//	private TreeNode<MenuItem> mScriptExecutionOrderItem = null;
	#endregion

//	private TreeNode<MenuItem> mRenderSettingsItem     = null;

	#region Edit->Network Emulation
	private TreeNode<MenuItem> mNetworkEmulationItem          = null;
	
//	private TreeNode<MenuItem> mNetworkEmulationNoneItem      = null;
//	private TreeNode<MenuItem> mNetworkEmulationBroadbandItem = null;
//	private TreeNode<MenuItem> mNetworkEmulationDSLItem       = null;
//	private TreeNode<MenuItem> mNetworkEmulationISDNItem      = null;
//	private TreeNode<MenuItem> mNetworkEmulationDialUpItem    = null;
	#endregion

	#region Edit->Graphics Emulation
	private TreeNode<MenuItem> mGraphicsEmulationItem             = null;
	
//	private TreeNode<MenuItem> mGraphicsEmulationNoEmulationItem  = null;
//	private TreeNode<MenuItem> mGraphicsEmulationShaderModel3Item = null;
//	private TreeNode<MenuItem> mGraphicsEmulationShaderModel2Item = null;
	#endregion

//	private TreeNode<MenuItem> mSnapSettingsItem       = null;
	#endregion

	#region Assets
	private TreeNode<MenuItem> mAssetsMenu = null;
	#endregion

	#region GameObject
	private TreeNode<MenuItem> mGameObjectMenu = null;
	#endregion

	#region Component
	private TreeNode<MenuItem> mComponentMenu = null;
	#endregion

	#region Window
	private TreeNode<MenuItem> mWindowMenu = null;
	#endregion

	#region Help
	private TreeNode<MenuItem> mHelpMenu = null;
	#endregion

	#endregion

	private PopupMenu mPopupMenu = null;



	/// <summary>
	/// Script starting callback.
	/// </summary>
	void Start()
	{
        CreateMenuItems();
		CreateUI();
	}

	/// <summary>
	/// Creates menu items.
	/// </summary>
    private void CreateMenuItems()
    {
		// Root
        mItems = new TreeNode<MenuItem>(new MenuItem());

        #region File
        mFileMenu            =   MenuItem.Create(mItems,    "File",              OnFileMenu);
        
		/*mNewSceneItem      =*/ MenuItem.Create(mFileMenu, "New Scene",         OnFile_NewScene);
		/*mOpenSceneItem     =*/ MenuItem.Create(mFileMenu, "Open Scene",        OnFile_OpenScene);
        MenuItem.InsertSeparator(mFileMenu);
		/*mSaveSceneItem     =*/ MenuItem.Create(mFileMenu, "Save Scene",        OnFile_SaveScene);
		/*mSaveSceneAsItem   =*/ MenuItem.Create(mFileMenu, "Save Scene as...",  OnFile_SaveSceneAs);
        MenuItem.InsertSeparator(mFileMenu);
		/*mNewProjectItem    =*/ MenuItem.Create(mFileMenu, "New Project...",    OnFile_NewProject);
		/*mOpenProjectItem   =*/ MenuItem.Create(mFileMenu, "Open Project...",   OnFile_OpenProject);
		/*mSaveProjectItem   =*/ MenuItem.Create(mFileMenu, "Save Project",      OnFile_SaveProject);
        MenuItem.InsertSeparator(mFileMenu);
		/*mBuildSettingsItem =*/ MenuItem.Create(mFileMenu, "Build Settings...", OnFile_BuildSettings);
		/*mBuildAndRunItem   =*/ MenuItem.Create(mFileMenu, "Build & Run",       OnFile_BuildAndRun);
        MenuItem.InsertSeparator(mFileMenu);
		/*mExitItem          =*/ MenuItem.Create(mFileMenu, "Exit",              OnFile_Exit);
        #endregion

		#region Edit
		mEditMenu                            =   MenuItem.Create(mItems,    "Edit",                              OnEditMenu);

		/*mUndoItem                          =*/ MenuItem.Create(mEditMenu, "Undo",                              OnEdit_Undo); // TODO: Change name of menu item after changes
		/*mRedoItem                          =*/ MenuItem.Create(mEditMenu, "Redo",                              OnEdit_Redo); // TODO: Change name of menu item after changes
		MenuItem.InsertSeparator(mEditMenu);
		/*mCutItem                           =*/ MenuItem.Create(mEditMenu, "Cut",                               OnEdit_Cut);
		/*mCopyItem                          =*/ MenuItem.Create(mEditMenu, "Copy",                              OnEdit_Copy);
		/*mPasteItem                         =*/ MenuItem.Create(mEditMenu, "Paste",                             OnEdit_Paste);
		MenuItem.InsertSeparator(mEditMenu);
		/*mDuplicateItem                     =*/ MenuItem.Create(mEditMenu, "Duplicate",                         OnEdit_Duplicate);
		/*mDeleteItem                        =*/ MenuItem.Create(mEditMenu, "Delete",                            OnEdit_Delete);
		MenuItem.InsertSeparator(mEditMenu);
		/*mFrameSelectedItem                 =*/ MenuItem.Create(mEditMenu, "Frame Selected",                    OnEdit_FrameSelected);
		/*mLockViewToSelectedItem            =*/ MenuItem.Create(mEditMenu, "Lock View to Selected",             OnEdit_LockViewToSelected);
		/*mFindItem                          =*/ MenuItem.Create(mEditMenu, "Find",                              OnEdit_Find);
		/*mSelectAllItem                     =*/ MenuItem.Create(mEditMenu, "Select All",                        OnEdit_SelectAll);
		MenuItem.InsertSeparator(mEditMenu);
		/*mPreferencesItem                   =*/ MenuItem.Create(mEditMenu, "Preferences...",                    OnEdit_Preferences);
		/*mModulesItem                       =*/ MenuItem.Create(mEditMenu, "Modules...",                        OnEdit_Modules);
		MenuItem.InsertSeparator(mEditMenu);
		/*mPlayItem                          =*/ MenuItem.Create(mEditMenu, "Play",                              OnEdit_Play);
		/*mPauseItem                         =*/ MenuItem.Create(mEditMenu, "Pause",                             OnEdit_Pause);
		/*mStepItem                          =*/ MenuItem.Create(mEditMenu, "Step",                              OnEdit_Step);
		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Selection
		mSelectionItem                       =   MenuItem.Create(mEditMenu, "Selection");
		
		/*mLoadSelection1Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 1",             OnEdit_Selection_LoadSelection1);
		/*mLoadSelection2Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 2",             OnEdit_Selection_LoadSelection2);
		/*mLoadSelection3Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 3",             OnEdit_Selection_LoadSelection3);
		/*mLoadSelection4Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 4",             OnEdit_Selection_LoadSelection4);
		/*mLoadSelection5Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 5",             OnEdit_Selection_LoadSelection5);
		/*mLoadSelection6Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 6",             OnEdit_Selection_LoadSelection6);
		/*mLoadSelection7Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 7",             OnEdit_Selection_LoadSelection7);
		/*mLoadSelection8Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 8",             OnEdit_Selection_LoadSelection8);
		/*mLoadSelection9Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 9",             OnEdit_Selection_LoadSelection9);
		/*mLoadSelection0Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 0",             OnEdit_Selection_LoadSelection0);
		
		/*mSaveSelection1Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 1",             OnEdit_Selection_SaveSelection1);
		/*mSaveSelection2Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 2",             OnEdit_Selection_SaveSelection2);
		/*mSaveSelection3Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 3",             OnEdit_Selection_SaveSelection3);
		/*mSaveSelection4Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 4",             OnEdit_Selection_SaveSelection4);
		/*mSaveSelection5Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 5",             OnEdit_Selection_SaveSelection5);
		/*mSaveSelection6Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 6",             OnEdit_Selection_SaveSelection6);
		/*mSaveSelection7Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 7",             OnEdit_Selection_SaveSelection7);
		/*mSaveSelection8Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 8",             OnEdit_Selection_SaveSelection8);
		/*mSaveSelection9Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 9",             OnEdit_Selection_SaveSelection9);
		/*mSaveSelection0Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 0",             OnEdit_Selection_SaveSelection0);
		#endregion

		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Project Settings
		mProjectSettingsItem                 =   MenuItem.Create(mEditMenu, "Project Settings");
		
		/*mInputItem                         =*/ MenuItem.Create(mProjectSettingsItem, "Input",                  OnEdit_ProjectSettings_Input);
		/*mTagsAndLayersItem                 =*/ MenuItem.Create(mProjectSettingsItem, "Tags and Layers",        OnEdit_ProjectSettings_TagsAndLayers);
		/*mAudioItem                         =*/ MenuItem.Create(mProjectSettingsItem, "Audio",                  OnEdit_ProjectSettings_Audio);
		/*mTimeItem                          =*/ MenuItem.Create(mProjectSettingsItem, "Time",                   OnEdit_ProjectSettings_Time);
		/*mPlayerItem                        =*/ MenuItem.Create(mProjectSettingsItem, "Player",                 OnEdit_ProjectSettings_Player);
		/*mPhysicsItem                       =*/ MenuItem.Create(mProjectSettingsItem, "Physics",                OnEdit_ProjectSettings_Physics);
		/*mPhysics2DItem                     =*/ MenuItem.Create(mProjectSettingsItem, "Physics 2D",             OnEdit_ProjectSettings_Physics2D);
		/*mQualityItem                       =*/ MenuItem.Create(mProjectSettingsItem, "Quality",                OnEdit_ProjectSettings_Quality);
		/*mGraphicsItem                      =*/ MenuItem.Create(mProjectSettingsItem, "Graphics",               OnEdit_ProjectSettings_Graphics);
		/*mNetworkItem                       =*/ MenuItem.Create(mProjectSettingsItem, "Network",                OnEdit_ProjectSettings_Network);
		/*mEditorItem                        =*/ MenuItem.Create(mProjectSettingsItem, "Editor",                 OnEdit_ProjectSettings_Editor);
		/*mScriptExecutionOrderItem          =*/ MenuItem.Create(mProjectSettingsItem, "Script Execution Order", OnEdit_ProjectSettings_ScriptExecutionOrder);
		#endregion
		
		/*mRenderSettingsItem                =*/ MenuItem.Create(mEditMenu, "Render Settings",                   OnEdit_RenderSettings);
		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Network Emulation
		mNetworkEmulationItem                =   MenuItem.Create(mEditMenu, "Network Emulation");
		
		/*mNetworkEmulationNoneItem          =*/ MenuItem.Create(mNetworkEmulationItem, "None",                  OnEdit_NetworkEmulation_None);
		/*mNetworkEmulationBroadbandItem     =*/ MenuItem.Create(mNetworkEmulationItem, "Broadband",             OnEdit_NetworkEmulation_Broadband);
		/*mNetworkEmulationDSLItem           =*/ MenuItem.Create(mNetworkEmulationItem, "DSL",                   OnEdit_NetworkEmulation_DSL);
		/*mNetworkEmulationISDNItem          =*/ MenuItem.Create(mNetworkEmulationItem, "ISDN",                  OnEdit_NetworkEmulation_ISDN);
		/*mNetworkEmulationDialUpItem        =*/ MenuItem.Create(mNetworkEmulationItem, "Dial-Up",               OnEdit_NetworkEmulation_DialUp);
		#endregion
		
		#region Edit->Graphics Emulation
		mGraphicsEmulationItem               =   MenuItem.Create(mEditMenu, "Graphics Emulation");
		
		/*mGraphicsEmulationNoEmulationItem  =*/ MenuItem.Create(mGraphicsEmulationItem, "No Emulation",         OnEdit_GraphicsEmulation_NoEmulation);
		/*mGraphicsEmulationShaderModel3Item =*/ MenuItem.Create(mGraphicsEmulationItem, "Shader Model 3",       OnEdit_GraphicsEmulation_ShaderModel3);
		/*mGraphicsEmulationShaderModel2Item =*/ MenuItem.Create(mGraphicsEmulationItem, "Shader Model 2",       OnEdit_GraphicsEmulation_ShaderModel2);
		#endregion

		MenuItem.InsertSeparator(mEditMenu);
		/*mSnapSettingsItem                  =*/ MenuItem.Create(mEditMenu,              "Snap Settings...",     OnEdit_SnapSettings);
		#endregion

		#region Assets
		mAssetsMenu = MenuItem.Create(mItems, "Assets", OnAssetsMenu);
		#endregion

		#region GameObject
		mGameObjectMenu = MenuItem.Create(mItems, "GameObject", OnGameObjectMenu);
		#endregion

		#region Component
		mComponentMenu = MenuItem.Create(mItems, "Component", OnComponentMenu);
		#endregion

		#region Window
		mWindowMenu = MenuItem.Create(mItems, "Window", OnWindowMenu);
		#endregion

		#region Help
		mHelpMenu = MenuItem.Create(mItems, "Help", OnHelpMenu);
		#endregion
    }

	/// <summary>
	/// Creates user interface.
	/// </summary>
	private void CreateUI() // TODO: Report bug for ///
	{
		//***************************************************************************
		// ScrollArea GameObject
		//***************************************************************************
		#region ScrollArea GameObject
        GameObject scrollArea = new GameObject("ScrollArea");
        Utils.InitUIObject(scrollArea, transform);

		//===========================================================================
		// RectTransform Component
		//===========================================================================
		#region RectTransform Component
        RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
		Utils.AlignRectTransformFill(scrollAreaTransform);
		#endregion

		//***************************************************************************
		// Content for ScrollArea object
		//***************************************************************************
		#region Content for ScrollArea object
        GameObject scrollAreaContent = new GameObject("Content");
        Utils.InitUIObject(scrollAreaContent, scrollArea.transform);

		//===========================================================================
		// RectTransform Component
		//===========================================================================
		#region RectTransform Component
        RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();

		scrollAreaContentTransform.localScale = new Vector3(1f, 1f, 1f);
        scrollAreaContentTransform.anchorMin  = new Vector2(0f, 0f);
        scrollAreaContentTransform.anchorMax  = new Vector2(0f, 1f);
		scrollAreaContentTransform.pivot      = new Vector2(0f, 0.5f);
		#endregion

        // Fill content
        float contentWidth = 0f;

        // Create menu item buttons
        foreach (TreeNode<MenuItem> menuItem in mItems.Children)
        {
			//***************************************************************************
			// Button GameObject
			//***************************************************************************
			#region Button GameObject
			GameObject menuItemButton = Instantiate(menuButton.gameObject) as GameObject;
			Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
			menuItemButton.name = menuItem.Data.Name; // TODO: Token id to string

			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform menuItemButtonTransform = menuItemButton.GetComponent<RectTransform>();
			
			menuItemButtonTransform.localScale = new Vector3(1f, 1f, 1f);
			menuItemButtonTransform.anchorMin  = new Vector2(0f, 0f);
			menuItemButtonTransform.anchorMax  = new Vector2(0f, 1f);
			#endregion

			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button button = menuItemButton.GetComponent<Button>();
			
			button.interactable = menuItem.Data.Enabled; // TODO: Check it. Maybe do the same as for PopupMenu
			button.onClick.AddListener(menuItem.Data.OnClick);
			#endregion
			#endregion

			//***************************************************************************
			// Text GameObject
			//***************************************************************************
			#region Text GameObject
			GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject;

			#region Text Component
			Text text = menuItemText.GetComponent<Text>();
			text.text = menuItem.Data.Name; // TODO: Translate
			#endregion
			#endregion

			#region Calculating button geometry
			++contentWidth;

			float buttonWidth = text.preferredWidth + 12;

			menuItemButtonTransform.anchoredPosition3D = new Vector3(contentWidth + buttonWidth / 2, 0f, 0f);
			menuItemButtonTransform.sizeDelta          = new Vector2(buttonWidth, -2f);
			
			contentWidth += buttonWidth + 1;
			#endregion
        }

		scrollAreaContentTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        scrollAreaContentTransform.sizeDelta          = new Vector2(contentWidth, 0f);
		#endregion

		#region ScrollRect Component
		ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();

		scrollAreaScrollRect.content  = scrollAreaContentTransform;
		scrollAreaScrollRect.vertical = false;
		#endregion
		#endregion
	}

	/// <summary>
	/// Creates and displays popup menu for specified menu item.
	/// </summary>
	/// <param name="node"><see cref="common.TreeNode`1"/> instance.</param>
	public void OnShowMenuSubItems(TreeNode<MenuItem> node)
    {
		Debug.Log("MainMenuScript.OnShowMenuSubItems(" + node.Data.Name + ")");

		if (mPopupMenu != null)
		{
			mPopupMenu.Destroy();
		}

		mPopupMenu = new PopupMenu(node);
		mPopupMenu.OnDestroy.AddListener(OnPopupMenuDestroyed);

		RectTransform menuItemTransform = transform.FindChild("ScrollArea/Content/" + node.Data.Name).GetComponent<RectTransform>();
		Vector3[] menuItemCorners = Utils.GetWindowCorners(menuItemTransform);

		mPopupMenu.Show(menuItemCorners[0].x, menuItemCorners[0].y);
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
		OnShowMenuSubItems(mFileMenu);
	}

	/// <summary>
	/// Handler for File->New Scene.
	/// </summary>
	public void OnFile_NewScene()
	{
		Debug.Log("MainMenuScript.OnFile_NewScene");
		// TODO: Implement MainMenuScript.OnFile_NewScene
	}

	/// <summary>
	/// Handler for File->Open Scene.
	/// </summary>
	public void OnFile_OpenScene()
	{
		Debug.Log("MainMenuScript.OnFile_OpenScene");
		// TODO: Implement MainMenuScript.OnFile_OpenScene
	}

	/// <summary>
	/// Handler for File->Save Scene.
	/// </summary>
	public void OnFile_SaveScene()
	{
		Debug.Log("MainMenuScript.OnFile_SaveScene");
		// TODO: Implement MainMenuScript.OnFile_SaveScene
	}

	/// <summary>
	/// Handler for File->Save Scene as...
	/// </summary>
	public void OnFile_SaveSceneAs()
	{
		Debug.Log("MainMenuScript.OnFile_SaveSceneAs");
		// TODO: Implement MainMenuScript.OnFile_SaveSceneAs
	}

	/// <summary>
	/// Handler for File->New Project...
	/// </summary>
	public void OnFile_NewProject()
	{
		Debug.Log("MainMenuScript.OnFile_NewProject");
		// TODO: Implement MainMenuScript.OnFile_NewProject
	}

	/// <summary>
	/// Handler for File->Open Project...
	/// </summary>
	public void OnFile_OpenProject()
	{
		Debug.Log("MainMenuScript.OnFile_OpenProject");
		// TODO: Implement MainMenuScript.OnFile_OpenProject
	}

	/// <summary>
	/// Handler for File->Save Project.
	/// </summary>
	public void OnFile_SaveProject()
	{
		Debug.Log("MainMenuScript.OnFile_SaveProject");
		// TODO: Implement MainMenuScript.OnFile_SaveProject
	}

	/// <summary>
	/// Handler for File->Build Settings...
	/// </summary>
	public void OnFile_BuildSettings()
	{
		Debug.Log("MainMenuScript.OnFile_BuildSettings");
		// TODO: Implement MainMenuScript.OnFile_BuildSettings
	}

	/// <summary>
	/// Handler for File->Build & Run.
	/// </summary>
	public void OnFile_BuildAndRun()
	{
		Debug.Log("MainMenuScript.OnFile_BuildAndRun");
		// TODO: Implement MainMenuScript.OnFile_BuildAndRun
	}

	/// <summary>
	/// Handler for File->Exit.
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
		OnShowMenuSubItems(mEditMenu);
	}

	/// <summary>
	/// Handler for Edit->Undo.
	/// </summary>
	public void OnEdit_Undo()
	{
		Debug.Log("MainMenuScript.OnEdit_Undo");
		// TODO: Implement MainMenuScript.OnEdit_Undo
	}

	/// <summary>
	/// Handler for Edit->Redo.
	/// </summary>
	public void OnEdit_Redo()
	{
		Debug.Log("MainMenuScript.OnEdit_Redo");
		// TODO: Implement MainMenuScript.OnEdit_Redo
	}

	/// <summary>
	/// Handler for Edit->Cut.
	/// </summary>
	public void OnEdit_Cut()
	{
		Debug.Log("MainMenuScript.OnEdit_Cut");
		// TODO: Implement MainMenuScript.OnEdit_Cut
	}

	/// <summary>
	/// Handler for Edit->Copy.
	/// </summary>
	public void OnEdit_Copy()
	{
		Debug.Log("MainMenuScript.OnEdit_Copy");
		// TODO: Implement MainMenuScript.OnEdit_Copy
	}

	/// <summary>
	/// Handler for Edit->Paste.
	/// </summary>
	public void OnEdit_Paste()
	{
		Debug.Log("MainMenuScript.OnEdit_Paste");
		// TODO: Implement MainMenuScript.OnEdit_Paste
	}

	/// <summary>
	/// Handler for Edit->Duplicate.
	/// </summary>
	public void OnEdit_Duplicate()
	{
		Debug.Log("MainMenuScript.OnEdit_Duplicate");
		// TODO: Implement MainMenuScript.OnEdit_Duplicate
	}

	/// <summary>
	/// Handler for Edit->Delete.
	/// </summary>
	public void OnEdit_Delete()
	{
		Debug.Log("MainMenuScript.OnEdit_Delete");
		// TODO: Implement MainMenuScript.OnEdit_Delete
	}

	/// <summary>
	/// Handler for Edit->Frame Selected.
	/// </summary>
	public void OnEdit_FrameSelected()
	{
		Debug.Log("MainMenuScript.OnEdit_FrameSelected");
		// TODO: Implement MainMenuScript.OnEdit_FrameSelected
	}

	/// <summary>
	/// Handler for Edit->Lock View to Selected.
	/// </summary>
	public void OnEdit_LockViewToSelected()
	{
		Debug.Log("MainMenuScript.OnEdit_LockViewToSelected");
		// TODO: Implement MainMenuScript.OnEdit_LockViewToSelected
	}

	/// <summary>
	/// Handler for Edit->Find.
	/// </summary>
	public void OnEdit_Find()
	{
		Debug.Log("MainMenuScript.OnEdit_Find");
		// TODO: Implement MainMenuScript.OnEdit_Find
	}

	/// <summary>
	/// Handler for Edit->Select All.
	/// </summary>
	public void OnEdit_SelectAll()
	{
		Debug.Log("MainMenuScript.OnEdit_SelectAll");
		// TODO: Implement MainMenuScript.OnEdit_SelectAll
	}
		
	/// <summary>
	/// Handler for Edit->Preferences...
	/// </summary>
	public void OnEdit_Preferences()
	{
		Debug.Log("MainMenuScript.OnEdit_Preferences");
		// TODO: Implement MainMenuScript.OnEdit_Preferences
	}

	/// <summary>
	/// Handler for Edit->Modules...
	/// </summary>
	public void OnEdit_Modules()
	{
		Debug.Log("MainMenuScript.OnEdit_Modules");
		// TODO: Implement MainMenuScript.OnEdit_Modules
	}
		
	/// <summary>
	/// Handler for Edit->Play.
	/// </summary>
	public void OnEdit_Play()
	{
		Debug.Log("MainMenuScript.OnEdit_Play");
		// TODO: Implement MainMenuScript.OnEdit_Play
	}

	/// <summary>
	/// Handler for Edit->Pause.
	/// </summary>
	public void OnEdit_Pause()
	{
		Debug.Log("MainMenuScript.OnEdit_Pause");
		// TODO: Implement MainMenuScript.OnEdit_Pause
	}

	/// <summary>
	/// Handler for Edit->Step.
	/// </summary>
	public void OnEdit_Step()
	{
		Debug.Log("MainMenuScript.OnEdit_Step");
		// TODO: Implement MainMenuScript.OnEdit_Step
	}
	
	#region Edit->Selection
	/// <summary>
	/// Handler for Edit->Selection->Load Selection 1.
	/// </summary>
	public void OnEdit_Selection_LoadSelection1()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection1");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection1
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 2.
	/// </summary>
	public void OnEdit_Selection_LoadSelection2()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection2");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection2
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 3.
	/// </summary>
	public void OnEdit_Selection_LoadSelection3()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection3");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection3
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 4.
	/// </summary>
	public void OnEdit_Selection_LoadSelection4()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection4");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection4
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 5.
	/// </summary>
	public void OnEdit_Selection_LoadSelection5()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection5");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection5
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 6.
	/// </summary>
	public void OnEdit_Selection_LoadSelection6()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection6");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection6
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 7.
	/// </summary>
	public void OnEdit_Selection_LoadSelection7()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection7");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection7
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 8.
	/// </summary>
	public void OnEdit_Selection_LoadSelection8()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection8");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection8
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 9.
	/// </summary>
	public void OnEdit_Selection_LoadSelection9()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection9");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection9
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 0.
	/// </summary>
	public void OnEdit_Selection_LoadSelection0()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection0");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection0
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 1.
	/// </summary>
	public void OnEdit_Selection_SaveSelection1()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection1");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection1
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 2.
	/// </summary>
	public void OnEdit_Selection_SaveSelection2()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection2");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection2
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 3.
	/// </summary>
	public void OnEdit_Selection_SaveSelection3()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection3");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection3
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 4.
	/// </summary>
	public void OnEdit_Selection_SaveSelection4()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection4");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection4
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 5.
	/// </summary>
	public void OnEdit_Selection_SaveSelection5()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection5");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection5
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 6.
	/// </summary>
	public void OnEdit_Selection_SaveSelection6()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection6");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection6
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 7.
	/// </summary>
	public void OnEdit_Selection_SaveSelection7()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection7");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection7
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 8.
	/// </summary>
	public void OnEdit_Selection_SaveSelection8()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection8");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection8
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 9.
	/// </summary>
	public void OnEdit_Selection_SaveSelection9()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection9");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection9
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 0.
	/// </summary>
	public void OnEdit_Selection_SaveSelection0()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection0");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection0
	}
	#endregion
	
	#region Edit->Project Settings
	/// <summary>
	/// Handler for Edit->Project Settings->Input.
	/// </summary>
	public void OnEdit_ProjectSettings_Input()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Input");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Input
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Tags and Layers.
	/// </summary>
	public void OnEdit_ProjectSettings_TagsAndLayers()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Audio.
	/// </summary>
	public void OnEdit_ProjectSettings_Audio()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Audio");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Audio
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Time.
	/// </summary>
	public void OnEdit_ProjectSettings_Time()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Time");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Time
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Player.
	/// </summary>
	public void OnEdit_ProjectSettings_Player()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Player");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Player
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Physics.
	/// </summary>
	public void OnEdit_ProjectSettings_Physics()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Physics 2D.
	/// </summary>
	public void OnEdit_ProjectSettings_Physics2D()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics2D");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics2D
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Quality.
	/// </summary>
	public void OnEdit_ProjectSettings_Quality()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Quality");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Quality
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Graphics.
	/// </summary>
	public void OnEdit_ProjectSettings_Graphics()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Graphics");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Graphics
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Network.
	/// </summary>
	public void OnEdit_ProjectSettings_Network()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Network");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Network
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Editor.
	/// </summary>
	public void OnEdit_ProjectSettings_Editor()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Editor");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Editor
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Script Execution Order.
	/// </summary>
	public void OnEdit_ProjectSettings_ScriptExecutionOrder()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder
	}
	#endregion

	/// <summary>
	/// Handler for Edit->Render Settings.
	/// </summary>
	public void OnEdit_RenderSettings()
	{
		Debug.Log("MainMenuScript.OnEdit_RenderSettings");
		// TODO: Implement MainMenuScript.OnEdit_RenderSettings
	}
		
	#region Edit->Network Emulation
	/// <summary>
	/// Handler for Edit->Network Emulation->None.
	/// </summary>
	public void OnEdit_NetworkEmulation_None()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_None");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_None
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->Broadband.
	/// </summary>
	public void OnEdit_NetworkEmulation_Broadband()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_Broadband");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_Broadband
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->DSL.
	/// </summary>
	public void OnEdit_NetworkEmulation_DSL()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DSL");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DSL
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->ISDN.
	/// </summary>
	public void OnEdit_NetworkEmulation_ISDN()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_ISDN");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_ISDN
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->Dial-Up.
	/// </summary>
	public void OnEdit_NetworkEmulation_DialUp()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DialUp");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DialUp
	}
	#endregion
	
	#region Edit->Graphics Emulation
	/// <summary>
	/// Handler for Edit->Graphics Emulation->No Emulation.
	/// </summary>
	public void OnEdit_GraphicsEmulation_NoEmulation()
	{
		Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation");
		// TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation
	}

	/// <summary>
	/// Handler for Edit->Graphics Emulation->Shader Model 3.
	/// </summary>
	public void OnEdit_GraphicsEmulation_ShaderModel3()
	{
		Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel3");
		// TODO: Implement MainMenuScript.OnEdit_ReOnEdit_GraphicsEmulation_ShaderModel3do
	}

	/// <summary>
	/// Handler for Edit->Graphics Emulation->Shader Model 2.
	/// </summary>
	public void OnEdit_GraphicsEmulation_ShaderModel2()
	{
		Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2");
		// TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2
	}
	#endregion

	/// <summary>
	/// Handler for Edit->Snap Settings...
	/// </summary>
	public void OnEdit_SnapSettings()
	{
		Debug.Log("MainMenuScript.OnEdit_SnapSettings");
		// TODO: Implement MainMenuScript.OnEdit_SnapSettings
	}
	#endregion
	
	#region Assets
	/// <summary>
	/// Handler for Assets.
	/// </summary>
	public void OnAssetsMenu()
	{
		OnShowMenuSubItems(mAssetsMenu);
	}
	#endregion
	
	#region GameObject
	/// <summary>
	/// Handler for GameObject.
	/// </summary>
	public void OnGameObjectMenu()
	{
		OnShowMenuSubItems(mGameObjectMenu);
	}
	#endregion
	
	#region Component
	/// <summary>
	/// Handler for Component.
	/// </summary>
	public void OnComponentMenu()
	{
		OnShowMenuSubItems(mComponentMenu);
	}
	#endregion
	
	#region Window
	/// <summary>
	/// Handler for Window.
	/// </summary>
	public void OnWindowMenu()
	{
		OnShowMenuSubItems(mWindowMenu);
	}
	#endregion
	
	#region Help
	/// <summary>
	/// Handler for Help.
	/// </summary>
	public void OnHelpMenu()
	{
		OnShowMenuSubItems(mHelpMenu);
	}
	#endregion
	#endregion
}
