using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.AssetStore
{
	/// <summary>
	/// Script that realize assetStore dock widget behaviour.
	/// </summary>
	public class AssetStoreDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.AssetStore.AssetStoreDockWidgetScript"/> class.
		/// </summary>
		private AssetStoreDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.AssetStore.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.asset_store;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.AssetStore.AssetStoreDockWidgetScript"/> class.
		/// </summary>
		public static AssetStoreDockWidgetScript Create()
		{
			if (Global.assetStoreDockWidgetScript == null)
			{
				//***************************************************************************
				// AssetStore GameObject
				//***************************************************************************
				#region AssetStore GameObject
				GameObject assetStore = new GameObject("AssetStore");
				Utils.InitUIObject(assetStore, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// AssetStoreDockWidgetScript Component
				//===========================================================================
				#region AssetStoreDockWidgetScript Component
				Global.assetStoreDockWidgetScript = assetStore.AddComponent<AssetStoreDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.assetStoreDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			backgroundColor = Assets.Windows.MainWindow.DockWidgets.AssetStore.Colors.background;
			
			// TODO: Implement
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{			
			if (Global.assetStoreDockWidgetScript == this)
			{
				Global.assetStoreDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in AssetStoreDockWidgetScript.OnDestroy");
			}
		}
	}
}