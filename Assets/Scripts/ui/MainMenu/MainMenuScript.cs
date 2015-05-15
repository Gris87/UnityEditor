using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;

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
//  private TreeNode<MenuItem> mFile_BuildInCloudItem  = null;

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

    #region Edit -> Selection
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

    #region Edit -> Project Settings
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

    #region Edit -> Network Emulation
    private TreeNode<MenuItem> mEdit_NetworkEmulationItem                           = null;

//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationNoneItem      = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationBroadbandItem = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationDSLItem       = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationISDNItem      = null;
//	private TreeNode<MenuItem> mEdit_NetworkEmulation_NetworkEmulationDialUpItem    = null;
    #endregion

    #region Edit -> Graphics Emulation
    private TreeNode<MenuItem> mEdit_GraphicsEmulationItem                               = null;

//	private TreeNode<MenuItem> mEdit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  = null;
//	private TreeNode<MenuItem> mEdit_GraphicsEmulation_GraphicsEmulationShaderModel3Item = null;
//	private TreeNode<MenuItem> mEdit_GraphicsEmulation_GraphicsEmulationShaderModel2Item = null;
    #endregion

//	private TreeNode<MenuItem> mEdit_SnapSettingsItem = null;
    #endregion

    #region Assets
    private TreeNode<MenuItem> mAssetsMenu = null;

    #region Assets -> Create
    private TreeNode<MenuItem> mAssets_CreateItem                           = null;

//	private TreeNode<MenuItem> mAssets_Create_FolderItem                    = null;

//  private TreeNode<MenuItem> mAssets_Create_CSharpScriptItem              = null;
//  private TreeNode<MenuItem> mAssets_Create_JavascriptItem                = null;
//  private TreeNode<MenuItem> mAssets_Create_ShaderItem                    = null;
//  private TreeNode<MenuItem> mAssets_Create_ComputeShaderItem             = null;

//	private TreeNode<MenuItem> mAssets_Create_PrefabItem                    = null;

//  private TreeNode<MenuItem> mAssets_Create_AudioMixerItem                = null;

//	private TreeNode<MenuItem> mAssets_Create_MaterialItem                  = null;
//	private TreeNode<MenuItem> mAssets_Create_LensFlareItem                 = null;
//  private TreeNode<MenuItem> mAssets_Create_RenderTextureItem             = null;
//  private TreeNode<MenuItem> mAssets_Create_LightmapParametersItem        = null;

//	private TreeNode<MenuItem> mAssets_Create_AnimatorControllerItem        = null;
//	private TreeNode<MenuItem> mAssets_Create_AnimationItem                 = null;
//	private TreeNode<MenuItem> mAssets_Create_AnimatorOverrideContollerItem = null;
//	private TreeNode<MenuItem> mAssets_Create_AvatarMaskItem                = null;

//	private TreeNode<MenuItem> mAssets_Create_PhysicMaterialItem            = null;
//	private TreeNode<MenuItem> mAssets_Create_Physic2dMaterialItem          = null;

//	private TreeNode<MenuItem> mAssets_Create_GuiSkinItem                   = null;
//	private TreeNode<MenuItem> mAssets_Create_CustomFontItem                = null;
//  private TreeNode<MenuItem> mAssets_Create_ShaderVariantCollectionItem   = null;

    #region Assets -> Create -> Legacy
    private TreeNode<MenuItem> mAssets_Create_LegacyItem                = null;

//  private TreeNode<MenuItem> mAssets_Create_Legacy_CubemapItem        = null;
    #endregion

    #endregion

//	private TreeNode<MenuItem> mAssets_ShowInExplorerItem = null;
//	private TreeNode<MenuItem> mAssets_OpenItem           = null;
//	private TreeNode<MenuItem> mAssets_DeleteItem         = null;

//	private TreeNode<MenuItem> mAssets_ImportNewAssetItem = null;

    #region Assets -> Import Package
    private TreeNode<MenuItem> mAssets_ImportPackageItem                    = null;

//	private TreeNode<MenuItem> mAssets_ImportPackage_CustomPackageItem      = null;

//	private TreeNode<MenuItem> mAssets_ImportPackage_2dItem                 = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_CamerasItem            = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_CharactersItem         = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_CrossPlatformInputItem = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_EffectsItem            = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_EnvironmentItem        = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_ParticleSystemsItem    = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_PrototypingItem        = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_UtilityItem            = null;
//	private TreeNode<MenuItem> mAssets_ImportPackage_VehiclesItem           = null;
    #endregion

//	private TreeNode<MenuItem> mAssets_ExportPackageItem          = null;
//	private TreeNode<MenuItem> mAssets_FindReferencesInSceneItem  = null;
//	private TreeNode<MenuItem> mAssets_SelectDependenciesItem     = null;

//	private TreeNode<MenuItem> mAssets_RefreshItem                = null;
//	private TreeNode<MenuItem> mAssets_ReimportItem               = null;

//	private TreeNode<MenuItem> mAssets_ReimportAllItem            = null;

//	private TreeNode<MenuItem> mAssets_RunApiUpdaterItem          = null;

//  private TreeNode<MenuItem> mAssets_SyncMonoDevelopProjectItem = null;

    #endregion

    #region GameObject
    private TreeNode<MenuItem> mGameObjectMenu = null;

//  private TreeNode<MenuItem> mGameObject_CreateEmptyItem      = null;
//  private TreeNode<MenuItem> mGameObject_CreateEmptyChildItem = null;

    #region GameObject -> 3D Object    
    private TreeNode<MenuItem> mGameObject_3dObjectItem          = null;

//  private TreeNode<MenuItem> mGameObject_3dObject_CubeItem     = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_SphereItem   = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_CapsuleItem  = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_CylinderItem = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_PlaneItem    = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_QuadItem     = null;

//  private TreeNode<MenuItem> mGameObject_3dObject_RagdollItem  = null;

//  private TreeNode<MenuItem> mGameObject_3dObject_TerrainItem  = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_TreeItem     = null;
//  private TreeNode<MenuItem> mGameObject_3dObject_WindZoneItem = null;

//  private TreeNode<MenuItem> mGameObject_3dObject_3dTextItem   = null;
    #endregion

    #region GameObject -> 2D Object    
    private TreeNode<MenuItem> mGameObject_2dObjectItem        = null;

//  private TreeNode<MenuItem> mGameObject_2dObject_SpriteItem = null;
    #endregion

    #region GameObject -> Light
    private TreeNode<MenuItem> mGameObject_LightItem                  = null;
    
//  private TreeNode<MenuItem> mGameObject_Light_DirectionalLightItem = null;
//  private TreeNode<MenuItem> mGameObject_Light_PointLightItem       = null;
//  private TreeNode<MenuItem> mGameObject_Light_SpotlightItem        = null;
//  private TreeNode<MenuItem> mGameObject_Light_AreaLightItem        = null;

//  private TreeNode<MenuItem> mGameObject_Light_ReflectionProbeItem  = null;
//  private TreeNode<MenuItem> mGameObject_Light_LightProbeGroupItem  = null;
    #endregion

    #region GameObject -> Audio
    private TreeNode<MenuItem> mGameObject_AudioItem                 = null;
    
//  private TreeNode<MenuItem> mGameObject_Audio_AudioSourceItem     = null;
//  private TreeNode<MenuItem> mGameObject_Audio_AudioReverbZoneItem = null;
    #endregion

    #region GameObject -> UI
    private TreeNode<MenuItem> mGameObject_UiItem             = null;
    
//  private TreeNode<MenuItem> mGameObject_Ui_PanelItem       = null;
//  private TreeNode<MenuItem> mGameObject_Ui_ButtonItem      = null;
//  private TreeNode<MenuItem> mGameObject_Ui_TextItem        = null;
//  private TreeNode<MenuItem> mGameObject_Ui_ImageItem       = null;
//  private TreeNode<MenuItem> mGameObject_Ui_RawImageItem    = null;
//  private TreeNode<MenuItem> mGameObject_Ui_SliderItem      = null;
//  private TreeNode<MenuItem> mGameObject_Ui_ScrollbarItem   = null;
//  private TreeNode<MenuItem> mGameObject_Ui_ToggleItem      = null;
//  private TreeNode<MenuItem> mGameObject_Ui_InputFieldItem  = null;
//  private TreeNode<MenuItem> mGameObject_Ui_CanvasItem      = null;
//  private TreeNode<MenuItem> mGameObject_Ui_EventSystemItem = null;
    #endregion

//  private TreeNode<MenuItem> mGameObject_ParticleSystemItem       = null;
//  private TreeNode<MenuItem> mGameObject_CameraItem               = null;

//  private TreeNode<MenuItem> mGameObject_CenterOnChildrenItem     = null;

//  private TreeNode<MenuItem> mGameObject_MakeParentItem           = null;
//  private TreeNode<MenuItem> mGameObject_ClearParentItem          = null;
//  private TreeNode<MenuItem> mGameObject_ApplyChangesToPrefabItem = null;
//  private TreeNode<MenuItem> mGameObject_BreakPrefabInstanceItem  = null;

//  private TreeNode<MenuItem> mGameObject_SetAsFirstSiblingItem    = null;
//  private TreeNode<MenuItem> mGameObject_SetAsLastSiblingItem     = null;
//  private TreeNode<MenuItem> mGameObject_MoveToViewItem           = null;
//  private TreeNode<MenuItem> mGameObject_AlignWithViewItem        = null;
//  private TreeNode<MenuItem> mGameObject_AlignViewToSelectedItem  = null;
//  private TreeNode<MenuItem> mGameObject_ToggleActiveStateItem    = null;
    #endregion

    #region Component
    private TreeNode<MenuItem> mComponentMenu     = null;

//  private TreeNode<MenuItem> mComponent_AddItem = null;

    #region Component -> Mesh
    private TreeNode<MenuItem> mComponent_MeshItem                     = null;
    
//  private TreeNode<MenuItem> mComponent_Mesh_MeshFilterItem          = null;
//  private TreeNode<MenuItem> mComponent_Mesh_TextMeshItem            = null;

//  private TreeNode<MenuItem> mComponent_Mesh_MeshRendererItem        = null;
//  private TreeNode<MenuItem> mComponent_Mesh_SkinnedMeshRendererItem = null;
    #endregion

    #region Component -> Effects
    private TreeNode<MenuItem> mComponent_EffectsItem                = null;
    
//  private TreeNode<MenuItem> mComponent_Effects_ParticleSystemItem = null;
//  private TreeNode<MenuItem> mComponent_Effects_TrailRendererItem  = null;
//  private TreeNode<MenuItem> mComponent_Effects_LineRendererItem   = null;
//  private TreeNode<MenuItem> mComponent_Effects_LensFlareItem      = null;
//  private TreeNode<MenuItem> mComponent_Effects_HaloItem           = null;
//  private TreeNode<MenuItem> mComponent_Effects_ProjectorItem      = null;

    #region Component -> Effects -> Legacy Particles
    private TreeNode<MenuItem> mComponent_Effects_LegacyParticlesItem                          = null;
    
//  private TreeNode<MenuItem> mComponent_Effects_LegacyParticles_EllipsoidParticleEmitterItem = null;
//  private TreeNode<MenuItem> mComponent_Effects_LegacyParticles_MeshParticleEmitterItem      = null;

//  private TreeNode<MenuItem> mComponent_Effects_LegacyParticles_ParticleAnimatorItem         = null;
//  private TreeNode<MenuItem> mComponent_Effects_LegacyParticles_WorldParticleColliderItem    = null;

//  private TreeNode<MenuItem> mComponent_Effects_LegacyParticles_ParticleRendererItem         = null;
    #endregion

    #endregion

    #region Component -> Physics
    private TreeNode<MenuItem> mComponent_PhysicsItem                     = null;
    
//  private TreeNode<MenuItem> mComponent_Physics_RigidbodyItem           = null;
//  private TreeNode<MenuItem> mComponent_Physics_CharacterControllerItem = null;

//  private TreeNode<MenuItem> mComponent_Physics_BoxColliderItem         = null;
//  private TreeNode<MenuItem> mComponent_Physics_SphereColliderItem      = null;
//  private TreeNode<MenuItem> mComponent_Physics_CapsuleColliderItem     = null;
//  private TreeNode<MenuItem> mComponent_Physics_MeshColliderItem        = null;
//  private TreeNode<MenuItem> mComponent_Physics_WheelColliderItem       = null;
//  private TreeNode<MenuItem> mComponent_Physics_TerrainColliderItem     = null;

//  private TreeNode<MenuItem> mComponent_Physics_ClothItem               = null;

//  private TreeNode<MenuItem> mComponent_Physics_HingeJointItem          = null;
//  private TreeNode<MenuItem> mComponent_Physics_FixedJointItem          = null;
//  private TreeNode<MenuItem> mComponent_Physics_SpringJointItem         = null;
//  private TreeNode<MenuItem> mComponent_Physics_CharacterJointItem      = null;
//  private TreeNode<MenuItem> mComponent_Physics_ConfigurableJointItem   = null;

//  private TreeNode<MenuItem> mComponent_Physics_ConstantForceItem       = null;
    #endregion

    #region Component -> Physics 2D
    private TreeNode<MenuItem> mComponent_Physics2dItem                    = null;
    
//  private TreeNode<MenuItem> mComponent_Physics2d_Rigidbody2dItem        = null;

//  private TreeNode<MenuItem> mComponent_Physics2d_CircleCollider2dItem   = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_BoxCollider2dItem      = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_EdgeCollider2dItem     = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_PolygonCollider2dItem  = null;

//  private TreeNode<MenuItem> mComponent_Physics2d_SpringJoint2dItem      = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_DistanceJoint2dItem    = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_HingeJoint2dItem       = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_SliderJoint2dItem      = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_WheelJoint2dItem       = null;

//  private TreeNode<MenuItem> mComponent_Physics2d_ConstantForce2dItem    = null;

//  private TreeNode<MenuItem> mComponent_Physics2d_AreaEffector2dItem     = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_PointEffector2dItem    = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_PlatformEffector2dItem = null;
//  private TreeNode<MenuItem> mComponent_Physics2d_SurfaceEffector2dItem  = null;
    #endregion

    #region Component -> Navigation
    private TreeNode<MenuItem> mComponent_NavigationItem                 = null;
    
//  private TreeNode<MenuItem> mComponent_Navigation_NavMeshAgentItem    = null;
//  private TreeNode<MenuItem> mComponent_Navigation_OffMeshLinkItem     = null;
//  private TreeNode<MenuItem> mComponent_Navigation_NavMeshObstacleItem = null;
    #endregion

    #region Component -> Audio
    private TreeNode<MenuItem> mComponent_AudioItem                       = null;
    
//  private TreeNode<MenuItem> mComponent_Audio_AudioListenerItem         = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioSourceItem           = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioReverbZoneItem       = null;

//  private TreeNode<MenuItem> mComponent_Audio_AudioLowPassFilterItem    = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioHighPassFilterItem   = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioEchoFilterItem       = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioDistortionFilterItem = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioReverbFilterItem     = null;
//  private TreeNode<MenuItem> mComponent_Audio_AudioChorusFilterItem     = null;
    #endregion

    #region Component -> Rendering
    private TreeNode<MenuItem> mComponent_RenderingItem                 = null;
    
//  private TreeNode<MenuItem> mComponent_Rendering_CameraItem          = null;
//  private TreeNode<MenuItem> mComponent_Rendering_SkyboxItem          = null;
//  private TreeNode<MenuItem> mComponent_Rendering_FlareLayerItem      = null;
//  private TreeNode<MenuItem> mComponent_Rendering_GuiLayerItem        = null;

//  private TreeNode<MenuItem> mComponent_Rendering_LightItem           = null;
//  private TreeNode<MenuItem> mComponent_Rendering_LightProbeGroupItem = null;
//  private TreeNode<MenuItem> mComponent_Rendering_ReflectionProbeItem = null;

//  private TreeNode<MenuItem> mComponent_Rendering_OcclusionAreaItem   = null;
//  private TreeNode<MenuItem> mComponent_Rendering_OcclusionPortalItem = null;
//  private TreeNode<MenuItem> mComponent_Rendering_LodGroupItem        = null;

//  private TreeNode<MenuItem> mComponent_Rendering_SpriteRendererItem  = null;
//  private TreeNode<MenuItem> mComponent_Rendering_CanvasRendererItem  = null;

//  private TreeNode<MenuItem> mComponent_Rendering_GuiTextureItem      = null;
//  private TreeNode<MenuItem> mComponent_Rendering_GuiTextItem         = null;
    #endregion

    #region Component -> Layout
    private TreeNode<MenuItem> mComponent_LayoutItem                       = null;
    
//  private TreeNode<MenuItem> mComponent_Layout_RectTransformItem         = null;
//  private TreeNode<MenuItem> mComponent_Layout_CanvasItem                = null;
//  private TreeNode<MenuItem> mComponent_Layout_CanvasGroupItem           = null;

//  private TreeNode<MenuItem> mComponent_Layout_CanvasScalerItem          = null;

//  private TreeNode<MenuItem> mComponent_Layout_LayoutElementItem         = null;
//  private TreeNode<MenuItem> mComponent_Layout_ContentSizeFitterItem     = null;
//  private TreeNode<MenuItem> mComponent_Layout_AspectRatioFitterItem     = null;
//  private TreeNode<MenuItem> mComponent_Layout_HorizontalLayoutGroupItem = null;
//  private TreeNode<MenuItem> mComponent_Layout_VerticalLayoutGroupItem   = null;
//  private TreeNode<MenuItem> mComponent_Layout_GridLayoutGroupItem       = null;
    #endregion

    #region Component -> Miscellaneous
    private TreeNode<MenuItem> mComponent_MiscellaneousItem                   = null;
    
//  private TreeNode<MenuItem> mComponent_Miscellaneous_AnimatorItem          = null;
//  private TreeNode<MenuItem> mComponent_Miscellaneous_AnimationItem         = null;
//  private TreeNode<MenuItem> mComponent_Miscellaneous_NetworkViewItem       = null;
//  private TreeNode<MenuItem> mComponent_Miscellaneous_WindZoneItem          = null;
//  private TreeNode<MenuItem> mComponent_Miscellaneous_TerrainItem           = null;
//  private TreeNode<MenuItem> mComponent_Miscellaneous_BillboardRendererItem = null;
    #endregion

    #region Component -> Event
    private TreeNode<MenuItem> mComponent_EventItem                       = null;
    
//  private TreeNode<MenuItem> mComponent_Event_EventSystemItem           = null;
//  private TreeNode<MenuItem> mComponent_Event_EventTriggerItem          = null;
//  private TreeNode<MenuItem> mComponent_Event_Physics2dRaycasterItem    = null;
//  private TreeNode<MenuItem> mComponent_Event_PhysicsRaycasterItem      = null;
//  private TreeNode<MenuItem> mComponent_Event_StandaloneInputModuleItem = null;
//  private TreeNode<MenuItem> mComponent_Event_TouchInputModuleItem      = null;
//  private TreeNode<MenuItem> mComponent_Event_GraphicRaycasterItem      = null;
    #endregion

    #region Component -> UI
    private TreeNode<MenuItem> mComponent_UiItem = null;

    #region Component -> UI -> Effects
    private TreeNode<MenuItem> mComponent_Ui_EffectsItem               = null;
    
//  private TreeNode<MenuItem> mComponent_Ui_Effects_ShadowItem        = null;
//  private TreeNode<MenuItem> mComponent_Ui_Effects_OutlineItem       = null;
//  private TreeNode<MenuItem> mComponent_Ui_Effects_PositionAsUv1Item = null;
    #endregion
    
//  private TreeNode<MenuItem> mComponent_Ui_ImageItem       = null;
//  private TreeNode<MenuItem> mComponent_Ui_TextItem        = null;
//  private TreeNode<MenuItem> mComponent_Ui_RawImageItem    = null;
//  private TreeNode<MenuItem> mComponent_Ui_MaskItem        = null;

//  private TreeNode<MenuItem> mComponent_Ui_ButtonItem      = null;
//  private TreeNode<MenuItem> mComponent_Ui_InputFieldItem  = null;
//  private TreeNode<MenuItem> mComponent_Ui_ScrollbarItem   = null;
//  private TreeNode<MenuItem> mComponent_Ui_ScrollRectItem  = null;
//  private TreeNode<MenuItem> mComponent_Ui_SliderItem      = null;
//  private TreeNode<MenuItem> mComponent_Ui_ToggleItem      = null;
//  private TreeNode<MenuItem> mComponent_Ui_ToggleGroupItem = null;

//  private TreeNode<MenuItem> mComponent_Ui_SelectableItem  = null;
    #endregion

    #region Component -> Scripts
//  private TreeNode<MenuItem> mComponent_ScriptsItem = null;
    #endregion

    #endregion

    #region Window
    private TreeNode<MenuItem> mWindowMenu                = null;

//  private TreeNode<MenuItem> mWindow_NextWindowItem     = null;
//  private TreeNode<MenuItem> mWindow_PreviousWindowItem = null;

    #region Window -> Layouts
    private TreeNode<MenuItem> mWindow_LayoutsItem                       = null;
    
//  private TreeNode<MenuItem> mWindow_Layouts_2_by_3Item                = null;
//  private TreeNode<MenuItem> mWindow_Layouts_4_splitItem               = null;
//  private TreeNode<MenuItem> mWindow_Layouts_DefaultItem               = null;
//  private TreeNode<MenuItem> mWindow_Layouts_TallItem                  = null;
//  private TreeNode<MenuItem> mWindow_Layouts_WideItem                  = null;

//  private TreeNode<MenuItem> mWindow_Layouts_SaveLayoutItem            = null;
//  private TreeNode<MenuItem> mWindow_Layouts_DeleteLayoutItem          = null;
//  private TreeNode<MenuItem> mWindow_Layouts_RevertFactorySettingsItem = null;
    #endregion

//  private TreeNode<MenuItem> mWindow_SceneItem             = null;
//  private TreeNode<MenuItem> mWindow_GameItem              = null;
//  private TreeNode<MenuItem> mWindow_InspectorItem         = null;
//  private TreeNode<MenuItem> mWindow_HierarchyItem         = null;
//  private TreeNode<MenuItem> mWindow_ProjectItem           = null;
//  private TreeNode<MenuItem> mWindow_AnimationItem         = null;
//  private TreeNode<MenuItem> mWindow_ProfilerItem          = null;
//  private TreeNode<MenuItem> mWindow_AudioMixerItem        = null;
//  private TreeNode<MenuItem> mWindow_AssetStoreItem        = null;
//  private TreeNode<MenuItem> mWindow_VersionControlItem    = null;
//  private TreeNode<MenuItem> mWindow_AnimatorParameterItem = null;
//  private TreeNode<MenuItem> mWindow_AnimatorItem          = null;
//  private TreeNode<MenuItem> mWindow_SpritePackerItem      = null;

//  private TreeNode<MenuItem> mWindow_LightingItem          = null;
//  private TreeNode<MenuItem> mWindow_OcclusionCullingItem  = null;
//  private TreeNode<MenuItem> mWindow_FrameDebuggerItem     = null;
//  private TreeNode<MenuItem> mWindow_NavigationItem        = null;

//  private TreeNode<MenuItem> mWindow_ConsoleItem           = null;
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
        // TODO: REMOVE IT
        Debug.Log(Translator.language);

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
        mFileMenu                 =   MenuItem.Create(mItems,    R.sections.MenuItems.strings.file,                 OnFileMenu);

        /*mFile_NewSceneItem      =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__new_scene,      OnFile_NewScene);
        /*mFile_OpenSceneItem     =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__open_scene,     OnFile_OpenScene);
        MenuItem.InsertSeparator(mFileMenu);
        /*mFile_SaveSceneItem     =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__save_scene,     OnFile_SaveScene);
        /*mFile_SaveSceneAsItem   =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__save_scene_as,  OnFile_SaveSceneAs);
        MenuItem.InsertSeparator(mFileMenu);
        /*mFile_NewProjectItem    =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__new_project,    OnFile_NewProject);
        /*mFile_OpenProjectItem   =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__open_project,   OnFile_OpenProject);
        /*mFile_SaveProjectItem   =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__save_project,   OnFile_SaveProject);
        MenuItem.InsertSeparator(mFileMenu);
        /*mFile_BuildSettingsItem =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__build_settings, OnFile_BuildSettings);
        /*mFile_BuildAndRunItem   =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__build_and_run,  OnFile_BuildAndRun);
        /*mFile_BuildInCloudItem  =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__build_in_cloud, OnFile_BuildInCloud);
        MenuItem.InsertSeparator(mFileMenu);
        /*mFile_ExitItem          =*/ MenuItem.Create(mFileMenu, R.sections.MenuItems.strings.file__exit,           OnFile_Exit);
        #endregion

        #region Edit
        mEditMenu                      =   MenuItem.Create(mItems,    R.sections.MenuItems.strings.edit,                        OnEditMenu);

        /*mEdit_UndoItem               =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__undo,                  OnEdit_Undo); // TODO: Change name of menu item after changes
        /*mEdit_RedoItem               =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__redo,                  OnEdit_Redo); // TODO: Change name of menu item after changes
        MenuItem.InsertSeparator(mEditMenu);
        /*mEdit_CutItem                =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__cut,                   OnEdit_Cut);
        /*mEdit_CopyItem               =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__copy,                  OnEdit_Copy);
        /*mEdit_PasteItem              =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__paste,                 OnEdit_Paste);
        MenuItem.InsertSeparator(mEditMenu);
        /*mEdit_DuplicateItem          =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__duplicate,             OnEdit_Duplicate);
        /*mEdit_DeleteItem             =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__delete,                OnEdit_Delete);
        MenuItem.InsertSeparator(mEditMenu);
        /*mEdit_FrameSelectedItem      =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__frame_selected,        OnEdit_FrameSelected);
        /*mEdit_LockViewToSelectedItem =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__lock_view_to_selected, OnEdit_LockViewToSelected);
        /*mEdit_FindItem               =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__find,                  OnEdit_Find);
        /*mEdit_SelectAllItem          =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__select_all,            OnEdit_SelectAll);
        MenuItem.InsertSeparator(mEditMenu);
        /*mEdit_PreferencesItem        =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__preferences,           OnEdit_Preferences);
        /*mEdit_ModulesItem            =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__modules,               OnEdit_Modules);
        MenuItem.InsertSeparator(mEditMenu);
        /*mEdit_PlayItem               =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__play,                  OnEdit_Play);
        /*mEdit_PauseItem              =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__pause,                 OnEdit_Pause);
        /*mEdit_StepItem               =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__step,                  OnEdit_Step);
        MenuItem.InsertSeparator(mEditMenu);

        #region Edit -> Selection
        mEdit_SelectionItem                  =   MenuItem.Create(mEditMenu,           R.sections.MenuItems.strings.edit__selection);

        /*mEdit_Selection_LoadSelection1Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_1, OnEdit_Selection_LoadSelection1);
        /*mEdit_Selection_LoadSelection2Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_2, OnEdit_Selection_LoadSelection2);
        /*mEdit_Selection_LoadSelection3Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_3, OnEdit_Selection_LoadSelection3);
        /*mEdit_Selection_LoadSelection4Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_4, OnEdit_Selection_LoadSelection4);
        /*mEdit_Selection_LoadSelection5Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_5, OnEdit_Selection_LoadSelection5);
        /*mEdit_Selection_LoadSelection6Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_6, OnEdit_Selection_LoadSelection6);
        /*mEdit_Selection_LoadSelection7Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_7, OnEdit_Selection_LoadSelection7);
        /*mEdit_Selection_LoadSelection8Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_8, OnEdit_Selection_LoadSelection8);
        /*mEdit_Selection_LoadSelection9Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_9, OnEdit_Selection_LoadSelection9);
        /*mEdit_Selection_LoadSelection0Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_0, OnEdit_Selection_LoadSelection0);

        /*mEdit_Selection_SaveSelection1Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_1, OnEdit_Selection_SaveSelection1);
        /*mEdit_Selection_SaveSelection2Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_2, OnEdit_Selection_SaveSelection2);
        /*mEdit_Selection_SaveSelection3Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_3, OnEdit_Selection_SaveSelection3);
        /*mEdit_Selection_SaveSelection4Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_4, OnEdit_Selection_SaveSelection4);
        /*mEdit_Selection_SaveSelection5Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_5, OnEdit_Selection_SaveSelection5);
        /*mEdit_Selection_SaveSelection6Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_6, OnEdit_Selection_SaveSelection6);
        /*mEdit_Selection_SaveSelection7Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_7, OnEdit_Selection_SaveSelection7);
        /*mEdit_Selection_SaveSelection8Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_8, OnEdit_Selection_SaveSelection8);
        /*mEdit_Selection_SaveSelection9Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_9, OnEdit_Selection_SaveSelection9);
        /*mEdit_Selection_SaveSelection0Item =*/ MenuItem.Create(mEdit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_0, OnEdit_Selection_SaveSelection0);
        #endregion

        MenuItem.InsertSeparator(mEditMenu);

        #region Edit -> Project Settings
        mEdit_ProjectSettingsItem                        =   MenuItem.Create(mEditMenu,                 R.sections.MenuItems.strings.edit__project_settings);

        /*mEdit_ProjectSettings_InputItem                =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__input,                  OnEdit_ProjectSettings_Input);
        /*mEdit_ProjectSettings_TagsAndLayersItem        =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__tags_and_layers,        OnEdit_ProjectSettings_TagsAndLayers);
        /*mEdit_ProjectSettings_AudioItem                =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__audio,                  OnEdit_ProjectSettings_Audio);
        /*mEdit_ProjectSettings_TimeItem                 =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__time,                   OnEdit_ProjectSettings_Time);
        /*mEdit_ProjectSettings_PlayerItem               =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__player,                 OnEdit_ProjectSettings_Player);
        /*mEdit_ProjectSettings_PhysicsItem              =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__physics,                OnEdit_ProjectSettings_Physics);
        /*mEdit_ProjectSettings_Physics2DItem            =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__physics_2d,             OnEdit_ProjectSettings_Physics2D);
        /*mEdit_ProjectSettings_QualityItem              =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__quality,                OnEdit_ProjectSettings_Quality);
        /*mEdit_ProjectSettings_GraphicsItem             =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__graphics,               OnEdit_ProjectSettings_Graphics);
        /*mEdit_ProjectSettings_NetworkItem              =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__network,                OnEdit_ProjectSettings_Network);
        /*mEdit_ProjectSettings_EditorItem               =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__editor,                 OnEdit_ProjectSettings_Editor);
        /*mEdit_ProjectSettings_ScriptExecutionOrderItem =*/ MenuItem.Create(mEdit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__script_execution_order, OnEdit_ProjectSettings_ScriptExecutionOrder);
        #endregion

        MenuItem.InsertSeparator(mEditMenu);

        #region Edit -> Network Emulation
        mEdit_NetworkEmulationItem                             =   MenuItem.Create(mEditMenu,                  R.sections.MenuItems.strings.edit__network_emulation);

        /*mEdit_NetworkEmulation_NetworkEmulationNoneItem      =*/ MenuItem.Create(mEdit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__none,      OnEdit_NetworkEmulation_None);
        /*mEdit_NetworkEmulation_NetworkEmulationBroadbandItem =*/ MenuItem.Create(mEdit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__broadband, OnEdit_NetworkEmulation_Broadband);
        /*mEdit_NetworkEmulation_NetworkEmulationDSLItem       =*/ MenuItem.Create(mEdit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__dsl,       OnEdit_NetworkEmulation_DSL);
        /*mEdit_NetworkEmulation_NetworkEmulationISDNItem      =*/ MenuItem.Create(mEdit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__isdn,      OnEdit_NetworkEmulation_ISDN);
        /*mEdit_NetworkEmulation_NetworkEmulationDialUpItem    =*/ MenuItem.Create(mEdit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__dial_up,   OnEdit_NetworkEmulation_DialUp);
        #endregion

        #region Edit -> Graphics Emulation
        mEdit_GraphicsEmulationItem                                 =   MenuItem.Create(mEditMenu,                   R.sections.MenuItems.strings.edit__graphics_emulation);

        /*mEdit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  =*/ MenuItem.Create(mEdit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__no_emulation,   OnEdit_GraphicsEmulation_NoEmulation);
        /*mEdit_GraphicsEmulation_GraphicsEmulationShaderModel3Item =*/ MenuItem.Create(mEdit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__shader_model_3, OnEdit_GraphicsEmulation_ShaderModel3);
        /*mEdit_GraphicsEmulation_GraphicsEmulationShaderModel2Item =*/ MenuItem.Create(mEdit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__shader_model_2, OnEdit_GraphicsEmulation_ShaderModel2);
        #endregion

        MenuItem.InsertSeparator(mEditMenu);
        /*mEdit_SnapSettingsItem =*/ MenuItem.Create(mEditMenu, R.sections.MenuItems.strings.edit__snap_settings, OnEdit_SnapSettings);
        #endregion

        #region Assets
        mAssetsMenu = MenuItem.Create(mItems, R.sections.MenuItems.strings.assets, OnAssetsMenu);

        #region Assets -> Create
        mAssets_CreateItem                             =   MenuItem.Create(mAssetsMenu,        R.sections.MenuItems.strings.assets__create);

        /*mAssets_Create_FolderItem                    =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__folder,                      OnAssets_Create_Folder);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_CSharpScriptItem              =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__c_sharp_script,              OnAssets_Create_CSharpScript);
        /*mAssets_Create_JavascriptItem                =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__javascript,                  OnAssets_Create_Javascript);
        /*mAssets_Create_ShaderItem                    =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__shader,                      OnAssets_Create_Shader);
        /*mAssets_Create_ComputeShaderItem             =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__compute_shader,              OnAssets_Create_ComputeShader);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_PrefabItem                    =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__prefab,                      OnAssets_Create_Prefab);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_AudioMixerItem                =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__audio_mixer,                 OnAssets_Create_AudioMixer);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_MaterialItem                  =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__material,                    OnAssets_Create_Material);
        /*mAssets_Create_LensFlareItem                 =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__lens_flare,                  OnAssets_Create_LensFlare);
        /*mAssets_Create_RenderTextureItem             =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__render_texture,              OnAssets_Create_RenderTexture);
        /*mAssets_Create_LightmapParametersItem        =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__lightmap_parameters,         OnAssets_Create_LightmapParameters);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_AnimatorControllerItem        =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__animator_controller,         OnAssets_Create_AnimatorController);
        /*mAssets_Create_AnimationItem                 =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__animation,                   OnAssets_Create_Animation);
        /*mAssets_Create_AnimatorOverrideContollerItem =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__animator_override_contoller, OnAssets_Create_AnimatorOverrideContoller);
        /*mAssets_Create_AvatarMaskItem                =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__avatar_mask,                 OnAssets_Create_AvatarMask);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_PhysicMaterialItem            =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__physic_material,             OnAssets_Create_PhysicMaterial);
        /*mAssets_Create_Physic2dMaterialItem          =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__physic2d_material,           OnAssets_Create_Physic2dMaterial);
        MenuItem.InsertSeparator(mAssets_CreateItem);
        /*mAssets_Create_GuiSkinItem                   =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__gui_skin,                    OnAssets_Create_GuiSkin);
        /*mAssets_Create_CustomFontItem                =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__custom_font,                 OnAssets_Create_CustomFont);
        /*mAssets_Create_ShaderVariantCollectionItem   =*/ MenuItem.Create(mAssets_CreateItem, R.sections.MenuItems.strings.assets__create__shader_variant_collection,   OnAssets_Create_ShaderVariantCollection);

        #region Assets -> Create -> Legacy
        mAssets_Create_LegacyItem                      =   MenuItem.Create(mAssets_CreateItem,        R.sections.MenuItems.strings.assets__create__legacy);

        /*mAssets_Create_Legacy_CubemapItem            =*/ MenuItem.Create(mAssets_Create_LegacyItem, R.sections.MenuItems.strings.assets__create__legacy__cubemap, OnAssets_Create_Legacy_Cubemap);
        #endregion

        #endregion

        /*mAssets_ShowInExplorerItem =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__show_in_explorer, OnAssets_ShowInExplorer);
        /*mAssets_OpenItem           =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__open,             OnAssets_Open);
        /*mAssets_DeleteItem         =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__delete,           OnAssets_Delete);
        MenuItem.InsertSeparator(mAssetsMenu);
        /*mAssets_ImportNewAssetItem =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__import_new_asset, OnAssets_ImportNewAsset);

        #region Assets -> Import Package
        mAssets_ImportPackageItem                           =   MenuItem.Create(mAssetsMenu,               R.sections.MenuItems.strings.assets__import_package);

        /*mAssets_ImportPackage_CustomPackageItem           =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__custom_package,       OnAssets_ImportPackage_CustomPackage);
        MenuItem.InsertSeparator(mAssets_ImportPackageItem);
        /*mAssets_ImportPackage_2dItem                      =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__2d,                   OnAssets_ImportPackage_2d);
        /*mAssets_ImportPackage_CamerasItem                 =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__cameras,              OnAssets_ImportPackage_Cameras);
        /*mAssets_ImportPackage_CharactersItem              =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__characters,           OnAssets_ImportPackage_Characters);
        /*mAssets_ImportPackage_CrossPlatformInputItem      =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__cross_platform_input, OnAssets_ImportPackage_CrossPlatformInput);
        /*mAssets_ImportPackage_EffectsItem                 =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__effects,              OnAssets_ImportPackage_Effects);
        /*mAssets_ImportPackage_EnvironmentItem             =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__environment,          OnAssets_ImportPackage_Environment);
        /*mAssets_ImportPackage_ParticleSystemsItem         =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__particle_systems,     OnAssets_ImportPackage_ParticleSystems);
        /*mAssets_ImportPackage_PrototypingItem             =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__prototyping,          OnAssets_ImportPackage_Prototyping);
        /*mAssets_ImportPackage_UtilityItem                 =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__utility,              OnAssets_ImportPackage_Utility);
        /*mAssets_ImportPackage_VehiclesItem                =*/ MenuItem.Create(mAssets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__vehicles,             OnAssets_ImportPackage_Vehicles);
        #endregion

        /*mAssets_ExportPackageItem          =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__export_package,           OnAssets_ExportPackage);
        /*mAssets_FindReferencesInSceneItem  =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__find_references_in_scene, OnAssets_FindReferencesInScene);
        /*mAssets_SelectDependenciesItem     =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__select_dependencies,      OnAssets_SelectDependencies);
        MenuItem.InsertSeparator(mAssetsMenu);
        /*mAssets_RefreshItem                =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__refresh,                  OnAssets_Refresh);
        /*mAssets_ReimportItem               =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__reimport,                 OnAssets_Reimport);
        MenuItem.InsertSeparator(mAssetsMenu);
        /*mAssets_ReimportAllItem            =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__reimport_all,             OnAssets_ReimportAll);
        MenuItem.InsertSeparator(mAssetsMenu);
        /*mAssets_RunApiUpdaterItem          =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__run_api_updater,          OnAssets_RunApiUpdater);
        MenuItem.InsertSeparator(mAssetsMenu);
        /*mAssets_SyncMonoDevelopProjectItem =*/ MenuItem.Create(mAssetsMenu, R.sections.MenuItems.strings.assets__sync_monodevelop_project, OnAssets_SyncMonoDevelopProject);
        #endregion

        #region GameObject
        mGameObjectMenu                    =   MenuItem.Create(mItems,          R.sections.MenuItems.strings.gameobject, OnGameObjectMenu);

        /*mGameObject_CreateEmptyItem      =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__create_empty,       OnGameObject_CreateEmpty);
        /*mGameObject_CreateEmptyChildItem =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__create_empty_child, OnGameObject_CreateEmptyChild);
        
        #region GameObject -> 3D Object    
        mGameObject_3dObjectItem            =   MenuItem.Create(mGameObjectMenu,          R.sections.MenuItems.strings.gameobject__3d_object);
        
        /*mGameObject_3dObject_CubeItem     =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__cube,      OnGameObject_3dObject_Cube);
        /*mGameObject_3dObject_SphereItem   =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__sphere,    OnGameObject_3dObject_Sphere);
        /*mGameObject_3dObject_CapsuleItem  =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__capsule,   OnGameObject_3dObject_Capsule);
        /*mGameObject_3dObject_CylinderItem =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__cylinder,  OnGameObject_3dObject_Cylinder);
        /*mGameObject_3dObject_PlaneItem    =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__plane,     OnGameObject_3dObject_Plane);
        /*mGameObject_3dObject_QuadItem     =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__quad,      OnGameObject_3dObject_Quad);
        MenuItem.InsertSeparator(mGameObject_3dObjectItem);
        /*mGameObject_3dObject_RagdollItem  =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__ragdoll,   OnGameObject_3dObject_Ragdoll);
        MenuItem.InsertSeparator(mGameObject_3dObjectItem);
        /*mGameObject_3dObject_TerrainItem  =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__terrain,   OnGameObject_3dObject_Terrain);
        /*mGameObject_3dObject_TreeItem     =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__tree,      OnGameObject_3dObject_Tree);
        /*mGameObject_3dObject_WindZoneItem =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__wind_zone, OnGameObject_3dObject_WindZone);
        
        /*mGameObject_3dObject_3dTextItem   =*/ MenuItem.Create(mGameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__3d_text,   OnGameObject_3dObject_3dText);
        #endregion
        
        #region GameObject -> 2D Object    
        mGameObject_2dObjectItem          =   MenuItem.Create(mGameObjectMenu,          R.sections.MenuItems.strings.gameobject__2d_object);
        
        /*mGameObject_2dObject_SpriteItem =*/ MenuItem.Create(mGameObject_2dObjectItem, R.sections.MenuItems.strings.gameobject__2d_object__sprite, OnGameObject_2dObject_Sprite);
        #endregion
        
        #region GameObject -> Light
        mGameObject_LightItem                    =   MenuItem.Create(mGameObjectMenu,       R.sections.MenuItems.strings.gameobject__light);
        
        /*mGameObject_Light_DirectionalLightItem =*/ MenuItem.Create(mGameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__directional_light, OnGameObject_Light_DirectionalLight);
        /*mGameObject_Light_PointLightItem       =*/ MenuItem.Create(mGameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__point_light,       OnGameObject_Light_PointLight);
        /*mGameObject_Light_SpotlightItem        =*/ MenuItem.Create(mGameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__spotlight,         OnGameObject_Light_Spotlight);
        /*mGameObject_Light_AreaLightItem        =*/ MenuItem.Create(mGameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__area_light,        OnGameObject_Light_AreaLight);
        MenuItem.InsertSeparator(mGameObject_LightItem);
        /*mGameObject_Light_ReflectionProbeItem  =*/ MenuItem.Create(mGameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__reflection_probe,  OnGameObject_Light_ReflectionProbe);
        /*mGameObject_Light_LightProbeGroupItem  =*/ MenuItem.Create(mGameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__light_probe_group, OnGameObject_Light_LightProbeGroup);
        #endregion
        
        #region GameObject -> Audio
        mGameObject_AudioItem                   =   MenuItem.Create(mGameObjectMenu,       R.sections.MenuItems.strings.gameobject__audio);
        
        /*mGameObject_Audio_AudioSourceItem     =*/ MenuItem.Create(mGameObject_AudioItem, R.sections.MenuItems.strings.gameobject__audio__audio_source,      OnGameObject_Audio_AudioSource);
        /*mGameObject_Audio_AudioReverbZoneItem =*/ MenuItem.Create(mGameObject_AudioItem, R.sections.MenuItems.strings.gameobject__audio__audio_reverb_zone, OnGameObject_Audio_AudioReverbZone);
        #endregion
        
        #region GameObject -> UI
        mGameObject_UiItem               =   MenuItem.Create(mGameObjectMenu,    R.sections.MenuItems.strings.gameobject__ui);
        
        /*mGameObject_Ui_PanelItem       =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__panel,        OnGameObject_Ui_Panel);
        /*mGameObject_Ui_ButtonItem      =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__button,       OnGameObject_Ui_Button);
        /*mGameObject_Ui_TextItem        =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__text,         OnGameObject_Ui_Text);
        /*mGameObject_Ui_ImageItem       =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__image,        OnGameObject_Ui_Image);
        /*mGameObject_Ui_RawImageItem    =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__raw_image,    OnGameObject_Ui_RawImage);
        /*mGameObject_Ui_SliderItem      =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__slider,       OnGameObject_Ui_Slider);
        /*mGameObject_Ui_ScrollbarItem   =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__scrollbar,    OnGameObject_Ui_Scrollbar);
        /*mGameObject_Ui_ToggleItem      =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__toggle,       OnGameObject_Ui_Toggle);
        /*mGameObject_Ui_InputFieldItem  =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__input_field,  OnGameObject_Ui_InputField);
        /*mGameObject_Ui_CanvasItem      =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__canvas,       OnGameObject_Ui_Canvas);
        /*mGameObject_Ui_EventSystemItem =*/ MenuItem.Create(mGameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__event_system, OnGameObject_Ui_EventSystem);
        #endregion
        
        /*mGameObject_ParticleSystemItem       =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__particle_system,         OnGameObject_ParticleSystem);
        /*mGameObject_CameraItem               =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__camera,                  OnGameObject_Camera);
        MenuItem.InsertSeparator(mGameObjectMenu);
        /*mGameObject_CenterOnChildrenItem     =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__center_on_children,      OnGameObject_CenterOnChildren);
        MenuItem.InsertSeparator(mGameObjectMenu);
        /*mGameObject_MakeParentItem           =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__make_parent,             OnGameObject_MakeParent);
        /*mGameObject_ClearParentItem          =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__clear_parent,            OnGameObject_ClearParent);
        /*mGameObject_ApplyChangesToPrefabItem =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__apply_changes_to_prefab, OnGameObject_ApplyChangesToPrefab);
        /*mGameObject_BreakPrefabInstanceItem  =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__break_prefab_instance,   OnGameObject_BreakPrefabInstance);
        MenuItem.InsertSeparator(mGameObjectMenu);
        /*mGameObject_SetAsFirstSiblingItem    =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__set_as_first_sibling,    OnGameObject_SetAsFirstSibling);
        /*mGameObject_SetAsLastSiblingItem     =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__set_as_last_sibling,     OnGameObject_SetAsLastSibling);
        /*mGameObject_MoveToViewItem           =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__move_to_view,            OnGameObject_MoveToView);
        /*mGameObject_AlignWithViewItem        =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__align_with_view,         OnGameObject_AlignWithView);
        /*mGameObject_AlignViewToSelectedItem  =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__align_view_to_selected,  OnGameObject_AlignViewToSelected);
        /*mGameObject_ToggleActiveStateItem    =*/ MenuItem.Create(mGameObjectMenu, R.sections.MenuItems.strings.gameobject__toggle_active_state,     OnGameObject_ToggleActiveState);
        #endregion

        #region Component
        mComponentMenu       =   MenuItem.Create(mItems,         R.sections.MenuItems.strings.component,      OnComponentMenu);

        /*mComponent_AddItem =*/ MenuItem.Create(mComponentMenu, R.sections.MenuItems.strings.component__add, OnComponent_Add);
        
        #region Component -> Mesh
        mComponent_MeshItem                       =   MenuItem.Create(mComponentMenu,      R.sections.MenuItems.strings.component__mesh);
        
        /*mComponent_Mesh_MeshFilterItem          =*/ MenuItem.Create(mComponent_MeshItem, R.sections.MenuItems.strings.component__mesh__mesh_filter,           OnComponent_Mesh_MeshFilter);
        /*mComponent_Mesh_TextMeshItem            =*/ MenuItem.Create(mComponent_MeshItem, R.sections.MenuItems.strings.component__mesh__text_mesh,             OnComponent_Mesh_TextMesh);
        MenuItem.InsertSeparator(mComponent_MeshItem);
        /*mComponent_Mesh_MeshRendererItem        =*/ MenuItem.Create(mComponent_MeshItem, R.sections.MenuItems.strings.component__mesh__mesh_renderer,         OnComponent_Mesh_MeshRenderer);
        /*mComponent_Mesh_SkinnedMeshRendererItem =*/ MenuItem.Create(mComponent_MeshItem, R.sections.MenuItems.strings.component__mesh__skinned_mesh_renderer, OnComponent_Mesh_SkinnedMeshRenderer);
        #endregion
        
        #region Component -> Effects
        mComponent_EffectsItem                  =   MenuItem.Create(mComponentMenu,         R.sections.MenuItems.strings.component__effects);
        
        /*mComponent_Effects_ParticleSystemItem =*/ MenuItem.Create(mComponent_EffectsItem, R.sections.MenuItems.strings.component__effects__particle_system, OnComponent_Effects_ParticleSystem);
        /*mComponent_Effects_TrailRendererItem  =*/ MenuItem.Create(mComponent_EffectsItem, R.sections.MenuItems.strings.component__effects__trail_renderer,  OnComponent_Effects_TrailRenderer);
        /*mComponent_Effects_LineRendererItem   =*/ MenuItem.Create(mComponent_EffectsItem, R.sections.MenuItems.strings.component__effects__line_renderer,   OnComponent_Effects_LineRenderer);
        /*mComponent_Effects_LensFlareItem      =*/ MenuItem.Create(mComponent_EffectsItem, R.sections.MenuItems.strings.component__effects__lens_flare,      OnComponent_Effects_LensFlare);
        /*mComponent_Effects_HaloItem           =*/ MenuItem.Create(mComponent_EffectsItem, R.sections.MenuItems.strings.component__effects__halo,            OnComponent_Effects_Halo);
        /*mComponent_Effects_ProjectorItem      =*/ MenuItem.Create(mComponent_EffectsItem, R.sections.MenuItems.strings.component__effects__projector,       OnComponent_Effects_Projector);
        MenuItem.InsertSeparator(mComponent_MeshItem);

        #region Component -> Effects -> Legacy Particles
        mComponent_Effects_LegacyParticlesItem                            =   MenuItem.Create(mComponent_EffectsItem,                 R.sections.MenuItems.strings.component__effects__legacy_particles);
        
        /*mComponent_Effects_LegacyParticles_EllipsoidParticleEmitterItem =*/ MenuItem.Create(mComponent_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__ellipsoid_particle_emitter, OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter);
        /*mComponent_Effects_LegacyParticles_MeshParticleEmitterItem      =*/ MenuItem.Create(mComponent_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__mesh_particle_emitter,      OnComponent_Effects_LegacyParticles_MeshParticleEmitter);
        MenuItem.InsertSeparator(mComponent_Effects_LegacyParticlesItem);
        /*mComponent_Effects_LegacyParticles_ParticleAnimatorItem         =*/ MenuItem.Create(mComponent_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__particle_animator,          OnComponent_Effects_LegacyParticles_ParticleAnimator);
        /*mComponent_Effects_LegacyParticles_WorldParticleColliderItem    =*/ MenuItem.Create(mComponent_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__world_particle_collider,    OnComponent_Effects_LegacyParticles_WorldParticleCollider);
        MenuItem.InsertSeparator(mComponent_Effects_LegacyParticlesItem);
        /*mComponent_Effects_LegacyParticles_ParticleRendererItem         =*/ MenuItem.Create(mComponent_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__particle_renderer,          OnComponent_Effects_LegacyParticles_ParticleRenderer);
        #endregion
        
        #endregion
        
        #region Component -> Physics
        mComponent_PhysicsItem                       =   MenuItem.Create(mComponentMenu,         R.sections.MenuItems.strings.component__physics);
        
        /*mComponent_Physics_RigidbodyItem           =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__rigidbody,            OnComponent_Physics_Rigidbody);
        /*mComponent_Physics_CharacterControllerItem =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__character_controller, OnComponent_Physics_CharacterController);
        MenuItem.InsertSeparator(mComponent_PhysicsItem);
        /*mComponent_Physics_BoxColliderItem         =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__box_collider,         OnComponent_Physics_BoxCollider);
        /*mComponent_Physics_SphereColliderItem      =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__sphere_collider,      OnComponent_Physics_SphereCollider);
        /*mComponent_Physics_CapsuleColliderItem     =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__capsule_collider,     OnComponent_Physics_CapsuleCollider);
        /*mComponent_Physics_MeshColliderItem        =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__mesh_collider,        OnComponent_Physics_MeshCollider);
        /*mComponent_Physics_WheelColliderItem       =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__wheel_collider,       OnComponent_Physics_WheelCollider);
        /*mComponent_Physics_TerrainColliderItem     =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__terrain_collider,     OnComponent_Physics_TerrainCollider);
        MenuItem.InsertSeparator(mComponent_PhysicsItem);
        /*mComponent_Physics_ClothItem               =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__cloth,                OnComponent_Physics_Cloth);
        MenuItem.InsertSeparator(mComponent_PhysicsItem);
        /*mComponent_Physics_HingeJointItem          =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__hinge_joint,          OnComponent_Physics_HingeJoint);
        /*mComponent_Physics_FixedJointItem          =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__fixed_joint,          OnComponent_Physics_FixedJoint);
        /*mComponent_Physics_SpringJointItem         =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__spring_joint,         OnComponent_Physics_SpringJoint);
        /*mComponent_Physics_CharacterJointItem      =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__character_joint,      OnComponent_Physics_CharacterJoint);
        /*mComponent_Physics_ConfigurableJointItem   =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__configurable_joint,   OnComponent_Physics_ConfigurableJoint);
        MenuItem.InsertSeparator(mComponent_PhysicsItem);
        /*mComponent_Physics_ConstantForceItem       =*/ MenuItem.Create(mComponent_PhysicsItem, R.sections.MenuItems.strings.component__physics__constant_force,       OnComponent_Physics_ConstantForce);
        #endregion
        
        #region Component -> Physics 2D
        mComponent_Physics2dItem                      =   MenuItem.Create(mComponentMenu,           R.sections.MenuItems.strings.component__physics_2d);
        
        /*mComponent_Physics2d_Rigidbody2dItem        =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__rigidbody_2d,         OnComponent_Physics2d_Rigidbody2d);
        MenuItem.InsertSeparator(mComponent_Physics2dItem);
        /*mComponent_Physics2d_CircleCollider2dItem   =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__circle_collider_2d,   OnComponent_Physics2d_CircleCollider2d);
        /*mComponent_Physics2d_BoxCollider2dItem      =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__box_collider_2d,      OnComponent_Physics2d_BoxCollider2d);
        /*mComponent_Physics2d_EdgeCollider2dItem     =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__edge_collider_2d,     OnComponent_Physics2d_EdgeCollider2d);
        /*mComponent_Physics2d_PolygonCollider2dItem  =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__polygon_collider_2d,  OnComponent_Physics2d_PolygonCollider2d);
        MenuItem.InsertSeparator(mComponent_Physics2dItem);
        /*mComponent_Physics2d_SpringJoint2dItem      =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__spring_joint_2d,      OnComponent_Physics2d_SpringJoint2d);
        /*mComponent_Physics2d_DistanceJoint2dItem    =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__distance_joint_2d,    OnComponent_Physics2d_DistanceJoint2d);
        /*mComponent_Physics2d_HingeJoint2dItem       =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__hinge_joint_2d,       OnComponent_Physics2d_HingeJoint2d);
        /*mComponent_Physics2d_SliderJoint2dItem      =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__slider_joint_2d,      OnComponent_Physics2d_SliderJoint2d);
        /*mComponent_Physics2d_WheelJoint2dItem       =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__wheel_joint_2d,       OnComponent_Physics2d_WheelJoint2d);
        MenuItem.InsertSeparator(mComponent_Physics2dItem);
        /*mComponent_Physics2d_ConstantForce2dItem    =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__constant_force_2d,    OnComponent_Physics2d_ConstantForce2d);
        MenuItem.InsertSeparator(mComponent_Physics2dItem);
        /*mComponent_Physics2d_AreaEffector2dItem     =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__area_effector_2d,     OnComponent_Physics2d_AreaEffector2d);
        /*mComponent_Physics2d_PointEffector2dItem    =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__point_effector_2d,    OnComponent_Physics2d_PointEffector2d);
        /*mComponent_Physics2d_PlatformEffector2dItem =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__platform_effector_2d, OnComponent_Physics2d_PlatformEffector2d);
        /*mComponent_Physics2d_SurfaceEffector2dItem  =*/ MenuItem.Create(mComponent_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__surface_effector_2d,  OnComponent_Physics2d_SurfaceEffector2d);
        #endregion
        
        #region Component -> Navigation
        mComponent_NavigationItem                   =   MenuItem.Create(mComponentMenu,            R.sections.MenuItems.strings.component__navigation);
        
        /*mComponent_Navigation_NavMeshAgentItem    =*/ MenuItem.Create(mComponent_NavigationItem, R.sections.MenuItems.strings.component__navigation__nav_mesh_agent,    OnComponent_Navigation_NavMeshAgent);
        /*mComponent_Navigation_OffMeshLinkItem     =*/ MenuItem.Create(mComponent_NavigationItem, R.sections.MenuItems.strings.component__navigation__off_mesh_link,     OnComponent_Navigation_OffMeshLink);
        /*mComponent_Navigation_NavMeshObstacleItem =*/ MenuItem.Create(mComponent_NavigationItem, R.sections.MenuItems.strings.component__navigation__nav_mesh_obstacle, OnComponent_Navigation_NavMeshObstacle);
        #endregion
        
        #region Component -> Audio
        mComponent_AudioItem                         =   MenuItem.Create(mComponentMenu,       R.sections.MenuItems.strings.component__audio);
        
        /*mComponent_Audio_AudioListenerItem         =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_listener,          OnComponent_Audio_AudioListener);
        /*mComponent_Audio_AudioSourceItem           =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_source,            OnComponent_Audio_AudioSource);
        /*mComponent_Audio_AudioReverbZoneItem       =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_reverb_zone,       OnComponent_Audio_AudioReverbZone);
        MenuItem.InsertSeparator(mComponent_AudioItem);
        /*mComponent_Audio_AudioLowPassFilterItem    =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_low_pass_filter,   OnComponent_Audio_AudioLowPassFilter);
        /*mComponent_Audio_AudioHighPassFilterItem   =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_high_pass_filter,  OnComponent_Audio_AudioHighPassFilter);
        /*mComponent_Audio_AudioEchoFilterItem       =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_echo_filter,       OnComponent_Audio_AudioEchoFilter);
        /*mComponent_Audio_AudioDistortionFilterItem =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_distortion_filter, OnComponent_Audio_AudioDistortionFilter);
        /*mComponent_Audio_AudioReverbFilterItem     =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_reverb_filter,     OnComponent_Audio_AudioReverbFilter);
        /*mComponent_Audio_AudioChorusFilterItem     =*/ MenuItem.Create(mComponent_AudioItem, R.sections.MenuItems.strings.component__audio__audio_chorus_filter,     OnComponent_Audio_AudioChorusFilter);
        #endregion
        
        #region Component -> Rendering
        mComponent_RenderingItem                   =   MenuItem.Create(mComponentMenu,           R.sections.MenuItems.strings.component__rendering);
        
        /*mComponent_Rendering_CameraItem          =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__camera,            OnComponent_Rendering_Camera);
        /*mComponent_Rendering_SkyboxItem          =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__skybox,            OnComponent_Rendering_Skybox);
        /*mComponent_Rendering_FlareLayerItem      =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__flare_layer,       OnComponent_Rendering_FlareLayer);
        /*mComponent_Rendering_GuiLayerItem        =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_layer,         OnComponent_Rendering_GuiLayer);
        MenuItem.InsertSeparator(mComponent_RenderingItem);
        /*mComponent_Rendering_LightItem           =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__light,             OnComponent_Rendering_Light);
        /*mComponent_Rendering_LightProbeGroupItem =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__light_probe_group, OnComponent_Rendering_LightProbeGroup);
        /*mComponent_Rendering_ReflectionProbeItem =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__reflection_probe,  OnComponent_Rendering_ReflectionProbe);
        MenuItem.InsertSeparator(mComponent_RenderingItem);
        /*mComponent_Rendering_OcclusionAreaItem   =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__occlusion_area,    OnComponent_Rendering_OcclusionArea);
        /*mComponent_Rendering_OcclusionPortalItem =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__occlusion_portal,  OnComponent_Rendering_OcclusionPortal);
        /*mComponent_Rendering_LodGroupItem        =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__lod_group,         OnComponent_Rendering_LodGroup);
        MenuItem.InsertSeparator(mComponent_RenderingItem);
        /*mComponent_Rendering_SpriteRendererItem  =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__sprite_renderer,   OnComponent_Rendering_SpriteRenderer);
        /*mComponent_Rendering_CanvasRendererItem  =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__canvas_renderer,   OnComponent_Rendering_CanvasRenderer);
        MenuItem.InsertSeparator(mComponent_RenderingItem);
        /*mComponent_Rendering_GuiTextureItem      =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_texture,       OnComponent_Rendering_GuiTexture);
        /*mComponent_Rendering_GuiTextItem         =*/ MenuItem.Create(mComponent_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_text,          OnComponent_Rendering_GuiText);
        #endregion
        
        #region Component -> Layout
        mComponent_LayoutItem                         =   MenuItem.Create(mComponentMenu,        R.sections.MenuItems.strings.component__layout);
        
        /*mComponent_Layout_RectTransformItem         =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__rect_transform,          OnComponent_Layout_RectTransform);
        /*mComponent_Layout_CanvasItem                =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas,                  OnComponent_Layout_Canvas);
        /*mComponent_Layout_CanvasGroupItem           =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas_group,            OnComponent_Layout_CanvasGroup);
        MenuItem.InsertSeparator(mComponent_LayoutItem);
        /*mComponent_Layout_CanvasScalerItem          =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas_scaler,           OnComponent_Layout_CanvasScaler);
        MenuItem.InsertSeparator(mComponent_LayoutItem);
        /*mComponent_Layout_LayoutElementItem         =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__layout_element,          OnComponent_Layout_LayoutElement);
        /*mComponent_Layout_ContentSizeFitterItem     =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__content_size_fitter,     OnComponent_Layout_ContentSizeFitter);
        /*mComponent_Layout_AspectRatioFitterItem     =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__aspect_ratio_fitter,     OnComponent_Layout_AspectRatioFitter);
        /*mComponent_Layout_HorizontalLayoutGroupItem =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__horizontal_layout_group, OnComponent_Layout_HorizontalLayoutGroup);
        /*mComponent_Layout_VerticalLayoutGroupItem   =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__vertical_layout_group,   OnComponent_Layout_VerticalLayoutGroup);
        /*mComponent_Layout_GridLayoutGroupItem       =*/ MenuItem.Create(mComponent_LayoutItem, R.sections.MenuItems.strings.component__layout__grid_layout_group,       OnComponent_Layout_GridLayoutGroup);
        #endregion
        
        #region Component -> Miscellaneous
        mComponent_MiscellaneousItem                     =   MenuItem.Create(mComponentMenu,               R.sections.MenuItems.strings.component__miscellaneous);
        
        /*mComponent_Miscellaneous_AnimatorItem          =*/ MenuItem.Create(mComponent_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__animator,           OnComponent_Miscellaneous_Animator);
        /*mComponent_Miscellaneous_AnimationItem         =*/ MenuItem.Create(mComponent_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__animation,          OnComponent_Miscellaneous_Animation);
        /*mComponent_Miscellaneous_NetworkViewItem       =*/ MenuItem.Create(mComponent_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__network_view,       OnComponent_Miscellaneous_NetworkView);
        /*mComponent_Miscellaneous_WindZoneItem          =*/ MenuItem.Create(mComponent_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__wind_zone,          OnComponent_Miscellaneous_WindZone);
        /*mComponent_Miscellaneous_TerrainItem           =*/ MenuItem.Create(mComponent_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__terrain,            OnComponent_Miscellaneous_Terrain);
        /*mComponent_Miscellaneous_BillboardRendererItem =*/ MenuItem.Create(mComponent_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__billboard_renderer, OnComponent_Miscellaneous_BillboardRenderer);
        #endregion
        
        #region Component -> Event
        mComponent_EventItem                         =   MenuItem.Create(mComponentMenu,       R.sections.MenuItems.strings.component__event);
        
        /*mComponent_Event_EventSystemItem           =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__event_system,            OnComponent_Event_EventSystem);
        /*mComponent_Event_EventTriggerItem          =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__event_trigger,           OnComponent_Event_EventTrigger);
        /*mComponent_Event_Physics2dRaycasterItem    =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__physics_2d_raycaster,    OnComponent_Event_Physics2dRaycaster);
        /*mComponent_Event_PhysicsRaycasterItem      =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__physics_raycaster,       OnComponent_Event_PhysicsRaycaster);
        /*mComponent_Event_StandaloneInputModuleItem =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__standalone_input_module, OnComponent_Event_StandaloneInputModule);
        /*mComponent_Event_TouchInputModuleItem      =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__touch_input_module,      OnComponent_Event_TouchInputModule);
        /*mComponent_Event_GraphicRaycasterItem      =*/ MenuItem.Create(mComponent_EventItem, R.sections.MenuItems.strings.component__event__graphic_raycaster,       OnComponent_Event_GraphicRaycaster);
        #endregion
        
        #region Component -> UI
        mComponent_UiItem = MenuItem.Create(mComponentMenu, R.sections.MenuItems.strings.component__ui);
        
        #region Component -> UI -> Effects
        mComponent_Ui_EffectsItem                 =   MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__effects);

        /*mComponent_Ui_Effects_ShadowItem        =*/ MenuItem.Create(mComponent_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__shadow,          OnComponent_Ui_Effects_Shadow);
        /*mComponent_Ui_Effects_OutlineItem       =*/ MenuItem.Create(mComponent_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__outline,         OnComponent_Ui_Effects_Outline);
        /*mComponent_Ui_Effects_PositionAsUv1Item =*/ MenuItem.Create(mComponent_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__position_as_uv1, OnComponent_Ui_Effects_PositionAsUv1);
        #endregion
        
        /*mComponent_Ui_ImageItem       =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__image,        OnComponent_Ui_Image);
        /*mComponent_Ui_TextItem        =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__text,         OnComponent_Ui_Text);
        /*mComponent_Ui_RawImageItem    =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__raw_image,    OnComponent_Ui_RawImage);
        /*mComponent_Ui_MaskItem        =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__mask,         OnComponent_Ui_Mask);
        MenuItem.InsertSeparator(mComponent_UiItem);
        /*mComponent_Ui_ButtonItem      =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__button,       OnComponent_Ui_Button);
        /*mComponent_Ui_InputFieldItem  =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__input_field,  OnComponent_Ui_InputField);
        /*mComponent_Ui_ScrollbarItem   =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__scrollbar,    OnComponent_Ui_Scrollbar);
        /*mComponent_Ui_ScrollRectItem  =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__scroll_rect,  OnComponent_Ui_ScrollRect);
        /*mComponent_Ui_SliderItem      =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__slider,       OnComponent_Ui_Slider);
        /*mComponent_Ui_ToggleItem      =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__toggle,       OnComponent_Ui_Toggle);
        /*mComponent_Ui_ToggleGroupItem =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__toggle_group, OnComponent_Ui_ToggleGroup);
        MenuItem.InsertSeparator(mComponent_UiItem);
        /*mComponent_Ui_SelectableItem  =*/ MenuItem.Create(mComponent_UiItem, R.sections.MenuItems.strings.component__ui__selectable,   OnComponent_Ui_Selectable);
        #endregion
        
        #region Component -> Scripts
        /*mComponent_ScriptsItem =*/ MenuItem.Create(mComponentMenu, R.sections.MenuItems.strings.component__scripts);
        #endregion

        #endregion

        #region Window
        mWindowMenu                  =   MenuItem.Create(mItems,      R.sections.MenuItems.strings.window,                  OnWindowMenu);

        /*mWindow_NextWindowItem     =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__next_window,     OnWindow_NextWindow);
        /*mWindow_PreviousWindowItem =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__previous_window, OnWindow_PreviousWindow);
        MenuItem.InsertSeparator(mWindowMenu);

        #region Window -> Layouts
        mWindow_LayoutsItem                         =   MenuItem.Create(mWindowMenu,         R.sections.MenuItems.strings.window__layouts);
        
        /*mWindow_Layouts_2_by_3Item                =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__2_by_3,                  OnWindow_Layouts_2_by_3);
        /*mWindow_Layouts_4_splitItem               =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__4_split,                 OnWindow_Layouts_4_split);
        /*mWindow_Layouts_DefaultItem               =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__default,                 OnWindow_Layouts_Default);
        /*mWindow_Layouts_TallItem                  =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__tall,                    OnWindow_Layouts_Tall);
        /*mWindow_Layouts_WideItem                  =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__wide,                    OnWindow_Layouts_Wide);
        MenuItem.InsertSeparator(mWindow_LayoutsItem);
        /*mWindow_Layouts_SaveLayoutItem            =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__save_layout,             OnWindow_Layouts_SaveLayout);
        /*mWindow_Layouts_DeleteLayoutItem          =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__delete_layout,           OnWindow_Layouts_DeleteLayout);
        /*mWindow_Layouts_RevertFactorySettingsItem =*/ MenuItem.Create(mWindow_LayoutsItem, R.sections.MenuItems.strings.window__layouts__revert_factory_settings, OnWindow_Layouts_RevertFactorySettings);
        #endregion

        MenuItem.InsertSeparator(mWindowMenu);
        /*mWindow_SceneItem             =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__scene,              OnWindow_Scene);
        /*mWindow_GameItem              =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__game,               OnWindow_Game);
        /*mWindow_InspectorItem         =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__inspector,          OnWindow_Inspector);
        /*mWindow_HierarchyItem         =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__hierarchy,          OnWindow_Hierarchy);
        /*mWindow_ProjectItem           =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__project,            OnWindow_Project);
        /*mWindow_AnimationItem         =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__animation,          OnWindow_Animation);
        /*mWindow_ProfilerItem          =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__profiler,           OnWindow_Profiler);
        /*mWindow_AudioMixerItem        =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__audio_mixer,        OnWindow_AudioMixer);
        /*mWindow_AssetStoreItem        =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__asset_store,        OnWindow_AssetStore);
        /*mWindow_VersionControlItem    =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__version_control,    OnWindow_VersionControl);
        /*mWindow_AnimatorParameterItem =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__animator_parameter, OnWindow_AnimatorParameter);
        /*mWindow_AnimatorItem          =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__animator,           OnWindow_Animator);
        /*mWindow_SpritePackerItem      =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__sprite_packer,      OnWindow_SpritePacker);
        MenuItem.InsertSeparator(mWindowMenu);
        /*mWindow_LightingItem          =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__lighting,           OnWindow_Lighting);
        /*mWindow_OcclusionCullingItem  =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__occlusion_culling,  OnWindow_OcclusionCulling);
        /*mWindow_FrameDebuggerItem     =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__frame_debugger,     OnWindow_FrameDebugger);
        /*mWindow_NavigationItem        =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__navigation,         OnWindow_Navigation);
        MenuItem.InsertSeparator(mWindowMenu);
        /*mWindow_ConsoleItem           =*/ MenuItem.Create(mWindowMenu, R.sections.MenuItems.strings.window__console,            OnWindow_Console);
        #endregion

        #region Help
        mHelpMenu = MenuItem.Create(mItems, R.sections.MenuItems.strings.help, OnHelpMenu);
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
            menuItemButton.name = menuItem.Data.Name;

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
            text.text = menuItem.Data.Text;
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
    /// Handler for File -> New Scene.
    /// </summary>
    public void OnFile_NewScene()
    {
        Debug.Log("MainMenuScript.OnFile_NewScene");
        // TODO: Implement MainMenuScript.OnFile_NewScene
    }

    /// <summary>
    /// Handler for File -> Open Scene.
    /// </summary>
    public void OnFile_OpenScene()
    {
        Debug.Log("MainMenuScript.OnFile_OpenScene");
        // TODO: Implement MainMenuScript.OnFile_OpenScene
    }

    /// <summary>
    /// Handler for File -> Save Scene.
    /// </summary>
    public void OnFile_SaveScene()
    {
        Debug.Log("MainMenuScript.OnFile_SaveScene");
        // TODO: Implement MainMenuScript.OnFile_SaveScene
    }

    /// <summary>
    /// Handler for File -> Save Scene as...
    /// </summary>
    public void OnFile_SaveSceneAs()
    {
        Debug.Log("MainMenuScript.OnFile_SaveSceneAs");
        // TODO: Implement MainMenuScript.OnFile_SaveSceneAs
    }

    /// <summary>
    /// Handler for File -> New Project...
    /// </summary>
    public void OnFile_NewProject()
    {
        Debug.Log("MainMenuScript.OnFile_NewProject");
        // TODO: Implement MainMenuScript.OnFile_NewProject
    }

    /// <summary>
    /// Handler for File -> Open Project...
    /// </summary>
    public void OnFile_OpenProject()
    {
        Debug.Log("MainMenuScript.OnFile_OpenProject");
        // TODO: Implement MainMenuScript.OnFile_OpenProject
    }

    /// <summary>
    /// Handler for File -> Save Project.
    /// </summary>
    public void OnFile_SaveProject()
    {
        Debug.Log("MainMenuScript.OnFile_SaveProject");
        // TODO: Implement MainMenuScript.OnFile_SaveProject
    }

    /// <summary>
    /// Handler for File -> Build Settings...
    /// </summary>
    public void OnFile_BuildSettings()
    {
        Debug.Log("MainMenuScript.OnFile_BuildSettings");
        // TODO: Implement MainMenuScript.OnFile_BuildSettings
    }

    /// <summary>
    /// Handler for File -> Build & Run.
    /// </summary>
    public void OnFile_BuildAndRun()
    {
        Debug.Log("MainMenuScript.OnFile_BuildAndRun");
        // TODO: Implement MainMenuScript.OnFile_BuildAndRun
    }

    /// <summary>
    /// Handler for File -> Build in Cloud...
    /// </summary>
    public void OnFile_BuildInCloud()
    {
        Debug.Log("MainMenuScript.OnFile_BuildInCloud");
        // TODO: Implement MainMenuScript.OnFile_BuildInCloud
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
        OnShowMenuSubItems(mEditMenu);
    }

    /// <summary>
    /// Handler for Edit -> Undo.
    /// </summary>
    public void OnEdit_Undo()
    {
        Debug.Log("MainMenuScript.OnEdit_Undo");
        // TODO: Implement MainMenuScript.OnEdit_Undo
    }

    /// <summary>
    /// Handler for Edit -> Redo.
    /// </summary>
    public void OnEdit_Redo()
    {
        Debug.Log("MainMenuScript.OnEdit_Redo");
        // TODO: Implement MainMenuScript.OnEdit_Redo
    }

    /// <summary>
    /// Handler for Edit -> Cut.
    /// </summary>
    public void OnEdit_Cut()
    {
        Debug.Log("MainMenuScript.OnEdit_Cut");
        // TODO: Implement MainMenuScript.OnEdit_Cut
    }

    /// <summary>
    /// Handler for Edit -> Copy.
    /// </summary>
    public void OnEdit_Copy()
    {
        Debug.Log("MainMenuScript.OnEdit_Copy");
        // TODO: Implement MainMenuScript.OnEdit_Copy
    }

    /// <summary>
    /// Handler for Edit -> Paste.
    /// </summary>
    public void OnEdit_Paste()
    {
        Debug.Log("MainMenuScript.OnEdit_Paste");
        // TODO: Implement MainMenuScript.OnEdit_Paste
    }

    /// <summary>
    /// Handler for Edit -> Duplicate.
    /// </summary>
    public void OnEdit_Duplicate()
    {
        Debug.Log("MainMenuScript.OnEdit_Duplicate");
        // TODO: Implement MainMenuScript.OnEdit_Duplicate
    }

    /// <summary>
    /// Handler for Edit -> Delete.
    /// </summary>
    public void OnEdit_Delete()
    {
        Debug.Log("MainMenuScript.OnEdit_Delete");
        // TODO: Implement MainMenuScript.OnEdit_Delete
    }

    /// <summary>
    /// Handler for Edit -> Frame Selected.
    /// </summary>
    public void OnEdit_FrameSelected()
    {
        Debug.Log("MainMenuScript.OnEdit_FrameSelected");
        // TODO: Implement MainMenuScript.OnEdit_FrameSelected
    }

    /// <summary>
    /// Handler for Edit -> Lock View to Selected.
    /// </summary>
    public void OnEdit_LockViewToSelected()
    {
        Debug.Log("MainMenuScript.OnEdit_LockViewToSelected");
        // TODO: Implement MainMenuScript.OnEdit_LockViewToSelected
    }

    /// <summary>
    /// Handler for Edit -> Find.
    /// </summary>
    public void OnEdit_Find()
    {
        Debug.Log("MainMenuScript.OnEdit_Find");
        // TODO: Implement MainMenuScript.OnEdit_Find
    }

    /// <summary>
    /// Handler for Edit -> Select All.
    /// </summary>
    public void OnEdit_SelectAll()
    {
        Debug.Log("MainMenuScript.OnEdit_SelectAll");
        // TODO: Implement MainMenuScript.OnEdit_SelectAll
    }

    /// <summary>
    /// Handler for Edit -> Preferences...
    /// </summary>
    public void OnEdit_Preferences()
    {
        Debug.Log("MainMenuScript.OnEdit_Preferences");
        // TODO: Implement MainMenuScript.OnEdit_Preferences
    }

    /// <summary>
    /// Handler for Edit -> Modules...
    /// </summary>
    public void OnEdit_Modules()
    {
        Debug.Log("MainMenuScript.OnEdit_Modules");
        // TODO: Implement MainMenuScript.OnEdit_Modules
    }

    /// <summary>
    /// Handler for Edit -> Play.
    /// </summary>
    public void OnEdit_Play()
    {
        Debug.Log("MainMenuScript.OnEdit_Play");
        // TODO: Implement MainMenuScript.OnEdit_Play
    }

    /// <summary>
    /// Handler for Edit -> Pause.
    /// </summary>
    public void OnEdit_Pause()
    {
        Debug.Log("MainMenuScript.OnEdit_Pause");
        // TODO: Implement MainMenuScript.OnEdit_Pause
    }

    /// <summary>
    /// Handler for Edit -> Step.
    /// </summary>
    public void OnEdit_Step()
    {
        Debug.Log("MainMenuScript.OnEdit_Step");
        // TODO: Implement MainMenuScript.OnEdit_Step
    }

    #region Edit -> Selection
    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 1.
    /// </summary>
    public void OnEdit_Selection_LoadSelection1()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection1");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection1
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 2.
    /// </summary>
    public void OnEdit_Selection_LoadSelection2()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection2");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection2
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 3.
    /// </summary>
    public void OnEdit_Selection_LoadSelection3()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection3");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection3
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 4.
    /// </summary>
    public void OnEdit_Selection_LoadSelection4()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection4");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection4
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 5.
    /// </summary>
    public void OnEdit_Selection_LoadSelection5()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection5");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection5
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 6.
    /// </summary>
    public void OnEdit_Selection_LoadSelection6()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection6");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection6
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 7.
    /// </summary>
    public void OnEdit_Selection_LoadSelection7()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection7");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection7
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 8.
    /// </summary>
    public void OnEdit_Selection_LoadSelection8()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection8");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection8
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 9.
    /// </summary>
    public void OnEdit_Selection_LoadSelection9()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection9");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection9
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Load Selection 0.
    /// </summary>
    public void OnEdit_Selection_LoadSelection0()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_LoadSelection0");
        // TODO: Implement MainMenuScript.OnEdit_Selection_LoadSelection0
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 1.
    /// </summary>
    public void OnEdit_Selection_SaveSelection1()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection1");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection1
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 2.
    /// </summary>
    public void OnEdit_Selection_SaveSelection2()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection2");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection2
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 3.
    /// </summary>
    public void OnEdit_Selection_SaveSelection3()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection3");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection3
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 4.
    /// </summary>
    public void OnEdit_Selection_SaveSelection4()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection4");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection4
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 5.
    /// </summary>
    public void OnEdit_Selection_SaveSelection5()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection5");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection5
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 6.
    /// </summary>
    public void OnEdit_Selection_SaveSelection6()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection6");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection6
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 7.
    /// </summary>
    public void OnEdit_Selection_SaveSelection7()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection7");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection7
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 8.
    /// </summary>
    public void OnEdit_Selection_SaveSelection8()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection8");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection8
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 9.
    /// </summary>
    public void OnEdit_Selection_SaveSelection9()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection9");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection9
    }

    /// <summary>
    /// Handler for Edit -> Selection -> Save Selection 0.
    /// </summary>
    public void OnEdit_Selection_SaveSelection0()
    {
        Debug.Log("MainMenuScript.OnEdit_Selection_SaveSelection0");
        // TODO: Implement MainMenuScript.OnEdit_Selection_SaveSelection0
    }
    #endregion

    #region Edit -> Project Settings
    /// <summary>
    /// Handler for Edit -> Project Settings -> Input.
    /// </summary>
    public void OnEdit_ProjectSettings_Input()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Input");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Input
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Tags and Layers.
    /// </summary>
    public void OnEdit_ProjectSettings_TagsAndLayers()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_TagsAndLayers
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Audio.
    /// </summary>
    public void OnEdit_ProjectSettings_Audio()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Audio");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Audio
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Time.
    /// </summary>
    public void OnEdit_ProjectSettings_Time()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Time");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Time
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Player.
    /// </summary>
    public void OnEdit_ProjectSettings_Player()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Player");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Player
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Physics.
    /// </summary>
    public void OnEdit_ProjectSettings_Physics()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Physics 2D.
    /// </summary>
    public void OnEdit_ProjectSettings_Physics2D()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Physics2D");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Physics2D
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Quality.
    /// </summary>
    public void OnEdit_ProjectSettings_Quality()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Quality");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Quality
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Graphics.
    /// </summary>
    public void OnEdit_ProjectSettings_Graphics()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Graphics");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Graphics
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Network.
    /// </summary>
    public void OnEdit_ProjectSettings_Network()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Network");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Network
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Editor.
    /// </summary>
    public void OnEdit_ProjectSettings_Editor()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_Editor");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_Editor
    }

    /// <summary>
    /// Handler for Edit -> Project Settings -> Script Execution Order.
    /// </summary>
    public void OnEdit_ProjectSettings_ScriptExecutionOrder()
    {
        Debug.Log("MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder");
        // TODO: Implement MainMenuScript.OnEdit_ProjectSettings_ScriptExecutionOrder
    }
    #endregion

    #region Edit -> Network Emulation
    /// <summary>
    /// Handler for Edit -> Network Emulation -> None.
    /// </summary>
    public void OnEdit_NetworkEmulation_None()
    {
        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_None");
        // TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_None
    }

    /// <summary>
    /// Handler for Edit -> Network Emulation -> Broadband.
    /// </summary>
    public void OnEdit_NetworkEmulation_Broadband()
    {
        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_Broadband");
        // TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_Broadband
    }

    /// <summary>
    /// Handler for Edit -> Network Emulation -> DSL.
    /// </summary>
    public void OnEdit_NetworkEmulation_DSL()
    {
        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DSL");
        // TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DSL
    }

    /// <summary>
    /// Handler for Edit -> Network Emulation -> ISDN.
    /// </summary>
    public void OnEdit_NetworkEmulation_ISDN()
    {
        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_ISDN");
        // TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_ISDN
    }

    /// <summary>
    /// Handler for Edit -> Network Emulation -> Dial-Up.
    /// </summary>
    public void OnEdit_NetworkEmulation_DialUp()
    {
        Debug.Log("MainMenuScript.OnEdit_NetworkEmulation_DialUp");
        // TODO: Implement MainMenuScript.OnEdit_NetworkEmulation_DialUp
    }
    #endregion

    #region Edit -> Graphics Emulation
    /// <summary>
    /// Handler for Edit -> Graphics Emulation -> No Emulation.
    /// </summary>
    public void OnEdit_GraphicsEmulation_NoEmulation()
    {
        Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation");
        // TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_NoEmulation
    }

    /// <summary>
    /// Handler for Edit -> Graphics Emulation -> Shader Model 3.
    /// </summary>
    public void OnEdit_GraphicsEmulation_ShaderModel3()
    {
        Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel3");
        // TODO: Implement MainMenuScript.OnEdit_ReOnEdit_GraphicsEmulation_ShaderModel3do
    }

    /// <summary>
    /// Handler for Edit -> Graphics Emulation -> Shader Model 2.
    /// </summary>
    public void OnEdit_GraphicsEmulation_ShaderModel2()
    {
        Debug.Log("MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2");
        // TODO: Implement MainMenuScript.OnEdit_GraphicsEmulation_ShaderModel2
    }
    #endregion

    /// <summary>
    /// Handler for Edit -> Snap Settings...
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

    #region Assets -> Create
    /// <summary>
    /// Handler for Assets -> Create -> Folder.
    /// </summary>
    public void OnAssets_Create_Folder()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Folder");
        // TODO: Implement MainMenuScript.OnAssets_Create_Folder
    }

    /// <summary>
    /// Handler for Assets -> Create -> C# Script.
    /// </summary>
    public void OnAssets_Create_CSharpScript()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_CSharpScript");
        // TODO: Implement MainMenuScript.OnAssets_Create_CSharpScript
    }

    /// <summary>
    /// Handler for Assets -> Create -> Javascript.
    /// </summary>
    public void OnAssets_Create_Javascript()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Javascript");
        // TODO: Implement MainMenuScript.OnAssets_Create_Javascript
    }

    /// <summary>
    /// Handler for Assets -> Create -> Shader.
    /// </summary>
    public void OnAssets_Create_Shader()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Shader");
        // TODO: Implement MainMenuScript.OnAssets_Create_Shader
    }

    /// <summary>
    /// Handler for Assets -> Create -> Compute Shader.
    /// </summary>
    public void OnAssets_Create_ComputeShader()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_ComputeShader");
        // TODO: Implement MainMenuScript.OnAssets_Create_ComputeShader
    }

    /// <summary>
    /// Handler for Assets -> Create -> Prefab.
    /// </summary>
    public void OnAssets_Create_Prefab()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Prefab");
        // TODO: Implement MainMenuScript.OnAssets_Create_Prefab
    }

    /// <summary>
    /// Handler for Assets -> Create -> Audio Mixer.
    /// </summary>
    public void OnAssets_Create_AudioMixer()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_AudioMixer");
        // TODO: Implement MainMenuScript.OnAssets_Create_AudioMixer
    }

    /// <summary>
    /// Handler for Assets -> Create -> Material.
    /// </summary>
    public void OnAssets_Create_Material()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Material");
        // TODO: Implement MainMenuScript.OnAssets_Create_Material
    }

    /// <summary>
    /// Handler for Assets -> Create -> Lens Flare.
    /// </summary>
    public void OnAssets_Create_LensFlare()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_LensFlare");
        // TODO: Implement MainMenuScript.OnAssets_Create_LensFlare
    }
    
    /// <summary>
    /// Handler for Assets -> Create -> Render Texture.
    /// </summary>
    public void OnAssets_Create_RenderTexture()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_RenderTexture");
        // TODO: Implement MainMenuScript.OnAssets_Create_RenderTexture
    }
    
    /// <summary>
    /// Handler for Assets -> Create -> Lightmap Parameters.
    /// </summary>
    public void OnAssets_Create_LightmapParameters()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_LightmapParameters");
        // TODO: Implement MainMenuScript.OnAssets_Create_LightmapParameters
    }

    /// <summary>
    /// Handler for Assets -> Create -> Animator Controller.
    /// </summary>
    public void OnAssets_Create_AnimatorController()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_AnimatorController");
        // TODO: Implement MainMenuScript.OnAssets_Create_AnimatorController
    }

    /// <summary>
    /// Handler for Assets -> Create -> Animation.
    /// </summary>
    public void OnAssets_Create_Animation()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Animation");
        // TODO: Implement MainMenuScript.OnAssets_Create_Animation
    }

    /// <summary>
    /// Handler for Assets -> Create -> Animator Override Contoller.
    /// </summary>
    public void OnAssets_Create_AnimatorOverrideContoller()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_AnimatorOverrideContoller");
        // TODO: Implement MainMenuScript.OnAssets_Create_AnimatorOverrideContoller
    }

    /// <summary>
    /// Handler for Assets -> Create -> Avatar Mask.
    /// </summary>
    public void OnAssets_Create_AvatarMask()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_AvatarMask");
        // TODO: Implement MainMenuScript.OnAssets_Create_AvatarMask
    }

    /// <summary>
    /// Handler for Assets -> Create -> Physic Material.
    /// </summary>
    public void OnAssets_Create_PhysicMaterial()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_PhysicMaterial");
        // TODO: Implement MainMenuScript.OnAssets_Create_PhysicMaterial
    }

    /// <summary>
    /// Handler for Assets -> Create -> Physic2D Material.
    /// </summary>
    public void OnAssets_Create_Physic2dMaterial()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Physic2dMaterial");
        // TODO: Implement MainMenuScript.OnAssets_Create_Physic2dMaterial
    }

    /// <summary>
    /// Handler for Assets -> Create -> GUI Skin.
    /// </summary>
    public void OnAssets_Create_GuiSkin()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_GuiSkin");
        // TODO: Implement MainMenuScript.OnAssets_Create_GuiSkin
    }

    /// <summary>
    /// Handler for Assets -> Create -> Custom Font.
    /// </summary>
    public void OnAssets_Create_CustomFont()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_CustomFont");
        // TODO: Implement MainMenuScript.OnAssets_Create_CustomFont
    }

    /// <summary>
    /// Handler for Assets -> Create -> Shader Variant Collection.
    /// </summary>
    public void OnAssets_Create_ShaderVariantCollection()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_ShaderVariantCollection");
        // TODO: Implement MainMenuScript.OnAssets_Create_ShaderVariantCollection
    }

    #region Assets -> Create -> Legacy
    /// <summary>
    /// Handler for Assets -> Create -> Legacy -> Cubemap.
    /// </summary>
    public void OnAssets_Create_Legacy_Cubemap()
    {
        Debug.Log("MainMenuScript.OnAssets_Create_Legacy_Cubemap");
        // TODO: Implement MainMenuScript.OnAssets_Create_Legacy_Cubemap
    }
    #endregion

    #endregion

    /// <summary>
    /// Handler for Assets -> Show In Explorer.
    /// </summary>
    public void OnAssets_ShowInExplorer()
    {
        Debug.Log("MainMenuScript.OnAssets_ShowInExplorer");
        // TODO: Implement MainMenuScript.OnAssets_ShowInExplorer
    }

    /// <summary>
    /// Handler for Assets -> Open.
    /// </summary>
    public void OnAssets_Open()
    {
        Debug.Log("MainMenuScript.OnAssets_Open");
        // TODO: Implement MainMenuScript.OnAssets_Open
    }

    /// <summary>
    /// Handler for Assets -> Delete.
    /// </summary>
    public void OnAssets_Delete()
    {
        Debug.Log("MainMenuScript.OnAssets_Delete");
        // TODO: Implement MainMenuScript.OnAssets_Delete
    }

    /// <summary>
    /// Handler for Assets -> Import New Asset...
    /// </summary>
    public void OnAssets_ImportNewAsset()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportNewAsset");
        // TODO: Implement MainMenuScript.OnAssets_ImportNewAsset
    }

    #region Assets -> Import Package
    /// <summary>
    /// Handler for Assets -> Import Package -> Custom Package...
    /// </summary>
    public void OnAssets_ImportPackage_CustomPackage()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_CustomPackage");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_CustomPackage
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> 2D.
    /// </summary>
    public void OnAssets_ImportPackage_2d()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_2d");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_2d
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Cameras.
    /// </summary>
    public void OnAssets_ImportPackage_Cameras()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Cameras");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Cameras
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Characters.
    /// </summary>
    public void OnAssets_ImportPackage_Characters()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Characters");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Characters
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> CrossPlatformInput.
    /// </summary>
    public void OnAssets_ImportPackage_CrossPlatformInput()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_CrossPlatformInput
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Effects.
    /// </summary>
    public void OnAssets_ImportPackage_Effects()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Effects");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Effects
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Environment.
    /// </summary>
    public void OnAssets_ImportPackage_Environment()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Environment");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Environment
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> ParticleSystems.
    /// </summary>
    public void OnAssets_ImportPackage_ParticleSystems()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_ParticleSystems");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_ParticleSystems
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Prototyping.
    /// </summary>
    public void OnAssets_ImportPackage_Prototyping()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Prototyping");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Prototyping
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Utility.
    /// </summary>
    public void OnAssets_ImportPackage_Utility()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Utility");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Utility
    }

    /// <summary>
    /// Handler for Assets -> Import Package -> Vehicles.
    /// </summary>
    public void OnAssets_ImportPackage_Vehicles()
    {
        Debug.Log("MainMenuScript.OnAssets_ImportPackage_Vehicles");
        // TODO: Implement MainMenuScript.OnAssets_ImportPackage_Vehicles
    }
    #endregion

    /// <summary>
    /// Handler for Assets -> Export Package...
    /// </summary>
    public void OnAssets_ExportPackage()
    {
        Debug.Log("MainMenuScript.OnAssets_ExportPackage");
        // TODO: Implement MainMenuScript.OnAssets_ExportPackage
    }

    /// <summary>
    /// Handler for Assets -> Find References In Scene.
    /// </summary>
    public void OnAssets_FindReferencesInScene()
    {
        Debug.Log("MainMenuScript.OnAssets_FindReferencesInScene");
        // TODO: Implement MainMenuScript.OnAssets_FindReferencesInScene
    }

    /// <summary>
    /// Handler for Assets -> Select Dependencies.
    /// </summary>
    public void OnAssets_SelectDependencies()
    {
        Debug.Log("MainMenuScript.OnAssets_SelectDependencies");
        // TODO: Implement MainMenuScript.OnAssets_SelectDependencies
    }

    /// <summary>
    /// Handler for Assets -> Refresh.
    /// </summary>
    public void OnAssets_Refresh()
    {
        Debug.Log("MainMenuScript.OnAssets_Refresh");
        // TODO: Implement MainMenuScript.OnAssets_Refresh
    }

    /// <summary>
    /// Handler for Assets -> Reimport.
    /// </summary>
    public void OnAssets_Reimport()
    {
        Debug.Log("MainMenuScript.OnAssets_Reimport");
        // TODO: Implement MainMenuScript.OnAssets_Reimport
    }

    /// <summary>
    /// Handler for Assets -> Reimport All.
    /// </summary>
    public void OnAssets_ReimportAll()
    {
        Debug.Log("MainMenuScript.OnAssets_ReimportAll");
        // TODO: Implement MainMenuScript.OnAssets_ReimportAll
    }
    
    /// <summary>
    /// Handler for Assets -> Run API Updater...
    /// </summary>
    public void OnAssets_RunApiUpdater()
    {
        Debug.Log("MainMenuScript.OnAssets_RunApiUpdater");
        // TODO: Implement MainMenuScript.OnAssets_RunApiUpdater
    }

    /// <summary>
    /// Handler for Assets -> Sync MonoDevelop Project.
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

    /// <summary>
    /// Handler for GameObject -> Create Empty.
    /// </summary>
    public void OnGameObject_CreateEmpty()
    {
        Debug.Log("MainMenuScript.OnGameObject_CreateEmpty");
        // TODO: Implement MainMenuScript.OnGameObject_CreateEmpty
    }
        
    /// <summary>
    /// Handler for GameObject -> Create Empty Child.
    /// </summary>
    public void OnGameObject_CreateEmptyChild()
    {
        Debug.Log("MainMenuScript.OnGameObject_CreateEmptyChild");
        // TODO: Implement MainMenuScript.OnGameObject_CreateEmptyChild
    }
            
    #region GameObject -> 3D Object
    /// <summary>
    /// Handler for GameObject -> 3D Object -> Cube.
    /// </summary>
    public void OnGameObject_3dObject_Cube()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Cube");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Cube
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Sphere.
    /// </summary>
    public void OnGameObject_3dObject_Sphere()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Sphere");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Sphere
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Capsule.
    /// </summary>
    public void OnGameObject_3dObject_Capsule()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Capsule");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Capsule
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Cylinder.
    /// </summary>
    public void OnGameObject_3dObject_Cylinder()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Cylinder");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Cylinder
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Plane.
    /// </summary>
    public void OnGameObject_3dObject_Plane()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Plane");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Plane
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Quad.
    /// </summary>
    public void OnGameObject_3dObject_Quad()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Quad");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Quad
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Ragdoll...
    /// </summary>
    public void OnGameObject_3dObject_Ragdoll()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Ragdoll");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Ragdoll
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Terrain.
    /// </summary>
    public void OnGameObject_3dObject_Terrain()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Terrain");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Terrain
    }

    /// <summary>
    /// Handler for GameObject -> 3D Object -> Tree.
    /// </summary>
    public void OnGameObject_3dObject_Tree()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_Tree");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_Tree
    }
    
    /// <summary>
    /// Handler for GameObject -> 3D Object -> Wind Zone.
    /// </summary>
    public void OnGameObject_3dObject_WindZone()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_WindZone");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_WindZone
    }
    
    /// <summary>
    /// Handler for GameObject -> 3D Object -> 3D Text.
    /// </summary>
    public void OnGameObject_3dObject_3dText()
    {
        Debug.Log("MainMenuScript.OnGameObject_3dObject_3dText");
        // TODO: Implement MainMenuScript.OnGameObject_3dObject_3dText
    }
    #endregion
    
    #region GameObject -> 2D Object    
    /// <summary>
    /// Handler for GameObject -> 2D Object -> Sprite.
    /// </summary>
    public void OnGameObject_2dObject_Sprite()
    {
        Debug.Log("MainMenuScript.OnGameObject_2dObject_Sprite");
        // TODO: Implement MainMenuScript.OnGameObject_2dObject_Sprite
    }
    #endregion
    
    #region GameObject -> Light
    /// <summary>
    /// Handler for GameObject -> Light -> Directional Light.
    /// </summary>
    public void OnGameObject_Light_DirectionalLight()
    {
        Debug.Log("MainMenuScript.OnGameObject_Light_DirectionalLight");
        // TODO: Implement MainMenuScript.OnGameObject_Light_DirectionalLight
    }

    /// <summary>
    /// Handler for GameObject -> Light -> Point Light.
    /// </summary>
    public void OnGameObject_Light_PointLight()
    {
        Debug.Log("MainMenuScript.OnGameObject_Light_PointLight");
        // TODO: Implement MainMenuScript.OnGameObject_Light_PointLight
    }

    /// <summary>
    /// Handler for GameObject -> Light -> Spotlight.
    /// </summary>
    public void OnGameObject_Light_Spotlight()
    {
        Debug.Log("MainMenuScript.OnGameObject_Light_Spotlight");
        // TODO: Implement MainMenuScript.OnGameObject_Light_Spotlight
    }

    /// <summary>
    /// Handler for GameObject -> Light -> Area Light.
    /// </summary>
    public void OnGameObject_Light_AreaLight()
    {
        Debug.Log("MainMenuScript.OnGameObject_Light_AreaLight");
        // TODO: Implement MainMenuScript.OnGameObject_Light_AreaLight
    }

    /// <summary>
    /// Handler for GameObject -> Light -> Reflection Probe.
    /// </summary>
    public void OnGameObject_Light_ReflectionProbe()
    {
        Debug.Log("MainMenuScript.OnGameObject_Light_ReflectionProbe");
        // TODO: Implement MainMenuScript.OnGameObject_Light_ReflectionProbe
    }

    /// <summary>
    /// Handler for GameObject -> Light -> Light Probe Group.
    /// </summary>
    public void OnGameObject_Light_LightProbeGroup()
    {
        Debug.Log("MainMenuScript.OnGameObject_Light_LightProbeGroup");
        // TODO: Implement MainMenuScript.OnGameObject_Light_LightProbeGroup
    }
    #endregion
    
    #region GameObject -> Audio
    /// <summary>
    /// Handler for GameObject -> Audio -> Audio Source.
    /// </summary>
    public void OnGameObject_Audio_AudioSource()
    {
        Debug.Log("MainMenuScript.OnGameObject_Audio_AudioSource");
        // TODO: Implement MainMenuScript.OnGameObject_Audio_AudioSource
    }

    /// <summary>
    /// Handler for GameObject -> Audio -> Audio Reverb Zone.
    /// </summary>
    public void OnGameObject_Audio_AudioReverbZone()
    {
        Debug.Log("MainMenuScript.OnGameObject_Audio_AudioReverbZone");
        // TODO: Implement MainMenuScript.OnGameObject_Audio_AudioReverbZone
    }
    #endregion
    
    #region GameObject -> UI
    /// <summary>
    /// Handler for GameObject -> UI -> Panel.
    /// </summary>
    public void OnGameObject_Ui_Panel()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Panel");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Panel
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Button.
    /// </summary>
    public void OnGameObject_Ui_Button()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Button");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Button
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Text.
    /// </summary>
    public void OnGameObject_Ui_Text()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Text");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Text
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Image.
    /// </summary>
    public void OnGameObject_Ui_Image()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Image");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Image
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Raw Image.
    /// </summary>
    public void OnGameObject_Ui_RawImage()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_RawImage");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_RawImage
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Slider.
    /// </summary>
    public void OnGameObject_Ui_Slider()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Slider");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Slider
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Scrollbar.
    /// </summary>
    public void OnGameObject_Ui_Scrollbar()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Scrollbar");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Scrollbar
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Toggle.
    /// </summary>
    public void OnGameObject_Ui_Toggle()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Toggle");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Toggle
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Input Field.
    /// </summary>
    public void OnGameObject_Ui_InputField()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_InputField");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_InputField
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Canvas.
    /// </summary>
    public void OnGameObject_Ui_Canvas()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_Canvas");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_Canvas
    }

    /// <summary>
    /// Handler for GameObject -> UI -> Event System.
    /// </summary>
    public void OnGameObject_Ui_EventSystem()
    {
        Debug.Log("MainMenuScript.OnGameObject_Ui_EventSystem");
        // TODO: Implement MainMenuScript.OnGameObject_Ui_EventSystem
    }
    #endregion

    /// <summary>
    /// Handler for GameObject -> Particle System.
    /// </summary>
    public void OnGameObject_ParticleSystem()
    {
        Debug.Log("MainMenuScript.OnGameObject_ParticleSystem");
        // TODO: Implement MainMenuScript.OnGameObject_ParticleSystem
    }

    /// <summary>
    /// Handler for GameObject -> Camera.
    /// </summary>
    public void OnGameObject_Camera()
    {
        Debug.Log("MainMenuScript.OnGameObject_Camera");
        // TODO: Implement MainMenuScript.OnGameObject_Camera
    }

    /// <summary>
    /// Handler for GameObject -> Center On Children.
    /// </summary>
    public void OnGameObject_CenterOnChildren()
    {
        Debug.Log("MainMenuScript.OnGameObject_CenterOnChildren");
        // TODO: Implement MainMenuScript.OnGameObject_CenterOnChildren
    }

    /// <summary>
    /// Handler for GameObject -> Make Parent.
    /// </summary>
    public void OnGameObject_MakeParent()
    {
        Debug.Log("MainMenuScript.OnGameObject_MakeParent");
        // TODO: Implement MainMenuScript.OnGameObject_MakeParent
    }

    /// <summary>
    /// Handler for GameObject -> Clear Parent.
    /// </summary>
    public void OnGameObject_ClearParent()
    {
        Debug.Log("MainMenuScript.OnGameObject_ClearParent");
        // TODO: Implement MainMenuScript.OnGameObject_ClearParent
    }

    /// <summary>
    /// Handler for GameObject -> Apply Changes To Prefab.
    /// </summary>
    public void OnGameObject_ApplyChangesToPrefab()
    {
        Debug.Log("MainMenuScript.OnGameObject_ApplyChangesToPrefab");
        // TODO: Implement MainMenuScript.OnGameObject_ApplyChangesToPrefab
    }

    /// <summary>
    /// Handler for GameObject -> Break Prefab Instance.
    /// </summary>
    public void OnGameObject_BreakPrefabInstance()
    {
        Debug.Log("MainMenuScript.OnGameObject_BreakPrefabInstance");
        // TODO: Implement MainMenuScript.OnGameObject_BreakPrefabInstance
    }

    /// <summary>
    /// Handler for GameObject -> Set as first sibling.
    /// </summary>
    public void OnGameObject_SetAsFirstSibling()
    {
        Debug.Log("MainMenuScript.OnGameObject_SetAsFirstSibling");
        // TODO: Implement MainMenuScript.OnGameObject_SetAsFirstSibling
    }

    /// <summary>
    /// Handler for GameObject -> Set as last sibling.
    /// </summary>
    public void OnGameObject_SetAsLastSibling()
    {
        Debug.Log("MainMenuScript.OnGameObject_SetAsLastSibling");
        // TODO: Implement MainMenuScript.OnGameObject_SetAsLastSibling
    }

    /// <summary>
    /// Handler for GameObject -> Move To View.
    /// </summary>
    public void OnGameObject_MoveToView()
    {
        Debug.Log("MainMenuScript.OnGameObject_MoveToView");
        // TODO: Implement MainMenuScript.OnGameObject_MoveToView
    }

    /// <summary>
    /// Handler for GameObject -> Align With View.
    /// </summary>
    public void OnGameObject_AlignWithView()
    {
        Debug.Log("MainMenuScript.OnGameObject_AlignWithView");
        // TODO: Implement MainMenuScript.OnGameObject_AlignWithView
    }

    /// <summary>
    /// Handler for GameObject -> Align View to Selected.
    /// </summary>
    public void OnGameObject_AlignViewToSelected()
    {
        Debug.Log("MainMenuScript.OnGameObject_AlignViewToSelected");
        // TODO: Implement MainMenuScript.OnGameObject_AlignViewToSelected
    }

    /// <summary>
    /// Handler for GameObject -> Toggle Active State.
    /// </summary>
    public void OnGameObject_ToggleActiveState()
    {
        Debug.Log("MainMenuScript.OnGameObject_ToggleActiveState");
        // TODO: Implement MainMenuScript.OnGameObject_ToggleActiveState
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

    /// <summary>
    /// Handler for Component -> Add...
    /// </summary>
    public void OnComponent_Add()
    {
        Debug.Log("MainMenuScript.OnComponent_Add");
        // TODO: Implement MainMenuScript.OnComponent_Add
    }
    
    #region Component -> Mesh
    /// <summary>
    /// Handler for Component -> Mesh -> Mesh Filter.
    /// </summary>
    public void OnComponent_Mesh_MeshFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Mesh_MeshFilter");
        // TODO: Implement MainMenuScript.OnComponent_Mesh_MeshFilter
    }

    /// <summary>
    /// Handler for Component -> Mesh -> Text Mesh.
    /// </summary>
    public void OnComponent_Mesh_TextMesh()
    {
        Debug.Log("MainMenuScript.OnComponent_Mesh_TextMesh");
        // TODO: Implement MainMenuScript.OnComponent_Mesh_TextMesh
    }

    /// <summary>
    /// Handler for Component -> Mesh -> Mesh Renderer.
    /// </summary>
    public void OnComponent_Mesh_MeshRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Mesh_MeshRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Mesh_MeshRenderer
    }

    /// <summary>
    /// Handler for Component -> Mesh -> Skinned Mesh Renderer.
    /// </summary>
    public void OnComponent_Mesh_SkinnedMeshRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Mesh_SkinnedMeshRenderer
    }
    #endregion
    
    #region Component -> Effects
    /// <summary>
    /// Handler for Component -> Effects -> Particle System.
    /// </summary>
    public void OnComponent_Effects_ParticleSystem()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_ParticleSystem");
        // TODO: Implement MainMenuScript.OnComponent_Effects_ParticleSystem
    }

    /// <summary>
    /// Handler for Component -> Effects -> Trail Renderer.
    /// </summary>
    public void OnComponent_Effects_TrailRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_TrailRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Effects_TrailRenderer
    }

    /// <summary>
    /// Handler for Component -> Effects -> Line Renderer.
    /// </summary>
    public void OnComponent_Effects_LineRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LineRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LineRenderer
    }

    /// <summary>
    /// Handler for Component -> Effects -> Lens Flare.
    /// </summary>
    public void OnComponent_Effects_LensFlare()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LensFlare");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LensFlare
    }

    /// <summary>
    /// Handler for Component -> Effects -> Halo.
    /// </summary>
    public void OnComponent_Effects_Halo()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_Halo");
        // TODO: Implement MainMenuScript.OnComponent_Effects_Halo
    }

    /// <summary>
    /// Handler for Component -> Effects -> Projector.
    /// </summary>
    public void OnComponent_Effects_Projector()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_Projector");
        // TODO: Implement MainMenuScript.OnComponent_Effects_Projector
    }
    
    #region Component -> Effects -> Legacy Particles
    /// <summary>
    /// Handler for Component -> Effects -> Legacy Particles -> Ellipsoid Particle Emitter.
    /// </summary>
    public void OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter
    }

    /// <summary>
    /// Handler for Component -> Effects -> Legacy Particles -> Mesh Particle Emitter.
    /// </summary>
    public void OnComponent_Effects_LegacyParticles_MeshParticleEmitter()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter
    }

    /// <summary>
    /// Handler for Component -> Effects -> Legacy Particles -> Particle Animator.
    /// </summary>
    public void OnComponent_Effects_LegacyParticles_ParticleAnimator()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleAnimator
    }

    /// <summary>
    /// Handler for Component -> Effects -> Legacy Particles -> World Particle Collider.
    /// </summary>
    public void OnComponent_Effects_LegacyParticles_WorldParticleCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider
    }

    /// <summary>
    /// Handler for Component -> Effects -> Legacy Particles -> Particle Renderer.
    /// </summary>
    public void OnComponent_Effects_LegacyParticles_ParticleRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Effects_LegacyParticles_ParticleRenderer
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
        // TODO: Implement MainMenuScript.OnComponent_Physics_Rigidbody
    }

    /// <summary>
    /// Handler for Component -> Physics -> Character Controller.
    /// </summary>
    public void OnComponent_Physics_CharacterController()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_CharacterController");
        // TODO: Implement MainMenuScript.OnComponent_Physics_CharacterController
    }

    /// <summary>
    /// Handler for Component -> Physics -> Box Collider.
    /// </summary>
    public void OnComponent_Physics_BoxCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_BoxCollider");
        // TODO: Implement MainMenuScript.OnComponent_Physics_BoxCollider
    }

    /// <summary>
    /// Handler for Component -> Physics -> Sphere Collider.
    /// </summary>
    public void OnComponent_Physics_SphereCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_SphereCollider");
        // TODO: Implement MainMenuScript.OnComponent_Physics_SphereCollider
    }

    /// <summary>
    /// Handler for Component -> Physics -> Capsule Collider.
    /// </summary>
    public void OnComponent_Physics_CapsuleCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_CapsuleCollider");
        // TODO: Implement MainMenuScript.OnComponent_Physics_CapsuleCollider
    }

    /// <summary>
    /// Handler for Component -> Physics -> Mesh Collider.
    /// </summary>
    public void OnComponent_Physics_MeshCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_MeshCollider");
        // TODO: Implement MainMenuScript.OnComponent_Physics_MeshCollider
    }

    /// <summary>
    /// Handler for Component -> Physics -> Wheel Collider.
    /// </summary>
    public void OnComponent_Physics_WheelCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_WheelCollider");
        // TODO: Implement MainMenuScript.OnComponent_Physics_WheelCollider
    }

    /// <summary>
    /// Handler for Component -> Physics -> Terrain Collider.
    /// </summary>
    public void OnComponent_Physics_TerrainCollider()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_TerrainCollider");
        // TODO: Implement MainMenuScript.OnComponent_Physics_TerrainCollider
    }

    /// <summary>
    /// Handler for Component -> Physics -> Cloth.
    /// </summary>
    public void OnComponent_Physics_Cloth()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_Cloth");
        // TODO: Implement MainMenuScript.OnComponent_Physics_Cloth
    }

    /// <summary>
    /// Handler for Component -> Physics -> Hinge Joint.
    /// </summary>
    public void OnComponent_Physics_HingeJoint()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_HingeJoint");
        // TODO: Implement MainMenuScript.OnComponent_Physics_HingeJoint
    }

    /// <summary>
    /// Handler for Component -> Physics -> Fixed Joint.
    /// </summary>
    public void OnComponent_Physics_FixedJoint()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_FixedJoint");
        // TODO: Implement MainMenuScript.OnComponent_Physics_FixedJoint
    }

    /// <summary>
    /// Handler for Component -> Physics -> Spring Joint.
    /// </summary>
    public void OnComponent_Physics_SpringJoint()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_SpringJoint");
        // TODO: Implement MainMenuScript.OnComponent_Physics_SpringJoint
    }

    /// <summary>
    /// Handler for Component -> Physics -> Character Joint.
    /// </summary>
    public void OnComponent_Physics_CharacterJoint()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_CharacterJoint");
        // TODO: Implement MainMenuScript.OnComponent_Physics_CharacterJoint
    }

    /// <summary>
    /// Handler for Component -> Physics -> Configurable Joint.
    /// </summary>
    public void OnComponent_Physics_ConfigurableJoint()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_ConfigurableJoint");
        // TODO: Implement MainMenuScript.OnComponent_Physics_ConfigurableJoint
    }

    /// <summary>
    /// Handler for Component -> Physics -> Constant Force.
    /// </summary>
    public void OnComponent_Physics_ConstantForce()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics_ConstantForce");
        // TODO: Implement MainMenuScript.OnComponent_Physics_ConstantForce
    }
    #endregion
    
    #region Component -> Physics 2D
    /// <summary>
    /// Handler for Component -> Physics 2D -> Rigidbody 2D.
    /// </summary>
    public void OnComponent_Physics2d_Rigidbody2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_Rigidbody2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_Rigidbody2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Circle Collider 2D.
    /// </summary>
    public void OnComponent_Physics2d_CircleCollider2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_CircleCollider2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_CircleCollider2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Box Collider 2D.
    /// </summary>
    public void OnComponent_Physics2d_BoxCollider2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_BoxCollider2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_BoxCollider2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Edge Collider 2D.
    /// </summary>
    public void OnComponent_Physics2d_EdgeCollider2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_EdgeCollider2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_EdgeCollider2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Polygon Collider 2D.
    /// </summary>
    public void OnComponent_Physics2d_PolygonCollider2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_PolygonCollider2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_PolygonCollider2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Spring Joint 2D.
    /// </summary>
    public void OnComponent_Physics2d_SpringJoint2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_SpringJoint2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_SpringJoint2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Distance Joint 2D.
    /// </summary>
    public void OnComponent_Physics2d_DistanceJoint2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_DistanceJoint2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_DistanceJoint2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Hinge Joint 2D.
    /// </summary>
    public void OnComponent_Physics2d_HingeJoint2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_HingeJoint2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_HingeJoint2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Slider Joint 2D.
    /// </summary>
    public void OnComponent_Physics2d_SliderJoint2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_SliderJoint2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_SliderJoint2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Wheel Joint 2D.
    /// </summary>
    public void OnComponent_Physics2d_WheelJoint2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_WheelJoint2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_WheelJoint2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Constant Force 2D.
    /// </summary>
    public void OnComponent_Physics2d_ConstantForce2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_ConstantForce2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_ConstantForce2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Area Effector 2D.
    /// </summary>
    public void OnComponent_Physics2d_AreaEffector2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_AreaEffector2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_AreaEffector2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Point Effector 2D.
    /// </summary>
    public void OnComponent_Physics2d_PointEffector2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_PointEffector2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_PointEffector2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Platform Effector 2D.
    /// </summary>
    public void OnComponent_Physics2d_PlatformEffector2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_PlatformEffector2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_PlatformEffector2d
    }

    /// <summary>
    /// Handler for Component -> Physics 2D -> Surface Effector 2D.
    /// </summary>
    public void OnComponent_Physics2d_SurfaceEffector2d()
    {
        Debug.Log("MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d");
        // TODO: Implement MainMenuScript.OnComponent_Physics2d_SurfaceEffector2d
    }
    #endregion
    
    #region Component -> Navigation
    /// <summary>
    /// Handler for Component -> Navigation -> Nav Mesh Agent.
    /// </summary>
    public void OnComponent_Navigation_NavMeshAgent()
    {
        Debug.Log("MainMenuScript.OnComponent_Navigation_NavMeshAgent");
        // TODO: Implement MainMenuScript.OnComponent_Navigation_NavMeshAgent
    }

    /// <summary>
    /// Handler for Component -> Navigation -> Off Mesh Link.
    /// </summary>
    public void OnComponent_Navigation_OffMeshLink()
    {
        Debug.Log("MainMenuScript.OnComponent_Navigation_OffMeshLink");
        // TODO: Implement MainMenuScript.OnComponent_Navigation_OffMeshLink
    }

    /// <summary>
    /// Handler for Component -> Navigation -> Nav Mesh Obstacle.
    /// </summary>
    public void OnComponent_Navigation_NavMeshObstacle()
    {
        Debug.Log("MainMenuScript.OnComponent_Navigation_NavMeshObstacle");
        // TODO: Implement MainMenuScript.OnComponent_Navigation_NavMeshObstacle
    }
    #endregion
    
    #region Component -> Audio
    /// <summary>
    /// Handler for Component -> Audio -> Audio Listener.
    /// </summary>
    public void OnComponent_Audio_AudioListener()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioListener");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioListener
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Source.
    /// </summary>
    public void OnComponent_Audio_AudioSource()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioSource");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioSource
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Reverb Zone.
    /// </summary>
    public void OnComponent_Audio_AudioReverbZone()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioReverbZone");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioReverbZone
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Low Pass Filter.
    /// </summary>
    public void OnComponent_Audio_AudioLowPassFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioLowPassFilter");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioLowPassFilter
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio High Pass Filter.
    /// </summary>
    public void OnComponent_Audio_AudioHighPassFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioHighPassFilter");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioHighPassFilter
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Echo Filter.
    /// </summary>
    public void OnComponent_Audio_AudioEchoFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioEchoFilter");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioEchoFilter
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Distortion Filter.
    /// </summary>
    public void OnComponent_Audio_AudioDistortionFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioDistortionFilter");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioDistortionFilter
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Reverb Filter.
    /// </summary>
    public void OnComponent_Audio_AudioReverbFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioReverbFilter");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioReverbFilter
    }

    /// <summary>
    /// Handler for Component -> Audio -> Audio Chorus Filter.
    /// </summary>
    public void OnComponent_Audio_AudioChorusFilter()
    {
        Debug.Log("MainMenuScript.OnComponent_Audio_AudioChorusFilter");
        // TODO: Implement MainMenuScript.OnComponent_Audio_AudioChorusFilter
    }
    #endregion
    
    #region Component -> Rendering
    /// <summary>
    /// Handler for Component -> Rendering -> Camera.
    /// </summary>
    public void OnComponent_Rendering_Camera()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_Camera");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_Camera
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Skybox.
    /// </summary>
    public void OnComponent_Rendering_Skybox()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_Skybox");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_Skybox
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Flare Layer.
    /// </summary>
    public void OnComponent_Rendering_FlareLayer()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_FlareLayer");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_FlareLayer
    }

    /// <summary>
    /// Handler for Component -> Rendering -> GUI Layer.
    /// </summary>
    public void OnComponent_Rendering_GuiLayer()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_GuiLayer");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_GuiLayer
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Light.
    /// </summary>
    public void OnComponent_Rendering_Light()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_Light");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_Light
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Light Probe Group.
    /// </summary>
    public void OnComponent_Rendering_LightProbeGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_LightProbeGroup");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_LightProbeGroup
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Reflection Probe.
    /// </summary>
    public void OnComponent_Rendering_ReflectionProbe()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_ReflectionProbe");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_ReflectionProbe
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Occlusion Area.
    /// </summary>
    public void OnComponent_Rendering_OcclusionArea()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_OcclusionArea");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_OcclusionArea
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Occlusion Portal.
    /// </summary>
    public void OnComponent_Rendering_OcclusionPortal()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_OcclusionPortal");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_OcclusionPortal
    }

    /// <summary>
    /// Handler for Component -> Rendering -> LOD Group.
    /// </summary>
    public void OnComponent_Rendering_LodGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_LodGroup");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_LodGroup
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Sprite Renderer.
    /// </summary>
    public void OnComponent_Rendering_SpriteRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_SpriteRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_SpriteRenderer
    }

    /// <summary>
    /// Handler for Component -> Rendering -> Canvas Renderer.
    /// </summary>
    public void OnComponent_Rendering_CanvasRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_CanvasRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_CanvasRenderer
    }

    /// <summary>
    /// Handler for Component -> Rendering -> GUI Texture.
    /// </summary>
    public void OnComponent_Rendering_GuiTexture()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_GuiTexture");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_GuiTexture
    }

    /// <summary>
    /// Handler for Component -> Rendering -> GUI Text.
    /// </summary>
    public void OnComponent_Rendering_GuiText()
    {
        Debug.Log("MainMenuScript.OnComponent_Rendering_GuiText");
        // TODO: Implement MainMenuScript.OnComponent_Rendering_GuiText
    }
    #endregion
    
    #region Component -> Layout
    /// <summary>
    /// Handler for Component -> Layout -> Rect Transform.
    /// </summary>
    public void OnComponent_Layout_RectTransform()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_RectTransform");
        // TODO: Implement MainMenuScript.OnComponent_Layout_RectTransform
    }

    /// <summary>
    /// Handler for Component -> Layout -> Canvas.
    /// </summary>
    public void OnComponent_Layout_Canvas()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_Canvas");
        // TODO: Implement MainMenuScript.OnComponent_Layout_Canvas
    }

    /// <summary>
    /// Handler for Component -> Layout -> Canvas Group.
    /// </summary>
    public void OnComponent_Layout_CanvasGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_CanvasGroup");
        // TODO: Implement MainMenuScript.OnComponent_Layout_CanvasGroup
    }

    /// <summary>
    /// Handler for Component -> Layout -> Canvas Scaler.
    /// </summary>
    public void OnComponent_Layout_CanvasScaler()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_CanvasScaler");
        // TODO: Implement MainMenuScript.OnComponent_Layout_CanvasScaler
    }

    /// <summary>
    /// Handler for Component -> Layout -> Layout Element.
    /// </summary>
    public void OnComponent_Layout_LayoutElement()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_LayoutElement");
        // TODO: Implement MainMenuScript.OnComponent_Layout_LayoutElement
    }

    /// <summary>
    /// Handler for Component -> Layout -> Content Size Fitter.
    /// </summary>
    public void OnComponent_Layout_ContentSizeFitter()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_ContentSizeFitter");
        // TODO: Implement MainMenuScript.OnComponent_Layout_ContentSizeFitter
    }

    /// <summary>
    /// Handler for Component -> Layout -> Aspect Ratio Fitter.
    /// </summary>
    public void OnComponent_Layout_AspectRatioFitter()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_AspectRatioFitter");
        // TODO: Implement MainMenuScript.OnComponent_Layout_AspectRatioFitter
    }

    /// <summary>
    /// Handler for Component -> Layout -> Horizontal Layout Group.
    /// </summary>
    public void OnComponent_Layout_HorizontalLayoutGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup");
        // TODO: Implement MainMenuScript.OnComponent_Layout_HorizontalLayoutGroup
    }

    /// <summary>
    /// Handler for Component -> Layout -> Vertical Layout Group.
    /// </summary>
    public void OnComponent_Layout_VerticalLayoutGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_VerticalLayoutGroup");
        // TODO: Implement MainMenuScript.OnComponent_Layout_VerticalLayoutGroup
    }

    /// <summary>
    /// Handler for Component -> Layout -> Grid Layout Group.
    /// </summary>
    public void OnComponent_Layout_GridLayoutGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Layout_GridLayoutGroup");
        // TODO: Implement MainMenuScript.OnComponent_Layout_GridLayoutGroup
    }
    #endregion
    
    #region Component -> Miscellaneous
    /// <summary>
    /// Handler for Component -> Miscellaneous -> Animator.
    /// </summary>
    public void OnComponent_Miscellaneous_Animator()
    {
        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Animator");
        // TODO: Implement MainMenuScript.OnComponent_Miscellaneous_Animator
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Animation.
    /// </summary>
    public void OnComponent_Miscellaneous_Animation()
    {
        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Animation");
        // TODO: Implement MainMenuScript.OnComponent_Miscellaneous_Animation
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Network View.
    /// </summary>
    public void OnComponent_Miscellaneous_NetworkView()
    {
        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_NetworkView");
        // TODO: Implement MainMenuScript.OnComponent_Miscellaneous_NetworkView
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Wind Zone.
    /// </summary>
    public void OnComponent_Miscellaneous_WindZone()
    {
        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_WindZone");
        // TODO: Implement MainMenuScript.OnComponent_Miscellaneous_WindZone
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Terrain.
    /// </summary>
    public void OnComponent_Miscellaneous_Terrain()
    {
        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_Terrain");
        // TODO: Implement MainMenuScript.OnComponent_Miscellaneous_Terrain
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Billboard Renderer.
    /// </summary>
    public void OnComponent_Miscellaneous_BillboardRenderer()
    {
        Debug.Log("MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer");
        // TODO: Implement MainMenuScript.OnComponent_Miscellaneous_BillboardRenderer
    }
    #endregion
    
    #region Component -> Event
    /// <summary>
    /// Handler for Component -> Miscellaneous -> Event System.
    /// </summary>
    public void OnComponent_Event_EventSystem()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_EventSystem");
        // TODO: Implement MainMenuScript.OnComponent_Event_EventSystem
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Event Trigger.
    /// </summary>
    public void OnComponent_Event_EventTrigger()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_EventTrigger");
        // TODO: Implement MainMenuScript.OnComponent_Event_EventTrigger
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Physics 2D Raycaster.
    /// </summary>
    public void OnComponent_Event_Physics2dRaycaster()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_Physics2dRaycaster");
        // TODO: Implement MainMenuScript.OnComponent_Event_Physics2dRaycaster
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Physics Raycaster.
    /// </summary>
    public void OnComponent_Event_PhysicsRaycaster()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_PhysicsRaycaster");
        // TODO: Implement MainMenuScript.OnComponent_Event_PhysicsRaycaster
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Standalone Input Module.
    /// </summary>
    public void OnComponent_Event_StandaloneInputModule()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_StandaloneInputModule");
        // TODO: Implement MainMenuScript.OnComponent_Event_StandaloneInputModule
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Touch Input Module.
    /// </summary>
    public void OnComponent_Event_TouchInputModule()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_TouchInputModule");
        // TODO: Implement MainMenuScript.OnComponent_Event_TouchInputModule
    }

    /// <summary>
    /// Handler for Component -> Miscellaneous -> Graphic Raycaster.
    /// </summary>
    public void OnComponent_Event_GraphicRaycaster()
    {
        Debug.Log("MainMenuScript.OnComponent_Event_GraphicRaycaster");
        // TODO: Implement MainMenuScript.OnComponent_Event_GraphicRaycaster
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
        // TODO: Implement MainMenuScript.OnComponent_Ui_Effects_Shadow
    }

    /// <summary>
    /// Handler for Component -> UI -> Effects -> Outline.
    /// </summary>
    public void OnComponent_Ui_Effects_Outline()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Effects_Outline");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Effects_Outline
    }

    /// <summary>
    /// Handler for Component -> UI -> Effects -> Position As UV1.
    /// </summary>
    public void OnComponent_Ui_Effects_PositionAsUv1()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Effects_PositionAsUv1
    }
    #endregion

    /// <summary>
    /// Handler for Component -> UI -> Image.
    /// </summary>
    public void OnComponent_Ui_Image()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Image");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Image
    }

    /// <summary>
    /// Handler for Component -> UI -> Text.
    /// </summary>
    public void OnComponent_Ui_Text()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Text");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Text
    }

    /// <summary>
    /// Handler for Component -> UI -> Raw Image.
    /// </summary>
    public void OnComponent_Ui_RawImage()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_RawImage");
        // TODO: Implement MainMenuScript.OnComponent_Ui_RawImage
    }

    /// <summary>
    /// Handler for Component -> UI -> Mask.
    /// </summary>
    public void OnComponent_Ui_Mask()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Mask");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Mask
    }

    /// <summary>
    /// Handler for Component -> UI -> Button.
    /// </summary>
    public void OnComponent_Ui_Button()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Button");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Button
    }

    /// <summary>
    /// Handler for Component -> UI -> Input Field.
    /// </summary>
    public void OnComponent_Ui_InputField()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_InputField");
        // TODO: Implement MainMenuScript.OnComponent_Ui_InputField
    }

    /// <summary>
    /// Handler for Component -> UI -> Scrollbar.
    /// </summary>
    public void OnComponent_Ui_Scrollbar()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Scrollbar");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Scrollbar
    }

    /// <summary>
    /// Handler for Component -> UI -> Scroll Rect.
    /// </summary>
    public void OnComponent_Ui_ScrollRect()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_ScrollRect");
        // TODO: Implement MainMenuScript.OnComponent_Ui_ScrollRect
    }

    /// <summary>
    /// Handler for Component -> UI -> Slider.
    /// </summary>
    public void OnComponent_Ui_Slider()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Slider");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Slider
    }

    /// <summary>
    /// Handler for Component -> UI -> Toggle.
    /// </summary>
    public void OnComponent_Ui_Toggle()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Toggle");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Toggle
    }

    /// <summary>
    /// Handler for Component -> UI -> Toggle Group.
    /// </summary>
    public void OnComponent_Ui_ToggleGroup()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_ToggleGroup");
        // TODO: Implement MainMenuScript.OnComponent_Ui_ToggleGroup
    }

    /// <summary>
    /// Handler for Component -> UI -> Selectable.
    /// </summary>
    public void OnComponent_Ui_Selectable()
    {
        Debug.Log("MainMenuScript.OnComponent_Ui_Selectable");
        // TODO: Implement MainMenuScript.OnComponent_Ui_Selectable
    }
    #endregion

    #endregion
    
    #region Window
    /// <summary>
    /// Handler for Window.
    /// </summary>
    public void OnWindowMenu()
    {
        OnShowMenuSubItems(mWindowMenu);
    }

    /// <summary>
    /// Handler for Window -> Next Window.
    /// </summary>
    public void OnWindow_NextWindow()
    {
        Debug.Log("MainMenuScript.OnWindow_NextWindow");
        // TODO: Implement MainMenuScript.OnWindow_NextWindow
    }

    /// <summary>
    /// Handler for Window -> Previous Window.
    /// </summary>
    public void OnWindow_PreviousWindow()
    {
        Debug.Log("MainMenuScript.OnWindow_PreviousWindow");
        // TODO: Implement MainMenuScript.OnWindow_PreviousWindow
    }
    
    #region Window -> Layouts
    /// <summary>
    /// Handler for Window -> Layouts -> 2 by 3.
    /// </summary>
    public void OnWindow_Layouts_2_by_3()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_2_by_3");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_2_by_3
    }

    /// <summary>
    /// Handler for Window -> Layouts -> 4 split.
    /// </summary>
    public void OnWindow_Layouts_4_split()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_4_split");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_4_split
    }

    /// <summary>
    /// Handler for Window -> Layouts -> Default.
    /// </summary>
    public void OnWindow_Layouts_Default()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_Default");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_Default
    }

    /// <summary>
    /// Handler for Window -> Layouts -> Tall.
    /// </summary>
    public void OnWindow_Layouts_Tall()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_Tall");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_Tall
    }

    /// <summary>
    /// Handler for Window -> Layouts -> Wide.
    /// </summary>
    public void OnWindow_Layouts_Wide()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_Wide");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_Wide
    }

    /// <summary>
    /// Handler for Window -> Layouts -> Save Layout.
    /// </summary>
    public void OnWindow_Layouts_SaveLayout()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_SaveLayout");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_SaveLayout
    }

    /// <summary>
    /// Handler for Window -> Layouts -> Delete Layout.
    /// </summary>
    public void OnWindow_Layouts_DeleteLayout()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_DeleteLayout");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_DeleteLayout
    }

    /// <summary>
    /// Handler for Window -> Layouts -> Revert Factory Settings.
    /// </summary>
    public void OnWindow_Layouts_RevertFactorySettings()
    {
        Debug.Log("MainMenuScript.OnWindow_Layouts_RevertFactorySettings");
        // TODO: Implement MainMenuScript.OnWindow_Layouts_RevertFactorySettings
    }
    #endregion

    /// <summary>
    /// Handler for Window -> Scene.
    /// </summary>
    public void OnWindow_Scene()
    {
        Debug.Log("MainMenuScript.OnWindow_Scene");
        // TODO: Implement MainMenuScript.OnWindow_Scene
    }

    /// <summary>
    /// Handler for Window -> Game.
    /// </summary>
    public void OnWindow_Game()
    {
        Debug.Log("MainMenuScript.OnWindow_Game");
        // TODO: Implement MainMenuScript.OnWindow_Game
    }

    /// <summary>
    /// Handler for Window -> Inspector.
    /// </summary>
    public void OnWindow_Inspector()
    {
        Debug.Log("MainMenuScript.OnWindow_Inspector");
        // TODO: Implement MainMenuScript.OnWindow_Inspector
    }

    /// <summary>
    /// Handler for Window -> Hierarchy.
    /// </summary>
    public void OnWindow_Hierarchy()
    {
        Debug.Log("MainMenuScript.OnWindow_Hierarchy");
        // TODO: Implement MainMenuScript.OnWindow_Hierarchy
    }

    /// <summary>
    /// Handler for Window -> Project.
    /// </summary>
    public void OnWindow_Project()
    {
        Debug.Log("MainMenuScript.OnWindow_Project");
        // TODO: Implement MainMenuScript.OnWindow_Project
    }

    /// <summary>
    /// Handler for Window -> Animation.
    /// </summary>
    public void OnWindow_Animation()
    {
        Debug.Log("MainMenuScript.OnWindow_Animation");
        // TODO: Implement MainMenuScript.OnWindow_Animation
    }

    /// <summary>
    /// Handler for Window -> Profiler.
    /// </summary>
    public void OnWindow_Profiler()
    {
        Debug.Log("MainMenuScript.OnWindow_Profiler");
        // TODO: Implement MainMenuScript.OnWindow_Profiler
    }

    /// <summary>
    /// Handler for Window -> Audio Mixer.
    /// </summary>
    public void OnWindow_AudioMixer()
    {
        Debug.Log("MainMenuScript.OnWindow_AudioMixer");
        // TODO: Implement MainMenuScript.OnWindow_AudioMixer
    }

    /// <summary>
    /// Handler for Window -> Asset Store.
    /// </summary>
    public void OnWindow_AssetStore()
    {
        Debug.Log("MainMenuScript.OnWindow_AssetStore");
        // TODO: Implement MainMenuScript.OnWindow_AssetStore
    }

    /// <summary>
    /// Handler for Window -> Version Control.
    /// </summary>
    public void OnWindow_VersionControl()
    {
        Debug.Log("MainMenuScript.OnWindow_VersionControl");
        // TODO: Implement MainMenuScript.OnWindow_VersionControl
    }

    /// <summary>
    /// Handler for Window -> Animator Parameter.
    /// </summary>
    public void OnWindow_AnimatorParameter()
    {
        Debug.Log("MainMenuScript.OnWindow_AnimatorParameter");
        // TODO: Implement MainMenuScript.OnWindow_AnimatorParameter
    }

    /// <summary>
    /// Handler for Window -> Animator.
    /// </summary>
    public void OnWindow_Animator()
    {
        Debug.Log("MainMenuScript.OnWindow_Animator");
        // TODO: Implement MainMenuScript.OnWindow_Animator
    }

    /// <summary>
    /// Handler for Window -> Sprite Packer.
    /// </summary>
    public void OnWindow_SpritePacker()
    {
        Debug.Log("MainMenuScript.OnWindow_SpritePacker");
        // TODO: Implement MainMenuScript.OnWindow_SpritePacker
    }

    /// <summary>
    /// Handler for Window -> Lighting.
    /// </summary>
    public void OnWindow_Lighting()
    {
        Debug.Log("MainMenuScript.OnWindow_Lighting");
        // TODO: Implement MainMenuScript.OnWindow_Lighting
    }

    /// <summary>
    /// Handler for Window -> Occlusion Culling.
    /// </summary>
    public void OnWindow_OcclusionCulling()
    {
        Debug.Log("MainMenuScript.OnWindow_OcclusionCulling");
        // TODO: Implement MainMenuScript.OnWindow_OcclusionCulling
    }

    /// <summary>
    /// Handler for Window -> Frame Debugger.
    /// </summary>
    public void OnWindow_FrameDebugger()
    {
        Debug.Log("MainMenuScript.OnWindow_FrameDebugger");
        // TODO: Implement MainMenuScript.OnWindow_FrameDebugger
    }

    /// <summary>
    /// Handler for Window -> Navigation.
    /// </summary>
    public void OnWindow_Navigation()
    {
        Debug.Log("MainMenuScript.OnWindow_Navigation");
        // TODO: Implement MainMenuScript.OnWindow_Navigation
    }

    /// <summary>
    /// Handler for Window -> Console.
    /// </summary>
    public void OnWindow_Console()
    {
        Debug.Log("MainMenuScript.OnWindow_Console");
        // TODO: Implement MainMenuScript.OnWindow_Console
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
