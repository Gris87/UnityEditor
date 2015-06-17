using UnityEngine;
using UnityEngine.Events;



namespace Common.UI
{
	/// <summary>
	/// Script that listen for screen resize events.
	/// </summary>
	public class ResizeListenerScript : MonoBehaviour
	{
		private static readonly float CHECK_INTERVAL = 300f;



		private float mScreenWidth;
		private float mScreenHeight;
		private float mDelay;

		private UnityEvent mListeners;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			mScreenWidth  = Screen.width;
			mScreenHeight = Screen.height;
			mDelay        = CHECK_INTERVAL / 1000f;

			mListeners = new UnityEvent();
		}

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			mDelay -= Time.deltaTime;

			if (mDelay < 0f)
			{
				mDelay = CHECK_INTERVAL / 1000f;

				float screenWidth  = Screen.width;
				float screenHeight = Screen.height;

				if (
					mScreenWidth  != screenWidth
					||
					mScreenHeight != screenHeight
				   )
				{
					mScreenWidth  = screenWidth;
					mScreenHeight = screenHeight;

					mListeners.Invoke();
				}
			}
		}

		/// <summary>
		/// Adds the listener.
		/// </summary>
		/// <param name="listener">Listener.</param>
		public void AddListener(UnityAction listener)
		{
			mListeners.AddListener(listener);
		}

		/// <summary>
		/// Removes the listener.
		/// </summary>
		/// <param name="listener">Listener.</param>
		public void RemoveListener(UnityAction listener)
		{
			mListeners.RemoveListener(listener);
        }
	}
}

