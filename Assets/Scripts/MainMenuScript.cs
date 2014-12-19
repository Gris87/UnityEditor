using UnityEngine;
using System.Collections;

using common;
using ui;



public class MainMenuScript : MonoBehaviour
{
    private TreeNode<MenuItem> mItems;



	// Use this for initialization
	void Start()
	{
        CreateMenuItems();
		CreateUI();
	}

    private void CreateMenuItems()
    {
        mItems = new TreeNode<MenuItem>(new MenuItem());

        // File
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "File", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }

        // Edit
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Edit", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }

        // Assets
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Assets", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }

        // GameObject
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "GameObject", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }

        // Component
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Component", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }

        // Window
        {
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Window", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }

        // Help
        {
            // TODO: Translate
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "Help", OnShowMenuSubItemsDown);
            Debug.Log(node);
        }
    }

	private void CreateUI()
	{
        // Create ScrollArea object
        GameObject scrollArea = new GameObject("ScrollArea");
        Utils.InitUIObject(scrollArea, transform);

        RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
        Utils.AlignRectTransformFill(scrollAreaTransform);

        // Create content for ScrollArea object
        GameObject scrollAreaContent = new GameObject("Content");
        Utils.InitUIObject(scrollAreaContent, scrollArea.transform);

        RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();        
        scrollAreaContentTransform.localScale = new Vector2(1f, 1f);
        scrollAreaContentTransform.anchorMin  = new Vector2(0f, 0f);
        scrollAreaContentTransform.anchorMax  = new Vector2(0f, 1f);

        // Fill content
        float contentWidth = 0f;

        foreach (TreeNode<MenuItem> menuItem in mItems.Children)
        {
            // Create menu item buttons
            GameObject menuButton = new GameObject(menuItem.Data.Name);
            Utils.InitUIObject(menuButton, scrollAreaContent.transform);

            float buttonWidth = 100f;

            RectTransform menuButtonTransform = menuButton.AddComponent<RectTransform>();

            menuButtonTransform.localScale         = new Vector2(1f, 1f);
            menuButtonTransform.anchorMin          = new Vector2(0f, 0f);
            menuButtonTransform.anchorMax          = new Vector2(0f, 1f);
            menuButtonTransform.anchoredPosition3D = new Vector3(contentWidth + buttonWidth / 2, 0f, 0f);
            menuButtonTransform.sizeDelta          = new Vector2(buttonWidth, 0f);

            contentWidth += buttonWidth;
        }

        scrollAreaContentTransform.anchoredPosition3D = new Vector3(contentWidth / 2, 0f, 0f);
        scrollAreaContentTransform.sizeDelta          = new Vector2(contentWidth, 0f);
	}

    public void OnShowMenuSubItemsDown()
    {
    }
}
