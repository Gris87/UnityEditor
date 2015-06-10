using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityTranslation;

using Common;



namespace Common.UI.Windows
{
	#region Internal namespace
	namespace Internal
	{
		/// <summary>
		/// Window common things.
		/// </summary>
		static class WindowCommon
		{
			public static SpriteState minimizeButtonSpriteState;
			public static SpriteState maximizeButtonSpriteState;
			public static SpriteState normalizeButtonSpriteState;
			public static SpriteState closeButtonSpriteState;
			public static SpriteState toolCloseButtonSpriteState;
			
			
			
			/// <summary>
			/// Initializes the <see cref="Common.UI.Popups.Internal.PopupMenuCommon"/> class.
			/// </summary>
			static WindowCommon()
			{
				minimizeButtonSpriteState  = new SpriteState();
				maximizeButtonSpriteState  = new SpriteState();
				normalizeButtonSpriteState = new SpriteState();
				closeButtonSpriteState     = new SpriteState();
				toolCloseButtonSpriteState = new SpriteState();
				
				minimizeButtonSpriteState.disabledSprite     = Assets.Windows.Common.Textures.minimizeButtonDisabled;
				minimizeButtonSpriteState.highlightedSprite  = Assets.Windows.Common.Textures.minimizeButtonHighlighted;
				minimizeButtonSpriteState.pressedSprite      = Assets.Windows.Common.Textures.minimizeButtonPressed;

				maximizeButtonSpriteState.disabledSprite     = Assets.Windows.Common.Textures.maximizeButtonDisabled;
				maximizeButtonSpriteState.highlightedSprite  = Assets.Windows.Common.Textures.maximizeButtonHighlighted;
				maximizeButtonSpriteState.pressedSprite      = Assets.Windows.Common.Textures.maximizeButtonPressed;

				normalizeButtonSpriteState.disabledSprite    = Assets.Windows.Common.Textures.normalizeButtonDisabled;
				normalizeButtonSpriteState.highlightedSprite = Assets.Windows.Common.Textures.normalizeButtonHighlighted;
				normalizeButtonSpriteState.pressedSprite     = Assets.Windows.Common.Textures.normalizeButtonPressed;

				closeButtonSpriteState.disabledSprite        = Assets.Windows.Common.Textures.closeButtonDisabled;
				closeButtonSpriteState.highlightedSprite     = Assets.Windows.Common.Textures.closeButtonHighlighted;
				closeButtonSpriteState.pressedSprite         = Assets.Windows.Common.Textures.closeButtonPressed;

				toolCloseButtonSpriteState.disabledSprite    = Assets.Windows.Common.Textures.toolCloseButtonDisabled;
				toolCloseButtonSpriteState.highlightedSprite = Assets.Windows.Common.Textures.toolCloseButtonHighlighted;
				toolCloseButtonSpriteState.pressedSprite     = Assets.Windows.Common.Textures.toolCloseButtonPressed;
			}
		}
	}
	#endregion



	/// <summary>
	/// Script that realize behaviour for window.
	/// </summary>
	public class WindowScript : MonoBehaviour, ICanvasRaycastFilter, IPointerEnterHandler, IPointerExitHandler
	{
		/// <summary>
		/// Class for data that used while lef mouse button pressed.
		/// </summary>
		private class MouseContext
		{
			public float previousMouseX;
			public float previousMouseY;
			public float previousX;
			public float previousY;
			public float previousWidth;
			public float previousHeight;
			public float previousRectX;
			public float previousRectY;



			/// <summary>
			/// Initializes a new instance of the <see cref="Common.UI.Windows.WindowScript+MouseContext"/> class.
			/// </summary>
			public MouseContext(
				                  float mouseX
			                    , float mouseY
			                    , float x
			                    , float y
			                    , float width
			                    , float height
								, float rectX
								, float rectY
			                   )
			{
				previousMouseX = mouseX;
				previousMouseY = mouseY;
				previousX      = x;
				previousY      = y;
				previousWidth  = width;
				previousHeight = height;
				previousRectX  = rectX;
				previousRectY  = rectY;
			}
		}

		private enum MouseLocation
		{
			  Outside
			, Header
			, North
			, South
			, West
			, East
			, NorthWest
			, NorthEast
			, SouthWest
			, SouthEast
			, Inside
		}

		private enum MouseState
		{
			  NoState
			, Dragging
			, Resizing
		}



		private static float SHADOW_WIDTH           = 15f;
		private static float BUTTON_GLOW_WIDTH      = 8f;
		private static float TOOL_BUTTON_GLOW_WIDTH = 4f;
		private static float MAXIMIZED_OFFSET       = 3f;
		private static float RESIZING_GAP           = 8f;
		private static float DRAGGING_GAP           = 15f;

		private static float MINIMAL_WIDTH  = 120f;
		private static float MINIMAL_HEIGHT = 38f;

		private static float MINIMIZED_OFFSET_LEFT   = 8f;
		private static float MINIMIZED_OFFSET_BOTTOM = 8f;
		private static float MINIMIZED_WIDTH         = 120f;
		private static float MINIMIZED_HEIGHT        = 20f;



		private WindowFrameType                 mFrame;
		private WindowState                     mState;
		private float                           mX;
		private float                           mY;
		private float                           mWidth;
		private float                           mHeight;
		private Color                           mBackgroundColor;
		private bool                            mResizable;
		private float                           mMinimumWidth;
		private float                           mMinimumHeight;
		private float                           mMaximumWidth;
		private float                           mMaximumHeight;
		private bool                            mAllowMinimize;
		private bool                            mAllowMaximize;
		private bool                            mAllowClose;
		private R.sections.WindowTitles.strings mTokenId;
		// TODO: Label

		private RectTransform                   mWindowTransform;
		private GameObject                      mBorderGameObject;
		private Image                           mBorderImage;
		private GameObject                      mMinimizeGameObject;
		private Button                          mMinimizeButton;
		private GameObject                      mMaximizeGameObject;
		private Button                          mMaximizeButton;
		private GameObject                      mCloseGameObject;
		private Button                          mCloseButton;
		private RectTransform                   mContentTransform;
		private Image                           mContentBackgroundImage;
		private float                           mBorderLeft;
		private float                           mBorderTop;
		private float                           mBorderRight;
        private float                           mBorderBottom;
		private MouseLocation                   mMouseLocation;
		private MouseState                      mMouseState;
		private MouseContext                    mMouseContext;



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

							if ((oldValue == WindowFrameType.Drawer) || (mFrame == WindowFrameType.Drawer))
							{
								DestroyButtons();
								CreateButtons();
							}
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
						else
						{
							DestroyButtons();
							CreateButtons();
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

				if (mMinimumWidth != 0 && value < mMinimumWidth)
				{
					value = mMinimumWidth;
				}

				if (mMaximumWidth != 0 && value > mMaximumWidth)
				{
					value = mMaximumWidth;
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

				if (mMinimumHeight != 0 && value < mMinimumHeight)
				{
					value = mMinimumHeight;
				}
				
				if (mMaximumHeight != 0 && value > mMaximumHeight)
				{
					value = mMaximumHeight;
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
					mBackgroundColor = value;

					if (IsUICreated())
					{
						mContentBackgroundImage.color = mBackgroundColor;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return -MAXIMIZED_OFFSET;
					}
					else
					{
						return 0;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return -MAXIMIZED_OFFSET;
					}
					else
					{
						return 0;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return Screen.width + MAXIMIZED_OFFSET * 2;
					}
					else
					{
						return Screen.width;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return Screen.height + MAXIMIZED_OFFSET * 2;
					}
					else
					{
						return Screen.height;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return mBorderLeft - SHADOW_WIDTH - MAXIMIZED_OFFSET;
					}
					else
					{
						return 0;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return mBorderTop - SHADOW_WIDTH - MAXIMIZED_OFFSET;
					}
					else
					{
						return 0;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return Screen.width - mBorderLeft - mBorderRight + MAXIMIZED_OFFSET * 2;
					}
					else
					{
						return Screen.width;
					}
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
					if (mFrame != WindowFrameType.Frameless)
					{
						return Screen.height - mBorderTop - mBorderBottom + MAXIMIZED_OFFSET * 2;
					}
					else
					{
						return Screen.height;
					}
				}

				if (mState == WindowState.Minimized)
				{
					return 0;
				}

				return mWindowTransform.sizeDelta.y - mBorderTop - mBorderBottom;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this window is resizable.
		/// </summary>
		/// <value><c>true</c> if window is resizable; otherwise, <c>false</c>.</value>
		public bool resizable
		{
			get { return mResizable;  }
			set { mResizable = value; }
		}

		/// <summary>
		/// Gets or sets the minimum width.
		/// </summary>
		/// <value>The minimum width.</value>
		public float minimumWidth
		{
			get
			{
				return mMinimumWidth;
			}

			set
			{
				if (mMinimumWidth != value)
				{
					mMinimumWidth = value;

					if (mMinimumWidth != 0f)
					{
						if (mWidth != 0f)
						{
							if (width < mMinimumWidth)
							{
								width = mMinimumWidth;
							}
						}

						if (mMaximumWidth != 0f)
						{
							if (mMaximumWidth < mMinimumWidth)
							{
								mMaximumWidth = mMinimumWidth;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the maximum width.
		/// </summary>
		/// <value>The maximum width.</value>
		public float maximumWidth
		{
			get
			{
				return mMaximumWidth;
			}
			
			set
			{
				if (mMaximumWidth != value)
				{
					mMaximumWidth = value;
					
					if (mMaximumWidth != 0f)
					{
						if (mWidth != 0f)
						{
							if (width > mMaximumWidth)
							{
								width = mMaximumWidth;
							}
						}
						
						if (mMinimumWidth != 0f)
						{
							if (mMinimumWidth > mMaximumWidth)
							{
								mMinimumWidth = mMaximumWidth;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the minimum height.
		/// </summary>
		/// <value>The minimum height.</value>
		public float minimumHeight
		{
			get
			{
				return mMinimumHeight;
			}
			
			set
			{
				if (mMinimumHeight != value)
				{
					mMinimumHeight = value;
					
					if (mMinimumHeight != 0f)
					{
						if (mHeight != 0f)
						{
							if (height < mMinimumHeight)
							{
								height = mMinimumHeight;
							}
						}
						
						if (mMaximumHeight != 0f)
						{
							if (mMaximumHeight < mMinimumHeight)
							{
								mMaximumHeight = mMinimumHeight;
							}
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the maximum height.
		/// </summary>
		/// <value>The maximum height.</value>
		public float maximumHeight
		{
			get
			{
				return mMaximumHeight;
			}
			
			set
			{
				if (mMaximumHeight != value)
				{
					mMaximumHeight = value;
					
					if (mMaximumHeight != 0f)
					{
						if (mHeight != 0f)
						{
							if (height > mMaximumHeight)
							{
								height = mMaximumHeight;
							}
						}
						
						if (mMinimumHeight != 0f)
						{
							if (mMinimumHeight > mMaximumHeight)
							{
								mMinimumHeight = mMaximumHeight;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this window allow to be minimized.
		/// </summary>
		/// <value><c>true</c> if allow to minimize; otherwise, <c>false</c>.</value>
		public bool allowMinimize
		{
			get
			{
				return mAllowMinimize;
			}

			set
			{
				if (mAllowMinimize != value)
				{
					mAllowMinimize = value;

					if (IsUICreated())
					{
						DestroyButtons();
						CreateButtons();
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this window allow to be maximized.
		/// </summary>
		/// <value><c>true</c> if allow to maximize; otherwise, <c>false</c>.</value>
		public bool allowMaximize
		{
			get
			{
				return mAllowMaximize;
			}
			
			set
			{
				if (mAllowMaximize != value)
				{
					mAllowMaximize = value;
					
					if (IsUICreated())
					{
						DestroyButtons();
						CreateButtons();
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this window allow to close.
		/// </summary>
		/// <value><c>true</c> if allow to close; otherwise, <c>false</c>.</value>
		public bool allowClose
		{
			get
			{
				return mAllowClose;
			}
			
			set
			{
				if (mAllowClose != value)
				{
					mAllowClose = value;
					
					if (IsUICreated())
					{
						DestroyButtons();
						CreateButtons();
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets token ID for translation.
		/// </summary>
		/// <value>Token ID for translation.</value>
		public R.sections.WindowTitles.strings tokenId
		{
			get
			{
				return mTokenId; 
			}

			set
			{
				mTokenId = value;

				// TODO: Change title
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
			mResizable       = true;
			mMinimumWidth    = 0f;
			mMinimumHeight   = 0f;
			mMaximumWidth    = 0f;
			mMaximumHeight   = 0f;
			mAllowMinimize   = true;
			mAllowMaximize   = true;
			mAllowClose      = true;

			mWindowTransform        = null;
			mBorderGameObject       = null;
			mBorderImage            = null;
			mMinimizeGameObject     = null;
			mMinimizeButton         = null;
			mMaximizeGameObject     = null;
			mMaximizeButton         = null;
			mCloseGameObject        = null;
			mCloseButton            = null;
			mContentTransform       = null;
			mContentBackgroundImage = null;
			mBorderLeft             = 0f;
			mBorderTop              = 0f;
			mBorderRight            = 0f;
			mBorderBottom           = 0f;
			mMouseLocation          = MouseLocation.Outside;
			mMouseState             = MouseState.NoState;
			mMouseContext           = null;

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

				#region Apply constraints
				if (IsFramePresent())
				{
					if (mWidth < MINIMAL_WIDTH + SHADOW_WIDTH * 2)
					{
						mWidth = MINIMAL_WIDTH + SHADOW_WIDTH * 2;
					}

					if (mMinimumWidth != 0 && mWidth < mMinimumWidth + SHADOW_WIDTH * 2)
					{
						mWidth = mMinimumWidth + SHADOW_WIDTH * 2;
					}
					
					if (mMaximumWidth != 0 && mWidth > mMaximumWidth + SHADOW_WIDTH * 2)
					{
						mWidth = mMaximumWidth + SHADOW_WIDTH * 2;
					}
					
					if (mHeight < MINIMAL_HEIGHT + SHADOW_WIDTH * 2)
					{
						mHeight = MINIMAL_HEIGHT + SHADOW_WIDTH * 2;
					}

					if (mMinimumHeight != 0 && mHeight < mMinimumHeight + SHADOW_WIDTH * 2)
					{
						mHeight = mMinimumHeight + SHADOW_WIDTH * 2;
					}
					
					if (mMaximumHeight != 0 && mHeight > mMaximumHeight + SHADOW_WIDTH * 2)
					{
						mHeight = mMaximumHeight + SHADOW_WIDTH * 2;
					}
				}
				else
				{
					if (mWidth < MINIMAL_WIDTH)
					{
						mWidth = MINIMAL_WIDTH;
					}

					if (mMinimumWidth != 0 && mWidth < mMinimumWidth)
					{
						mWidth = mMinimumWidth;
					}
					
					if (mMaximumWidth != 0 && mWidth > mMaximumWidth)
					{
						mWidth = mMaximumWidth;
					}
					
					if (mHeight < MINIMAL_HEIGHT)
					{
						mHeight = MINIMAL_HEIGHT;
					}

					if (mMinimumHeight != 0 && mHeight < mMinimumHeight)
					{
						mHeight = mMinimumHeight;
					}
					
					if (mMaximumHeight != 0 && mHeight > mMaximumHeight)
					{
						mHeight = mMaximumHeight;
					}
				}
				#endregion

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

				CreateButtons();
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
			DestroyButtons();

			UnityEngine.Object.DestroyObject(mBorderGameObject);
			mBorderGameObject = null;
			mBorderImage      = null;

			UpdateBorders();
		}

		/// <summary>
		/// Creates control buttons.
		/// </summary>
		private void CreateButtons()
		{
			switch (mFrame)
			{
				case WindowFrameType.Window:
				case WindowFrameType.SubWindow:
				{
					if (
						mAllowMinimize
					    ||
						mAllowMaximize
						||
						mAllowClose
					   )
					{
						float buttonWidth;
						float buttonHeight = 20f;
						float contentWidth = SHADOW_WIDTH + 4f;
						
						buttonWidth = 48f;

						//***************************************************************************
						// Close GameObject
						//***************************************************************************
						#region Close GameObject
						mCloseGameObject = new GameObject("Close");
						Utils.InitUIObject(mCloseGameObject, mBorderGameObject.transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						RectTransform closeTransform = mCloseGameObject.AddComponent<RectTransform>();
						Utils.AlignRectTransformTopRight(closeTransform, buttonWidth, buttonHeight, contentWidth, SHADOW_WIDTH);
						#endregion
						
						//***************************************************************************
						// CloseImage GameObject
						//***************************************************************************
						#region CloseImage GameObject
						GameObject closeImage = new GameObject("Image");
						Utils.InitUIObject(closeImage, mCloseGameObject.transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						RectTransform closeImageTransform = closeImage.AddComponent<RectTransform>();
						Utils.AlignRectTransformStretchStretch(closeImageTransform, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH);
						#endregion
						
						//===========================================================================
						// CanvasRenderer Component
						//===========================================================================
						#region CanvasRenderer Component
						closeImage.AddComponent<CanvasRenderer>();
						#endregion
						
						//===========================================================================
						// Image Component
						//===========================================================================
						#region Image Component
						Image closeImageImage = closeImage.AddComponent<Image>();
						
						closeImageImage.sprite = Assets.Windows.Common.Textures.closeButton;
						closeImageImage.type   = Image.Type.Sliced;
						#endregion
						
						//===========================================================================
						// ButtonGlowScript Component
						//===========================================================================
						#region ButtonGlowScript Component
						ButtonGlowScript closeButtonGlowScript = closeImage.AddComponent<ButtonGlowScript>();
						
						closeButtonGlowScript.rectTransform = closeTransform;
						#endregion
						#endregion
						
						//===========================================================================
						// Button Component
						//===========================================================================
						#region Button Component
						mCloseButton = mCloseGameObject.AddComponent<Button>();
						
						mCloseButton.interactable  = mAllowClose;
						mCloseButton.targetGraphic = closeImageImage;
						mCloseButton.transition    = Selectable.Transition.SpriteSwap;
						mCloseButton.spriteState   = Internal.WindowCommon.closeButtonSpriteState;
						mCloseButton.onClick.AddListener(Close);
						#endregion
						#endregion

						if (
							mAllowMinimize
							||
							mAllowMaximize
						   )
						{
							contentWidth += buttonWidth - 1; // One button overlaps another one
							buttonWidth = 28f;
							
							//***************************************************************************
							// Maximize GameObject
							//***************************************************************************
							#region Maximize GameObject
							mMaximizeGameObject = new GameObject("Maximize");
							Utils.InitUIObject(mMaximizeGameObject, mBorderGameObject.transform);
							
							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform maximizeTransform = mMaximizeGameObject.AddComponent<RectTransform>();
							Utils.AlignRectTransformTopRight(maximizeTransform, buttonWidth, buttonHeight, contentWidth, SHADOW_WIDTH);
							#endregion
							
							//***************************************************************************
							// MaximizeImage GameObject
							//***************************************************************************
							#region MaximizeImage GameObject
							GameObject maximizeImage = new GameObject("Image");
							Utils.InitUIObject(maximizeImage, mMaximizeGameObject.transform);
							
							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform maximizeImageTransform = maximizeImage.AddComponent<RectTransform>();
							Utils.AlignRectTransformStretchStretch(maximizeImageTransform, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH);
							#endregion
							
							//===========================================================================
							// CanvasRenderer Component
							//===========================================================================
							#region CanvasRenderer Component
							maximizeImage.AddComponent<CanvasRenderer>();
							#endregion
							
							//===========================================================================
							// Image Component
							//===========================================================================
							#region Image Component
							Image maximizeImageImage = maximizeImage.AddComponent<Image>();
							
							if (mState != WindowState.Maximized)
							{
								maximizeImageImage.sprite = Assets.Windows.Common.Textures.maximizeButton;
							}
							else
							{
								maximizeImageImage.sprite = Assets.Windows.Common.Textures.normalizeButton;
							}

							maximizeImageImage.type   = Image.Type.Sliced;
							#endregion
							
							//===========================================================================
							// ButtonGlowScript Component
							//===========================================================================
							#region ButtonGlowScript Component
							ButtonGlowScript maximizeButtonGlowScript = maximizeImage.AddComponent<ButtonGlowScript>();
							
							maximizeButtonGlowScript.rectTransform = maximizeTransform;
							#endregion
							#endregion
							
							//===========================================================================
							// Button Component
							//===========================================================================
							#region Button Component
							mMaximizeButton = mMaximizeGameObject.AddComponent<Button>();
							
							mMaximizeButton.interactable  = mAllowMaximize;
							mMaximizeButton.targetGraphic = maximizeImageImage;
							mMaximizeButton.transition    = Selectable.Transition.SpriteSwap;
							
							if (mState != WindowState.Maximized)
							{
								mMaximizeButton.spriteState   = Internal.WindowCommon.maximizeButtonSpriteState;
							}
							else
							{
								mMaximizeButton.spriteState   = Internal.WindowCommon.normalizeButtonSpriteState;
							}
							
							mMaximizeButton.onClick.AddListener(OnMaximizeClicked);
							#endregion
							#endregion
							
							contentWidth += buttonWidth - 1; // One button overlaps another one
							buttonWidth = 29f;
							
							//***************************************************************************
							// Minimize GameObject
							//***************************************************************************
							#region Minimize GameObject
							mMinimizeGameObject = new GameObject("Minimize");
							Utils.InitUIObject(mMinimizeGameObject, mBorderGameObject.transform);
							
							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform minimizeTransform = mMinimizeGameObject.AddComponent<RectTransform>();
							Utils.AlignRectTransformTopRight(minimizeTransform, buttonWidth, buttonHeight, contentWidth, SHADOW_WIDTH);
							#endregion
							
							//***************************************************************************
							// MinimizeImage GameObject
							//***************************************************************************
							#region MinimizeImage GameObject
							GameObject minimizeImage = new GameObject("Image");
							Utils.InitUIObject(minimizeImage, mMinimizeGameObject.transform);
							
							//===========================================================================
							// RectTransform Component
							//===========================================================================
							#region RectTransform Component
							RectTransform minimizeImageTransform = minimizeImage.AddComponent<RectTransform>();
							Utils.AlignRectTransformStretchStretch(minimizeImageTransform, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH, -BUTTON_GLOW_WIDTH);
							#endregion
							
							//===========================================================================
							// CanvasRenderer Component
							//===========================================================================
							#region CanvasRenderer Component
							minimizeImage.AddComponent<CanvasRenderer>();
							#endregion
							
							//===========================================================================
							// Image Component
							//===========================================================================
							#region Image Component
							Image minimizeImageImage = minimizeImage.AddComponent<Image>();
							
							if (mState != WindowState.Minimized)
							{
								minimizeImageImage.sprite = Assets.Windows.Common.Textures.minimizeButton;
							}
							else
							{
								minimizeImageImage.sprite = Assets.Windows.Common.Textures.normalizeButton;
							}
													
							minimizeImageImage.type   = Image.Type.Sliced;
							#endregion
							
							//===========================================================================
							// ButtonGlowScript Component
							//===========================================================================
							#region ButtonGlowScript Component
							ButtonGlowScript minimizeButtonGlowScript = minimizeImage.AddComponent<ButtonGlowScript>();
							
							minimizeButtonGlowScript.rectTransform = minimizeTransform;
							#endregion
							#endregion
							
							//===========================================================================
							// Button Component
							//===========================================================================
							#region Button Component
							mMinimizeButton = mMinimizeGameObject.AddComponent<Button>();
							
							mMinimizeButton.interactable  = mAllowMinimize;
							mMinimizeButton.targetGraphic = minimizeImageImage;
							mMinimizeButton.transition    = Selectable.Transition.SpriteSwap;
							
							if (mState != WindowState.Minimized)
							{
								mMinimizeButton.spriteState = Internal.WindowCommon.minimizeButtonSpriteState;
							}	
							else
							{
								mMinimizeButton.spriteState = Internal.WindowCommon.normalizeButtonSpriteState;
							}
							
							mMinimizeButton.onClick.AddListener(OnMinimizeClicked);
							#endregion
							#endregion
						}
					}					
				}
				break;

				case WindowFrameType.Drawer:
				{
					if (mAllowClose)
					{						
						//***************************************************************************
						// Close GameObject
						//***************************************************************************
						#region Close GameObject
						mCloseGameObject = new GameObject("Close");
						Utils.InitUIObject(mCloseGameObject, mBorderGameObject.transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						RectTransform closeTransform = mCloseGameObject.AddComponent<RectTransform>();
						Utils.AlignRectTransformTopRight(closeTransform, 17f, 17f, SHADOW_WIDTH + 5f, SHADOW_WIDTH + 4f);
						#endregion
						
						//***************************************************************************
						// CloseImage GameObject
						//***************************************************************************
						#region CloseImage GameObject
						GameObject closeImage = new GameObject("Image");
						Utils.InitUIObject(closeImage, mCloseGameObject.transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						RectTransform closeImageTransform = closeImage.AddComponent<RectTransform>();
						Utils.AlignRectTransformStretchStretch(closeImageTransform, -TOOL_BUTTON_GLOW_WIDTH, -TOOL_BUTTON_GLOW_WIDTH, -TOOL_BUTTON_GLOW_WIDTH, -TOOL_BUTTON_GLOW_WIDTH);
						#endregion
						
						//===========================================================================
						// CanvasRenderer Component
						//===========================================================================
						#region CanvasRenderer Component
						closeImage.AddComponent<CanvasRenderer>();
						#endregion
						
						//===========================================================================
						// Image Component
						//===========================================================================
						#region Image Component
						Image closeImageImage = closeImage.AddComponent<Image>();
						
						closeImageImage.sprite = Assets.Windows.Common.Textures.toolCloseButton;
						closeImageImage.type   = Image.Type.Sliced;
						#endregion
						
						//===========================================================================
						// ButtonGlowScript Component
						//===========================================================================
						#region ButtonGlowScript Component
						ButtonGlowScript closeButtonGlowScript = closeImage.AddComponent<ButtonGlowScript>();
						
						closeButtonGlowScript.rectTransform = closeTransform;
						#endregion
						#endregion
						
						//===========================================================================
						// Button Component
						//===========================================================================
						#region Button Component
						mCloseButton = mCloseGameObject.AddComponent<Button>();
						
						mCloseButton.interactable  = mAllowClose;
						mCloseButton.targetGraphic = closeImageImage;
						mCloseButton.transition    = Selectable.Transition.SpriteSwap;
						mCloseButton.spriteState   = Internal.WindowCommon.toolCloseButtonSpriteState;
						mCloseButton.onClick.AddListener(Close);
						#endregion
						#endregion
					}
				}
				break;

				case WindowFrameType.Frameless:
				{
					Debug.LogError("Incorrect window frame");
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
		/// Destroies control buttons.
		/// </summary>
		private void DestroyButtons()
		{
			if (mMinimizeGameObject != null)
			{
				UnityEngine.Object.DestroyObject(mMinimizeGameObject);
				mMinimizeGameObject = null;
				mMinimizeButton     = null;
			}

			if (mMaximizeGameObject != null)
			{
				UnityEngine.Object.DestroyObject(mMaximizeGameObject);
				mMaximizeGameObject = null;
				mMaximizeButton     = null;
			}

			if (mCloseGameObject != null)
			{
				UnityEngine.Object.DestroyObject(mCloseGameObject);
				mCloseGameObject = null;
				mCloseButton     = null;
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
													, MINIMIZED_WIDTH  + 2 * SHADOW_WIDTH
													, MINIMIZED_HEIGHT + 2 * SHADOW_WIDTH
													, MINIMIZED_OFFSET_LEFT - SHADOW_WIDTH
													, Screen.height - MINIMIZED_OFFSET_BOTTOM - MINIMIZED_HEIGHT - SHADOW_WIDTH
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
		/// Handler for click event on mimimize button.
		/// </summary>
		private void OnMinimizeClicked()
		{
			if (mState != WindowState.Minimized) 
			{
				state = WindowState.Minimized;
			}
			else
			{
				state = WindowState.NoState;
			}
		}

		/// <summary>
		/// Handler for click event on mimimize button.
		/// </summary>
		private void OnMaximizeClicked()
		{
			if (mState != WindowState.Maximized) 
			{
				state = WindowState.Maximized;
			}
			else
			{
				state = WindowState.NoState;
			}
		}

		/// <summary>
		/// Close this window.
		/// </summary>
		public void Close()
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
				if (mState == WindowState.Maximized)
				{
					return true;
				}

				float mouseX = sp.x;
				float mouseY = Screen.height - sp.y;

				float windowX      = mWindowTransform.offsetMin.x  + SHADOW_WIDTH;
				float windowY      = -mWindowTransform.offsetMax.y + SHADOW_WIDTH;
				float windowWidth  = mWindowTransform.sizeDelta.x - 2 * SHADOW_WIDTH;
				float windowHeight = mWindowTransform.sizeDelta.y - 2 * SHADOW_WIDTH;

				return (
						mouseX >= windowX
						&&
						mouseX <= windowX + windowWidth
						&&
						mouseY >= windowY
						&&
						mouseY <= windowY + windowHeight
					   );
			}

			return true;
		}

		/// <summary>
		/// Handler for pointer enter event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (mMouseState == MouseState.NoState)
			{
				mMouseLocation = MouseLocation.Inside;
			}
		}

		/// <summary>
		/// Handler for pointer exit event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnPointerExit(PointerEventData eventData)
		{
			if (mMouseState == MouseState.NoState)
			{
				if (
					mResizable
					&&
					(
					 mMouseLocation == MouseLocation.North
					 ||
					 mMouseLocation == MouseLocation.South
					 ||
					 mMouseLocation == MouseLocation.West
					 ||
					 mMouseLocation == MouseLocation.East
					 ||
					 mMouseLocation == MouseLocation.NorthWest
					 ||
					 mMouseLocation == MouseLocation.NorthEast
					 ||
					 mMouseLocation == MouseLocation.SouthWest
					 ||
					 mMouseLocation == MouseLocation.SouthEast
					)
				   )
				{
					Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
				}

				mMouseLocation = MouseLocation.Outside;
			}
		}

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			if (IsFramePresent())
			{
				switch (mMouseState)
				{
					case MouseState.NoState:
					{							
						if (mMouseLocation != MouseLocation.Outside)
						{
							bool isInsideButtons = false;

							Vector3 mousePos = InputControl.mousePosition;

							float mouseX = mousePos.x;
							float mouseY = Screen.height - mousePos.y;
							
							if (mMinimizeGameObject != null)
							{
								RectTransform buttonTransform = mMinimizeGameObject.GetComponent<RectTransform>();
								Vector3[] corners = Utils.GetWindowCorners(buttonTransform);
								
								if (
									mouseX >= corners[0].x
									&&
									mouseX <= corners[3].x
									&&
									mouseY >= corners[0].y
									&&
									mouseY <= corners[3].y
								   )
								{
									isInsideButtons = true;

									mMinimizeGameObject.transform.SetAsLastSibling();
								}
							}
							
							if (mMaximizeGameObject != null)
							{
								RectTransform buttonTransform = mMaximizeGameObject.GetComponent<RectTransform>();
								Vector3[] corners = Utils.GetWindowCorners(buttonTransform);
								
								if (
									mouseX >= corners[0].x
									&&
									mouseX <= corners[3].x
									&&
									mouseY >= corners[0].y
									&&
									mouseY <= corners[3].y
								   )
								{
									isInsideButtons = true;

									mMaximizeGameObject.transform.SetAsLastSibling();
								}
							}
							
							if (mCloseGameObject != null)
							{
								RectTransform buttonTransform = mCloseGameObject.GetComponent<RectTransform>();
								Vector3[] corners = Utils.GetWindowCorners(buttonTransform);
								
								if (
									mouseX >= corners[0].x
									&&
									mouseX <= corners[3].x
									&&
									mouseY >= corners[0].y
									&&
									mouseY <= corners[3].y
								   )
								{
									isInsideButtons = true;

									mCloseGameObject.transform.SetAsLastSibling();
								}
							}

							switch (mState)
							{
								case WindowState.NoState:
								{
									MouseLocation oldLocation = mMouseLocation;

									if (isInsideButtons)
									{
										mMouseLocation = MouseLocation.Inside;
									}
									else
									{
										if (mouseY <= mY + SHADOW_WIDTH + RESIZING_GAP)
										{
											if (mouseX <= mX + mBorderLeft)
											{
												mMouseLocation = MouseLocation.NorthWest;
											}
											else
											if (mouseX < mX + mWidth - mBorderRight)
											{
												mMouseLocation = MouseLocation.North;
											}
											else
											{
												mMouseLocation = MouseLocation.NorthEast;
											}
										}
										else
										if (mouseY <= mY + mBorderTop)
										{
											if (mouseX <= mX + mBorderLeft)
											{
												mMouseLocation = MouseLocation.West;
											}
											else
											if (mouseX < mX + mWidth - mBorderRight)
											{
												mMouseLocation = MouseLocation.Header;
											}
											else
											{
												mMouseLocation = MouseLocation.East;
											}
										}
										else
										if (mouseY < mY + mHeight - mBorderBottom)
										{
											if (mouseX <= mX + mBorderLeft)
											{
												mMouseLocation = MouseLocation.West;
											}
											else
											if (mouseX < mX + mWidth - mBorderRight)
											{
												mMouseLocation = MouseLocation.Inside;
											}
											else
											{
												mMouseLocation = MouseLocation.East;
											}
										}
										else
										{
											if (mouseX <= mX + mBorderLeft)
											{
												mMouseLocation = MouseLocation.SouthWest;
											}
											else
											if (mouseX < mX + mWidth - mBorderRight)
											{
												mMouseLocation = MouseLocation.South;
											}
											else
											{
												mMouseLocation = MouseLocation.SouthEast;
											}
										}
									}
									
									if (mResizable && oldLocation != mMouseLocation)
									{
										switch (mMouseLocation)
										{
											case MouseLocation.North:
											case MouseLocation.South:
											{
												Cursor.SetCursor(Assets.Cursors.northSouth, new Vector2(16f, 16f), CursorMode.Auto);
											}
											break;
											
											case MouseLocation.West:
											case MouseLocation.East:
											{
												Cursor.SetCursor(Assets.Cursors.eastWest, new Vector2(16f, 16f), CursorMode.Auto);
											}
											break;
											
											case MouseLocation.NorthWest:
											case MouseLocation.SouthEast:
											{
												Cursor.SetCursor(Assets.Cursors.northWestSouthEast, new Vector2(16f, 16f), CursorMode.Auto);
											}
											break;
											
											case MouseLocation.NorthEast:
											case MouseLocation.SouthWest:
											{
												Cursor.SetCursor(Assets.Cursors.northEastSouthWest, new Vector2(16f, 16f), CursorMode.Auto);
											}
											break;
											
											case MouseLocation.Header:
											case MouseLocation.Inside:
											{
												Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
											}
											break;
											
											case MouseLocation.Outside:
											{
												Debug.LogError("Incorrect mouse location");
											}
											break;
											
											default:
											{
												Debug.LogError("Unknown mouse location");
											}
											break;
										}
									}
								}
								break;

								case WindowState.Minimized:
								{
									if (isInsideButtons)
									{
										mMouseLocation = MouseLocation.Inside;
									}
									else
									{
										mMouseLocation = MouseLocation.Header;
									}
								}
								break;

								case WindowState.Maximized:
								{
									if (isInsideButtons)
									{
										mMouseLocation = MouseLocation.Inside;
									}
									else
									{
										if (mouseY <= mBorderTop - MAXIMIZED_OFFSET)
										{
											mMouseLocation = MouseLocation.Header;
										}
										else
										{
											mMouseLocation = MouseLocation.Inside;
										}
									}
								}
								break;

								case WindowState.FullScreen:
								{
									Debug.LogError("Incorrect window state");
								}
								break;

								default:
								{
									Debug.LogError("Unknown window state");
								}
								break;
							}

							switch (mMouseLocation)
							{
								case MouseLocation.Header:
								{
									if (InputControl.GetMouseButtonDown(MouseButton.Left))
									{
										mMouseState = MouseState.Dragging;
										
										mMouseContext = new MouseContext(mouseX, mouseY, x, y, width, height, mWindowTransform.offsetMin.x, -mWindowTransform.offsetMax.y);
									}
								}
								break;

								case MouseLocation.North:
								case MouseLocation.South:
								case MouseLocation.West:
								case MouseLocation.East:
								case MouseLocation.NorthWest:
								case MouseLocation.SouthEast:
								case MouseLocation.NorthEast:
								case MouseLocation.SouthWest:
								{
									if (mResizable && mState == WindowState.NoState)
									{
										if (InputControl.GetMouseButtonDown(MouseButton.Left))
										{
											mMouseState = MouseState.Resizing;
											
											mMouseContext = new MouseContext(mouseX, mouseY, x, y, width, height, mWindowTransform.offsetMin.x, -mWindowTransform.offsetMax.y);
										}
									}									
								}
								break;

								case MouseLocation.Inside:
								{
									// Nothing
								}
								break;

								case MouseLocation.Outside:
								{
									Debug.LogError("Incorrect mouse location");
								}
								break;

								default:
								{
									Debug.LogError("Unknown mouse location");
								}
								break;
							}
						}
					}
					break;

					case MouseState.Dragging:
					{
						Vector3 mousePos = InputControl.mousePosition;
						
						float mouseX = mousePos.x;
						float mouseY = Screen.height - mousePos.y;
						
						#region Calculate new position
						int screenWidth  = Screen.width;
						int screenHeight = Screen.height;
						
						if (mState == WindowState.Maximized)
						{
							// TODO: Go to NoState instead of this
							mMouseState   = MouseState.NoState;							
							mMouseContext = null;
							
							return;
							// end of to do
						}

						float newX = 0f; 
						float newY = 0f;

						switch (mState)
						{
							case WindowState.NoState:
							{
								newX = mMouseContext.previousX + mouseX - mMouseContext.previousMouseX; 
								newY = mMouseContext.previousY + mouseY - mMouseContext.previousMouseY;
							}
							break;

							case WindowState.Minimized:
							{
								newX = mMouseContext.previousRectX + mouseX - mMouseContext.previousMouseX + SHADOW_WIDTH; 
								newY = mMouseContext.previousRectY + mouseY - mMouseContext.previousMouseY + SHADOW_WIDTH;
							}
							break;

							case WindowState.Maximized:
							case WindowState.FullScreen:
							{
								Debug.LogError("Incorrect window state");
							}
							break;

							default:
							{
								Debug.LogError("Unknown window state");
							}
							break;
						}

						float windowWidth = mWindowTransform.sizeDelta.x - 2 * SHADOW_WIDTH;

						if (newX + windowWidth < DRAGGING_GAP)
						{
							newX = -windowWidth + DRAGGING_GAP; // TODO: Show new transform aligned to the left
						}
						else
						if (newX > screenWidth - DRAGGING_GAP)
						{
							newX = screenWidth - DRAGGING_GAP; // TODO: Show new transform aligned to the right
						}
						
						if (newY < -mBorderTop + DRAGGING_GAP + SHADOW_WIDTH)
						{
							newY = -mBorderTop + DRAGGING_GAP + SHADOW_WIDTH; // TODO: Show new transform stretch to screen
						}
						else
						if (newY > screenHeight - DRAGGING_GAP)
						{
							newY = screenHeight - DRAGGING_GAP;
						}

						switch (mState)
						{
							case WindowState.NoState:
							{								
								x = newX; 
								y = newY;
							}
							break;

							case WindowState.Minimized:
							{
								newX -= SHADOW_WIDTH;
								newY -= SHADOW_WIDTH;
								windowWidth += 2 * SHADOW_WIDTH;
								float windowHeight = mWindowTransform.sizeDelta.y;

								mWindowTransform.offsetMin = new Vector2(
							                                               newX
							                                             , -newY - windowHeight
							                                            );

								mWindowTransform.offsetMax = new Vector2(
							                                               newX + windowWidth
							                                             , -newY
							                                            );
							}
							break;

							case WindowState.Maximized:
							case WindowState.FullScreen:
							{
								Debug.LogError("Incorrect window state");
							}
							break;

							default:
							{
								Debug.LogError("Unknown window state");
							}
							break;
						}
						#endregion

						if (InputControl.GetMouseButtonUp(MouseButton.Left))
						{
							// TODO: Apply transform if showed

							mMouseState   = MouseState.NoState;							
							mMouseContext = null;
							
							Vector3[] corners = Utils.GetWindowCorners(mWindowTransform);
							
							if (
								mouseX < corners[0].x + SHADOW_WIDTH || mouseX > corners[3].x - SHADOW_WIDTH
								||
								mouseY < corners[0].y + SHADOW_WIDTH || mouseY > corners[3].y - SHADOW_WIDTH
							   )
							{
								mMouseLocation = MouseLocation.Outside;
							}
						}
					}
					break;

					case MouseState.Resizing:
					{
						Vector3 mousePos = InputControl.mousePosition;
						
						float mouseX = mousePos.x;
						float mouseY = Screen.height - mousePos.y;

						#region Calculate new geometry
						int screenWidth  = Screen.width;
						int screenHeight = Screen.height;

						#region West
						if (
						    mMouseLocation == MouseLocation.West
						    || 
							mMouseLocation == MouseLocation.NorthWest
							||
							mMouseLocation == MouseLocation.SouthWest
						   )
						{
							float newX     = mMouseContext.previousX     + mouseX - mMouseContext.previousMouseX;
							float newWidth = mMouseContext.previousWidth - mouseX + mMouseContext.previousMouseX;
							
							if (newWidth < MINIMAL_WIDTH)
							{
								newX     -= MINIMAL_WIDTH - newWidth;
								newWidth  = MINIMAL_WIDTH;
							}

							if (mMinimumWidth != 0 && newWidth < mMinimumWidth)
							{
								newX     -= mMinimumWidth - newWidth;
								newWidth  = mMinimumWidth;
							}
							
							if (mMaximumWidth != 0 && newWidth > mMaximumWidth)
							{
								newX     -= mMaximumWidth - newWidth;
								newWidth  = mMaximumWidth;
							}

							if (newX > screenWidth - DRAGGING_GAP)
							{
								newWidth += newX - (screenWidth - DRAGGING_GAP);
								newX      = screenWidth - DRAGGING_GAP;								
							}

							x     = newX;
							width = newWidth;
						}
						#endregion
						else
						#region East
						if (
							mMouseLocation == MouseLocation.East
							|| 
							mMouseLocation == MouseLocation.NorthEast
							||
							mMouseLocation == MouseLocation.SouthEast
						   )
						{
							float newWidth = mMouseContext.previousWidth + mouseX - mMouseContext.previousMouseX;

							if (mMouseContext.previousX + newWidth < DRAGGING_GAP)
							{
								newWidth = -mMouseContext.previousX + DRAGGING_GAP;
							}
							
							width = newWidth;
						}
						#endregion

						#region North
						if (
							mMouseLocation == MouseLocation.North
							|| 
							mMouseLocation == MouseLocation.NorthWest
							||
							mMouseLocation == MouseLocation.NorthEast
						   )
						{
							float newY      = mMouseContext.previousY      + mouseY - mMouseContext.previousMouseY;
							float newHeight = mMouseContext.previousHeight - mouseY + mMouseContext.previousMouseY;
							
							if (newHeight < MINIMAL_HEIGHT)
							{
								newY      -= MINIMAL_HEIGHT - newHeight;
								newHeight  = MINIMAL_HEIGHT;
							}

							if (mMinimumHeight != 0 && newHeight < mMinimumHeight)
							{
								newY      -= mMinimumHeight - newHeight;
								newHeight  = mMinimumHeight;
							}
							
							if (mMaximumHeight != 0 && newHeight > mMaximumHeight)
							{
								newY      -= mMaximumHeight - newHeight;
								newHeight  = mMaximumHeight;
							}
							
							if (newY < -mBorderTop + DRAGGING_GAP + SHADOW_WIDTH)
							{
								newHeight -= -mBorderTop + DRAGGING_GAP + SHADOW_WIDTH - newY; // TODO: Show new transform stretch to height
								newY       = -mBorderTop + DRAGGING_GAP + SHADOW_WIDTH;
							}
							else
							if (newY > screenHeight - DRAGGING_GAP)
							{
								newHeight += newY - (screenHeight - DRAGGING_GAP);
								newY       = screenHeight - DRAGGING_GAP;
							}
							
							y      = newY;
							height = newHeight;	
						}
						#endregion
						else
						#region South
						if (
							mMouseLocation == MouseLocation.South
							|| 
							mMouseLocation == MouseLocation.SouthWest
							||
							mMouseLocation == MouseLocation.SouthEast
						   )
						{							
							height = mMouseContext.previousHeight + mouseY - mMouseContext.previousMouseY; // TODO: Show new transform stretch to height
						}
						#endregion
						#endregion

						if (InputControl.GetMouseButtonUp(MouseButton.Left))
						{
							// TODO: Apply transform if showed

							mMouseState   = MouseState.NoState;							
							mMouseContext = null;

							if (mouseX < mX + SHADOW_WIDTH || mouseX > mX + mWidth  - SHADOW_WIDTH
							    ||
							    mouseY < mY + SHADOW_WIDTH || mouseY > mY + mHeight - SHADOW_WIDTH)
							{
								Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
								mMouseLocation = MouseLocation.Outside;
							}
						}
					}
					break;

					default:
					{
						Debug.LogError("Unknown mouse state");
					}
					break;
				}
			}
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
