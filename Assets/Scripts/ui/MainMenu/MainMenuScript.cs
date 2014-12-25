using UnityEngine;
using UnityEngine.UI;

using common;
using common.ui;



public class MainMenuScript : MonoBehaviour
{
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



	// Use this for initialization
	void Start()
	{
        CreateMenuItems();
		CreateUI();
	}

    private void CreateMenuItems()
    {
		// Root
        mItems = new TreeNode<MenuItem>(new MenuItem());

        #region File
        mFileMenu            =   MenuItem.Create(mItems,    "File",              OnFileMenu);
        
		/*mNewSceneItem      =*/ MenuItem.Create(mFileMenu, "New Scene",         OnNewScene);
		/*mOpenSceneItem     =*/ MenuItem.Create(mFileMenu, "Open Scene",        OnOpenScene);
        MenuItem.InsertSeparator(mFileMenu);
		/*mSaveSceneItem     =*/ MenuItem.Create(mFileMenu, "Save Scene",        OnSaveScene);
		/*mSaveSceneAsItem   =*/ MenuItem.Create(mFileMenu, "Save Scene as...",  OnSaveSceneAs);
        MenuItem.InsertSeparator(mFileMenu);
		/*mNewProjectItem    =*/ MenuItem.Create(mFileMenu, "New Project...",    OnNewProject);
		/*mOpenProjectItem   =*/ MenuItem.Create(mFileMenu, "Open Project...",   OnOpenProject);
		/*mSaveProjectItem   =*/ MenuItem.Create(mFileMenu, "Save Project",      OnSaveProject);
        MenuItem.InsertSeparator(mFileMenu);
		/*mBuildSettingsItem =*/ MenuItem.Create(mFileMenu, "Build Settings...", OnBuildSettings);
		/*mBuildAndRunItem   =*/ MenuItem.Create(mFileMenu, "Build & Run",       OnBuildAndRun);
        MenuItem.InsertSeparator(mFileMenu);
		/*mExitItem          =*/ MenuItem.Create(mFileMenu, "Exit",              OnExit);
        #endregion

		#region Edit
		mEditMenu                            =   MenuItem.Create(mItems,    "Edit",                              OnEditMenu);

		/*mUndoItem                          =*/ MenuItem.Create(mEditMenu, "Undo",                              OnUndo); // TODO: Change name of menu item after changes
		/*mRedoItem                          =*/ MenuItem.Create(mEditMenu, "Redo",                              OnRedo); // TODO: Change name of menu item after changes
		MenuItem.InsertSeparator(mEditMenu);
		/*mCutItem                           =*/ MenuItem.Create(mEditMenu, "Cut",                               OnCut);
		/*mCopyItem                          =*/ MenuItem.Create(mEditMenu, "Copy",                              OnCopy);
		/*mPasteItem                         =*/ MenuItem.Create(mEditMenu, "Paste",                             OnPaste);
		MenuItem.InsertSeparator(mEditMenu);
		/*mDuplicateItem                     =*/ MenuItem.Create(mEditMenu, "Duplicate",                         OnDuplicate);
		/*mDeleteItem                        =*/ MenuItem.Create(mEditMenu, "Delete",                            OnDelete);
		MenuItem.InsertSeparator(mEditMenu);
		/*mFrameSelectedItem                 =*/ MenuItem.Create(mEditMenu, "Frame Selected",                    OnFrameSelected);
		/*mLockViewToSelectedItem            =*/ MenuItem.Create(mEditMenu, "Lock View to Selected",             OnLockViewToSelected);
		/*mFindItem                          =*/ MenuItem.Create(mEditMenu, "Find",                              OnFind);
		/*mSelectAllItem                     =*/ MenuItem.Create(mEditMenu, "Select All",                        OnSelectAll);
		MenuItem.InsertSeparator(mEditMenu);
		/*mPreferencesItem                   =*/ MenuItem.Create(mEditMenu, "Preferences...",                    OnPreferences);
		/*mModulesItem                       =*/ MenuItem.Create(mEditMenu, "Modules...",                        OnModules);
		MenuItem.InsertSeparator(mEditMenu);
		/*mPlayItem                          =*/ MenuItem.Create(mEditMenu, "Play",                              OnPlay);
		/*mPauseItem                         =*/ MenuItem.Create(mEditMenu, "Pause",                             OnPause);
		/*mStepItem                          =*/ MenuItem.Create(mEditMenu, "Step",                              OnStep);
		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Selection
		mSelectionItem                       =   MenuItem.Create(mEditMenu, "Selection");
		
		/*mLoadSelection1Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 1",             OnLoadSelection1);
		/*mLoadSelection2Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 2",             OnLoadSelection2);
		/*mLoadSelection3Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 3",             OnLoadSelection3);
		/*mLoadSelection4Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 4",             OnLoadSelection4);
		/*mLoadSelection5Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 5",             OnLoadSelection5);
		/*mLoadSelection6Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 6",             OnLoadSelection6);
		/*mLoadSelection7Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 7",             OnLoadSelection7);
		/*mLoadSelection8Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 8",             OnLoadSelection8);
		/*mLoadSelection9Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 9",             OnLoadSelection9);
		/*mLoadSelection0Item                =*/ MenuItem.Create(mSelectionItem, "Load Selection 0",             OnLoadSelection0);
		
		/*mSaveSelection1Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 1",             OnSaveSelection1);
		/*mSaveSelection2Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 2",             OnSaveSelection2);
		/*mSaveSelection3Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 3",             OnSaveSelection3);
		/*mSaveSelection4Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 4",             OnSaveSelection4);
		/*mSaveSelection5Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 5",             OnSaveSelection5);
		/*mSaveSelection6Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 6",             OnSaveSelection6);
		/*mSaveSelection7Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 7",             OnSaveSelection7);
		/*mSaveSelection8Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 8",             OnSaveSelection8);
		/*mSaveSelection9Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 9",             OnSaveSelection9);
		/*mSaveSelection0Item                =*/ MenuItem.Create(mSelectionItem, "Save Selection 0",             OnSaveSelection0);
		#endregion

		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Project Settings
		mProjectSettingsItem                 =   MenuItem.Create(mEditMenu, "Project Settings");
		
		/*mInputItem                         =*/ MenuItem.Create(mProjectSettingsItem, "Input",                  OnInput);
		/*mTagsAndLayersItem                 =*/ MenuItem.Create(mProjectSettingsItem, "Tags and Layers",        OnTagsAndLayers);
		/*mAudioItem                         =*/ MenuItem.Create(mProjectSettingsItem, "Audio",                  OnAudio);
		/*mTimeItem                          =*/ MenuItem.Create(mProjectSettingsItem, "Time",                   OnTime);
		/*mPlayerItem                        =*/ MenuItem.Create(mProjectSettingsItem, "Player",                 OnPlayer);
		/*mPhysicsItem                       =*/ MenuItem.Create(mProjectSettingsItem, "Physics",                OnPhysics);
		/*mPhysics2DItem                     =*/ MenuItem.Create(mProjectSettingsItem, "Physics 2D",             OnPhysics2D);
		/*mQualityItem                       =*/ MenuItem.Create(mProjectSettingsItem, "Quality",                OnQuality);
		/*mGraphicsItem                      =*/ MenuItem.Create(mProjectSettingsItem, "Graphics",               OnGraphics);
		/*mNetworkItem                       =*/ MenuItem.Create(mProjectSettingsItem, "Network",                OnNetwork);
		/*mEditorItem                        =*/ MenuItem.Create(mProjectSettingsItem, "Editor",                 OnEditor);
		/*mScriptExecutionOrderItem          =*/ MenuItem.Create(mProjectSettingsItem, "Script Execution Order", OnScriptExecutionOrder);
		#endregion
		
		/*mRenderSettingsItem                =*/ MenuItem.Create(mEditMenu, "Render Settings",                   OnRenderSettings);
		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Network Emulation
		mNetworkEmulationItem                =   MenuItem.Create(mEditMenu, "Network Emulation");
		
		/*mNetworkEmulationNoneItem          =*/ MenuItem.Create(mNetworkEmulationItem, "None",                  OnNetworkEmulationNone);
		/*mNetworkEmulationBroadbandItem     =*/ MenuItem.Create(mNetworkEmulationItem, "Broadband",             OnNetworkEmulationBroadband);
		/*mNetworkEmulationDSLItem           =*/ MenuItem.Create(mNetworkEmulationItem, "DSL",                   OnNetworkEmulationDSL);
		/*mNetworkEmulationISDNItem          =*/ MenuItem.Create(mNetworkEmulationItem, "ISDN",                  OnNetworkEmulationISDN);
		/*mNetworkEmulationDialUpItem        =*/ MenuItem.Create(mNetworkEmulationItem, "Dial-Up",               OnNetworkEmulationDialUp);
		#endregion
		
		#region Edit->Graphics Emulation
		mGraphicsEmulationItem               =   MenuItem.Create(mEditMenu, "Graphics Emulation");
		
		/*mGraphicsEmulationNoEmulationItem  =*/ MenuItem.Create(mGraphicsEmulationItem, "No Emulation",         OnGraphicsEmulationNoEmulation);
		/*mGraphicsEmulationShaderModel3Item =*/ MenuItem.Create(mGraphicsEmulationItem, "Shader Model 2",       OnGraphicsEmulationShaderModel3);
		/*mGraphicsEmulationShaderModel2Item =*/ MenuItem.Create(mGraphicsEmulationItem, "Shader Model 2",       OnGraphicsEmulationShaderModel2);
		#endregion

		MenuItem.InsertSeparator(mEditMenu);
		/*mSnapSettingsItem                  =*/ MenuItem.Create(mEditMenu,              "Snap Settings...",     OnSnapSettings);
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

	private void CreateUI()
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
			menuItemButton.name = menuItem.Data.Name;

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
			
			button.interactable = menuItem.Data.Enabled;
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

	public void OnPopupMenuDestroyed()
	{
		Debug.Log("MainMenuScript.OnPopupMenuDestroyed");

		mPopupMenu = null;
	}

	#region Handlers for menu items
	#region File
	public void OnFileMenu()
	{
		OnShowMenuSubItems(mFileMenu);
	}

	public void OnNewScene()
	{
		Debug.Log("MainMenuScript.OnNewScene");
		// TODO: Implement MainMenuScript.OnNewScene
	}

	public void OnOpenScene()
	{
		Debug.Log("MainMenuScript.OnOpenScene");
		// TODO: Implement MainMenuScript.OnOpenScene
	}

	public void OnSaveScene()
	{
		Debug.Log("MainMenuScript.OnSaveScene");
		// TODO: Implement MainMenuScript.OnSaveScene
	}

	public void OnSaveSceneAs()
	{
		Debug.Log("MainMenuScript.OnSaveSceneAs");
		// TODO: Implement MainMenuScript.OnSaveSceneAs
	}

	public void OnNewProject()
	{
		Debug.Log("MainMenuScript.OnNewProject");
		// TODO: Implement MainMenuScript.OnNewProject
	}
	
	public void OnOpenProject()
	{
		Debug.Log("MainMenuScript.OnOpenProject");
		// TODO: Implement MainMenuScript.OnOpenProject
	}
	
	public void OnSaveProject()
	{
		Debug.Log("MainMenuScript.OnSaveProject");
		// TODO: Implement MainMenuScript.OnSaveProject
	}
	
	public void OnBuildSettings()
	{
		Debug.Log("MainMenuScript.OnBuildSettings");
		// TODO: Implement MainMenuScript.OnBuildSettings
	}
	
	public void OnBuildAndRun()
	{
		Debug.Log("MainMenuScript.OnBuildAndRun");
		// TODO: Implement MainMenuScript.OnBuildAndRun
	}
	
	public void OnExit()
	{
		Debug.Log("MainMenuScript.OnExit");
		Application.Quit();
	}
	#endregion

	#region Edit
	public void OnEditMenu()
	{
		OnShowMenuSubItems(mEditMenu);
	}

	public void OnUndo()
	{
		Debug.Log("MainMenuScript.OnUndo");
		// TODO: Implement MainMenuScript.OnUndo
	}

	public void OnRedo()
	{
		Debug.Log("MainMenuScript.OnRedo");
		// TODO: Implement MainMenuScript.OnRedo
	}
	
	public void OnCut()
	{
		Debug.Log("MainMenuScript.OnCut");
		// TODO: Implement MainMenuScript.OnCut
	}

	public void OnCopy()
	{
		Debug.Log("MainMenuScript.OnCopy");
		// TODO: Implement MainMenuScript.OnCopy
	}

	public void OnPaste()
	{
		Debug.Log("MainMenuScript.OnPaste");
		// TODO: Implement MainMenuScript.OnPaste
	}
	
	public void OnDuplicate()
	{
		Debug.Log("MainMenuScript.OnDuplicate");
		// TODO: Implement MainMenuScript.OnDuplicate
	}

	public void OnDelete()
	{
		Debug.Log("MainMenuScript.OnDelete");
		// TODO: Implement MainMenuScript.OnDelete
	}
		
	public void OnFrameSelected()
	{
		Debug.Log("MainMenuScript.OnFrameSelected");
		// TODO: Implement MainMenuScript.OnFrameSelected
	}

	public void OnLockViewToSelected()
	{
		Debug.Log("MainMenuScript.OnLockViewToSelected");
		// TODO: Implement MainMenuScript.OnLockViewToSelected
	}

	public void OnFind()
	{
		Debug.Log("MainMenuScript.OnFind");
		// TODO: Implement MainMenuScript.OnFind
	}

	public void OnSelectAll()
	{
		Debug.Log("MainMenuScript.OnSelectAll");
		// TODO: Implement MainMenuScript.OnSelectAll
	}
		
	public void OnPreferences()
	{
		Debug.Log("MainMenuScript.OnPreferences");
		// TODO: Implement MainMenuScript.OnPreferences
	}

	public void OnModules()
	{
		Debug.Log("MainMenuScript.OnModules");
		// TODO: Implement MainMenuScript.OnModules
	}
		
	public void OnPlay()
	{
		Debug.Log("MainMenuScript.OnPlay");
		// TODO: Implement MainMenuScript.OnPlay
	}

	public void OnPause()
	{
		Debug.Log("MainMenuScript.OnPause");
		// TODO: Implement MainMenuScript.OnPause
	}

	public void OnStep()
	{
		Debug.Log("MainMenuScript.OnStep");
		// TODO: Implement MainMenuScript.OnStep
	}
	
	#region Edit->Selection	
	public void OnLoadSelection1()
	{
		Debug.Log("MainMenuScript.OnLoadSelection1");
		// TODO: Implement MainMenuScript.OnLoadSelection1
	}

	public void OnLoadSelection2()
	{
		Debug.Log("MainMenuScript.OnLoadSelection2");
		// TODO: Implement MainMenuScript.OnLoadSelection2
	}

	public void OnLoadSelection3()
	{
		Debug.Log("MainMenuScript.OnLoadSelection3");
		// TODO: Implement MainMenuScript.OnLoadSelection3
	}

	public void OnLoadSelection4()
	{
		Debug.Log("MainMenuScript.OnLoadSelection4");
		// TODO: Implement MainMenuScript.OnLoadSelection4
	}

	public void OnLoadSelection5()
	{
		Debug.Log("MainMenuScript.OnLoadSelection5");
		// TODO: Implement MainMenuScript.OnLoadSelection5
	}

	public void OnLoadSelection6()
	{
		Debug.Log("MainMenuScript.OnLoadSelection6");
		// TODO: Implement MainMenuScript.OnLoadSelection6
	}

	public void OnLoadSelection7()
	{
		Debug.Log("MainMenuScript.OnLoadSelection7");
		// TODO: Implement MainMenuScript.OnLoadSelection7
	}

	public void OnLoadSelection8()
	{
		Debug.Log("MainMenuScript.OnLoadSelection8");
		// TODO: Implement MainMenuScript.OnLoadSelection8
	}

	public void OnLoadSelection9()
	{
		Debug.Log("MainMenuScript.OnLoadSelection9");
		// TODO: Implement MainMenuScript.OnLoadSelection9
	}

	public void OnLoadSelection0()
	{
		Debug.Log("MainMenuScript.OnLoadSelection0");
		// TODO: Implement MainMenuScript.OnLoadSelection0
	}
	
	public void OnSaveSelection1()
	{
		Debug.Log("MainMenuScript.OnSaveSelection1");
		// TODO: Implement MainMenuScript.OnSaveSelection1
	}

	public void OnSaveSelection2()
	{
		Debug.Log("MainMenuScript.OnSaveSelection2");
		// TODO: Implement MainMenuScript.OnSaveSelection2
	}

	public void OnSaveSelection3()
	{
		Debug.Log("MainMenuScript.OnSaveSelection3");
		// TODO: Implement MainMenuScript.OnSaveSelection3
	}

	public void OnSaveSelection4()
	{
		Debug.Log("MainMenuScript.OnSaveSelection4");
		// TODO: Implement MainMenuScript.OnSaveSelection4
	}

	public void OnSaveSelection5()
	{
		Debug.Log("MainMenuScript.OnSaveSelection5");
		// TODO: Implement MainMenuScript.OnSaveSelection5
	}

	public void OnSaveSelection6()
	{
		Debug.Log("MainMenuScript.OnSaveSelection6");
		// TODO: Implement MainMenuScript.OnSaveSelection6
	}

	public void OnSaveSelection7()
	{
		Debug.Log("MainMenuScript.OnSaveSelection7");
		// TODO: Implement MainMenuScript.OnSaveSelection7
	}

	public void OnSaveSelection8()
	{
		Debug.Log("MainMenuScript.OnSaveSelection8");
		// TODO: Implement MainMenuScript.OnSaveSelection8
	}

	public void OnSaveSelection9()
	{
		Debug.Log("MainMenuScript.OnSaveSelection9");
		// TODO: Implement MainMenuScript.OnSaveSelection9
	}

	public void OnSaveSelection0()
	{
		Debug.Log("MainMenuScript.OnSaveSelection0");
		// TODO: Implement MainMenuScript.OnSaveSelection0
	}
	#endregion
	
	#region Edit->Project Settings	
	public void OnInput()
	{
		Debug.Log("MainMenuScript.OnInput");
		// TODO: Implement MainMenuScript.OnInput
	}

	public void OnTagsAndLayers()
	{
		Debug.Log("MainMenuScript.OnTagsAndLayers");
		// TODO: Implement MainMenuScript.OnTagsAndLayers
	}

	public void OnAudio()
	{
		Debug.Log("MainMenuScript.OnAudio");
		// TODO: Implement MainMenuScript.OnAudio
	}

	public void OnTime()
	{
		Debug.Log("MainMenuScript.OnTime");
		// TODO: Implement MainMenuScript.OnTime
	}

	public void OnPlayer()
	{
		Debug.Log("MainMenuScript.OnPlayer");
		// TODO: Implement MainMenuScript.OnPlayer
	}

	public void OnPhysics()
	{
		Debug.Log("MainMenuScript.OnPhysics");
		// TODO: Implement MainMenuScript.OnPhysics
	}

	public void OnPhysics2D()
	{
		Debug.Log("MainMenuScript.OnPhysics2D");
		// TODO: Implement MainMenuScript.OnPhysics2D
	}

	public void OnQuality()
	{
		Debug.Log("MainMenuScript.OnQuality");
		// TODO: Implement MainMenuScript.OnQuality
	}

	public void OnGraphics()
	{
		Debug.Log("MainMenuScript.OnGraphics");
		// TODO: Implement MainMenuScript.OnGraphics
	}

	public void OnNetwork()
	{
		Debug.Log("MainMenuScript.OnNetwork");
		// TODO: Implement MainMenuScript.OnNetwork
	}

	public void OnEditor()
	{
		Debug.Log("MainMenuScript.OnEditor");
		// TODO: Implement MainMenuScript.OnEditor
	}

	public void OnScriptExecutionOrder()
	{
		Debug.Log("MainMenuScript.OnScriptExecutionOrder");
		// TODO: Implement MainMenuScript.OnScriptExecutionOrder
	}
	#endregion
	
	public void OnRenderSettings()
	{
		Debug.Log("MainMenuScript.OnRenderSettings");
		// TODO: Implement MainMenuScript.OnRenderSettings
	}
		
	#region Edit->Network Emulation	
	public void OnNetworkEmulationNone()
	{
		Debug.Log("MainMenuScript.OnNetworkEmulationNone");
		// TODO: Implement MainMenuScript.OnNetworkEmulationNone
	}

	public void OnNetworkEmulationBroadband()
	{
		Debug.Log("MainMenuScript.OnNetworkEmulationBroadband");
		// TODO: Implement MainMenuScript.OnNetworkEmulationBroadband
	}

	public void OnNetworkEmulationDSL()
	{
		Debug.Log("MainMenuScript.OnNetworkEmulationDSL");
		// TODO: Implement MainMenuScript.OnNetworkEmulationDSL
	}

	public void OnNetworkEmulationISDN()
	{
		Debug.Log("MainMenuScript.OnNetworkEmulationISDN");
		// TODO: Implement MainMenuScript.OnNetworkEmulationISDN
	}

	public void OnNetworkEmulationDialUp()
	{
		Debug.Log("MainMenuScript.OnROnNetworkEmulationDialUpedo");
		// TODO: Implement MainMenuScript.OnNetworkEmulationDialUp
	}
	#endregion
	
	#region Edit->Graphics Emulation	
	public void OnGraphicsEmulationNoEmulation()
	{
		Debug.Log("MainMenuScript.OnGraphicsEmulationNoEmulation");
		// TODO: Implement MainMenuScript.OnGraphicsEmulationNoEmulation
	}

	public void OnGraphicsEmulationShaderModel3()
	{
		Debug.Log("MainMenuScript.OnGraphicsEmulationShaderModel3");
		// TODO: Implement MainMenuScript.OnReOnGraphicsEmulationShaderModel3do
	}

	public void OnGraphicsEmulationShaderModel2()
	{
		Debug.Log("MainMenuScript.OnGraphicsEmulationShaderModel2");
		// TODO: Implement MainMenuScript.OnGraphicsEmulationShaderModel2
	}
	#endregion
	
	public void OnSnapSettings()
	{
		Debug.Log("MainMenuScript.OnSnapSettings");
		// TODO: Implement MainMenuScript.OnSnapSettings
	}
	#endregion
	
	#region Assets
	public void OnAssetsMenu()
	{
		OnShowMenuSubItems(mAssetsMenu);
	}
	#endregion
	
	#region GameObject
	public void OnGameObjectMenu()
	{
		OnShowMenuSubItems(mGameObjectMenu);
	}
	#endregion
	
	#region Component
	public void OnComponentMenu()
	{
		OnShowMenuSubItems(mComponentMenu);
	}
	#endregion
	
	#region Window
	public void OnWindowMenu()
	{
		OnShowMenuSubItems(mWindowMenu);
	}
	#endregion
	
	#region Help
	public void OnHelpMenu()
	{
		OnShowMenuSubItems(mHelpMenu);
	}
	#endregion
	#endregion
}
