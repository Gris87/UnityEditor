using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using Common.UI.MenuItems;



namespace Common.UI.Popups
{
	#region Internal namespace
	namespace Internal
	{
		/// <summary>
		/// Popup menu common things.
		/// </summary>
		static class PopupMenuCommon
		{
			public static SpriteState buttonSpriteState;
			public static SpriteState buttonDisabledSpriteState;
			public static Navigation  defaultNavigation;
			public static Navigation  noneNavigation;



			/// <summary>
			/// Initializes the <see cref="Common.UI.Popups.Internal.PopupMenuCommon"/> class.
			/// </summary>
			static PopupMenuCommon()
			{
				buttonSpriteState         = new SpriteState();
				buttonDisabledSpriteState = new SpriteState();
				
				buttonSpriteState.disabledSprite            = Assets.Popups.Textures.button;
				buttonSpriteState.highlightedSprite         = Assets.Popups.Textures.buttonHighlighted;
				buttonSpriteState.pressedSprite             = Assets.Popups.Textures.buttonHighlighted;
				
				buttonDisabledSpriteState.disabledSprite    = Assets.Popups.Textures.button;
				buttonDisabledSpriteState.highlightedSprite = Assets.Popups.Textures.buttonDisabled;
				buttonDisabledSpriteState.pressedSprite     = Assets.Popups.Textures.buttonDisabled;
				
				defaultNavigation   = Navigation.defaultNavigation;
				noneNavigation      = new Navigation();
				noneNavigation.mode = Navigation.Mode.None;
			}
		}
	}
	#endregion



	/// <summary>
	/// Popup menu.
	/// </summary>
	public class PopupMenu
	{
		private static float SHADOW_WIDTH     = 5f;
		private static float AUTO_POPUP_DELAY = 500f;
		
		
		
		private TreeNode<CustomMenuItem> mItems;
		private GameObject               mGameObject;
		private UnityEvent               mOnDestroy;
		
		private PopupMenu                mChildPopupMenu;
		
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.Popups.PopupMenu"/> class with specified menu items.
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
			
			Global.popupMenuAreaScript.DeregisterPopupMenu(this); // TODO: Remove Global from Common part
			
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
			Global.popupMenuAreaScript.RegisterPopupMenu(this); // TODO: Remove Global from Common part
			
			//***************************************************************************
			// PopupMenu GameObject
			//***************************************************************************
			#region PopupMenu GameObject
			mGameObject = new GameObject("PopupMenu");
			Utils.InitUIObject(mGameObject, Global.popupMenuAreaScript.transform); // TODO: Remove Global from Common part
			
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
			
			popupMenuImage.sprite = Assets.Popups.Textures.popupBackground;
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
			Utils.AlignRectTransformStretchStretch(
				                                     scrollAreaTransform
												   , popupMenuImage.sprite.border.x
												   , popupMenuImage.sprite.border.w
												   , popupMenuImage.sprite.border.z
												   , popupMenuImage.sprite.border.y
												  );
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
			ReadOnlyCollection<TreeNode<CustomMenuItem>> menuItems = mItems.children;
			
			foreach (TreeNode<CustomMenuItem> menuItem in menuItems)
			{
				if (menuItem.data.visible)
				{
					if (menuItem.data is MenuSeparatorItem)
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
						
						image.sprite = Assets.Popups.Textures.separator;
						#endregion
						#endregion
					}
					else
					if (menuItem.data is MenuItem)
					{
						MenuItem item = menuItem.data as MenuItem;
						
						bool hasChildren = menuItem.HasChildren();
						bool enabled     = item.enabled && (hasChildren || item.onClick != null);
						
						//***************************************************************************
						// Button GameObject
						//***************************************************************************
						#region Button GameObject
						GameObject menuItemButton = new GameObject(item.name);
						Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						RectTransform menuItemButtonTransform = menuItemButton.AddComponent<RectTransform>();
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
						Image menuItemButtonImage = menuItemButton.AddComponent<Image>();
						
						menuItemButtonImage.sprite = Assets.Popups.Textures.button;
						menuItemButtonImage.type   = Image.Type.Sliced;
						#endregion
						
						//===========================================================================
						// Button Component
						//===========================================================================
						#region Button Component
						Button menuItemButtonButton = menuItemButton.AddComponent<Button>();
						
						menuItemButtonButton.targetGraphic = menuItemButtonImage;
						menuItemButtonButton.transition    = Selectable.Transition.SpriteSwap;
						
						if (enabled)
						{
							menuItemButtonButton.spriteState = Internal.PopupMenuCommon.buttonSpriteState;
							menuItemButtonButton.navigation  = Internal.PopupMenuCommon.defaultNavigation;
							
							if (hasChildren)
							{
								TreeNode<CustomMenuItem> currentMenuItem = menuItem;
								
								menuItemButtonButton.onClick.AddListener(() => OnShowMenuSubItems(currentMenuItem));
								
								//===========================================================================
								// AutoPopupItemScript Component
								//===========================================================================
								#region AutoPopupItemScript Component
								AutoPopupItemScript menuItemButtonAutoPopup = menuItemButton.AddComponent<AutoPopupItemScript>();
								
								menuItemButtonAutoPopup.delay = AUTO_POPUP_DELAY;
								#endregion
							}
							else
							{
								menuItemButtonButton.onClick.AddListener(item.onClick);
								
								if (item.radioGroup != null)
								{
									menuItemButtonButton.onClick.AddListener(() => OnSelectItem(item));
								}
								
								menuItemButtonButton.onClick.AddListener(Global.popupMenuAreaScript.DestroyAll); // TODO: Remove Global from Common part
							}
						}
						else
						{
							menuItemButtonButton.spriteState = Internal.PopupMenuCommon.buttonDisabledSpriteState;
							menuItemButtonButton.navigation  = Internal.PopupMenuCommon.noneNavigation;
						}
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
						Utils.AlignRectTransformStretchStretch(menuItemTextTransform, Assets.Popups.Textures.background.border.x + 4f);
						#endregion
						
						//===========================================================================
						// Text Component
						//===========================================================================
						#region Text Component
						Text menuItemTextText      = menuItemText.AddComponent<Text>();

						menuItemTextText.font      = Assets.Common.Fonts.microsoftSansSerif;
						menuItemTextText.fontSize  = 12;
						menuItemTextText.alignment = TextAnchor.MiddleLeft;
						menuItemTextText.text      = item.text;
						
						if (enabled)
						{
							menuItemTextText.color = new Color(0f, 0f, 0f, 1f);
						}
						else
						{
							menuItemTextText.color = new Color(0.5f, 0.5f, 0.5f, 1f);
						}
						#endregion
						#endregion
						
						float buttonWidth  = menuItemTextText.preferredWidth + Assets.Popups.Textures.background.border.x + 16f;
						float buttonHeight = 22f; // TODO: Report request for prefferedHeight for specified width
						
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
			}
			
			//***************************************************************************
			// Shortcuts
			//***************************************************************************
			#region Shortcuts
			float shortcutWidth = 0f;
			int index = 0;
			
			for (int i = 0; i < menuItems.Count; ++i)
			{
				if (menuItems[i].data.visible)
				{
					if (menuItems[i].data is MenuItem)
					{
						MenuItem item   = menuItems[i].data as MenuItem;
						string shortcut = item.shortcut;
						
						if (shortcut != null)
						{
							Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(index);
							
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

					++index;
				}
			}
			
			if (shortcutWidth > 0f)
			{
				index = 0;

				for (int i = 0; i < menuItems.Count; ++i)
				{
					if (menuItems[i].data.visible)
					{
						if (menuItems[i].data is MenuItem)
						{
							MenuItem item   = menuItems[i].data as MenuItem;
							string shortcut = item.shortcut;
							
							if (shortcut != null)
							{
								Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(index);
								
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

						++index;
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
				if (menuItems[i].data.visible)
				{
					if (menuItems[i].data is MenuItem)
					{
						if (menuItems[i].HasChildren())
						{
							arrowWidth = 16f;
							
							break;
						}
					}
				}
			}
			
			if (arrowWidth > 0f)
			{
				index = 0;

				for (int i = 0; i < menuItems.Count; ++i)
				{
					if (menuItems[i].data.visible)
					{
						if (menuItems[i].data is MenuItem)
						{
							Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(index);
							
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
								
								arrowImage.sprite = Assets.Popups.Textures.arrow;
								arrowImage.type   = Image.Type.Sliced;
								#endregion
								#endregion
							}
						}

						++index;
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
			index = 0;
			
			for (int i = 0; i < menuItems.Count; ++i)
			{
				if (menuItems[i].data.visible)
				{
					if (menuItems[i].data is MenuItem)
					{
						MenuItem item = menuItems[i].data as MenuItem;
						
						if (item.radioGroup != null && item.radioGroup.selectedItem == item)
						{
							Transform menuItemButtonTransform = scrollAreaContentTransform.GetChild(index);
							
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
							
							checkboxImage.sprite = Assets.Popups.Textures.checkbox;
							checkboxImage.type   = Image.Type.Sliced;
							#endregion
							#endregion
						}
					}

					++index;
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
			
			scrollAreaImage.sprite = Assets.Popups.Textures.background;
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
			
			Utils.FitRectTransformToScreen(popupMenuTransform, popupMenuWidth, popupMenuHeight, x, y, left, bottom, SHADOW_WIDTH, SHADOW_WIDTH);
			#endregion
		}
		
		/// <summary>
		/// Handler for menu item selection.
		/// </summary>
		/// <param name="item">Item.</param>
		public void OnSelectItem(MenuItem item)
		{
			if (item.radioGroup != null)
			{
				item.radioGroup.selectedItem = item;
			}
			else
			{
				Debug.LogError("Unexpected OnSelectItem call");
			}
		}
		
		/// <summary>
		/// Creates and displays popup menu for specified menu item.
		/// </summary>
		/// <param name="node"><see cref="Common.TreeNode`1"/> instance.</param>
		public void OnShowMenuSubItems(TreeNode<CustomMenuItem> node)
		{
			if (node.data is MenuItem)
			{
				MenuItem item = node.data as MenuItem;
				Debug.Log("PopupMenu.OnShowMenuSubItems(" + item.name + ")");
				
				if (mChildPopupMenu != null)
				{
					mChildPopupMenu.Destroy();
				}
				
				mChildPopupMenu = new PopupMenu(node);
				mChildPopupMenu.OnDestroy.AddListener(OnPopupMenuDestroyed);
				
				int index = node.parent.children.IndexOf(node);
				
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
