using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityTranslation;

using Common;
using Common.UI.MenuItems;
using Common.UI.Popups;



namespace UI.Windows.MainWindow.MainMenu
{
    /// <summary>
    /// Main menu user interface.
    /// </summary>
    public class MainMenuUI
    {
        private const float AUTO_POPUP_DELAY = 0f;



        private MainMenuScript mScript;

        private SpriteState mButtonSpriteState;

        private GameObject    mScrollAreaContent;
        private RectTransform mScrollAreaContentTransform;

        #region Menu items
        private TreeNode<CustomMenuItem> mItems;

        #region File
        public TreeNode<CustomMenuItem> fileMenu;

//      public TreeNode<CustomMenuItem> file_ExitItem;
        #endregion

        #region Window
        public TreeNode<CustomMenuItem> windowMenu;

//      public TreeNode<CustomMenuItem> window_NextWindowItem;
//      public TreeNode<CustomMenuItem> window_PreviousWindowItem;

        #region Window -> Layouts
        public TreeNode<CustomMenuItem> window_LayoutsItem;

//      public TreeNode<CustomMenuItem> window_Layouts_DefaultItem;

//      public TreeNode<CustomMenuItem> window_Layouts_SaveLayoutItem;
//      public TreeNode<CustomMenuItem> window_Layouts_DeleteLayoutItem;
//      public TreeNode<CustomMenuItem> window_Layouts_RevertFactorySettingsItem;
        #endregion

        #region Window -> Screenshot
        public TreeNode<CustomMenuItem> window_ScreenshotSeparator;
        public TreeNode<CustomMenuItem> window_ScreenshotItem;

//      public TreeNode<CustomMenuItem> window_Screenshot_SetWindowSizeItem;
//      public TreeNode<CustomMenuItem> window_Screenshot_SetWindowSizeSmallItem;
//      public TreeNode<CustomMenuItem> window_Screenshot_SnapViewItem;
        #endregion

//      public TreeNode<CustomMenuItem> window_ServersItem;
        #endregion

        #region Help
        public TreeNode<CustomMenuItem> helpMenu;

//      public TreeNode<CustomMenuItem> help_AboutUnityItem;

//      public TreeNode<CustomMenuItem> help_ManageLicenseItem;

//      public TreeNode<CustomMenuItem> help_UnityManualItem;
//      public TreeNode<CustomMenuItem> help_ScriptingReferenceItem;

//      public TreeNode<CustomMenuItem> help_UnityConnectItem;
//      public TreeNode<CustomMenuItem> help_UnityForumItem;
//      public TreeNode<CustomMenuItem> help_UnityAnswersItem;
//      public TreeNode<CustomMenuItem> help_UnityFeedbackItem;

//      public TreeNode<CustomMenuItem> help_CheckForUpdatesItem;
//      public TreeNode<CustomMenuItem> help_DownloadBetaItem;

//      public TreeNode<CustomMenuItem> help_ReleaseNotesItem;
//      public TreeNode<CustomMenuItem> help_ReportABugItem;
        #endregion

        #endregion



        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuUI"/> class.
        /// </summary>
        public MainMenuUI(MainMenuScript script)
        {
            mScript = script;

            mButtonSpriteState = new SpriteState();

			mButtonSpriteState.disabledSprite    = Assets.Windows.MainWindow.MainMenu.Textures.buttonDisabled.sprite;
			mButtonSpriteState.highlightedSprite = Assets.Windows.MainWindow.MainMenu.Textures.buttonHighlighted.sprite;
			mButtonSpriteState.pressedSprite     = Assets.Windows.MainWindow.MainMenu.Textures.buttonPressed.sprite;

            mScrollAreaContent          = null;
            mScrollAreaContentTransform = null;
        }

        /// <summary>
        /// Setup user interface.
        /// </summary>
        public void SetupUI()
        {
            CreateMenuItems();
            CreateUI();
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Release()
        {
            Settings.RemoveInternalModeListener(OnInternalModeChanged);
            Translator.RemoveLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.MenuItems.MenuItem"/> class with given token ID and with
        /// assigning to specified <see cref="Common.TreeNode`1"/> instance.
        /// </summary>
        /// <param name="owner"><see cref="Common.TreeNode`1"/> instance.</param>
        /// <param name="tokenId">Token ID for translation.</param>
        /// <param name="onClick">Click event handler.</param>
        /// <param name="enabled">Is this menu item enabled or not.</param>
        /// <param name="shortcut">Shortcut.</param>
        /// <param name="radioGroup">Menu radio group.</param>
        private TreeNode<CustomMenuItem> MakeItem(
                                                    TreeNode<CustomMenuItem>     owner
                                                     , R.sections.MenuItems.strings tokenId
                                                    , UnityAction                  onClick    = null
                                                    , bool                         enabled    = true
                                                    , string                       shortcut   = null
                                                  , MenuRadioGroup               radioGroup = null
                                                     )
        {
            return MenuItem.Create(owner, tokenId, onClick, enabled, mScript, shortcut, radioGroup);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.MenuItems.MenuItem"/> class with given text and with
        /// assigning to specified <see cref="Common.TreeNode`1"/> instance.
        /// </summary>
        /// <param name="owner"><see cref="Common.TreeNode`1"/> instance.</param>
        /// <param name="text">Menu item text.</param>
        /// <param name="onClick">Click event handler.</param>
        /// <param name="enabled">Is this menu item enabled or not.</param>
        /// <param name="shortcut">Shortcut.</param>
        /// <param name="radioGroup">Menu radio group.</param>
        private TreeNode<CustomMenuItem> MakeItem(
                                                    TreeNode<CustomMenuItem> owner
                                                    , string 		             text
                                                    , UnityAction              onClick    = null
                                                    , bool                     enabled    = true
                                                    , string                   shortcut   = null
                                                  , MenuRadioGroup           radioGroup = null
                                                  )
        {
            return MenuItem.Create(owner, text, onClick, enabled, mScript, shortcut, radioGroup);
        }

        /// <summary>
        /// Creates menu items.
        /// </summary>
        private void CreateMenuItems()
        {
            // Root
            mItems = new TreeNode<CustomMenuItem>(new CustomMenuItem());

            #region Menu items
            #region File
            fileMenu         =   MakeItem(mItems,   R.sections.MenuItems.strings.file,       mScript.OnFileMenu);

            /*mFile_ExitItem =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__exit, mScript.OnFile_Exit);
            #endregion

            #region Window
            windowMenu                  =   MakeItem(mItems,     R.sections.MenuItems.strings.window,                  mScript.OnWindowMenu);

            /*window_NextWindowItem     =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__next_window,     mScript.OnWindow_NextWindow,     true, "Ctrl+Tab");
            /*window_PreviousWindowItem =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__previous_window, mScript.OnWindow_PreviousWindow, true, "Ctrl+Shift+Tab");
            MenuSeparatorItem.Create(windowMenu);

            #region Window -> Layouts
            window_LayoutsItem                         =   MakeItem(windowMenu,         R.sections.MenuItems.strings.window__layouts);

            /*window_Layouts_DefaultItem               =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__default,                 mScript.OnWindow_Layouts_Default);
            MenuSeparatorItem.Create(window_LayoutsItem);
            /*window_Layouts_SaveLayoutItem            =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__save_layout,             mScript.OnWindow_Layouts_SaveLayout);
            /*window_Layouts_DeleteLayoutItem          =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__delete_layout,           mScript.OnWindow_Layouts_DeleteLayout);
            /*window_Layouts_RevertFactorySettingsItem =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__revert_factory_settings, mScript.OnWindow_Layouts_RevertFactorySettings);
            #endregion

            #region Window -> Screenshot
            window_ScreenshotSeparator = MenuSeparatorItem.Create(windowMenu);
            window_ScreenshotItem                      =   MakeItem(windowMenu,            R.sections.MenuItems.strings.window__screenshot);

            window_ScreenshotSeparator.data.visible = Settings.internalMode;
            window_ScreenshotItem.data.visible      = Settings.internalMode;

            /*window_Screenshot_SetWindowSizeItem      =*/ MakeItem(window_ScreenshotItem, R.sections.MenuItems.strings.window__screenshot__set_window_size,       mScript.OnWindow_Screenshot_SetWindowSize);
            /*window_Screenshot_SetWindowSizeSmallItem =*/ MakeItem(window_ScreenshotItem, R.sections.MenuItems.strings.window__screenshot__set_window_size_small, mScript.OnWindow_Screenshot_SetWindowSizeSmall);
            /*window_Screenshot_SnapViewItem           =*/ MakeItem(window_ScreenshotItem, R.sections.MenuItems.strings.window__screenshot__snap_view,             mScript.OnWindow_Screenshot_SnapView);
            #endregion

            MenuSeparatorItem.Create(windowMenu);
            /*window_ServersItem =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__servers, mScript.OnWindow_Servers, true, "Ctrl+1");
            #endregion

            #region Help
            helpMenu                      =   MakeItem(mItems,   R.sections.MenuItems.strings.help,                      mScript.OnHelpMenu);

            /*help_AboutUnityItem         =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__about_unity,         mScript.OnHelp_AboutUnity);
            MenuSeparatorItem.Create(helpMenu);
            /*help_ManageLicenseItem      =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__manage_license,      mScript.OnHelp_ManageLicense);
            MenuSeparatorItem.Create(helpMenu);
            /*help_UnityManualItem        =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__unity_manual,        mScript.OnHelp_UnityManual);
            /*help_ScriptingReferenceItem =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__scripting_reference, mScript.OnHelp_ScriptingReference);
            MenuSeparatorItem.Create(helpMenu);
            /*help_UnityConnectItem       =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__unity_connect,       mScript.OnHelp_UnityConnect);
            /*help_UnityForumItem         =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__unity_forum,         mScript.OnHelp_UnityForum);
            /*help_UnityAnswersItem       =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__unity_answers,       mScript.OnHelp_UnityAnswers);
            /*help_UnityFeedbackItem      =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__unity_feedback,      mScript.OnHelp_UnityFeedback);
            MenuSeparatorItem.Create(helpMenu);
            /*help_CheckForUpdatesItem    =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__check_for_updates,   mScript.OnHelp_CheckForUpdates);
            /*help_DownloadBetaItem       =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__download_beta,       mScript.OnHelp_DownloadBeta);
            MenuSeparatorItem.Create(helpMenu);
            /*help_ReleaseNotesItem       =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__release_notes,       mScript.OnHelp_ReleaseNotes);
            /*help_ReportABugItem         =*/ MakeItem(helpMenu, R.sections.MenuItems.strings.help__report_a_bug,        mScript.OnHelp_ReportABug);
            #endregion
            #endregion

            Settings.AddInternalModeListener(OnInternalModeChanged);
        }

        /// <summary>
        /// Creates user interface.
        /// </summary>
        private void CreateUI() // TODO: [Trivial] Report bug for ///
        {
            //***************************************************************************
            // ScrollArea GameObject
            //***************************************************************************
            #region ScrollArea GameObject
            GameObject scrollArea = new GameObject("ScrollArea");
            Utils.InitUIObject(scrollArea, mScript.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(scrollAreaTransform);
            #endregion

            //***************************************************************************
            // Content GameObject
            //***************************************************************************
            #region Content GameObject
            mScrollAreaContent = new GameObject("Content");
            Utils.InitUIObject(mScrollAreaContent, scrollArea.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mScrollAreaContentTransform = mScrollAreaContent.AddComponent<RectTransform>();
            #endregion

            float contentWidth = 0f;

            //===========================================================================
            // Fill content
            //===========================================================================
            #region Fill content
            // Create menu item buttons
            foreach (TreeNode<CustomMenuItem> menuItem in mItems.children)
            {
                if (menuItem.data.visible)
                {
                    if (menuItem.data is MenuItem)
                    {
                        MenuItem item = menuItem.data as MenuItem;

                        //***************************************************************************
                        // Button GameObject
                        //***************************************************************************
                        #region Button GameObject
                        GameObject menuItemButton = new GameObject(item.name);
                        Utils.InitUIObject(menuItemButton, mScrollAreaContent.transform);

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

						menuItemButtonImage.sprite = Assets.Windows.MainWindow.MainMenu.Textures.button.sprite;
                        menuItemButtonImage.type   = Image.Type.Sliced;
                        #endregion

                        //===========================================================================
                        // Button Component
                        //===========================================================================
                        #region Button Component
                        Button menuItemButtonButton = menuItemButton.AddComponent<Button>();

                        menuItemButtonButton.targetGraphic = menuItemButtonImage;
                        menuItemButtonButton.transition    = Selectable.Transition.SpriteSwap;
                        menuItemButtonButton.spriteState   = mButtonSpriteState;

                        if (item.enabled)
                        {
                            menuItemButtonButton.onClick.AddListener(item.onClick);
                        }
                        #endregion

                        //===========================================================================
                        // AutoPopupItemScript Component
                        //===========================================================================
                        #region AutoPopupItemScript Component
                        AutoPopupItemScript menuItemButtonAutoPopup = menuItemButton.AddComponent<AutoPopupItemScript>();

                        menuItemButtonAutoPopup.delay = AUTO_POPUP_DELAY;
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
                        Utils.AlignRectTransformStretchStretch(menuItemTextTransform);
                        #endregion

                        //===========================================================================
                        // Text Component
                        //===========================================================================
                        #region Text Component
                        Text menuItemTextText = menuItemText.AddComponent<Text>();

                        Assets.Windows.MainWindow.MainMenu.TextStyles.button.Apply(menuItemTextText);

                        menuItemTextText.text      = item.text;
                        #endregion
                        #endregion

                        ++contentWidth;

                        float buttonWidth = menuItemTextText.preferredWidth + 12;

                        Utils.AlignRectTransformStretchLeft(menuItemButtonTransform, buttonWidth, contentWidth, 1, 1);

                        contentWidth += buttonWidth + 1;
                    }
                    else
                    {
                        Debug.LogError("Unknown menu item type");
                    }
                }
            }
            #endregion

            Utils.AlignRectTransformStretchLeft(mScrollAreaContentTransform, contentWidth, 0f, 0f, 0f, 0f, 0.5f);
            #endregion

            //===========================================================================
            // ScrollRect Component
            //===========================================================================
            #region ScrollRect Component
            ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();

            scrollAreaScrollRect.content  = mScrollAreaContentTransform;
            scrollAreaScrollRect.vertical = false;
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

			scrollAreaImage.sprite = Assets.Windows.MainWindow.MainMenu.Textures.background.sprite;
            scrollAreaImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Mask Component
            //===========================================================================
            #region Mask Component
            scrollArea.AddComponent<Mask>();
            #endregion
            #endregion

            Translator.AddLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Handler for Settings.InternalMode changed event.
        /// </summary>
        public void OnInternalModeChanged()
        {
            window_ScreenshotSeparator.data.visible = Settings.internalMode;
            window_ScreenshotItem.data.visible      = Settings.internalMode;
        }

        /// <summary>
        /// Handler for language changed event.
        /// </summary>
        public void OnLanguageChanged()
        {
            float contentWidth = 0f;

            //===========================================================================
            // Update content
            //===========================================================================
            #region Update content
            ReadOnlyCollection<TreeNode<CustomMenuItem>> menuItems = mItems.children;
            int index = 0;

            for (int i = 0; i < menuItems.Count; ++i)
            {
                if (menuItems[i].data.visible)
                {
                    if (menuItems[i].data is MenuItem)
                    {
                        MenuItem item = menuItems[i].data as MenuItem;

                        //***************************************************************************
                        // Button GameObject
                        //***************************************************************************
                        #region Button GameObject
                        GameObject menuItemButton = mScrollAreaContent.transform.GetChild(index).gameObject;

                        //===========================================================================
                        // RectTransform Component
                        //===========================================================================
                        #region RectTransform Component
                        RectTransform menuItemButtonTransform = menuItemButton.transform as RectTransform;
                        #endregion
                        #endregion

                        //***************************************************************************
                        // Text GameObject
                        //***************************************************************************
                        #region Text GameObject
                        GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject; // Button/Text

                        //===========================================================================
                        // Text Component
                        //===========================================================================
                        #region Text Component
                        Text menuItemTextText = menuItemText.GetComponent<Text>();

                        menuItemTextText.text = item.text;
                        #endregion
                        #endregion

                        ++contentWidth;

                        float buttonWidth = menuItemTextText.preferredWidth + 12;

                        Utils.AlignRectTransformStretchLeft(menuItemButtonTransform, buttonWidth, contentWidth, 1, 1);

                        contentWidth += buttonWidth + 1;
                    }
                    else
                    {
                        Debug.LogError("Unknown menu item type");
                    }

                    ++index;
                }
            }
            #endregion

            mScrollAreaContentTransform.offsetMax = new Vector2(mScrollAreaContentTransform.offsetMin.x + contentWidth, mScrollAreaContentTransform.offsetMax.y);
        }
    }
}
