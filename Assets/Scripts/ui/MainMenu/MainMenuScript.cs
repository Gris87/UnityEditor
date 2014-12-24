using UnityEngine;
using UnityEngine.UI;

using common;
using common.ui;



public class MainMenuScript : MonoBehaviour
{
    public Button menuButton = null;

	private TreeNode<MenuItem> mItems          = null;
	private TreeNode<MenuItem> mFileMenu       = null;
	private TreeNode<MenuItem> mEditMenu       = null;
	private TreeNode<MenuItem> mAssetsMenu     = null;
	private TreeNode<MenuItem> mGameObjectMenu = null;
	private TreeNode<MenuItem> mComponentMenu  = null;
	private TreeNode<MenuItem> mWindowMenu     = null;
	private TreeNode<MenuItem> mHelpMenu       = null;
	private PopupMenu          mPopupMenu      = null;



	// Use this for initialization
	void Start()
	{
        CreateMenuItems();
		CreateUI();
	}

	// Update is called once per frame
	void Update()
	{
		if (mPopupMenu != null)
		{
			mPopupMenu.Update();
		}
	}

    private void CreateMenuItems()
    {
		// Root
        mItems = new TreeNode<MenuItem>(new MenuItem());

        #region File
        mFileMenu = MenuItem.Create(mItems, "File", OnFileMenu);
        
        MenuItem.Create(mFileMenu, "New Scene",         OnNewScene);
        MenuItem.Create(mFileMenu, "Open Scene",        OnOpenScene);
        MenuItem.InsertSeparator(mFileMenu);
        MenuItem.Create(mFileMenu, "Save Scene",        OnSaveScene);
        MenuItem.Create(mFileMenu, "Save Scene as...",  OnSaveSceneAs);
        MenuItem.InsertSeparator(mFileMenu);
        MenuItem.Create(mFileMenu, "New Project...",    OnNewProject);
        MenuItem.Create(mFileMenu, "Open Project...",   OnOpenProject);
        MenuItem.Create(mFileMenu, "Save Project",      OnSaveProject);
        MenuItem.InsertSeparator(mFileMenu);
        MenuItem.Create(mFileMenu, "Build Settings...", OnBuildSettings);
        MenuItem.Create(mFileMenu, "Build & Run",       OnBuildAndRun);
        MenuItem.InsertSeparator(mFileMenu);
        MenuItem.Create(mFileMenu, "Exit",              OnExit);
        #endregion

		#region Edit
		mEditMenu = MenuItem.Create(mItems, "Edit", OnEditMenu);
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
