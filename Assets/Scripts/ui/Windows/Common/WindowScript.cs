using UnityEngine;



namespace UI.Windows.Common
{
	/// <summary>
	/// Script that realize behaviour for window.
	/// </summary>
	public class WindowScript : MonoBehaviour
	{
		private WindowFrameTypes mFrame;
		private WindowStates     mState;



		/// <summary>
		/// Gets or sets the window frame.
		/// </summary>
		/// <value>Window frame.</value>
		public WindowFrameTypes frame
		{
			get
			{
				return mFrame;
			}

			set
			{
				if (mFrame != value)
				{
					mFrame = value;
					// TODO: Update
				}
			}
		}

		/// <summary>
		/// Gets or sets the window state.
		/// </summary>
		/// <value>Window state.</value>
		public WindowStates state
		{
			get
			{
				return mState;
			}
			
			set
			{
				if (mState != value)
				{
					mState = value;
					// TODO: Update
				}
			}
		}



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			// TODO: Create UI
		}

		// TODO: Implement
	}
}
