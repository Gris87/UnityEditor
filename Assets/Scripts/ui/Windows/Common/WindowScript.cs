using UnityEngine;
using UnityEngine.UI;

using Common;



namespace UI.Windows.Common
{
	/// <summary>
	/// Script that realize behaviour for window.
	/// </summary>
	public class WindowScript : MonoBehaviour
	{
		private static float SHADOW_WIDTH = 15f;



		private WindowFrameTypes mFrame;
		private WindowStates     mState;
		private float            mX;
		private float            mY;
		private float            mWidth;
		private float            mHeight;

		private RectTransform    mWindowTransform;
		private GameObject       mBorderGameObject;
		private Image            mBorderImage;
		private RectTransform    mContentTransform;
		private float            mBorderLeft;
		private float            mBorderTop;
		private float            mBorderRight;
		private float            mBorderBottom;



		/// <summary>
		/// Gets or sets the window frame.
		/// </summary>
		/// <value>Window frame.</value>
		public WindowFrameTypes frame
		{
			get
			{
				return mFrame;
			}

			set
			{
				if (mFrame != value)
				{
					mFrame = value; // TODO: Implement this
				}
			}
		}

		/// <summary>
		/// Gets or sets the window state.
		/// </summary>
		/// <value>Window state.</value>
		public WindowStates state
		{
			get
			{
				return mState;
			}
			
			set
			{
				if (mState != value)
				{
					mState = value; // TODO: Implement this
				}
			}
		}

		/// <summary>
		/// Gets or sets the x coordinate.
		/// </summary>
		/// <value>The x coordinate.</value>
		public float x
		{
			get
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					return mX + SHADOW_WIDTH;
				}
				else
				{
					return mX;
				}
			}

			set
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					value -= SHADOW_WIDTH;
				}

				if (mX != value)
				{
					mX = value; // TODO: Implement this
				}
			}
		}

		/// <summary>
		/// Gets or sets the y coordinate.
		/// </summary>
		/// <value>The y coordinate.</value>
		public float y
		{
			get
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					return mY + SHADOW_WIDTH;
				}
				else
				{
					return mY;
				}
			}
			
			set
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					value -= SHADOW_WIDTH;
				}

				if (mY != value)
				{
					mY = value; // TODO: Implement this
				}
			}
		}

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>Window width.</value>
		public float width
		{
			get
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					return mWidth - SHADOW_WIDTH * 2;
				}
				else
				{
					return mWidth;
				}

				return mWidth;
			}
			
			set
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					value += SHADOW_WIDTH * 2;
				}

				if (mWidth != value)
				{
					mWidth = value; // TODO: Implement this
				}
			}
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>Window height.</value>
		public float height
		{
			get
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					return mHeight - SHADOW_WIDTH * 2;
				}
				else
				{
					return mHeight;
				}
				
				return mHeight;
			}
			
			set
			{
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					value += SHADOW_WIDTH * 2;
				}
				
				if (mHeight != value)
				{
					mHeight = value; // TODO: Implement this
				}
			}
		}

		/// <summary>
		/// Gets the real x coordinate.
		/// </summary>
		/// <value>Real x coordinate.</value>
		public float realX
		{
			get
			{
				if (mWindowTransform == null)
				{
					return 0;
				}
				
				if (mState == WindowStates.FullScreen || mState == WindowStates.Maximized)
				{
					return 0;
				}
				
				return x;
			}
		}
		
		/// <summary>
		/// Gets the real y cooordinate.
		/// </summary>
		/// <value>Real y coordinate.</value>
		public float realY
		{
			get
			{
				if (mWindowTransform == null)
				{
					return 0;
				}
				
				if (mState == WindowStates.FullScreen || mState == WindowStates.Maximized)
				{
					return 0;
				}
				
				return y;
			}
		}

		/// <summary>
		/// Gets the real width.
		/// </summary>
		/// <value>Real window width.</value>
		public float realWidth
		{
			get
			{
				if (mWindowTransform == null)
				{
					return 0;
				}

				if (mState == WindowStates.FullScreen || mState == WindowStates.Maximized)
				{
					return Screen.width;
				}

				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					return mWindowTransform.sizeDelta.x - SHADOW_WIDTH * 2;
				}
				else
				{
					return mWindowTransform.sizeDelta.x;
				}
			}
		}
		
		/// <summary>
		/// Gets the real height.
		/// </summary>
		/// <value>Real window height.</value>
		public float realHeight
		{
			get
			{
				if (mWindowTransform == null)
				{
					return 0;
				}
				
				if (mState == WindowStates.FullScreen || mState == WindowStates.Maximized)
				{
					return Screen.height;
				}
				
				if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
				{
					return mWindowTransform.sizeDelta.y - SHADOW_WIDTH * 2;
				}
				else
				{
					return mWindowTransform.sizeDelta.y;
				}
			}
		}

		// TODO: Content X/Y

		/// <summary>
		/// Gets the content width.
		/// </summary>
		/// <value>Content width.</value>
		public float contentWidth
		{
			get
			{
				if (mWindowTransform == null)
				{
					return 0;
				}

				if (mState == WindowStates.FullScreen)
				{
					return Screen.width;
				}

				if (mState == WindowStates.Maximized)
				{
					return Screen.width - mBorderLeft - mBorderRight;
				}
				
				return mWindowTransform.sizeDelta.x - mBorderLeft - mBorderRight;
			}
		}
		
		/// <summary>
		/// Gets the content height.
		/// </summary>
		/// <value>Content height.</value>
		public float contentHeight
		{
			get
			{
				if (mWindowTransform == null)
				{
					return 0;
				}

				if (mState == WindowStates.FullScreen)
				{
					return Screen.height;
				}
				
				if (mState == WindowStates.Maximized)
				{
					return Screen.height - mBorderTop - mBorderBottom; // TODO: Incorrect
				}
				
				return mWindowTransform.sizeDelta.y - mBorderTop - mBorderBottom;
			}
		}



		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.Common.WindowScript"/> class.
		/// </summary>
		public WindowScript()
			: base()
		{
			mFrame  = WindowFrameTypes.Window;
			mState  = WindowStates.NoState;
			mX      = 0f;
			mY      = 0f;
			mWidth  = 0f;
			mHeight = 0f;

			mWindowTransform  = null;
			mBorderGameObject = null;
			mBorderImage      = null;
			mContentTransform = null;
			mBorderLeft       = 0f;
			mBorderTop        = 0f;
			mBorderRight      = 0f;
			mBorderBottom     = 0f;

			Hide();
		}

		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			CreateUI();
		}

		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			mWindowTransform = gameObject.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(mWindowTransform);
			#endregion

			if (mFrame != WindowFrameTypes.Frameless && mState != WindowStates.FullScreen)
			{
				//***************************************************************************
				// Border GameObject
				//***************************************************************************
				#region Border GameObject
				mBorderGameObject = new GameObject("Border");
				Utils.InitUIObject(mBorderGameObject, transform);

				//===========================================================================
				// RectTransform Component
				//===========================================================================
				#region RectTransform Component
				RectTransform borderTransform = mBorderGameObject.AddComponent<RectTransform>();
				Utils.AlignRectTransformStretchStretch(borderTransform);
				#endregion
				
				//===========================================================================
				// CanvasRenderer Component
				//===========================================================================
				#region CanvasRenderer Component
				mBorderGameObject.AddComponent<CanvasRenderer>();
				#endregion
				
				//===========================================================================
				// Image Component
				//===========================================================================
				#region Image Component
				mBorderImage = mBorderGameObject.AddComponent<Image>();
				
				switch (mFrame)
				{
					case WindowFrameTypes.Window:
					{
						mBorderImage.sprite = Assets.Windows.Common.Textures.window;
					}
					break;
					case WindowFrameTypes.SubWindow:
					{
						mBorderImage.sprite = Assets.Windows.Common.Textures.subWindow;
					}
					break;
					case WindowFrameTypes.Drawer:
					{
						mBorderImage.sprite = Assets.Windows.Common.Textures.drawer;
					}
					break;
					default:
					{
						Debug.LogError("Unknown window frame");
					}
					break;
				}
				
				mBorderImage.type = Image.Type.Sliced;
				
				Vector4	borders = mBorderImage.sprite.border;
				
				mBorderLeft   = borders.x;
				mBorderTop    = borders.w;
				mBorderRight  = borders.z;
				mBorderBottom = borders.y;
				#endregion
				#endregion
			}
			else
			{
				mBorderLeft   = 0f;
				mBorderTop    = 0f;
				mBorderRight  = 0f;
				mBorderBottom = 0f;
			}
			
			float contentWidth  = 0f;
			float contentHeight = 0f;

			//***************************************************************************
			// Content GameObject
			//***************************************************************************
			#region Content GameObject
			GameObject content = new GameObject("Content");
			Utils.InitUIObject(content, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			mContentTransform = content.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(mContentTransform, mBorderLeft, mBorderTop, mBorderRight, mBorderBottom);
			#endregion

			CreateContent(content.transform, out contentWidth, out contentHeight);
			#endregion

			if (mWidth == 0 || mHeight == 0)
			{
				mWidth  = mBorderLeft + contentWidth  + mBorderRight;
				mHeight = mBorderTop  + contentHeight + mBorderBottom;
				mX      = (Screen.width  - mWidth)  / 2; // Screen.width  / 2 - mWidth / 2;
				mY      = (Screen.height - mHeight) / 2; // Screen.height / 2 - mHeight / 2;
			}

			switch (mState)
			{
				case WindowStates.NoState:
				{
					Utils.AlignRectTransformTopLeft(mWindowTransform, mWidth, mHeight, mX, mY);
				}
				break;
				case WindowStates.Minimized:
				{
					Utils.AlignRectTransformTopLeft(mWindowTransform, mWidth, mHeight, mX, mY);
				}
				break;
				case WindowStates.Maximized:
				{
					Utils.AlignRectTransformStretchStretch(mWindowTransform);
				}
				break;
				case WindowStates.FullScreen:
				{
					Utils.AlignRectTransformStretchStretch(mWindowTransform);
				}
				break;
				default:
				{
					Debug.LogError("Unknown window state");
				}
				break;
			}
		}

		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected virtual void CreateContent(Transform contentTransform, out float width, out float height)
		{
			// Nothing
			width  = 0;
			height = 0;
		}

		/// <summary>
		/// Destroy this instance.
		/// </summary>
		public void Destroy()
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}

		/// <summary>
		/// Show window.
		/// </summary>
		public void Show()
		{
			gameObject.SetActive(true);
		}

		/// <summary>
		/// Hide window.
		/// </summary>
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		/// <summary>
		/// Determines whether this window is visible.
		/// </summary>
		/// <returns><c>true</c> if this window is visible; otherwise, <c>false</c>.</returns>
		public bool IsVisible()
		{
			return gameObject.activeSelf;
		}
	}
}
