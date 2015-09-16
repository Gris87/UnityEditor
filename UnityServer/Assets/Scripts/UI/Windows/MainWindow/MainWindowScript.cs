#if !UNITY_EDITOR
#if UNITY_ANDROID
#define MENU_BUTTON_TO_SHOW_MENU
#endif

#if UNITY_ANDROID
#define HANDLE_ESCAPE_BUTTON
#endif
#endif



using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.UI.DockWidgets;
using Common.UI.Listeners;
using Common.UI.Windows;
using UI.Windows.MainWindow.DockWidgets.Servers;
using UI.Windows.MainWindow.MainMenu;
using UI.Windows.MainWindow.Toolbar;



namespace UI.Windows.MainWindow
{
    /// <summary>
    /// Script that realize main window behaviour.
    /// </summary>
    public class MainWindowScript : WindowScript
#if HANDLE_ESCAPE_BUTTON
                                  , EscapeButtonHandler
#endif
    {
        private const float MAIN_MENU_HEIGHT = 20f;
        private const float TOOLBAR_HEIGHT   = 32f;



        /// <summary>
        /// Gets a value indicating whether this <see cref="UI.Windows.MainWindow.MainWindowScript"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public override bool selected
        {
            get
            {
                return (
                        base.selected
                        ||
                        WindowScript.selectedWindow is DockingWindowScript
                       );
            }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
        /// </summary>
        private MainWindowScript()
            : base()
        {
			DebugEx.Verbose("Created MainWindowScript object");

            frame           = WindowFrameType.Frameless;
            state           = WindowState.FullScreen;
            backgroundColor = Assets.Windows.MainWindow.Colors.background;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
        /// </summary>
        public static MainWindowScript Create()
        {
			DebugEx.Verbose("MainWindowScript.Create()");

            if (Global.mainWindowScript == null)
            {
                //***************************************************************************
                // MainWindow GameObject
                //***************************************************************************
                #region MainWindow GameObject
                GameObject mainWindow = new GameObject("MainWindow");
                Utils.InitUIObject(mainWindow, Global.windowsTransform);

                //===========================================================================
                // MainWindowScript Component
                //===========================================================================
                #region MainWindowScript Component
                Global.mainWindowScript = mainWindow.AddComponent<MainWindowScript>();
                #endregion
                #endregion
            }

            return Global.mainWindowScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        /// <param name="width">Width of content.</param>
        /// <param name="height">Height of content.</param>
        protected override void CreateContent(Transform contentTransform, out float width, out float height)
        {
			DebugEx.Verbose("MainWindowScript.CreateContent()");

            width  = 0f;
            height = 0f;

            //***************************************************************************
            // MainMenu GameObject
            //***************************************************************************
            #region MainMenu GameObject
            GameObject mainMenu = new GameObject("MainMenu");
            Utils.InitUIObject(mainMenu, contentTransform);

#if MENU_BUTTON_TO_SHOW_MENU
            mainMenu.SetActive(false);
#endif

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform mainMenuTransform = mainMenu.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(mainMenuTransform, MAIN_MENU_HEIGHT);
            #endregion

            //===========================================================================
            // MainMenuScript Component
            //===========================================================================
            #region MainMenuScript Component
            Global.mainMenuScript = mainMenu.AddComponent<MainMenuScript>();
            #endregion
            #endregion



            //***************************************************************************
            // Toolbar GameObject
            //***************************************************************************
            #region Toolbar GameObject
            GameObject toolbar = new GameObject("Toolbar");
            Utils.InitUIObject(toolbar, contentTransform);

#if MENU_BUTTON_TO_SHOW_MENU
            toolbar.SetActive(false);
#endif

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform toolbarTransform = toolbar.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(toolbarTransform, TOOLBAR_HEIGHT, MAIN_MENU_HEIGHT);
            #endregion

            //===========================================================================
            // ToolbarScript Component
            //===========================================================================
            #region ToolbarScript Component
            Global.toolbarScript = toolbar.AddComponent<ToolbarScript>();
            #endregion
            #endregion



            //***************************************************************************
            // DockingArea GameObject
            //***************************************************************************
            #region DockingArea GameObject
            GameObject dockingArea = new GameObject("DockingArea");
            Utils.InitUIObject(dockingArea, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();

#if MENU_BUTTON_TO_SHOW_MENU
            Utils.AlignRectTransformStretchStretch(dockingAreaTransform);
#else
            Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, MAIN_MENU_HEIGHT + TOOLBAR_HEIGHT, 0f, 0f);
#endif
            #endregion

            //===========================================================================
            // DockingAreaScript Component
            //===========================================================================
            #region DockingAreaScript Component
            Global.dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
            #endregion
            #endregion

#if HANDLE_ESCAPE_BUTTON
            EscapeButtonListenerScript.PushHandlerToTop(this);
#endif

            // TODO: [Major] It looks bad on start up on Android
            LoadDockWidgets();
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();

			DebugEx.Verbose("MainWindowScript.OnDestroy()");

#if HANDLE_ESCAPE_BUTTON
            EscapeButtonListenerScript.RemoveHandler(this);
#endif

            if (Global.mainWindowScript == this)
            {
                Global.mainWindowScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in MainWindowScript.OnDestroy()");
            }
        }

#if MENU_BUTTON_TO_SHOW_MENU
        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        protected override void Update()
        {
            base.Update();

			DebugEx.VeryVeryVerbose("MainWindowScript.Update()");

            if (selected)
            {
                if (InputControl.GetButtonDown(Controls.buttons.menu, true))
                {
                    if (IsMenuVisible())
                    {
                        HideMenu();
                    }
                    else
                    {
                        ShowMenu();
                    }
                }
            }
        }
#endif

        /// <summary>
        /// Handler for resize event.
        /// </summary>
        protected override void OnResize()
        {
			DebugEx.UserInteraction("MainWindowScript.OnResize()");

            if (Global.dockingAreaScript != null)
            {
                Global.dockingAreaScript.OnResize();
            }
        }

#if HANDLE_ESCAPE_BUTTON
        /// <summary>
        /// Handles escape button press event.
        /// </summary>
        /// <returns><c>true</c>, if escape button was handled, <c>false</c> otherwise.</returns>
        public bool OnEscapeButtonPressed()
        {
			DebugEx.UserInteraction("MainWindowScript.OnEscapeButtonPressed()");

#if MENU_BUTTON_TO_SHOW_MENU
            if (IsMenuVisible())
            {
                HideMenu();
            }
            else
            {
                Global.mainMenuScript.OnFile_Exit();
            }
#else
            Global.mainMenuScript.OnFile_Exit();
#endif

            return true;
        }
#endif

#if MENU_BUTTON_TO_SHOW_MENU
        /// <summary>
        /// Determines whether menu is visible.
        /// </summary>
        /// <returns><c>true</c> if menu is visible; otherwise, <c>false</c>.</returns>
        private bool IsMenuVisible()
        {
            return Global.mainMenuScript.gameObject.activeSelf;
        }

        /// <summary>
        /// Shows menu.
        /// </summary>
        private void ShowMenu()
        {
			DebugEx.Verbose("MainWindowScript.ShowMenu()");

            Global.mainMenuScript.gameObject.SetActive(true);
            Global.toolbarScript.gameObject.SetActive(true);

            RectTransform dockingAreaTransform = Global.dockingAreaScript.transform as RectTransform;

            dockingAreaTransform.offsetMax = new Vector2(0f, -MAIN_MENU_HEIGHT - TOOLBAR_HEIGHT);

            Global.dockingAreaScript.OnResize();
        }

        /// <summary>
        /// Hides menu.
        /// </summary>
        private void HideMenu()
        {
			DebugEx.Verbose("MainWindowScript.HideMenu()");

            Global.mainMenuScript.gameObject.SetActive(false);
            Global.toolbarScript.gameObject.SetActive(false);

            RectTransform dockingAreaTransform = Global.dockingAreaScript.transform as RectTransform;

            dockingAreaTransform.offsetMax = new Vector2(0f, 0f);

            Global.dockingAreaScript.OnResize();
        }
#endif

        /// <summary>
        /// Loads dock widgets layout.
        /// </summary>
        private void LoadDockWidgets()
        {
			DebugEx.Verbose("MainWindowScript.LoadDockWidgets()");

            ServersDockWidgetScript.Create().InsertToDockingArea(Global.dockingAreaScript);
        }
    }
}
