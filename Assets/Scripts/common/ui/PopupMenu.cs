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
			/// <param name="left">Left edge for button of parent popup if present.</param>
			/// <param name="bottom">Bottom edge for button of parent popup if present.</param>
			public void Show(float x, float y, float left = -1, float bottom = -1)
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

                popupMenuImage.sprite = Global.PopupMenuArea.popupBackground;
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
                Utils.AlignRectTransformStretchStretch(scrollAreaTransform, 3f, 8f, 8f, 3f);
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
						menuItemSeparatorTransform.pivot              = new Vector2(0.5f, 0.5f);
                        menuItemSeparatorTransform.anchoredPosition3D = new Vector3(0f, -contentHeight - separatorHeight / 2, 0f); // TODO: Incorrect position
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

						bool hasChildren = menuItem.HasChildren();
						bool enabled     = item.Enabled && (hasChildren || item.OnClick != null);

                        //***************************************************************************
                        // Button GameObject
                        //***************************************************************************
                        #region Button GameObject
                        GameObject menuItemButton;

						if (enabled)
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

						if (enabled)
						{
                            if (hasChildren)
                            {
								TreeNode<CustomMenuItem> currentMenuItem = menuItem;
								
								button.onClick.AddListener(() => OnShowMenuSubItems(currentMenuItem));
                            }
                            else
                            {
								button.onClick.AddListener(item.OnClick);

								if (item.RadioGroup != null)
								{
									button.onClick.AddListener(() => OnSelectItem(item));
								}

								button.onClick.AddListener(Global.PopupMenuArea.DestroyAll);                                
                            }
                        }
                        #endregion
                        #endregion

                        //***************************************************************************
                        // Text GameObject
                        //***************************************************************************
                        #region Text GameObject
                        GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject; // Button/Text

						//***************************************************************************
						// Text Component
						//***************************************************************************
                        #region Text Component
                        Text text = menuItemText.GetComponent<Text>();
                        text.text = item.Text;
                        #endregion
                        #endregion

						//***************************************************************************
						// Calculating button geometry
						//***************************************************************************
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
							Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(i);

							//***************************************************************************
							// Text GameObject
							//***************************************************************************
                            #region Text GameObject
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
								Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(i);

								//***************************************************************************
								// Text GameObject
								//***************************************************************************
								#region Text GameObject								
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

								shortcutTextTransform.anchoredPosition3D = new Vector3(-shortcutWidth / 2 - 4, 0f, 0f);
								shortcutTextTransform.sizeDelta          = new Vector2(shortcutWidth, 0f);
                                #endregion
								#endregion
                            }
                        }
                    }
                    
					contentWidth += shortcutWidth + 8;
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
						if (menuItems[i].HasChildren())
						{
							arrowWidth = 16f;

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
							Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(i);

							//***************************************************************************
							// Text GameObject
							//***************************************************************************
							#region Text GameObject							
							GameObject menuItemText = menuItemButtonTransform.GetChild(0).gameObject; // Button/Text
							GameObject shortcutText = null;

							if (menuItemButtonTransform.childCount > 1)
							{
								shortcutText = menuItemButtonTransform.GetChild(1).gameObject; // Button/Text
							}								
							
							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform menuItemTextTransform = menuItemText.GetComponent<RectTransform>();
							
							menuItemTextTransform.offsetMax = new Vector2(menuItemTextTransform.offsetMax.x - arrowWidth, 0f);
							#endregion

							if (shortcutText != null)
							{
								//===========================================================================
								// RectTransform Component
								//===========================================================================
								#region RectTransform Component
								RectTransform shortcutTextTransform = shortcutText.GetComponent<RectTransform>();

								shortcutTextTransform.offsetMin = new Vector2(shortcutTextTransform.offsetMin.x - arrowWidth, 0f);
								shortcutTextTransform.offsetMax = new Vector2(shortcutTextTransform.offsetMax.x - arrowWidth, 0f);
                                #endregion
                            }
                            #endregion
                            
                            if (menuItems[i].HasChildren())
							{
								//***************************************************************************
								// Image GameObject
								//***************************************************************************
								#region Image GameObject
								GameObject arrow = new GameObject("Arrow");
								Utils.InitUIObject(arrow, menuItemButtonTransform);
								
								//===========================================================================
								// RectTransform Component
								//===========================================================================
								#region RectTransform Component
								RectTransform arrowTransform = arrow.AddComponent<RectTransform>();
								
								arrowTransform.localScale         = new Vector3(1f, 1f, 1f);
								arrowTransform.anchorMin          = new Vector2(1f, 0f);
								arrowTransform.anchorMax          = new Vector2(1f, 1f);
								arrowTransform.pivot              = new Vector2(0.5f, 0.5f);
								arrowTransform.anchoredPosition3D = new Vector3(-arrowWidth / 2 - 4, 0f, 0f);
								arrowTransform.sizeDelta          = new Vector2(arrowWidth, 0f);
								arrowTransform.offsetMin          = new Vector2(arrowTransform.offsetMin.x, 3f);
								arrowTransform.offsetMax          = new Vector2(arrowTransform.offsetMax.x, -3f);
                                #endregion

								//===========================================================================
								// CanvasRenderer Component
								//===========================================================================
								#region CanvasRenderer Component
								arrow.AddComponent<CanvasRenderer>();
								#endregion
								
								//===========================================================================
								// Image Component
								//===========================================================================
								#region Image Component
								Image arrowImage = arrow.AddComponent<Image>();
								
								arrowImage.sprite = Global.PopupMenuArea.arrow;
								arrowImage.type   = Image.Type.Sliced;
								#endregion
								#endregion
                            }
                        }
                    }
                    
                    contentWidth += arrowWidth + 8;
				}
				#endregion

				//***************************************************************************
				// Checkbox
				//***************************************************************************
				#region Checkbox
				float checkboxWidth = 22f;

				for (int i = 0; i < menuItems.Count; ++i)
				{
					if (menuItems[i].Data is MenuItem)
					{
						MenuItem item = menuItems[i].Data as MenuItem;

						if (item.RadioGroup != null && item.RadioGroup.SelectedItem == item)
						{
							Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(i);

							//***************************************************************************
							// Image GameObject
							//***************************************************************************
							#region Image GameObject
							GameObject checkbox = new GameObject("Checkbox");
							Utils.InitUIObject(checkbox, menuItemButtonTransform);
							
							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform checkboxTransform = checkbox.AddComponent<RectTransform>();
							
							checkboxTransform.localScale         = new Vector3(1f, 1f, 1f);
							checkboxTransform.anchorMin          = new Vector2(0f, 0f);
							checkboxTransform.anchorMax          = new Vector2(0f, 1f);
							checkboxTransform.pivot              = new Vector2(0.5f, 0.5f);
							checkboxTransform.anchoredPosition3D = new Vector3(checkboxWidth / 2, 0f, 0f);
							checkboxTransform.sizeDelta          = new Vector2(checkboxWidth, 0f);
							#endregion
							
							//===========================================================================
							// CanvasRenderer Component
							//===========================================================================
							#region CanvasRenderer Component
							checkbox.AddComponent<CanvasRenderer>();
							#endregion
							
							//===========================================================================
							// Image Component
							//===========================================================================
							#region Image Component
							Image checkboxImage = checkbox.AddComponent<Image>();
							
							checkboxImage.sprite = Global.PopupMenuArea.checkbox;
							checkboxImage.type   = Image.Type.Sliced;
							#endregion
							#endregion
						}
					}
				}
				#endregion
                
                scrollAreaContentTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                scrollAreaContentTransform.sizeDelta          = new Vector2(0f, contentHeight);
                #endregion

				//===========================================================================
				// ScrollRect Component
				//===========================================================================
                #region ScrollRect Component
                ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();

                scrollAreaScrollRect.content    = scrollAreaContentTransform;
                scrollAreaScrollRect.horizontal = false;
                #endregion

				//===========================================================================
				// CanvasRenderer Component
				//===========================================================================
				#region CanvasRenderer Component
				scrollArea.AddComponent<CanvasRenderer>();
				#endregion
				
				//===========================================================================
				// Image Component
				//===========================================================================
				#region Image Component
				Image scrollAreaImage = scrollArea.AddComponent<Image>();
				
				scrollAreaImage.sprite = Global.PopupMenuArea.background;
				scrollAreaImage.type   = Image.Type.Sliced;
				#endregion

				//===========================================================================
				// Mask Component
				//===========================================================================
				#region Mask Component
				scrollArea.AddComponent<Mask>();
				#endregion
                #endregion

				float popupMenuWidth  = contentWidth  + 11;
                float popupMenuHeight = contentHeight + 11;
				int   screenWidth     = Screen.width;
				int   screenHeight    = Screen.height;

				if (popupMenuWidth > screenWidth)
				{
					popupMenuWidth = screenWidth;
				}

				if (popupMenuHeight > screenHeight)
				{
					popupMenuHeight = screenHeight;
				}

				if (x + popupMenuWidth > screenWidth)
				{
					if (left != -1)
					{
						x = left - popupMenuWidth;

						if (x < 0)
						{
							x = screenWidth - popupMenuWidth;
						}
					}
					else
					{
						x = screenWidth - popupMenuWidth;
					}
				}

				if (y + popupMenuHeight > screenHeight)
				{
					if (bottom != -1)
					{
						y = bottom - popupMenuHeight;
						
						if (y < 0)
						{
							y = screenHeight - popupMenuHeight;
						}
					}
					else
					{
						y = screenHeight - popupMenuHeight;
					}
				}

				Utils.AlignRectTransformTopLeft(popupMenuTransform, popupMenuWidth, popupMenuHeight, x, y);
                #endregion
            }

			/// <summary>
			/// Handler for menu item selection.
			/// </summary>
			/// <param name="item">Item.</param>
			public void OnSelectItem(MenuItem item)
			{
				if (item.RadioGroup != null)
				{
					item.RadioGroup.SelectedItem = item;
				}
				else
				{
					Debug.LogError("Unexpected OnSelectItem call");
				}
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
	                
					mChildPopupMenu.Show(
						                 menuItemCorners[1].x,
						                 menuItemCorners[1].y,
					                     menuItemCorners[2].x,
					                     menuItemCorners[2].y
						                );
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
