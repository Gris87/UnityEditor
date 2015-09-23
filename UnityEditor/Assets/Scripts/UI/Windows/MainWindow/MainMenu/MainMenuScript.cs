using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

using Common;
using Common.App;
using Common.UI.DockWidgets;
using Common.UI.MenuItems;
using Common.UI.Popups;
using Common.UI.Windows;
using UI.Windows.AboutDialog;
using UI.Windows.MainWindow.DockWidgets.Animation;
using UI.Windows.MainWindow.DockWidgets.Animator;
using UI.Windows.MainWindow.DockWidgets.AnimatorParameter;
using UI.Windows.MainWindow.DockWidgets.AssetStore;
using UI.Windows.MainWindow.DockWidgets.AudioMixer;
using UI.Windows.MainWindow.DockWidgets.Console;
using UI.Windows.MainWindow.DockWidgets.FrameDebugger;
using UI.Windows.MainWindow.DockWidgets.Game;
using UI.Windows.MainWindow.DockWidgets.Hierarchy;
using UI.Windows.MainWindow.DockWidgets.Inspector;
using UI.Windows.MainWindow.DockWidgets.Lighting;
using UI.Windows.MainWindow.DockWidgets.Navigation;
using UI.Windows.MainWindow.DockWidgets.OcclusionCulling;
using UI.Windows.MainWindow.DockWidgets.Profiler;
using UI.Windows.MainWindow.DockWidgets.Project;
using UI.Windows.MainWindow.DockWidgets.Scene;
using UI.Windows.MainWindow.DockWidgets.SpritePacker;
using UI.Windows.MainWindow.DockWidgets.VersionControl;



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
            DebugEx.Verbose("MainMenuScript.Start()");

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
            DebugEx.Verbose("MainMenuScript.OnDestroy()");

            mUi.Release();
        }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        void Update()
        {
            DebugEx.VeryVeryVerbose("MainMenuScript.Update()");

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
            DebugEx.VerboseFormat("MainMenuScript.RegisterShortcut(shortcut = {0})", shortcut);

            mShortcuts.Add(shortcut);
        }

        /// <summary>
        /// Deregisters the shortcut.
        /// </summary>
        /// <param name="shortcut">Shortcut.</param>
        public void DeregisterShortcut(MenuItem shortcut)
        {
            DebugEx.VerboseFormat("MainMenuScript.DeregisterShortcut(shortcut = {0})", shortcut);

            if (!mShortcuts.Remove(shortcut))
            {
                DebugEx.Error("Failed to deregister shortcut for \"{0}\"", shortcut.name);
            }
        }

        /// <summary>
        /// Creates and displays popup menu for specified menu item.
        /// </summary>
        /// <param name="node"><see cref="Common.TreeNode`1"/> instance.</param>
        public void OnShowMenuSubItems(TreeNode<CustomMenuItem> node)
        {
            DebugEx.VerboseFormat("MainMenuScript.OnShowMenuSubItems(node = {0})", node);

            if (node.data is MenuItem)
            {
                MenuItem item = node.data as MenuItem;
                DebugEx.UserInteraction("MainMenuScript.OnShowMenuSubItems({0})", item.name);

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
                DebugEx.Error("Unknown menu item type");
            }
        }

        /// <summary>
        /// Handler for popup menu destroy event.
        /// </summary>
        public void OnPopupMenuDestroyed()
        {
            DebugEx.Verbose("MainMenuScript.OnPopupMenuDestroyed()");

            mPopupMenu = null;
        }

        #region Handlers for menu items
        #region File
        /// <summary>
        /// Handler for File.
        /// </summary>
        public void OnFileMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnFileMenu()");

            OnShowMenuSubItems(mUi.fileMenu);
        }

        /// <summary>
        /// Handler for File -> New Scene.
        /// </summary>
        public void OnFile_NewScene()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_NewScene()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_NewScene

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Open Scene.
        /// </summary>
        public void OnFile_OpenScene()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_OpenScene()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_OpenScene

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Save Scene.
        /// </summary>
        public void OnFile_SaveScene()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_SaveScene()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_SaveScene

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Save Scene as...
        /// </summary>
        public void OnFile_SaveSceneAs()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_SaveSceneAs()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_SaveSceneAs

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> New Project...
        /// </summary>
        public void OnFile_NewProject()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_NewProject()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_NewProject

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Open Project...
        /// </summary>
        public void OnFile_OpenProject()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_OpenProject()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_OpenProject

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Save Project.
        /// </summary>
        public void OnFile_SaveProject()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_SaveProject()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_SaveProject

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Build Settings...
        /// </summary>
        public void OnFile_BuildSettings()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_BuildSettings()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_BuildSettings

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Build & Run.
        /// </summary>
        public void OnFile_BuildAndRun()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_BuildAndRun()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_BuildAndRun

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Build in Cloud...
        /// </summary>
        public void OnFile_BuildInCloud()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_BuildInCloud()");
            // TODO: [Minor] Implement MainMenuScript.OnFile_BuildInCloud

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Exit.
        /// </summary>
        public void OnFile_Exit()
        {
            DebugEx.UserInteraction("MainMenuScript.OnFile_Exit()");

            Application.Quit();
        }
        #endregion

        #region Edit
        /// <summary>
        /// Handler for Edit.
        /// </summary>
        public void OnEditMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnEditMenu()");

            OnShowMenuSubItems(mUi.editMenu);
        }

        /// <summary>
        /// Handler for Edit -> Undo.
        /// </summary>
        public void OnEdit_Undo()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Undo()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Undo

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Redo.
        /// </summary>
        public void OnEdit_Redo()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Redo()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Redo

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Cut.
        /// </summary>
        public void OnEdit_Cut()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Cut()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Cut

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Copy.
        /// </summary>
        public void OnEdit_Copy()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Copy()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Copy

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Paste.
        /// </summary>
        public void OnEdit_Paste()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Paste()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Paste

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Duplicate.
        /// </summary>
        public void OnEdit_Duplicate()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Duplicate()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Duplicate

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Delete.
        /// </summary>
        public void OnEdit_Delete()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Delete()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Delete

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Frame Selected.
        /// </summary>
        public void OnEdit_FrameSelected()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_FrameSelected()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_FrameSelected

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Lock View to Selected.
        /// </summary>
        public void OnEdit_LockViewToSelected()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_LockViewToSelected()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_LockViewToSelected

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Find.
        /// </summary>
        public void OnEdit_Find()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Find()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Find

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Select All.
        /// </summary>
        public void OnEdit_SelectAll()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_SelectAll()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_SelectAll

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Preferences...
        /// </summary>
        public void OnEdit_Preferences()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Preferences()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Preferences

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Modules...
        /// </summary>
        public void OnEdit_Modules()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Modules()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Modules

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Play.
        /// </summary>
        public void OnEdit_Play()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Play()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Play

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Pause.
        /// </summary>
        public void OnEdit_Pause()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Pause()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Pause

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Step.
        /// </summary>
        public void OnEdit_Step()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Step()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Step

            AppUtils.ShowContributeMessage();
        }

        #region Edit -> Selection
        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 1.
        /// </summary>
        public void OnEdit_Selection_LoadSelection1()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection1()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection1

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 2.
        /// </summary>
        public void OnEdit_Selection_LoadSelection2()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection2()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection2

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 3.
        /// </summary>
        public void OnEdit_Selection_LoadSelection3()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection3()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection3

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 4.
        /// </summary>
        public void OnEdit_Selection_LoadSelection4()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection4()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection4

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 5.
        /// </summary>
        public void OnEdit_Selection_LoadSelection5()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection5()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection5

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 6.
        /// </summary>
        public void OnEdit_Selection_LoadSelection6()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection6()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection6

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 7.
        /// </summary>
        public void OnEdit_Selection_LoadSelection7()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection7()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection7

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 8.
        /// </summary>
        public void OnEdit_Selection_LoadSelection8()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection8()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection8

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 9.
        /// </summary>
        public void OnEdit_Selection_LoadSelection9()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection9()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection9

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 0.
        /// </summary>
        public void OnEdit_Selection_LoadSelection0()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_LoadSelection0()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection0

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 1.
        /// </summary>
        public void OnEdit_Selection_SaveSelection1()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection1()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection1

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 2.
        /// </summary>
        public void OnEdit_Selection_SaveSelection2()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection2()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection2

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 3.
        /// </summary>
        public void OnEdit_Selection_SaveSelection3()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection3()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection3

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 4.
        /// </summary>
        public void OnEdit_Selection_SaveSelection4()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection4()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection4

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 5.
        /// </summary>
        public void OnEdit_Selection_SaveSelection5()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection5()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection5

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 6.
        /// </summary>
        public void OnEdit_Selection_SaveSelection6()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection6()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection6

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 7.
        /// </summary>
        public void OnEdit_Selection_SaveSelection7()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection7()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection7

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 8.
        /// </summary>
        public void OnEdit_Selection_SaveSelection8()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection8()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection8

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 9.
        /// </summary>
        public void OnEdit_Selection_SaveSelection9()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection9()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection9

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 0.
        /// </summary>
        public void OnEdit_Selection_SaveSelection0()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_Selection_SaveSelection0()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection0

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Edit -> Project Settings
        /// <summary>
        /// Handler for Edit -> Project Settings -> Input.
        /// </summary>
        public void OnEdit_ProjectSettings_Input()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Input()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Input

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Tags and Layers.
        /// </summary>
        public void OnEdit_ProjectSettings_TagsAndLayers()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Audio.
        /// </summary>
        public void OnEdit_ProjectSettings_Audio()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Audio()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Audio

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Time.
        /// </summary>
        public void OnEdit_ProjectSettings_Time()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Time()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Time

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Player.
        /// </summary>
        public void OnEdit_ProjectSettings_Player()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Player()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Player

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Physics.
        /// </summary>
        public void OnEdit_ProjectSettings_Physics()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Physics()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Physics

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Physics 2D.
        /// </summary>
        public void OnEdit_ProjectSettings_Physics2D()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Physics2D()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Physics2D

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Quality.
        /// </summary>
        public void OnEdit_ProjectSettings_Quality()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Quality()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Quality

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Graphics.
        /// </summary>
        public void OnEdit_ProjectSettings_Graphics()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Graphics()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Graphics

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Network.
        /// </summary>
        public void OnEdit_ProjectSettings_Network()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Network()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Network

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Editor.
        /// </summary>
        public void OnEdit_ProjectSettings_Editor()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_Editor()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Editor

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Script Execution Order.
        /// </summary>
        public void OnEdit_ProjectSettings_ScriptExecutionOrder()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Edit -> Network Emulation
        /// <summary>
        /// Handler for Edit -> Network Emulation -> None.
        /// </summary>
        public void OnEdit_NetworkEmulation_None()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_NetworkEmulation_None()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_None

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> Broadband.
        /// </summary>
        public void OnEdit_NetworkEmulation_Broadband()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_NetworkEmulation_Broadband()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_Broadband

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> DSL.
        /// </summary>
        public void OnEdit_NetworkEmulation_DSL()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_NetworkEmulation_DSL()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_DSL

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> ISDN.
        /// </summary>
        public void OnEdit_NetworkEmulation_ISDN()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_NetworkEmulation_ISDN()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_ISDN

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> Dial-Up.
        /// </summary>
        public void OnEdit_NetworkEmulation_DialUp()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_NetworkEmulation_DialUp()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_DialUp

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Edit -> Graphics Emulation
        /// <summary>
        /// Handler for Edit -> Graphics Emulation -> No Emulation.
        /// </summary>
        public void OnEdit_GraphicsEmulation_NoEmulation()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Graphics Emulation -> Shader Model 3.
        /// </summary>
        public void OnEdit_GraphicsEmulation_ShaderModel3()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel3()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ReOnEdit_GraphicsEmulation_ShaderModel3do

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Graphics Emulation -> Shader Model 2.
        /// </summary>
        public void OnEdit_GraphicsEmulation_ShaderModel2()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2

            AppUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for Edit -> Snap Settings...
        /// </summary>
        public void OnEdit_SnapSettings()
        {
            DebugEx.UserInteraction("MainMenuScript.OnEdit_SnapSettings()");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_SnapSettings

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Assets
        /// <summary>
        /// Handler for Assets.
        /// </summary>
        public void OnAssetsMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnAssetsMenu()");

            OnShowMenuSubItems(mUi.assetsMenu);
        }

        #region Assets -> Create
        /// <summary>
        /// Handler for Assets -> Create -> Folder.
        /// </summary>
        public void OnAssets_Create_Folder()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Folder()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Folder

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> C# Script.
        /// </summary>
        public void OnAssets_Create_CSharpScript()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_CSharpScript()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_CSharpScript

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Javascript.
        /// </summary>
        public void OnAssets_Create_Javascript()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Javascript()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Javascript

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Shader.
        /// </summary>
        public void OnAssets_Create_Shader()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Shader()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Shader

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Compute Shader.
        /// </summary>
        public void OnAssets_Create_ComputeShader()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_ComputeShader()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_ComputeShader

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Prefab.
        /// </summary>
        public void OnAssets_Create_Prefab()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Prefab()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Prefab

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Audio Mixer.
        /// </summary>
        public void OnAssets_Create_AudioMixer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_AudioMixer()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AudioMixer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Material.
        /// </summary>
        public void OnAssets_Create_Material()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Material()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Material

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Lens Flare.
        /// </summary>
        public void OnAssets_Create_LensFlare()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_LensFlare()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_LensFlare

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Render Texture.
        /// </summary>
        public void OnAssets_Create_RenderTexture()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_RenderTexture()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_RenderTexture

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Lightmap Parameters.
        /// </summary>
        public void OnAssets_Create_LightmapParameters()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_LightmapParameters()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_LightmapParameters

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Animator Controller.
        /// </summary>
        public void OnAssets_Create_AnimatorController()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_AnimatorController()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AnimatorController

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Animation.
        /// </summary>
        public void OnAssets_Create_Animation()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Animation()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Animation

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Animator Override Contoller.
        /// </summary>
        public void OnAssets_Create_AnimatorOverrideContoller()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_AnimatorOverrideContoller()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AnimatorOverrideContoller

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Avatar Mask.
        /// </summary>
        public void OnAssets_Create_AvatarMask()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_AvatarMask()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AvatarMask

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Physic Material.
        /// </summary>
        public void OnAssets_Create_PhysicMaterial()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_PhysicMaterial()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_PhysicMaterial

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Physic2D Material.
        /// </summary>
        public void OnAssets_Create_Physic2dMaterial()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Physic2dMaterial()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Physic2dMaterial

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> GUI Skin.
        /// </summary>
        public void OnAssets_Create_GuiSkin()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_GuiSkin()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_GuiSkin

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Custom Font.
        /// </summary>
        public void OnAssets_Create_CustomFont()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_CustomFont()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_CustomFont

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Shader Variant Collection.
        /// </summary>
        public void OnAssets_Create_ShaderVariantCollection()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_ShaderVariantCollection()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_ShaderVariantCollection

            AppUtils.ShowContributeMessage();
        }

        #region Assets -> Create -> Legacy
        /// <summary>
        /// Handler for Assets -> Create -> Legacy -> Cubemap.
        /// </summary>
        public void OnAssets_Create_Legacy_Cubemap()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Create_Legacy_Cubemap()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Legacy_Cubemap

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #endregion

        /// <summary>
        /// Handler for Assets -> Show In Explorer.
        /// </summary>
        public void OnAssets_ShowInExplorer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ShowInExplorer()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ShowInExplorer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Open.
        /// </summary>
        public void OnAssets_Open()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Open()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Open

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Delete.
        /// </summary>
        public void OnAssets_Delete()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Delete()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Delete

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import New Asset...
        /// </summary>
        public void OnAssets_ImportNewAsset()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportNewAsset()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportNewAsset

            AppUtils.ShowContributeMessage();
        }

        #region Assets -> Import Package
        /// <summary>
        /// Handler for Assets -> Import Package -> Custom Package...
        /// </summary>
        public void OnAssets_ImportPackage_CustomPackage()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_CustomPackage()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_CustomPackage

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> 2D.
        /// </summary>
        public void OnAssets_ImportPackage_2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_2d()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Cameras.
        /// </summary>
        public void OnAssets_ImportPackage_Cameras()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Cameras()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Cameras

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Characters.
        /// </summary>
        public void OnAssets_ImportPackage_Characters()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Characters()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Characters

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> CrossPlatformInput.
        /// </summary>
        public void OnAssets_ImportPackage_CrossPlatformInput()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Effects.
        /// </summary>
        public void OnAssets_ImportPackage_Effects()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Effects()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Effects

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Environment.
        /// </summary>
        public void OnAssets_ImportPackage_Environment()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Environment()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Environment

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> ParticleSystems.
        /// </summary>
        public void OnAssets_ImportPackage_ParticleSystems()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_ParticleSystems()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_ParticleSystems

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Prototyping.
        /// </summary>
        public void OnAssets_ImportPackage_Prototyping()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Prototyping()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Prototyping

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Utility.
        /// </summary>
        public void OnAssets_ImportPackage_Utility()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Utility()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Utility

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Vehicles.
        /// </summary>
        public void OnAssets_ImportPackage_Vehicles()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ImportPackage_Vehicles()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Vehicles

            AppUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for Assets -> Export Package...
        /// </summary>
        public void OnAssets_ExportPackage()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ExportPackage()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ExportPackage

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Find References In Scene.
        /// </summary>
        public void OnAssets_FindReferencesInScene()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_FindReferencesInScene()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_FindReferencesInScene

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Select Dependencies.
        /// </summary>
        public void OnAssets_SelectDependencies()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_SelectDependencies()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_SelectDependencies

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Refresh.
        /// </summary>
        public void OnAssets_Refresh()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Refresh()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Refresh

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Reimport.
        /// </summary>
        public void OnAssets_Reimport()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_Reimport()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Reimport

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Reimport All.
        /// </summary>
        public void OnAssets_ReimportAll()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_ReimportAll()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ReimportAll

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Run API Updater...
        /// </summary>
        public void OnAssets_RunApiUpdater()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_RunApiUpdater()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_RunApiUpdater

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Sync MonoDevelop Project.
        /// </summary>
        public void OnAssets_SyncMonoDevelopProject()
        {
            DebugEx.UserInteraction("MainMenuScript.OnAssets_SyncMonoDevelopProject()");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_SyncMonoDevelopProject

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject
        /// <summary>
        /// Handler for GameObject.
        /// </summary>
        public void OnGameObjectMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnGameObjectMenu()");

            OnShowMenuSubItems(mUi.gameObjectMenu);
        }

        /// <summary>
        /// Handler for GameObject -> Create Empty.
        /// </summary>
        public void OnGameObject_CreateEmpty()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_CreateEmpty()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_CreateEmpty

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Create Empty Child.
        /// </summary>
        public void OnGameObject_CreateEmptyChild()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_CreateEmptyChild()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_CreateEmptyChild

            AppUtils.ShowContributeMessage();
        }

        #region GameObject -> 3D Object
        /// <summary>
        /// Handler for GameObject -> 3D Object -> Cube.
        /// </summary>
        public void OnGameObject_3dObject_Cube()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Cube()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Cube

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Sphere.
        /// </summary>
        public void OnGameObject_3dObject_Sphere()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Sphere()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Sphere

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Capsule.
        /// </summary>
        public void OnGameObject_3dObject_Capsule()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Capsule()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Capsule

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Cylinder.
        /// </summary>
        public void OnGameObject_3dObject_Cylinder()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Cylinder()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Cylinder

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Plane.
        /// </summary>
        public void OnGameObject_3dObject_Plane()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Plane()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Plane

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Quad.
        /// </summary>
        public void OnGameObject_3dObject_Quad()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Quad()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Quad

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Ragdoll...
        /// </summary>
        public void OnGameObject_3dObject_Ragdoll()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Ragdoll()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Ragdoll

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Terrain.
        /// </summary>
        public void OnGameObject_3dObject_Terrain()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Terrain()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Terrain

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Tree.
        /// </summary>
        public void OnGameObject_3dObject_Tree()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_Tree()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Tree

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Wind Zone.
        /// </summary>
        public void OnGameObject_3dObject_WindZone()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_WindZone()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_WindZone

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> 3D Text.
        /// </summary>
        public void OnGameObject_3dObject_3dText()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_3dObject_3dText()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_3dText

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> 2D Object
        /// <summary>
        /// Handler for GameObject -> 2D Object -> Sprite.
        /// </summary>
        public void OnGameObject_2dObject_Sprite()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_2dObject_Sprite()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_2dObject_Sprite

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> Light
        /// <summary>
        /// Handler for GameObject -> Light -> Directional Light.
        /// </summary>
        public void OnGameObject_Light_DirectionalLight()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Light_DirectionalLight()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_DirectionalLight

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Point Light.
        /// </summary>
        public void OnGameObject_Light_PointLight()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Light_PointLight()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_PointLight

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Spotlight.
        /// </summary>
        public void OnGameObject_Light_Spotlight()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Light_Spotlight()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_Spotlight

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Area Light.
        /// </summary>
        public void OnGameObject_Light_AreaLight()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Light_AreaLight()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_AreaLight

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Reflection Probe.
        /// </summary>
        public void OnGameObject_Light_ReflectionProbe()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Light_ReflectionProbe()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_ReflectionProbe

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Light Probe Group.
        /// </summary>
        public void OnGameObject_Light_LightProbeGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Light_LightProbeGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_LightProbeGroup

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> Audio
        /// <summary>
        /// Handler for GameObject -> Audio -> Audio Source.
        /// </summary>
        public void OnGameObject_Audio_AudioSource()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Audio_AudioSource()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Audio_AudioSource

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Audio -> Audio Reverb Zone.
        /// </summary>
        public void OnGameObject_Audio_AudioReverbZone()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Audio_AudioReverbZone()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Audio_AudioReverbZone

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> UI
        /// <summary>
        /// Handler for GameObject -> UI -> Panel.
        /// </summary>
        public void OnGameObject_Ui_Panel()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Panel()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Panel

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Button.
        /// </summary>
        public void OnGameObject_Ui_Button()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Button()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Button

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Text.
        /// </summary>
        public void OnGameObject_Ui_Text()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Text()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Text

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Image.
        /// </summary>
        public void OnGameObject_Ui_Image()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Image()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Image

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Raw Image.
        /// </summary>
        public void OnGameObject_Ui_RawImage()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_RawImage()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_RawImage

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Slider.
        /// </summary>
        public void OnGameObject_Ui_Slider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Slider()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Slider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Scrollbar.
        /// </summary>
        public void OnGameObject_Ui_Scrollbar()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Scrollbar()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Scrollbar

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Toggle.
        /// </summary>
        public void OnGameObject_Ui_Toggle()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Toggle()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Toggle

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Input Field.
        /// </summary>
        public void OnGameObject_Ui_InputField()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_InputField()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_InputField

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Canvas.
        /// </summary>
        public void OnGameObject_Ui_Canvas()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_Canvas()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Canvas

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Event System.
        /// </summary>
        public void OnGameObject_Ui_EventSystem()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Ui_EventSystem()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_EventSystem

            AppUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for GameObject -> Particle System.
        /// </summary>
        public void OnGameObject_ParticleSystem()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_ParticleSystem()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ParticleSystem

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Camera.
        /// </summary>
        public void OnGameObject_Camera()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_Camera()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Camera

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Center On Children.
        /// </summary>
        public void OnGameObject_CenterOnChildren()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_CenterOnChildren()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_CenterOnChildren

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Make Parent.
        /// </summary>
        public void OnGameObject_MakeParent()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_MakeParent()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_MakeParent

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Clear Parent.
        /// </summary>
        public void OnGameObject_ClearParent()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_ClearParent()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ClearParent

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Apply Changes To Prefab.
        /// </summary>
        public void OnGameObject_ApplyChangesToPrefab()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_ApplyChangesToPrefab()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ApplyChangesToPrefab

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Break Prefab Instance.
        /// </summary>
        public void OnGameObject_BreakPrefabInstance()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_BreakPrefabInstance()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_BreakPrefabInstance

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Set as first sibling.
        /// </summary>
        public void OnGameObject_SetAsFirstSibling()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_SetAsFirstSibling()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_SetAsFirstSibling

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Set as last sibling.
        /// </summary>
        public void OnGameObject_SetAsLastSibling()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_SetAsLastSibling()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_SetAsLastSibling

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Move To View.
        /// </summary>
        public void OnGameObject_MoveToView()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_MoveToView()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_MoveToView

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Align With View.
        /// </summary>
        public void OnGameObject_AlignWithView()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_AlignWithView()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_AlignWithView

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Align View to Selected.
        /// </summary>
        public void OnGameObject_AlignViewToSelected()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_AlignViewToSelected()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_AlignViewToSelected

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Toggle Active State.
        /// </summary>
        public void OnGameObject_ToggleActiveState()
        {
            DebugEx.UserInteraction("MainMenuScript.OnGameObject_ToggleActiveState()");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ToggleActiveState

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component
        /// <summary>
        /// Handler for Component.
        /// </summary>
        public void OnComponentMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnComponentMenu()");

            OnShowMenuSubItems(mUi.componentMenu);
        }

        /// <summary>
        /// Handler for Component -> Add...
        /// </summary>
        public void OnComponent_Add()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Add()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Add

            AppUtils.ShowContributeMessage();
        }

        #region Component -> Mesh
        /// <summary>
        /// Handler for Component -> Mesh -> Mesh Filter.
        /// </summary>
        public void OnComponent_Mesh_MeshFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Mesh_MeshFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_MeshFilter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Mesh -> Text Mesh.
        /// </summary>
        public void OnComponent_Mesh_TextMesh()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Mesh_TextMesh()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_TextMesh

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Mesh -> Mesh Renderer.
        /// </summary>
        public void OnComponent_Mesh_MeshRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Mesh_MeshRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_MeshRenderer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Mesh -> Skinned Mesh Renderer.
        /// </summary>
        public void OnComponent_Mesh_SkinnedMeshRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Effects
        /// <summary>
        /// Handler for Component -> Effects -> Particle System.
        /// </summary>
        public void OnComponent_Effects_ParticleSystem()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_ParticleSystem()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_ParticleSystem

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Trail Renderer.
        /// </summary>
        public void OnComponent_Effects_TrailRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_TrailRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_TrailRenderer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Line Renderer.
        /// </summary>
        public void OnComponent_Effects_LineRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LineRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LineRenderer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Lens Flare.
        /// </summary>
        public void OnComponent_Effects_LensFlare()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LensFlare()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LensFlare

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Halo.
        /// </summary>
        public void OnComponent_Effects_Halo()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_Halo()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_Halo

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Projector.
        /// </summary>
        public void OnComponent_Effects_Projector()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_Projector()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_Projector

            AppUtils.ShowContributeMessage();
        }

        #region Component -> Effects -> Legacy Particles
        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Ellipsoid Particle Emitter.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Mesh Particle Emitter.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_MeshParticleEmitter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Particle Animator.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_ParticleAnimator()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> World Particle Collider.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_WorldParticleCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Particle Renderer.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_ParticleRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #endregion

        #region Component -> Physics
        /// <summary>
        /// Handler for Component -> Physics -> Rigidbody.
        /// </summary>
        public void OnComponent_Physics_Rigidbody()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_Rigidbody()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_Rigidbody

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Character Controller.
        /// </summary>
        public void OnComponent_Physics_CharacterController()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_CharacterController()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_CharacterController

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Box Collider.
        /// </summary>
        public void OnComponent_Physics_BoxCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_BoxCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_BoxCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Sphere Collider.
        /// </summary>
        public void OnComponent_Physics_SphereCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_SphereCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_SphereCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Capsule Collider.
        /// </summary>
        public void OnComponent_Physics_CapsuleCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_CapsuleCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_CapsuleCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Mesh Collider.
        /// </summary>
        public void OnComponent_Physics_MeshCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_MeshCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_MeshCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Wheel Collider.
        /// </summary>
        public void OnComponent_Physics_WheelCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_WheelCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_WheelCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Terrain Collider.
        /// </summary>
        public void OnComponent_Physics_TerrainCollider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_TerrainCollider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_TerrainCollider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Cloth.
        /// </summary>
        public void OnComponent_Physics_Cloth()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_Cloth()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_Cloth

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Hinge Joint.
        /// </summary>
        public void OnComponent_Physics_HingeJoint()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_HingeJoint()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_HingeJoint

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Fixed Joint.
        /// </summary>
        public void OnComponent_Physics_FixedJoint()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_FixedJoint()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_FixedJoint

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Spring Joint.
        /// </summary>
        public void OnComponent_Physics_SpringJoint()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_SpringJoint()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_SpringJoint

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Character Joint.
        /// </summary>
        public void OnComponent_Physics_CharacterJoint()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_CharacterJoint()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_CharacterJoint

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Configurable Joint.
        /// </summary>
        public void OnComponent_Physics_ConfigurableJoint()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_ConfigurableJoint()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_ConfigurableJoint

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Constant Force.
        /// </summary>
        public void OnComponent_Physics_ConstantForce()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics_ConstantForce()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_ConstantForce

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Physics 2D
        /// <summary>
        /// Handler for Component -> Physics 2D -> Rigidbody 2D.
        /// </summary>
        public void OnComponent_Physics2d_Rigidbody2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_Rigidbody2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_Rigidbody2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Circle Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_CircleCollider2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_CircleCollider2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_CircleCollider2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Box Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_BoxCollider2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_BoxCollider2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_BoxCollider2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Edge Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_EdgeCollider2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_EdgeCollider2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_EdgeCollider2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Polygon Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_PolygonCollider2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_PolygonCollider2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_PolygonCollider2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Spring Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_SpringJoint2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_SpringJoint2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_SpringJoint2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Distance Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_DistanceJoint2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_DistanceJoint2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_DistanceJoint2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Hinge Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_HingeJoint2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_HingeJoint2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_HingeJoint2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Slider Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_SliderJoint2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_SliderJoint2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_SliderJoint2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Wheel Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_WheelJoint2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_WheelJoint2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_WheelJoint2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Constant Force 2D.
        /// </summary>
        public void OnComponent_Physics2d_ConstantForce2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_ConstantForce2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_ConstantForce2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Area Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_AreaEffector2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_AreaEffector2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_AreaEffector2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Point Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_PointEffector2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_PointEffector2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_PointEffector2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Platform Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_PlatformEffector2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_PlatformEffector2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_PlatformEffector2d

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Surface Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_SurfaceEffector2d()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Navigation
        /// <summary>
        /// Handler for Component -> Navigation -> Nav Mesh Agent.
        /// </summary>
        public void OnComponent_Navigation_NavMeshAgent()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Navigation_NavMeshAgent()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Navigation_NavMeshAgent

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Navigation -> Off Mesh Link.
        /// </summary>
        public void OnComponent_Navigation_OffMeshLink()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Navigation_OffMeshLink()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Navigation_OffMeshLink

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Navigation -> Nav Mesh Obstacle.
        /// </summary>
        public void OnComponent_Navigation_NavMeshObstacle()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Navigation_NavMeshObstacle()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Navigation_NavMeshObstacle

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Audio
        /// <summary>
        /// Handler for Component -> Audio -> Audio Listener.
        /// </summary>
        public void OnComponent_Audio_AudioListener()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioListener()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioListener

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Source.
        /// </summary>
        public void OnComponent_Audio_AudioSource()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioSource()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioSource

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Reverb Zone.
        /// </summary>
        public void OnComponent_Audio_AudioReverbZone()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioReverbZone()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioReverbZone

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Low Pass Filter.
        /// </summary>
        public void OnComponent_Audio_AudioLowPassFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioLowPassFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioLowPassFilter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio High Pass Filter.
        /// </summary>
        public void OnComponent_Audio_AudioHighPassFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioHighPassFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioHighPassFilter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Echo Filter.
        /// </summary>
        public void OnComponent_Audio_AudioEchoFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioEchoFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioEchoFilter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Distortion Filter.
        /// </summary>
        public void OnComponent_Audio_AudioDistortionFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioDistortionFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioDistortionFilter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Reverb Filter.
        /// </summary>
        public void OnComponent_Audio_AudioReverbFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioReverbFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioReverbFilter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Chorus Filter.
        /// </summary>
        public void OnComponent_Audio_AudioChorusFilter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Audio_AudioChorusFilter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioChorusFilter

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Rendering
        /// <summary>
        /// Handler for Component -> Rendering -> Camera.
        /// </summary>
        public void OnComponent_Rendering_Camera()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_Camera()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_Camera

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Skybox.
        /// </summary>
        public void OnComponent_Rendering_Skybox()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_Skybox()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_Skybox

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Flare Layer.
        /// </summary>
        public void OnComponent_Rendering_FlareLayer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_FlareLayer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_FlareLayer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> GUI Layer.
        /// </summary>
        public void OnComponent_Rendering_GuiLayer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_GuiLayer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_GuiLayer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Light.
        /// </summary>
        public void OnComponent_Rendering_Light()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_Light()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_Light

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Light Probe Group.
        /// </summary>
        public void OnComponent_Rendering_LightProbeGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_LightProbeGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_LightProbeGroup

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Reflection Probe.
        /// </summary>
        public void OnComponent_Rendering_ReflectionProbe()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_ReflectionProbe()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_ReflectionProbe

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Occlusion Area.
        /// </summary>
        public void OnComponent_Rendering_OcclusionArea()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_OcclusionArea()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_OcclusionArea

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Occlusion Portal.
        /// </summary>
        public void OnComponent_Rendering_OcclusionPortal()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_OcclusionPortal()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_OcclusionPortal

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> LOD Group.
        /// </summary>
        public void OnComponent_Rendering_LodGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_LodGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_LodGroup

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Sprite Renderer.
        /// </summary>
        public void OnComponent_Rendering_SpriteRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_SpriteRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_SpriteRenderer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Canvas Renderer.
        /// </summary>
        public void OnComponent_Rendering_CanvasRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_CanvasRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_CanvasRenderer

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> GUI Texture.
        /// </summary>
        public void OnComponent_Rendering_GuiTexture()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_GuiTexture()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_GuiTexture

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> GUI Text.
        /// </summary>
        public void OnComponent_Rendering_GuiText()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Rendering_GuiText()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_GuiText

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Layout
        /// <summary>
        /// Handler for Component -> Layout -> Rect Transform.
        /// </summary>
        public void OnComponent_Layout_RectTransform()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_RectTransform()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_RectTransform

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Canvas.
        /// </summary>
        public void OnComponent_Layout_Canvas()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_Canvas()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_Canvas

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Canvas Group.
        /// </summary>
        public void OnComponent_Layout_CanvasGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_CanvasGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_CanvasGroup

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Canvas Scaler.
        /// </summary>
        public void OnComponent_Layout_CanvasScaler()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_CanvasScaler()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_CanvasScaler

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Layout Element.
        /// </summary>
        public void OnComponent_Layout_LayoutElement()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_LayoutElement()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_LayoutElement

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Content Size Fitter.
        /// </summary>
        public void OnComponent_Layout_ContentSizeFitter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_ContentSizeFitter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_ContentSizeFitter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Aspect Ratio Fitter.
        /// </summary>
        public void OnComponent_Layout_AspectRatioFitter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_AspectRatioFitter()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_AspectRatioFitter

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Horizontal Layout Group.
        /// </summary>
        public void OnComponent_Layout_HorizontalLayoutGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Vertical Layout Group.
        /// </summary>
        public void OnComponent_Layout_VerticalLayoutGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_VerticalLayoutGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_VerticalLayoutGroup

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Grid Layout Group.
        /// </summary>
        public void OnComponent_Layout_GridLayoutGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Layout_GridLayoutGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_GridLayoutGroup

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Miscellaneous
        /// <summary>
        /// Handler for Component -> Miscellaneous -> Animator.
        /// </summary>
        public void OnComponent_Miscellaneous_Animator()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Miscellaneous_Animator()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_Animator

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Animation.
        /// </summary>
        public void OnComponent_Miscellaneous_Animation()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Miscellaneous_Animation()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_Animation

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Network View.
        /// </summary>
        public void OnComponent_Miscellaneous_NetworkView()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Miscellaneous_NetworkView()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_NetworkView

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Wind Zone.
        /// </summary>
        public void OnComponent_Miscellaneous_WindZone()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Miscellaneous_WindZone()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_WindZone

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Terrain.
        /// </summary>
        public void OnComponent_Miscellaneous_Terrain()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Miscellaneous_Terrain()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_Terrain

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Billboard Renderer.
        /// </summary>
        public void OnComponent_Miscellaneous_BillboardRenderer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Event
        /// <summary>
        /// Handler for Component -> Miscellaneous -> Event System.
        /// </summary>
        public void OnComponent_Event_EventSystem()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_EventSystem()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_EventSystem

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Event Trigger.
        /// </summary>
        public void OnComponent_Event_EventTrigger()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_EventTrigger()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_EventTrigger

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Physics 2D Raycaster.
        /// </summary>
        public void OnComponent_Event_Physics2dRaycaster()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_Physics2dRaycaster()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_Physics2dRaycaster

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Physics Raycaster.
        /// </summary>
        public void OnComponent_Event_PhysicsRaycaster()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_PhysicsRaycaster()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_PhysicsRaycaster

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Standalone Input Module.
        /// </summary>
        public void OnComponent_Event_StandaloneInputModule()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_StandaloneInputModule()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_StandaloneInputModule

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Touch Input Module.
        /// </summary>
        public void OnComponent_Event_TouchInputModule()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_TouchInputModule()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_TouchInputModule

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Graphic Raycaster.
        /// </summary>
        public void OnComponent_Event_GraphicRaycaster()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Event_GraphicRaycaster()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_GraphicRaycaster

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> UI

        #region Component -> UI -> Effects
        /// <summary>
        /// Handler for Component -> UI -> Effects -> Shadow.
        /// </summary>
        public void OnComponent_Ui_Effects_Shadow()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Effects_Shadow()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Effects_Shadow

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Effects -> Outline.
        /// </summary>
        public void OnComponent_Ui_Effects_Outline()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Effects_Outline()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Effects_Outline

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Effects -> Position As UV1.
        /// </summary>
        public void OnComponent_Ui_Effects_PositionAsUv1()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1

            AppUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for Component -> UI -> Image.
        /// </summary>
        public void OnComponent_Ui_Image()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Image()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Image

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Text.
        /// </summary>
        public void OnComponent_Ui_Text()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Text()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Text

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Raw Image.
        /// </summary>
        public void OnComponent_Ui_RawImage()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_RawImage()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_RawImage

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Mask.
        /// </summary>
        public void OnComponent_Ui_Mask()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Mask()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Mask

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Button.
        /// </summary>
        public void OnComponent_Ui_Button()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Button()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Button

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Input Field.
        /// </summary>
        public void OnComponent_Ui_InputField()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_InputField()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_InputField

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Scrollbar.
        /// </summary>
        public void OnComponent_Ui_Scrollbar()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Scrollbar()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Scrollbar

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Scroll Rect.
        /// </summary>
        public void OnComponent_Ui_ScrollRect()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_ScrollRect()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_ScrollRect

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Slider.
        /// </summary>
        public void OnComponent_Ui_Slider()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Slider()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Slider

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Toggle.
        /// </summary>
        public void OnComponent_Ui_Toggle()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Toggle()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Toggle

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Toggle Group.
        /// </summary>
        public void OnComponent_Ui_ToggleGroup()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_ToggleGroup()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_ToggleGroup

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Selectable.
        /// </summary>
        public void OnComponent_Ui_Selectable()
        {
            DebugEx.UserInteraction("MainMenuScript.OnComponent_Ui_Selectable()");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Selectable

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #endregion

        #region Window
        /// <summary>
        /// Handler for Window.
        /// </summary>
        public void OnWindowMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnWindowMenu()");

            OnShowMenuSubItems(mUi.windowMenu);
        }

        /// <summary>
        /// Handler for Window -> Next Window.
        /// </summary>
        public void OnWindow_NextWindow()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_NextWindow()");

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
                DebugEx.Fatal("Unexpected behaviour in MainMenuScript.OnWindow_NextWindow()");
            }
        }

        /// <summary>
        /// Handler for Window -> Previous Window.
        /// </summary>
        public void OnWindow_PreviousWindow()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_PreviousWindow()");

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
                DebugEx.Fatal("Unexpected behaviour in MainMenuScript.OnWindow_PreviousWindow()");
            }
        }

        #region Window -> Layouts
        /// <summary>
        /// Handler for Window -> Layouts -> 2 by 3.
        /// </summary>
        public void OnWindow_Layouts_2_by_3()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_2_by_3()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_2_by_3

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> 4 Split.
        /// </summary>
        public void OnWindow_Layouts_4_split()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_4_split()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_4_split

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Default.
        /// </summary>
        public void OnWindow_Layouts_Default()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_Default()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Default

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Tall.
        /// </summary>
        public void OnWindow_Layouts_Tall()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_Tall()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Tall

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Wide.
        /// </summary>
        public void OnWindow_Layouts_Wide()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_Wide()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Wide

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Save Layout.
        /// </summary>
        public void OnWindow_Layouts_SaveLayout()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_SaveLayout()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_SaveLayout

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Delete Layout.
        /// </summary>
        public void OnWindow_Layouts_DeleteLayout()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_DeleteLayout()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_DeleteLayout

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Revert Factory Settings.
        /// </summary>
        public void OnWindow_Layouts_RevertFactorySettings()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Layouts_RevertFactorySettings()");
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
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SetWindowSize()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SetWindowSize

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Set Window Size Small.
        /// </summary>
        public void OnWindow_Screenshot_SetWindowSizeSmall()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View.
        /// </summary>
        public void OnWindow_Screenshot_SnapView()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SnapView()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapView

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View Toolbar.
        /// </summary>
        public void OnWindow_Screenshot_SnapViewToolbar()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SnapViewToolbar()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapViewToolbar

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View Extended Right.
        /// </summary>
        public void OnWindow_Screenshot_SnapViewExtendedRight()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SnapViewExtendedRight()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapViewExtendedRight

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap Component.
        /// </summary>
        public void OnWindow_Screenshot_SnapComponent()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SnapComponent()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapComponent

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap Game View Content.
        /// </summary>
        public void OnWindow_Screenshot_SnapGameViewContent()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_SnapGameViewContent()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapGameViewContent

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Toggle DeveloperBuild.
        /// </summary>
        public void OnWindow_Screenshot_ToggleDeveloperBuild()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Screenshot_ToggleDeveloperBuild()");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_ToggleDeveloperBuild

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
            DebugEx.VerboseFormat("MainMenuScript.ShowDockWidget(globalPointer = {0}, name = {1})", globalPointer, name);

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
        /// Handler for Window -> Scene.
        /// </summary>
        public void OnWindow_Scene()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Scene()");

            ShowDockWidget<SceneDockWidgetScript>(ref Global.sceneDockWidgetScript, "Scene");
        }

        /// <summary>
        /// Handler for Window -> Game.
        /// </summary>
        public void OnWindow_Game()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Game()");

            ShowDockWidget<GameDockWidgetScript>(ref Global.gameDockWidgetScript, "Game");
        }

        /// <summary>
        /// Handler for Window -> Inspector.
        /// </summary>
        public void OnWindow_Inspector()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Inspector()");

            ShowDockWidget<InspectorDockWidgetScript>(ref Global.inspectorDockWidgetScript, "Inspector");
        }

        /// <summary>
        /// Handler for Window -> Hierarchy.
        /// </summary>
        public void OnWindow_Hierarchy()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Hierarchy()");

            ShowDockWidget<HierarchyDockWidgetScript>(ref Global.hierarchyDockWidgetScript, "Hierarchy");
        }

        /// <summary>
        /// Handler for Window -> Project.
        /// </summary>
        public void OnWindow_Project()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Project()");

            ShowDockWidget<ProjectDockWidgetScript>(ref Global.projectDockWidgetScript, "Project");
        }

        /// <summary>
        /// Handler for Window -> Animation.
        /// </summary>
        public void OnWindow_Animation()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Animation()");

            ShowDockWidget<AnimationDockWidgetScript>(ref Global.animationDockWidgetScript, "Animation");
        }

        /// <summary>
        /// Handler for Window -> Profiler.
        /// </summary>
        public void OnWindow_Profiler()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Profiler()");

            ShowDockWidget<ProfilerDockWidgetScript>(ref Global.profilerDockWidgetScript, "Profiler");
        }

        /// <summary>
        /// Handler for Window -> Audio Mixer.
        /// </summary>
        public void OnWindow_AudioMixer()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_AudioMixer()");

            ShowDockWidget<AudioMixerDockWidgetScript>(ref Global.audioMixerDockWidgetScript, "AudioMixer");
        }

        /// <summary>
        /// Handler for Window -> Asset Store.
        /// </summary>
        public void OnWindow_AssetStore()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_AssetStore()");

            ShowDockWidget<AssetStoreDockWidgetScript>(ref Global.assetStoreDockWidgetScript, "AssetStore");
        }

        /// <summary>
        /// Handler for Window -> Version Control.
        /// </summary>
        public void OnWindow_VersionControl()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_VersionControl()");

            ShowDockWidget<VersionControlDockWidgetScript>(ref Global.versionControlDockWidgetScript, "VersionControl");
        }

        /// <summary>
        /// Handler for Window -> Animator Parameter.
        /// </summary>
        public void OnWindow_AnimatorParameter()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_AnimatorParameter()");

            ShowDockWidget<AnimatorParameterDockWidgetScript>(ref Global.animatorParameterDockWidgetScript, "AnimatorParameter");
        }

        /// <summary>
        /// Handler for Window -> Animator.
        /// </summary>
        public void OnWindow_Animator()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Animator()");

            ShowDockWidget<AnimatorDockWidgetScript>(ref Global.animatorDockWidgetScript, "Animator");
        }

        /// <summary>
        /// Handler for Window -> Sprite Packer.
        /// </summary>
        public void OnWindow_SpritePacker()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_SpritePacker()");

            ShowDockWidget<SpritePackerDockWidgetScript>(ref Global.spritePackerDockWidgetScript, "SpritePacker");
        }

        /// <summary>
        /// Handler for Window -> Lighting.
        /// </summary>
        public void OnWindow_Lighting()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Lighting()");

            ShowDockWidget<LightingDockWidgetScript>(ref Global.lightingDockWidgetScript, "Lighting");
        }

        /// <summary>
        /// Handler for Window -> Occlusion Culling.
        /// </summary>
        public void OnWindow_OcclusionCulling()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_OcclusionCulling()");

            ShowDockWidget<OcclusionCullingDockWidgetScript>(ref Global.occlusionCullingDockWidgetScript, "OcclusionCulling");
        }

        /// <summary>
        /// Handler for Window -> Frame Debugger.
        /// </summary>
        public void OnWindow_FrameDebugger()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_FrameDebugger()");

            ShowDockWidget<FrameDebuggerDockWidgetScript>(ref Global.frameDebuggerDockWidgetScript, "FrameDebugger");
        }

        /// <summary>
        /// Handler for Window -> Navigation.
        /// </summary>
        public void OnWindow_Navigation()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Navigation()");

            ShowDockWidget<NavigationDockWidgetScript>(ref Global.navigationDockWidgetScript, "Navigation");
        }

        /// <summary>
        /// Handler for Window -> Console.
        /// </summary>
        public void OnWindow_Console()
        {
            DebugEx.UserInteraction("MainMenuScript.OnWindow_Console()");

            ShowDockWidget<ConsoleDockWidgetScript>(ref Global.consoleDockWidgetScript, "Console");
        }
        #endregion

        #region Help
        /// <summary>
        /// Handler for Help.
        /// </summary>
        public void OnHelpMenu()
        {
            DebugEx.Verbose("MainMenuScript.OnHelpMenu()");

            OnShowMenuSubItems(mUi.helpMenu);
        }

        /// <summary>
        /// Handler for Help -> About Unity...
        /// </summary>
        public void OnHelp_AboutUnity()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_AboutUnity()");

            AboutDialogScript.Create().Show();
        }

        /// <summary>
        /// Handler for Help -> Manage License...
        /// </summary>
        public void OnHelp_ManageLicense()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_ManageLicense()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ManageLicense

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Manual.
        /// </summary>
        public void OnHelp_UnityManual()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_UnityManual()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityManual

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Scripting Reference.
        /// </summary>
        public void OnHelp_ScriptingReference()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_ScriptingReference()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ScriptingReference

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Connect.
        /// </summary>
        public void OnHelp_UnityConnect()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_UnityConnect()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityConnect

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Forum.
        /// </summary>
        public void OnHelp_UnityForum()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_UnityForum()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityForum

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Answers.
        /// </summary>
        public void OnHelp_UnityAnswers()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_UnityAnswers()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityAnswers

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Feedback.
        /// </summary>
        public void OnHelp_UnityFeedback()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_UnityFeedback()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityFeedback

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Check for Updates.
        /// </summary>
        public void OnHelp_CheckForUpdates()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_CheckForUpdates()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_CheckForUpdates

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Download Beta...
        /// </summary>
        public void OnHelp_DownloadBeta()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_DownloadBeta()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_DownloadBeta

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Release Notes.
        /// </summary>
        public void OnHelp_ReleaseNotes()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_ReleaseNotes()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ReleaseNotes

            AppUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Report a Bug...
        /// </summary>
        public void OnHelp_ReportABug()
        {
            DebugEx.UserInteraction("MainMenuScript.OnHelp_ReportABug()");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ReportABug

            AppUtils.ShowContributeMessage();
        }
        #endregion

        #endregion
    }
}
