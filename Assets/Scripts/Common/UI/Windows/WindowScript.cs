using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Common;



namespace Common.UI.Windows
{
	/// <summary>
	/// Script that realize behaviour for window.
	/// </summary>
	public class WindowScript : MonoBehaviour, ICanvasRaycastFilter
	{
		private static float SHADOW_WIDTH     = 15f;
		private static float MAXIMIZED_OFFSET = 3f;
		private static float MINIMAL_WIDTH    = 100f;
		private static float MINIMAL_HEIGHT   = 38f;

		private static float MINIMIZED_OFFSET_LEFT   = 8f;
		private static float MINIMIZED_OFFSET_BOTTOM = 8f;
		private static float MINIMIZED_WIDTH         = 100f;
		private static float MINIMIZED_HEIGHT        = 38f;



		private WindowFrameType mFrame;
		private WindowState     mState;
		private float           mX;
		private float           mY;
		private float           mWidth;
		private float           mHeight;
		private Color           mBackgroundColor;

		private RectTransform   mWindowTransform;
		private GameObject      mBorderGameObject;
		private Image           mBorderImage;
		private RectTransform   mContentTransform;
		private Image           mContentBackgroundImage;
		private float           mBorderLeft;
		private float           mBorderTop;
		private float           mBorderRight;
		private float           mBorderBottom;



		/// <summary>
		/// Gets or sets the window frame.
		/// </summary>
		/// <value>Window frame.</value>
		public WindowFrameType frame
		{
			get
			{
				return mFrame;
			}

			set
			{
				if (mFrame != value)
				{
					WindowFrameType oldValue = mFrame;
					bool wasFramePresent = IsFramePresent();

					mFrame = value;

					if (IsUICreated())
					{
						if (wasFramePresent != IsFramePresent())
						{
							if (mFrame == WindowFrameType.Frameless)
							{
								DestroyBorder();

								if (mState == WindowState.NoState)
								{
									mWindowTransform.offsetMin = new Vector2(mWindowTransform.offsetMin.x + SHADOW_WIDTH, mWindowTransform.offsetMin.y + SHADOW_WIDTH);
									mWindowTransform.offsetMax = new Vector2(mWindowTransform.offsetMax.x - SHADOW_WIDTH, mWindowTransform.offsetMax.y - SHADOW_WIDTH);
								}
							}
							else
							{
								CreateBorder();

								if (mState == WindowState.NoState)
								{
									mWindowTransform.offsetMin = new Vector2(mWindowTransform.offsetMin.x - SHADOW_WIDTH, mWindowTransform.offsetMin.y - SHADOW_WIDTH);
									mWindowTransform.offsetMax = new Vector2(mWindowTransform.offsetMax.x + SHADOW_WIDTH, mWindowTransform.offsetMax.y + SHADOW_WIDTH);
								}
							}
						}
						else
						{
							UpdateBorderImage();
							UpdateBorders();
						}

						mContentTransform.offsetMin = new Vector2(mBorderLeft,    mBorderBottom);
						mContentTransform.offsetMax = new Vector2(-mBorderRight, -mBorderTop);
					}

					if ((oldValue == WindowFrameType.Frameless) || (mFrame == WindowFrameType.Frameless))
					{
						if (mFrame == WindowFrameType.Frameless)
						{
							mX      += SHADOW_WIDTH;
							mY      += SHADOW_WIDTH;
							mWidth  -= SHADOW_WIDTH * 2;
							mHeight -= SHADOW_WIDTH * 2;
						}
						else
						{
							mX      -= SHADOW_WIDTH;
							mY      -= SHADOW_WIDTH;
							mWidth  += SHADOW_WIDTH * 2;
							mHeight += SHADOW_WIDTH * 2;
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the window state.
		/// </summary>
		/// <value>Window state.</value>
		public WindowState state
		{
			get
			{
				return mState;
			}
			
			set
			{
				if (mState != value)
				{
					bool wasFramePresent = IsFramePresent();
					
					mState = value;

					if (IsUICreated())
					{
						if (wasFramePresent != IsFramePresent())
						{
							if (mState == WindowState.FullScreen)
							{
								DestroyBorder();
							}
							else
							{
								CreateBorder();
							}

							mContentTransform.offsetMin = new Vector2(mBorderLeft,    mBorderBottom);
							mContentTransform.offsetMax = new Vector2(-mBorderRight, -mBorderTop);
						}

						UpdateState();
					}
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
				if (mFrame != WindowFrameType.Frameless)
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
				if (mFrame != WindowFrameType.Frameless)
				{
					value -= SHADOW_WIDTH;
				}

				if (mX != value)
				{
					if (IsUICreated())
					{
						if (mState == WindowState.NoState)
						{
							mWindowTransform.offsetMin = new Vector2(mWindowTransform.offsetMin.x - mX + value, mWindowTransform.offsetMin.y);
							mWindowTransform.offsetMax = new Vector2(mWindowTransform.offsetMax.x - mX + value, mWindowTransform.offsetMax.y);
						}
					}

					mX = value;
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
				if (mFrame != WindowFrameType.Frameless)
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
				if (mFrame != WindowFrameType.Frameless)
				{
					value -= SHADOW_WIDTH;
				}

				if (mY != value)
				{
					if (IsUICreated())
					{
						if (mState == WindowState.NoState)
						{
							mWindowTransform.offsetMin = new Vector2(mWindowTransform.offsetMin.x, mWindowTransform.offsetMin.y + mY - value);
							mWindowTransform.offsetMax = new Vector2(mWindowTransform.offsetMax.x, mWindowTransform.offsetMax.y + mY - value);
						}
					}

					mY = value;
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
				if (mWidth == 0)
				{
					return 0;
				}

				if (mFrame != WindowFrameType.Frameless)
				{
					return mWidth - SHADOW_WIDTH * 2;
				}
				else
				{
					return mWidth;
				}
			}
			
			set
			{
				if (value < MINIMAL_WIDTH)
				{
					value = MINIMAL_WIDTH;
				}

				if (mFrame != WindowFrameType.Frameless)
				{
					value += SHADOW_WIDTH * 2;
				}

				if (mWidth != value)
				{
					if (IsUICreated())
					{
						if (mState == WindowState.NoState)
						{
							mWindowTransform.offsetMax = new Vector2(mWindowTransform.offsetMax.x - mWidth + value, mWindowTransform.offsetMax.y);
						}
					}

					mWidth = value;
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
				if (mHeight == 0)
				{
					return 0;
				}

				if (mFrame != WindowFrameType.Frameless)
				{
					return mHeight - SHADOW_WIDTH * 2;
				}
				else
				{
					return mHeight;
				}
			}
			
			set
			{
				if (value < MINIMAL_HEIGHT)
				{
					value = MINIMAL_HEIGHT;
				}

				if (mFrame != WindowFrameType.Frameless)
				{
					value += SHADOW_WIDTH * 2;
				}
				
				if (mHeight != value)
				{
					if (IsUICreated())
					{
						if (mState == WindowState.NoState)
						{
							mWindowTransform.offsetMin = new Vector2(mWindowTransform.offsetMin.x, mWindowTransform.offsetMin.y + mHeight - value);
						}
					}

					mHeight = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		/// <value>Background color.</value>
		public Color backgroundColor
		{
			get
			{
				return mBackgroundColor;
			}

			set
			{
				if (mBackgroundColor != value)
				{
					if (IsUICreated())
					{
						mContentBackgroundImage.color = value;
					}

					mBackgroundColor = value;
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
				if (!IsUICreated())
				{
					return 0;
				}
				
				if (mState == WindowState.FullScreen)
				{
					return 0;
				}

				if (mState == WindowState.Maximized)
				{
					return -MAXIMIZED_OFFSET;
				}

				if (mFrame != WindowFrameType.Frameless)
				{
					return mWindowTransform.offsetMin.x + SHADOW_WIDTH;
				}
				else
				{
					return mWindowTransform.offsetMin.x;
				}
			}
		}
		
		/// <summary>
		/// Gets the real y coordinate.
		/// </summary>
		/// <value>Real y coordinate.</value>
		public float realY
		{
			get
			{
				if (!IsUICreated())
				{
					return 0;
				}
				
				if (mState == WindowState.FullScreen)
				{
					return 0;
				}
				
				if (mState == WindowState.Maximized)
				{
					return -MAXIMIZED_OFFSET;
				}				
				
				if (mFrame != WindowFrameType.Frameless)
				{
					return -mWindowTransform.offsetMax.y + SHADOW_WIDTH;
				}
				else
				{
					return -mWindowTransform.offsetMax.y;
				}
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
				if (!IsUICreated())
				{
					return 0;
				}

				if (mState == WindowState.FullScreen)
				{
					return Screen.width;
				}

				if (mState == WindowState.Maximized)
				{
					return Screen.width + MAXIMIZED_OFFSET * 2;
				}

				if (mFrame != WindowFrameType.Frameless)
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
				if (!IsUICreated())
				{
					return 0;
				}

				if (mState == WindowState.FullScreen)
				{
					return Screen.height;
				}
				
				if (mState == WindowState.Maximized)
				{
					return Screen.height + MAXIMIZED_OFFSET * 2;
				}
				
				if (mFrame != WindowFrameType.Frameless)
				{
					return mWindowTransform.sizeDelta.y - SHADOW_WIDTH * 2;
				}
				else
				{
					return mWindowTransform.sizeDelta.y;
				}
			}
		}

		/// <summary>
		/// Gets the content x coordinate.
		/// </summary>
		/// <value>Content x coordinate.</value>
		public float contentX
		{
			get
			{
				if (!IsUICreated())
				{
					return 0;
				}
				
				if (mState == WindowState.FullScreen)
				{
					return 0;
				}
				
				if (mState == WindowState.Maximized)
				{
					return mBorderLeft - SHADOW_WIDTH - MAXIMIZED_OFFSET;
				}

				if (mState == WindowState.Minimized)
				{
					return 0;
				}
                
				return mX + mBorderLeft;
            }
        }

		/// <summary>
		/// Gets the content y coordinate.
		/// </summary>
		/// <value>Content y coordinate.</value>
		public float contentY
		{
			get
			{
				if (!IsUICreated())
				{
					return 0;
				}
				
				if (mState == WindowState.FullScreen)
				{
					return 0;
				}
                
                if (mState == WindowState.Maximized)
                {
					return mBorderTop - SHADOW_WIDTH - MAXIMIZED_OFFSET;
                }

				if (mState == WindowState.Minimized)
				{
					return 0;
				}
                
				return mY + mBorderTop;
			}
        }
        
        /// <summary>
		/// Gets the content width.
		/// </summary>
		/// <value>Content width.</value>
		public float contentWidth
		{
			get
			{
				if (!IsUICreated())
				{
					return 0;
				}

				if (mState == WindowState.FullScreen)
				{
					return Screen.width;
				}

				if (mState == WindowState.Maximized)
				{
					return Screen.width - mBorderLeft - mBorderRight + MAXIMIZED_OFFSET * 2;
				}

				if (mState == WindowState.Minimized)
				{
					return 0;
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
				if (!IsUICreated())
				{
					return 0;
				}

				if (mState == WindowState.FullScreen)
				{
					return Screen.height;
				}
				
				if (mState == WindowState.Maximized)
				{
					return Screen.height - mBorderTop - mBorderBottom + MAXIMIZED_OFFSET * 2;
				}

				if (mState == WindowState.Minimized)
				{
					return 0;
				}

				return mWindowTransform.sizeDelta.y - mBorderTop - mBorderBottom;
			}
		}



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.Windows.WindowScript"/> class.
		/// </summary>
		public WindowScript()
			: base()
        {
			mFrame           = WindowFrameType.Window;
			mState           = WindowState.NoState;
			mX               = -SHADOW_WIDTH;
			mY               = -SHADOW_WIDTH;
			mWidth           = 0f;
			mHeight          = 0f;
			mBackgroundColor = new Color(1f, 1f, 1f, 1f);

			mWindowTransform        = null;
			mBorderGameObject       = null;
			mBorderImage            = null;
			mContentTransform       = null;
			mContentBackgroundImage = null;
			mBorderLeft             = 0f;
			mBorderTop              = 0f;
			mBorderRight            = 0f;
			mBorderBottom           = 0f;

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

			if (IsFramePresent())
			{
				CreateBorder();
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

			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			content.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			mContentBackgroundImage = content.AddComponent<Image>();
			mContentBackgroundImage.color = mBackgroundColor;
			#endregion

			CreateContent(content.transform, out contentWidth, out contentHeight);
			#endregion

			if (mWidth == 0 || mHeight == 0)
			{
				mWidth  = mBorderLeft + contentWidth  + mBorderRight;
				mHeight = mBorderTop  + contentHeight + mBorderBottom;

				if (mWidth < MINIMAL_WIDTH)
				{
					mWidth = MINIMAL_WIDTH;
				}

				if (mHeight < MINIMAL_HEIGHT)
				{
					mHeight = MINIMAL_HEIGHT;
				}

				mX = (Screen.width  - mWidth)  / 2; // Screen.width  / 2 - mWidth / 2;
				mY = (Screen.height - mHeight) / 2; // Screen.height / 2 - mHeight / 2;
			}

			UpdateState();
		}

		/// <summary>
		/// Creates border.
		/// </summary>
		private void CreateBorder()
		{
			if (mBorderGameObject == null)
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
				
				UpdateBorderImage();
				
				mBorderImage.type       = Image.Type.Sliced;
				mBorderImage.fillCenter = false;
				
				UpdateBorders();
				#endregion
				#endregion
			}
			else
			{
				Debug.LogError("Border game object already created");
			}
		}

		/// <summary>
		/// Updates border image.
		/// </summary>
		private void UpdateBorderImage()
		{
			switch (mFrame)
			{
				case WindowFrameType.Window:
				{
					mBorderImage.sprite = Assets.Windows.Common.Textures.window;
				}
				break;

				case WindowFrameType.SubWindow:
				{
					mBorderImage.sprite = Assets.Windows.Common.Textures.subWindow;
				}
				break;

				case WindowFrameType.Drawer:
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
		}

		/// <summary>
		/// Updates information about borders.
		/// </summary>
		private void UpdateBorders()
		{
			if (mBorderImage != null)
			{
				Vector4	borders = mBorderImage.sprite.border;
				
				mBorderLeft   = borders.x;
				mBorderTop    = borders.w;
				mBorderRight  = borders.z;
				mBorderBottom = borders.y;
			}
			else
			{
				mBorderLeft   = 0f;
				mBorderTop    = 0f;
				mBorderRight  = 0f;
				mBorderBottom = 0f;
			}
		}

		/// <summary>
		/// Destroies border.
		/// </summary>
		private void DestroyBorder()
		{
			UnityEngine.Object.DestroyObject(mBorderGameObject);
			mBorderGameObject = null;
			mBorderImage      = null;

			UpdateBorders();
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
		/// Updates window position on state changes.
		/// </summary>
		private void UpdateState()
		{
			switch (mState)
			{
				case WindowState.NoState:
				{
					Utils.AlignRectTransformTopLeft(mWindowTransform, mWidth, mHeight, mX, mY);
				}
				break;

				case WindowState.Minimized:
				{
					Utils.AlignRectTransformTopLeft(
													  mWindowTransform
													, MINIMIZED_WIDTH
													, MINIMIZED_HEIGHT
													, MINIMIZED_OFFSET_LEFT
													, Screen.height - MINIMIZED_OFFSET_BOTTOM - MINIMIZED_HEIGHT
												   );
				}
				break;

				case WindowState.Maximized:
				{
					if (mFrame != WindowFrameType.Frameless)
					{
						Utils.AlignRectTransformStretchStretch(
																 mWindowTransform
															   , -SHADOW_WIDTH - MAXIMIZED_OFFSET
															   , -SHADOW_WIDTH - MAXIMIZED_OFFSET
															   , -SHADOW_WIDTH - MAXIMIZED_OFFSET
															   , -SHADOW_WIDTH - MAXIMIZED_OFFSET
															  );
					}
					else
					{
						Utils.AlignRectTransformStretchStretch(mWindowTransform);
					}				    
				}
				break;

				case WindowState.FullScreen:
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
		/// Destroy this instance.
		/// </summary>
		public void Destroy()
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}

		/// <summary>
		/// Handler for raycast validation.
		/// </summary>
		/// <returns><c>true</c> if raycast handled by this window; otherwise, <c>false</c>.</returns>
		/// <param name="sp">Screen point</param>
		/// <param name="eventCamera">Event camera.</param>
		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			if (IsFramePresent())
			{
				float x = sp.x;
				float y = Screen.height - sp.y;
				
				return x >= mX + SHADOW_WIDTH && x <= mX + mWidth  - SHADOW_WIDTH
					   &&
					   y >= mY + SHADOW_WIDTH && y <= mY + mHeight - SHADOW_WIDTH;
			}

			return true;
		}

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			// TODO: Implement
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

		/// <summary>
		/// Determines whether frame present or not.
		/// </summary>
		/// <returns><c>true</c> if frame present; otherwise, <c>false</c>.</returns>
		private bool IsFramePresent()
		{
			return (mFrame != WindowFrameType.Frameless && mState != WindowState.FullScreen);
		}

		/// <summary>
		/// Determines whether user interface created or not.
		/// </summary>
		/// <returns><c>true</c> if user interface created; otherwise, <c>false</c>.</returns>
		private bool IsUICreated()
		{
			return (mWindowTransform != null);
		}
	}
}
