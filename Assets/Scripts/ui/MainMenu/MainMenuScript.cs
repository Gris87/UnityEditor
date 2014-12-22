using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using common;
using common.ui;



public class MainMenuScript : MonoBehaviour
{
    public Button menuButton;

    private TreeNode<MenuItem> mItems;



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

        // File
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "File", OnShowMenuSubItems);

			MenuItem.Create(node, "New Scene",         OnNewScene);
			MenuItem.Create(node, "Open Scene",        OnOpenScene);
			MenuItem.InsertSeparator(node);
			MenuItem.Create(node, "Save Scene",        OnSaveScene);
			MenuItem.Create(node, "Save Scene as...",  OnSaveSceneAs);
			MenuItem.InsertSeparator(node);
			MenuItem.Create(node, "New Project...",    OnNewProject);
			MenuItem.Create(node, "Open Project...",   OnOpenProject);
			MenuItem.Create(node, "Save Project",      OnSaveProject);
			MenuItem.InsertSeparator(node);
			MenuItem.Create(node, "Build Settings...", OnBuildSettings);
			MenuItem.Create(node, "Build & Run",       OnBuildAndRun);
			MenuItem.InsertSeparator(node);
			MenuItem.Create(node, "Exit",              OnExit);
        }

        // Edit
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Edit", OnShowMenuSubItems);
            Debug.Log(node);
        }

        // Assets
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Assets", OnShowMenuSubItems);
            Debug.Log(node);
        }

        // GameObject
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "GameObject", OnShowMenuSubItems);
            Debug.Log(node);
        }

        // Component
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Component", OnShowMenuSubItems);
            Debug.Log(node);
        }

        // Window
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Window", OnShowMenuSubItems);
            Debug.Log(node);
        }

        // Help
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Help", OnShowMenuSubItems);
            Debug.Log(node);
        }
    }

	private void CreateUI()
	{
        // Create ScrollArea object
        GameObject scrollArea = new GameObject("ScrollArea");
        Utils.InitUIObject(scrollArea, transform);

        RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
		scrollAreaTransform.localScale = new Vector3(1f, 1f, 1f);
		scrollAreaTransform.anchorMin  = new Vector2(0f, 0f);
		scrollAreaTransform.anchorMax  = new Vector2(0f, 1f);
		
		// Create content for ScrollArea object
        GameObject scrollAreaContent = new GameObject("Content");
        Utils.InitUIObject(scrollAreaContent, scrollArea.transform);

        RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();        
		scrollAreaContentTransform.localScale = new Vector3(1f, 1f, 1f);
        scrollAreaContentTransform.anchorMin  = new Vector2(0f, 0f);
        scrollAreaContentTransform.anchorMax  = new Vector2(0f, 1f);

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
			button.onClick.AddListener(() => menuItem.Data.OnClick());
			#endregion
			#endregion

			//***************************************************************************
			// Text GameObject
			//***************************************************************************
			#region Text GameObject
			GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject;

			#region Text Component
			Text text = menuItemText.GetComponent<Text>();
			Utils.InitTextObject(text, menuItem.Data.Name); // TODO: Translate
			#endregion
			#endregion

			#region Calculating button size
			float buttonWidth = text.preferredWidth + 12;

			menuItemButtonTransform.anchoredPosition3D = new Vector3(contentWidth + buttonWidth / 2, 0f, 0f);
			menuItemButtonTransform.sizeDelta          = new Vector2(buttonWidth, 0f);
			
			contentWidth += buttonWidth;
			#endregion
        }

		scrollAreaTransform.anchoredPosition3D        = new Vector3(contentWidth / 2, 0f, 0f);
		scrollAreaTransform.sizeDelta                 = new Vector2(contentWidth, 0f);
		
		scrollAreaContentTransform.anchoredPosition3D = new Vector3(contentWidth / 2, 0f, 0f);
        scrollAreaContentTransform.sizeDelta          = new Vector2(contentWidth, 0f);

		// Allow to scroll content
		ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();

		scrollAreaScrollRect.content  = scrollAreaContentTransform;
		scrollAreaScrollRect.vertical = false;
	}

    public void OnShowMenuSubItems()
    {
		Debug.Log("OnShowMenuSubItems");
    }

	#region File
	public void OnNewScene()
	{
		Debug.Log("OnNewScene");
		// TODO: Implement MainMenuScript.OnNewScene
	}

	public void OnOpenScene()
	{
		Debug.Log("OnOpenScene");
		// TODO: Implement MainMenuScript.OnOpenScene
	}

	public void OnSaveScene()
	{
		Debug.Log("OnSaveScene");
		// TODO: Implement MainMenuScript.OnSaveScene
	}

	public void OnSaveSceneAs()
	{
		Debug.Log("OnSaveSceneAs");
		// TODO: Implement MainMenuScript.OnSaveSceneAs
	}

	public void OnNewProject()
	{
		Debug.Log("OnNewProject");
		// TODO: Implement MainMenuScript.OnNewProject
	}
	
	public void OnOpenProject()
	{
		Debug.Log("OnOpenProject");
		// TODO: Implement MainMenuScript.OnOpenProject
	}
	
	public void OnSaveProject()
	{
		Debug.Log("OnSaveProject");
		// TODO: Implement MainMenuScript.OnSaveProject
	}
	
	public void OnBuildSettings()
	{
		Debug.Log("OnBuildSettings");
		// TODO: Implement MainMenuScript.OnBuildSettings
	}
	
	public void OnBuildAndRun()
	{
		Debug.Log("OnBuildAndRun");
		// TODO: Implement MainMenuScript.OnBuildAndRun
	}
	
	public void OnExit()
	{
		Debug.Log("OnExit");
		Application.Quit();
	}
	#endregion
}
