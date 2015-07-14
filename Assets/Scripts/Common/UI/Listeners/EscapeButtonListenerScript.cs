using System.Collections.Generic;
using UnityEngine;



namespace Common.UI.Listeners
{
	/// <summary>
	/// Script that listen for escape button press events.
	/// </summary>
	public class EscapeButtonListenerScript : MonoBehaviour
	{
		private static EscapeButtonListenerScript sInstance = null;



		private List<EscapeButtonHandler> mHandlers;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			if (sInstance == null)
			{
				sInstance = this;
			}
			else
			{
				Debug.LogError("Two instances of EscapeButtonListener not supported");
			}
			
			mHandlers = new List<EscapeButtonHandler>();

			enabled = false;
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (sInstance == this)
			{
				sInstance = null;
			}
		}

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			if (InputControl.GetButtonDown(Controls.buttons.cancel, true))
			{
				mHandlers[mHandlers.Count - 1].OnEscapeButtonPressed();
			}
		}

		/// <summary>
		/// Push handler to the top.
		/// </summary>
		/// <param name="handler">Handler.</param>
		public static void PushHandlerToTop(EscapeButtonHandler handler)
		{
			if (sInstance != null)
			{
				sInstance.mHandlers.Remove(handler);
				sInstance.mHandlers.Add(handler);

				sInstance.enabled = true;
			}
			else
			{
				Debug.LogError("There is no EscapeButtonListener instance");
			}
		}
		
		/// <summary>
		/// Removes the handler.
		/// </summary>
		/// <param name="handler">Handler.</param>
		public static void RemoveHandler(EscapeButtonHandler handler)
		{
			if (sInstance != null)
			{
				if (sInstance.mHandlers.Remove(handler))
				{
					if (sInstance.mHandlers.Count == 0)
					{
						sInstance.enabled = false;
                    }
				}
				else
				{
					Debug.LogError("Failed to remove handler");
				}
			}
			else
			{
				Debug.LogError("There is no EscapeButtonListener instance");
			}
		}
	}
}

