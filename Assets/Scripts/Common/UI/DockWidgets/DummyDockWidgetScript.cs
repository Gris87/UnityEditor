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
			mInstance.backgroundColor = Assets.DockWidgets.Colors.dummyBackground;
			#endregion
			#endregion
			
			return mInstance;
		}

		/// <summary>
		/// Creates dummy dock widget and insert where it needed.
		/// </summary>
		public static void CreateAndInsert()
		{
			if (DragHandler.dockingArea != null)
			{
				Create(DragHandler.dockWidget).InsertToDockingArea(
																     DragHandler.dockingArea
																   , DragHandler.dockingAreaOrientation
																   , DragHandler.insertIndex
																  );
			}
			else
			if (DragHandler.dockingGroup != null)
			{
				Create(DragHandler.dockWidget).InsertToDockingGroup(
																	  DragHandler.dockingGroup
																	, DragHandler.insertIndex
																   );
			}
			else
			{
				Debug.LogError("Impossible to insert dummy dock widget");
			}
		}

		/// <summary>
		/// Destroies the instance.
		/// </summary>
		public static void DestroyInstance()
		{
			if (mInstance != null)
			{
				mInstance.Destroy();
				mInstance = null;
			}
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (mInstance != null)
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
}

