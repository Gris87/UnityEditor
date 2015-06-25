using UnityEngine;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Dummy dock widget.
	/// </summary>
	public class DummyDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static DummyDockWidgetScript instance
		{
			get { return mInstance; }
		}



		private static DummyDockWidgetScript mInstance = null;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DummyDockWidgetScript"/> class.
		/// </summary>
		private DummyDockWidgetScript()
		{
			// Nothing
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DummyDockWidgetScript"/> class.
		/// </summary>
		/// <param name="baseScript">Base script.</param>
		public static DummyDockWidgetScript Create(DockWidgetScript baseScript)
		{
			DestroyInstance();

			//***************************************************************************
			// Dummy GameObject
			//***************************************************************************
			#region Dummy GameObject
			GameObject dummy = new GameObject("Dummy");
			Utils.InitUIObject(dummy, Global.dockingAreaScript.transform);
			
			//===========================================================================
			// DummyDockWidgetScript Component
			//===========================================================================
			#region DummyDockWidgetScript Component
			mInstance = dummy.AddComponent<DummyDockWidgetScript>();

			mInstance.image           = baseScript.image;
			mInstance.tokenId         = baseScript.tokenId;
			mInstance.backgroundColor = baseScript.backgroundColor;
			#endregion
			#endregion
			
			return mInstance;
		}

		/// <summary>
		/// Destroies the instance.
		/// </summary>
		public static void DestroyInstance()
		{
			if (mInstance != null)
			{
				mInstance.Destroy();
			}
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (mInstance == this)
			{
				mInstance = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in DummyDockWidgetScript.OnDestroy");
			}
		}
	}
}

