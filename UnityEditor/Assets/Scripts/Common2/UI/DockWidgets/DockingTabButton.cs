using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Common.UI.DragAndDrop;
using Common.UI.Windows;



namespace Common.UI.DockWidgets
{
    #region Internal namespace
    namespace Internal
    {
        /// <summary>
        /// Docking tab common things.
        /// </summary>
        static class DockingTabCommon
        {
            public static SpriteState buttonSpriteState;
            public static SpriteState activeButtonSpriteState;



            /// <summary>
            /// Initializes the <see cref="Common.UI.DockWidgets.Internal.DockingTabCommon"/> class.
            /// </summary>
            static DockingTabCommon()
            {
                buttonSpriteState       = new SpriteState();
                activeButtonSpriteState = new SpriteState();

                buttonSpriteState.disabledSprite          = Assets.DockWidgets.Textures.tabDisabled;
                buttonSpriteState.highlightedSprite       = Assets.DockWidgets.Textures.tabHighlighted;
                buttonSpriteState.pressedSprite           = Assets.DockWidgets.Textures.tabPressed;

                activeButtonSpriteState.disabledSprite    = Assets.DockWidgets.Textures.tabActiveDisabled;
                activeButtonSpriteState.highlightedSprite = Assets.DockWidgets.Textures.tabActiveHighlighted;
                activeButtonSpriteState.pressedSprite     = Assets.DockWidgets.Textures.tabActivePressed;
            }
        }
    }
    #endregion



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



        private DockWidgetScript mDockWidget;
        private bool             mActive;

        List<DockingAreaScript> mDockingAreas;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingTabButton"/> class.
        /// </summary>
        public DockingTabButton()
            : base()
        {
            transition = Selectable.Transition.SpriteSwap;

            mDockWidget = null;
            mActive     = false;

            mDockingAreas = null;

            onClick.AddListener(ButtonClicked);
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
        /// Handler for pointer down event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            if (eventData.button == PointerEventData.InputButton.Middle)
            {
                mDockWidget.Destroy();
            }
        }

        /// <summary>
        /// Handler for begin drag event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            ButtonClicked();

            DragInfoHolder.dockWidget    = mDockWidget;
            DragInfoHolder.minimum       = float.MaxValue;
            DragInfoHolder.dockingArea   = null;
            DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.Outside;

            mDockingAreas = new List<DockingAreaScript>(DockingAreaScript.instances);

            foreach (DockingAreaScript dockingArea in mDockingAreas)
            {
                dockingArea.CacheDragInfo();
            }

            StartCoroutine(CreateDraggingImage(eventData));
        }

        /// <summary>
        /// Handler for drag event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnDrag(PointerEventData eventData)
        {
            DragInfoHolder.minimum       = float.MaxValue;
            DragInfoHolder.dockingArea   = null;
            DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.Outside;

            RaycastResult     raycastResult  = eventData.pointerCurrentRaycast;
            DockingAreaScript hitDockingArea = null;

            if (raycastResult.gameObject != null)
            {
                hitDockingArea = Utils.FindInParents<DockingAreaScript>(raycastResult.gameObject);
            }

            if (hitDockingArea != null && hitDockingArea.HasDragInfo())
            {
                hitDockingArea.PreprocessDockWidgetDrag(eventData);
            }
            else
            {
                for (int i = mDockingAreas.Count - 1; i >= 0; --i)
                {
                    mDockingAreas[i].PreprocessDockWidgetDrag(eventData);
                }
            }

            if (DragInfoHolder.dockingArea != null)
            {
                DragInfoHolder.dockingArea.ProcessDockWidgetDrag(eventData);
            }

            if (DragInfoHolder.dockingArea != null)
            {
                DragData.HideImage();
            }
            else
            {
                DummyDockWidgetScript.DestroyInstance();

                DragData.ShowImage();
                DragData.Drag();
            }
        }

        /// <summary>
        /// Handler for end drag event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnEndDrag(PointerEventData eventData)
        {
            foreach (DockingAreaScript dockingArea in mDockingAreas)
            {
                dockingArea.ClearDragInfo();
            }

            mDockingAreas = null;

            if (DummyDockWidgetScript.instance != null)
            {
                int index = DummyDockWidgetScript.instance.parent.children.IndexOf(DummyDockWidgetScript.instance);

                if (index >= 0)
                {
                    DummyDockWidgetScript.instance.parent.InsertDockWidget(DragInfoHolder.dockWidget, index);
                    DummyDockWidgetScript.instance.parent.selectedIndex = index;
                }
                else
                {
                    Debug.LogError("Unexpected behaviour in DockingTabButton.OnEndDrag");
                }

                DummyDockWidgetScript.DestroyInstance();
            }
            else
            if (DragInfoHolder.dockingArea == null)
            {
                WindowScript parentWindow = Utils.FindInParents<WindowScript>(gameObject);

                if (parentWindow != null)
                {
                    //***************************************************************************
                    // DockingWindow GameObject
                    //***************************************************************************
                    #region DockingWindow GameObject
                    GameObject dockingWindow = new GameObject("DockingWindow");
                    Utils.InitUIObject(dockingWindow, parentWindow.transform.parent);

                    //===========================================================================
                    // DockingWindowScript Component
                    //===========================================================================
                    #region DockingWindowScript Component
                    DockingWindowScript dockingWindowScript = dockingWindow.AddComponent<DockingWindowScript>();

                    dockingWindowScript.dockWidget = DragInfoHolder.dockWidget;

                    // TODO: [Trivial] Check it home
                    dockingWindowScript.x      = DragData.x      - 8f;
                    dockingWindowScript.y      = DragData.y      - 13f; // - 8f      - 5f
                    dockingWindowScript.width  = DragData.width  + 16f; // + 8f + 8f
                    dockingWindowScript.height = DragData.height + 21f; // + 8f + 8f + 5f

                    dockingWindowScript.Show();
                    #endregion
                    #endregion
                }
                else
                {
                    Debug.LogError("Unexpected behaviour in DockingTabButton.OnEndDrag");
                }
            }

            DragInfoHolder.dockWidget    = null;
            DragInfoHolder.minimum       = float.MaxValue;
            DragInfoHolder.dockingArea   = null;
            DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.Outside;

            DragData.EndDrag();
        }

        /// <summary>
        /// Creates the dragging image.
        /// </summary>
        /// <returns>The dragging image.</returns>
        /// <param name="eventData">Pointer data.</param>
        public IEnumerator CreateDraggingImage(PointerEventData eventData)
        {
            yield return new WaitForEndOfFrame();

            Vector3[] corners = Utils.GetWindowCorners(mDockWidget.parent.transform as RectTransform);

            float screenWidth  = Screen.width;
			float screenHeight = Screen.height;

            float left   = corners[0].x * Utils.canvasScale;
			float top    = corners[0].y * Utils.canvasScale;
			float right  = corners[3].x * Utils.canvasScale;
			float bottom = corners[3].y * Utils.canvasScale;

            if (left < 0f)
            {
                left = 0f;
            }

            if (top < 0f)
            {
                top = 0f;
            }

            if (right > screenWidth - 1)
            {
                right = screenWidth - 1;
            }

            if (bottom > screenHeight - 1)
            {
                bottom = screenHeight - 1;
            }

            int widgetX      = Mathf.CeilToInt(left);
            int widgetY      = Mathf.CeilToInt(top);
            int widgetWidth  = Mathf.FloorToInt(right  - left);
            int widgetHeight = Mathf.FloorToInt(bottom - top);

			float dragPosX = (eventData.pressPosition.x                - widgetX) / Utils.canvasScale;
			float dragPosY = (screenHeight - eventData.pressPosition.y - widgetY) / Utils.canvasScale;

            DragData.BeginDrag(
                                 DraggingType.DockWidget
                               , gameObject
                               , Sprite.Create(
                                                 Utils.TakeScreenshot(widgetX, widgetY, widgetWidth, widgetHeight)
                                               , new Rect(0, 0, widgetWidth, widgetHeight)
                                               , new Vector2(0.5f, 0.5f)
                                              )
				               , widgetWidth  / Utils.canvasScale
							   , widgetHeight / Utils.canvasScale
                               , dragPosX
                               , dragPosY
                              );
        }

        /// <summary>
        /// Button click handler.
        /// </summary>
        private void ButtonClicked()
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
                image.sprite = Assets.DockWidgets.Textures.tabActive;
                spriteState = Internal.DockingTabCommon.activeButtonSpriteState;
            }
            else
            {
                image.sprite = Assets.DockWidgets.Textures.tab;
                spriteState = Internal.DockingTabCommon.buttonSpriteState;
            }
        }
    }
}

