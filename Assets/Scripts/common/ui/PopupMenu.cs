using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;



namespace common
{
	namespace ui
	{
		public class PopupMenu
		{
			private TreeNode<MenuItem> mItems      = null;
			private GameObject         mPopupMenu  = null;
			private UnityEvent         mOnDestroy  = null;



			public PopupMenu(TreeNode<MenuItem> items)
			{
				mItems     = items;
				mOnDestroy = new UnityEvent();
			}

			public void Destroy()
			{
				if (mPopupMenu != null)
				{
					UnityEngine.Object.Destroy(mPopupMenu);
					mPopupMenu = null;
				}

				Global.PopupMenuArea.DeregisterPopupMenu(this);

				mOnDestroy.Invoke();
			}

			public void Show(float x, float y)
			{
				Global.PopupMenuArea.RegisterPopupMenu(this);

				//***************************************************************************
				// PopupMenu GameObject
				//***************************************************************************
				#region PopupMenu GameObject
				mPopupMenu = new GameObject("PopupMenu");
				Utils.InitUIObject(mPopupMenu, Global.PopupMenuAreaTransform);

				//===========================================================================
				// RectTransform Component
				//===========================================================================
				#region RectTransform Component
				RectTransform popupMenuTransform = mPopupMenu.AddComponent<RectTransform>();

				popupMenuTransform.localScale = new Vector3(1f, 1f, 1f);
				popupMenuTransform.anchorMin  = new Vector2(0.5f, 0.5f);
				popupMenuTransform.anchorMax  = new Vector2(0.5f, 0.5f);
				popupMenuTransform.pivot      = new Vector2(0.5f, 0.5f);
				#endregion

				//===========================================================================
				// CanvasRenderer Component
				//===========================================================================
				#region CanvasRenderer Component
				mPopupMenu.AddComponent<CanvasRenderer>();
				#endregion

				//===========================================================================
				// Image Component
				//===========================================================================
				#region Image Component
				Image popupMenuImage = mPopupMenu.AddComponent<Image>();
				
				popupMenuImage.sprite = Global.PopupMenuArea.background;
				popupMenuImage.type   = Image.Type.Sliced;
				#endregion

				//***************************************************************************
				// ScrollArea GameObject
				//***************************************************************************
				#region ScrollArea GameObject
				GameObject scrollArea = new GameObject("ScrollArea");
				Utils.InitUIObject(scrollArea, mPopupMenu.transform);
				
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
				float contentWidth  = 0f; // TODO: Calculate content size
				float contentHeight = 0f;

				// Create menu item buttons
				foreach (TreeNode<MenuItem> menuItem in mItems.Children)
				{
					if (menuItem.Data.IsSeparator)
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
					{
						//***************************************************************************
						// Button GameObject
						//***************************************************************************
						#region Button GameObject
						GameObject menuItemButton;
						
						if (menuItem.Data.Enabled)
						{
							menuItemButton = UnityEngine.Object.Instantiate(Global.PopupMenuArea.itemButton.gameObject) as GameObject;
						}
						else
						{
							menuItemButton = UnityEngine.Object.Instantiate(Global.PopupMenuArea.itemButtonDisabled.gameObject) as GameObject;
						}
						
						Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
						menuItemButton.name = menuItem.Data.Name;
						
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
						
						if (menuItem.Data.Enabled)
						{
							button.onClick.AddListener(menuItem.Data.OnClick);
						}
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
				}

				scrollAreaContentTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
				scrollAreaContentTransform.sizeDelta          = new Vector2(0f, contentHeight);
				#endregion
				
				#region ScrollRect Component
				ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();
				
				scrollAreaScrollRect.content    = scrollAreaContentTransform;
				scrollAreaScrollRect.horizontal = false;
				#endregion
				#endregion

				float popupMenuWidth  = contentWidth  + 12; // TODO: Calculate popup menu size
				float popupMenuHeight = contentHeight + 12;

				popupMenuTransform.anchoredPosition3D = new Vector3(x + popupMenuWidth / 2, y - popupMenuHeight / 2, 0f);
				popupMenuTransform.sizeDelta          = new Vector2(popupMenuWidth, popupMenuHeight);
				#endregion
			}

			public TreeNode<MenuItem> items
			{
				get { return mItems; }
			}
						
			public UnityEvent OnDestroy
			{
				get { return mOnDestroy; }
			}
		}
	}
}
