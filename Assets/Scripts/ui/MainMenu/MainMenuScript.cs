using UnityEngine;
using UnityEngine.UI;

using common;
using common.ui;



/// <summary>
/// Script that realize main menu behaviour.
/// </summary>
public class MainMenuScript : MonoBehaviour
{
	/// <summary>
	/// Menu item button prefab.
	/// </summary>
    public Button menuButton = null;



	#region Menu items
	private TreeNode<MenuItem> mItems = null;

	#region File
	private TreeNode<MenuItem> mFileMenu               = null;

//	private TreeNode<MenuItem> mFile_NewSceneItem      = null;
//	private TreeNode<MenuItem> mFile_OpenSceneItem     = null;

//	private TreeNode<MenuItem> mFile_SaveSceneItem     = null;
//	private TreeNode<MenuItem> mFile_SaveSceneAsItem   = null;

//	private TreeNode<MenuItem> mFile_NewProjectItem    = null;
//	private TreeNode<MenuItem> mFile_OpenProjectItem   = null;
//	private TreeNode<MenuItem> mFile_SaveProjectItem   = null;

//	private TreeNode<MenuItem> mFile_BuildSettingsItem = null;
//	private TreeNode<MenuItem> mFile_BuildAndRunItem   = null;

//	private TreeNode<MenuItem> mFile_ExitItem          = null;
	#endregion

	#region Edit
	private TreeNode<MenuItem> mEditMenu                    = null;

//	private TreeNode<MenuItem> mEdit_UndoItem               = null;
//	private TreeNode<MenuItem> mEdit_RedoItem               = null;

//	private TreeNode<MenuItem> mEdit_CutItem                = null;
//	private TreeNode<MenuItem> mEdit_CopyItem               = null;
//	private TreeNode<MenuItem> mEdit_PasteItem              = null;

//	private TreeNode<MenuItem> mEdit_DuplicateItem          = null;
//	private TreeNode<MenuItem> mEdit_DeleteItem             = null;

//	private TreeNode<MenuItem> mEdit_FrameSelectedItem      = null;
//	private TreeNode<MenuItem> mEdit_LockViewToSelectedItem = null;
//	private TreeNode<MenuItem> mEdit_FindItem               = null;
//	private TreeNode<MenuItem> mEdit_SelectAllItem          = null;

//	private TreeNode<MenuItem> mEdit_PreferencesItem        = null;
//	private TreeNode<MenuItem> mEdit_ModulesItem            = null;

//	private TreeNode<MenuItem> mEdit_PlayItem               = null;
//	private TreeNode<MenuItem> mEdit_PauseItem              = null;
//	private TreeNode<MenuItem> mEdit_StepItem               = null;

	#region Edit->Selection
	private TreeNode<MenuItem> mEdit_SelectionItem                = null;

//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection1Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection2Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection3Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection4Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection5Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection6Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection7Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection8Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection9Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_LoadSelection0Item = null;

//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection1Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection2Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection3Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection4Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection5Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection6Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection7Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection8Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection9Item = null;
//	private TreeNode<MenuItem> mEdit_Selection_SaveSelection0Item = null;
	#endregion

	#region Edit->Project Settings
	private TreeNode<MenuItem> mEdit_ProjectSettingsItem                      = null;

//	private TreeNode<MenuItem> mEdit_ProjectSettings_InputItem                = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_TagsAndLayersItem        = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_AudioItem                = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_TimeItem                 = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_PlayerItem               = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_PhysicsItem              = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_Physics2DItem            = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_QualityItem              = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_GraphicsItem             = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_NetworkItem              = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_EditorItem               = null;
//	private TreeNode<MenuItem> mEdit_ProjectSettings_ScriptExecutionOrderItem = null;
	#endregion

//	private TreeNode<MenuItem> mEdit_RenderSettingsItem = null;

	#region Edit->Network Emulation
	private TreeNode<MenuItem> mEdit_NetworkEmulationItem                           = null;
	
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationNoneItem      = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationBroadbandItem = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationDSLItem       = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationISDNItem      = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationDialUpItem    = null;
	#endregion

	#region Edit->Graphics Emulation
	private TreeNode<MenuItem> mEdit_GraphicsEmulationItem                               = null;
	
//	private TreeNode<MenuItem> mEdit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  = null;
//	private TreeNode<MenuItem> mEdit_GraphicsEmulation_GraphicsEmulationShaderModel3Item = null;
//	private TreeNode<MenuItem> mEdit_GraphicsEmulation_GraphicsEmulationShaderModel2Item = null;
	#endregion

//	private TreeNode<MenuItem> mEdit_SnapSettingsItem = null;
	#endregion

	#region Assets
	private TreeNode<MenuItem> mAssetsMenu = null;

	#region Assets->Create
	private TreeNode<MenuItem> mAssets_CreateItem                           = null;
	
//	private TreeNode<MenuItem> mAssets_Create_FolderItem                    = null;

//	private TreeNode<MenuItem> mAssets_Create_JavascriptItem                = null;
//	private TreeNode<MenuItem> mAssets_Create_CShartScriptItem              = null;
//	private TreeNode<MenuItem> mAssets_Create_BooScriptItem                 = null;
//	private TreeNode<MenuItem> mAssets_Create_ShaderItem                    = null;
//	private TreeNode<MenuItem> mAssets_Create_ComputeShaderItem             = null;

//	private TreeNode<MenuItem> mAssets_Create_PrefabItem                    = null;

//	private TreeNode<MenuItem> mAssets_Create_MaterialItem                  = null;
//	private TreeNode<MenuItem> mAssets_Create_CubemapItem                   = null;
//	private TreeNode<MenuItem> mAssets_Create_LensFlareItem                 = null;

//	private TreeNode<MenuItem> mAssets_Create_AnimatorControllerItem        = null;
//	private TreeNode<MenuItem> mAssets_Create_AnimationItem                 = null;
//	private TreeNode<MenuItem> mAssets_Create_AnimatorOverrideContollerItem = null;
//	private TreeNode<MenuItem> mAssets_Create_AvatarMaskItem                = null;

//	private TreeNode<MenuItem> mAssets_Create_PhysicMaterialItem            = null;
//	private TreeNode<MenuItem> mAssets_Create_Physic2dMaterialItem          = null;

//	private TreeNode<MenuItem> mAssets_Create_GuiSkinItem                   = null;
//	private TreeNode<MenuItem> mAssets_Create_CustomFontItem                = null;
	#endregion

//	private TreeNode<MenuItem> mAssets_ShowInExplorerItem = null;
//	private TreeNode<MenuItem> mAssets_OpenItem           = null;
//	private TreeNode<MenuItem> mAssets_DeleteItem         = null;

//	private TreeNode<MenuItem> mAssets_ImportNewAssetItem = null;

	#region Assets->Import Package
	private TreeNode<MenuItem> mAssets_ImportPackageItem                         = null;
	
//	private TreeNode<MenuItem> mAssets_ImportPackage_CustomPackageItem           = null;

//	private TreeNode<MenuItem> mAssets_ImportPackage_CharacterControllerItem     = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_GlassRefractionProOnlytem   = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_ImageEffectsProOnlyItem     = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_LightCookiesItem            = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_LightFlaresItem             = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_ParticlesItem               = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_PhysicMaterialsItem         = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_ProjectorsItem              = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_ScriptsItem                 = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_SkyboxesItem                = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_StandardAssetsMobileItem    = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_TerrainAssetsItem           = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_TessellationShadersDx11Item = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_ToonShadingItem             = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_TreeCreatorItem             = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_WaterBasicItem              = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_WaterProOnlyItem            = null;
	#endregion

//	private TreeNode<MenuItem> mAssets_ExportPackageItem          = null;
//	private TreeNode<MenuItem> mAssets_FindReferencesInSceneItem  = null;
//	private TreeNode<MenuItem> mAssets_SelectDependenciestem      = null;

//	private TreeNode<MenuItem> mAssets_RefreshItem                = null;
//	private TreeNode<MenuItem> mAssets_ReimportItem               = null;

//	private TreeNode<MenuItem> mAssets_ReimportAllItem            = null;

//	private TreeNode<MenuItem> mAssets_SyncMonoDevelopProjectItem = null;

	#endregion

	#region GameObject
	private TreeNode<MenuItem> mGameObjectMenu = null;
	#endregion

	#region Component
	private TreeNode<MenuItem> mComponentMenu = null;
	#endregion

	#region Window
	private TreeNode<MenuItem> mWindowMenu = null;
	#endregion

	#region Help
	private TreeNode<MenuItem> mHelpMenu = null;
	#endregion

	#endregion

	private PopupMenu mPopupMenu = null;



	/// <summary>
	/// Script starting callback.
	/// </summary>
	void Start()
	{
        CreateMenuItems();
		CreateUI();
	}

	/// <summary>
	/// Creates menu items.
	/// </summary>
    private void CreateMenuItems()
    {
		// Root
        mItems = new TreeNode<MenuItem>(new MenuItem());

        #region File
        mFileMenu                 =   MenuItem.Create(mItems,    "File",              OnFileMenu);
        
		/*mFile_NewSceneItem      =*/ MenuItem.Create(mFileMenu, "New Scene",         OnFile_NewScene);
		/*mFile_OpenSceneItem     =*/ MenuItem.Create(mFileMenu, "Open Scene",        OnFile_OpenScene);
        MenuItem.InsertSeparator(mFileMenu);
		/*mFile_SaveSceneItem     =*/ MenuItem.Create(mFileMenu, "Save Scene",        OnFile_SaveScene);
		/*mFile_SaveSceneAsItem   =*/ MenuItem.Create(mFileMenu, "Save Scene as...",  OnFile_SaveSceneAs);
        MenuItem.InsertSeparator(mFileMenu);
		/*mFile_NewProjectItem    =*/ MenuItem.Create(mFileMenu, "New Project...",    OnFile_NewProject);
		/*mFile_OpenProjectItem   =*/ MenuItem.Create(mFileMenu, "Open Project...",   OnFile_OpenProject);
		/*mFile_SaveProjectItem   =*/ MenuItem.Create(mFileMenu, "Save Project",      OnFile_SaveProject);
        MenuItem.InsertSeparator(mFileMenu);
		/*mFile_BuildSettingsItem =*/ MenuItem.Create(mFileMenu, "Build Settings...", OnFile_BuildSettings);
		/*mFile_BuildAndRunItem   =*/ MenuItem.Create(mFileMenu, "Build & Run",       OnFile_BuildAndRun);
        MenuItem.InsertSeparator(mFileMenu);
		/*mFile_ExitItem          =*/ MenuItem.Create(mFileMenu, "Exit",              OnFile_Exit);
        #endregion

		#region Edit
		mEditMenu                      =   MenuItem.Create(mItems,    "Edit",                  OnEditMenu);

		/*mEdit_UndoItem               =*/ MenuItem.Create(mEditMenu, "Undo",                  OnEdit_Undo); // TODO: Change name of menu item after changes
		/*mEdit_RedoItem               =*/ MenuItem.Create(mEditMenu, "Redo",                  OnEdit_Redo); // TODO: Change name of menu item after changes
		MenuItem.InsertSeparator(mEditMenu);
		/*mEdit_CutItem                =*/ MenuItem.Create(mEditMenu, "Cut",                   OnEdit_Cut);
		/*mEdit_CopyItem               =*/ MenuItem.Create(mEditMenu, "Copy",                  OnEdit_Copy);
		/*mEdit_PasteItem              =*/ MenuItem.Create(mEditMenu, "Paste",                 OnEdit_Paste);
		MenuItem.InsertSeparator(mEditMenu);
		/*mEdit_DuplicateItem          =*/ MenuItem.Create(mEditMenu, "Duplicate",             OnEdit_Duplicate);
		/*mEdit_DeleteItem             =*/ MenuItem.Create(mEditMenu, "Delete",                OnEdit_Delete);
		MenuItem.InsertSeparator(mEditMenu);
		/*mEdit_FrameSelectedItem      =*/ MenuItem.Create(mEditMenu, "Frame Selected",        OnEdit_FrameSelected);
		/*mEdit_LockViewToSelectedItem =*/ MenuItem.Create(mEditMenu, "Lock View to Selected", OnEdit_LockViewToSelected);
		/*mEdit_FindItem               =*/ MenuItem.Create(mEditMenu, "Find",                  OnEdit_Find);
		/*mEdit_SelectAllItem          =*/ MenuItem.Create(mEditMenu, "Select All",            OnEdit_SelectAll);
		MenuItem.InsertSeparator(mEditMenu);
		/*mEdit_PreferencesItem        =*/ MenuItem.Create(mEditMenu, "Preferences...",        OnEdit_Preferences);
		/*mEdit_ModulesItem            =*/ MenuItem.Create(mEditMenu, "Modules...",            OnEdit_Modules);
		MenuItem.InsertSeparator(mEditMenu);
		/*mEdit_PlayItem               =*/ MenuItem.Create(mEditMenu, "Play",                  OnEdit_Play);
		/*mEdit_PauseItem              =*/ MenuItem.Create(mEditMenu, "Pause",                 OnEdit_Pause);
		/*mEdit_StepItem               =*/ MenuItem.Create(mEditMenu, "Step",                  OnEdit_Step);
		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Selection
		mEdit_SelectionItem                  =   MenuItem.Create(mEditMenu,           "Selection");
		
		/*mEdit_Selection_LoadSelection1Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 1", OnEdit_Selection_LoadSelection1);
		/*mEdit_Selection_LoadSelection2Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 2", OnEdit_Selection_LoadSelection2);
		/*mEdit_Selection_LoadSelection3Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 3", OnEdit_Selection_LoadSelection3);
		/*mEdit_Selection_LoadSelection4Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 4", OnEdit_Selection_LoadSelection4);
		/*mEdit_Selection_LoadSelection5Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 5", OnEdit_Selection_LoadSelection5);
		/*mEdit_Selection_LoadSelection6Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 6", OnEdit_Selection_LoadSelection6);
		/*mEdit_Selection_LoadSelection7Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 7", OnEdit_Selection_LoadSelection7);
		/*mEdit_Selection_LoadSelection8Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 8", OnEdit_Selection_LoadSelection8);
		/*mEdit_Selection_LoadSelection9Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 9", OnEdit_Selection_LoadSelection9);
		/*mEdit_Selection_LoadSelection0Item =*/ MenuItem.Create(mEdit_SelectionItem, "Load Selection 0", OnEdit_Selection_LoadSelection0);
		
		/*mEdit_Selection_SaveSelection1Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 1", OnEdit_Selection_SaveSelection1);
		/*mEdit_Selection_SaveSelection2Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 2", OnEdit_Selection_SaveSelection2);
		/*mEdit_Selection_SaveSelection3Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 3", OnEdit_Selection_SaveSelection3);
		/*mEdit_Selection_SaveSelection4Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 4", OnEdit_Selection_SaveSelection4);
		/*mEdit_Selection_SaveSelection5Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 5", OnEdit_Selection_SaveSelection5);
		/*mEdit_Selection_SaveSelection6Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 6", OnEdit_Selection_SaveSelection6);
		/*mEdit_Selection_SaveSelection7Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 7", OnEdit_Selection_SaveSelection7);
		/*mEdit_Selection_SaveSelection8Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 8", OnEdit_Selection_SaveSelection8);
		/*mEdit_Selection_SaveSelection9Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 9", OnEdit_Selection_SaveSelection9);
		/*mEdit_Selection_SaveSelection0Item =*/ MenuItem.Create(mEdit_SelectionItem, "Save Selection 0", OnEdit_Selection_SaveSelection0);
		#endregion

		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Project Settings
		mEdit_ProjectSettingsItem                        =   MenuItem.Create(mEditMenu,                 "Project Settings");
		
		/*mEdit_ProjectSettings_InputItem                =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Input",                  OnEdit_ProjectSettings_Input);
		/*mEdit_ProjectSettings_TagsAndLayersItem        =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Tags and Layers",        OnEdit_ProjectSettings_TagsAndLayers);
		/*mEdit_ProjectSettings_AudioItem                =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Audio",                  OnEdit_ProjectSettings_Audio);
		/*mEdit_ProjectSettings_TimeItem                 =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Time",                   OnEdit_ProjectSettings_Time);
		/*mEdit_ProjectSettings_PlayerItem               =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Player",                 OnEdit_ProjectSettings_Player);
		/*mEdit_ProjectSettings_PhysicsItem              =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Physics",                OnEdit_ProjectSettings_Physics);
		/*mEdit_ProjectSettings_Physics2DItem            =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Physics 2D",             OnEdit_ProjectSettings_Physics2D);
		/*mEdit_ProjectSettings_QualityItem              =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Quality",                OnEdit_ProjectSettings_Quality);
		/*mEdit_ProjectSettings_GraphicsItem             =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Graphics",               OnEdit_ProjectSettings_Graphics);
		/*mEdit_ProjectSettings_NetworkItem              =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Network",                OnEdit_ProjectSettings_Network);
		/*mEdit_ProjectSettings_EditorItem               =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Editor",                 OnEdit_ProjectSettings_Editor);
		/*mEdit_ProjectSettings_ScriptExecutionOrderItem =*/ MenuItem.Create(mEdit_ProjectSettingsItem, "Script Execution Order", OnEdit_ProjectSettings_ScriptExecutionOrder);
		#endregion
		
		/*mEdit_RenderSettingsItem =*/ MenuItem.Create(mEditMenu, "Render Settings", OnEdit_RenderSettings);
		MenuItem.InsertSeparator(mEditMenu);

		#region Edit->Network Emulation
		mEdit_NetworkEmulationItem                             =   MenuItem.Create(mEditMenu,                  "Network Emulation");
		
		/*mEdit_NetworkEmulation_NetworkEmulationNoneItem      =*/ MenuItem.Create(mEdit_NetworkEmulationItem, "None",      OnEdit_NetworkEmulation_None);
		/*mEdit_NetworkEmulation_NetworkEmulationBroadbandItem =*/ MenuItem.Create(mEdit_NetworkEmulationItem, "Broadband", OnEdit_NetworkEmulation_Broadband);
		/*mEdit_NetworkEmulation_NetworkEmulationDSLItem       =*/ MenuItem.Create(mEdit_NetworkEmulationItem, "DSL",       OnEdit_NetworkEmulation_DSL);
		/*mEdit_NetworkEmulation_NetworkEmulationISDNItem      =*/ MenuItem.Create(mEdit_NetworkEmulationItem, "ISDN",      OnEdit_NetworkEmulation_ISDN);
		/*mEdit_NetworkEmulation_NetworkEmulationDialUpItem    =*/ MenuItem.Create(mEdit_NetworkEmulationItem, "Dial-Up",   OnEdit_NetworkEmulation_DialUp);
		#endregion
		
		#region Edit->Graphics Emulation
		mEdit_GraphicsEmulationItem                                 =   MenuItem.Create(mEditMenu,                   "Graphics Emulation");
		
		/*mEdit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  =*/ MenuItem.Create(mEdit_GraphicsEmulationItem, "No Emulation",   OnEdit_GraphicsEmulation_NoEmulation);
		/*mEdit_GraphicsEmulation_GraphicsEmulationShaderModel3Item =*/ MenuItem.Create(mEdit_GraphicsEmulationItem, "Shader Model 3", OnEdit_GraphicsEmulation_ShaderModel3);
		/*mEdit_GraphicsEmulation_GraphicsEmulationShaderModel2Item =*/ MenuItem.Create(mEdit_GraphicsEmulationItem, "Shader Model 2", OnEdit_GraphicsEmulation_ShaderModel2);
		#endregion

		MenuItem.InsertSeparator(mEditMenu);
		/*mEdit_SnapSettingsItem =*/ MenuItem.Create(mEditMenu, "Snap Settings...", OnEdit_SnapSettings);
		#endregion

		#region Assets
		mAssetsMenu = MenuItem.Create(mItems, "Assets", OnAssetsMenu);

		#region Assets->Create
		mAssets_CreateItem                             =   MenuItem.Create(mAssetsMenu,        "Create");

		/*mAssets_Create_FolderItem                    =*/ MenuItem.Create(mAssets_CreateItem, "Folder",                      OnAssets_Create_Folder);
		MenuItem.InsertSeparator(mAssets_CreateItem);
		/*mAssets_Create_JavascriptItem                =*/ MenuItem.Create(mAssets_CreateItem, "Javascript",                  OnAssets_Create_Javascript);
		/*mAssets_Create_CShartScriptItem              =*/ MenuItem.Create(mAssets_CreateItem, "C# Script",                   OnAssets_Create_CShartScript);
		/*mAssets_Create_BooScriptItem                 =*/ MenuItem.Create(mAssets_CreateItem, "Boo Script",                  OnAssets_Create_BooScript);
		/*mAssets_Create_ShaderItem                    =*/ MenuItem.Create(mAssets_CreateItem, "Shader",                      OnAssets_Create_Shader);
		/*mAssets_Create_ComputeShaderItem             =*/ MenuItem.Create(mAssets_CreateItem, "Compute Shader",              OnAssets_Create_ComputeShader);
		MenuItem.InsertSeparator(mAssets_CreateItem);
		/*mAssets_Create_PrefabItem                    =*/ MenuItem.Create(mAssets_CreateItem, "Prefab",                      OnAssets_Create_Prefab);
		MenuItem.InsertSeparator(mAssets_CreateItem);
		/*mAssets_Create_MaterialItem                  =*/ MenuItem.Create(mAssets_CreateItem, "Material",                    OnAssets_Create_Material);
		/*mAssets_Create_CubemapItem                   =*/ MenuItem.Create(mAssets_CreateItem, "Cubemap",                     OnAssets_Create_Cubemap);
		/*mAssets_Create_LensFlareItem                 =*/ MenuItem.Create(mAssets_CreateItem, "Lens Flare",                  OnAssets_Create_LensFlare);
		MenuItem.InsertSeparator(mAssets_CreateItem);
		/*mAssets_Create_AnimatorControllerItem        =*/ MenuItem.Create(mAssets_CreateItem, "Animator Controller",         OnAssets_Create_AnimatorController);
		/*mAssets_Create_AnimationItem                 =*/ MenuItem.Create(mAssets_CreateItem, "Animation",                   OnAssets_Create_Animation);
		/*mAssets_Create_AnimatorOverrideContollerItem =*/ MenuItem.Create(mAssets_CreateItem, "Animator Override Contoller", OnAssets_Create_AnimatorOverrideContoller);
		/*mAssets_Create_AvatarMaskItem                =*/ MenuItem.Create(mAssets_CreateItem, "Avatar Mask",                 OnAssets_Create_AvatarMask);
		MenuItem.InsertSeparator(mAssets_CreateItem);
		/*mAssets_Create_PhysicMaterialItem            =*/ MenuItem.Create(mAssets_CreateItem, "Physic Material",             OnAssets_Create_PhysicMaterial);
		/*mAssets_Create_Physic2dMaterialItem          =*/ MenuItem.Create(mAssets_CreateItem, "Physic2D Material",           OnAssets_Create_Physic2dMaterial);
		MenuItem.InsertSeparator(mAssets_CreateItem);
		/*mAssets_Create_GuiSkinItem                   =*/ MenuItem.Create(mAssets_CreateItem, "GUI Skin",                    OnAssets_Create_GuiSkin);
		/*mAssets_Create_CustomFontItem                =*/ MenuItem.Create(mAssets_CreateItem, "Custom Font",                 OnAssets_Create_CustomFont);
		#endregion

		/*mAssets_ShowInExplorerItem =*/ MenuItem.Create(mAssetsMenu, "Show In Explorer",    OnAssets_ShowInExplorer);
		/*mAssets_OpenItem           =*/ MenuItem.Create(mAssetsMenu, "Open",                OnAssets_Open);
		/*mAssets_DeleteItem         =*/ MenuItem.Create(mAssetsMenu, "Delete",              OnAssets_Delete);
		MenuItem.InsertSeparator(mAssetsMenu);
		/*mAssets_ImportNewAssetItem =*/ MenuItem.Create(mAssetsMenu, "Import New Asset...", OnAssets_ImportNewAsset);

		#region Assets->Import Package
		mAssets_ImportPackageItem                           =   MenuItem.Create(mAssetsMenu,               "Import Package");

		/*mAssets_ImportPackage_CustomPackageItem           =*/ MenuItem.Create(mAssets_ImportPackageItem, "Custom Package...",           OnAssets_ImportPackage_CustomPackage);
		MenuItem.InsertSeparator(mAssets_ImportPackageItem);
		/*mAssets_ImportPackage_CharacterControllerItem     =*/ MenuItem.Create(mAssets_ImportPackageItem, "Character Controller",        OnAssets_ImportPackage_CharacterController);
		/*mAssets_ImportPackage_GlassRefractionProOnlytem   =*/ MenuItem.Create(mAssets_ImportPackageItem, "Glass Refraction (Pro Only)", OnAssets_ImportPackage_GlassRefractionProOnly);
		/*mAssets_ImportPackage_ImageEffectsProOnlyItem     =*/ MenuItem.Create(mAssets_ImportPackageItem, "Image Effects (Pro Only)",    OnAssets_ImportPackage_ImageEffectsProOnly);
		/*mAssets_ImportPackage_LightCookiesItem            =*/ MenuItem.Create(mAssets_ImportPackageItem, "Light Cookies",               OnAssets_ImportPackage_LightCookies);
		/*mAssets_ImportPackage_LightFlaresItem             =*/ MenuItem.Create(mAssets_ImportPackageItem, "Light Flares",                OnAssets_ImportPackage_LightFlares);
		/*mAssets_ImportPackage_ParticlesItem               =*/ MenuItem.Create(mAssets_ImportPackageItem, "Particles",                   OnAssets_ImportPackage_Particles);
		/*mAssets_ImportPackage_PhysicMaterialsItem         =*/ MenuItem.Create(mAssets_ImportPackageItem, "Physic Materials",            OnAssets_ImportPackage_PhysicMaterials);
		/*mAssets_ImportPackage_ProjectorsItem              =*/ MenuItem.Create(mAssets_ImportPackageItem, "Projectors",                  OnAssets_ImportPackage_Projectors);
		/*mAssets_ImportPackage_ScriptsItem                 =*/ MenuItem.Create(mAssets_ImportPackageItem, "Scripts",                     OnAssets_ImportPackage_Scripts);
		/*mAssets_ImportPackage_SkyboxesItem                =*/ MenuItem.Create(mAssets_ImportPackageItem, "Skyboxes",                    OnAssets_ImportPackage_Skyboxes);
		/*mAssets_ImportPackage_StandardAssetsMobileItem    =*/ MenuItem.Create(mAssets_ImportPackageItem, "Standard Assets (Mobile)",    OnAssets_ImportPackage_StandardAssetsMobile);
		/*mAssets_ImportPackage_TerrainAssetsItem           =*/ MenuItem.Create(mAssets_ImportPackageItem, "Terrain Assets",              OnAssets_ImportPackage_TerrainAssets);
		/*mAssets_ImportPackage_TessellationShadersDx11Item =*/ MenuItem.Create(mAssets_ImportPackageItem, "Tessellation Shaders (DX11)", OnAssets_ImportPackage_TessellationShadersDx11);
		/*mAssets_ImportPackage_ToonShadingItem             =*/ MenuItem.Create(mAssets_ImportPackageItem, "Toon Shading",                OnAssets_ImportPackage_ToonShading);
		/*mAssets_ImportPackage_TreeCreatorItem             =*/ MenuItem.Create(mAssets_ImportPackageItem, "Tree Creator",                OnAssets_ImportPackage_TreeCreator);
		/*mAssets_ImportPackage_WaterBasicItem              =*/ MenuItem.Create(mAssets_ImportPackageItem, "Water (Basic)",               OnAssets_ImportPackage_WaterBasic);
		/*mAssets_ImportPackage_WaterProOnlyItem            =*/ MenuItem.Create(mAssets_ImportPackageItem, "Water (Pro Only)",            OnAssets_ImportPackage_WaterProOnly);
		#endregion

		/*mAssets_ExportPackageItem          =*/ MenuItem.Create(mAssetsMenu, "Export Package...",        OnAssets_ExportPackage);
		/*mAssets_FindReferencesInSceneItem  =*/ MenuItem.Create(mAssetsMenu, "Find References In Scene", OnAssets_FindReferencesInScene);
		/*mAssets_SelectDependenciestem      =*/ MenuItem.Create(mAssetsMenu, "Select Dependencies",      OnAssets_SelectDependencies);
		MenuItem.InsertSeparator(mAssetsMenu);
		/*mAssets_RefreshItem                =*/ MenuItem.Create(mAssetsMenu, "Refresh",                  OnAssets_Refresh);
		/*mAssets_ReimportItem               =*/ MenuItem.Create(mAssetsMenu, "Reimport",                 OnAssets_Reimport);
		MenuItem.InsertSeparator(mAssetsMenu);
		/*mAssets_ReimportAllItem            =*/ MenuItem.Create(mAssetsMenu, "Reimport All",             OnAssets_ReimportAll);
		MenuItem.InsertSeparator(mAssetsMenu);
		/*mAssets_SyncMonoDevelopProjectItem =*/ MenuItem.Create(mAssetsMenu, "Sync MonoDevelop Project", OnAssets_SyncMonoDevelopProject);
		#endregion

		#region GameObject
		mGameObjectMenu = MenuItem.Create(mItems, "GameObject", OnGameObjectMenu);
		#endregion

		#region Component
		mComponentMenu = MenuItem.Create(mItems, "Component", OnComponentMenu);
		#endregion

		#region Window
		mWindowMenu = MenuItem.Create(mItems, "Window", OnWindowMenu);
		#endregion

		#region Help
		mHelpMenu = MenuItem.Create(mItems, "Help", OnHelpMenu);
		#endregion
    }

	/// <summary>
	/// Creates user interface.
	/// </summary>
	private void CreateUI() // TODO: Report bug for ///
	{
		//***************************************************************************
		// ScrollArea GameObject
		//***************************************************************************
		#region ScrollArea GameObject
        GameObject scrollArea = new GameObject("ScrollArea");
        Utils.InitUIObject(scrollArea, transform);

		//===========================================================================
		// RectTransform Component
		//===========================================================================
		#region RectTransform Component
        RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
		Utils.AlignRectTransformFill(scrollAreaTransform);
		#endregion

		//***************************************************************************
		// Content for ScrollArea object
		//***************************************************************************
		#region Content for ScrollArea object
        GameObject scrollAreaContent = new GameObject("Content");
        Utils.InitUIObject(scrollAreaContent, scrollArea.transform);

		//===========================================================================
		// RectTransform Component
		//===========================================================================
		#region RectTransform Component
        RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();

		scrollAreaContentTransform.localScale = new Vector3(1f, 1f, 1f);
        scrollAreaContentTransform.anchorMin  = new Vector2(0f, 0f);
        scrollAreaContentTransform.anchorMax  = new Vector2(0f, 1f);
		scrollAreaContentTransform.pivot      = new Vector2(0f, 0.5f);
		#endregion

        // Fill content
        float contentWidth = 0f;

        // Create menu item buttons
        foreach (TreeNode<MenuItem> menuItem in mItems.Children)
        {
			//***************************************************************************
			// Button GameObject
			//***************************************************************************
			#region Button GameObject
			GameObject menuItemButton = Instantiate(menuButton.gameObject) as GameObject;
			Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
			menuItemButton.name = menuItem.Data.Name; // TODO: Token id to string

			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform menuItemButtonTransform = menuItemButton.GetComponent<RectTransform>();
			
			menuItemButtonTransform.localScale = new Vector3(1f, 1f, 1f);
			menuItemButtonTransform.anchorMin  = new Vector2(0f, 0f);
			menuItemButtonTransform.anchorMax  = new Vector2(0f, 1f);
			#endregion

			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button button = menuItemButton.GetComponent<Button>();
			
			button.interactable = menuItem.Data.Enabled; // TODO: Check it. Maybe do the same as for PopupMenu
			button.onClick.AddListener(menuItem.Data.OnClick);
			#endregion
			#endregion

			//***************************************************************************
			// Text GameObject
			//***************************************************************************
			#region Text GameObject
			GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject;

			#region Text Component
			Text text = menuItemText.GetComponent<Text>();
			text.text = menuItem.Data.Name; // TODO: Translate
			#endregion
			#endregion

			#region Calculating button geometry
			++contentWidth;

			float buttonWidth = text.preferredWidth + 12;

			menuItemButtonTransform.anchoredPosition3D = new Vector3(contentWidth + buttonWidth / 2, 0f, 0f);
			menuItemButtonTransform.sizeDelta          = new Vector2(buttonWidth, -2f);
			
			contentWidth += buttonWidth + 1;
			#endregion
        }

		scrollAreaContentTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        scrollAreaContentTransform.sizeDelta          = new Vector2(contentWidth, 0f);
		#endregion

		#region ScrollRect Component
		ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();

		scrollAreaScrollRect.content  = scrollAreaContentTransform;
		scrollAreaScrollRect.vertical = false;
		#endregion
		#endregion
	}

	/// <summary>
	/// Creates and displays popup menu for specified menu item.
	/// </summary>
	/// <param name="node"><see cref="common.TreeNode`1"/> instance.</param>
	public void OnShowMenuSubItems(TreeNode<MenuItem> node)
    {
		Debug.Log("MainMenuScript.OnShowMenuSubItems(" + node.Data.Name + ")");

		if (mPopupMenu != null)
		{
			mPopupMenu.Destroy();
		}

		mPopupMenu = new PopupMenu(node);
		mPopupMenu.OnDestroy.AddListener(OnPopupMenuDestroyed);

		RectTransform menuItemTransform = transform.FindChild("ScrollArea/Content/" + node.Data.Name).GetComponent<RectTransform>();
		Vector3[] menuItemCorners = Utils.GetWindowCorners(menuItemTransform);

		mPopupMenu.Show(menuItemCorners[0].x, menuItemCorners[0].y);
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
		OnShowMenuSubItems(mFileMenu);
	}

	/// <summary>
	/// Handler for File->New Scene.
	/// </summary>
	public void OnFile_NewScene()
	{
		Debug.Log("MainMenuScript.OnFile_NewScene");
		// TODO: Implement MainMenuScript.OnFile_NewScene
	}

	/// <summary>
	/// Handler for File->Open Scene.
	/// </summary>
	public void OnFile_OpenScene()
	{
		Debug.Log("MainMenuScript.OnFile_OpenScene");
		// TODO: Implement MainMenuScript.OnFile_OpenScene
	}

	/// <summary>
	/// Handler for File->Save Scene.
	/// </summary>
	public void OnFile_SaveScene()
	{
		Debug.Log("MainMenuScript.OnFile_SaveScene");
		// TODO: Implement MainMenuScript.OnFile_SaveScene
	}

	/// <summary>
	/// Handler for File->Save Scene as...
	/// </summary>
	public void OnFile_SaveSceneAs()
	{
		Debug.Log("MainMenuScript.OnFile_SaveSceneAs");
		// TODO: Implement MainMenuScript.OnFile_SaveSceneAs
	}

	/// <summary>
	/// Handler for File->New Project...
	/// </summary>
	public void OnFile_NewProject()
	{
		Debug.Log("MainMenuScript.OnFile_NewProject");
		// TODO: Implement MainMenuScript.OnFile_NewProject
	}

	/// <summary>
	/// Handler for File->Open Project...
	/// </summary>
	public void OnFile_OpenProject()
	{
		Debug.Log("MainMenuScript.OnFile_OpenProject");
		// TODO: Implement MainMenuScript.OnFile_OpenProject
	}

	/// <summary>
	/// Handler for File->Save Project.
	/// </summary>
	public void OnFile_SaveProject()
	{
		Debug.Log("MainMenuScript.OnFile_SaveProject");
		// TODO: Implement MainMenuScript.OnFile_SaveProject
	}

	/// <summary>
	/// Handler for File->Build Settings...
	/// </summary>
	public void OnFile_BuildSettings()
	{
		Debug.Log("MainMenuScript.OnFile_BuildSettings");
		// TODO: Implement MainMenuScript.OnFile_BuildSettings
	}

	/// <summary>
	/// Handler for File->Build & Run.
	/// </summary>
	public void OnFile_BuildAndRun()
	{
		Debug.Log("MainMenuScript.OnFile_BuildAndRun");
		// TODO: Implement MainMenuScript.OnFile_BuildAndRun
	}

	/// <summary>
	/// Handler for File->Exit.
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
		OnShowMenuSubItems(mEditMenu);
	}

	/// <summary>
	/// Handler for Edit->Undo.
	/// </summary>
	public void OnEdit_Undo()
	{
		Debug.Log("MainMenuScript.OnEdit_Undo");
		// TODO: Implement MainMenuScript.OnEdit_Undo
	}

	/// <summary>
	/// Handler for Edit->Redo.
	/// </summary>
	public void OnEdit_Redo()
	{
		Debug.Log("MainMenuScript.OnEdit_Redo");
		// TODO: Implement MainMenuScript.OnEdit_Redo
	}

	/// <summary>
	/// Handler for Edit->Cut.
	/// </summary>
	public void OnEdit_Cut()
	{
		Debug.Log("MainMenuScript.OnEdit_Cut");
		// TODO: Implement MainMenuScript.OnEdit_Cut
	}

	/// <summary>
	/// Handler for Edit->Copy.
	/// </summary>
	public void OnEdit_Copy()
	{
		Debug.Log("MainMenuScript.OnEdit_Copy");
		// TODO: Implement MainMenuScript.OnEdit_Copy
	}

	/// <summary>
	/// Handler for Edit->Paste.
	/// </summary>
	public void OnEdit_Paste()
	{
		Debug.Log("MainMenuScript.OnEdit_Paste");
		// TODO: Implement MainMenuScript.OnEdit_Paste
	}

	/// <summary>
	/// Handler for Edit->Duplicate.
	/// </summary>
	public void OnEdit_Duplicate()
	{
		Debug.Log("MainMenuScript.OnEdit_Duplicate");
		// TODO: Implement MainMenuScript.OnEdit_Duplicate
	}

	/// <summary>
	/// Handler for Edit->Delete.
	/// </summary>
	public void OnEdit_Delete()
	{
		Debug.Log("MainMenuScript.OnEdit_Delete");
		// TODO: Implement MainMenuScript.OnEdit_Delete
	}

	/// <summary>
	/// Handler for Edit->Frame Selected.
	/// </summary>
	public void OnEdit_FrameSelected()
	{
		Debug.Log("MainMenuScript.OnEdit_FrameSelected");
		// TODO: Implement MainMenuScript.OnEdit_FrameSelected
	}

	/// <summary>
	/// Handler for Edit->Lock View to Selected.
	/// </summary>
	public void OnEdit_LockViewToSelected()
	{
		Debug.Log("MainMenuScript.OnEdit_LockViewToSelected");
		// TODO: Implement MainMenuScript.OnEdit_LockViewToSelected
	}

	/// <summary>
	/// Handler for Edit->Find.
	/// </summary>
	public void OnEdit_Find()
	{
		Debug.Log("MainMenuScript.OnEdit_Find");
		// TODO: Implement MainMenuScript.OnEdit_Find
	}

	/// <summary>
	/// Handler for Edit->Select All.
	/// </summary>
	public void OnEdit_SelectAll()
	{
		Debug.Log("MainMenuScript.OnEdit_SelectAll");
		// TODO: Implement MainMenuScript.OnEdit_SelectAll
	}
		
	/// <summary>
	/// Handler for Edit->Preferences...
	/// </summary>
	public void OnEdit_Preferences()
	{
		Debug.Log("MainMenuScript.OnEdit_Preferences");
		// TODO: Implement MainMenuScript.OnEdit_Preferences
	}

	/// <summary>
	/// Handler for Edit->Modules...
	/// </summary>
	public void OnEdit_Modules()
	{
		Debug.Log("MainMenuScript.OnEdit_Modules");
		// TODO: Implement MainMenuScript.OnEdit_Modules
	}
		
	/// <summary>
	/// Handler for Edit->Play.
	/// </summary>
	public void OnEdit_Play()
	{
		Debug.Log("MainMenuScript.OnEdit_Play");
		// TODO: Implement MainMenuScript.OnEdit_Play
	}

	/// <summary>
	/// Handler for Edit->Pause.
	/// </summary>
	public void OnEdit_Pause()
	{
		Debug.Log("MainMenuScript.OnEdit_Pause");
		// TODO: Implement MainMenuScript.OnEdit_Pause
	}

	/// <summary>
	/// Handler for Edit->Step.
	/// </summary>
	public void OnEdit_Step()
	{
		Debug.Log("MainMenuScript.OnEdit_Step");
		// TODO: Implement MainMenuScript.OnEdit_Step
	}
	
	#region Edit->Selection
	/// <summary>
	/// Handler for Edit->Selection->Load Selection 1.
	/// </summary>
	public void OnEdit_Selection_LoadSelection1()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection1");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection1
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 2.
	/// </summary>
	public void OnEdit_Selection_LoadSelection2()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection2");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection2
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 3.
	/// </summary>
	public void OnEdit_Selection_LoadSelection3()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection3");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection3
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 4.
	/// </summary>
	public void OnEdit_Selection_LoadSelection4()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection4");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection4
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 5.
	/// </summary>
	public void OnEdit_Selection_LoadSelection5()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection5");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection5
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 6.
	/// </summary>
	public void OnEdit_Selection_LoadSelection6()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection6");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection6
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 7.
	/// </summary>
	public void OnEdit_Selection_LoadSelection7()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection7");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection7
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 8.
	/// </summary>
	public void OnEdit_Selection_LoadSelection8()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection8");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection8
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 9.
	/// </summary>
	public void OnEdit_Selection_LoadSelection9()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection9");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection9
	}

	/// <summary>
	/// Handler for Edit->Selection->Load Selection 0.
	/// </summary>
	public void OnEdit_Selection_LoadSelection0()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection0");
		// TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection0
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 1.
	/// </summary>
	public void OnEdit_Selection_SaveSelection1()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection1");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection1
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 2.
	/// </summary>
	public void OnEdit_Selection_SaveSelection2()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection2");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection2
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 3.
	/// </summary>
	public void OnEdit_Selection_SaveSelection3()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection3");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection3
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 4.
	/// </summary>
	public void OnEdit_Selection_SaveSelection4()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection4");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection4
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 5.
	/// </summary>
	public void OnEdit_Selection_SaveSelection5()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection5");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection5
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 6.
	/// </summary>
	public void OnEdit_Selection_SaveSelection6()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection6");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection6
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 7.
	/// </summary>
	public void OnEdit_Selection_SaveSelection7()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection7");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection7
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 8.
	/// </summary>
	public void OnEdit_Selection_SaveSelection8()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection8");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection8
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 9.
	/// </summary>
	public void OnEdit_Selection_SaveSelection9()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection9");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection9
	}

	/// <summary>
	/// Handler for Edit->Selection->Save Selection 0.
	/// </summary>
	public void OnEdit_Selection_SaveSelection0()
	{
		Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection0");
		// TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection0
	}
	#endregion
	
	#region Edit->Project Settings
	/// <summary>
	/// Handler for Edit->Project Settings->Input.
	/// </summary>
	public void OnEdit_ProjectSettings_Input()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Input");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Input
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Tags and Layers.
	/// </summary>
	public void OnEdit_ProjectSettings_TagsAndLayers()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Audio.
	/// </summary>
	public void OnEdit_ProjectSettings_Audio()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Audio");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Audio
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Time.
	/// </summary>
	public void OnEdit_ProjectSettings_Time()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Time");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Time
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Player.
	/// </summary>
	public void OnEdit_ProjectSettings_Player()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Player");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Player
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Physics.
	/// </summary>
	public void OnEdit_ProjectSettings_Physics()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Physics 2D.
	/// </summary>
	public void OnEdit_ProjectSettings_Physics2D()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics2D");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics2D
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Quality.
	/// </summary>
	public void OnEdit_ProjectSettings_Quality()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Quality");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Quality
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Graphics.
	/// </summary>
	public void OnEdit_ProjectSettings_Graphics()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Graphics");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Graphics
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Network.
	/// </summary>
	public void OnEdit_ProjectSettings_Network()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Network");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Network
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Editor.
	/// </summary>
	public void OnEdit_ProjectSettings_Editor()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Editor");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Editor
	}

	/// <summary>
	/// Handler for Edit->Project Settings->Script Execution Order.
	/// </summary>
	public void OnEdit_ProjectSettings_ScriptExecutionOrder()
	{
		Debug.Log("MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder");
		// TODO: Implement MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder
	}
	#endregion

	/// <summary>
	/// Handler for Edit->Render Settings.
	/// </summary>
	public void OnEdit_RenderSettings()
	{
		Debug.Log("MainMenuScript.OnEdit_RenderSettings");
		// TODO: Implement MainMenuScript.OnEdit_RenderSettings
	}
		
	#region Edit->Network Emulation
	/// <summary>
	/// Handler for Edit->Network Emulation->None.
	/// </summary>
	public void OnEdit_NetworkEmulation_None()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_None");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_None
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->Broadband.
	/// </summary>
	public void OnEdit_NetworkEmulation_Broadband()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_Broadband");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_Broadband
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->DSL.
	/// </summary>
	public void OnEdit_NetworkEmulation_DSL()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DSL");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DSL
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->ISDN.
	/// </summary>
	public void OnEdit_NetworkEmulation_ISDN()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_ISDN");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_ISDN
	}

	/// <summary>
	/// Handler for Edit->Network Emulation->Dial-Up.
	/// </summary>
	public void OnEdit_NetworkEmulation_DialUp()
	{
		Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DialUp");
		// TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DialUp
	}
	#endregion
	
	#region Edit->Graphics Emulation
	/// <summary>
	/// Handler for Edit->Graphics Emulation->No Emulation.
	/// </summary>
	public void OnEdit_GraphicsEmulation_NoEmulation()
	{
		Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation");
		// TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation
	}

	/// <summary>
	/// Handler for Edit->Graphics Emulation->Shader Model 3.
	/// </summary>
	public void OnEdit_GraphicsEmulation_ShaderModel3()
	{
		Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel3");
		// TODO: Implement MainMenuScript.OnEdit_ReOnEdit_GraphicsEmulation_ShaderModel3do
	}

	/// <summary>
	/// Handler for Edit->Graphics Emulation->Shader Model 2.
	/// </summary>
	public void OnEdit_GraphicsEmulation_ShaderModel2()
	{
		Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2");
		// TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2
	}
	#endregion

	/// <summary>
	/// Handler for Edit->Snap Settings...
	/// </summary>
	public void OnEdit_SnapSettings()
	{
		Debug.Log("MainMenuScript.OnEdit_SnapSettings");
		// TODO: Implement MainMenuScript.OnEdit_SnapSettings
	}
	#endregion
	
	#region Assets
	/// <summary>
	/// Handler for Assets.
	/// </summary>
	public void OnAssetsMenu()
	{
		OnShowMenuSubItems(mAssetsMenu);
	}

	#region Assets->Create
	/// <summary>
	/// Handler for Assets->Create->Folder.
	/// </summary>
	public void OnAssets_Create_Folder()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Folder");
		// TODO: Implement MainMenuScript.OnAssets_Create_Folder
	}
	
	/// <summary>
	/// Handler for Assets->Create->Javascript.
	/// </summary>
	public void OnAssets_Create_Javascript()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Javascript");
		// TODO: Implement MainMenuScript.OnAssets_Create_Javascript
	}

	/// <summary>
	/// Handler for Assets->Create->C# Script.
	/// </summary>
	public void OnAssets_Create_CShartScript()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_CShartScript");
		// TODO: Implement MainMenuScript.OnAssets_Create_CShartScript
	}

	/// <summary>
	/// Handler for Assets->Create->Boo Script.
	/// </summary>
	public void OnAssets_Create_BooScript()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_BooScript");
		// TODO: Implement MainMenuScript.OnAssets_Create_BooScript
	}

	/// <summary>
	/// Handler for Assets->Create->Shader.
	/// </summary>
	public void OnAssets_Create_Shader()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Shader");
		// TODO: Implement MainMenuScript.OnAssets_Create_Shader
	}

	/// <summary>
	/// Handler for Assets->Create->Compute Shader.
	/// </summary>
	public void OnAssets_Create_ComputeShader()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_ComputeShader");
		// TODO: Implement MainMenuScript.OnAssets_Create_ComputeShader
	}

	/// <summary>
	/// Handler for Assets->Create->Prefab.
	/// </summary>
	public void OnAssets_Create_Prefab()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Prefab");
		// TODO: Implement MainMenuScript.OnAssets_Create_Prefab
	}

	/// <summary>
	/// Handler for Assets->Create->Material.
	/// </summary>
	public void OnAssets_Create_Material()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Material");
		// TODO: Implement MainMenuScript.OnAssets_Create_Material
	}

	/// <summary>
	/// Handler for Assets->Create->Cubemap.
	/// </summary>
	public void OnAssets_Create_Cubemap()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Cubemap");
		// TODO: Implement MainMenuScript.OnAssets_Create_Cubemap
	}

	/// <summary>
	/// Handler for Assets->Create->Lens Flare.
	/// </summary>
	public void OnAssets_Create_LensFlare()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_LensFlare");
		// TODO: Implement MainMenuScript.OnAssets_Create_LensFlare
	}

	/// <summary>
	/// Handler for Assets->Create->Animator Controller.
	/// </summary>
	public void OnAssets_Create_AnimatorController()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_AnimatorController");
		// TODO: Implement MainMenuScript.OnAssets_Create_AnimatorController
	}

	/// <summary>
	/// Handler for Assets->Create->Animation.
	/// </summary>
	public void OnAssets_Create_Animation()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Animation");
		// TODO: Implement MainMenuScript.OnAssets_Create_Animation
	}

	/// <summary>
	/// Handler for Assets->Create->Animator Override Contoller.
	/// </summary>
	public void OnAssets_Create_AnimatorOverrideContoller()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_AnimatorOverrideContoller");
		// TODO: Implement MainMenuScript.OnAssets_Create_AnimatorOverrideContoller
	}
	
	/// <summary>
	/// Handler for Assets->Create->Avatar Mask.
	/// </summary>
	public void OnAssets_Create_AvatarMask()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_AvatarMask");
		// TODO: Implement MainMenuScript.OnAssets_Create_AvatarMask
	}
	
	/// <summary>
	/// Handler for Assets->Create->Physic Material.
	/// </summary>
	public void OnAssets_Create_PhysicMaterial()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_PhysicMaterial");
		// TODO: Implement MainMenuScript.OnAssets_Create_PhysicMaterial
	}
	
	/// <summary>
	/// Handler for Assets->Create->Physic2D Material.
	/// </summary>
	public void OnAssets_Create_Physic2dMaterial()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_Physic2dMaterial");
		// TODO: Implement MainMenuScript.OnAssets_Create_Physic2dMaterial
	}
	
	/// <summary>
	/// Handler for Assets->Create->GUI Skin.
	/// </summary>
	public void OnAssets_Create_GuiSkin()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_GuiSkin");
		// TODO: Implement MainMenuScript.OnAssets_Create_GuiSkin
	}
	
	/// <summary>
	/// Handler for Assets->Create->Custom Font.
	/// </summary>
	public void OnAssets_Create_CustomFont()
	{
		Debug.Log("MainMenuScript.OnAssets_Create_CustomFont");
		// TODO: Implement MainMenuScript.OnAssets_Create_CustomFont
	}
	#endregion

	/// <summary>
	/// Handler for Assets->Show In Explorer.
	/// </summary>
	public void OnAssets_ShowInExplorer()
	{
		Debug.Log("MainMenuScript.OnAssets_ShowInExplorer");
		// TODO: Implement MainMenuScript.OnAssets_ShowInExplorer
	}

	/// <summary>
	/// Handler for Assets->Open.
	/// </summary>
	public void OnAssets_Open()
	{
		Debug.Log("MainMenuScript.OnAssets_Open");
		// TODO: Implement MainMenuScript.OnAssets_Open
	}
	
	/// <summary>
	/// Handler for Assets->Delete.
	/// </summary>
	public void OnAssets_Delete()
	{
		Debug.Log("MainMenuScript.OnAssets_Delete");
		// TODO: Implement MainMenuScript.OnAssets_Delete
	}
	
	/// <summary>
	/// Handler for Assets->Import New Asset...
	/// </summary>
	public void OnAssets_ImportNewAsset()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportNewAsset");
		// TODO: Implement MainMenuScript.OnAssets_ImportNewAsset
	}

	#region Assets->Import Package
	/// <summary>
	/// Handler for Assets->Import Package->Custom Package...
	/// </summary>
	public void OnAssets_ImportPackage_CustomPackage()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_CustomPackage");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_CustomPackage
	}

	/// <summary>
	/// Handler for Assets->Import Package->Character Controller.
	/// </summary>
	public void OnAssets_ImportPackage_CharacterController()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_CharacterController");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_CharacterController
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Glass Refraction (Pro Only).
	/// </summary>
	public void OnAssets_ImportPackage_GlassRefractionProOnly()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_GlassRefractionProOnly");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_GlassRefractionProOnly
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Image Effects (Pro Only).
	/// </summary>
	public void OnAssets_ImportPackage_ImageEffectsProOnly()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_ImageEffectsProOnly");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_ImageEffectsProOnly
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Light Cookies.
	/// </summary>
	public void OnAssets_ImportPackage_LightCookies()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_LightCookies");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_LightCookies
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Light Flares.
	/// </summary>
	public void OnAssets_ImportPackage_LightFlares()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_LightFlares");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_LightFlares
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Particles.
	/// </summary>
	public void OnAssets_ImportPackage_Particles()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_Particles");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Particles
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Physic Materials.
	/// </summary>
	public void OnAssets_ImportPackage_PhysicMaterials()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_PhysicMaterials");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_PhysicMaterials
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Projectors.
	/// </summary>
	public void OnAssets_ImportPackage_Projectors()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_Projectors");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Projectors
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Scripts.
	/// </summary>
	public void OnAssets_ImportPackage_Scripts()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_Scripts");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Scripts
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Skyboxes.
	/// </summary>
	public void OnAssets_ImportPackage_Skyboxes()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_Skyboxes");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_Skyboxes
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Standard Assets (Mobile).
	/// </summary>
	public void OnAssets_ImportPackage_StandardAssetsMobile()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_StandardAssetsMobile");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_StandardAssetsMobile
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Terrain Assets.
	/// </summary>
	public void OnAssets_ImportPackage_TerrainAssets()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_TerrainAssets");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_TerrainAssets
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Tessellation Shaders (DX11).
	/// </summary>
	public void OnAssets_ImportPackage_TessellationShadersDx11()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_TessellationShadersDx11");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_TessellationShadersDx11
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Toon Shading.
	/// </summary>
	public void OnAssets_ImportPackage_ToonShading()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_ToonShading");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_ToonShading
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Tree Creator.
	/// </summary>
	public void OnAssets_ImportPackage_TreeCreator()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_TreeCreator");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_TreeCreator
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Water (Basic).
	/// </summary>
	public void OnAssets_ImportPackage_WaterBasic()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_WaterBasic");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_WaterBasic
	}
	
	/// <summary>
	/// Handler for Assets->Import Package->Water (Pro Only).
	/// </summary>
	public void OnAssets_ImportPackage_WaterProOnly()
	{
		Debug.Log("MainMenuScript.OnAssets_ImportPackage_WaterProOnly");
		// TODO: Implement MainMenuScript.OnAssets_ImportPackage_WaterProOnly
	}
	#endregion
	
	/// <summary>
	/// Handler for Assets->Export Package...
	/// </summary>
	public void OnAssets_ExportPackage()
	{
		Debug.Log("MainMenuScript.OnAssets_ExportPackage");
		// TODO: Implement MainMenuScript.OnAssets_ExportPackage
	}

	/// <summary>
	/// Handler for Assets->Find References In Scene.
	/// </summary>
	public void OnAssets_FindReferencesInScene()
	{
		Debug.Log("MainMenuScript.OnAssets_FindReferencesInScene");
		// TODO: Implement MainMenuScript.OnAssets_FindReferencesInScene
	}
	
	/// <summary>
	/// Handler for Assets->Select Dependencies.
	/// </summary>
	public void OnAssets_SelectDependencies()
	{
		Debug.Log("MainMenuScript.OnAssets_SelectDependencies");
		// TODO: Implement MainMenuScript.OnAssets_SelectDependencies
	}
	
	/// <summary>
	/// Handler for Assets->Refresh.
	/// </summary>
	public void OnAssets_Refresh()
	{
		Debug.Log("MainMenuScript.OnAssets_Refresh");
		// TODO: Implement MainMenuScript.OnAssets_Refresh
	}
	
	/// <summary>
	/// Handler for Assets->Reimport.
	/// </summary>
	public void OnAssets_Reimport()
	{
		Debug.Log("MainMenuScript.OnAssets_Reimport");
		// TODO: Implement MainMenuScript.OnAssets_Reimport
	}
	
	/// <summary>
	/// Handler for Assets->Reimport All.
	/// </summary>
	public void OnAssets_ReimportAll()
	{
		Debug.Log("MainMenuScript.OnAssets_ReimportAll");
		// TODO: Implement MainMenuScript.OnAssets_ReimportAll
	}
	
	/// <summary>
	/// Handler for Assets->Sync MonoDevelop Project.
	/// </summary>
	public void OnAssets_SyncMonoDevelopProject()
	{
		Debug.Log("MainMenuScript.OnAssets_SyncMonoDevelopProject");
		// TODO: Implement MainMenuScript.OnAssets_SyncMonoDevelopProject
	}
	#endregion
	
	#region GameObject
	/// <summary>
	/// Handler for GameObject.
	/// </summary>
	public void OnGameObjectMenu()
	{
		OnShowMenuSubItems(mGameObjectMenu);
	}
	#endregion
	
	#region Component
	/// <summary>
	/// Handler for Component.
	/// </summary>
	public void OnComponentMenu()
	{
		OnShowMenuSubItems(mComponentMenu);
	}
	#endregion
	
	#region Window
	/// <summary>
	/// Handler for Window.
	/// </summary>
	public void OnWindowMenu()
	{
		OnShowMenuSubItems(mWindowMenu);
	}
	#endregion
	
	#region Help
	/// <summary>
	/// Handler for Help.
	/// </summary>
	public void OnHelpMenu()
	{
		OnShowMenuSubItems(mHelpMenu);
	}
	#endregion
	#endregion
}
