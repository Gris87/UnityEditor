using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;

using Common;



// TODO: Rewrite
namespace UI.Toasts
{
	/// <summary>
	/// Class for displaying text notifications.
	/// </summary>
	public static class Toast
	{
		/// <summary>
		/// Show text notification for a long period of time.
		/// </summary>
		public static float LENGTH_LONG  = 3000f;

		/// <summary>
		/// Show text notification for a short period of time.
		/// </summary>
		public static float LENGTH_SHORT = 1000f;



		/// <summary>
		/// Show text notification with specified duration.
		/// </summary>
		/// <param name="message">Message text.</param>
		/// <param name="duration">Duration.</param>
		public static void Show(string message, float duration)
		{
			Global.toastAreaScript.AddMessage(message, duration);
		}

		/// <summary>
		/// Show text notification with specified duration.
		/// </summary>
		/// <param name="tokenId">Token ID for translation.</param>
		/// <param name="duration">Duration.</param>
		public static void Show(R.sections.Toasts.strings tokenId, float duration)
		{
			Global.toastAreaScript.AddMessage(Translator.getString(tokenId), duration);
        }

		/// <summary>
		/// Show text notification with specified duration.
		/// </summary>
		/// <param name="tokenId">Token ID for translation.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="tokenArguments">Token arguments.</param>
		public static void Show(R.sections.Toasts.strings tokenId, float duration, params object[] tokenArguments)
		{
			Global.toastAreaScript.AddMessage(Translator.getString(tokenId, tokenArguments), duration);
        }

		/// <summary>
		/// Show text notification with the contribute message.
		/// </summary>
		public static void ShowContributeMessage()
		{
			Global.toastAreaScript.AddMessage(Translator.getString(R.sections.Toasts.strings.contribute, Stuff.sourceCodeUrl), Toast.LENGTH_LONG);
		}
    }
    
    /// <summary>
	/// Script that realize toasts behaviour.
	/// </summary>
	public class ToastAreaScript : MonoBehaviour
	{
		/// <summary>
		/// Class that represent message.
		/// </summary>
		private class Message
		{
			/// <summary>
			/// Gets the text.
			/// </summary>
			/// <value>The text.</value>
			public string text
			{
				get { return mText; }
			}

			/// <summary>
			/// Gets the token ID for translation.
			/// </summary>
			/// <value>The token identifier.</value>
			public R.sections.Toasts.strings tokenId
			{
				get { return mTokenId; }
			}

			/// <summary>
			/// Gets the token arguments.
			/// </summary>
			/// <value>The token arguments.</value>
			public object[] tokenArguments
			{
				get { return mTokenArguments; }
			}

			/// <summary>
			/// Gets the duration.
			/// </summary>
			/// <value>The duration.</value>
			public float duration
			{
				get { return mDuration; }
			}



			private string                    mText;
			private R.sections.Toasts.strings mTokenId;
			private object[]                  mTokenArguments;
			private float                     mDuration;



			/// <summary>
			/// Initializes a new instance of the <see cref="UI.Toasts.ToastAreaScript+Message"/> class.
			/// </summary>
			/// <param name="text">Text.</param>
			/// <param name="duration">Duration.</param>
			public Message(string text, float duration)
			{
				mText           = text;
				mTokenId        = R.sections.Toasts.strings.Count;
				mTokenArguments = null;
				mDuration       = duration;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="UI.Toasts.ToastAreaScript+Message"/> class.
			/// </summary>
			/// <param name="text">Text.</param>
			/// <param name="tokenId">Token identifier.</param>
			/// <param name="tokenArguments">Token arguments.</param>
			/// <param name="duration">Duration.</param>
			public Message(
						 	 R.sections.Toasts.strings tokenId
						   , object[]                  tokenArguments
						   , float                     duration
						  )
			{
				mText           = null;
				mTokenId        = tokenId;
				mTokenArguments = tokenArguments;
				mDuration       = duration;
			}
		}



		private static float TIMER_NOT_ACTIVE = -10000f;
		private static float FADE_TIME        = 300f / 1000f;



		private List<Message> mMessages;
		CanvasGroup           mToastCanvasGroup;
		private float         mRemainingTime;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			mMessages         = new List<Message>();
			mToastCanvasGroup = null;
			mRemainingTime    = TIMER_NOT_ACTIVE;
		}
		
		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			if (IsTimerActive())
			{
				mRemainingTime -= Time.deltaTime;
				
				if (mRemainingTime <= 0)
				{
					DestroyToast();

					if (mMessages.Count > 0)
					{
						ShowNextMessage();
					}
					else
					{
						mToastCanvasGroup = null;
						StopTimer();
					}
                }
				else
				{
					if (mRemainingTime < FADE_TIME)
					{
						mToastCanvasGroup.alpha = mRemainingTime / FADE_TIME;
                    }
				}
            }
		}

		/// <summary>
		/// Adds text notification with specified duration to the list.
		/// </summary>
		/// <param name="message">Message text.</param>
		/// <param name="duration">Duration.</param>
		public void AddMessage(string message, float duration)
		{
			mMessages.Add(new Message(message, duration));

			if (mMessages.Count == 1 && mToastCanvasGroup == null)
			{
				ShowNextMessage();
			}
		}

		/// <summary>
		/// Adds text notification with specified duration to the list.
		/// </summary>
		/// <param name="tokenId">Token ID for translation.</param>
		/// <param name="tokenArguments">Token arguments.</param>
		/// <param name="duration">Duration.</param>
		public void AddMessage(
							 	 R.sections.Toasts.strings tokenId
							   , object[]                  tokenArguments
							   , float                     duration
							  )
		{
			mMessages.Add(new Message(tokenId, tokenArguments, duration));
			
			if (mMessages.Count == 1 && mToastCanvasGroup == null)
			{
				ShowNextMessage();
			}
		}

		/// <summary>
		/// Takes message from the list and display it.
		/// </summary>
		public void ShowNextMessage()
		{
			Message message = mMessages[0];
			mMessages.RemoveAt(0);

			//***************************************************************************
			// Toast GameObject
			//***************************************************************************
			#region Toast GameObject
			GameObject toast = new GameObject("Toast");
			Utils.InitUIObject(toast, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toastTransform = toast.AddComponent<RectTransform>();
            #endregion

			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			toast.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image toastImage = toast.AddComponent<Image>();
			
			toastImage.sprite = Assets.Toasts.Textures.toastBackground;
			toastImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Image CanvasGroup
			//===========================================================================
            #region CanvasGroup Component
			mToastCanvasGroup = toast.AddComponent<CanvasGroup>();
            
			mToastCanvasGroup.blocksRaycasts = false;
            #endregion

			//***************************************************************************
			// ToastText GameObject
			//***************************************************************************
			#region ToastText GameObject
			GameObject toastTextObject = new GameObject("Text");
			Utils.InitUIObject(toastTextObject, toast.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toastTextTransform = toastTextObject.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(
				                                     toastTextTransform
				                                   , toastImage.sprite.border.x
												   , toastImage.sprite.border.w
												   , toastImage.sprite.border.z
												   , toastImage.sprite.border.y
												  );
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text toastText = toastTextObject.AddComponent<Text>();
			
			toastText.font     = Assets.Common.Fonts.microsoftSansSerif;
            toastText.fontSize = 12;
            toastText.color    = new Color(1f, 1f, 1f, 1f);
            toastText.text     = message.text;
            #endregion
            #endregion

			float toastWidth = toastText.preferredWidth  + 20f;
			int   screenWidth  = Screen.width;
			
			if (toastWidth > screenWidth - 60f)
			{
				toastWidth = screenWidth - 60f;
			}
			
			toastTransform.sizeDelta = new Vector2(toastWidth, 0f);
            float toastHeight = toastText.preferredHeight + 20f;

			Utils.AlignRectTransformBottomCenter(toastTransform, toastWidth, toastHeight, 0f, 30f);
			#endregion

			StartTimer(message.duration);
		}

		/// <summary>
		/// Destroies the toast.
		/// </summary>
		private void DestroyToast()
		{
			UnityEngine.Object.DestroyObject(mToastCanvasGroup.gameObject);
		}

		/// <summary>
		/// Starts timer with specified delay.
		/// </summary>
		/// <param name="ms">Delay in ms.</param>
		private void StartTimer(float ms)
		{
			if (ms < 0f)
			{
				Debug.LogError("Incorrect delay value: " + ms);
			}
			
			mRemainingTime = ms / 1000f;
		}
		
		/// <summary>
		/// Stops timer.
		/// </summary>
		private void StopTimer()
		{
			mRemainingTime = TIMER_NOT_ACTIVE;
		}
		
		/// <summary>
		/// Determines whether timer is active.
		/// </summary>
		/// <returns><c>true</c> if timer is active; otherwise, <c>false</c>.</returns>
		private bool IsTimerActive()
		{
			return mRemainingTime != TIMER_NOT_ACTIVE;
		}
	}
}

