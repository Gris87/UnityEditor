using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityTranslation;

using Common;
using Common.UI.DockWidgets;
using Common.UI.MenuItems;
using Common.UI.Popups;
using Common.UI.Windows;
using UI.Windows.AboutDialog;
using UI.Windows.MainWindow.DockWidgets.Servers;



namespace UI.Windows.MainWindow.MainMenu
{
    /// <summary>
    /// Script that realize main menu behaviour.
    /// </summary>
    public class MainMenuScript : MonoBehaviour, IShortcutHandler
    {
        private MainMenuUI     mUi;
        private List<MenuItem> mShortcuts;
        private PopupMenu      mPopupMenu;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            mUi        = new MainMenuUI(this);
            mShortcuts = new List<MenuItem>();
            mPopupMenu = null;

            mUi.SetupUI();
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            mUi.Release();
        }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        void Update()
        {
            if (
				Global.mainWindowScript.selected
				&&
				InputControl.anyKeyDown
			   )
            {
                foreach (MenuItem menuItem in mShortcuts)
                {
                    if (menuItem.HandleShortcut())
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Registers the shortcut.
        /// </summary>
        /// <param name="shortcut">Shortcut.</param>
        public void RegisterShortcut(MenuItem shortcut)
        {
            mShortcuts.Add(shortcut);
        }

        /// <summary>
        /// Deregisters the shortcut.
        /// </summary>
        /// <param name="shortcut">Shortcut.</param>
        public void DeregisterShortcut(MenuItem shortcut)
        {
            if (!mShortcuts.Remove(shortcut))
            {
                Debug.LogError("Failed to deregister shortcut for \"" + shortcut.name + "\"");
            }
        }

        /// <summary>
        /// Creates and displays popup menu for specified menu item.
        /// </summary>
        /// <param name="node"><see cref="Common.TreeNode`1"/> instance.</param>
        public void OnShowMenuSubItems(TreeNode<CustomMenuItem> node)
        {
            if (node.data is MenuItem)
            {
                MenuItem item = node.data as MenuItem;
                Debug.Log("MainMenuScript.OnShowMenuSubItems(" + item.name + ")");

                if (mPopupMenu != null)
                {
                    mPopupMenu.Destroy();
                }

                mPopupMenu = new PopupMenu(node);
                mPopupMenu.OnDestroy.AddListener(OnPopupMenuDestroyed);

                int index = node.parent.children.IndexOf(node);

                RectTransform menuItemTransform = transform.GetChild(0).GetChild(0).GetChild(index).transform as RectTransform; // ScrollArea/Content/NODE
                Vector3[] menuItemCorners = Utils.GetWindowCorners(menuItemTransform);

                mPopupMenu.Show(menuItemCorners[2].x, menuItemCorners[2].y);
            }
            else
            {
                Debug.LogError("Unknown menu item type");
            }
        }

        /// <summary>
        /// Handler for popup menu destroy event.
        /// </summary>
        public void OnPopupMenuDestroyed()
        {
            Debug.Log("MainMenuScript.OnPopupMenuDestroyed");

            mPopupMenu = null;
        }

        #region Handlers for menu items
        #region File
        /// <summary>
        /// Handler for File.
        /// </summary>
        public void OnFileMenu()
        {
            OnShowMenuSubItems(mUi.fileMenu);
        }

        /// <summary>
        /// Handler for File -> Exit.
        /// </summary>
        public void OnFile_Exit()
        {
            Debug.Log("MainMenuScript.OnFile_Exit");
            Application.Quit();
        }
        #endregion

        #region Window
        /// <summary>
        /// Handler for Window.
        /// </summary>
        public void OnWindowMenu()
        {
            OnShowMenuSubItems(mUi.windowMenu);
        }

        /// <summary>
        /// Handler for Window -> Next Window.
        /// </summary>
        public void OnWindow_NextWindow()
        {
			Debug.Log("MainMenuScript.OnWindow_NextWindow");

			ReadOnlyCollection<WindowScript> windows = WindowScript.instances;

			int index = windows.IndexOf(WindowScript.selectedWindow);

			if (index >= 0)
			{
				if (windows.Count > 1)
				{
					++index;

					if (index >= windows.Count)
					{
						index = 0;
					}

					windows[index].Select();
				}
			}
			else
			{
				Debug.LogError("Unexpected behaviour in MainMenuScript.OnWindow_NextWindow");
			}
        }

        /// <summary>
        /// Handler for Window -> Previous Window.
        /// </summary>
        public void OnWindow_PreviousWindow()
        {
			Debug.Log("MainMenuScript.OnWindow_PreviousWindow");
			
			ReadOnlyCollection<WindowScript> windows = WindowScript.instances;
			
			int index = windows.IndexOf(WindowScript.selectedWindow);
			
			if (index >= 0)
			{
				if (windows.Count > 1)
				{
					--index;

                    if (index < 0)
                    {
                        index = windows.Count - 1;
                    }
					
					windows[index].Select();
				}
			}
			else
			{
				Debug.LogError("Unexpected behaviour in MainMenuScript.OnWindow_NextWindow");
			}
        }

        #region Window -> Layouts
        /// <summary>
        /// Handler for Window -> Layouts -> Default.
        /// </summary>
        public void OnWindow_Layouts_Default()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_Default");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Default

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Save Layout.
        /// </summary>
        public void OnWindow_Layouts_SaveLayout()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_SaveLayout");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_SaveLayout

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Delete Layout.
        /// </summary>
        public void OnWindow_Layouts_DeleteLayout()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_DeleteLayout");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_DeleteLayout

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Revert Factory Settings.
        /// </summary>
        public void OnWindow_Layouts_RevertFactorySettings()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_RevertFactorySettings");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_RevertFactorySettings

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Window -> Screenshot
        /// <summary>
        /// Handler for Window -> Screenshot -> Set Window Size.
        /// </summary>
        public void OnWindow_Screenshot_SetWindowSize()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SetWindowSize");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SetWindowSize

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Set Window Size Small.
        /// </summary>
        public void OnWindow_Screenshot_SetWindowSizeSmall()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View.
        /// </summary>
        public void OnWindow_Screenshot_SnapView()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapView");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapView

            AppUtils.ShowContributeMessage();
        }
        #endregion

		/// <summary>
		/// Shows dock widget.
		/// </summary>
		/// <param name="globalPointer">Global pointer for storing.</param>
		/// <param name="name">Dock widget name.</param>
		/// <typeparam name="T">Type of dock widget.</typeparam>
		private void ShowDockWidget<T>(ref T globalPointer, string name) where T : DockWidgetScript
		{
			if (globalPointer == null)
			{
				//***************************************************************************
				// DockWidget GameObject
				//***************************************************************************
				#region DockWidget GameObject
				GameObject dockWidget = new GameObject(name);
				Utils.InitUIObject(dockWidget, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// T Component
				//===========================================================================
                #region T Component
                globalPointer = dockWidget.AddComponent<T>();
                #endregion
                #endregion


				if (Global.dockingAreaScript.dockingGroupScript == null && Global.dockingAreaScript.children.Count == 0)
				{
					globalPointer.InsertToDockingArea(Global.dockingAreaScript);
				}
				else
				{
					//***************************************************************************
					// DockingWindow GameObject
					//***************************************************************************
					#region DockingWindow GameObject
					GameObject dockingWindow = new GameObject("DockingWindow");
					Utils.InitUIObject(dockingWindow, Global.windowsTransform);
					
					//===========================================================================
					// DockingWindowScript Component
					//===========================================================================
					#region DockingWindowScript Component
					DockingWindowScript dockingWindowScript = dockingWindow.AddComponent<DockingWindowScript>();
                    
                    dockingWindowScript.dockWidget = globalPointer;				
                    dockingWindowScript.Show();
                    #endregion
					#endregion
				}
			}
			else
			{
				globalPointer.Select();
			}
        }
        
        /// <summary>
        /// Handler for Window -> Servers.
        /// </summary>
        public void OnWindow_Servers()
        {
            Debug.Log("MainMenuScript.OnWindow_Servers");
            
            ShowDockWidget<ServersDockWidgetScript>(ref Global.serversDockWidgetScript, "Servers");
        }
        #endregion

        #region Help
        /// <summary>
        /// Handler for Help.
        /// </summary>
        public void OnHelpMenu()
        {
            OnShowMenuSubItems(mUi.helpMenu);
        }

        /// <summary>
        /// Handler for Help -> About Unity...
        /// </summary>
        public void OnHelp_AboutUnity()
        {
            AboutDialogScript.Create().Show();
        }

        /// <summary>
        /// Handler for Help -> Manage License...
        /// </summary>
        public void OnHelp_ManageLicense()
        {
            Debug.Log("MainMenuScript.OnHelp_ManageLicense");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ManageLicense

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Manual.
        /// </summary>
        public void OnHelp_UnityManual()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityManual");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityManual

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Scripting Reference.
        /// </summary>
        public void OnHelp_ScriptingReference()
        {
            Debug.Log("MainMenuScript.OnHelp_ScriptingReference");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ScriptingReference

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Connect.
        /// </summary>
        public void OnHelp_UnityConnect()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityConnect");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityConnect

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Forum.
        /// </summary>
        public void OnHelp_UnityForum()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityForum");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityForum

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Answers.
        /// </summary>
        public void OnHelp_UnityAnswers()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityAnswers");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityAnswers

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Feedback.
        /// </summary>
        public void OnHelp_UnityFeedback()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityFeedback");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityFeedback

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Check for Updates.
        /// </summary>
        public void OnHelp_CheckForUpdates()
        {
            Debug.Log("MainMenuScript.OnHelp_CheckForUpdates");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_CheckForUpdates

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Download Beta...
        /// </summary>
        public void OnHelp_DownloadBeta()
        {
            Debug.Log("MainMenuScript.OnHelp_DownloadBeta");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_DownloadBeta

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Release Notes.
        /// </summary>
        public void OnHelp_ReleaseNotes()
        {
            Debug.Log("MainMenuScript.OnHelp_ReleaseNotes");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ReleaseNotes

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Report a Bug...
        /// </summary>
        public void OnHelp_ReportABug()
        {
            Debug.Log("MainMenuScript.OnHelp_ReportABug");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ReportABug

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #endregion
    }
}
