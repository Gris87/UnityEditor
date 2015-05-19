using System;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



namespace common
{
    namespace ui
    {
        /// <summary>
        /// Popup menu.
        /// </summary>
        public class PopupMenu
        {
            private TreeNode<CustomMenuItem> mItems;
            private GameObject               mGameObject;
            private UnityEvent               mOnDestroy;

            private PopupMenu                mChildPopupMenu;



            /// <summary>
            /// Initializes a new instance of the <see cref="common.ui.PopupMenu"/> class with specified menu items.
            /// </summary>
            /// <param name="items">Items.</param>
            public PopupMenu(TreeNode<CustomMenuItem> items)
            {
                mItems          = items;
				mGameObject     = null;
                mOnDestroy      = new UnityEvent();

				mChildPopupMenu = null;
            }

            /// <summary>
            /// Destroy this instance.
            /// </summary>
            public void Destroy()
            {
                if (mChildPopupMenu != null)
                {
                    mChildPopupMenu.Destroy();
                    mChildPopupMenu = null;
                }

                if (mGameObject != null)
                {
                    UnityEngine.Object.Destroy(mGameObject);
                    mGameObject = null;
                }

                Global.PopupMenuArea.DeregisterPopupMenu(this);

                mOnDestroy.Invoke();
            }

            /// <summary>
            /// Show popup menu at the specified coordinates.
            /// </summary>
            /// <param name="x">The x coordinate.</param>
            /// <param name="y">The y coordinate.</param>
            public void Show(float x, float y)
            {
                Global.PopupMenuArea.RegisterPopupMenu(this);

                //***************************************************************************
                // PopupMenu GameObject
                //***************************************************************************
                #region PopupMenu GameObject
                mGameObject = new GameObject("PopupMenu");
                Utils.InitUIObject(mGameObject, Global.PopupMenuAreaTransform);

                //===========================================================================
                // RectTransform Component
                //===========================================================================
                #region RectTransform Component
                RectTransform popupMenuTransform = mGameObject.AddComponent<RectTransform>();

                popupMenuTransform.localScale = new Vector3(1f, 1f, 1f);
                popupMenuTransform.anchorMin  = new Vector2(0.5f, 0.5f);
                popupMenuTransform.anchorMax  = new Vector2(0.5f, 0.5f);
                popupMenuTransform.pivot      = new Vector2(0.5f, 0.5f);
                #endregion

                //===========================================================================
                // CanvasRenderer Component
                //===========================================================================
                #region CanvasRenderer Component
                mGameObject.AddComponent<CanvasRenderer>();
                #endregion

                //===========================================================================
                // Image Component
                //===========================================================================
                #region Image Component
                Image popupMenuImage = mGameObject.AddComponent<Image>();

                popupMenuImage.sprite = Global.PopupMenuArea.background;
                popupMenuImage.type   = Image.Type.Sliced;
                #endregion

                //***************************************************************************
                // ScrollArea GameObject
                //***************************************************************************
                #region ScrollArea GameObject
                GameObject scrollArea = new GameObject("ScrollArea");
                Utils.InitUIObject(scrollArea, mGameObject.transform);

                //===========================================================================
                // RectTransform Component
                //===========================================================================
                #region RectTransform Component
                RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
                Utils.AlignRectTransformFill(scrollAreaTransform);

                scrollAreaTransform.offsetMin = new Vector2(3f, 8f);
                scrollAreaTransform.offsetMax = new Vector2(-8f, -3f);
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
                scrollAreaContentTransform.anchorMin  = new Vector2(0f, 1f);
                scrollAreaContentTransform.anchorMax  = new Vector2(1f, 1f);
                scrollAreaContentTransform.pivot      = new Vector2(0.5f, 1f);
                #endregion

                // Fill content
                float contentWidth  = 0f;
                float contentHeight = 0f;

                // Create menu item buttons
				ReadOnlyCollection<TreeNode<CustomMenuItem>> menuItems = mItems.Children;

				foreach (TreeNode<CustomMenuItem> menuItem in menuItems)
                {
                    if (menuItem.Data is MenuSeparatorItem)
                    {
                        //***************************************************************************
                        // Separator GameObject
                        //***************************************************************************
                        #region Separator GameObject
                        GameObject menuSeparator = new GameObject("Separator");
                        Utils.InitUIObject(menuSeparator, scrollAreaContent.transform);

                        //===========================================================================
                        // RectTransform Component
                        //===========================================================================
                        #region RectTransform Component
                        float separatorHeight = 8;

                        RectTransform menuItemSeparatorTransform = menuSeparator.AddComponent<RectTransform>();

                        menuItemSeparatorTransform.localScale         = new Vector3(1f, 1f, 1f);
                        menuItemSeparatorTransform.anchorMin          = new Vector2(0f, 1f);
                        menuItemSeparatorTransform.anchorMax          = new Vector2(1f, 1f);
                        menuItemSeparatorTransform.anchoredPosition3D = new Vector3(0f, -contentHeight - separatorHeight / 2, 0f);
                        menuItemSeparatorTransform.sizeDelta          = new Vector2(0f, separatorHeight);
                        menuItemSeparatorTransform.offsetMin          = new Vector2(28f, menuItemSeparatorTransform.offsetMin.y);

                        contentHeight += separatorHeight;
                        #endregion

                        //===========================================================================
                        // Image Component
                        //===========================================================================
                        #region Image Component
                        Image image = menuSeparator.AddComponent<Image>();

                        image.sprite = Global.PopupMenuArea.separator;
                        #endregion
                        #endregion
                    }
                    else
				    if (menuItem.Data is MenuItem)
                    {
						MenuItem item = menuItem.Data as MenuItem;

                        //***************************************************************************
                        // Button GameObject
                        //***************************************************************************
                        #region Button GameObject
                        GameObject menuItemButton;

                        if (item.Enabled)
                        {
                            menuItemButton = UnityEngine.Object.Instantiate(Global.PopupMenuArea.itemButton.gameObject) as GameObject;
                        }
                        else
                        {
                            menuItemButton = UnityEngine.Object.Instantiate(Global.PopupMenuArea.itemButtonDisabled.gameObject) as GameObject;
                        }

                        Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
                        menuItemButton.name = item.Name;

                        //===========================================================================
                        // RectTransform Component
                        //===========================================================================
                        #region RectTransform Component
                        RectTransform menuItemButtonTransform = menuItemButton.GetComponent<RectTransform>();

                        menuItemButtonTransform.localScale = new Vector3(1f, 1f, 1f);
                        menuItemButtonTransform.anchorMin  = new Vector2(0f, 1f);
                        menuItemButtonTransform.anchorMax  = new Vector2(1f, 1f);
                        #endregion

                        //===========================================================================
                        // Button Component
                        //===========================================================================
                        #region Button Component
                        Button button = menuItemButton.GetComponent<Button>();

                        if (item.Enabled)
                        {
                            ReadOnlyCollection<TreeNode<CustomMenuItem>> children = menuItem.Children;

                            if (children == null || children.Count == 0)
                            {
                                button.onClick.AddListener(item.OnClick);
                                button.onClick.AddListener(Global.PopupMenuArea.DestroyAll);
                            }
                            else
                            {
                                TreeNode<CustomMenuItem> currentMenuItem = menuItem;

                                button.onClick.AddListener(() => OnShowMenuSubItems(currentMenuItem));
                            }
                        }
                        #endregion
                        #endregion

                        //***************************************************************************
                        // Text GameObject
                        //***************************************************************************
                        #region Text GameObject
                        GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject; // Button/Text

                        #region Text Component
                        Text text = menuItemText.GetComponent<Text>();
                        text.text = item.Text;
                        #endregion
                        #endregion

                        #region Calculating button geometry
                        float buttonWidth  = text.preferredWidth  + 44;
                        float buttonHeight = text.preferredHeight + 8;

                        menuItemButtonTransform.anchoredPosition3D = new Vector3(0f, -contentHeight - buttonHeight / 2, 0f);
                        menuItemButtonTransform.sizeDelta          = new Vector2(0f, buttonHeight);

                        if (buttonWidth > contentWidth)
                        {
                            contentWidth = buttonWidth;
                        }

                        contentHeight += buttonHeight;
                        #endregion
                    }
					else
					{
						Debug.LogError("Unknown menu item type");
					}
                }

				//***************************************************************************
				// Shortcuts
				//***************************************************************************
				#region Shortcuts
                float shortcutWidth = 0f;

				for (int i = 0; i < menuItems.Count; ++i)
				{
					if (menuItems[i].Data is MenuItem)
					{
						MenuItem item   = menuItems[i].Data as MenuItem;
						string shortcut = item.Shortcut;

						if (shortcut != null)
						{
							//***************************************************************************
							// Text GameObject
							//***************************************************************************
                            #region Text GameObject
                            Transform menuItemButtonTransform = mGameObject.transform.GetChild(0).GetChild(0).GetChild(i); // ScrollArea/Content/NODE
							
							GameObject menuItemText = menuItemButtonTransform.GetChild(0).gameObject; // Button/Text
							GameObject shortcutText = UnityEngine.Object.Instantiate(menuItemText) as GameObject;								
							
							Utils.InitUIObject(shortcutText, menuItemButtonTransform);
                            shortcutText.name = "Shortcut";

							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform shortcutTextTransform = shortcutText.GetComponent<RectTransform>();
							
							shortcutTextTransform.localScale = new Vector3(1f, 1f, 1f);
							shortcutTextTransform.anchorMin  = new Vector2(1f, 0f);
							shortcutTextTransform.anchorMax  = new Vector2(1f, 1f);
							#endregion
							
							//===========================================================================
							// Text Component
							//===========================================================================
							#region Text Component
							Text text      = shortcutText.GetComponent<Text>();
							text.text      = shortcut;
							text.alignment = TextAnchor.MiddleRight;

							float shortcutTextWidth = text.preferredWidth;
							
							if (shortcutTextWidth > shortcutWidth)
							{
								shortcutWidth = shortcutTextWidth;
							}
                            #endregion
                            #endregion
                        }
                    }
                }
                
                if (shortcutWidth > 0f)
                {
                    for (int i = 0; i < menuItems.Count; ++i)
                    {
                        if (menuItems[i].Data is MenuItem)
                        {
                            MenuItem item   = menuItems[i].Data as MenuItem;
                            string shortcut = item.Shortcut;
                            
                            if (shortcut != null)
                            {
								//***************************************************************************
								// Text GameObject
								//***************************************************************************
								#region Text GameObject
								Transform menuItemButtonTransform = mGameObject.transform.GetChild(0).GetChild(0).GetChild(i); // ScrollArea/Content/NODE
								
								GameObject menuItemText = menuItemButtonTransform.GetChild(0).gameObject; // Button/Text
								GameObject shortcutText = menuItemButtonTransform.GetChild(1).gameObject; // Button/Text

								//===========================================================================
								// RectTransform Component
								//===========================================================================
								#region RectTransform Component
								RectTransform menuItemTextTransform = menuItemText.GetComponent<RectTransform>();
								
								menuItemTextTransform.offsetMax = new Vector2(-shortcutWidth, 0f);
                                #endregion

								//===========================================================================
								// RectTransform Component
								//===========================================================================
								#region RectTransform Component
								RectTransform shortcutTextTransform = shortcutText.GetComponent<RectTransform>();

								shortcutTextTransform.anchoredPosition3D = new Vector3(-shortcutWidth / 2 - 4, 0f, 0f); // TODO: Need to check 4
								shortcutTextTransform.sizeDelta          = new Vector2(shortcutWidth, 0f);
                                #endregion
								#endregion
                            }
                        }
                    }
                    
					contentWidth += shortcutWidth + 8; // TODO: Need to check 8 and check whole image
                }
                #endregion

				//***************************************************************************
				// Arrow
				//***************************************************************************
				#region Arrow
				float arrowWidth = 0f;
				
				for (int i = 0; i < menuItems.Count; ++i)
				{
					if (menuItems[i].Data is MenuItem)
					{
						ReadOnlyCollection<TreeNode<CustomMenuItem>> children = mItems.Children;

						if (children != null && children.Count > 0)
						{
							arrowWidth = 32f;

							break;
						}
					}
				}
				
				if (arrowWidth > 0f)
				{
					for (int i = 0; i < menuItems.Count; ++i)
					{
						if (menuItems[i].Data is MenuItem)
						{
							// TODO: Complete it

							ReadOnlyCollection<TreeNode<CustomMenuItem>> children = mItems.Children;
							
                            if (children != null && children.Count > 0)
                            {
							}
						}
					}

					contentWidth += arrowWidth + 8; // TODO: Need to check 8 and check whole image
				}
				#endregion
                
                scrollAreaContentTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                scrollAreaContentTransform.sizeDelta          = new Vector2(0f, contentHeight);
                #endregion

                #region ScrollRect Component
                ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>(); // TODO: Add Mask

                scrollAreaScrollRect.content    = scrollAreaContentTransform;
                scrollAreaScrollRect.horizontal = false;
                #endregion
                #endregion

                float popupMenuWidth  = contentWidth  + 12; // TODO: Calculate popup menu size related to window size
                float popupMenuHeight = contentHeight + 12;

				// TODO: Shall use top-left corner as pivot
                popupMenuTransform.anchoredPosition3D = new Vector3(x + popupMenuWidth / 2, y - popupMenuHeight / 2, 0f); // TODO: Move popup menu when needed
                popupMenuTransform.sizeDelta          = new Vector2(popupMenuWidth, popupMenuHeight);
                #endregion
            }

            /// <summary>
            /// Creates and displays popup menu for specified menu item.
            /// </summary>
            /// <param name="node"><see cref="common.TreeNode`1"/> instance.</param>
            public void OnShowMenuSubItems(TreeNode<CustomMenuItem> node)
            {
				if (node.Data is MenuItem)
				{
					MenuItem item = node.Data as MenuItem;
	                Debug.Log("PopupMenu.OnShowMenuSubItems(" + item.Name + ")");
	                
	                if (mChildPopupMenu != null)
	                {
	                    mChildPopupMenu.Destroy();
	                }
	                
	                mChildPopupMenu = new PopupMenu(node);
	                mChildPopupMenu.OnDestroy.AddListener(OnPopupMenuDestroyed);

					int index = node.Parent.Children.IndexOf(node);

					RectTransform menuItemTransform = mGameObject.transform.GetChild(0).GetChild(0).GetChild(index).GetComponent<RectTransform>(); // ScrollArea/Content/NODE
	                Vector3[] menuItemCorners = Utils.GetWindowCorners(menuItemTransform);
	                
	                mChildPopupMenu.Show(menuItemCorners[2].x, menuItemCorners[2].y); // TODO: Add alternative positions (All 4 corners)
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
                Debug.Log("PopupMenu.OnPopupMenuDestroyed");
                
                mChildPopupMenu = null;
			}
			
			/// <summary>
			/// Gets the menu items.
			/// </summary>
			/// <value>The menu items.</value>
			public TreeNode<CustomMenuItem> items
			{
				get { return mItems; }
			}
			
			/// <summary>
			/// Gets the destroy event handler.
			/// </summary>
			/// <value>The destroy event handler.</value>
			public UnityEvent OnDestroy
			{
				get { return mOnDestroy; }
			}
        }
    }
}
