using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityTranslation;

using Common.UI.Popups;



namespace Common.UI.DockWidgets
{
    #region Internal namespace
    namespace Internal
    {
        /// <summary>
        /// Docking group common things.
        /// </summary>
        static class DockingGroupCommon
        {
            public static SpriteState unlockedButtonSpriteState;
            public static SpriteState lockedButtonSpriteState;
            public static SpriteState contextMenuButtonSpriteState;



            /// <summary>
            /// Initializes the <see cref="Common.UI.DockWidgets.Internal.DockingGroupCommon"/> class.
            /// </summary>
            static DockingGroupCommon()
            {
                unlockedButtonSpriteState    = new SpriteState();
                lockedButtonSpriteState      = new SpriteState();
                contextMenuButtonSpriteState = new SpriteState();

                unlockedButtonSpriteState.disabledSprite       = Assets.DockWidgets.Textures.unlockedButtonDisabled;
                unlockedButtonSpriteState.highlightedSprite    = Assets.DockWidgets.Textures.unlockedButtonHighlighted;
                unlockedButtonSpriteState.pressedSprite        = Assets.DockWidgets.Textures.unlockedButtonPressed;

                lockedButtonSpriteState.disabledSprite         = Assets.DockWidgets.Textures.lockedButtonDisabled;
                lockedButtonSpriteState.highlightedSprite      = Assets.DockWidgets.Textures.lockedButtonHighlighted;
                lockedButtonSpriteState.pressedSprite          = Assets.DockWidgets.Textures.lockedButtonPressed;

                contextMenuButtonSpriteState.disabledSprite    = Assets.DockWidgets.Textures.contextMenuButtonDisabled;
                contextMenuButtonSpriteState.highlightedSprite = Assets.DockWidgets.Textures.contextMenuButtonHighlighted;
                contextMenuButtonSpriteState.pressedSprite     = Assets.DockWidgets.Textures.contextMenuButtonPressed;
            }
        }
    }
    #endregion



    /// <summary>
    /// Script that realize docking group behaviour.
    /// </summary>
    public class DockingGroupScript : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets parent docking area.
        /// </summary>
        /// <value>Parent docking area.</value>
        public DockingAreaScript parent
        {
            get { return mParent;  }
            set { mParent = value; }
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        public ReadOnlyCollection<DockWidgetScript> children
        {
            get { return mChildren.AsReadOnly(); }
        }

        /// <summary>
        /// Gets or sets the index of selected tab.
        /// </summary>
        /// <value>The index of selected tab.</value>
        public int selectedIndex
        {
            get
            {
                return mSelectedIndex;
            }

            set
            {
                if (mSelectedIndex != value)
                {
                    if (value >= 0 && value < mChildren.Count)
                    {
                        if (mSelectedIndex != -1)
                        {
                            mContentTransform.GetChild(mSelectedIndex).gameObject.SetActive(false);
                            DockingTabButton tabButton = mTabsTransform.GetChild(mSelectedIndex).GetComponent<DockingTabButton>();

                            tabButton.active = false;
                        }

                        mSelectedIndex = value;

                        if (mSelectedIndex != -1)
                        {
                            mContentTransform.GetChild(mSelectedIndex).gameObject.SetActive(true);
                            DockingTabButton tabButton = mTabsTransform.GetChild(mSelectedIndex).GetComponent<DockingTabButton>();

                            tabButton.active = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("Invalid selected index value: " + value);
                    }
                }
            }
        }



        private DockingAreaScript      mParent;
        private List<DockWidgetScript> mChildren;
        private int                    mSelectedIndex;

        private RectTransform mTabsTransform;
        private RectTransform mContentTransform;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingGroupScript"/> class.
        /// </summary>
        public DockingGroupScript()
            : base()
        {
            mParent        = null;
            mChildren      = new List<DockWidgetScript>();
            mSelectedIndex = -1;

            mTabsTransform    = null;
            mContentTransform = null;
        }

        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Awake()
        {
            Translator.AddLanguageChangedListener(UpdateTabs);

            CreateUI();
        }

        /// <summary>
        /// Creates user interface.
        /// </summary>
        private void CreateUI()
        {
            //===========================================================================
            // Tabs GameObject
            //===========================================================================
            #region Tabs GameObject
            GameObject tabs = new GameObject("Tabs");
            Utils.InitUIObject(tabs, transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mTabsTransform = tabs.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(mTabsTransform, 16f);
            #endregion

            //***************************************************************************
            // ContextMenu GameObject
            //***************************************************************************
            #region ContextMenu GameObject
            GameObject contextMenuGameObject = new GameObject("ContextMenu");
            Utils.InitUIObject(contextMenuGameObject, tabs.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform contextMenuTransform = contextMenuGameObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopRight(contextMenuTransform, 14f, 5f, 5f, 10f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            contextMenuGameObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image contextMenuImage = contextMenuGameObject.AddComponent<Image>();

            contextMenuImage.sprite = Assets.DockWidgets.Textures.contextMenuButton;
            contextMenuImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button contextMenuButton = contextMenuGameObject.AddComponent<Button>();

            contextMenuButton.targetGraphic = contextMenuImage;
            contextMenuButton.transition    = Selectable.Transition.SpriteSwap;
            contextMenuButton.spriteState   = Internal.DockingGroupCommon.contextMenuButtonSpriteState;
            contextMenuButton.onClick.AddListener(OnContextMenuButtonClicked);
            #endregion
            #endregion

            //***************************************************************************
            // Lock GameObject
            //***************************************************************************
            #region Lock GameObject
            GameObject lockGameObject = new GameObject("Lock");
            Utils.InitUIObject(lockGameObject, tabs.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform lockTransform = lockGameObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopRight(lockTransform, 7f, 9f, 25f, 6f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            lockGameObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image lockImage = lockGameObject.AddComponent<Image>();

            lockImage.sprite = Assets.DockWidgets.Textures.unlockedButton;
            lockImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button lockButton = lockGameObject.AddComponent<Button>();

            lockButton.targetGraphic = lockImage;
            lockButton.transition    = Selectable.Transition.SpriteSwap;
            lockButton.spriteState   = Internal.DockingGroupCommon.unlockedButtonSpriteState;
            lockButton.onClick.AddListener(OnLockButtonClicked);
            #endregion
            #endregion
            #endregion

            //===========================================================================
            // Pages GameObject
            //===========================================================================
            #region Pages GameObject
            GameObject pages = new GameObject("Pages");
            Utils.InitUIObject(pages, transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform pagesTransform = pages.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(pagesTransform, 0f, 16f, 0f, 0f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            pages.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image pagesImage = pages.AddComponent<Image>();

            pagesImage.sprite = Assets.DockWidgets.Textures.pageBackground;
            pagesImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Content GameObject
            //===========================================================================
            #region Content GameObject
            GameObject content = new GameObject("Content");
            Utils.InitUIObject(content, pages.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mContentTransform = content.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(
                                                     mContentTransform
                                                   , pagesImage.sprite.border.x
                                                   , pagesImage.sprite.border.w
                                                     , pagesImage.sprite.border.z
                                                   , pagesImage.sprite.border.y
                                                  );
            #endregion
            #endregion
            #endregion

            mTabsTransform.SetAsLastSibling();
        }

        /// <summary>
        /// Destroy this instance.
        /// </summary>
        public void Destroy()
        {
            UnityEngine.Object.DestroyObject(gameObject);

            if (mParent != null)
            {
                mParent.RemoveDockingGroup(this);
            }
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            Translator.RemoveLanguageChangedListener(UpdateTabs);
        }

        /// <summary>
        /// Handler for resize event.
        /// </summary>
        public void OnResize()
        {
            UpdateTabsGeometry();

            foreach (DockWidgetScript child in mChildren)
            {
                child.OnResize();
            }
        }

        /// <summary>
        /// Updates tabs geometry.
        /// </summary>
        private void UpdateTabsGeometry()
        {
            bool hasDummyWidget = false;
            List<float> tabWidths = new List<float>();
            float totalWidth = 0f;

            for (int i = 0; i < mChildren.Count; ++i)
            {
                Text tabText = mTabsTransform.GetChild(i).GetChild(1).GetComponent<Text>(); // Tab/Text

                float tabWidth = tabText.preferredWidth + 40f;

                tabWidths.Add(tabWidth);

                if (mChildren[i] == DummyDockWidgetScript.instance && mChildren.Count > 1)
                {
                    hasDummyWidget = true;
                }
                else
                {
                    totalWidth += tabWidth;
                }
            }

            Vector3[] corners = new Vector3[4];
            (transform as RectTransform).GetLocalCorners(corners);
            float width = corners[2].x - corners[0].x - 37f;

            if (width < 10f)
            {
                width = 10f;
            }

            float contentWidth = 0f;

            if (totalWidth <= width)
            {
                for (int i = 0; i < mChildren.Count; ++i)
                {
                    RectTransform tabTransform = mTabsTransform.GetChild(i) as RectTransform;

                    Utils.AlignRectTransformStretchLeft(tabTransform, tabWidths[i], contentWidth, 0f, -1f);
                    contentWidth += tabWidths[i];
                }
            }
            else
            {
                float tabWidth;

                if (hasDummyWidget)
                {
                    tabWidth = width / (mChildren.Count - 1);
                }
                else
                {
                    tabWidth = width / mChildren.Count;
                }

                for (int i = 0; i < mChildren.Count; ++i)
                {
                    RectTransform tabTransform = mTabsTransform.GetChild(i) as RectTransform;

                    Utils.AlignRectTransformStretchLeft(tabTransform, tabWidth, contentWidth, 0f, -1f);
                    contentWidth += tabWidth;
                }
            }
        }

        /// <summary>
        /// Updates tabs.
        /// </summary>
        private void UpdateTabs()
        {
            for (int i = 0; i < mChildren.Count; ++i)
            {
                Text tabText = mTabsTransform.GetChild(i).GetChild(1).GetComponent<Text>(); // Tab/Text

                tabText.text = mChildren[i].title;
            }

            UpdateTabsGeometry();
        }

        /// <summary>
        /// Updates tab image.
        /// </summary>
        /// <param name="dockWidget">Dock widget.</param>
        public void UpdateTabImage(DockWidgetScript dockWidget)
        {
            if (dockWidget.parent == this)
            {
                int index = mChildren.IndexOf(dockWidget);

                if (index >= 0)
                {
                    Image tabImage = mTabsTransform.GetChild(index).GetChild(0).GetComponent<Image>(); // Tab/Image

                    tabImage.sprite = dockWidget.image;
                }
                else
                {
                    Debug.LogError("Failed to update tab image");
                }
            }
            else
            {
                Debug.LogError("Dock widget belongs not to this docking group");
            }
        }

        /// <summary>
        /// Updates tab.
        /// </summary>
        /// <param name="dockWidget">Dock widget.</param>
        public void UpdateTab(DockWidgetScript dockWidget)
        {
            if (dockWidget.parent == this)
            {
                int index = mChildren.IndexOf(dockWidget);

                if (index >= 0)
                {
                    Text tabText = mTabsTransform.GetChild(index).GetChild(1).GetComponent<Text>(); // Tab/Text

                    tabText.text = dockWidget.title;

                    UpdateTabsGeometry();
                }
                else
                {
                    Debug.LogError("Failed to update tab");
                }
            }
            else
            {
                Debug.LogError("Dock widget belongs not to this docking group");
            }
        }

        /// <summary>
        /// Handler for tab select event.
        /// </summary>
        /// <param name="dockWidget">Dock widget.</param>
        public void OnSelectTab(DockWidgetScript dockWidget)
        {
            if (dockWidget.parent == this)
            {
                int index = mChildren.IndexOf(dockWidget);

                if (index >= 0)
                {
                    selectedIndex = index;
                }
                else
                {
                    Debug.LogError("Failed to select tab");
                }
            }
            else
            {
                Debug.LogError("Dock widget belongs not to this docking group");
            }
        }

        /// <summary>
        /// Handler for dock widget drag event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        /// <param name="dragCorners">Cached drag corners.</param>
        public void ProcessDockWidgetDrag(PointerEventData eventData, Vector3[] dragCorners)
        {
            float x = eventData.position.x - dragCorners[0].x;

            DragInfoHolder.dockingArea = mParent;

            #region Insert dummy dock widget if absent
            if (
                DummyDockWidgetScript.instance == null
                ||
                DummyDockWidgetScript.instance.parent != this
               )
            {
                DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
                    InsertToDockingGroup(this, 0);
            }
            #endregion

            int dummyIndex = -1;

            #region Find dummy dock widget position
            float contentWidth = 0f;

            int index = 0;

            for (int i = 0; i < mChildren.Count; ++i)
            {
                if (mChildren[i] == DummyDockWidgetScript.instance)
                {
                    dummyIndex = i;
                }
                else
                {
                    RectTransform tabTransform = mTabsTransform.GetChild(i) as RectTransform;

                    float tabWidth = tabTransform.sizeDelta.x;

                    if (
                        x >= contentWidth
                        &&
                        x <= contentWidth + tabWidth
                       )
                    {
                        if (x <= contentWidth + tabWidth / 2)
                        {
                            index = i;
                        }
                        else
                        {
                            index = i + 1;
                        }
                    }

                    contentWidth += tabWidth;
                }
            }

            if (x >= contentWidth)
            {
                index = mChildren.Count;
            }

            if (dummyIndex < index)
            {
                --index;
            }

            dummyIndex = index;
            #endregion

            InsertDockWidget(DummyDockWidgetScript.instance, dummyIndex);

            int dockWidgetIndex = -1;

            #region Place tabs where it should be
            contentWidth = 0f;

            for (int i = 0; i < mChildren.Count; ++i)
            {
                if (mChildren[i] == DragInfoHolder.dockWidget)
                {
                    dockWidgetIndex = i;
                }
                else
                {
                    RectTransform tabTransform = mTabsTransform.GetChild(i) as RectTransform;

                    float tabWidth = tabTransform.sizeDelta.x;

                    if (i == dummyIndex)
                    {
                        Utils.AlignRectTransformStretchLeft(tabTransform, tabWidth, x - tabWidth * 0.3f, 0f, -1f);
                    }
                    else
                    {
                        Utils.AlignRectTransformStretchLeft(tabTransform, tabWidth, contentWidth, 0f, -1f);
                    }

                    contentWidth += tabWidth;
                }
            }
            #endregion

            if (dockWidgetIndex >= 0)
            {
                RectTransform tabTransform      = mTabsTransform.GetChild(dockWidgetIndex) as RectTransform;
                RectTransform dummyTabTransform = mTabsTransform.GetChild(dummyIndex)      as RectTransform;

                tabTransform.offsetMin = dummyTabTransform.offsetMin;
                tabTransform.offsetMax = dummyTabTransform.offsetMax;
            }
        }

        /// <summary>
        /// Insert the specified dock widget.
        /// </summary>
        /// <param name="dockWidget">Dock widget.</param>
        /// <param name="index">Index.</param>
        public void InsertDockWidget(DockWidgetScript dockWidget, int index = 0)
        {
            if (dockWidget.parent != null)
            {
                if (dockWidget.parent == this)
                {
                    if (index < mChildren.Count && mChildren[index] == dockWidget)
                    {
                        // Do nothing
                        return;
                    }

                    int foundIndex = mChildren.IndexOf(dockWidget);

                    if (foundIndex >= 0)
                    {
                        if (mSelectedIndex == foundIndex)
                        {
                            mSelectedIndex = index;
                        }
                        else
                        if (mSelectedIndex >= 0)
                        {
                            if (foundIndex < mSelectedIndex)
                            {
                                --mSelectedIndex;
                            }

                            if (index <= mSelectedIndex)
                            {
                                ++mSelectedIndex;
                            }
                        }

                        mChildren.RemoveAt(foundIndex);
                        mChildren.Insert(index, dockWidget);

                        mTabsTransform.GetChild(foundIndex).SetSiblingIndex(index);
                        dockWidget.transform.SetSiblingIndex(index);

                        UpdateTabsGeometry();
                    }
                    else
                    {
                        Debug.LogError("Failed to insert dock widget");
                    }

                    return;
                }
                else
                {
                    dockWidget.parent.RemoveDockWidget(dockWidget);
                }
            }

            dockWidget.parent = this;
            mChildren.Insert(index, dockWidget);

            dockWidget.transform.SetParent(mContentTransform, false);
            dockWidget.transform.SetSiblingIndex(index);

            if (mSelectedIndex == -1)
            {
                mSelectedIndex = index;

                dockWidget.gameObject.SetActive(true);
            }
            else
            {
                if (index <= mSelectedIndex)
                {
                    ++mSelectedIndex;
                }

                dockWidget.gameObject.SetActive(false);
            }

            //===========================================================================
            // Tab GameObject
            //===========================================================================
            #region Tab GameObject
            GameObject tab = new GameObject("Tab");
            Utils.InitUIObject(tab, mTabsTransform);
            tab.transform.SetSiblingIndex(index);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            tab.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            tab.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image tabImage = tab.AddComponent<Image>();

            tabImage.type = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // DockingTabButton Component
            //===========================================================================
            #region DockingTabButton Component
            DockingTabButton tabButton = tab.AddComponent<DockingTabButton>();

            tabButton.targetGraphic = tabImage;
            tabButton.dockWidget    = dockWidget;
            tabButton.active        = (mSelectedIndex == index) || (dockWidget == DummyDockWidgetScript.instance);
            #endregion

            //===========================================================================
            // ContextMenuScript Component
            //===========================================================================
            #region ContextMenuScript Component
            ContextMenuScript tabContextMenu = tab.AddComponent<ContextMenuScript>();

            tabContextMenu.sourceObject      = dockWidget;
            tabContextMenu.onShowContextMenu = OnShowContextMenu;
            #endregion

            //===========================================================================
            // Image GameObject
            //===========================================================================
            #region Image GameObject
            GameObject imageGameObject = new GameObject("Image");
            Utils.InitUIObject(imageGameObject, tab.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform imageTransform = imageGameObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(imageTransform, 12f, 12f, 9f, 3f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            imageGameObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image image = imageGameObject.AddComponent<Image>();

            image.sprite = dockWidget.image;
            image.type   = Image.Type.Sliced;
            #endregion
            #endregion

            //===========================================================================
            // Text GameObject
            //===========================================================================
            #region Text GameObject
            GameObject textObject = new GameObject("Text");
            Utils.InitUIObject(textObject, tab.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform textTransform = textObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(textTransform, 25f, 0f, 6f, 0f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            Text text = textObject.AddComponent<Text>();

            Assets.DockWidgets.TextStyles.title.Apply(text);
            text.text = dockWidget.title;
            #endregion
            #endregion
            #endregion

            UpdateTabsGeometry();
        }

        /// <summary>
        /// Removes the dock widget.
        /// </summary>
        /// <param name="dockWidget">Dock widget.</param>
        public void RemoveDockWidget(DockWidgetScript dockWidget)
        {
            if (dockWidget.parent == this)
            {
                int index = mChildren.IndexOf(dockWidget);

                if (index >= 0)
                {
                    dockWidget.parent = null;

                    Transform tab = mTabsTransform.GetChild(index);

                    mContentTransform.GetChild(index).SetAsLastSibling();
                    tab.SetAsLastSibling();
                    UnityEngine.Object.DestroyObject(tab.gameObject);
                    mChildren.RemoveAt(index);

                    if (mChildren.Count > 0)
                    {
                        if (index == mSelectedIndex)
                        {
                            int temp = mSelectedIndex;
                            mSelectedIndex = -1;

                            if (temp < mChildren.Count)
                            {
                                selectedIndex = temp;
                            }
                            else
                            {
                                selectedIndex = mChildren.Count - 1;
                            }
                        }
                        else
                        if (index < mSelectedIndex)
                        {
                            --mSelectedIndex;
                        }

                        UpdateTabsGeometry();
                    }
                    else
                    {
                        Destroy();
                    }
                }
                else
                {
                    Debug.LogError("Failed to remove dock widget");
                }
            }
            else
            {
                Debug.LogError("Dock widget belongs not to this docking group");
            }
        }

        /// <summary>
        /// Handler for show context menu event.
        /// </summary>
        /// <param name="sourceObject">Source object.</param>
        private void OnShowContextMenu(object sourceObject)
        {
            DockWidgetScript dockWidget = sourceObject as DockWidgetScript;

            if (dockWidget != null)
            {
                // TODO: [Major] Show context menu
                AppUtils.ShowContributeMessage();
            }
            else
            {
                Debug.LogError("Unexpected behaviour in DockingGroupScript.OnShowContextMenu");
            }
        }

        /// <summary>
        /// Handler for lock button click event.
        /// </summary>
        private void OnLockButtonClicked()
        {
            // TODO: [Major] Implement DockingGroupScript.OnLockButtonClicked
            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for context menu button click event.
        /// </summary>
        private void OnContextMenuButtonClicked()
        {
            // TODO: [Major] Implement DockingGroupScript.OnContextMenuButtonClicked
            AppUtils.ShowContributeMessage();
        }
    }
}
