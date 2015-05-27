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

                Global.popupMenuAreaScript.DeregisterPopupMenu(this);

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
				Global.popupMenuAreaScript.RegisterPopupMenu(this);

                //***************************************************************************
                // PopupMenu GameObject
                //***************************************************************************
                #region PopupMenu GameObject
                mGameObject = new GameObject("PopupMenu");
				Utils.InitUIObject(mGameObject, Global.popupMenuAreaTransform);

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

                popupMenuImage.sprite = Assets.PopupMenuArea.Textures.popupBackground;
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
				// Content GameObject
                //***************************************************************************
				#region Content GameObject
                GameObject scrollAreaContent = new GameObject("Content");
                Utils.InitUIObject(scrollAreaContent, scrollArea.transform);

                //===========================================================================
                // RectTransform Component
                //===========================================================================
                #region RectTransform Component
                RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();
                #endregion

				float contentWidth  = 0f;
				float contentHeight = 0f;

				//===========================================================================
				// Fill content
				//===========================================================================
				#region Fill content
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

						Utils.AlignRectTransformTopStretch(menuItemSeparatorTransform, separatorHeight, contentHeight, 28f); // TODO: Incorrect position

                        contentHeight += separatorHeight;
                        #endregion

                        //===========================================================================
                        // Image Component
                        //===========================================================================
                        #region Image Component
                        Image image = menuSeparator.AddComponent<Image>();

                        image.sprite = Assets.PopupMenuArea.Textures.separator;
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
							menuItemButton = UnityEngine.Object.Instantiate(Assets.PopupMenuArea.Prefabs.button) as GameObject; // TODO: Try to do the same without prefabs
                        }
                        else
                        {
							menuItemButton = UnityEngine.Object.Instantiate(Assets.PopupMenuArea.Prefabs.buttonDisabled) as GameObject; // TODO: Try to do the same without prefabs
                        }

                        Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
                        menuItemButton.name = item.Name;

                        //===========================================================================
                        // RectTransform Component
                        //===========================================================================
                        #region RectTransform Component
                        RectTransform menuItemButtonTransform = menuItemButton.GetComponent<RectTransform>();
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

								button.onClick.AddListener(Global.popupMenuAreaScript.DestroyAll);                                
                            }
                        }
                        #endregion
                        #endregion

                        //***************************************************************************
                        // Text GameObject
                        //***************************************************************************
                        #region Text GameObject
                        GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject; // Button/Text

						//===========================================================================
						// Text Component
						//===========================================================================
                        #region Text Component
                        Text text = menuItemText.GetComponent<Text>();
                        text.text = item.Text;
                        #endregion
                        #endregion

                        float buttonWidth  = text.preferredWidth  + 44;
                        float buttonHeight = text.preferredHeight + 8;

						Utils.AlignRectTransformTopStretch(menuItemButtonTransform, buttonHeight, contentHeight);

                        if (buttonWidth > contentWidth)
                        {
                            contentWidth = buttonWidth;
                        }

                        contentHeight += buttonHeight;
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

								Utils.AlignRectTransformStretchRight(shortcutTextTransform, shortcutWidth, 4);
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

								Utils.AlignRectTransformStretchRight(arrowTransform, arrowWidth, 4, 3, 3);
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
								
								arrowImage.sprite = Assets.PopupMenuArea.Textures.arrow;
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

							Utils.AlignRectTransformStretchLeft(checkboxTransform, checkboxWidth);
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
							
							checkboxImage.sprite = Assets.PopupMenuArea.Textures.checkbox;
							checkboxImage.type   = Image.Type.Sliced;
							#endregion
							#endregion
						}
					}
				}
				#endregion
				#endregion

				Utils.AlignRectTransformTopStretch(scrollAreaContentTransform, contentHeight);
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
				
				scrollAreaImage.sprite = Assets.PopupMenuArea.Textures.background;
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

				Utils.FitRectTransformToScreen(popupMenuTransform, popupMenuWidth, popupMenuHeight, x, y, left, bottom);
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
