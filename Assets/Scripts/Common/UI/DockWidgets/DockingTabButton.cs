using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Button component for docking group tab.
	/// </summary>
	public class DockingTabButton : Button, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		/// <summary>
		/// Gets or sets the dock widget.
		/// </summary>
		/// <value>The dock widget.</value>
		public DockWidgetScript dockWidget
		{
			get { return mDockWidget;  }
			set { mDockWidget = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Common.UI.DockWidgets.DockingTabButton"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool active
		{
			get
			{
				return mActive;  
			}

			set
			{
				if (mActive != value)
				{
					mActive = value;
				
					UpdateImage();
				}
			}
		}



		private static GameObject draggingImage = null;



		private DockWidgetScript mDockWidget;
		private bool             mActive;
		private bool             mSelected;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingTabButton"/> class.
		/// </summary>
		public DockingTabButton()
			: base()
		{
			mDockWidget = null;
			mActive     = false;
			mSelected   = false;

			onClick.AddListener(buttonClicked);
		}

		/// <summary>
		/// Script starting callback.
		/// </summary>
		protected override void Start()
		{
			base.Start();

			UpdateImage();
		}

		/// <summary>
		/// Handler for select event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);

			mSelected = true;
			UpdateImage();
		}

		/// <summary>
		/// Handler for deselect event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);

			mSelected = false;
			UpdateImage();
		}

		/// <summary>
		/// Handler for begin drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnBeginDrag(PointerEventData eventData)
		{
			buttonClicked();

			if (draggingImage == null)
			{
				StartCoroutine(CreateDraggingImage());
			}
			else
			{
				Debug.LogError("Dragging image already exists");
			}
		}

		/// <summary>
		/// Handler for drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnDrag(PointerEventData eventData)
		{
			if (draggingImage != null)
			{
				// TODO: Implement
			}
		}

		/// <summary>
		/// Handler for end drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnEndDrag(PointerEventData eventData)
		{
			if (draggingImage != null)
			{
				UnityEngine.Object.DestroyObject(draggingImage);
				draggingImage = null;
			}
		}

		public IEnumerator CreateDraggingImage()
		{
			yield return new WaitForEndOfFrame();

			Canvas canvas = Utils.FindInParents<Canvas>(gameObject);
			
			if (canvas != null)
			{				
				Vector3[] corners = Utils.GetWindowCorners(mDockWidget.parent.transform as RectTransform);
				
				int screenX      = (int)corners[0].x;
				int screenY      = (int)corners[0].y;
				int screenWidth  = (int)(corners[3].x - corners[0].x);
				int screenHeight = (int)(corners[3].y - corners[0].y);
								
				// TODO: Implement
				
				//===========================================================================
				// Image GameObject
				//===========================================================================
				#region Image GameObject
				draggingImage = new GameObject("DraggingImage");
				Utils.InitUIObject(draggingImage, canvas.transform);
				
				//===========================================================================
				// RectTransform Component
				//===========================================================================
				#region RectTransform Component
				RectTransform imageTransform = draggingImage.AddComponent<RectTransform>();
				Utils.AlignRectTransformTopLeft(imageTransform, screenWidth, screenHeight);
				#endregion
				
				//===========================================================================
				// CanvasRenderer Component
				//===========================================================================
				#region CanvasRenderer Component
				draggingImage.AddComponent<CanvasRenderer>();
				#endregion
				
				//===========================================================================
				// Image Component
				//===========================================================================
				#region Image Component
				Image image = draggingImage.AddComponent<Image>();
				
				image.sprite = Sprite.Create(Utils.TakeScreenshot(screenX, screenY, screenWidth, screenHeight), new Rect(0, 0, screenWidth, screenHeight), new Vector2(0.5f, 0.5f));
				image.type   = Image.Type.Sliced;
				#endregion
				#endregion
			}
			else
			{
				Debug.LogError("Canvas not found");
			}
		}

		/// <summary>
		/// Button click handler.
		/// </summary>
		private void buttonClicked()
		{
			mDockWidget.Select();
		}

		/// <summary>
		/// Updates background image.
		/// </summary>
		private void UpdateImage()
		{
			if (mActive)
			{
				if (mSelected)
				{
					image.sprite = Assets.DockWidgets.Textures.tabSelected;
				}
				else
				{
					image.sprite = Assets.DockWidgets.Textures.tabActive;
				}
			}
			else
			{
				image.sprite = Assets.DockWidgets.Textures.tab;
			}
		}
	}
}

