using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using common;
using ui;



public class MainMenuScript : MonoBehaviour
{
    public Sprite buttonHighlighted;
    public Sprite buttonPressed;

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
            TreeNode<MenuItem> node = MenuItem.Create(mItems, "File", OnShowMenuSubItems);
            Debug.Log(node);
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

        // Create menu item buttons
        foreach (TreeNode<MenuItem> menuItem in mItems.Children)
        {
            //***************************************************************************
            // Button GameObject
            //***************************************************************************
            #region Button GameObject
            GameObject menuItemButton = new GameObject(menuItem.Data.Name);
            Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            float buttonWidth = 100f;

            RectTransform menuItemButtonTransform = menuItemButton.AddComponent<RectTransform>();

            menuItemButtonTransform.localScale         = new Vector2(1f, 1f);
            menuItemButtonTransform.anchorMin          = new Vector2(0f, 0f);
            menuItemButtonTransform.anchorMax          = new Vector2(0f, 1f);
            menuItemButtonTransform.anchoredPosition3D = new Vector3(contentWidth + buttonWidth / 2, 0f, 0f);
            menuItemButtonTransform.sizeDelta          = new Vector2(buttonWidth, 0f);

            contentWidth += buttonWidth;
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            menuItemButton.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image image = menuItemButton.AddComponent<Image>();

            image.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button
            //===========================================================================
            #region Button Component
            Button button = menuItemButton.AddComponent<Button>();

            button.interactable = menuItem.Data.Enabled;
            button.transition   = Selectable.Transition.SpriteSwap;
            #endregion
            #endregion

            //***************************************************************************
            // Text GameObject
            //***************************************************************************
            #region Text GameObject
            GameObject menuItemText = new GameObject("Text");
            Utils.InitUIObject(menuItemText, menuItemButton.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component            
            RectTransform menuItemTextTransform = menuItemText.AddComponent<RectTransform>();
            Utils.AlignRectTransformFill(menuItemTextTransform);
            #endregion
            
            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            menuItemText.AddComponent<CanvasRenderer>();
            #endregion
            
            //===========================================================================
            // Image Component
            //===========================================================================
            #region Text Component
            Text text = menuItemText.AddComponent<Text>();
            Utils.InitTextObject(text, menuItem.Data.Name); // TODO: Translate
            #endregion
            #endregion
        }
        
        scrollAreaContentTransform.anchoredPosition3D = new Vector3(contentWidth / 2, 0f, 0f);
        scrollAreaContentTransform.sizeDelta          = new Vector2(contentWidth, 0f);
	}

    public void OnShowMenuSubItems()
    {
    }
}
