using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;

using common;
using common.ui;



public class MainMenu_UI
{
    private MainMenuScript mScript;

    #region Menu items
    private TreeNode<MenuItem> mItems = null;
    
    #region File
    public TreeNode<MenuItem> fileMenu               = null;
    
//  public TreeNode<MenuItem> file_NewSceneItem      = null;
//  public TreeNode<MenuItem> file_OpenSceneItem     = null;
    
//  public TreeNode<MenuItem> file_SaveSceneItem     = null;
//  public TreeNode<MenuItem> file_SaveSceneAsItem   = null;
    
//  public TreeNode<MenuItem> file_NewProjectItem    = null;
//  public TreeNode<MenuItem> file_OpenProjectItem   = null;
//  public TreeNode<MenuItem> file_SaveProjectItem   = null;
    
//  public TreeNode<MenuItem> file_BuildSettingsItem = null;
//  public TreeNode<MenuItem> file_BuildAndRunItem   = null;
//  public TreeNode<MenuItem> file_BuildInCloudItem  = null;
    
//  public TreeNode<MenuItem> file_ExitItem          = null;
    #endregion
    
    #region Edit
    public TreeNode<MenuItem> editMenu                    = null;
    
//  public TreeNode<MenuItem> edit_UndoItem               = null;
//  public TreeNode<MenuItem> edit_RedoItem               = null;
    
//  public TreeNode<MenuItem> edit_CutItem                = null;
//  public TreeNode<MenuItem> edit_CopyItem               = null;
//  public TreeNode<MenuItem> edit_PasteItem              = null;
    
//  public TreeNode<MenuItem> edit_DuplicateItem          = null;
//  public TreeNode<MenuItem> edit_DeleteItem             = null;
    
//  public TreeNode<MenuItem> edit_FrameSelectedItem      = null;
//  public TreeNode<MenuItem> edit_LockViewToSelectedItem = null;
//  public TreeNode<MenuItem> edit_FindItem               = null;
//  public TreeNode<MenuItem> edit_SelectAllItem          = null;
    
//  public TreeNode<MenuItem> edit_PreferencesItem        = null;
//  public TreeNode<MenuItem> edit_ModulesItem            = null;
    
//  public TreeNode<MenuItem> edit_PlayItem               = null;
//  public TreeNode<MenuItem> edit_PauseItem              = null;
//  public TreeNode<MenuItem> edit_StepItem               = null;
    
    #region Edit -> Selection
    public TreeNode<MenuItem> edit_SelectionItem                = null;
    
//  public TreeNode<MenuItem> edit_Selection_LoadSelection1Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection2Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection3Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection4Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection5Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection6Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection7Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection8Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection9Item = null;
//  public TreeNode<MenuItem> edit_Selection_LoadSelection0Item = null;
    
//  public TreeNode<MenuItem> edit_Selection_SaveSelection1Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection2Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection3Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection4Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection5Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection6Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection7Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection8Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection9Item = null;
//  public TreeNode<MenuItem> edit_Selection_SaveSelection0Item = null;
    #endregion
    
    #region Edit -> Project Settings
    public TreeNode<MenuItem> edit_ProjectSettingsItem                      = null;
    
//  public TreeNode<MenuItem> edit_ProjectSettings_InputItem                = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_TagsAndLayersItem        = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_AudioItem                = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_TimeItem                 = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_PlayerItem               = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_PhysicsItem              = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_Physics2DItem            = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_QualityItem              = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_GraphicsItem             = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_NetworkItem              = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_EditorItem               = null;
//  public TreeNode<MenuItem> edit_ProjectSettings_ScriptExecutionOrderItem = null;
    #endregion
    
    #region Edit -> Network Emulation
    public TreeNode<MenuItem> edit_NetworkEmulationItem                           = null;
    
//  public TreeNode<MenuItem> edit_NetworkEmulation_NetworkEmulationNoneItem      = null;
//  public TreeNode<MenuItem> edit_NetworkEmulation_NetworkEmulationBroadbandItem = null;
//  public TreeNode<MenuItem> edit_NetworkEmulation_NetworkEmulationDSLItem       = null;
//  public TreeNode<MenuItem> edit_NetworkEmulation_NetworkEmulationISDNItem      = null;
//  public TreeNode<MenuItem> edit_NetworkEmulation_NetworkEmulationDialUpItem    = null;
    #endregion
    
    #region Edit -> Graphics Emulation
    public TreeNode<MenuItem> edit_GraphicsEmulationItem                               = null;
    
//  public TreeNode<MenuItem> edit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  = null;
//  public TreeNode<MenuItem> edit_GraphicsEmulation_GraphicsEmulationShaderModel3Item = null;
//  public TreeNode<MenuItem> edit_GraphicsEmulation_GraphicsEmulationShaderModel2Item = null;
    #endregion
    
//  public TreeNode<MenuItem> edit_SnapSettingsItem = null;
    #endregion
    
    #region Assets
    public TreeNode<MenuItem> assetsMenu = null;
    
    #region Assets -> Create
    public TreeNode<MenuItem> assets_CreateItem                           = null;
    
//  public TreeNode<MenuItem> assets_Create_FolderItem                    = null;
    
//  public TreeNode<MenuItem> assets_Create_CSharpScriptItem              = null;
//  public TreeNode<MenuItem> assets_Create_JavascriptItem                = null;
//  public TreeNode<MenuItem> assets_Create_ShaderItem                    = null;
//  public TreeNode<MenuItem> assets_Create_ComputeShaderItem             = null;
    
//  public TreeNode<MenuItem> assets_Create_PrefabItem                    = null;
    
//  public TreeNode<MenuItem> assets_Create_AudioMixerItem                = null;
    
//  public TreeNode<MenuItem> assets_Create_MaterialItem                  = null;
//  public TreeNode<MenuItem> assets_Create_LensFlareItem                 = null;
//  public TreeNode<MenuItem> assets_Create_RenderTextureItem             = null;
//  public TreeNode<MenuItem> assets_Create_LightmapParametersItem        = null;
    
//  public TreeNode<MenuItem> assets_Create_AnimatorControllerItem        = null;
//  public TreeNode<MenuItem> assets_Create_AnimationItem                 = null;
//  public TreeNode<MenuItem> assets_Create_AnimatorOverrideContollerItem = null;
//  public TreeNode<MenuItem> assets_Create_AvatarMaskItem                = null;
    
//  public TreeNode<MenuItem> assets_Create_PhysicMaterialItem            = null;
//  public TreeNode<MenuItem> assets_Create_Physic2dMaterialItem          = null;
    
//  public TreeNode<MenuItem> assets_Create_GuiSkinItem                   = null;
//  public TreeNode<MenuItem> assets_Create_CustomFontItem                = null;
//  public TreeNode<MenuItem> assets_Create_ShaderVariantCollectionItem   = null;
    
    #region Assets -> Create -> Legacy
    public TreeNode<MenuItem> assets_Create_LegacyItem         = null;
    
//  public TreeNode<MenuItem> assets_Create_Legacy_CubemapItem = null;
    #endregion
    
    #endregion
    
//  public TreeNode<MenuItem> assets_ShowInExplorerItem = null;
//  public TreeNode<MenuItem> assets_OpenItem           = null;
//  public TreeNode<MenuItem> assets_DeleteItem         = null;
    
//  public TreeNode<MenuItem> assets_ImportNewAssetItem = null;
    
    #region Assets -> Import Package
    public TreeNode<MenuItem> assets_ImportPackageItem                    = null;
    
//  public TreeNode<MenuItem> assets_ImportPackage_CustomPackageItem      = null;
    
//  public TreeNode<MenuItem> assets_ImportPackage_2dItem                 = null;
//  public TreeNode<MenuItem> assets_ImportPackage_CamerasItem            = null;
//  public TreeNode<MenuItem> assets_ImportPackage_CharactersItem         = null;
//  public TreeNode<MenuItem> assets_ImportPackage_CrossPlatformInputItem = null;
//  public TreeNode<MenuItem> assets_ImportPackage_EffectsItem            = null;
//  public TreeNode<MenuItem> assets_ImportPackage_EnvironmentItem        = null;
//  public TreeNode<MenuItem> assets_ImportPackage_ParticleSystemsItem    = null;
//  public TreeNode<MenuItem> assets_ImportPackage_PrototypingItem        = null;
//  public TreeNode<MenuItem> assets_ImportPackage_UtilityItem            = null;
//  public TreeNode<MenuItem> assets_ImportPackage_VehiclesItem           = null;
    #endregion
    
//  public TreeNode<MenuItem> assets_ExportPackageItem          = null;
//  public TreeNode<MenuItem> assets_FindReferencesInSceneItem  = null;
//  public TreeNode<MenuItem> assets_SelectDependenciesItem     = null;
    
//  public TreeNode<MenuItem> assets_RefreshItem                = null;
//  public TreeNode<MenuItem> assets_ReimportItem               = null;
    
//  public TreeNode<MenuItem> assets_ReimportAllItem            = null;
    
//  public TreeNode<MenuItem> assets_RunApiUpdaterItem          = null;
    
//  public TreeNode<MenuItem> assets_SyncMonoDevelopProjectItem = null;
    
    #endregion
    
    #region GameObject
    public TreeNode<MenuItem> gameObjectMenu                  = null;
    
//  public TreeNode<MenuItem> gameObject_CreateEmptyItem      = null;
//  public TreeNode<MenuItem> gameObject_CreateEmptyChildItem = null;
    
    #region GameObject -> 3D Object    
    public TreeNode<MenuItem> gameObject_3dObjectItem          = null;
    
//  public TreeNode<MenuItem> gameObject_3dObject_CubeItem     = null;
//  public TreeNode<MenuItem> gameObject_3dObject_SphereItem   = null;
//  public TreeNode<MenuItem> gameObject_3dObject_CapsuleItem  = null;
//  public TreeNode<MenuItem> gameObject_3dObject_CylinderItem = null;
//  public TreeNode<MenuItem> gameObject_3dObject_PlaneItem    = null;
//  public TreeNode<MenuItem> gameObject_3dObject_QuadItem     = null;
    
//  public TreeNode<MenuItem> gameObject_3dObject_RagdollItem  = null;
    
//  public TreeNode<MenuItem> gameObject_3dObject_TerrainItem  = null;
//  public TreeNode<MenuItem> gameObject_3dObject_TreeItem     = null;
//  public TreeNode<MenuItem> gameObject_3dObject_WindZoneItem = null;
    
//  public TreeNode<MenuItem> gameObject_3dObject_3dTextItem   = null;
    #endregion
    
    #region GameObject -> 2D Object    
    public TreeNode<MenuItem> gameObject_2dObjectItem        = null;
    
//  public TreeNode<MenuItem> gameObject_2dObject_SpriteItem = null;
    #endregion
    
    #region GameObject -> Light
    public TreeNode<MenuItem> gameObject_LightItem                  = null;
    
//  public TreeNode<MenuItem> gameObject_Light_DirectionalLightItem = null;
//  public TreeNode<MenuItem> gameObject_Light_PointLightItem       = null;
//  public TreeNode<MenuItem> gameObject_Light_SpotlightItem        = null;
//  public TreeNode<MenuItem> gameObject_Light_AreaLightItem        = null;
    
//  public TreeNode<MenuItem> gameObject_Light_ReflectionProbeItem  = null;
//  public TreeNode<MenuItem> gameObject_Light_LightProbeGroupItem  = null;
    #endregion
    
    #region GameObject -> Audio
    public TreeNode<MenuItem> gameObject_AudioItem                 = null;
    
//  public TreeNode<MenuItem> gameObject_Audio_AudioSourceItem     = null;
//  public TreeNode<MenuItem> gameObject_Audio_AudioReverbZoneItem = null;
    #endregion
    
    #region GameObject -> UI
    public TreeNode<MenuItem> gameObject_UiItem             = null;
    
//  public TreeNode<MenuItem> gameObject_Ui_PanelItem       = null;
//  public TreeNode<MenuItem> gameObject_Ui_ButtonItem      = null;
//  public TreeNode<MenuItem> gameObject_Ui_TextItem        = null;
//  public TreeNode<MenuItem> gameObject_Ui_ImageItem       = null;
//  public TreeNode<MenuItem> gameObject_Ui_RawImageItem    = null;
//  public TreeNode<MenuItem> gameObject_Ui_SliderItem      = null;
//  public TreeNode<MenuItem> gameObject_Ui_ScrollbarItem   = null;
//  public TreeNode<MenuItem> gameObject_Ui_ToggleItem      = null;
//  public TreeNode<MenuItem> gameObject_Ui_InputFieldItem  = null;
//  public TreeNode<MenuItem> gameObject_Ui_CanvasItem      = null;
//  public TreeNode<MenuItem> gameObject_Ui_EventSystemItem = null;
    #endregion
    
//  public TreeNode<MenuItem> gameObject_ParticleSystemItem       = null;
//  public TreeNode<MenuItem> gameObject_CameraItem               = null;
    
//  public TreeNode<MenuItem> gameObject_CenterOnChildrenItem     = null;
    
//  public TreeNode<MenuItem> gameObject_MakeParentItem           = null;
//  public TreeNode<MenuItem> gameObject_ClearParentItem          = null;
//  public TreeNode<MenuItem> gameObject_ApplyChangesToPrefabItem = null;
//  public TreeNode<MenuItem> gameObject_BreakPrefabInstanceItem  = null;
    
//  public TreeNode<MenuItem> gameObject_SetAsFirstSiblingItem    = null;
//  public TreeNode<MenuItem> gameObject_SetAsLastSiblingItem     = null;
//  public TreeNode<MenuItem> gameObject_MoveToViewItem           = null;
//  public TreeNode<MenuItem> gameObject_AlignWithViewItem        = null;
//  public TreeNode<MenuItem> gameObject_AlignViewToSelectedItem  = null;
//  public TreeNode<MenuItem> gameObject_ToggleActiveStateItem    = null;
    #endregion
    
    #region Component
    public TreeNode<MenuItem> componentMenu     = null;
    
//  public TreeNode<MenuItem> component_AddItem = null;
    
    #region Component -> Mesh
    public TreeNode<MenuItem> component_MeshItem                     = null;
    
//  public TreeNode<MenuItem> component_Mesh_MeshFilterItem          = null;
//  public TreeNode<MenuItem> component_Mesh_TextMeshItem            = null;
    
//  public TreeNode<MenuItem> component_Mesh_MeshRendererItem        = null;
//  public TreeNode<MenuItem> component_Mesh_SkinnedMeshRendererItem = null;
    #endregion
    
    #region Component -> Effects
    public TreeNode<MenuItem> component_EffectsItem                = null;
    
//  public TreeNode<MenuItem> component_Effects_ParticleSystemItem = null;
//  public TreeNode<MenuItem> component_Effects_TrailRendererItem  = null;
//  public TreeNode<MenuItem> component_Effects_LineRendererItem   = null;
//  public TreeNode<MenuItem> component_Effects_LensFlareItem      = null;
//  public TreeNode<MenuItem> component_Effects_HaloItem           = null;
//  public TreeNode<MenuItem> component_Effects_ProjectorItem      = null;
    
    #region Component -> Effects -> Legacy Particles
    public TreeNode<MenuItem> component_Effects_LegacyParticlesItem                          = null;
    
//  public TreeNode<MenuItem> component_Effects_LegacyParticles_EllipsoidParticleEmitterItem = null;
//  public TreeNode<MenuItem> component_Effects_LegacyParticles_MeshParticleEmitterItem      = null;
    
//  public TreeNode<MenuItem> component_Effects_LegacyParticles_ParticleAnimatorItem         = null;
//  public TreeNode<MenuItem> component_Effects_LegacyParticles_WorldParticleColliderItem    = null;
    
//  public TreeNode<MenuItem> component_Effects_LegacyParticles_ParticleRendererItem         = null;
    #endregion
    
    #endregion
    
    #region Component -> Physics
    public TreeNode<MenuItem> component_PhysicsItem                     = null;
    
//  public TreeNode<MenuItem> component_Physics_RigidbodyItem           = null;
//  public TreeNode<MenuItem> component_Physics_CharacterControllerItem = null;
    
//  public TreeNode<MenuItem> component_Physics_BoxColliderItem         = null;
//  public TreeNode<MenuItem> component_Physics_SphereColliderItem      = null;
//  public TreeNode<MenuItem> component_Physics_CapsuleColliderItem     = null;
//  public TreeNode<MenuItem> component_Physics_MeshColliderItem        = null;
//  public TreeNode<MenuItem> component_Physics_WheelColliderItem       = null;
//  public TreeNode<MenuItem> component_Physics_TerrainColliderItem     = null;
    
//  public TreeNode<MenuItem> component_Physics_ClothItem               = null;
    
//  public TreeNode<MenuItem> component_Physics_HingeJointItem          = null;
//  public TreeNode<MenuItem> component_Physics_FixedJointItem          = null;
//  public TreeNode<MenuItem> component_Physics_SpringJointItem         = null;
//  public TreeNode<MenuItem> component_Physics_CharacterJointItem      = null;
//  public TreeNode<MenuItem> component_Physics_ConfigurableJointItem   = null;
    
//  public TreeNode<MenuItem> component_Physics_ConstantForceItem       = null;
    #endregion
    
    #region Component -> Physics 2D
    public TreeNode<MenuItem> component_Physics2dItem                    = null;
    
//  public TreeNode<MenuItem> component_Physics2d_Rigidbody2dItem        = null;
    
//  public TreeNode<MenuItem> component_Physics2d_CircleCollider2dItem   = null;
//  public TreeNode<MenuItem> component_Physics2d_BoxCollider2dItem      = null;
//  public TreeNode<MenuItem> component_Physics2d_EdgeCollider2dItem     = null;
//  public TreeNode<MenuItem> component_Physics2d_PolygonCollider2dItem  = null;
    
//  public TreeNode<MenuItem> component_Physics2d_SpringJoint2dItem      = null;
//  public TreeNode<MenuItem> component_Physics2d_DistanceJoint2dItem    = null;
//  public TreeNode<MenuItem> component_Physics2d_HingeJoint2dItem       = null;
//  public TreeNode<MenuItem> component_Physics2d_SliderJoint2dItem      = null;
//  public TreeNode<MenuItem> component_Physics2d_WheelJoint2dItem       = null;
    
//  public TreeNode<MenuItem> component_Physics2d_ConstantForce2dItem    = null;
    
//  public TreeNode<MenuItem> component_Physics2d_AreaEffector2dItem     = null;
//  public TreeNode<MenuItem> component_Physics2d_PointEffector2dItem    = null;
//  public TreeNode<MenuItem> component_Physics2d_PlatformEffector2dItem = null;
//  public TreeNode<MenuItem> component_Physics2d_SurfaceEffector2dItem  = null;
    #endregion
    
    #region Component -> Navigation
    public TreeNode<MenuItem> component_NavigationItem                 = null;
    
//  public TreeNode<MenuItem> component_Navigation_NavMeshAgentItem    = null;
//  public TreeNode<MenuItem> component_Navigation_OffMeshLinkItem     = null;
//  public TreeNode<MenuItem> component_Navigation_NavMeshObstacleItem = null;
    #endregion
    
    #region Component -> Audio
    public TreeNode<MenuItem> component_AudioItem                       = null;
    
//  public TreeNode<MenuItem> component_Audio_AudioListenerItem         = null;
//  public TreeNode<MenuItem> component_Audio_AudioSourceItem           = null;
//  public TreeNode<MenuItem> component_Audio_AudioReverbZoneItem       = null;
    
//  public TreeNode<MenuItem> component_Audio_AudioLowPassFilterItem    = null;
//  public TreeNode<MenuItem> component_Audio_AudioHighPassFilterItem   = null;
//  public TreeNode<MenuItem> component_Audio_AudioEchoFilterItem       = null;
//  public TreeNode<MenuItem> component_Audio_AudioDistortionFilterItem = null;
//  public TreeNode<MenuItem> component_Audio_AudioReverbFilterItem     = null;
//  public TreeNode<MenuItem> component_Audio_AudioChorusFilterItem     = null;
    #endregion
    
    #region Component -> Rendering
    public TreeNode<MenuItem> component_RenderingItem                 = null;
    
//  public TreeNode<MenuItem> component_Rendering_CameraItem          = null;
//  public TreeNode<MenuItem> component_Rendering_SkyboxItem          = null;
//  public TreeNode<MenuItem> component_Rendering_FlareLayerItem      = null;
//  public TreeNode<MenuItem> component_Rendering_GuiLayerItem        = null;
    
//  public TreeNode<MenuItem> component_Rendering_LightItem           = null;
//  public TreeNode<MenuItem> component_Rendering_LightProbeGroupItem = null;
//  public TreeNode<MenuItem> component_Rendering_ReflectionProbeItem = null;
    
//  public TreeNode<MenuItem> component_Rendering_OcclusionAreaItem   = null;
//  public TreeNode<MenuItem> component_Rendering_OcclusionPortalItem = null;
//  public TreeNode<MenuItem> component_Rendering_LodGroupItem        = null;
    
//  public TreeNode<MenuItem> component_Rendering_SpriteRendererItem  = null;
//  public TreeNode<MenuItem> component_Rendering_CanvasRendererItem  = null;
    
//  public TreeNode<MenuItem> component_Rendering_GuiTextureItem      = null;
//  public TreeNode<MenuItem> component_Rendering_GuiTextItem         = null;
    #endregion
    
    #region Component -> Layout
    public TreeNode<MenuItem> component_LayoutItem                       = null;
    
//  public TreeNode<MenuItem> component_Layout_RectTransformItem         = null;
//  public TreeNode<MenuItem> component_Layout_CanvasItem                = null;
//  public TreeNode<MenuItem> component_Layout_CanvasGroupItem           = null;
    
//  public TreeNode<MenuItem> component_Layout_CanvasScalerItem          = null;
    
//  public TreeNode<MenuItem> component_Layout_LayoutElementItem         = null;
//  public TreeNode<MenuItem> component_Layout_ContentSizeFitterItem     = null;
//  public TreeNode<MenuItem> component_Layout_AspectRatioFitterItem     = null;
//  public TreeNode<MenuItem> component_Layout_HorizontalLayoutGroupItem = null;
//  public TreeNode<MenuItem> component_Layout_VerticalLayoutGroupItem   = null;
//  public TreeNode<MenuItem> component_Layout_GridLayoutGroupItem       = null;
    #endregion
    
    #region Component -> Miscellaneous
    public TreeNode<MenuItem> component_MiscellaneousItem                   = null;
    
//  public TreeNode<MenuItem> component_Miscellaneous_AnimatorItem          = null;
//  public TreeNode<MenuItem> component_Miscellaneous_AnimationItem         = null;
//  public TreeNode<MenuItem> component_Miscellaneous_NetworkViewItem       = null;
//  public TreeNode<MenuItem> component_Miscellaneous_WindZoneItem          = null;
//  public TreeNode<MenuItem> component_Miscellaneous_TerrainItem           = null;
//  public TreeNode<MenuItem> component_Miscellaneous_BillboardRendererItem = null;
    #endregion
    
    #region Component -> Event
    public TreeNode<MenuItem> component_EventItem                       = null;
    
//  public TreeNode<MenuItem> component_Event_EventSystemItem           = null;
//  public TreeNode<MenuItem> component_Event_EventTriggerItem          = null;
//  public TreeNode<MenuItem> component_Event_Physics2dRaycasterItem    = null;
//  public TreeNode<MenuItem> component_Event_PhysicsRaycasterItem      = null;
//  public TreeNode<MenuItem> component_Event_StandaloneInputModuleItem = null;
//  public TreeNode<MenuItem> component_Event_TouchInputModuleItem      = null;
//  public TreeNode<MenuItem> component_Event_GraphicRaycasterItem      = null;
    #endregion
    
    #region Component -> UI
    public TreeNode<MenuItem> component_UiItem = null;
    
    #region Component -> UI -> Effects
    public TreeNode<MenuItem> component_Ui_EffectsItem               = null;
    
//  public TreeNode<MenuItem> component_Ui_Effects_ShadowItem        = null;
//  public TreeNode<MenuItem> component_Ui_Effects_OutlineItem       = null;
//  public TreeNode<MenuItem> component_Ui_Effects_PositionAsUv1Item = null;
    #endregion
    
//  public TreeNode<MenuItem> component_Ui_ImageItem       = null;
//  public TreeNode<MenuItem> component_Ui_TextItem        = null;
//  public TreeNode<MenuItem> component_Ui_RawImageItem    = null;
//  public TreeNode<MenuItem> component_Ui_MaskItem        = null;
    
//  public TreeNode<MenuItem> component_Ui_ButtonItem      = null;
//  public TreeNode<MenuItem> component_Ui_InputFieldItem  = null;
//  public TreeNode<MenuItem> component_Ui_ScrollbarItem   = null;
//  public TreeNode<MenuItem> component_Ui_ScrollRectItem  = null;
//  public TreeNode<MenuItem> component_Ui_SliderItem      = null;
//  public TreeNode<MenuItem> component_Ui_ToggleItem      = null;
//  public TreeNode<MenuItem> component_Ui_ToggleGroupItem = null;
    
//  public TreeNode<MenuItem> component_Ui_SelectableItem  = null;
    #endregion
    
    #region Component -> Scripts
//  public TreeNode<MenuItem> component_ScriptsItem = null;
    #endregion
    
    #endregion
    
    #region Window
    public TreeNode<MenuItem> windowMenu                = null;
    
//  public TreeNode<MenuItem> window_NextWindowItem     = null;
//  public TreeNode<MenuItem> window_PreviousWindowItem = null;
    
    #region Window -> Layouts
    public TreeNode<MenuItem> window_LayoutsItem                       = null;
    
//  public TreeNode<MenuItem> window_Layouts_2_by_3Item                = null;
//  public TreeNode<MenuItem> window_Layouts_4_splitItem               = null;
//  public TreeNode<MenuItem> window_Layouts_DefaultItem               = null;
//  public TreeNode<MenuItem> window_Layouts_TallItem                  = null;
//  public TreeNode<MenuItem> window_Layouts_WideItem                  = null;
    
//  public TreeNode<MenuItem> window_Layouts_SaveLayoutItem            = null;
//  public TreeNode<MenuItem> window_Layouts_DeleteLayoutItem          = null;
//  public TreeNode<MenuItem> window_Layouts_RevertFactorySettingsItem = null;
    #endregion
    
//  public TreeNode<MenuItem> window_SceneItem             = null;
//  public TreeNode<MenuItem> window_GameItem              = null;
//  public TreeNode<MenuItem> window_InspectorItem         = null;
//  public TreeNode<MenuItem> window_HierarchyItem         = null;
//  public TreeNode<MenuItem> window_ProjectItem           = null;
//  public TreeNode<MenuItem> window_AnimationItem         = null;
//  public TreeNode<MenuItem> window_ProfilerItem          = null;
//  public TreeNode<MenuItem> window_AudioMixerItem        = null;
//  public TreeNode<MenuItem> window_AssetStoreItem        = null;
//  public TreeNode<MenuItem> window_VersionControlItem    = null;
//  public TreeNode<MenuItem> window_AnimatorParameterItem = null;
//  public TreeNode<MenuItem> window_AnimatorItem          = null;
//  public TreeNode<MenuItem> window_SpritePackerItem      = null;
    
//  public TreeNode<MenuItem> window_LightingItem          = null;
//  public TreeNode<MenuItem> window_OcclusionCullingItem  = null;
//  public TreeNode<MenuItem> window_FrameDebuggerItem     = null;
//  public TreeNode<MenuItem> window_NavigationItem        = null;
    
//  public TreeNode<MenuItem> window_ConsoleItem           = null;
    #endregion
    
    #region Help
    public TreeNode<MenuItem> helpMenu                    = null;
    
//  public TreeNode<MenuItem> help_AboutUnityItem         = null;
    
//  public TreeNode<MenuItem> help_ManageLicenseItem      = null;
    
//  public TreeNode<MenuItem> help_UnityManualItem        = null;
//  public TreeNode<MenuItem> help_ScriptingReferenceItem = null;
    
//  public TreeNode<MenuItem> help_UnityConnectItem       = null;
//  public TreeNode<MenuItem> help_UnityForumItem         = null;
//  public TreeNode<MenuItem> help_UnityAnswersItem       = null;
//  public TreeNode<MenuItem> help_UnityFeedbackItem      = null;
    
//  public TreeNode<MenuItem> help_CheckForUpdatesItem    = null;
//  public TreeNode<MenuItem> help_DownloadBetaItem       = null;
    
//  public TreeNode<MenuItem> help_ReleaseNotesItem       = null;
//  public TreeNode<MenuItem> help_ReportABugItem         = null;
    #endregion
    
    #endregion



    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenu_UI"/> class.
    /// </summary>
    public MainMenu_UI(MainMenuScript script)
    {
        mScript = script;

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
        fileMenu                  =   MenuItem.Create(mItems,   R.sections.MenuItems.strings.file,                 mScript.OnFileMenu); // TODO: Shortcuts
        
        /*mFile_NewSceneItem      =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__new_scene,      mScript.OnFile_NewScene);
        /*mFile_OpenSceneItem     =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__open_scene,     mScript.OnFile_OpenScene);
        MenuItem.InsertSeparator(fileMenu);
        /*mFile_SaveSceneItem     =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__save_scene,     mScript.OnFile_SaveScene);
        /*mFile_SaveSceneAsItem   =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__save_scene_as,  mScript.OnFile_SaveSceneAs);
        MenuItem.InsertSeparator(fileMenu);
        /*mFile_NewProjectItem    =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__new_project,    mScript.OnFile_NewProject);
        /*mFile_OpenProjectItem   =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__open_project,   mScript.OnFile_OpenProject);
        /*mFile_SaveProjectItem   =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__save_project,   mScript.OnFile_SaveProject);
        MenuItem.InsertSeparator(fileMenu);
        /*mFile_BuildSettingsItem =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__build_settings, mScript.OnFile_BuildSettings);
        /*mFile_BuildAndRunItem   =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__build_and_run,  mScript.OnFile_BuildAndRun);
        /*mFile_BuildInCloudItem  =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__build_in_cloud, mScript.OnFile_BuildInCloud);
        MenuItem.InsertSeparator(fileMenu);
        /*mFile_ExitItem          =*/ MenuItem.Create(fileMenu, R.sections.MenuItems.strings.file__exit,           mScript.OnFile_Exit);
        #endregion
        
        #region Edit
        editMenu                      =   MenuItem.Create(mItems,   R.sections.MenuItems.strings.edit,                        mScript.OnEditMenu);
        
        /*edit_UndoItem               =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__undo,                  mScript.OnEdit_Undo); // TODO: Change name of menu item after changes
        /*edit_RedoItem               =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__redo,                  mScript.OnEdit_Redo); // TODO: Change name of menu item after changes
        MenuItem.InsertSeparator(editMenu);
        /*edit_CutItem                =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__cut,                   mScript.OnEdit_Cut);
        /*edit_CopyItem               =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__copy,                  mScript.OnEdit_Copy);
        /*edit_PasteItem              =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__paste,                 mScript.OnEdit_Paste);
        MenuItem.InsertSeparator(editMenu);
        /*edit_DuplicateItem          =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__duplicate,             mScript.OnEdit_Duplicate);
        /*edit_DeleteItem             =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__delete,                mScript.OnEdit_Delete);
        MenuItem.InsertSeparator(editMenu);
        /*edit_FrameSelectedItem      =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__frame_selected,        mScript.OnEdit_FrameSelected);
        /*edit_LockViewToSelectedItem =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__lock_view_to_selected, mScript.OnEdit_LockViewToSelected);
        /*edit_FindItem               =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__find,                  mScript.OnEdit_Find);
        /*edit_SelectAllItem          =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__select_all,            mScript.OnEdit_SelectAll);
        MenuItem.InsertSeparator(editMenu);
        /*edit_PreferencesItem        =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__preferences,           mScript.OnEdit_Preferences);
        /*edit_ModulesItem            =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__modules,               mScript.OnEdit_Modules);
        MenuItem.InsertSeparator(editMenu);
        /*edit_PlayItem               =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__play,                  mScript.OnEdit_Play);
        /*edit_PauseItem              =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__pause,                 mScript.OnEdit_Pause);
        /*edit_StepItem               =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__step,                  mScript.OnEdit_Step);
        MenuItem.InsertSeparator(editMenu);
        
        #region Edit -> Selection
        edit_SelectionItem                  =   MenuItem.Create(editMenu,           R.sections.MenuItems.strings.edit__selection);
        
        /*edit_Selection_LoadSelection1Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_1, mScript.OnEdit_Selection_LoadSelection1);
        /*edit_Selection_LoadSelection2Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_2, mScript.OnEdit_Selection_LoadSelection2);
        /*edit_Selection_LoadSelection3Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_3, mScript.OnEdit_Selection_LoadSelection3);
        /*edit_Selection_LoadSelection4Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_4, mScript.OnEdit_Selection_LoadSelection4);
        /*edit_Selection_LoadSelection5Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_5, mScript.OnEdit_Selection_LoadSelection5);
        /*edit_Selection_LoadSelection6Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_6, mScript.OnEdit_Selection_LoadSelection6);
        /*edit_Selection_LoadSelection7Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_7, mScript.OnEdit_Selection_LoadSelection7);
        /*edit_Selection_LoadSelection8Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_8, mScript.OnEdit_Selection_LoadSelection8);
        /*edit_Selection_LoadSelection9Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_9, mScript.OnEdit_Selection_LoadSelection9);
        /*edit_Selection_LoadSelection0Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_0, mScript.OnEdit_Selection_LoadSelection0);
        
        /*edit_Selection_SaveSelection1Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_1, mScript.OnEdit_Selection_SaveSelection1);
        /*edit_Selection_SaveSelection2Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_2, mScript.OnEdit_Selection_SaveSelection2);
        /*edit_Selection_SaveSelection3Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_3, mScript.OnEdit_Selection_SaveSelection3);
        /*edit_Selection_SaveSelection4Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_4, mScript.OnEdit_Selection_SaveSelection4);
        /*edit_Selection_SaveSelection5Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_5, mScript.OnEdit_Selection_SaveSelection5);
        /*edit_Selection_SaveSelection6Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_6, mScript.OnEdit_Selection_SaveSelection6);
        /*edit_Selection_SaveSelection7Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_7, mScript.OnEdit_Selection_SaveSelection7);
        /*edit_Selection_SaveSelection8Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_8, mScript.OnEdit_Selection_SaveSelection8);
        /*edit_Selection_SaveSelection9Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_9, mScript.OnEdit_Selection_SaveSelection9);
        /*edit_Selection_SaveSelection0Item =*/ MenuItem.Create(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_0, mScript.OnEdit_Selection_SaveSelection0);
        #endregion
        
        MenuItem.InsertSeparator(editMenu);
        
        #region Edit -> Project Settings
        edit_ProjectSettingsItem                        =   MenuItem.Create(editMenu,                 R.sections.MenuItems.strings.edit__project_settings);
        
        /*edit_ProjectSettings_InputItem                =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__input,                  mScript.OnEdit_ProjectSettings_Input);
        /*edit_ProjectSettings_TagsAndLayersItem        =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__tags_and_layers,        mScript.OnEdit_ProjectSettings_TagsAndLayers);
        /*edit_ProjectSettings_AudioItem                =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__audio,                  mScript.OnEdit_ProjectSettings_Audio);
        /*edit_ProjectSettings_TimeItem                 =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__time,                   mScript.OnEdit_ProjectSettings_Time);
        /*edit_ProjectSettings_PlayerItem               =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__player,                 mScript.OnEdit_ProjectSettings_Player);
        /*edit_ProjectSettings_PhysicsItem              =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__physics,                mScript.OnEdit_ProjectSettings_Physics);
        /*edit_ProjectSettings_Physics2DItem            =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__physics_2d,             mScript.OnEdit_ProjectSettings_Physics2D);
        /*edit_ProjectSettings_QualityItem              =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__quality,                mScript.OnEdit_ProjectSettings_Quality);
        /*edit_ProjectSettings_GraphicsItem             =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__graphics,               mScript.OnEdit_ProjectSettings_Graphics);
        /*edit_ProjectSettings_NetworkItem              =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__network,                mScript.OnEdit_ProjectSettings_Network);
        /*edit_ProjectSettings_EditorItem               =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__editor,                 mScript.OnEdit_ProjectSettings_Editor);
        /*edit_ProjectSettings_ScriptExecutionOrderItem =*/ MenuItem.Create(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__script_execution_order, mScript.OnEdit_ProjectSettings_ScriptExecutionOrder);
        #endregion
        
        MenuItem.InsertSeparator(editMenu);
        
        #region Edit -> Network Emulation
        edit_NetworkEmulationItem                             =   MenuItem.Create(editMenu,                  R.sections.MenuItems.strings.edit__network_emulation);
        
        /*edit_NetworkEmulation_NetworkEmulationNoneItem      =*/ MenuItem.Create(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__none,      mScript.OnEdit_NetworkEmulation_None);
        /*edit_NetworkEmulation_NetworkEmulationBroadbandItem =*/ MenuItem.Create(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__broadband, mScript.OnEdit_NetworkEmulation_Broadband);
        /*edit_NetworkEmulation_NetworkEmulationDSLItem       =*/ MenuItem.Create(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__dsl,       mScript.OnEdit_NetworkEmulation_DSL);
        /*edit_NetworkEmulation_NetworkEmulationISDNItem      =*/ MenuItem.Create(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__isdn,      mScript.OnEdit_NetworkEmulation_ISDN);
        /*edit_NetworkEmulation_NetworkEmulationDialUpItem    =*/ MenuItem.Create(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__dial_up,   mScript.OnEdit_NetworkEmulation_DialUp);
        #endregion
        
        #region Edit -> Graphics Emulation
        edit_GraphicsEmulationItem                                 =   MenuItem.Create(editMenu,                   R.sections.MenuItems.strings.edit__graphics_emulation);
        
        /*edit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  =*/ MenuItem.Create(edit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__no_emulation,   mScript.OnEdit_GraphicsEmulation_NoEmulation);
        /*edit_GraphicsEmulation_GraphicsEmulationShaderModel3Item =*/ MenuItem.Create(edit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__shader_model_3, mScript.OnEdit_GraphicsEmulation_ShaderModel3);
        /*edit_GraphicsEmulation_GraphicsEmulationShaderModel2Item =*/ MenuItem.Create(edit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__shader_model_2, mScript.OnEdit_GraphicsEmulation_ShaderModel2);
        #endregion
        
        MenuItem.InsertSeparator(editMenu);
        /*edit_SnapSettingsItem =*/ MenuItem.Create(editMenu, R.sections.MenuItems.strings.edit__snap_settings, mScript.OnEdit_SnapSettings);
        #endregion
        
        #region Assets
        assetsMenu = MenuItem.Create(mItems, R.sections.MenuItems.strings.assets, mScript.OnAssetsMenu);
        
        #region Assets -> Create
        assets_CreateItem                             =   MenuItem.Create(assetsMenu,        R.sections.MenuItems.strings.assets__create);
        
        /*assets_Create_FolderItem                    =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__folder,                      mScript.OnAssets_Create_Folder);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_CSharpScriptItem              =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__c_sharp_script,              mScript.OnAssets_Create_CSharpScript);
        /*assets_Create_JavascriptItem                =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__javascript,                  mScript.OnAssets_Create_Javascript);
        /*assets_Create_ShaderItem                    =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__shader,                      mScript.OnAssets_Create_Shader);
        /*assets_Create_ComputeShaderItem             =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__compute_shader,              mScript.OnAssets_Create_ComputeShader);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_PrefabItem                    =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__prefab,                      mScript.OnAssets_Create_Prefab);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_AudioMixerItem                =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__audio_mixer,                 mScript.OnAssets_Create_AudioMixer);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_MaterialItem                  =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__material,                    mScript.OnAssets_Create_Material);
        /*assets_Create_LensFlareItem                 =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__lens_flare,                  mScript.OnAssets_Create_LensFlare);
        /*assets_Create_RenderTextureItem             =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__render_texture,              mScript.OnAssets_Create_RenderTexture);
        /*assets_Create_LightmapParametersItem        =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__lightmap_parameters,         mScript.OnAssets_Create_LightmapParameters);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_AnimatorControllerItem        =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__animator_controller,         mScript.OnAssets_Create_AnimatorController);
        /*assets_Create_AnimationItem                 =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__animation,                   mScript.OnAssets_Create_Animation);
        /*assets_Create_AnimatorOverrideContollerItem =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__animator_override_contoller, mScript.OnAssets_Create_AnimatorOverrideContoller);
        /*assets_Create_AvatarMaskItem                =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__avatar_mask,                 mScript.OnAssets_Create_AvatarMask);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_PhysicMaterialItem            =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__physic_material,             mScript.OnAssets_Create_PhysicMaterial);
        /*assets_Create_Physic2dMaterialItem          =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__physic2d_material,           mScript.OnAssets_Create_Physic2dMaterial);
        MenuItem.InsertSeparator(assets_CreateItem);
        /*assets_Create_GuiSkinItem                   =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__gui_skin,                    mScript.OnAssets_Create_GuiSkin);
        /*assets_Create_CustomFontItem                =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__custom_font,                 mScript.OnAssets_Create_CustomFont);
        /*assets_Create_ShaderVariantCollectionItem   =*/ MenuItem.Create(assets_CreateItem, R.sections.MenuItems.strings.assets__create__shader_variant_collection,   mScript.OnAssets_Create_ShaderVariantCollection);
        
        #region Assets -> Create -> Legacy
        assets_Create_LegacyItem           =   MenuItem.Create(assets_CreateItem,        R.sections.MenuItems.strings.assets__create__legacy);
        
        /*assets_Create_Legacy_CubemapItem =*/ MenuItem.Create(assets_Create_LegacyItem, R.sections.MenuItems.strings.assets__create__legacy__cubemap, mScript.OnAssets_Create_Legacy_Cubemap);
        #endregion
        
        #endregion
        
        /*assets_ShowInExplorerItem =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__show_in_explorer, mScript.OnAssets_ShowInExplorer);
        /*assets_OpenItem           =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__open,             mScript.OnAssets_Open);
        /*assets_DeleteItem         =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__delete,           mScript.OnAssets_Delete);
        MenuItem.InsertSeparator(assetsMenu);
        /*assets_ImportNewAssetItem =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__import_new_asset, mScript.OnAssets_ImportNewAsset);
        
        #region Assets -> Import Package
        assets_ImportPackageItem                           =   MenuItem.Create(assetsMenu,               R.sections.MenuItems.strings.assets__import_package);
        
        /*assets_ImportPackage_CustomPackageItem           =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__custom_package,       mScript.OnAssets_ImportPackage_CustomPackage);
        MenuItem.InsertSeparator(assets_ImportPackageItem);
        /*assets_ImportPackage_2dItem                      =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__2d,                   mScript.OnAssets_ImportPackage_2d);
        /*assets_ImportPackage_CamerasItem                 =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__cameras,              mScript.OnAssets_ImportPackage_Cameras);
        /*assets_ImportPackage_CharactersItem              =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__characters,           mScript.OnAssets_ImportPackage_Characters);
        /*assets_ImportPackage_CrossPlatformInputItem      =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__cross_platform_input, mScript.OnAssets_ImportPackage_CrossPlatformInput);
        /*assets_ImportPackage_EffectsItem                 =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__effects,              mScript.OnAssets_ImportPackage_Effects);
        /*assets_ImportPackage_EnvironmentItem             =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__environment,          mScript.OnAssets_ImportPackage_Environment);
        /*assets_ImportPackage_ParticleSystemsItem         =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__particle_systems,     mScript.OnAssets_ImportPackage_ParticleSystems);
        /*assets_ImportPackage_PrototypingItem             =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__prototyping,          mScript.OnAssets_ImportPackage_Prototyping);
        /*assets_ImportPackage_UtilityItem                 =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__utility,              mScript.OnAssets_ImportPackage_Utility);
        /*assets_ImportPackage_VehiclesItem                =*/ MenuItem.Create(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__vehicles,             mScript.OnAssets_ImportPackage_Vehicles);
        #endregion
        
        /*assets_ExportPackageItem          =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__export_package,           mScript.OnAssets_ExportPackage);
        /*assets_FindReferencesInSceneItem  =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__find_references_in_scene, mScript.OnAssets_FindReferencesInScene);
        /*assets_SelectDependenciesItem     =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__select_dependencies,      mScript.OnAssets_SelectDependencies);
        MenuItem.InsertSeparator(assetsMenu);
        /*assets_RefreshItem                =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__refresh,                  mScript.OnAssets_Refresh);
        /*assets_ReimportItem               =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__reimport,                 mScript.OnAssets_Reimport);
        MenuItem.InsertSeparator(assetsMenu);
        /*assets_ReimportAllItem            =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__reimport_all,             mScript.OnAssets_ReimportAll);
        MenuItem.InsertSeparator(assetsMenu);
        /*assets_RunApiUpdaterItem          =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__run_api_updater,          mScript.OnAssets_RunApiUpdater);
        MenuItem.InsertSeparator(assetsMenu);
        /*assets_SyncMonoDevelopProjectItem =*/ MenuItem.Create(assetsMenu, R.sections.MenuItems.strings.assets__sync_monodevelop_project, mScript.OnAssets_SyncMonoDevelopProject);
        #endregion
        
        #region GameObject
        gameObjectMenu                    =   MenuItem.Create(mItems,         R.sections.MenuItems.strings.gameobject, mScript.OnGameObjectMenu);
        
        /*gameObject_CreateEmptyItem      =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__create_empty,       mScript.OnGameObject_CreateEmpty);
        /*gameObject_CreateEmptyChildItem =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__create_empty_child, mScript.OnGameObject_CreateEmptyChild);
        
        #region GameObject -> 3D Object    
        gameObject_3dObjectItem            =   MenuItem.Create(gameObjectMenu,          R.sections.MenuItems.strings.gameobject__3d_object);
        
        /*gameObject_3dObject_CubeItem     =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__cube,      mScript.OnGameObject_3dObject_Cube);
        /*gameObject_3dObject_SphereItem   =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__sphere,    mScript.OnGameObject_3dObject_Sphere);
        /*gameObject_3dObject_CapsuleItem  =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__capsule,   mScript.OnGameObject_3dObject_Capsule);
        /*gameObject_3dObject_CylinderItem =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__cylinder,  mScript.OnGameObject_3dObject_Cylinder);
        /*gameObject_3dObject_PlaneItem    =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__plane,     mScript.OnGameObject_3dObject_Plane);
        /*gameObject_3dObject_QuadItem     =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__quad,      mScript.OnGameObject_3dObject_Quad);
        MenuItem.InsertSeparator(gameObject_3dObjectItem);
        /*gameObject_3dObject_RagdollItem  =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__ragdoll,   mScript.OnGameObject_3dObject_Ragdoll);
        MenuItem.InsertSeparator(gameObject_3dObjectItem);
        /*gameObject_3dObject_TerrainItem  =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__terrain,   mScript.OnGameObject_3dObject_Terrain);
        /*gameObject_3dObject_TreeItem     =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__tree,      mScript.OnGameObject_3dObject_Tree);
        /*gameObject_3dObject_WindZoneItem =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__wind_zone, mScript.OnGameObject_3dObject_WindZone);
        
        /*gameObject_3dObject_3dTextItem   =*/ MenuItem.Create(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__3d_text,   mScript.OnGameObject_3dObject_3dText);
        #endregion
        
        #region GameObject -> 2D Object    
        gameObject_2dObjectItem          =   MenuItem.Create(gameObjectMenu,          R.sections.MenuItems.strings.gameobject__2d_object);
        
        /*gameObject_2dObject_SpriteItem =*/ MenuItem.Create(gameObject_2dObjectItem, R.sections.MenuItems.strings.gameobject__2d_object__sprite, mScript.OnGameObject_2dObject_Sprite);
        #endregion
        
        #region GameObject -> Light
        gameObject_LightItem                    =   MenuItem.Create(gameObjectMenu,       R.sections.MenuItems.strings.gameobject__light);
        
        /*gameObject_Light_DirectionalLightItem =*/ MenuItem.Create(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__directional_light, mScript.OnGameObject_Light_DirectionalLight);
        /*gameObject_Light_PointLightItem       =*/ MenuItem.Create(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__point_light,       mScript.OnGameObject_Light_PointLight);
        /*gameObject_Light_SpotlightItem        =*/ MenuItem.Create(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__spotlight,         mScript.OnGameObject_Light_Spotlight);
        /*gameObject_Light_AreaLightItem        =*/ MenuItem.Create(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__area_light,        mScript.OnGameObject_Light_AreaLight);
        MenuItem.InsertSeparator(gameObject_LightItem);
        /*gameObject_Light_ReflectionProbeItem  =*/ MenuItem.Create(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__reflection_probe,  mScript.OnGameObject_Light_ReflectionProbe);
        /*gameObject_Light_LightProbeGroupItem  =*/ MenuItem.Create(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__light_probe_group, mScript.OnGameObject_Light_LightProbeGroup);
        #endregion
        
        #region GameObject -> Audio
        gameObject_AudioItem                   =   MenuItem.Create(gameObjectMenu,       R.sections.MenuItems.strings.gameobject__audio);
        
        /*gameObject_Audio_AudioSourceItem     =*/ MenuItem.Create(gameObject_AudioItem, R.sections.MenuItems.strings.gameobject__audio__audio_source,      mScript.OnGameObject_Audio_AudioSource);
        /*gameObject_Audio_AudioReverbZoneItem =*/ MenuItem.Create(gameObject_AudioItem, R.sections.MenuItems.strings.gameobject__audio__audio_reverb_zone, mScript.OnGameObject_Audio_AudioReverbZone);
        #endregion
        
        #region GameObject -> UI
        gameObject_UiItem               =   MenuItem.Create(gameObjectMenu,    R.sections.MenuItems.strings.gameobject__ui);
        
        /*gameObject_Ui_PanelItem       =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__panel,        mScript.OnGameObject_Ui_Panel);
        /*gameObject_Ui_ButtonItem      =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__button,       mScript.OnGameObject_Ui_Button);
        /*gameObject_Ui_TextItem        =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__text,         mScript.OnGameObject_Ui_Text);
        /*gameObject_Ui_ImageItem       =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__image,        mScript.OnGameObject_Ui_Image);
        /*gameObject_Ui_RawImageItem    =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__raw_image,    mScript.OnGameObject_Ui_RawImage);
        /*gameObject_Ui_SliderItem      =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__slider,       mScript.OnGameObject_Ui_Slider);
        /*gameObject_Ui_ScrollbarItem   =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__scrollbar,    mScript.OnGameObject_Ui_Scrollbar);
        /*gameObject_Ui_ToggleItem      =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__toggle,       mScript.OnGameObject_Ui_Toggle);
        /*gameObject_Ui_InputFieldItem  =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__input_field,  mScript.OnGameObject_Ui_InputField);
        /*gameObject_Ui_CanvasItem      =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__canvas,       mScript.OnGameObject_Ui_Canvas);
        /*gameObject_Ui_EventSystemItem =*/ MenuItem.Create(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__event_system, mScript.OnGameObject_Ui_EventSystem);
        #endregion
        
        /*gameObject_ParticleSystemItem       =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__particle_system,         mScript.OnGameObject_ParticleSystem);
        /*gameObject_CameraItem               =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__camera,                  mScript.OnGameObject_Camera);
        MenuItem.InsertSeparator(gameObjectMenu);
        /*gameObject_CenterOnChildrenItem     =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__center_on_children,      mScript.OnGameObject_CenterOnChildren);
        MenuItem.InsertSeparator(gameObjectMenu);
        /*gameObject_MakeParentItem           =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__make_parent,             mScript.OnGameObject_MakeParent);
        /*gameObject_ClearParentItem          =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__clear_parent,            mScript.OnGameObject_ClearParent);
        /*gameObject_ApplyChangesToPrefabItem =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__apply_changes_to_prefab, mScript.OnGameObject_ApplyChangesToPrefab);
        /*gameObject_BreakPrefabInstanceItem  =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__break_prefab_instance,   mScript.OnGameObject_BreakPrefabInstance);
        MenuItem.InsertSeparator(gameObjectMenu);
        /*gameObject_SetAsFirstSiblingItem    =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__set_as_first_sibling,    mScript.OnGameObject_SetAsFirstSibling);
        /*gameObject_SetAsLastSiblingItem     =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__set_as_last_sibling,     mScript.OnGameObject_SetAsLastSibling);
        /*gameObject_MoveToViewItem           =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__move_to_view,            mScript.OnGameObject_MoveToView);
        /*gameObject_AlignWithViewItem        =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__align_with_view,         mScript.OnGameObject_AlignWithView);
        /*gameObject_AlignViewToSelectedItem  =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__align_view_to_selected,  mScript.OnGameObject_AlignViewToSelected);
        /*gameObject_ToggleActiveStateItem    =*/ MenuItem.Create(gameObjectMenu, R.sections.MenuItems.strings.gameobject__toggle_active_state,     mScript.OnGameObject_ToggleActiveState);
        #endregion
        
        #region Component
        componentMenu       =   MenuItem.Create(mItems,        R.sections.MenuItems.strings.component,      mScript.OnComponentMenu);
        
        /*component_AddItem =*/ MenuItem.Create(componentMenu, R.sections.MenuItems.strings.component__add, mScript.OnComponent_Add);
        
        #region Component -> Mesh
        component_MeshItem                       =   MenuItem.Create(componentMenu,      R.sections.MenuItems.strings.component__mesh);
        
        /*component_Mesh_MeshFilterItem          =*/ MenuItem.Create(component_MeshItem, R.sections.MenuItems.strings.component__mesh__mesh_filter,           mScript.OnComponent_Mesh_MeshFilter);
        /*component_Mesh_TextMeshItem            =*/ MenuItem.Create(component_MeshItem, R.sections.MenuItems.strings.component__mesh__text_mesh,             mScript.OnComponent_Mesh_TextMesh);
        MenuItem.InsertSeparator(component_MeshItem);
        /*component_Mesh_MeshRendererItem        =*/ MenuItem.Create(component_MeshItem, R.sections.MenuItems.strings.component__mesh__mesh_renderer,         mScript.OnComponent_Mesh_MeshRenderer);
        /*component_Mesh_SkinnedMeshRendererItem =*/ MenuItem.Create(component_MeshItem, R.sections.MenuItems.strings.component__mesh__skinned_mesh_renderer, mScript.OnComponent_Mesh_SkinnedMeshRenderer);
        #endregion
        
        #region Component -> Effects
        component_EffectsItem                  =   MenuItem.Create(componentMenu,         R.sections.MenuItems.strings.component__effects);
        
        /*component_Effects_ParticleSystemItem =*/ MenuItem.Create(component_EffectsItem, R.sections.MenuItems.strings.component__effects__particle_system, mScript.OnComponent_Effects_ParticleSystem);
        /*component_Effects_TrailRendererItem  =*/ MenuItem.Create(component_EffectsItem, R.sections.MenuItems.strings.component__effects__trail_renderer,  mScript.OnComponent_Effects_TrailRenderer);
        /*component_Effects_LineRendererItem   =*/ MenuItem.Create(component_EffectsItem, R.sections.MenuItems.strings.component__effects__line_renderer,   mScript.OnComponent_Effects_LineRenderer);
        /*component_Effects_LensFlareItem      =*/ MenuItem.Create(component_EffectsItem, R.sections.MenuItems.strings.component__effects__lens_flare,      mScript.OnComponent_Effects_LensFlare);
        /*component_Effects_HaloItem           =*/ MenuItem.Create(component_EffectsItem, R.sections.MenuItems.strings.component__effects__halo,            mScript.OnComponent_Effects_Halo);
        /*component_Effects_ProjectorItem      =*/ MenuItem.Create(component_EffectsItem, R.sections.MenuItems.strings.component__effects__projector,       mScript.OnComponent_Effects_Projector);
        MenuItem.InsertSeparator(component_MeshItem);
        
        #region Component -> Effects -> Legacy Particles
        component_Effects_LegacyParticlesItem                            =   MenuItem.Create(component_EffectsItem,                 R.sections.MenuItems.strings.component__effects__legacy_particles);
        
        /*component_Effects_LegacyParticles_EllipsoidParticleEmitterItem =*/ MenuItem.Create(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__ellipsoid_particle_emitter, mScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter);
        /*component_Effects_LegacyParticles_MeshParticleEmitterItem      =*/ MenuItem.Create(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__mesh_particle_emitter,      mScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter);
        MenuItem.InsertSeparator(component_Effects_LegacyParticlesItem);
        /*component_Effects_LegacyParticles_ParticleAnimatorItem         =*/ MenuItem.Create(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__particle_animator,          mScript.OnComponent_Effects_LegacyParticles_ParticleAnimator);
        /*component_Effects_LegacyParticles_WorldParticleColliderItem    =*/ MenuItem.Create(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__world_particle_collider,    mScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider);
        MenuItem.InsertSeparator(component_Effects_LegacyParticlesItem);
        /*component_Effects_LegacyParticles_ParticleRendererItem         =*/ MenuItem.Create(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__particle_renderer,          mScript.OnComponent_Effects_LegacyParticles_ParticleRenderer);
        #endregion
        
        #endregion
        
        #region Component -> Physics
        component_PhysicsItem                       =   MenuItem.Create(componentMenu,         R.sections.MenuItems.strings.component__physics);
        
        /*component_Physics_RigidbodyItem           =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__rigidbody,            mScript.OnComponent_Physics_Rigidbody);
        /*component_Physics_CharacterControllerItem =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__character_controller, mScript.OnComponent_Physics_CharacterController);
        MenuItem.InsertSeparator(component_PhysicsItem);
        /*component_Physics_BoxColliderItem         =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__box_collider,         mScript.OnComponent_Physics_BoxCollider);
        /*component_Physics_SphereColliderItem      =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__sphere_collider,      mScript.OnComponent_Physics_SphereCollider);
        /*component_Physics_CapsuleColliderItem     =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__capsule_collider,     mScript.OnComponent_Physics_CapsuleCollider);
        /*component_Physics_MeshColliderItem        =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__mesh_collider,        mScript.OnComponent_Physics_MeshCollider);
        /*component_Physics_WheelColliderItem       =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__wheel_collider,       mScript.OnComponent_Physics_WheelCollider);
        /*component_Physics_TerrainColliderItem     =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__terrain_collider,     mScript.OnComponent_Physics_TerrainCollider);
        MenuItem.InsertSeparator(component_PhysicsItem);
        /*component_Physics_ClothItem               =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__cloth,                mScript.OnComponent_Physics_Cloth);
        MenuItem.InsertSeparator(component_PhysicsItem);
        /*component_Physics_HingeJointItem          =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__hinge_joint,          mScript.OnComponent_Physics_HingeJoint);
        /*component_Physics_FixedJointItem          =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__fixed_joint,          mScript.OnComponent_Physics_FixedJoint);
        /*component_Physics_SpringJointItem         =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__spring_joint,         mScript.OnComponent_Physics_SpringJoint);
        /*component_Physics_CharacterJointItem      =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__character_joint,      mScript.OnComponent_Physics_CharacterJoint);
        /*component_Physics_ConfigurableJointItem   =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__configurable_joint,   mScript.OnComponent_Physics_ConfigurableJoint);
        MenuItem.InsertSeparator(component_PhysicsItem);
        /*component_Physics_ConstantForceItem       =*/ MenuItem.Create(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__constant_force,       mScript.OnComponent_Physics_ConstantForce);
        #endregion
        
        #region Component -> Physics 2D
        component_Physics2dItem                      =   MenuItem.Create(componentMenu,           R.sections.MenuItems.strings.component__physics_2d);
        
        /*component_Physics2d_Rigidbody2dItem        =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__rigidbody_2d,         mScript.OnComponent_Physics2d_Rigidbody2d);
        MenuItem.InsertSeparator(component_Physics2dItem);
        /*component_Physics2d_CircleCollider2dItem   =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__circle_collider_2d,   mScript.OnComponent_Physics2d_CircleCollider2d);
        /*component_Physics2d_BoxCollider2dItem      =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__box_collider_2d,      mScript.OnComponent_Physics2d_BoxCollider2d);
        /*component_Physics2d_EdgeCollider2dItem     =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__edge_collider_2d,     mScript.OnComponent_Physics2d_EdgeCollider2d);
        /*component_Physics2d_PolygonCollider2dItem  =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__polygon_collider_2d,  mScript.OnComponent_Physics2d_PolygonCollider2d);
        MenuItem.InsertSeparator(component_Physics2dItem);
        /*component_Physics2d_SpringJoint2dItem      =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__spring_joint_2d,      mScript.OnComponent_Physics2d_SpringJoint2d);
        /*component_Physics2d_DistanceJoint2dItem    =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__distance_joint_2d,    mScript.OnComponent_Physics2d_DistanceJoint2d);
        /*component_Physics2d_HingeJoint2dItem       =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__hinge_joint_2d,       mScript.OnComponent_Physics2d_HingeJoint2d);
        /*component_Physics2d_SliderJoint2dItem      =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__slider_joint_2d,      mScript.OnComponent_Physics2d_SliderJoint2d);
        /*component_Physics2d_WheelJoint2dItem       =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__wheel_joint_2d,       mScript.OnComponent_Physics2d_WheelJoint2d);
        MenuItem.InsertSeparator(component_Physics2dItem);
        /*component_Physics2d_ConstantForce2dItem    =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__constant_force_2d,    mScript.OnComponent_Physics2d_ConstantForce2d);
        MenuItem.InsertSeparator(component_Physics2dItem);
        /*component_Physics2d_AreaEffector2dItem     =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__area_effector_2d,     mScript.OnComponent_Physics2d_AreaEffector2d);
        /*component_Physics2d_PointEffector2dItem    =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__point_effector_2d,    mScript.OnComponent_Physics2d_PointEffector2d);
        /*component_Physics2d_PlatformEffector2dItem =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__platform_effector_2d, mScript.OnComponent_Physics2d_PlatformEffector2d);
        /*component_Physics2d_SurfaceEffector2dItem  =*/ MenuItem.Create(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__surface_effector_2d,  mScript.OnComponent_Physics2d_SurfaceEffector2d);
        #endregion
        
        #region Component -> Navigation
        component_NavigationItem                   =   MenuItem.Create(componentMenu,            R.sections.MenuItems.strings.component__navigation);
        
        /*component_Navigation_NavMeshAgentItem    =*/ MenuItem.Create(component_NavigationItem, R.sections.MenuItems.strings.component__navigation__nav_mesh_agent,    mScript.OnComponent_Navigation_NavMeshAgent);
        /*component_Navigation_OffMeshLinkItem     =*/ MenuItem.Create(component_NavigationItem, R.sections.MenuItems.strings.component__navigation__off_mesh_link,     mScript.OnComponent_Navigation_OffMeshLink);
        /*component_Navigation_NavMeshObstacleItem =*/ MenuItem.Create(component_NavigationItem, R.sections.MenuItems.strings.component__navigation__nav_mesh_obstacle, mScript.OnComponent_Navigation_NavMeshObstacle);
        #endregion
        
        #region Component -> Audio
        component_AudioItem                         =   MenuItem.Create(componentMenu,       R.sections.MenuItems.strings.component__audio);
        
        /*component_Audio_AudioListenerItem         =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_listener,          mScript.OnComponent_Audio_AudioListener);
        /*component_Audio_AudioSourceItem           =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_source,            mScript.OnComponent_Audio_AudioSource);
        /*component_Audio_AudioReverbZoneItem       =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_reverb_zone,       mScript.OnComponent_Audio_AudioReverbZone);
        MenuItem.InsertSeparator(component_AudioItem);
        /*component_Audio_AudioLowPassFilterItem    =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_low_pass_filter,   mScript.OnComponent_Audio_AudioLowPassFilter);
        /*component_Audio_AudioHighPassFilterItem   =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_high_pass_filter,  mScript.OnComponent_Audio_AudioHighPassFilter);
        /*component_Audio_AudioEchoFilterItem       =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_echo_filter,       mScript.OnComponent_Audio_AudioEchoFilter);
        /*component_Audio_AudioDistortionFilterItem =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_distortion_filter, mScript.OnComponent_Audio_AudioDistortionFilter);
        /*component_Audio_AudioReverbFilterItem     =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_reverb_filter,     mScript.OnComponent_Audio_AudioReverbFilter);
        /*component_Audio_AudioChorusFilterItem     =*/ MenuItem.Create(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_chorus_filter,     mScript.OnComponent_Audio_AudioChorusFilter);
        #endregion
        
        #region Component -> Rendering
        component_RenderingItem                   =   MenuItem.Create(componentMenu,           R.sections.MenuItems.strings.component__rendering);
        
        /*component_Rendering_CameraItem          =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__camera,            mScript.OnComponent_Rendering_Camera);
        /*component_Rendering_SkyboxItem          =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__skybox,            mScript.OnComponent_Rendering_Skybox);
        /*component_Rendering_FlareLayerItem      =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__flare_layer,       mScript.OnComponent_Rendering_FlareLayer);
        /*component_Rendering_GuiLayerItem        =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_layer,         mScript.OnComponent_Rendering_GuiLayer);
        MenuItem.InsertSeparator(component_RenderingItem);
        /*component_Rendering_LightItem           =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__light,             mScript.OnComponent_Rendering_Light);
        /*component_Rendering_LightProbeGroupItem =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__light_probe_group, mScript.OnComponent_Rendering_LightProbeGroup);
        /*component_Rendering_ReflectionProbeItem =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__reflection_probe,  mScript.OnComponent_Rendering_ReflectionProbe);
        MenuItem.InsertSeparator(component_RenderingItem);
        /*component_Rendering_OcclusionAreaItem   =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__occlusion_area,    mScript.OnComponent_Rendering_OcclusionArea);
        /*component_Rendering_OcclusionPortalItem =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__occlusion_portal,  mScript.OnComponent_Rendering_OcclusionPortal);
        /*component_Rendering_LodGroupItem        =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__lod_group,         mScript.OnComponent_Rendering_LodGroup);
        MenuItem.InsertSeparator(component_RenderingItem);
        /*component_Rendering_SpriteRendererItem  =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__sprite_renderer,   mScript.OnComponent_Rendering_SpriteRenderer);
        /*component_Rendering_CanvasRendererItem  =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__canvas_renderer,   mScript.OnComponent_Rendering_CanvasRenderer);
        MenuItem.InsertSeparator(component_RenderingItem);
        /*component_Rendering_GuiTextureItem      =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_texture,       mScript.OnComponent_Rendering_GuiTexture);
        /*component_Rendering_GuiTextItem         =*/ MenuItem.Create(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_text,          mScript.OnComponent_Rendering_GuiText);
        #endregion
        
        #region Component -> Layout
        component_LayoutItem                         =   MenuItem.Create(componentMenu,        R.sections.MenuItems.strings.component__layout);
        
        /*component_Layout_RectTransformItem         =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__rect_transform,          mScript.OnComponent_Layout_RectTransform);
        /*component_Layout_CanvasItem                =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas,                  mScript.OnComponent_Layout_Canvas);
        /*component_Layout_CanvasGroupItem           =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas_group,            mScript.OnComponent_Layout_CanvasGroup);
        MenuItem.InsertSeparator(component_LayoutItem);
        /*component_Layout_CanvasScalerItem          =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas_scaler,           mScript.OnComponent_Layout_CanvasScaler);
        MenuItem.InsertSeparator(component_LayoutItem);
        /*component_Layout_LayoutElementItem         =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__layout_element,          mScript.OnComponent_Layout_LayoutElement);
        /*component_Layout_ContentSizeFitterItem     =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__content_size_fitter,     mScript.OnComponent_Layout_ContentSizeFitter);
        /*component_Layout_AspectRatioFitterItem     =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__aspect_ratio_fitter,     mScript.OnComponent_Layout_AspectRatioFitter);
        /*component_Layout_HorizontalLayoutGroupItem =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__horizontal_layout_group, mScript.OnComponent_Layout_HorizontalLayoutGroup);
        /*component_Layout_VerticalLayoutGroupItem   =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__vertical_layout_group,   mScript.OnComponent_Layout_VerticalLayoutGroup);
        /*component_Layout_GridLayoutGroupItem       =*/ MenuItem.Create(component_LayoutItem, R.sections.MenuItems.strings.component__layout__grid_layout_group,       mScript.OnComponent_Layout_GridLayoutGroup);
        #endregion
        
        #region Component -> Miscellaneous
        component_MiscellaneousItem                     =   MenuItem.Create(componentMenu,               R.sections.MenuItems.strings.component__miscellaneous);
        
        /*component_Miscellaneous_AnimatorItem          =*/ MenuItem.Create(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__animator,           mScript.OnComponent_Miscellaneous_Animator);
        /*component_Miscellaneous_AnimationItem         =*/ MenuItem.Create(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__animation,          mScript.OnComponent_Miscellaneous_Animation);
        /*component_Miscellaneous_NetworkViewItem       =*/ MenuItem.Create(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__network_view,       mScript.OnComponent_Miscellaneous_NetworkView);
        /*component_Miscellaneous_WindZoneItem          =*/ MenuItem.Create(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__wind_zone,          mScript.OnComponent_Miscellaneous_WindZone);
        /*component_Miscellaneous_TerrainItem           =*/ MenuItem.Create(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__terrain,            mScript.OnComponent_Miscellaneous_Terrain);
        /*component_Miscellaneous_BillboardRendererItem =*/ MenuItem.Create(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__billboard_renderer, mScript.OnComponent_Miscellaneous_BillboardRenderer);
        #endregion
        
        #region Component -> Event
        component_EventItem                         =   MenuItem.Create(componentMenu,       R.sections.MenuItems.strings.component__event);
        
        /*component_Event_EventSystemItem           =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__event_system,            mScript.OnComponent_Event_EventSystem);
        /*component_Event_EventTriggerItem          =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__event_trigger,           mScript.OnComponent_Event_EventTrigger);
        /*component_Event_Physics2dRaycasterItem    =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__physics_2d_raycaster,    mScript.OnComponent_Event_Physics2dRaycaster);
        /*component_Event_PhysicsRaycasterItem      =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__physics_raycaster,       mScript.OnComponent_Event_PhysicsRaycaster);
        /*component_Event_StandaloneInputModuleItem =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__standalone_input_module, mScript.OnComponent_Event_StandaloneInputModule);
        /*component_Event_TouchInputModuleItem      =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__touch_input_module,      mScript.OnComponent_Event_TouchInputModule);
        /*component_Event_GraphicRaycasterItem      =*/ MenuItem.Create(component_EventItem, R.sections.MenuItems.strings.component__event__graphic_raycaster,       mScript.OnComponent_Event_GraphicRaycaster);
        #endregion
        
        #region Component -> UI
        component_UiItem = MenuItem.Create(componentMenu, R.sections.MenuItems.strings.component__ui);
        
        #region Component -> UI -> Effects
        component_Ui_EffectsItem                 =   MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__effects);
        
        /*component_Ui_Effects_ShadowItem        =*/ MenuItem.Create(component_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__shadow,          mScript.OnComponent_Ui_Effects_Shadow);
        /*component_Ui_Effects_OutlineItem       =*/ MenuItem.Create(component_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__outline,         mScript.OnComponent_Ui_Effects_Outline);
        /*component_Ui_Effects_PositionAsUv1Item =*/ MenuItem.Create(component_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__position_as_uv1, mScript.OnComponent_Ui_Effects_PositionAsUv1);
        #endregion
        
        /*component_Ui_ImageItem       =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__image,        mScript.OnComponent_Ui_Image);
        /*component_Ui_TextItem        =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__text,         mScript.OnComponent_Ui_Text);
        /*component_Ui_RawImageItem    =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__raw_image,    mScript.OnComponent_Ui_RawImage);
        /*component_Ui_MaskItem        =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__mask,         mScript.OnComponent_Ui_Mask);
        MenuItem.InsertSeparator(component_UiItem);
        /*component_Ui_ButtonItem      =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__button,       mScript.OnComponent_Ui_Button);
        /*component_Ui_InputFieldItem  =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__input_field,  mScript.OnComponent_Ui_InputField);
        /*component_Ui_ScrollbarItem   =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__scrollbar,    mScript.OnComponent_Ui_Scrollbar);
        /*component_Ui_ScrollRectItem  =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__scroll_rect,  mScript.OnComponent_Ui_ScrollRect);
        /*component_Ui_SliderItem      =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__slider,       mScript.OnComponent_Ui_Slider);
        /*component_Ui_ToggleItem      =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__toggle,       mScript.OnComponent_Ui_Toggle);
        /*component_Ui_ToggleGroupItem =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__toggle_group, mScript.OnComponent_Ui_ToggleGroup);
        MenuItem.InsertSeparator(component_UiItem);
        /*component_Ui_SelectableItem  =*/ MenuItem.Create(component_UiItem, R.sections.MenuItems.strings.component__ui__selectable,   mScript.OnComponent_Ui_Selectable);
        #endregion
        
        #region Component -> Scripts
        /*component_ScriptsItem =*/ MenuItem.Create(componentMenu, R.sections.MenuItems.strings.component__scripts);
        #endregion
        
        #endregion
        
        #region Window
        windowMenu                  =   MenuItem.Create(mItems,     R.sections.MenuItems.strings.window,                  mScript.OnWindowMenu);
        
        /*window_NextWindowItem     =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__next_window,     mScript.OnWindow_NextWindow);
        /*window_PreviousWindowItem =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__previous_window, mScript.OnWindow_PreviousWindow);
        MenuItem.InsertSeparator(windowMenu);
        
        #region Window -> Layouts
        window_LayoutsItem                         =   MenuItem.Create(windowMenu,         R.sections.MenuItems.strings.window__layouts);
        
        /*window_Layouts_2_by_3Item                =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__2_by_3,                  mScript.OnWindow_Layouts_2_by_3);
        /*window_Layouts_4_splitItem               =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__4_split,                 mScript.OnWindow_Layouts_4_split);
        /*window_Layouts_DefaultItem               =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__default,                 mScript.OnWindow_Layouts_Default);
        /*window_Layouts_TallItem                  =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__tall,                    mScript.OnWindow_Layouts_Tall);
        /*window_Layouts_WideItem                  =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__wide,                    mScript.OnWindow_Layouts_Wide);
        MenuItem.InsertSeparator(window_LayoutsItem);
        /*window_Layouts_SaveLayoutItem            =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__save_layout,             mScript.OnWindow_Layouts_SaveLayout);
        /*window_Layouts_DeleteLayoutItem          =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__delete_layout,           mScript.OnWindow_Layouts_DeleteLayout);
        /*window_Layouts_RevertFactorySettingsItem =*/ MenuItem.Create(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__revert_factory_settings, mScript.OnWindow_Layouts_RevertFactorySettings);
        #endregion
        
        MenuItem.InsertSeparator(windowMenu);
        /*window_SceneItem             =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__scene,              mScript.OnWindow_Scene);
        /*window_GameItem              =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__game,               mScript.OnWindow_Game);
        /*window_InspectorItem         =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__inspector,          mScript.OnWindow_Inspector);
        /*window_HierarchyItem         =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__hierarchy,          mScript.OnWindow_Hierarchy);
        /*window_ProjectItem           =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__project,            mScript.OnWindow_Project);
        /*window_AnimationItem         =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__animation,          mScript.OnWindow_Animation);
        /*window_ProfilerItem          =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__profiler,           mScript.OnWindow_Profiler);
        /*window_AudioMixerItem        =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__audio_mixer,        mScript.OnWindow_AudioMixer);
        /*window_AssetStoreItem        =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__asset_store,        mScript.OnWindow_AssetStore);
        /*window_VersionControlItem    =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__version_control,    mScript.OnWindow_VersionControl);
        /*window_AnimatorParameterItem =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__animator_parameter, mScript.OnWindow_AnimatorParameter);
        /*window_AnimatorItem          =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__animator,           mScript.OnWindow_Animator);
        /*window_SpritePackerItem      =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__sprite_packer,      mScript.OnWindow_SpritePacker);
        MenuItem.InsertSeparator(windowMenu);
        /*window_LightingItem          =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__lighting,           mScript.OnWindow_Lighting);
        /*window_OcclusionCullingItem  =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__occlusion_culling,  mScript.OnWindow_OcclusionCulling);
        /*window_FrameDebuggerItem     =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__frame_debugger,     mScript.OnWindow_FrameDebugger);
        /*window_NavigationItem        =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__navigation,         mScript.OnWindow_Navigation);
        MenuItem.InsertSeparator(windowMenu);
        /*window_ConsoleItem           =*/ MenuItem.Create(windowMenu, R.sections.MenuItems.strings.window__console,            mScript.OnWindow_Console);
        #endregion
        
        #region Help
        helpMenu                      =   MenuItem.Create(mItems,   R.sections.MenuItems.strings.help,                      mScript.OnHelpMenu);
        
        /*help_AboutUnityItem         =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__about_unity,         mScript.OnHelp_AboutUnity);
        MenuItem.InsertSeparator(helpMenu);
        /*help_ManageLicenseItem      =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__manage_license,      mScript.OnHelp_ManageLicense);
        MenuItem.InsertSeparator(helpMenu);
        /*help_UnityManualItem        =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__unity_manual,        mScript.OnHelp_UnityManual);
        /*help_ScriptingReferenceItem =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__scripting_reference, mScript.OnHelp_ScriptingReference);
        MenuItem.InsertSeparator(helpMenu);
        /*help_UnityConnectItem       =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__unity_connect,       mScript.OnHelp_UnityConnect);
        /*help_UnityForumItem         =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__unity_forum,         mScript.OnHelp_UnityForum);
        /*help_UnityAnswersItem       =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__unity_answers,       mScript.OnHelp_UnityAnswers);
        /*help_UnityFeedbackItem      =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__unity_feedback,      mScript.OnHelp_UnityFeedback);
        MenuItem.InsertSeparator(helpMenu);
        /*help_CheckForUpdatesItem    =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__check_for_updates,   mScript.OnHelp_CheckForUpdates);
        /*help_DownloadBetaItem       =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__download_beta,       mScript.OnHelp_DownloadBeta);
        MenuItem.InsertSeparator(helpMenu);
        /*help_ReleaseNotesItem       =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__release_notes,       mScript.OnHelp_ReleaseNotes);
        /*help_ReportABugItem         =*/ MenuItem.Create(helpMenu, R.sections.MenuItems.strings.help__report_a_bug,        mScript.OnHelp_ReportABug);
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
        Utils.InitUIObject(scrollArea, mScript.transform);
        
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
            GameObject menuItemButton = Object.Instantiate(mScript.menuButton.gameObject) as GameObject;
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
            
            if (menuItem.Data.Enabled)
            {
                button.onClick.AddListener(menuItem.Data.OnClick);
            }
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
}
