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
        /// Handler for File -> New Scene.
        /// </summary>
        public void OnFile_NewScene()
        {
            Debug.Log("MainMenuScript.OnFile_NewScene");
            // TODO: [Minor] Implement MainMenuScript.OnFile_NewScene

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Open Scene.
        /// </summary>
        public void OnFile_OpenScene()
        {
            Debug.Log("MainMenuScript.OnFile_OpenScene");
            // TODO: [Minor] Implement MainMenuScript.OnFile_OpenScene

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Save Scene.
        /// </summary>
        public void OnFile_SaveScene()
        {
            Debug.Log("MainMenuScript.OnFile_SaveScene");
            // TODO: [Minor] Implement MainMenuScript.OnFile_SaveScene

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Save Scene as...
        /// </summary>
        public void OnFile_SaveSceneAs()
        {
            Debug.Log("MainMenuScript.OnFile_SaveSceneAs");
            // TODO: [Minor] Implement MainMenuScript.OnFile_SaveSceneAs

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> New Project...
        /// </summary>
        public void OnFile_NewProject()
        {
            Debug.Log("MainMenuScript.OnFile_NewProject");
            // TODO: [Minor] Implement MainMenuScript.OnFile_NewProject

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Open Project...
        /// </summary>
        public void OnFile_OpenProject()
        {
            Debug.Log("MainMenuScript.OnFile_OpenProject");
            // TODO: [Minor] Implement MainMenuScript.OnFile_OpenProject

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Save Project.
        /// </summary>
        public void OnFile_SaveProject()
        {
            Debug.Log("MainMenuScript.OnFile_SaveProject");
            // TODO: [Minor] Implement MainMenuScript.OnFile_SaveProject

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Build Settings...
        /// </summary>
        public void OnFile_BuildSettings()
        {
            Debug.Log("MainMenuScript.OnFile_BuildSettings");
            // TODO: [Minor] Implement MainMenuScript.OnFile_BuildSettings

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Build & Run.
        /// </summary>
        public void OnFile_BuildAndRun()
        {
            Debug.Log("MainMenuScript.OnFile_BuildAndRun");
            // TODO: [Minor] Implement MainMenuScript.OnFile_BuildAndRun

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for File -> Build in Cloud...
        /// </summary>
        public void OnFile_BuildInCloud()
        {
            Debug.Log("MainMenuScript.OnFile_BuildInCloud");
            // TODO: [Minor] Implement MainMenuScript.OnFile_BuildInCloud

            AppCommonUtils.ShowContributeMessage();
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

        #region Edit
        /// <summary>
        /// Handler for Edit.
        /// </summary>
        public void OnEditMenu()
        {
            OnShowMenuSubItems(mUi.editMenu);
        }

        /// <summary>
        /// Handler for Edit -> Undo.
        /// </summary>
        public void OnEdit_Undo()
        {
            Debug.Log("MainMenuScript.OnEdit_Undo");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Undo

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Redo.
        /// </summary>
        public void OnEdit_Redo()
        {
            Debug.Log("MainMenuScript.OnEdit_Redo");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Redo

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Cut.
        /// </summary>
        public void OnEdit_Cut()
        {
            Debug.Log("MainMenuScript.OnEdit_Cut");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Cut

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Copy.
        /// </summary>
        public void OnEdit_Copy()
        {
            Debug.Log("MainMenuScript.OnEdit_Copy");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Copy

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Paste.
        /// </summary>
        public void OnEdit_Paste()
        {
            Debug.Log("MainMenuScript.OnEdit_Paste");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Paste

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Duplicate.
        /// </summary>
        public void OnEdit_Duplicate()
        {
            Debug.Log("MainMenuScript.OnEdit_Duplicate");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Duplicate

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Delete.
        /// </summary>
        public void OnEdit_Delete()
        {
            Debug.Log("MainMenuScript.OnEdit_Delete");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Delete

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Frame Selected.
        /// </summary>
        public void OnEdit_FrameSelected()
        {
            Debug.Log("MainMenuScript.OnEdit_FrameSelected");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_FrameSelected

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Lock View to Selected.
        /// </summary>
        public void OnEdit_LockViewToSelected()
        {
            Debug.Log("MainMenuScript.OnEdit_LockViewToSelected");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_LockViewToSelected

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Find.
        /// </summary>
        public void OnEdit_Find()
        {
            Debug.Log("MainMenuScript.OnEdit_Find");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Find

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Select All.
        /// </summary>
        public void OnEdit_SelectAll()
        {
            Debug.Log("MainMenuScript.OnEdit_SelectAll");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_SelectAll

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Preferences...
        /// </summary>
        public void OnEdit_Preferences()
        {
            Debug.Log("MainMenuScript.OnEdit_Preferences");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Preferences

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Modules...
        /// </summary>
        public void OnEdit_Modules()
        {
            Debug.Log("MainMenuScript.OnEdit_Modules");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Modules

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Play.
        /// </summary>
        public void OnEdit_Play()
        {
            Debug.Log("MainMenuScript.OnEdit_Play");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Play

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Pause.
        /// </summary>
        public void OnEdit_Pause()
        {
            Debug.Log("MainMenuScript.OnEdit_Pause");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Pause

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Step.
        /// </summary>
        public void OnEdit_Step()
        {
            Debug.Log("MainMenuScript.OnEdit_Step");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Step

            AppCommonUtils.ShowContributeMessage();
        }

        #region Edit -> Selection
        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 1.
        /// </summary>
        public void OnEdit_Selection_LoadSelection1()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection1");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection1

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 2.
        /// </summary>
        public void OnEdit_Selection_LoadSelection2()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection2");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection2

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 3.
        /// </summary>
        public void OnEdit_Selection_LoadSelection3()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection3");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection3

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 4.
        /// </summary>
        public void OnEdit_Selection_LoadSelection4()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection4");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection4

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 5.
        /// </summary>
        public void OnEdit_Selection_LoadSelection5()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection5");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection5

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 6.
        /// </summary>
        public void OnEdit_Selection_LoadSelection6()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection6");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection6

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 7.
        /// </summary>
        public void OnEdit_Selection_LoadSelection7()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection7");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection7

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 8.
        /// </summary>
        public void OnEdit_Selection_LoadSelection8()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection8");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection8

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 9.
        /// </summary>
        public void OnEdit_Selection_LoadSelection9()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection9");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection9

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Load Selection 0.
        /// </summary>
        public void OnEdit_Selection_LoadSelection0()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection0");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_LoadSelection0

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 1.
        /// </summary>
        public void OnEdit_Selection_SaveSelection1()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection1");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection1

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 2.
        /// </summary>
        public void OnEdit_Selection_SaveSelection2()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection2");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection2

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 3.
        /// </summary>
        public void OnEdit_Selection_SaveSelection3()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection3");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection3

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 4.
        /// </summary>
        public void OnEdit_Selection_SaveSelection4()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection4");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection4

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 5.
        /// </summary>
        public void OnEdit_Selection_SaveSelection5()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection5");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection5

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 6.
        /// </summary>
        public void OnEdit_Selection_SaveSelection6()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection6");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection6

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 7.
        /// </summary>
        public void OnEdit_Selection_SaveSelection7()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection7");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection7

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 8.
        /// </summary>
        public void OnEdit_Selection_SaveSelection8()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection8");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection8

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 9.
        /// </summary>
        public void OnEdit_Selection_SaveSelection9()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection9");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection9

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Selection -> Save Selection 0.
        /// </summary>
        public void OnEdit_Selection_SaveSelection0()
        {
            Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection0");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_Selection_SaveSelection0

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Edit -> Project Settings
        /// <summary>
        /// Handler for Edit -> Project Settings -> Input.
        /// </summary>
        public void OnEdit_ProjectSettings_Input()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Input");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Input

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Tags and Layers.
        /// </summary>
        public void OnEdit_ProjectSettings_TagsAndLayers()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Audio.
        /// </summary>
        public void OnEdit_ProjectSettings_Audio()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Audio");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Audio

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Time.
        /// </summary>
        public void OnEdit_ProjectSettings_Time()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Time");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Time

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Player.
        /// </summary>
        public void OnEdit_ProjectSettings_Player()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Player");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Player

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Physics.
        /// </summary>
        public void OnEdit_ProjectSettings_Physics()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Physics

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Physics 2D.
        /// </summary>
        public void OnEdit_ProjectSettings_Physics2D()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics2D");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Physics2D

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Quality.
        /// </summary>
        public void OnEdit_ProjectSettings_Quality()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Quality");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Quality

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Graphics.
        /// </summary>
        public void OnEdit_ProjectSettings_Graphics()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Graphics");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Graphics

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Network.
        /// </summary>
        public void OnEdit_ProjectSettings_Network()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Network");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Network

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Editor.
        /// </summary>
        public void OnEdit_ProjectSettings_Editor()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Editor");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_Editor

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Project Settings -> Script Execution Order.
        /// </summary>
        public void OnEdit_ProjectSettings_ScriptExecutionOrder()
        {
            Debug.Log("MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Edit -> Network Emulation
        /// <summary>
        /// Handler for Edit -> Network Emulation -> None.
        /// </summary>
        public void OnEdit_NetworkEmulation_None()
        {
            Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_None");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_None

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> Broadband.
        /// </summary>
        public void OnEdit_NetworkEmulation_Broadband()
        {
            Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_Broadband");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_Broadband

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> DSL.
        /// </summary>
        public void OnEdit_NetworkEmulation_DSL()
        {
            Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DSL");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_DSL

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> ISDN.
        /// </summary>
        public void OnEdit_NetworkEmulation_ISDN()
        {
            Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_ISDN");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_ISDN

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Network Emulation -> Dial-Up.
        /// </summary>
        public void OnEdit_NetworkEmulation_DialUp()
        {
            Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DialUp");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_NetworkEmulation_DialUp

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Edit -> Graphics Emulation
        /// <summary>
        /// Handler for Edit -> Graphics Emulation -> No Emulation.
        /// </summary>
        public void OnEdit_GraphicsEmulation_NoEmulation()
        {
            Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Graphics Emulation -> Shader Model 3.
        /// </summary>
        public void OnEdit_GraphicsEmulation_ShaderModel3()
        {
            Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel3");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_ReOnEdit_GraphicsEmulation_ShaderModel3do

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Edit -> Graphics Emulation -> Shader Model 2.
        /// </summary>
        public void OnEdit_GraphicsEmulation_ShaderModel2()
        {
            Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for Edit -> Snap Settings...
        /// </summary>
        public void OnEdit_SnapSettings()
        {
            Debug.Log("MainMenuScript.OnEdit_SnapSettings");
            // TODO: [Minor] Implement MainMenuScript.OnEdit_SnapSettings

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Assets
        /// <summary>
        /// Handler for Assets.
        /// </summary>
        public void OnAssetsMenu()
        {
            OnShowMenuSubItems(mUi.assetsMenu);
        }

        #region Assets -> Create
        /// <summary>
        /// Handler for Assets -> Create -> Folder.
        /// </summary>
        public void OnAssets_Create_Folder()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Folder");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Folder

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> C# Script.
        /// </summary>
        public void OnAssets_Create_CSharpScript()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_CSharpScript");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_CSharpScript

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Javascript.
        /// </summary>
        public void OnAssets_Create_Javascript()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Javascript");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Javascript

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Shader.
        /// </summary>
        public void OnAssets_Create_Shader()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Shader");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Shader

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Compute Shader.
        /// </summary>
        public void OnAssets_Create_ComputeShader()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_ComputeShader");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_ComputeShader

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Prefab.
        /// </summary>
        public void OnAssets_Create_Prefab()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Prefab");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Prefab

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Audio Mixer.
        /// </summary>
        public void OnAssets_Create_AudioMixer()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_AudioMixer");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AudioMixer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Material.
        /// </summary>
        public void OnAssets_Create_Material()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Material");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Material

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Lens Flare.
        /// </summary>
        public void OnAssets_Create_LensFlare()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_LensFlare");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_LensFlare

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Render Texture.
        /// </summary>
        public void OnAssets_Create_RenderTexture()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_RenderTexture");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_RenderTexture

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Lightmap Parameters.
        /// </summary>
        public void OnAssets_Create_LightmapParameters()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_LightmapParameters");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_LightmapParameters

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Animator Controller.
        /// </summary>
        public void OnAssets_Create_AnimatorController()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_AnimatorController");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AnimatorController

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Animation.
        /// </summary>
        public void OnAssets_Create_Animation()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Animation");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Animation

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Animator Override Contoller.
        /// </summary>
        public void OnAssets_Create_AnimatorOverrideContoller()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_AnimatorOverrideContoller");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AnimatorOverrideContoller

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Avatar Mask.
        /// </summary>
        public void OnAssets_Create_AvatarMask()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_AvatarMask");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_AvatarMask

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Physic Material.
        /// </summary>
        public void OnAssets_Create_PhysicMaterial()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_PhysicMaterial");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_PhysicMaterial

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Physic2D Material.
        /// </summary>
        public void OnAssets_Create_Physic2dMaterial()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Physic2dMaterial");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Physic2dMaterial

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> GUI Skin.
        /// </summary>
        public void OnAssets_Create_GuiSkin()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_GuiSkin");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_GuiSkin

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Custom Font.
        /// </summary>
        public void OnAssets_Create_CustomFont()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_CustomFont");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_CustomFont

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Create -> Shader Variant Collection.
        /// </summary>
        public void OnAssets_Create_ShaderVariantCollection()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_ShaderVariantCollection");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_ShaderVariantCollection

            AppCommonUtils.ShowContributeMessage();
        }

        #region Assets -> Create -> Legacy
        /// <summary>
        /// Handler for Assets -> Create -> Legacy -> Cubemap.
        /// </summary>
        public void OnAssets_Create_Legacy_Cubemap()
        {
            Debug.Log("MainMenuScript.OnAssets_Create_Legacy_Cubemap");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Create_Legacy_Cubemap

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #endregion

        /// <summary>
        /// Handler for Assets -> Show In Explorer.
        /// </summary>
        public void OnAssets_ShowInExplorer()
        {
            Debug.Log("MainMenuScript.OnAssets_ShowInExplorer");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ShowInExplorer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Open.
        /// </summary>
        public void OnAssets_Open()
        {
            Debug.Log("MainMenuScript.OnAssets_Open");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Open

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Delete.
        /// </summary>
        public void OnAssets_Delete()
        {
            Debug.Log("MainMenuScript.OnAssets_Delete");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Delete

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import New Asset...
        /// </summary>
        public void OnAssets_ImportNewAsset()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportNewAsset");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportNewAsset

            AppCommonUtils.ShowContributeMessage();
        }

        #region Assets -> Import Package
        /// <summary>
        /// Handler for Assets -> Import Package -> Custom Package...
        /// </summary>
        public void OnAssets_ImportPackage_CustomPackage()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_CustomPackage");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_CustomPackage

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> 2D.
        /// </summary>
        public void OnAssets_ImportPackage_2d()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_2d");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Cameras.
        /// </summary>
        public void OnAssets_ImportPackage_Cameras()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Cameras");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Cameras

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Characters.
        /// </summary>
        public void OnAssets_ImportPackage_Characters()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Characters");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Characters

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> CrossPlatformInput.
        /// </summary>
        public void OnAssets_ImportPackage_CrossPlatformInput()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Effects.
        /// </summary>
        public void OnAssets_ImportPackage_Effects()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Effects");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Effects

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Environment.
        /// </summary>
        public void OnAssets_ImportPackage_Environment()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Environment");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Environment

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> ParticleSystems.
        /// </summary>
        public void OnAssets_ImportPackage_ParticleSystems()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_ParticleSystems");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_ParticleSystems

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Prototyping.
        /// </summary>
        public void OnAssets_ImportPackage_Prototyping()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Prototyping");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Prototyping

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Utility.
        /// </summary>
        public void OnAssets_ImportPackage_Utility()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Utility");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Utility

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Import Package -> Vehicles.
        /// </summary>
        public void OnAssets_ImportPackage_Vehicles()
        {
            Debug.Log("MainMenuScript.OnAssets_ImportPackage_Vehicles");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ImportPackage_Vehicles

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for Assets -> Export Package...
        /// </summary>
        public void OnAssets_ExportPackage()
        {
            Debug.Log("MainMenuScript.OnAssets_ExportPackage");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ExportPackage

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Find References In Scene.
        /// </summary>
        public void OnAssets_FindReferencesInScene()
        {
            Debug.Log("MainMenuScript.OnAssets_FindReferencesInScene");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_FindReferencesInScene

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Select Dependencies.
        /// </summary>
        public void OnAssets_SelectDependencies()
        {
            Debug.Log("MainMenuScript.OnAssets_SelectDependencies");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_SelectDependencies

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Refresh.
        /// </summary>
        public void OnAssets_Refresh()
        {
            Debug.Log("MainMenuScript.OnAssets_Refresh");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Refresh

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Reimport.
        /// </summary>
        public void OnAssets_Reimport()
        {
            Debug.Log("MainMenuScript.OnAssets_Reimport");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_Reimport

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Reimport All.
        /// </summary>
        public void OnAssets_ReimportAll()
        {
            Debug.Log("MainMenuScript.OnAssets_ReimportAll");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_ReimportAll

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Run API Updater...
        /// </summary>
        public void OnAssets_RunApiUpdater()
        {
            Debug.Log("MainMenuScript.OnAssets_RunApiUpdater");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_RunApiUpdater

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Assets -> Sync MonoDevelop Project.
        /// </summary>
        public void OnAssets_SyncMonoDevelopProject()
        {
            Debug.Log("MainMenuScript.OnAssets_SyncMonoDevelopProject");
            // TODO: [Minor] Implement MainMenuScript.OnAssets_SyncMonoDevelopProject

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject
        /// <summary>
        /// Handler for GameObject.
        /// </summary>
        public void OnGameObjectMenu()
        {
            OnShowMenuSubItems(mUi.gameObjectMenu);
        }

        /// <summary>
        /// Handler for GameObject -> Create Empty.
        /// </summary>
        public void OnGameObject_CreateEmpty()
        {
            Debug.Log("MainMenuScript.OnGameObject_CreateEmpty");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_CreateEmpty

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Create Empty Child.
        /// </summary>
        public void OnGameObject_CreateEmptyChild()
        {
            Debug.Log("MainMenuScript.OnGameObject_CreateEmptyChild");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_CreateEmptyChild

            AppCommonUtils.ShowContributeMessage();
        }

        #region GameObject -> 3D Object
        /// <summary>
        /// Handler for GameObject -> 3D Object -> Cube.
        /// </summary>
        public void OnGameObject_3dObject_Cube()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Cube");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Cube

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Sphere.
        /// </summary>
        public void OnGameObject_3dObject_Sphere()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Sphere");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Sphere

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Capsule.
        /// </summary>
        public void OnGameObject_3dObject_Capsule()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Capsule");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Capsule

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Cylinder.
        /// </summary>
        public void OnGameObject_3dObject_Cylinder()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Cylinder");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Cylinder

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Plane.
        /// </summary>
        public void OnGameObject_3dObject_Plane()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Plane");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Plane

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Quad.
        /// </summary>
        public void OnGameObject_3dObject_Quad()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Quad");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Quad

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Ragdoll...
        /// </summary>
        public void OnGameObject_3dObject_Ragdoll()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Ragdoll");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Ragdoll

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Terrain.
        /// </summary>
        public void OnGameObject_3dObject_Terrain()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Terrain");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Terrain

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Tree.
        /// </summary>
        public void OnGameObject_3dObject_Tree()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_Tree");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_Tree

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> Wind Zone.
        /// </summary>
        public void OnGameObject_3dObject_WindZone()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_WindZone");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_WindZone

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> 3D Object -> 3D Text.
        /// </summary>
        public void OnGameObject_3dObject_3dText()
        {
            Debug.Log("MainMenuScript.OnGameObject_3dObject_3dText");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_3dObject_3dText

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> 2D Object
        /// <summary>
        /// Handler for GameObject -> 2D Object -> Sprite.
        /// </summary>
        public void OnGameObject_2dObject_Sprite()
        {
            Debug.Log("MainMenuScript.OnGameObject_2dObject_Sprite");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_2dObject_Sprite

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> Light
        /// <summary>
        /// Handler for GameObject -> Light -> Directional Light.
        /// </summary>
        public void OnGameObject_Light_DirectionalLight()
        {
            Debug.Log("MainMenuScript.OnGameObject_Light_DirectionalLight");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_DirectionalLight

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Point Light.
        /// </summary>
        public void OnGameObject_Light_PointLight()
        {
            Debug.Log("MainMenuScript.OnGameObject_Light_PointLight");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_PointLight

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Spotlight.
        /// </summary>
        public void OnGameObject_Light_Spotlight()
        {
            Debug.Log("MainMenuScript.OnGameObject_Light_Spotlight");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_Spotlight

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Area Light.
        /// </summary>
        public void OnGameObject_Light_AreaLight()
        {
            Debug.Log("MainMenuScript.OnGameObject_Light_AreaLight");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_AreaLight

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Reflection Probe.
        /// </summary>
        public void OnGameObject_Light_ReflectionProbe()
        {
            Debug.Log("MainMenuScript.OnGameObject_Light_ReflectionProbe");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_ReflectionProbe

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Light -> Light Probe Group.
        /// </summary>
        public void OnGameObject_Light_LightProbeGroup()
        {
            Debug.Log("MainMenuScript.OnGameObject_Light_LightProbeGroup");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Light_LightProbeGroup

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> Audio
        /// <summary>
        /// Handler for GameObject -> Audio -> Audio Source.
        /// </summary>
        public void OnGameObject_Audio_AudioSource()
        {
            Debug.Log("MainMenuScript.OnGameObject_Audio_AudioSource");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Audio_AudioSource

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Audio -> Audio Reverb Zone.
        /// </summary>
        public void OnGameObject_Audio_AudioReverbZone()
        {
            Debug.Log("MainMenuScript.OnGameObject_Audio_AudioReverbZone");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Audio_AudioReverbZone

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region GameObject -> UI
        /// <summary>
        /// Handler for GameObject -> UI -> Panel.
        /// </summary>
        public void OnGameObject_Ui_Panel()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Panel");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Panel

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Button.
        /// </summary>
        public void OnGameObject_Ui_Button()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Button");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Button

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Text.
        /// </summary>
        public void OnGameObject_Ui_Text()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Text");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Text

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Image.
        /// </summary>
        public void OnGameObject_Ui_Image()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Image");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Image

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Raw Image.
        /// </summary>
        public void OnGameObject_Ui_RawImage()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_RawImage");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_RawImage

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Slider.
        /// </summary>
        public void OnGameObject_Ui_Slider()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Slider");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Slider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Scrollbar.
        /// </summary>
        public void OnGameObject_Ui_Scrollbar()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Scrollbar");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Scrollbar

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Toggle.
        /// </summary>
        public void OnGameObject_Ui_Toggle()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Toggle");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Toggle

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Input Field.
        /// </summary>
        public void OnGameObject_Ui_InputField()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_InputField");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_InputField

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Canvas.
        /// </summary>
        public void OnGameObject_Ui_Canvas()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_Canvas");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_Canvas

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> UI -> Event System.
        /// </summary>
        public void OnGameObject_Ui_EventSystem()
        {
            Debug.Log("MainMenuScript.OnGameObject_Ui_EventSystem");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Ui_EventSystem

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for GameObject -> Particle System.
        /// </summary>
        public void OnGameObject_ParticleSystem()
        {
            Debug.Log("MainMenuScript.OnGameObject_ParticleSystem");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ParticleSystem

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Camera.
        /// </summary>
        public void OnGameObject_Camera()
        {
            Debug.Log("MainMenuScript.OnGameObject_Camera");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_Camera

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Center On Children.
        /// </summary>
        public void OnGameObject_CenterOnChildren()
        {
            Debug.Log("MainMenuScript.OnGameObject_CenterOnChildren");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_CenterOnChildren

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Make Parent.
        /// </summary>
        public void OnGameObject_MakeParent()
        {
            Debug.Log("MainMenuScript.OnGameObject_MakeParent");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_MakeParent

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Clear Parent.
        /// </summary>
        public void OnGameObject_ClearParent()
        {
            Debug.Log("MainMenuScript.OnGameObject_ClearParent");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ClearParent

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Apply Changes To Prefab.
        /// </summary>
        public void OnGameObject_ApplyChangesToPrefab()
        {
            Debug.Log("MainMenuScript.OnGameObject_ApplyChangesToPrefab");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ApplyChangesToPrefab

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Break Prefab Instance.
        /// </summary>
        public void OnGameObject_BreakPrefabInstance()
        {
            Debug.Log("MainMenuScript.OnGameObject_BreakPrefabInstance");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_BreakPrefabInstance

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Set as first sibling.
        /// </summary>
        public void OnGameObject_SetAsFirstSibling()
        {
            Debug.Log("MainMenuScript.OnGameObject_SetAsFirstSibling");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_SetAsFirstSibling

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Set as last sibling.
        /// </summary>
        public void OnGameObject_SetAsLastSibling()
        {
            Debug.Log("MainMenuScript.OnGameObject_SetAsLastSibling");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_SetAsLastSibling

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Move To View.
        /// </summary>
        public void OnGameObject_MoveToView()
        {
            Debug.Log("MainMenuScript.OnGameObject_MoveToView");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_MoveToView

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Align With View.
        /// </summary>
        public void OnGameObject_AlignWithView()
        {
            Debug.Log("MainMenuScript.OnGameObject_AlignWithView");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_AlignWithView

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Align View to Selected.
        /// </summary>
        public void OnGameObject_AlignViewToSelected()
        {
            Debug.Log("MainMenuScript.OnGameObject_AlignViewToSelected");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_AlignViewToSelected

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for GameObject -> Toggle Active State.
        /// </summary>
        public void OnGameObject_ToggleActiveState()
        {
            Debug.Log("MainMenuScript.OnGameObject_ToggleActiveState");
            // TODO: [Minor] Implement MainMenuScript.OnGameObject_ToggleActiveState

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component
        /// <summary>
        /// Handler for Component.
        /// </summary>
        public void OnComponentMenu()
        {
            OnShowMenuSubItems(mUi.componentMenu);
        }

        /// <summary>
        /// Handler for Component -> Add...
        /// </summary>
        public void OnComponent_Add()
        {
            Debug.Log("MainMenuScript.OnComponent_Add");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Add

            AppCommonUtils.ShowContributeMessage();
        }

        #region Component -> Mesh
        /// <summary>
        /// Handler for Component -> Mesh -> Mesh Filter.
        /// </summary>
        public void OnComponent_Mesh_MeshFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Mesh_MeshFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_MeshFilter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Mesh -> Text Mesh.
        /// </summary>
        public void OnComponent_Mesh_TextMesh()
        {
            Debug.Log("MainMenuScript.OnComponent_Mesh_TextMesh");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_TextMesh

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Mesh -> Mesh Renderer.
        /// </summary>
        public void OnComponent_Mesh_MeshRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Mesh_MeshRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_MeshRenderer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Mesh -> Skinned Mesh Renderer.
        /// </summary>
        public void OnComponent_Mesh_SkinnedMeshRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Effects
        /// <summary>
        /// Handler for Component -> Effects -> Particle System.
        /// </summary>
        public void OnComponent_Effects_ParticleSystem()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_ParticleSystem");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_ParticleSystem

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Trail Renderer.
        /// </summary>
        public void OnComponent_Effects_TrailRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_TrailRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_TrailRenderer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Line Renderer.
        /// </summary>
        public void OnComponent_Effects_LineRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LineRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LineRenderer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Lens Flare.
        /// </summary>
        public void OnComponent_Effects_LensFlare()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LensFlare");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LensFlare

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Halo.
        /// </summary>
        public void OnComponent_Effects_Halo()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_Halo");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_Halo

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Projector.
        /// </summary>
        public void OnComponent_Effects_Projector()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_Projector");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_Projector

            AppCommonUtils.ShowContributeMessage();
        }

        #region Component -> Effects -> Legacy Particles
        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Ellipsoid Particle Emitter.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Mesh Particle Emitter.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_MeshParticleEmitter()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Particle Animator.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_ParticleAnimator()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> World Particle Collider.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_WorldParticleCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Effects -> Legacy Particles -> Particle Renderer.
        /// </summary>
        public void OnComponent_Effects_LegacyParticles_ParticleRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #endregion

        #region Component -> Physics
        /// <summary>
        /// Handler for Component -> Physics -> Rigidbody.
        /// </summary>
        public void OnComponent_Physics_Rigidbody()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_Rigidbody");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_Rigidbody

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Character Controller.
        /// </summary>
        public void OnComponent_Physics_CharacterController()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_CharacterController");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_CharacterController

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Box Collider.
        /// </summary>
        public void OnComponent_Physics_BoxCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_BoxCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_BoxCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Sphere Collider.
        /// </summary>
        public void OnComponent_Physics_SphereCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_SphereCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_SphereCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Capsule Collider.
        /// </summary>
        public void OnComponent_Physics_CapsuleCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_CapsuleCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_CapsuleCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Mesh Collider.
        /// </summary>
        public void OnComponent_Physics_MeshCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_MeshCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_MeshCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Wheel Collider.
        /// </summary>
        public void OnComponent_Physics_WheelCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_WheelCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_WheelCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Terrain Collider.
        /// </summary>
        public void OnComponent_Physics_TerrainCollider()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_TerrainCollider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_TerrainCollider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Cloth.
        /// </summary>
        public void OnComponent_Physics_Cloth()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_Cloth");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_Cloth

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Hinge Joint.
        /// </summary>
        public void OnComponent_Physics_HingeJoint()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_HingeJoint");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_HingeJoint

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Fixed Joint.
        /// </summary>
        public void OnComponent_Physics_FixedJoint()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_FixedJoint");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_FixedJoint

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Spring Joint.
        /// </summary>
        public void OnComponent_Physics_SpringJoint()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_SpringJoint");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_SpringJoint

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Character Joint.
        /// </summary>
        public void OnComponent_Physics_CharacterJoint()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_CharacterJoint");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_CharacterJoint

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Configurable Joint.
        /// </summary>
        public void OnComponent_Physics_ConfigurableJoint()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_ConfigurableJoint");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_ConfigurableJoint

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics -> Constant Force.
        /// </summary>
        public void OnComponent_Physics_ConstantForce()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics_ConstantForce");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics_ConstantForce

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Physics 2D
        /// <summary>
        /// Handler for Component -> Physics 2D -> Rigidbody 2D.
        /// </summary>
        public void OnComponent_Physics2d_Rigidbody2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_Rigidbody2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_Rigidbody2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Circle Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_CircleCollider2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_CircleCollider2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_CircleCollider2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Box Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_BoxCollider2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_BoxCollider2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_BoxCollider2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Edge Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_EdgeCollider2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_EdgeCollider2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_EdgeCollider2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Polygon Collider 2D.
        /// </summary>
        public void OnComponent_Physics2d_PolygonCollider2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_PolygonCollider2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_PolygonCollider2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Spring Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_SpringJoint2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_SpringJoint2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_SpringJoint2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Distance Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_DistanceJoint2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_DistanceJoint2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_DistanceJoint2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Hinge Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_HingeJoint2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_HingeJoint2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_HingeJoint2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Slider Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_SliderJoint2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_SliderJoint2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_SliderJoint2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Wheel Joint 2D.
        /// </summary>
        public void OnComponent_Physics2d_WheelJoint2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_WheelJoint2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_WheelJoint2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Constant Force 2D.
        /// </summary>
        public void OnComponent_Physics2d_ConstantForce2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_ConstantForce2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_ConstantForce2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Area Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_AreaEffector2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_AreaEffector2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_AreaEffector2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Point Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_PointEffector2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_PointEffector2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_PointEffector2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Platform Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_PlatformEffector2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_PlatformEffector2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_PlatformEffector2d

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Physics 2D -> Surface Effector 2D.
        /// </summary>
        public void OnComponent_Physics2d_SurfaceEffector2d()
        {
            Debug.Log("MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Navigation
        /// <summary>
        /// Handler for Component -> Navigation -> Nav Mesh Agent.
        /// </summary>
        public void OnComponent_Navigation_NavMeshAgent()
        {
            Debug.Log("MainMenuScript.OnComponent_Navigation_NavMeshAgent");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Navigation_NavMeshAgent

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Navigation -> Off Mesh Link.
        /// </summary>
        public void OnComponent_Navigation_OffMeshLink()
        {
            Debug.Log("MainMenuScript.OnComponent_Navigation_OffMeshLink");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Navigation_OffMeshLink

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Navigation -> Nav Mesh Obstacle.
        /// </summary>
        public void OnComponent_Navigation_NavMeshObstacle()
        {
            Debug.Log("MainMenuScript.OnComponent_Navigation_NavMeshObstacle");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Navigation_NavMeshObstacle

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Audio
        /// <summary>
        /// Handler for Component -> Audio -> Audio Listener.
        /// </summary>
        public void OnComponent_Audio_AudioListener()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioListener");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioListener

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Source.
        /// </summary>
        public void OnComponent_Audio_AudioSource()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioSource");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioSource

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Reverb Zone.
        /// </summary>
        public void OnComponent_Audio_AudioReverbZone()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioReverbZone");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioReverbZone

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Low Pass Filter.
        /// </summary>
        public void OnComponent_Audio_AudioLowPassFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioLowPassFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioLowPassFilter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio High Pass Filter.
        /// </summary>
        public void OnComponent_Audio_AudioHighPassFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioHighPassFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioHighPassFilter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Echo Filter.
        /// </summary>
        public void OnComponent_Audio_AudioEchoFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioEchoFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioEchoFilter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Distortion Filter.
        /// </summary>
        public void OnComponent_Audio_AudioDistortionFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioDistortionFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioDistortionFilter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Reverb Filter.
        /// </summary>
        public void OnComponent_Audio_AudioReverbFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioReverbFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioReverbFilter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Audio -> Audio Chorus Filter.
        /// </summary>
        public void OnComponent_Audio_AudioChorusFilter()
        {
            Debug.Log("MainMenuScript.OnComponent_Audio_AudioChorusFilter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Audio_AudioChorusFilter

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Rendering
        /// <summary>
        /// Handler for Component -> Rendering -> Camera.
        /// </summary>
        public void OnComponent_Rendering_Camera()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_Camera");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_Camera

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Skybox.
        /// </summary>
        public void OnComponent_Rendering_Skybox()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_Skybox");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_Skybox

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Flare Layer.
        /// </summary>
        public void OnComponent_Rendering_FlareLayer()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_FlareLayer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_FlareLayer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> GUI Layer.
        /// </summary>
        public void OnComponent_Rendering_GuiLayer()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_GuiLayer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_GuiLayer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Light.
        /// </summary>
        public void OnComponent_Rendering_Light()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_Light");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_Light

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Light Probe Group.
        /// </summary>
        public void OnComponent_Rendering_LightProbeGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_LightProbeGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_LightProbeGroup

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Reflection Probe.
        /// </summary>
        public void OnComponent_Rendering_ReflectionProbe()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_ReflectionProbe");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_ReflectionProbe

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Occlusion Area.
        /// </summary>
        public void OnComponent_Rendering_OcclusionArea()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_OcclusionArea");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_OcclusionArea

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Occlusion Portal.
        /// </summary>
        public void OnComponent_Rendering_OcclusionPortal()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_OcclusionPortal");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_OcclusionPortal

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> LOD Group.
        /// </summary>
        public void OnComponent_Rendering_LodGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_LodGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_LodGroup

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Sprite Renderer.
        /// </summary>
        public void OnComponent_Rendering_SpriteRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_SpriteRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_SpriteRenderer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> Canvas Renderer.
        /// </summary>
        public void OnComponent_Rendering_CanvasRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_CanvasRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_CanvasRenderer

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> GUI Texture.
        /// </summary>
        public void OnComponent_Rendering_GuiTexture()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_GuiTexture");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_GuiTexture

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Rendering -> GUI Text.
        /// </summary>
        public void OnComponent_Rendering_GuiText()
        {
            Debug.Log("MainMenuScript.OnComponent_Rendering_GuiText");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Rendering_GuiText

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Layout
        /// <summary>
        /// Handler for Component -> Layout -> Rect Transform.
        /// </summary>
        public void OnComponent_Layout_RectTransform()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_RectTransform");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_RectTransform

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Canvas.
        /// </summary>
        public void OnComponent_Layout_Canvas()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_Canvas");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_Canvas

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Canvas Group.
        /// </summary>
        public void OnComponent_Layout_CanvasGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_CanvasGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_CanvasGroup

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Canvas Scaler.
        /// </summary>
        public void OnComponent_Layout_CanvasScaler()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_CanvasScaler");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_CanvasScaler

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Layout Element.
        /// </summary>
        public void OnComponent_Layout_LayoutElement()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_LayoutElement");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_LayoutElement

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Content Size Fitter.
        /// </summary>
        public void OnComponent_Layout_ContentSizeFitter()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_ContentSizeFitter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_ContentSizeFitter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Aspect Ratio Fitter.
        /// </summary>
        public void OnComponent_Layout_AspectRatioFitter()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_AspectRatioFitter");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_AspectRatioFitter

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Horizontal Layout Group.
        /// </summary>
        public void OnComponent_Layout_HorizontalLayoutGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Vertical Layout Group.
        /// </summary>
        public void OnComponent_Layout_VerticalLayoutGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_VerticalLayoutGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_VerticalLayoutGroup

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Layout -> Grid Layout Group.
        /// </summary>
        public void OnComponent_Layout_GridLayoutGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Layout_GridLayoutGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Layout_GridLayoutGroup

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Miscellaneous
        /// <summary>
        /// Handler for Component -> Miscellaneous -> Animator.
        /// </summary>
        public void OnComponent_Miscellaneous_Animator()
        {
            Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Animator");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_Animator

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Animation.
        /// </summary>
        public void OnComponent_Miscellaneous_Animation()
        {
            Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Animation");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_Animation

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Network View.
        /// </summary>
        public void OnComponent_Miscellaneous_NetworkView()
        {
            Debug.Log("MainMenuScript.OnComponent_Miscellaneous_NetworkView");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_NetworkView

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Wind Zone.
        /// </summary>
        public void OnComponent_Miscellaneous_WindZone()
        {
            Debug.Log("MainMenuScript.OnComponent_Miscellaneous_WindZone");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_WindZone

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Terrain.
        /// </summary>
        public void OnComponent_Miscellaneous_Terrain()
        {
            Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Terrain");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_Terrain

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Billboard Renderer.
        /// </summary>
        public void OnComponent_Miscellaneous_BillboardRenderer()
        {
            Debug.Log("MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> Event
        /// <summary>
        /// Handler for Component -> Miscellaneous -> Event System.
        /// </summary>
        public void OnComponent_Event_EventSystem()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_EventSystem");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_EventSystem

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Event Trigger.
        /// </summary>
        public void OnComponent_Event_EventTrigger()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_EventTrigger");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_EventTrigger

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Physics 2D Raycaster.
        /// </summary>
        public void OnComponent_Event_Physics2dRaycaster()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_Physics2dRaycaster");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_Physics2dRaycaster

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Physics Raycaster.
        /// </summary>
        public void OnComponent_Event_PhysicsRaycaster()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_PhysicsRaycaster");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_PhysicsRaycaster

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Standalone Input Module.
        /// </summary>
        public void OnComponent_Event_StandaloneInputModule()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_StandaloneInputModule");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_StandaloneInputModule

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Touch Input Module.
        /// </summary>
        public void OnComponent_Event_TouchInputModule()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_TouchInputModule");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_TouchInputModule

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> Miscellaneous -> Graphic Raycaster.
        /// </summary>
        public void OnComponent_Event_GraphicRaycaster()
        {
            Debug.Log("MainMenuScript.OnComponent_Event_GraphicRaycaster");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Event_GraphicRaycaster

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #region Component -> UI

        #region Component -> UI -> Effects
        /// <summary>
        /// Handler for Component -> UI -> Effects -> Shadow.
        /// </summary>
        public void OnComponent_Ui_Effects_Shadow()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Effects_Shadow");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Effects_Shadow

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Effects -> Outline.
        /// </summary>
        public void OnComponent_Ui_Effects_Outline()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Effects_Outline");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Effects_Outline

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Effects -> Position As UV1.
        /// </summary>
        public void OnComponent_Ui_Effects_PositionAsUv1()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        /// <summary>
        /// Handler for Component -> UI -> Image.
        /// </summary>
        public void OnComponent_Ui_Image()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Image");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Image

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Text.
        /// </summary>
        public void OnComponent_Ui_Text()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Text");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Text

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Raw Image.
        /// </summary>
        public void OnComponent_Ui_RawImage()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_RawImage");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_RawImage

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Mask.
        /// </summary>
        public void OnComponent_Ui_Mask()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Mask");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Mask

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Button.
        /// </summary>
        public void OnComponent_Ui_Button()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Button");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Button

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Input Field.
        /// </summary>
        public void OnComponent_Ui_InputField()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_InputField");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_InputField

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Scrollbar.
        /// </summary>
        public void OnComponent_Ui_Scrollbar()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Scrollbar");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Scrollbar

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Scroll Rect.
        /// </summary>
        public void OnComponent_Ui_ScrollRect()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_ScrollRect");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_ScrollRect

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Slider.
        /// </summary>
        public void OnComponent_Ui_Slider()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Slider");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Slider

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Toggle.
        /// </summary>
        public void OnComponent_Ui_Toggle()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Toggle");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Toggle

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Toggle Group.
        /// </summary>
        public void OnComponent_Ui_ToggleGroup()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_ToggleGroup");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_ToggleGroup

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Component -> UI -> Selectable.
        /// </summary>
        public void OnComponent_Ui_Selectable()
        {
            Debug.Log("MainMenuScript.OnComponent_Ui_Selectable");
            // TODO: [Minor] Implement MainMenuScript.OnComponent_Ui_Selectable

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

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
        /// Handler for Window -> Layouts -> 2 by 3.
        /// </summary>
        public void OnWindow_Layouts_2_by_3()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_2_by_3");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_2_by_3

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> 4 Split.
        /// </summary>
        public void OnWindow_Layouts_4_split()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_4_split");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_4_split

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Default.
        /// </summary>
        public void OnWindow_Layouts_Default()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_Default");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Default

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Tall.
        /// </summary>
        public void OnWindow_Layouts_Tall()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_Tall");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Tall

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Wide.
        /// </summary>
        public void OnWindow_Layouts_Wide()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_Wide");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_Wide

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Save Layout.
        /// </summary>
        public void OnWindow_Layouts_SaveLayout()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_SaveLayout");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_SaveLayout

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Delete Layout.
        /// </summary>
        public void OnWindow_Layouts_DeleteLayout()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_DeleteLayout");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_DeleteLayout

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Layouts -> Revert Factory Settings.
        /// </summary>
        public void OnWindow_Layouts_RevertFactorySettings()
        {
            Debug.Log("MainMenuScript.OnWindow_Layouts_RevertFactorySettings");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Layouts_RevertFactorySettings

            AppCommonUtils.ShowContributeMessage();
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

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Set Window Size Small.
        /// </summary>
        public void OnWindow_Screenshot_SetWindowSizeSmall()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SetWindowSizeSmall

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View.
        /// </summary>
        public void OnWindow_Screenshot_SnapView()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapView");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapView

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View Toolbar.
        /// </summary>
        public void OnWindow_Screenshot_SnapViewToolbar()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapViewToolbar");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapViewToolbar

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap View Extended Right.
        /// </summary>
        public void OnWindow_Screenshot_SnapViewExtendedRight()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapViewExtendedRight");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapViewExtendedRight

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap Component.
        /// </summary>
        public void OnWindow_Screenshot_SnapComponent()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapComponent");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapComponent

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Snap Game View Content.
        /// </summary>
        public void OnWindow_Screenshot_SnapGameViewContent()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_SnapGameViewContent");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_SnapGameViewContent

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Window -> Screenshot -> Toggle DeveloperBuild.
        /// </summary>
        public void OnWindow_Screenshot_ToggleDeveloperBuild()
        {
            Debug.Log("MainMenuScript.OnWindow_Screenshot_ToggleDeveloperBuild");
            // TODO: [Minor] Implement MainMenuScript.OnWindow_Screenshot_ToggleDeveloperBuild

            AppCommonUtils.ShowContributeMessage();
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
        /// Handler for Window -> Scene.
        /// </summary>
        public void OnWindow_Scene()
        {
            Debug.Log("MainMenuScript.OnWindow_Scene");
            
            ShowDockWidget<SceneDockWidgetScript>(ref Global.sceneDockWidgetScript, "Scene");
        }

        /// <summary>
        /// Handler for Window -> Game.
        /// </summary>
        public void OnWindow_Game()
        {
            Debug.Log("MainMenuScript.OnWindow_Game");
            
			ShowDockWidget<GameDockWidgetScript>(ref Global.gameDockWidgetScript, "Game");
        }

        /// <summary>
        /// Handler for Window -> Inspector.
        /// </summary>
        public void OnWindow_Inspector()
        {
            Debug.Log("MainMenuScript.OnWindow_Inspector");
            
			ShowDockWidget<InspectorDockWidgetScript>(ref Global.inspectorDockWidgetScript, "Inspector");
        }

        /// <summary>
        /// Handler for Window -> Hierarchy.
        /// </summary>
        public void OnWindow_Hierarchy()
        {
            Debug.Log("MainMenuScript.OnWindow_Hierarchy");
            
			ShowDockWidget<HierarchyDockWidgetScript>(ref Global.hierarchyDockWidgetScript, "Hierarchy");
        }

        /// <summary>
        /// Handler for Window -> Project.
        /// </summary>
        public void OnWindow_Project()
        {
            Debug.Log("MainMenuScript.OnWindow_Project");

			ShowDockWidget<ProjectDockWidgetScript>(ref Global.projectDockWidgetScript, "Project");
        }

        /// <summary>
        /// Handler for Window -> Animation.
        /// </summary>
        public void OnWindow_Animation()
        {
            Debug.Log("MainMenuScript.OnWindow_Animation");

			ShowDockWidget<AnimationDockWidgetScript>(ref Global.animationDockWidgetScript, "Animation");
        }

        /// <summary>
        /// Handler for Window -> Profiler.
        /// </summary>
        public void OnWindow_Profiler()
        {
            Debug.Log("MainMenuScript.OnWindow_Profiler");

			ShowDockWidget<ProfilerDockWidgetScript>(ref Global.profilerDockWidgetScript, "Profiler");
        }

        /// <summary>
        /// Handler for Window -> Audio Mixer.
        /// </summary>
        public void OnWindow_AudioMixer()
        {
            Debug.Log("MainMenuScript.OnWindow_AudioMixer");

			ShowDockWidget<AudioMixerDockWidgetScript>(ref Global.audioMixerDockWidgetScript, "AudioMixer");
        }

        /// <summary>
        /// Handler for Window -> Asset Store.
        /// </summary>
        public void OnWindow_AssetStore()
        {
            Debug.Log("MainMenuScript.OnWindow_AssetStore");

			ShowDockWidget<AssetStoreDockWidgetScript>(ref Global.assetStoreDockWidgetScript, "AssetStore");
        }

        /// <summary>
        /// Handler for Window -> Version Control.
        /// </summary>
        public void OnWindow_VersionControl()
        {
            Debug.Log("MainMenuScript.OnWindow_VersionControl");

			ShowDockWidget<VersionControlDockWidgetScript>(ref Global.versionControlDockWidgetScript, "VersionControl");
        }

        /// <summary>
        /// Handler for Window -> Animator Parameter.
        /// </summary>
        public void OnWindow_AnimatorParameter()
        {
            Debug.Log("MainMenuScript.OnWindow_AnimatorParameter");

			ShowDockWidget<AnimatorParameterDockWidgetScript>(ref Global.animatorParameterDockWidgetScript, "AnimatorParameter");
        }

        /// <summary>
        /// Handler for Window -> Animator.
        /// </summary>
        public void OnWindow_Animator()
        {
            Debug.Log("MainMenuScript.OnWindow_Animator");

			ShowDockWidget<AnimatorDockWidgetScript>(ref Global.animatorDockWidgetScript, "Animator");
        }

        /// <summary>
        /// Handler for Window -> Sprite Packer.
        /// </summary>
        public void OnWindow_SpritePacker()
        {
            Debug.Log("MainMenuScript.OnWindow_SpritePacker");

			ShowDockWidget<SpritePackerDockWidgetScript>(ref Global.spritePackerDockWidgetScript, "SpritePacker");
        }

        /// <summary>
        /// Handler for Window -> Lighting.
        /// </summary>
        public void OnWindow_Lighting()
        {
            Debug.Log("MainMenuScript.OnWindow_Lighting");
            
			ShowDockWidget<LightingDockWidgetScript>(ref Global.lightingDockWidgetScript, "Lighting");
        }

        /// <summary>
        /// Handler for Window -> Occlusion Culling.
        /// </summary>
        public void OnWindow_OcclusionCulling()
        {
            Debug.Log("MainMenuScript.OnWindow_OcclusionCulling");

			ShowDockWidget<OcclusionCullingDockWidgetScript>(ref Global.occlusionCullingDockWidgetScript, "OcclusionCulling");
        }

        /// <summary>
        /// Handler for Window -> Frame Debugger.
        /// </summary>
        public void OnWindow_FrameDebugger()
        {
            Debug.Log("MainMenuScript.OnWindow_FrameDebugger");

			ShowDockWidget<FrameDebuggerDockWidgetScript>(ref Global.frameDebuggerDockWidgetScript, "FrameDebugger");
        }

        /// <summary>
        /// Handler for Window -> Navigation.
        /// </summary>
        public void OnWindow_Navigation()
        {
            Debug.Log("MainMenuScript.OnWindow_Navigation");

			ShowDockWidget<NavigationDockWidgetScript>(ref Global.navigationDockWidgetScript, "Navigation");
        }

        /// <summary>
        /// Handler for Window -> Console.
        /// </summary>
        public void OnWindow_Console()
        {
            Debug.Log("MainMenuScript.OnWindow_Console");

			ShowDockWidget<ConsoleDockWidgetScript>(ref Global.consoleDockWidgetScript, "Console");
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

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Manual.
        /// </summary>
        public void OnHelp_UnityManual()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityManual");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityManual

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Scripting Reference.
        /// </summary>
        public void OnHelp_ScriptingReference()
        {
            Debug.Log("MainMenuScript.OnHelp_ScriptingReference");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ScriptingReference

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Connect.
        /// </summary>
        public void OnHelp_UnityConnect()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityConnect");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityConnect

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Forum.
        /// </summary>
        public void OnHelp_UnityForum()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityForum");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityForum

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Answers.
        /// </summary>
        public void OnHelp_UnityAnswers()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityAnswers");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityAnswers

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Unity Feedback.
        /// </summary>
        public void OnHelp_UnityFeedback()
        {
            Debug.Log("MainMenuScript.OnHelp_UnityFeedback");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_UnityFeedback

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Check for Updates.
        /// </summary>
        public void OnHelp_CheckForUpdates()
        {
            Debug.Log("MainMenuScript.OnHelp_CheckForUpdates");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_CheckForUpdates

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Download Beta...
        /// </summary>
        public void OnHelp_DownloadBeta()
        {
            Debug.Log("MainMenuScript.OnHelp_DownloadBeta");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_DownloadBeta

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Release Notes.
        /// </summary>
        public void OnHelp_ReleaseNotes()
        {
            Debug.Log("MainMenuScript.OnHelp_ReleaseNotes");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ReleaseNotes

            AppCommonUtils.ShowContributeMessage();
        }

        /// <summary>
        /// Handler for Help -> Report a Bug...
        /// </summary>
        public void OnHelp_ReportABug()
        {
            Debug.Log("MainMenuScript.OnHelp_ReportABug");
            // TODO: [Minor] Implement MainMenuScript.OnHelp_ReportABug

            AppCommonUtils.ShowContributeMessage();
        }
        #endregion

        #endregion
    }
}
