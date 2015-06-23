using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Button component for docking group tab.
	/// </summary>
	public class DockingTabButton : Button, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
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
			Canvas canvas = FindInParents<Canvas>();
			
			if (canvas != null)
			{
				buttonClicked();
				
				if (draggingImage == null)
				{
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
					Utils.AlignRectTransformTopLeft(imageTransform, 100f, 100f);
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
                    
                    image.sprite = dockWidget.image;
                    image.type   = Image.Type.Sliced;
                    #endregion
                    #endregion
                }
                else
                {
                    Debug.LogError("Dragging image already exists");
				}
			}
			else
			{
				Debug.LogError("Canvas not found");
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

		/// <summary>
		/// Handler for drop event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnDrop(PointerEventData eventData)
		{
			Debug.LogError("Drop");
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

		/// <summary>
		/// Search component in parents.
		/// </summary>
		/// <returns>Component with specified type if found in parents.</returns>
		/// <typeparam name="T">Type of component.</typeparam>
		private T FindInParents<T>() where T : Component
		{
			T component = gameObject.GetComponent<T>();
			
			if (component != null)
			{
				return component;
			}
			
			Transform curTransform = gameObject.transform.parent;
			
			while (curTransform != null && component == null)
			{
				component = curTransform.gameObject.GetComponent<T>();

				curTransform = curTransform.parent;
			}
			
			return component;
		}
	}
}

