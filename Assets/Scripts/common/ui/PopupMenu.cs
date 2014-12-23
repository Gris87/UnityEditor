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
			private static float TIME_TO_LIVE = 30; // TODO: Change to 3



			private TreeNode<MenuItem> mItems      = null;
			private GameObject         mPopupMenu  = null;
			private UnityEvent         mOnDestroy  = null;
			private float              mTimerStart = 0;



			public PopupMenu(TreeNode<MenuItem> items)
			{
				mItems     = items;
				mOnDestroy = new UnityEvent();
			}

			public void Update()
			{
				float curTime = Time.realtimeSinceStartup;

				if (curTime >= mTimerStart + TIME_TO_LIVE)
				{
					Destroy();
				}
			}

			public void Destroy()
			{
				Debug.Log("PopupMenu.Destroy");

				if (mPopupMenu != null)
				{
					UnityEngine.Object.Destroy(mPopupMenu);
					mPopupMenu = null;
				}

				mOnDestroy.Invoke();
			}

			public void Show(float x, float y)
			{
				RestartTimer();

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
				popupMenuTransform.anchorMin  = new Vector2(0f, 1f);
				popupMenuTransform.anchorMax  = new Vector2(0f, 1f);
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
				float contentWidth  = 100f; // TODO: Calculate content size
				float contentHeight = 100f;

				scrollAreaContentTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
				scrollAreaContentTransform.sizeDelta          = new Vector2(contentWidth, contentHeight);
				#endregion
				
				#region ScrollRect Component
				ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();
				
				scrollAreaScrollRect.content    = scrollAreaContentTransform;
				scrollAreaScrollRect.horizontal = false;
				#endregion
				#endregion

				float popupMenuWidth  = 100f; // TODO: Calculate popup menu size
				float popupMenuHeight = 100f;

				popupMenuTransform.anchoredPosition3D = new Vector3(x + popupMenuWidth / 2, y - popupMenuHeight / 2, 0f);
				popupMenuTransform.sizeDelta          = new Vector2(popupMenuWidth, popupMenuHeight);
				#endregion
			}

			private void RestartTimer()
			{
				mTimerStart = Time.realtimeSinceStartup;
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
