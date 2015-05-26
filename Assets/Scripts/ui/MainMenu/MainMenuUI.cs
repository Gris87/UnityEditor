using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityTranslation;

using common;
using common.ui;



namespace ui
{
	public class MainMenuUI
	{
	    private MainMenuScript mScript;

	    #region Menu items
	    private TreeNode<CustomMenuItem> mItems;
	    
	    #region File
	    public TreeNode<CustomMenuItem> fileMenu;
	    
//      public TreeNode<CustomMenuItem> file_NewSceneItem;
//      public TreeNode<CustomMenuItem> file_OpenSceneItem;
	    
//      public TreeNode<CustomMenuItem> file_SaveSceneItem;
//      public TreeNode<CustomMenuItem> file_SaveSceneAsItem;
	    
//      public TreeNode<CustomMenuItem> file_NewProjectItem;
//      public TreeNode<CustomMenuItem> file_OpenProjectItem;
//      public TreeNode<CustomMenuItem> file_SaveProjectItem;
	    
//      public TreeNode<CustomMenuItem> file_BuildSettingsItem;
//      public TreeNode<CustomMenuItem> file_BuildAndRunItem;
//      public TreeNode<CustomMenuItem> file_BuildInCloudItem;
	    
//      public TreeNode<CustomMenuItem> file_ExitItem;
	    #endregion
	    
	    #region Edit
	    public TreeNode<CustomMenuItem> editMenu;
	    
//      public TreeNode<CustomMenuItem> edit_UndoItem;
//      public TreeNode<CustomMenuItem> edit_RedoItem;
	    
//      public TreeNode<CustomMenuItem> edit_CutItem;
//      public TreeNode<CustomMenuItem> edit_CopyItem;
//      public TreeNode<CustomMenuItem> edit_PasteItem;
	    
//      public TreeNode<CustomMenuItem> edit_DuplicateItem;
//      public TreeNode<CustomMenuItem> edit_DeleteItem;
	    
//      public TreeNode<CustomMenuItem> edit_FrameSelectedItem;
//      public TreeNode<CustomMenuItem> edit_LockViewToSelectedItem;
//      public TreeNode<CustomMenuItem> edit_FindItem;
//      public TreeNode<CustomMenuItem> edit_SelectAllItem;
	    
//      public TreeNode<CustomMenuItem> edit_PreferencesItem;
//      public TreeNode<CustomMenuItem> edit_ModulesItem;
	    
//      public TreeNode<CustomMenuItem> edit_PlayItem;
//      public TreeNode<CustomMenuItem> edit_PauseItem;
//      public TreeNode<CustomMenuItem> edit_StepItem;
	    
	    #region Edit -> Selection
	    public TreeNode<CustomMenuItem> edit_SelectionItem;
	    
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection1Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection2Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection3Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection4Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection5Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection6Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection7Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection8Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection9Item;
//      public TreeNode<CustomMenuItem> edit_Selection_LoadSelection0Item;
	    
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection1Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection2Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection3Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection4Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection5Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection6Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection7Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection8Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection9Item;
//      public TreeNode<CustomMenuItem> edit_Selection_SaveSelection0Item;
	    #endregion
	    
	    #region Edit -> Project Settings
	    public TreeNode<CustomMenuItem> edit_ProjectSettingsItem;
	    
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_InputItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_TagsAndLayersItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_AudioItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_TimeItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_PlayerItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_PhysicsItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_Physics2DItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_QualityItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_GraphicsItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_NetworkItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_EditorItem;
//      public TreeNode<CustomMenuItem> edit_ProjectSettings_ScriptExecutionOrderItem;
	    #endregion
	    
	    #region Edit -> Network Emulation
	    public TreeNode<CustomMenuItem> edit_NetworkEmulationItem;
		public MenuRadioGroup           edit_NetworkEmulationRadioGroup;
	    
//      public TreeNode<CustomMenuItem> edit_NetworkEmulation_NetworkEmulationNoneItem;
//      public TreeNode<CustomMenuItem> edit_NetworkEmulation_NetworkEmulationBroadbandItem;
//      public TreeNode<CustomMenuItem> edit_NetworkEmulation_NetworkEmulationDSLItem;
//      public TreeNode<CustomMenuItem> edit_NetworkEmulation_NetworkEmulationISDNItem;
//      public TreeNode<CustomMenuItem> edit_NetworkEmulation_NetworkEmulationDialUpItem;
	    #endregion
	    
	    #region Edit -> Graphics Emulation
	    public TreeNode<CustomMenuItem> edit_GraphicsEmulationItem;
		public MenuRadioGroup           edit_GraphicsEmulationRadioGroup;
	    
//      public TreeNode<CustomMenuItem> edit_GraphicsEmulation_GraphicsEmulationNoEmulationItem;
//      public TreeNode<CustomMenuItem> edit_GraphicsEmulation_GraphicsEmulationShaderModel3Item;
//      public TreeNode<CustomMenuItem> edit_GraphicsEmulation_GraphicsEmulationShaderModel2Item;
	    #endregion
	    
//      public TreeNode<CustomMenuItem> edit_SnapSettingsItem;
	    #endregion
	    
	    #region Assets
	    public TreeNode<CustomMenuItem> assetsMenu;
	    
	    #region Assets -> Create
	    public TreeNode<CustomMenuItem> assets_CreateItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_FolderItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_CSharpScriptItem;
//      public TreeNode<CustomMenuItem> assets_Create_JavascriptItem;
//      public TreeNode<CustomMenuItem> assets_Create_ShaderItem;
//      public TreeNode<CustomMenuItem> assets_Create_ComputeShaderItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_PrefabItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_AudioMixerItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_MaterialItem;
//      public TreeNode<CustomMenuItem> assets_Create_LensFlareItem;
//      public TreeNode<CustomMenuItem> assets_Create_RenderTextureItem;
//      public TreeNode<CustomMenuItem> assets_Create_LightmapParametersItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_AnimatorControllerItem;
//      public TreeNode<CustomMenuItem> assets_Create_AnimationItem;
//      public TreeNode<CustomMenuItem> assets_Create_AnimatorOverrideContollerItem;
//      public TreeNode<CustomMenuItem> assets_Create_AvatarMaskItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_PhysicMaterialItem;
//      public TreeNode<CustomMenuItem> assets_Create_Physic2dMaterialItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_GuiSkinItem;
//      public TreeNode<CustomMenuItem> assets_Create_CustomFontItem;
//      public TreeNode<CustomMenuItem> assets_Create_ShaderVariantCollectionItem;
	    
	    #region Assets -> Create -> Legacy
	    public TreeNode<CustomMenuItem> assets_Create_LegacyItem;
	    
//      public TreeNode<CustomMenuItem> assets_Create_Legacy_CubemapItem;
	    #endregion
	    
	    #endregion
	    
//      public TreeNode<CustomMenuItem> assets_ShowInExplorerItem;
//      public TreeNode<CustomMenuItem> assets_OpenItem;
//      public TreeNode<CustomMenuItem> assets_DeleteItem;
	    
//      public TreeNode<CustomMenuItem> assets_ImportNewAssetItem;
	    
	    #region Assets -> Import Package
	    public TreeNode<CustomMenuItem> assets_ImportPackageItem;
	    
//      public TreeNode<CustomMenuItem> assets_ImportPackage_CustomPackageItem;
	    
//      public TreeNode<CustomMenuItem> assets_ImportPackage_2dItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_CamerasItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_CharactersItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_CrossPlatformInputItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_EffectsItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_EnvironmentItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_ParticleSystemsItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_PrototypingItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_UtilityItem;
//      public TreeNode<CustomMenuItem> assets_ImportPackage_VehiclesItem;
	    #endregion
	    
//      public TreeNode<CustomMenuItem> assets_ExportPackageItem;
//      public TreeNode<CustomMenuItem> assets_FindReferencesInSceneItem;
//      public TreeNode<CustomMenuItem> assets_SelectDependenciesItem;
	    
//      public TreeNode<CustomMenuItem> assets_RefreshItem;
//      public TreeNode<CustomMenuItem> assets_ReimportItem;
	    
//      public TreeNode<CustomMenuItem> assets_ReimportAllItem;
	    
//      public TreeNode<CustomMenuItem> assets_RunApiUpdaterItem;
	    
//      public TreeNode<CustomMenuItem> assets_SyncMonoDevelopProjectItem;
	    
	    #endregion
	    
	    #region GameObject
	    public TreeNode<CustomMenuItem> gameObjectMenu;
	    
//      public TreeNode<CustomMenuItem> gameObject_CreateEmptyItem;
//      public TreeNode<CustomMenuItem> gameObject_CreateEmptyChildItem;
	    
	    #region GameObject -> 3D Object    
	    public TreeNode<CustomMenuItem> gameObject_3dObjectItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_3dObject_CubeItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_SphereItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_CapsuleItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_CylinderItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_PlaneItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_QuadItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_3dObject_RagdollItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_3dObject_TerrainItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_TreeItem;
//      public TreeNode<CustomMenuItem> gameObject_3dObject_WindZoneItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_3dObject_3dTextItem;
	    #endregion
	    
	    #region GameObject -> 2D Object    
	    public TreeNode<CustomMenuItem> gameObject_2dObjectItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_2dObject_SpriteItem;
	    #endregion
	    
	    #region GameObject -> Light
	    public TreeNode<CustomMenuItem> gameObject_LightItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_Light_DirectionalLightItem;
//      public TreeNode<CustomMenuItem> gameObject_Light_PointLightItem;
//      public TreeNode<CustomMenuItem> gameObject_Light_SpotlightItem;
//      public TreeNode<CustomMenuItem> gameObject_Light_AreaLightItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_Light_ReflectionProbeItem;
//      public TreeNode<CustomMenuItem> gameObject_Light_LightProbeGroupItem;
	    #endregion
	    
	    #region GameObject -> Audio
	    public TreeNode<CustomMenuItem> gameObject_AudioItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_Audio_AudioSourceItem;
//      public TreeNode<CustomMenuItem> gameObject_Audio_AudioReverbZoneItem;
	    #endregion
	    
	    #region GameObject -> UI
	    public TreeNode<CustomMenuItem> gameObject_UiItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_Ui_PanelItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_ButtonItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_TextItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_ImageItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_RawImageItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_SliderItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_ScrollbarItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_ToggleItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_InputFieldItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_CanvasItem;
//      public TreeNode<CustomMenuItem> gameObject_Ui_EventSystemItem;
	    #endregion
	    
//      public TreeNode<CustomMenuItem> gameObject_ParticleSystemItem;
//      public TreeNode<CustomMenuItem> gameObject_CameraItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_CenterOnChildrenItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_MakeParentItem;
//      public TreeNode<CustomMenuItem> gameObject_ClearParentItem;
//      public TreeNode<CustomMenuItem> gameObject_ApplyChangesToPrefabItem;
//      public TreeNode<CustomMenuItem> gameObject_BreakPrefabInstanceItem;
	    
//      public TreeNode<CustomMenuItem> gameObject_SetAsFirstSiblingItem;
//      public TreeNode<CustomMenuItem> gameObject_SetAsLastSiblingItem;
//      public TreeNode<CustomMenuItem> gameObject_MoveToViewItem;
//      public TreeNode<CustomMenuItem> gameObject_AlignWithViewItem;
//      public TreeNode<CustomMenuItem> gameObject_AlignViewToSelectedItem;
//      public TreeNode<CustomMenuItem> gameObject_ToggleActiveStateItem;
	    #endregion
	    
	    #region Component
	    public TreeNode<CustomMenuItem> componentMenu;
	    
//      public TreeNode<CustomMenuItem> component_AddItem;
	    
	    #region Component -> Mesh
	    public TreeNode<CustomMenuItem> component_MeshItem;
	    
//      public TreeNode<CustomMenuItem> component_Mesh_MeshFilterItem;
//      public TreeNode<CustomMenuItem> component_Mesh_TextMeshItem;
	    
//      public TreeNode<CustomMenuItem> component_Mesh_MeshRendererItem;
//      public TreeNode<CustomMenuItem> component_Mesh_SkinnedMeshRendererItem;
	    #endregion
	    
	    #region Component -> Effects
	    public TreeNode<CustomMenuItem> component_EffectsItem;
	    
//      public TreeNode<CustomMenuItem> component_Effects_ParticleSystemItem;
//      public TreeNode<CustomMenuItem> component_Effects_TrailRendererItem;
//      public TreeNode<CustomMenuItem> component_Effects_LineRendererItem;
//      public TreeNode<CustomMenuItem> component_Effects_LensFlareItem;
//      public TreeNode<CustomMenuItem> component_Effects_HaloItem;
//      public TreeNode<CustomMenuItem> component_Effects_ProjectorItem;
	    
	    #region Component -> Effects -> Legacy Particles
	    public TreeNode<CustomMenuItem> component_Effects_LegacyParticlesItem;
	    
//      public TreeNode<CustomMenuItem> component_Effects_LegacyParticles_EllipsoidParticleEmitterItem;
//      public TreeNode<CustomMenuItem> component_Effects_LegacyParticles_MeshParticleEmitterItem;
	    
//      public TreeNode<CustomMenuItem> component_Effects_LegacyParticles_ParticleAnimatorItem;
//      public TreeNode<CustomMenuItem> component_Effects_LegacyParticles_WorldParticleColliderItem;
	    
//      public TreeNode<CustomMenuItem> component_Effects_LegacyParticles_ParticleRendererItem;
	    #endregion
	    
	    #endregion
	    
	    #region Component -> Physics
	    public TreeNode<CustomMenuItem> component_PhysicsItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics_RigidbodyItem;
//      public TreeNode<CustomMenuItem> component_Physics_CharacterControllerItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics_BoxColliderItem;
//      public TreeNode<CustomMenuItem> component_Physics_SphereColliderItem;
//      public TreeNode<CustomMenuItem> component_Physics_CapsuleColliderItem;
//      public TreeNode<CustomMenuItem> component_Physics_MeshColliderItem;
//      public TreeNode<CustomMenuItem> component_Physics_WheelColliderItem;
//      public TreeNode<CustomMenuItem> component_Physics_TerrainColliderItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics_ClothItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics_HingeJointItem;
//      public TreeNode<CustomMenuItem> component_Physics_FixedJointItem;
//      public TreeNode<CustomMenuItem> component_Physics_SpringJointItem;
//      public TreeNode<CustomMenuItem> component_Physics_CharacterJointItem;
//      public TreeNode<CustomMenuItem> component_Physics_ConfigurableJointItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics_ConstantForceItem;
	    #endregion
	    
	    #region Component -> Physics 2D
	    public TreeNode<CustomMenuItem> component_Physics2dItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics2d_Rigidbody2dItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics2d_CircleCollider2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_BoxCollider2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_EdgeCollider2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_PolygonCollider2dItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics2d_SpringJoint2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_DistanceJoint2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_HingeJoint2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_SliderJoint2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_WheelJoint2dItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics2d_ConstantForce2dItem;
	    
//      public TreeNode<CustomMenuItem> component_Physics2d_AreaEffector2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_PointEffector2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_PlatformEffector2dItem;
//      public TreeNode<CustomMenuItem> component_Physics2d_SurfaceEffector2dItem;
	    #endregion
	    
	    #region Component -> Navigation
	    public TreeNode<CustomMenuItem> component_NavigationItem;
	    
//      public TreeNode<CustomMenuItem> component_Navigation_NavMeshAgentItem;
//      public TreeNode<CustomMenuItem> component_Navigation_OffMeshLinkItem;
//      public TreeNode<CustomMenuItem> component_Navigation_NavMeshObstacleItem;
	    #endregion
	    
	    #region Component -> Audio
	    public TreeNode<CustomMenuItem> component_AudioItem;
	    
//      public TreeNode<CustomMenuItem> component_Audio_AudioListenerItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioSourceItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioReverbZoneItem;
	    
//      public TreeNode<CustomMenuItem> component_Audio_AudioLowPassFilterItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioHighPassFilterItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioEchoFilterItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioDistortionFilterItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioReverbFilterItem;
//      public TreeNode<CustomMenuItem> component_Audio_AudioChorusFilterItem;
	    #endregion
	    
	    #region Component -> Rendering
	    public TreeNode<CustomMenuItem> component_RenderingItem;
	    
//      public TreeNode<CustomMenuItem> component_Rendering_CameraItem;
//      public TreeNode<CustomMenuItem> component_Rendering_SkyboxItem;
//      public TreeNode<CustomMenuItem> component_Rendering_FlareLayerItem;
//      public TreeNode<CustomMenuItem> component_Rendering_GuiLayerItem;
	    
//      public TreeNode<CustomMenuItem> component_Rendering_LightItem;
//      public TreeNode<CustomMenuItem> component_Rendering_LightProbeGroupItem;
//      public TreeNode<CustomMenuItem> component_Rendering_ReflectionProbeItem;
	    
//      public TreeNode<CustomMenuItem> component_Rendering_OcclusionAreaItem;
//      public TreeNode<CustomMenuItem> component_Rendering_OcclusionPortalItem;
//      public TreeNode<CustomMenuItem> component_Rendering_LodGroupItem;
	    
//      public TreeNode<CustomMenuItem> component_Rendering_SpriteRendererItem;
//      public TreeNode<CustomMenuItem> component_Rendering_CanvasRendererItem;
	    
//      public TreeNode<CustomMenuItem> component_Rendering_GuiTextureItem;
//      public TreeNode<CustomMenuItem> component_Rendering_GuiTextItem;
	    #endregion
	    
	    #region Component -> Layout
	    public TreeNode<CustomMenuItem> component_LayoutItem;
	    
//      public TreeNode<CustomMenuItem> component_Layout_RectTransformItem;
//      public TreeNode<CustomMenuItem> component_Layout_CanvasItem;
//      public TreeNode<CustomMenuItem> component_Layout_CanvasGroupItem;
	    
//      public TreeNode<CustomMenuItem> component_Layout_CanvasScalerItem;
	    
//      public TreeNode<CustomMenuItem> component_Layout_LayoutElementItem;
//      public TreeNode<CustomMenuItem> component_Layout_ContentSizeFitterItem;
//      public TreeNode<CustomMenuItem> component_Layout_AspectRatioFitterItem;
//      public TreeNode<CustomMenuItem> component_Layout_HorizontalLayoutGroupItem;
//      public TreeNode<CustomMenuItem> component_Layout_VerticalLayoutGroupItem;
//      public TreeNode<CustomMenuItem> component_Layout_GridLayoutGroupItem;
	    #endregion
	    
	    #region Component -> Miscellaneous
	    public TreeNode<CustomMenuItem> component_MiscellaneousItem;
	    
//      public TreeNode<CustomMenuItem> component_Miscellaneous_AnimatorItem;
//      public TreeNode<CustomMenuItem> component_Miscellaneous_AnimationItem;
//      public TreeNode<CustomMenuItem> component_Miscellaneous_NetworkViewItem;
//      public TreeNode<CustomMenuItem> component_Miscellaneous_WindZoneItem;
//      public TreeNode<CustomMenuItem> component_Miscellaneous_TerrainItem;
//      public TreeNode<CustomMenuItem> component_Miscellaneous_BillboardRendererItem;
	    #endregion
	    
	    #region Component -> Event
	    public TreeNode<CustomMenuItem> component_EventItem;
	    
//      public TreeNode<CustomMenuItem> component_Event_EventSystemItem;
//      public TreeNode<CustomMenuItem> component_Event_EventTriggerItem;
//      public TreeNode<CustomMenuItem> component_Event_Physics2dRaycasterItem;
//      public TreeNode<CustomMenuItem> component_Event_PhysicsRaycasterItem;
//      public TreeNode<CustomMenuItem> component_Event_StandaloneInputModuleItem;
//      public TreeNode<CustomMenuItem> component_Event_TouchInputModuleItem;
//      public TreeNode<CustomMenuItem> component_Event_GraphicRaycasterItem;
	    #endregion
	    
	    #region Component -> UI
	    public TreeNode<CustomMenuItem> component_UiItem;
	    
	    #region Component -> UI -> Effects
	    public TreeNode<CustomMenuItem> component_Ui_EffectsItem;
	    
//      public TreeNode<CustomMenuItem> component_Ui_Effects_ShadowItem;
//      public TreeNode<CustomMenuItem> component_Ui_Effects_OutlineItem;
//      public TreeNode<CustomMenuItem> component_Ui_Effects_PositionAsUv1Item;
	    #endregion
	    
//      public TreeNode<CustomMenuItem> component_Ui_ImageItem;
//      public TreeNode<CustomMenuItem> component_Ui_TextItem;
//      public TreeNode<CustomMenuItem> component_Ui_RawImageItem;
//      public TreeNode<CustomMenuItem> component_Ui_MaskItem;
	    
//      public TreeNode<CustomMenuItem> component_Ui_ButtonItem;
//      public TreeNode<CustomMenuItem> component_Ui_InputFieldItem;
//      public TreeNode<CustomMenuItem> component_Ui_ScrollbarItem;
//      public TreeNode<CustomMenuItem> component_Ui_ScrollRectItem;
//      public TreeNode<CustomMenuItem> component_Ui_SliderItem;
//      public TreeNode<CustomMenuItem> component_Ui_ToggleItem;
//      public TreeNode<CustomMenuItem> component_Ui_ToggleGroupItem;
	    
//      public TreeNode<CustomMenuItem> component_Ui_SelectableItem;
	    #endregion
	    
	    #region Component -> Scripts
//      public TreeNode<CustomMenuItem> component_ScriptsItem;
	    #endregion
	    
	    #endregion
	    
	    #region Window
	    public TreeNode<CustomMenuItem> windowMenu;
	    
//      public TreeNode<CustomMenuItem> window_NextWindowItem;
//      public TreeNode<CustomMenuItem> window_PreviousWindowItem;
	    
	    #region Window -> Layouts
	    public TreeNode<CustomMenuItem> window_LayoutsItem;
	    
//      public TreeNode<CustomMenuItem> window_Layouts_2_by_3Item;
//      public TreeNode<CustomMenuItem> window_Layouts_4_splitItem;
//      public TreeNode<CustomMenuItem> window_Layouts_DefaultItem;
//      public TreeNode<CustomMenuItem> window_Layouts_TallItem;
//      public TreeNode<CustomMenuItem> window_Layouts_WideItem;
	    
//      public TreeNode<CustomMenuItem> window_Layouts_SaveLayoutItem;
//      public TreeNode<CustomMenuItem> window_Layouts_DeleteLayoutItem;
//      public TreeNode<CustomMenuItem> window_Layouts_RevertFactorySettingsItem;
	    #endregion
	    
//      public TreeNode<CustomMenuItem> window_SceneItem;
//      public TreeNode<CustomMenuItem> window_GameItem;
//      public TreeNode<CustomMenuItem> window_InspectorItem;
//      public TreeNode<CustomMenuItem> window_HierarchyItem;
//      public TreeNode<CustomMenuItem> window_ProjectItem;
//      public TreeNode<CustomMenuItem> window_AnimationItem;
//      public TreeNode<CustomMenuItem> window_ProfilerItem;
//      public TreeNode<CustomMenuItem> window_AudioMixerItem;
//      public TreeNode<CustomMenuItem> window_AssetStoreItem;
//      public TreeNode<CustomMenuItem> window_VersionControlItem;
//      public TreeNode<CustomMenuItem> window_AnimatorParameterItem;
//      public TreeNode<CustomMenuItem> window_AnimatorItem;
//      public TreeNode<CustomMenuItem> window_SpritePackerItem;
	    
//      public TreeNode<CustomMenuItem> window_LightingItem;
//      public TreeNode<CustomMenuItem> window_OcclusionCullingItem;
//      public TreeNode<CustomMenuItem> window_FrameDebuggerItem;
//      public TreeNode<CustomMenuItem> window_NavigationItem;
	    
//      public TreeNode<CustomMenuItem> window_ConsoleItem;
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
		/// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class with given token ID and with
		/// assigning to specified <see cref="common.TreeNode`1"/> instance.
		/// </summary>
		/// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
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
		/// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class with given text and with
		/// assigning to specified <see cref="common.TreeNode`1"/> instance.
		/// </summary>
		/// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
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
	        
	        #region File
	        fileMenu                  =   MakeItem(mItems,   R.sections.MenuItems.strings.file,                 mScript.OnFileMenu);
	        
	        /*mFile_NewSceneItem      =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__new_scene,      mScript.OnFile_NewScene,      true, "Ctrl+N");
			/*mFile_OpenSceneItem     =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__open_scene,     mScript.OnFile_OpenScene,     true, "Ctrl+O");
	        MenuSeparatorItem.Create(fileMenu);
			/*mFile_SaveSceneItem     =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__save_scene,     mScript.OnFile_SaveScene,     true, "Ctrl+S");
			/*mFile_SaveSceneAsItem   =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__save_scene_as,  mScript.OnFile_SaveSceneAs,   true, "Ctrl+Shift+S");
	        MenuSeparatorItem.Create(fileMenu);
	        /*mFile_NewProjectItem    =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__new_project,    mScript.OnFile_NewProject);
	        /*mFile_OpenProjectItem   =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__open_project,   mScript.OnFile_OpenProject);
	        /*mFile_SaveProjectItem   =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__save_project,   mScript.OnFile_SaveProject);
	        MenuSeparatorItem.Create(fileMenu);
			/*mFile_BuildSettingsItem =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__build_settings, mScript.OnFile_BuildSettings, true, "Ctrl+Shift+B");
			/*mFile_BuildAndRunItem   =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__build_and_run,  mScript.OnFile_BuildAndRun,   true, "Ctrl+B");
	        /*mFile_BuildInCloudItem  =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__build_in_cloud, mScript.OnFile_BuildInCloud);
	        MenuSeparatorItem.Create(fileMenu);
			/*mFile_ExitItem          =*/ MakeItem(fileMenu, R.sections.MenuItems.strings.file__exit,           mScript.OnFile_Exit);
	        #endregion
	        
	        #region Edit
	        editMenu                      =   MakeItem(mItems,   R.sections.MenuItems.strings.edit,                        mScript.OnEditMenu);
	        
			/*edit_UndoItem               =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__undo,                  mScript.OnEdit_Undo,               false, "Ctrl+Z"); // TODO: Change text of menu item after changes
			/*edit_RedoItem               =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__redo,                  mScript.OnEdit_Redo,               false, "Ctrl+Y"); // TODO: Change text of menu item after changes
	        MenuSeparatorItem.Create(editMenu);
			/*edit_CutItem                =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__cut,                   mScript.OnEdit_Cut,                true,  "Ctrl+X");
			/*edit_CopyItem               =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__copy,                  mScript.OnEdit_Copy,               true,  "Ctrl+C");
			/*edit_PasteItem              =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__paste,                 mScript.OnEdit_Paste,              true,  "Ctrl+V");
	        MenuSeparatorItem.Create(editMenu);
			/*edit_DuplicateItem          =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__duplicate,             mScript.OnEdit_Duplicate,          true,  "Ctrl+D");
			/*edit_DeleteItem             =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__delete,                mScript.OnEdit_Delete,             true,  "Shift+Del");
	        MenuSeparatorItem.Create(editMenu);
			/*edit_FrameSelectedItem      =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__frame_selected,        mScript.OnEdit_FrameSelected,      true,  "F");
			/*edit_LockViewToSelectedItem =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__lock_view_to_selected, mScript.OnEdit_LockViewToSelected, true,  "Shift+F");
			/*edit_FindItem               =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__find,                  mScript.OnEdit_Find,               true,  "Ctrl+F");
			/*edit_SelectAllItem          =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__select_all,            mScript.OnEdit_SelectAll,          true,  "Ctrl+A");
	        MenuSeparatorItem.Create(editMenu);
	        /*edit_PreferencesItem        =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__preferences,           mScript.OnEdit_Preferences);
	        /*edit_ModulesItem            =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__modules,               mScript.OnEdit_Modules);
	        MenuSeparatorItem.Create(editMenu);
			/*edit_PlayItem               =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__play,                  mScript.OnEdit_Play,               true,  "Ctrl+P");
			/*edit_PauseItem              =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__pause,                 mScript.OnEdit_Pause,              true,  "Ctrl+Shift+P");
			/*edit_StepItem               =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__step,                  mScript.OnEdit_Step,               true,  "Ctrl+Alt+P");
	        MenuSeparatorItem.Create(editMenu);
	        
	        #region Edit -> Selection
	        edit_SelectionItem                  =   MakeItem(editMenu,           R.sections.MenuItems.strings.edit__selection);
	        
			/*edit_Selection_LoadSelection1Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_1, mScript.OnEdit_Selection_LoadSelection1, false, "Ctrl+Shift+1");
			/*edit_Selection_LoadSelection2Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_2, mScript.OnEdit_Selection_LoadSelection2, false, "Ctrl+Shift+2");
			/*edit_Selection_LoadSelection3Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_3, mScript.OnEdit_Selection_LoadSelection3, false, "Ctrl+Shift+3");
			/*edit_Selection_LoadSelection4Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_4, mScript.OnEdit_Selection_LoadSelection4, false, "Ctrl+Shift+4");
			/*edit_Selection_LoadSelection5Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_5, mScript.OnEdit_Selection_LoadSelection5, false, "Ctrl+Shift+5");
			/*edit_Selection_LoadSelection6Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_6, mScript.OnEdit_Selection_LoadSelection6, false, "Ctrl+Shift+6");
			/*edit_Selection_LoadSelection7Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_7, mScript.OnEdit_Selection_LoadSelection7, false, "Ctrl+Shift+7");
			/*edit_Selection_LoadSelection8Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_8, mScript.OnEdit_Selection_LoadSelection8, false, "Ctrl+Shift+8");
			/*edit_Selection_LoadSelection9Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_9, mScript.OnEdit_Selection_LoadSelection9, false, "Ctrl+Shift+9");
			/*edit_Selection_LoadSelection0Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__load_selection_0, mScript.OnEdit_Selection_LoadSelection0, false, "Ctrl+Shift+0");
	        
			/*edit_Selection_SaveSelection1Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_1, mScript.OnEdit_Selection_SaveSelection1, false, "Ctrl+Alt+1");
			/*edit_Selection_SaveSelection2Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_2, mScript.OnEdit_Selection_SaveSelection2, false, "Ctrl+Alt+2");
			/*edit_Selection_SaveSelection3Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_3, mScript.OnEdit_Selection_SaveSelection3, false, "Ctrl+Alt+3");
			/*edit_Selection_SaveSelection4Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_4, mScript.OnEdit_Selection_SaveSelection4, false, "Ctrl+Alt+4");
			/*edit_Selection_SaveSelection5Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_5, mScript.OnEdit_Selection_SaveSelection5, false, "Ctrl+Alt+5");
			/*edit_Selection_SaveSelection6Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_6, mScript.OnEdit_Selection_SaveSelection6, false, "Ctrl+Alt+6");
			/*edit_Selection_SaveSelection7Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_7, mScript.OnEdit_Selection_SaveSelection7, false, "Ctrl+Alt+7");
			/*edit_Selection_SaveSelection8Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_8, mScript.OnEdit_Selection_SaveSelection8, false, "Ctrl+Alt+8");
			/*edit_Selection_SaveSelection9Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_9, mScript.OnEdit_Selection_SaveSelection9, false, "Ctrl+Alt+9");
			/*edit_Selection_SaveSelection0Item =*/ MakeItem(edit_SelectionItem, R.sections.MenuItems.strings.edit__selection__save_selection_0, mScript.OnEdit_Selection_SaveSelection0, false, "Ctrl+Alt+0");
	        #endregion
	        
	        MenuSeparatorItem.Create(editMenu);
	        
	        #region Edit -> Project Settings
	        edit_ProjectSettingsItem                        =   MakeItem(editMenu,                 R.sections.MenuItems.strings.edit__project_settings);
	        
	        /*edit_ProjectSettings_InputItem                =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__input,                  mScript.OnEdit_ProjectSettings_Input);
	        /*edit_ProjectSettings_TagsAndLayersItem        =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__tags_and_layers,        mScript.OnEdit_ProjectSettings_TagsAndLayers);
	        /*edit_ProjectSettings_AudioItem                =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__audio,                  mScript.OnEdit_ProjectSettings_Audio);
	        /*edit_ProjectSettings_TimeItem                 =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__time,                   mScript.OnEdit_ProjectSettings_Time);
	        /*edit_ProjectSettings_PlayerItem               =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__player,                 mScript.OnEdit_ProjectSettings_Player);
	        /*edit_ProjectSettings_PhysicsItem              =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__physics,                mScript.OnEdit_ProjectSettings_Physics);
	        /*edit_ProjectSettings_Physics2DItem            =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__physics_2d,             mScript.OnEdit_ProjectSettings_Physics2D);
	        /*edit_ProjectSettings_QualityItem              =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__quality,                mScript.OnEdit_ProjectSettings_Quality);
	        /*edit_ProjectSettings_GraphicsItem             =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__graphics,               mScript.OnEdit_ProjectSettings_Graphics);
	        /*edit_ProjectSettings_NetworkItem              =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__network,                mScript.OnEdit_ProjectSettings_Network);
	        /*edit_ProjectSettings_EditorItem               =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__editor,                 mScript.OnEdit_ProjectSettings_Editor);
	        /*edit_ProjectSettings_ScriptExecutionOrderItem =*/ MakeItem(edit_ProjectSettingsItem, R.sections.MenuItems.strings.edit__project_settings__script_execution_order, mScript.OnEdit_ProjectSettings_ScriptExecutionOrder);
	        #endregion
	        
	        MenuSeparatorItem.Create(editMenu);
	        
	        #region Edit -> Network Emulation
	        edit_NetworkEmulationItem                             =   MakeItem(editMenu,                  R.sections.MenuItems.strings.edit__network_emulation);
			edit_NetworkEmulationRadioGroup                       =   new MenuRadioGroup();
	        
			/*edit_NetworkEmulation_NetworkEmulationNoneItem      =*/ MakeItem(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__none,      mScript.OnEdit_NetworkEmulation_None,      true, null, edit_NetworkEmulationRadioGroup);
			/*edit_NetworkEmulation_NetworkEmulationBroadbandItem =*/ MakeItem(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__broadband, mScript.OnEdit_NetworkEmulation_Broadband, true, null, edit_NetworkEmulationRadioGroup);
			/*edit_NetworkEmulation_NetworkEmulationDSLItem       =*/ MakeItem(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__dsl,       mScript.OnEdit_NetworkEmulation_DSL,       true, null, edit_NetworkEmulationRadioGroup);
			/*edit_NetworkEmulation_NetworkEmulationISDNItem      =*/ MakeItem(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__isdn,      mScript.OnEdit_NetworkEmulation_ISDN,      true, null, edit_NetworkEmulationRadioGroup);
			/*edit_NetworkEmulation_NetworkEmulationDialUpItem    =*/ MakeItem(edit_NetworkEmulationItem, R.sections.MenuItems.strings.edit__network_emulation__dial_up,   mScript.OnEdit_NetworkEmulation_DialUp,    true, null, edit_NetworkEmulationRadioGroup);
	        #endregion
	        
	        #region Edit -> Graphics Emulation
			edit_GraphicsEmulationItem                                 =   MakeItem(editMenu,                   R.sections.MenuItems.strings.edit__graphics_emulation);
			edit_GraphicsEmulationRadioGroup                           =   new MenuRadioGroup();
            
			/*edit_GraphicsEmulation_GraphicsEmulationNoEmulationItem  =*/ MakeItem(edit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__no_emulation,   mScript.OnEdit_GraphicsEmulation_NoEmulation,  true, null, edit_GraphicsEmulationRadioGroup);
			/*edit_GraphicsEmulation_GraphicsEmulationShaderModel3Item =*/ MakeItem(edit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__shader_model_3, mScript.OnEdit_GraphicsEmulation_ShaderModel3, true, null, edit_GraphicsEmulationRadioGroup);
			/*edit_GraphicsEmulation_GraphicsEmulationShaderModel2Item =*/ MakeItem(edit_GraphicsEmulationItem, R.sections.MenuItems.strings.edit__graphics_emulation__shader_model_2, mScript.OnEdit_GraphicsEmulation_ShaderModel2, true, null, edit_GraphicsEmulationRadioGroup);
	        #endregion
	        
	        MenuSeparatorItem.Create(editMenu);
	        /*edit_SnapSettingsItem =*/ MakeItem(editMenu, R.sections.MenuItems.strings.edit__snap_settings, mScript.OnEdit_SnapSettings);
	        #endregion
	        
	        #region Assets
	        assetsMenu = MakeItem(mItems, R.sections.MenuItems.strings.assets, mScript.OnAssetsMenu);
	        
	        #region Assets -> Create
	        assets_CreateItem                             =   MakeItem(assetsMenu,        R.sections.MenuItems.strings.assets__create);
	        
	        /*assets_Create_FolderItem                    =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__folder,                      mScript.OnAssets_Create_Folder);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_CSharpScriptItem              =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__c_sharp_script,              mScript.OnAssets_Create_CSharpScript);
	        /*assets_Create_JavascriptItem                =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__javascript,                  mScript.OnAssets_Create_Javascript);
	        /*assets_Create_ShaderItem                    =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__shader,                      mScript.OnAssets_Create_Shader);
	        /*assets_Create_ComputeShaderItem             =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__compute_shader,              mScript.OnAssets_Create_ComputeShader);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_PrefabItem                    =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__prefab,                      mScript.OnAssets_Create_Prefab);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_AudioMixerItem                =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__audio_mixer,                 mScript.OnAssets_Create_AudioMixer);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_MaterialItem                  =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__material,                    mScript.OnAssets_Create_Material);
	        /*assets_Create_LensFlareItem                 =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__lens_flare,                  mScript.OnAssets_Create_LensFlare);
	        /*assets_Create_RenderTextureItem             =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__render_texture,              mScript.OnAssets_Create_RenderTexture);
	        /*assets_Create_LightmapParametersItem        =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__lightmap_parameters,         mScript.OnAssets_Create_LightmapParameters);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_AnimatorControllerItem        =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__animator_controller,         mScript.OnAssets_Create_AnimatorController);
	        /*assets_Create_AnimationItem                 =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__animation,                   mScript.OnAssets_Create_Animation);
	        /*assets_Create_AnimatorOverrideContollerItem =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__animator_override_contoller, mScript.OnAssets_Create_AnimatorOverrideContoller);
	        /*assets_Create_AvatarMaskItem                =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__avatar_mask,                 mScript.OnAssets_Create_AvatarMask);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_PhysicMaterialItem            =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__physic_material,             mScript.OnAssets_Create_PhysicMaterial);
	        /*assets_Create_Physic2dMaterialItem          =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__physic2d_material,           mScript.OnAssets_Create_Physic2dMaterial);
	        MenuSeparatorItem.Create(assets_CreateItem);
	        /*assets_Create_GuiSkinItem                   =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__gui_skin,                    mScript.OnAssets_Create_GuiSkin);
	        /*assets_Create_CustomFontItem                =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__custom_font,                 mScript.OnAssets_Create_CustomFont);
	        /*assets_Create_ShaderVariantCollectionItem   =*/ MakeItem(assets_CreateItem, R.sections.MenuItems.strings.assets__create__shader_variant_collection,   mScript.OnAssets_Create_ShaderVariantCollection);
	        
	        #region Assets -> Create -> Legacy
	        assets_Create_LegacyItem           =   MakeItem(assets_CreateItem,        R.sections.MenuItems.strings.assets__create__legacy);
	        
	        /*assets_Create_Legacy_CubemapItem =*/ MakeItem(assets_Create_LegacyItem, R.sections.MenuItems.strings.assets__create__legacy__cubemap, mScript.OnAssets_Create_Legacy_Cubemap);
	        #endregion
	        
	        #endregion
	        
	        /*assets_ShowInExplorerItem =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__show_in_explorer, mScript.OnAssets_ShowInExplorer);
	        /*assets_OpenItem           =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__open,             mScript.OnAssets_Open,   false);
	        /*assets_DeleteItem         =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__delete,           mScript.OnAssets_Delete, false);
	        MenuSeparatorItem.Create(assetsMenu);
	        /*assets_ImportNewAssetItem =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__import_new_asset, mScript.OnAssets_ImportNewAsset);
	        
	        #region Assets -> Import Package
	        assets_ImportPackageItem                           =   MakeItem(assetsMenu,               R.sections.MenuItems.strings.assets__import_package);
	        
	        /*assets_ImportPackage_CustomPackageItem           =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__custom_package,       mScript.OnAssets_ImportPackage_CustomPackage);
	        MenuSeparatorItem.Create(assets_ImportPackageItem);
	        /*assets_ImportPackage_2dItem                      =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__2d,                   mScript.OnAssets_ImportPackage_2d);
	        /*assets_ImportPackage_CamerasItem                 =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__cameras,              mScript.OnAssets_ImportPackage_Cameras);
	        /*assets_ImportPackage_CharactersItem              =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__characters,           mScript.OnAssets_ImportPackage_Characters);
	        /*assets_ImportPackage_CrossPlatformInputItem      =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__cross_platform_input, mScript.OnAssets_ImportPackage_CrossPlatformInput);
	        /*assets_ImportPackage_EffectsItem                 =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__effects,              mScript.OnAssets_ImportPackage_Effects);
	        /*assets_ImportPackage_EnvironmentItem             =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__environment,          mScript.OnAssets_ImportPackage_Environment);
	        /*assets_ImportPackage_ParticleSystemsItem         =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__particle_systems,     mScript.OnAssets_ImportPackage_ParticleSystems);
	        /*assets_ImportPackage_PrototypingItem             =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__prototyping,          mScript.OnAssets_ImportPackage_Prototyping);
	        /*assets_ImportPackage_UtilityItem                 =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__utility,              mScript.OnAssets_ImportPackage_Utility);
	        /*assets_ImportPackage_VehiclesItem                =*/ MakeItem(assets_ImportPackageItem, R.sections.MenuItems.strings.assets__import_package__vehicles,             mScript.OnAssets_ImportPackage_Vehicles);
	        #endregion
	        
	        /*assets_ExportPackageItem          =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__export_package,           mScript.OnAssets_ExportPackage);
	        /*assets_FindReferencesInSceneItem  =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__find_references_in_scene, mScript.OnAssets_FindReferencesInScene, false);
	        /*assets_SelectDependenciesItem     =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__select_dependencies,      mScript.OnAssets_SelectDependencies);
	        MenuSeparatorItem.Create(assetsMenu);
	        /*assets_RefreshItem                =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__refresh,                  mScript.OnAssets_Refresh,               true, "Ctrl+R");
	        /*assets_ReimportItem               =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__reimport,                 mScript.OnAssets_Reimport,              false);
	        MenuSeparatorItem.Create(assetsMenu);
	        /*assets_ReimportAllItem            =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__reimport_all,             mScript.OnAssets_ReimportAll);
	        MenuSeparatorItem.Create(assetsMenu);
	        /*assets_RunApiUpdaterItem          =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__run_api_updater,          mScript.OnAssets_RunApiUpdater,         false);
	        MenuSeparatorItem.Create(assetsMenu);
	        /*assets_SyncMonoDevelopProjectItem =*/ MakeItem(assetsMenu, R.sections.MenuItems.strings.assets__sync_monodevelop_project, mScript.OnAssets_SyncMonoDevelopProject);
	        #endregion
	        
	        #region GameObject
	        gameObjectMenu                    =   MakeItem(mItems,         R.sections.MenuItems.strings.gameobject, mScript.OnGameObjectMenu);
	        
			/*gameObject_CreateEmptyItem      =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__create_empty,       mScript.OnGameObject_CreateEmpty,      true, "Ctrl+Shift+N");
			/*gameObject_CreateEmptyChildItem =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__create_empty_child, mScript.OnGameObject_CreateEmptyChild, true, "Alt+Shift+N");
            
	        #region GameObject -> 3D Object    
	        gameObject_3dObjectItem            =   MakeItem(gameObjectMenu,          R.sections.MenuItems.strings.gameobject__3d_object);
	        
	        /*gameObject_3dObject_CubeItem     =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__cube,      mScript.OnGameObject_3dObject_Cube);
	        /*gameObject_3dObject_SphereItem   =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__sphere,    mScript.OnGameObject_3dObject_Sphere);
	        /*gameObject_3dObject_CapsuleItem  =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__capsule,   mScript.OnGameObject_3dObject_Capsule);
	        /*gameObject_3dObject_CylinderItem =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__cylinder,  mScript.OnGameObject_3dObject_Cylinder);
	        /*gameObject_3dObject_PlaneItem    =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__plane,     mScript.OnGameObject_3dObject_Plane);
	        /*gameObject_3dObject_QuadItem     =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__quad,      mScript.OnGameObject_3dObject_Quad);
	        MenuSeparatorItem.Create(gameObject_3dObjectItem);
	        /*gameObject_3dObject_RagdollItem  =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__ragdoll,   mScript.OnGameObject_3dObject_Ragdoll);
	        MenuSeparatorItem.Create(gameObject_3dObjectItem);
	        /*gameObject_3dObject_TerrainItem  =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__terrain,   mScript.OnGameObject_3dObject_Terrain);
	        /*gameObject_3dObject_TreeItem     =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__tree,      mScript.OnGameObject_3dObject_Tree);
	        /*gameObject_3dObject_WindZoneItem =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__wind_zone, mScript.OnGameObject_3dObject_WindZone);
	        
	        /*gameObject_3dObject_3dTextItem   =*/ MakeItem(gameObject_3dObjectItem, R.sections.MenuItems.strings.gameobject__3d_object__3d_text,   mScript.OnGameObject_3dObject_3dText);
	        #endregion
	        
	        #region GameObject -> 2D Object    
	        gameObject_2dObjectItem          =   MakeItem(gameObjectMenu,          R.sections.MenuItems.strings.gameobject__2d_object);
	        
	        /*gameObject_2dObject_SpriteItem =*/ MakeItem(gameObject_2dObjectItem, R.sections.MenuItems.strings.gameobject__2d_object__sprite, mScript.OnGameObject_2dObject_Sprite);
	        #endregion
	        
	        #region GameObject -> Light
	        gameObject_LightItem                    =   MakeItem(gameObjectMenu,       R.sections.MenuItems.strings.gameobject__light);
	        
	        /*gameObject_Light_DirectionalLightItem =*/ MakeItem(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__directional_light, mScript.OnGameObject_Light_DirectionalLight);
	        /*gameObject_Light_PointLightItem       =*/ MakeItem(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__point_light,       mScript.OnGameObject_Light_PointLight);
	        /*gameObject_Light_SpotlightItem        =*/ MakeItem(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__spotlight,         mScript.OnGameObject_Light_Spotlight);
	        /*gameObject_Light_AreaLightItem        =*/ MakeItem(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__area_light,        mScript.OnGameObject_Light_AreaLight);
	        MenuSeparatorItem.Create(gameObject_LightItem);
	        /*gameObject_Light_ReflectionProbeItem  =*/ MakeItem(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__reflection_probe,  mScript.OnGameObject_Light_ReflectionProbe);
	        /*gameObject_Light_LightProbeGroupItem  =*/ MakeItem(gameObject_LightItem, R.sections.MenuItems.strings.gameobject__light__light_probe_group, mScript.OnGameObject_Light_LightProbeGroup);
	        #endregion
	        
	        #region GameObject -> Audio
	        gameObject_AudioItem                   =   MakeItem(gameObjectMenu,       R.sections.MenuItems.strings.gameobject__audio);
	        
	        /*gameObject_Audio_AudioSourceItem     =*/ MakeItem(gameObject_AudioItem, R.sections.MenuItems.strings.gameobject__audio__audio_source,      mScript.OnGameObject_Audio_AudioSource);
	        /*gameObject_Audio_AudioReverbZoneItem =*/ MakeItem(gameObject_AudioItem, R.sections.MenuItems.strings.gameobject__audio__audio_reverb_zone, mScript.OnGameObject_Audio_AudioReverbZone);
	        #endregion
	        
	        #region GameObject -> UI
	        gameObject_UiItem               =   MakeItem(gameObjectMenu,    R.sections.MenuItems.strings.gameobject__ui);
	        
	        /*gameObject_Ui_PanelItem       =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__panel,        mScript.OnGameObject_Ui_Panel);
	        /*gameObject_Ui_ButtonItem      =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__button,       mScript.OnGameObject_Ui_Button);
	        /*gameObject_Ui_TextItem        =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__text,         mScript.OnGameObject_Ui_Text);
	        /*gameObject_Ui_ImageItem       =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__image,        mScript.OnGameObject_Ui_Image);
	        /*gameObject_Ui_RawImageItem    =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__raw_image,    mScript.OnGameObject_Ui_RawImage);
	        /*gameObject_Ui_SliderItem      =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__slider,       mScript.OnGameObject_Ui_Slider);
	        /*gameObject_Ui_ScrollbarItem   =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__scrollbar,    mScript.OnGameObject_Ui_Scrollbar);
	        /*gameObject_Ui_ToggleItem      =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__toggle,       mScript.OnGameObject_Ui_Toggle);
	        /*gameObject_Ui_InputFieldItem  =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__input_field,  mScript.OnGameObject_Ui_InputField);
	        /*gameObject_Ui_CanvasItem      =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__canvas,       mScript.OnGameObject_Ui_Canvas);
	        /*gameObject_Ui_EventSystemItem =*/ MakeItem(gameObject_UiItem, R.sections.MenuItems.strings.gameobject__ui__event_system, mScript.OnGameObject_Ui_EventSystem);
	        #endregion
	        
	        /*gameObject_ParticleSystemItem       =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__particle_system,         mScript.OnGameObject_ParticleSystem);
	        /*gameObject_CameraItem               =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__camera,                  mScript.OnGameObject_Camera);
	        MenuSeparatorItem.Create(gameObjectMenu);
	        /*gameObject_CenterOnChildrenItem     =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__center_on_children,      mScript.OnGameObject_CenterOnChildren,     false);
	        MenuSeparatorItem.Create(gameObjectMenu);
			/*gameObject_MakeParentItem           =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__make_parent,             mScript.OnGameObject_MakeParent,           false);
			/*gameObject_ClearParentItem          =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__clear_parent,            mScript.OnGameObject_ClearParent,          false);
			/*gameObject_ApplyChangesToPrefabItem =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__apply_changes_to_prefab, mScript.OnGameObject_ApplyChangesToPrefab, false);
            /*gameObject_BreakPrefabInstanceItem  =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__break_prefab_instance,   mScript.OnGameObject_BreakPrefabInstance,  false);
            MenuSeparatorItem.Create(gameObjectMenu);
			/*gameObject_SetAsFirstSiblingItem    =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__set_as_first_sibling,    mScript.OnGameObject_SetAsFirstSibling,    false, "Ctrl+=");
			/*gameObject_SetAsLastSiblingItem     =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__set_as_last_sibling,     mScript.OnGameObject_SetAsLastSibling,     false, "Ctrl+-");
			/*gameObject_MoveToViewItem           =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__move_to_view,            mScript.OnGameObject_MoveToView,           false, "Ctrl+Alt+F");
			/*gameObject_AlignWithViewItem        =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__align_with_view,         mScript.OnGameObject_AlignWithView,        false, "Ctrl+Shift+F");
			/*gameObject_AlignViewToSelectedItem  =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__align_view_to_selected,  mScript.OnGameObject_AlignViewToSelected,  false);
			/*gameObject_ToggleActiveStateItem    =*/ MakeItem(gameObjectMenu, R.sections.MenuItems.strings.gameobject__toggle_active_state,     mScript.OnGameObject_ToggleActiveState,    false, "Alt+Shift+A");
            #endregion
	        
	        #region Component
	        componentMenu       =   MakeItem(mItems,        R.sections.MenuItems.strings.component,      mScript.OnComponentMenu);
	        
			/*component_AddItem =*/ MakeItem(componentMenu, R.sections.MenuItems.strings.component__add, mScript.OnComponent_Add, false, "Ctrl+Shift+A");
            
	        #region Component -> Mesh
	        component_MeshItem                       =   MakeItem(componentMenu,      R.sections.MenuItems.strings.component__mesh);
	        
			/*component_Mesh_MeshFilterItem          =*/ MakeItem(component_MeshItem, R.sections.MenuItems.strings.component__mesh__mesh_filter,           mScript.OnComponent_Mesh_MeshFilter,          false);
            /*component_Mesh_TextMeshItem            =*/ MakeItem(component_MeshItem, R.sections.MenuItems.strings.component__mesh__text_mesh,             mScript.OnComponent_Mesh_TextMesh,            false);
            MenuSeparatorItem.Create(component_MeshItem);
			/*component_Mesh_MeshRendererItem        =*/ MakeItem(component_MeshItem, R.sections.MenuItems.strings.component__mesh__mesh_renderer,         mScript.OnComponent_Mesh_MeshRenderer,        false);
			/*component_Mesh_SkinnedMeshRendererItem =*/ MakeItem(component_MeshItem, R.sections.MenuItems.strings.component__mesh__skinned_mesh_renderer, mScript.OnComponent_Mesh_SkinnedMeshRenderer, false);
            #endregion
	        
	        #region Component -> Effects
	        component_EffectsItem                  =   MakeItem(componentMenu,         R.sections.MenuItems.strings.component__effects);
	        
			/*component_Effects_ParticleSystemItem =*/ MakeItem(component_EffectsItem, R.sections.MenuItems.strings.component__effects__particle_system, mScript.OnComponent_Effects_ParticleSystem, false);
			/*component_Effects_TrailRendererItem  =*/ MakeItem(component_EffectsItem, R.sections.MenuItems.strings.component__effects__trail_renderer,  mScript.OnComponent_Effects_TrailRenderer,  false);
			/*component_Effects_LineRendererItem   =*/ MakeItem(component_EffectsItem, R.sections.MenuItems.strings.component__effects__line_renderer,   mScript.OnComponent_Effects_LineRenderer,   false);
			/*component_Effects_LensFlareItem      =*/ MakeItem(component_EffectsItem, R.sections.MenuItems.strings.component__effects__lens_flare,      mScript.OnComponent_Effects_LensFlare,      false);
			/*component_Effects_HaloItem           =*/ MakeItem(component_EffectsItem, R.sections.MenuItems.strings.component__effects__halo,            mScript.OnComponent_Effects_Halo,           false);
			/*component_Effects_ProjectorItem      =*/ MakeItem(component_EffectsItem, R.sections.MenuItems.strings.component__effects__projector,       mScript.OnComponent_Effects_Projector,      false);
			MenuSeparatorItem.Create(component_EffectsItem);
	        
	        #region Component -> Effects -> Legacy Particles
	        component_Effects_LegacyParticlesItem                            =   MakeItem(component_EffectsItem,                 R.sections.MenuItems.strings.component__effects__legacy_particles);
	        
			/*component_Effects_LegacyParticles_EllipsoidParticleEmitterItem =*/ MakeItem(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__ellipsoid_particle_emitter, mScript.OnComponent_Effects_LegacyParticles_EllipsoidParticleEmitter, false);
            /*component_Effects_LegacyParticles_MeshParticleEmitterItem      =*/ MakeItem(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__mesh_particle_emitter,      mScript.OnComponent_Effects_LegacyParticles_MeshParticleEmitter,      false);
            MenuSeparatorItem.Create(component_Effects_LegacyParticlesItem);
			/*component_Effects_LegacyParticles_ParticleAnimatorItem         =*/ MakeItem(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__particle_animator,          mScript.OnComponent_Effects_LegacyParticles_ParticleAnimator,         false);
			/*component_Effects_LegacyParticles_WorldParticleColliderItem    =*/ MakeItem(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__world_particle_collider,    mScript.OnComponent_Effects_LegacyParticles_WorldParticleCollider,    false);
            MenuSeparatorItem.Create(component_Effects_LegacyParticlesItem);
			/*component_Effects_LegacyParticles_ParticleRendererItem         =*/ MakeItem(component_Effects_LegacyParticlesItem, R.sections.MenuItems.strings.component__effects__legacy_particles__particle_renderer,          mScript.OnComponent_Effects_LegacyParticles_ParticleRenderer,         false);
            #endregion
	        
	        #endregion
	        
	        #region Component -> Physics
	        component_PhysicsItem                       =   MakeItem(componentMenu,         R.sections.MenuItems.strings.component__physics);
	        
			/*component_Physics_RigidbodyItem           =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__rigidbody,            mScript.OnComponent_Physics_Rigidbody,           false);
			/*component_Physics_CharacterControllerItem =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__character_controller, mScript.OnComponent_Physics_CharacterController, false);
            MenuSeparatorItem.Create(component_PhysicsItem);
			/*component_Physics_BoxColliderItem         =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__box_collider,         mScript.OnComponent_Physics_BoxCollider,         false);
			/*component_Physics_SphereColliderItem      =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__sphere_collider,      mScript.OnComponent_Physics_SphereCollider,      false);
			/*component_Physics_CapsuleColliderItem     =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__capsule_collider,     mScript.OnComponent_Physics_CapsuleCollider,     false);
			/*component_Physics_MeshColliderItem        =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__mesh_collider,        mScript.OnComponent_Physics_MeshCollider,        false);
			/*component_Physics_WheelColliderItem       =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__wheel_collider,       mScript.OnComponent_Physics_WheelCollider,       false);
			/*component_Physics_TerrainColliderItem     =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__terrain_collider,     mScript.OnComponent_Physics_TerrainCollider,     false);
            MenuSeparatorItem.Create(component_PhysicsItem);
			/*component_Physics_ClothItem               =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__cloth,                mScript.OnComponent_Physics_Cloth,               false);
            MenuSeparatorItem.Create(component_PhysicsItem);
			/*component_Physics_HingeJointItem          =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__hinge_joint,          mScript.OnComponent_Physics_HingeJoint,          false);
			/*component_Physics_FixedJointItem          =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__fixed_joint,          mScript.OnComponent_Physics_FixedJoint,          false);
			/*component_Physics_SpringJointItem         =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__spring_joint,         mScript.OnComponent_Physics_SpringJoint,         false);
			/*component_Physics_CharacterJointItem      =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__character_joint,      mScript.OnComponent_Physics_CharacterJoint,      false);
			/*component_Physics_ConfigurableJointItem   =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__configurable_joint,   mScript.OnComponent_Physics_ConfigurableJoint,   false);
            MenuSeparatorItem.Create(component_PhysicsItem);
			/*component_Physics_ConstantForceItem       =*/ MakeItem(component_PhysicsItem, R.sections.MenuItems.strings.component__physics__constant_force,       mScript.OnComponent_Physics_ConstantForce,       false);
            #endregion
	        
	        #region Component -> Physics 2D
	        component_Physics2dItem                      =   MakeItem(componentMenu,           R.sections.MenuItems.strings.component__physics_2d);
	        
			/*component_Physics2d_Rigidbody2dItem        =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__rigidbody_2d,         mScript.OnComponent_Physics2d_Rigidbody2d,        false);
            MenuSeparatorItem.Create(component_Physics2dItem);
			/*component_Physics2d_CircleCollider2dItem   =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__circle_collider_2d,   mScript.OnComponent_Physics2d_CircleCollider2d,   false);
			/*component_Physics2d_BoxCollider2dItem      =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__box_collider_2d,      mScript.OnComponent_Physics2d_BoxCollider2d,      false);
			/*component_Physics2d_EdgeCollider2dItem     =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__edge_collider_2d,     mScript.OnComponent_Physics2d_EdgeCollider2d,     false);
			/*component_Physics2d_PolygonCollider2dItem  =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__polygon_collider_2d,  mScript.OnComponent_Physics2d_PolygonCollider2d,  false);
            MenuSeparatorItem.Create(component_Physics2dItem);
			/*component_Physics2d_SpringJoint2dItem      =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__spring_joint_2d,      mScript.OnComponent_Physics2d_SpringJoint2d,      false);
			/*component_Physics2d_DistanceJoint2dItem    =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__distance_joint_2d,    mScript.OnComponent_Physics2d_DistanceJoint2d,    false);
			/*component_Physics2d_HingeJoint2dItem       =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__hinge_joint_2d,       mScript.OnComponent_Physics2d_HingeJoint2d,       false);
			/*component_Physics2d_SliderJoint2dItem      =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__slider_joint_2d,      mScript.OnComponent_Physics2d_SliderJoint2d,      false);
			/*component_Physics2d_WheelJoint2dItem       =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__wheel_joint_2d,       mScript.OnComponent_Physics2d_WheelJoint2d,       false);
            MenuSeparatorItem.Create(component_Physics2dItem);
			/*component_Physics2d_ConstantForce2dItem    =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__constant_force_2d,    mScript.OnComponent_Physics2d_ConstantForce2d,    false);
            MenuSeparatorItem.Create(component_Physics2dItem);
			/*component_Physics2d_AreaEffector2dItem     =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__area_effector_2d,     mScript.OnComponent_Physics2d_AreaEffector2d,     false);
			/*component_Physics2d_PointEffector2dItem    =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__point_effector_2d,    mScript.OnComponent_Physics2d_PointEffector2d,    false);
			/*component_Physics2d_PlatformEffector2dItem =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__platform_effector_2d, mScript.OnComponent_Physics2d_PlatformEffector2d, false);
            /*component_Physics2d_SurfaceEffector2dItem  =*/ MakeItem(component_Physics2dItem, R.sections.MenuItems.strings.component__physics_2d__surface_effector_2d,  mScript.OnComponent_Physics2d_SurfaceEffector2d,  false);
            #endregion
	        
	        #region Component -> Navigation
	        component_NavigationItem                   =   MakeItem(componentMenu,            R.sections.MenuItems.strings.component__navigation);
	        
			/*component_Navigation_NavMeshAgentItem    =*/ MakeItem(component_NavigationItem, R.sections.MenuItems.strings.component__navigation__nav_mesh_agent,    mScript.OnComponent_Navigation_NavMeshAgent,    false);
			/*component_Navigation_OffMeshLinkItem     =*/ MakeItem(component_NavigationItem, R.sections.MenuItems.strings.component__navigation__off_mesh_link,     mScript.OnComponent_Navigation_OffMeshLink,     false);
			/*component_Navigation_NavMeshObstacleItem =*/ MakeItem(component_NavigationItem, R.sections.MenuItems.strings.component__navigation__nav_mesh_obstacle, mScript.OnComponent_Navigation_NavMeshObstacle, false);
            #endregion
	        
	        #region Component -> Audio
	        component_AudioItem                         =   MakeItem(componentMenu,       R.sections.MenuItems.strings.component__audio);
	        
			/*component_Audio_AudioListenerItem         =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_listener,          mScript.OnComponent_Audio_AudioListener,         false);
            /*component_Audio_AudioSourceItem           =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_source,            mScript.OnComponent_Audio_AudioSource,           false);
			/*component_Audio_AudioReverbZoneItem       =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_reverb_zone,       mScript.OnComponent_Audio_AudioReverbZone,       false);
            MenuSeparatorItem.Create(component_AudioItem);
			/*component_Audio_AudioLowPassFilterItem    =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_low_pass_filter,   mScript.OnComponent_Audio_AudioLowPassFilter,    false);
			/*component_Audio_AudioHighPassFilterItem   =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_high_pass_filter,  mScript.OnComponent_Audio_AudioHighPassFilter,   false);
			/*component_Audio_AudioEchoFilterItem       =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_echo_filter,       mScript.OnComponent_Audio_AudioEchoFilter,       false);
			/*component_Audio_AudioDistortionFilterItem =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_distortion_filter, mScript.OnComponent_Audio_AudioDistortionFilter, false);
			/*component_Audio_AudioReverbFilterItem     =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_reverb_filter,     mScript.OnComponent_Audio_AudioReverbFilter,     false);
			/*component_Audio_AudioChorusFilterItem     =*/ MakeItem(component_AudioItem, R.sections.MenuItems.strings.component__audio__audio_chorus_filter,     mScript.OnComponent_Audio_AudioChorusFilter,     false);
            #endregion
	        
	        #region Component -> Rendering
	        component_RenderingItem                   =   MakeItem(componentMenu,           R.sections.MenuItems.strings.component__rendering);
	        
			/*component_Rendering_CameraItem          =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__camera,            mScript.OnComponent_Rendering_Camera,          false);
			/*component_Rendering_SkyboxItem          =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__skybox,            mScript.OnComponent_Rendering_Skybox,          false);
			/*component_Rendering_FlareLayerItem      =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__flare_layer,       mScript.OnComponent_Rendering_FlareLayer,      false);
			/*component_Rendering_GuiLayerItem        =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_layer,         mScript.OnComponent_Rendering_GuiLayer,        false);
            MenuSeparatorItem.Create(component_RenderingItem);
			/*component_Rendering_LightItem           =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__light,             mScript.OnComponent_Rendering_Light,           false);
			/*component_Rendering_LightProbeGroupItem =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__light_probe_group, mScript.OnComponent_Rendering_LightProbeGroup, false);
			/*component_Rendering_ReflectionProbeItem =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__reflection_probe,  mScript.OnComponent_Rendering_ReflectionProbe, false);
            MenuSeparatorItem.Create(component_RenderingItem);
			/*component_Rendering_OcclusionAreaItem   =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__occlusion_area,    mScript.OnComponent_Rendering_OcclusionArea,   false);
			/*component_Rendering_OcclusionPortalItem =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__occlusion_portal,  mScript.OnComponent_Rendering_OcclusionPortal, false);
			/*component_Rendering_LodGroupItem        =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__lod_group,         mScript.OnComponent_Rendering_LodGroup,        false);
            MenuSeparatorItem.Create(component_RenderingItem);
			/*component_Rendering_SpriteRendererItem  =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__sprite_renderer,   mScript.OnComponent_Rendering_SpriteRenderer,  false);
			/*component_Rendering_CanvasRendererItem  =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__canvas_renderer,   mScript.OnComponent_Rendering_CanvasRenderer,  false);
            MenuSeparatorItem.Create(component_RenderingItem);
			/*component_Rendering_GuiTextureItem      =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_texture,       mScript.OnComponent_Rendering_GuiTexture,      false);
			/*component_Rendering_GuiTextItem         =*/ MakeItem(component_RenderingItem, R.sections.MenuItems.strings.component__rendering__gui_text,          mScript.OnComponent_Rendering_GuiText,         false);
            #endregion
	        
	        #region Component -> Layout
	        component_LayoutItem                         =   MakeItem(componentMenu,        R.sections.MenuItems.strings.component__layout);
	        
			/*component_Layout_RectTransformItem         =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__rect_transform,          mScript.OnComponent_Layout_RectTransform,         false);
			/*component_Layout_CanvasItem                =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas,                  mScript.OnComponent_Layout_Canvas,                false);
			/*component_Layout_CanvasGroupItem           =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas_group,            mScript.OnComponent_Layout_CanvasGroup,           false);
            MenuSeparatorItem.Create(component_LayoutItem);
			/*component_Layout_CanvasScalerItem          =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__canvas_scaler,           mScript.OnComponent_Layout_CanvasScaler,          false);
            MenuSeparatorItem.Create(component_LayoutItem);
			/*component_Layout_LayoutElementItem         =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__layout_element,          mScript.OnComponent_Layout_LayoutElement,         false);
			/*component_Layout_ContentSizeFitterItem     =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__content_size_fitter,     mScript.OnComponent_Layout_ContentSizeFitter,     false);
			/*component_Layout_AspectRatioFitterItem     =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__aspect_ratio_fitter,     mScript.OnComponent_Layout_AspectRatioFitter,     false);
			/*component_Layout_HorizontalLayoutGroupItem =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__horizontal_layout_group, mScript.OnComponent_Layout_HorizontalLayoutGroup, false);
			/*component_Layout_VerticalLayoutGroupItem   =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__vertical_layout_group,   mScript.OnComponent_Layout_VerticalLayoutGroup,   false);
			/*component_Layout_GridLayoutGroupItem       =*/ MakeItem(component_LayoutItem, R.sections.MenuItems.strings.component__layout__grid_layout_group,       mScript.OnComponent_Layout_GridLayoutGroup,       false);
            #endregion
	        
	        #region Component -> Miscellaneous
	        component_MiscellaneousItem                     =   MakeItem(componentMenu,               R.sections.MenuItems.strings.component__miscellaneous);
	        
			/*component_Miscellaneous_AnimatorItem          =*/ MakeItem(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__animator,           mScript.OnComponent_Miscellaneous_Animator,          false);
            /*component_Miscellaneous_AnimationItem         =*/ MakeItem(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__animation,          mScript.OnComponent_Miscellaneous_Animation,         false);
            /*component_Miscellaneous_NetworkViewItem       =*/ MakeItem(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__network_view,       mScript.OnComponent_Miscellaneous_NetworkView,       false);
            /*component_Miscellaneous_WindZoneItem          =*/ MakeItem(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__wind_zone,          mScript.OnComponent_Miscellaneous_WindZone,          false);
            /*component_Miscellaneous_TerrainItem           =*/ MakeItem(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__terrain,            mScript.OnComponent_Miscellaneous_Terrain,           false);
            /*component_Miscellaneous_BillboardRendererItem =*/ MakeItem(component_MiscellaneousItem, R.sections.MenuItems.strings.component__miscellaneous__billboard_renderer, mScript.OnComponent_Miscellaneous_BillboardRenderer, false);
            #endregion
	        
	        #region Component -> Event
	        component_EventItem                         =   MakeItem(componentMenu,       R.sections.MenuItems.strings.component__event);
	        
			/*component_Event_EventSystemItem           =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__event_system,            mScript.OnComponent_Event_EventSystem,           false);
            /*component_Event_EventTriggerItem          =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__event_trigger,           mScript.OnComponent_Event_EventTrigger,          false);
            /*component_Event_Physics2dRaycasterItem    =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__physics_2d_raycaster,    mScript.OnComponent_Event_Physics2dRaycaster,    false);
            /*component_Event_PhysicsRaycasterItem      =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__physics_raycaster,       mScript.OnComponent_Event_PhysicsRaycaster,      false);
            /*component_Event_StandaloneInputModuleItem =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__standalone_input_module, mScript.OnComponent_Event_StandaloneInputModule, false);
			/*component_Event_TouchInputModuleItem      =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__touch_input_module,      mScript.OnComponent_Event_TouchInputModule,      false);
			/*component_Event_GraphicRaycasterItem      =*/ MakeItem(component_EventItem, R.sections.MenuItems.strings.component__event__graphic_raycaster,       mScript.OnComponent_Event_GraphicRaycaster,      false);
            #endregion
	        
	        #region Component -> UI
	        component_UiItem = MakeItem(componentMenu, R.sections.MenuItems.strings.component__ui);
	        
	        #region Component -> UI -> Effects
	        component_Ui_EffectsItem                 =   MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__effects);
	        
			/*component_Ui_Effects_ShadowItem        =*/ MakeItem(component_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__shadow,          mScript.OnComponent_Ui_Effects_Shadow,        false);
            /*component_Ui_Effects_OutlineItem       =*/ MakeItem(component_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__outline,         mScript.OnComponent_Ui_Effects_Outline,       false);
            /*component_Ui_Effects_PositionAsUv1Item =*/ MakeItem(component_Ui_EffectsItem, R.sections.MenuItems.strings.component__ui__effects__position_as_uv1, mScript.OnComponent_Ui_Effects_PositionAsUv1, false);
            #endregion
	        
			/*component_Ui_ImageItem       =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__image,        mScript.OnComponent_Ui_Image,       false);
            /*component_Ui_TextItem        =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__text,         mScript.OnComponent_Ui_Text,        false);
            /*component_Ui_RawImageItem    =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__raw_image,    mScript.OnComponent_Ui_RawImage,    false);
            /*component_Ui_MaskItem        =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__mask,         mScript.OnComponent_Ui_Mask,        false);
            MenuSeparatorItem.Create(component_UiItem);
			/*component_Ui_ButtonItem      =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__button,       mScript.OnComponent_Ui_Button,      false);
            /*component_Ui_InputFieldItem  =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__input_field,  mScript.OnComponent_Ui_InputField,  false);
            /*component_Ui_ScrollbarItem   =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__scrollbar,    mScript.OnComponent_Ui_Scrollbar,   false);
            /*component_Ui_ScrollRectItem  =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__scroll_rect,  mScript.OnComponent_Ui_ScrollRect,  false);
            /*component_Ui_SliderItem      =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__slider,       mScript.OnComponent_Ui_Slider,      false);
            /*component_Ui_ToggleItem      =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__toggle,       mScript.OnComponent_Ui_Toggle,      false);
            /*component_Ui_ToggleGroupItem =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__toggle_group, mScript.OnComponent_Ui_ToggleGroup, false);
            MenuSeparatorItem.Create(component_UiItem);
			/*component_Ui_SelectableItem  =*/ MakeItem(component_UiItem, R.sections.MenuItems.strings.component__ui__selectable,   mScript.OnComponent_Ui_Selectable,  false);
            #endregion
	        
	        #region Component -> Scripts
	        /*component_ScriptsItem =*/ MakeItem(componentMenu, R.sections.MenuItems.strings.component__scripts);
	        #endregion
	        
	        #endregion
	        
	        #region Window
	        windowMenu                  =   MakeItem(mItems,     R.sections.MenuItems.strings.window,                  mScript.OnWindowMenu);
	        
	        /*window_NextWindowItem     =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__next_window,     mScript.OnWindow_NextWindow,     true, "Ctrl+Tab");
			/*window_PreviousWindowItem =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__previous_window, mScript.OnWindow_PreviousWindow, true, "Ctrl+Shift+Tab");
            MenuSeparatorItem.Create(windowMenu);
	        
	        #region Window -> Layouts
	        window_LayoutsItem                         =   MakeItem(windowMenu,         R.sections.MenuItems.strings.window__layouts);
	        
	        /*window_Layouts_2_by_3Item                =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__2_by_3,                  mScript.OnWindow_Layouts_2_by_3);
	        /*window_Layouts_4_splitItem               =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__4_split,                 mScript.OnWindow_Layouts_4_split);
	        /*window_Layouts_DefaultItem               =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__default,                 mScript.OnWindow_Layouts_Default);
	        /*window_Layouts_TallItem                  =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__tall,                    mScript.OnWindow_Layouts_Tall);
	        /*window_Layouts_WideItem                  =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__wide,                    mScript.OnWindow_Layouts_Wide);
	        MenuSeparatorItem.Create(window_LayoutsItem);
	        /*window_Layouts_SaveLayoutItem            =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__save_layout,             mScript.OnWindow_Layouts_SaveLayout);
	        /*window_Layouts_DeleteLayoutItem          =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__delete_layout,           mScript.OnWindow_Layouts_DeleteLayout);
	        /*window_Layouts_RevertFactorySettingsItem =*/ MakeItem(window_LayoutsItem, R.sections.MenuItems.strings.window__layouts__revert_factory_settings, mScript.OnWindow_Layouts_RevertFactorySettings);
	        #endregion
	        
	        MenuSeparatorItem.Create(windowMenu);
			/*window_SceneItem             =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__scene,              mScript.OnWindow_Scene,          true,  "Ctrl+1");
			/*window_GameItem              =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__game,               mScript.OnWindow_Game,           true,  "Ctrl+2");
			/*window_InspectorItem         =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__inspector,          mScript.OnWindow_Inspector,      true,  "Ctrl+3");
			/*window_HierarchyItem         =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__hierarchy,          mScript.OnWindow_Hierarchy,      true,  "Ctrl+4");
			/*window_ProjectItem           =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__project,            mScript.OnWindow_Project,        true,  "Ctrl+5");
			/*window_AnimationItem         =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__animation,          mScript.OnWindow_Animation,      true,  "Ctrl+6");
			/*window_ProfilerItem          =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__profiler,           mScript.OnWindow_Profiler,       true,  "Ctrl+7");
			/*window_AudioMixerItem        =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__audio_mixer,        mScript.OnWindow_AudioMixer,     true,  "Ctrl+8");
			/*window_AssetStoreItem        =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__asset_store,        mScript.OnWindow_AssetStore,     true,  "Ctrl+9");
			/*window_VersionControlItem    =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__version_control,    mScript.OnWindow_VersionControl, false, "Ctrl+0");
	        /*window_AnimatorParameterItem =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__animator_parameter, mScript.OnWindow_AnimatorParameter);
	        /*window_AnimatorItem          =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__animator,           mScript.OnWindow_Animator);
	        /*window_SpritePackerItem      =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__sprite_packer,      mScript.OnWindow_SpritePacker);
	        MenuSeparatorItem.Create(windowMenu);
	        /*window_LightingItem          =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__lighting,           mScript.OnWindow_Lighting);
	        /*window_OcclusionCullingItem  =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__occlusion_culling,  mScript.OnWindow_OcclusionCulling);
	        /*window_FrameDebuggerItem     =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__frame_debugger,     mScript.OnWindow_FrameDebugger);
	        /*window_NavigationItem        =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__navigation,         mScript.OnWindow_Navigation);
	        MenuSeparatorItem.Create(windowMenu);
			/*window_ConsoleItem           =*/ MakeItem(windowMenu, R.sections.MenuItems.strings.window__console,            mScript.OnWindow_Console,        true,  "Ctrl+Shift+C");
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
	        Utils.AlignRectTransformStretchStretch(scrollAreaTransform);
	        #endregion
	        
	        //***************************************************************************
			// Content GameObject
	        //***************************************************************************
	        #region Content GameObject
	        GameObject scrollAreaContent = new GameObject("Content");
	        Utils.InitUIObject(scrollAreaContent, scrollArea.transform);
	        
	        //===========================================================================
	        // RectTransform Component
	        //===========================================================================
	        #region RectTransform Component
	        RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();
	        #endregion
	        
	        float contentWidth = 0f;

			//===========================================================================
			// Fill content
			//===========================================================================
			#region Fill content
	        // Create menu item buttons
	        foreach (TreeNode<CustomMenuItem> menuItem in mItems.Children)
	        {
				if (menuItem.Data is MenuItem)
				{
					MenuItem item = menuItem.Data as MenuItem;

					//***************************************************************************
					// Button GameObject
					//***************************************************************************
					#region Button GameObject
					GameObject menuItemButton = Object.Instantiate(Assets.MainMenu.Prefabs.button) as GameObject; // TODO: Try to do the same without prefabs
					Utils.InitUIObject(menuItemButton, scrollAreaContent.transform);
					menuItemButton.name = item.Name;
					
					//===========================================================================
					// RectTransform Component
					//===========================================================================
					#region RectTransform Component
					RectTransform menuItemButtonTransform = menuItemButton.GetComponent<RectTransform>();
					#endregion
					
					//===========================================================================
					// Button Component
					//===========================================================================
					#region Button Component
					Button button = menuItemButton.GetComponent<Button>();
					
					if (item.Enabled)
					{
						button.onClick.AddListener(item.OnClick);
					}
					#endregion
					#endregion
					
					//***************************************************************************
					// Text GameObject
					//***************************************************************************
					#region Text GameObject
					GameObject menuItemText = menuItemButton.transform.GetChild(0).gameObject; // Button/Text
					
					#region Text Component
					Text text = menuItemText.GetComponent<Text>();
					text.text = item.Text; // TODO: Try to autotranslate somehow
					#endregion
					#endregion
					
					#region Calculating button geometry
					++contentWidth;
					
					float buttonWidth = text.preferredWidth + 12;

					Utils.AlignRectTransformStretchLeft(menuItemButtonTransform, buttonWidth, contentWidth, 1, 1);
					
					contentWidth += buttonWidth + 1;
					#endregion
				}
				else
				{
					Debug.LogError("Unknown menu item type");
				}
	        }
			#endregion

			Utils.AlignRectTransformStretchLeft(scrollAreaContentTransform, contentWidth);
			scrollAreaContentTransform.pivot = new Vector2(0f, 0.5f); // TODO: Try to do it in AlignRectTransformStretchLeft
	        #endregion
	        
			//===========================================================================
			// ScrollRect Component
			//===========================================================================
	        #region ScrollRect Component
	        ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();
	        
	        scrollAreaScrollRect.content  = scrollAreaContentTransform;
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
			
			scrollAreaImage.sprite = Assets.MainMenu.Textures.background;
			scrollAreaImage.type   = Image.Type.Sliced;
			#endregion

			//===========================================================================
			// Mask Component
			//===========================================================================
			#region Mask Component
			scrollArea.AddComponent<Mask>();
			#endregion
	        #endregion
	    }
	}
}
