using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;



namespace Common.UI.Toasts
{
	/// <summary>
	/// Script that realize toast behaviour.
	/// </summary>
	public class ToastScript : MonoBehaviour
	{
		private static readonly float TIMER_NOT_ACTIVE = -10000f;
		private static readonly float FADE_TIME        = 300f / 1000f;



		public string                    text;
		public R.sections.Toasts.strings tokenId;
		public object[]                  tokenArguments;
		public float                     duration;



		private float mRemainingTime;

		private CanvasGroup mToastCanvasGroup;
		private Text        mToastText;
        

			
		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.Toasts.ToastScript"/> class.
		/// </summary>
		public ToastScript()
		{
			mRemainingTime = TIMER_NOT_ACTIVE;

			mToastCanvasGroup = null;
			mToastText        = null;
        }

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (tokenId != R.sections.Toasts.strings.Count)
			{
				Translator.removeLanguageChangedListener(UpdateText);
			}

			Toast.ToastDestroyed(this);
		}

		/// <summary>
		/// Handler for disable event.
		/// </summary>
		void OnDisable()
		{
			UnityEngine.Object.DestroyObject(gameObject);
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
		/// Show this toast.
		/// </summary>
        public void Show()
        {
			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			gameObject.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image toastImage = gameObject.AddComponent<Image>();
			
			toastImage.sprite = Assets.Toasts.Textures.toastBackground;
			toastImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Image CanvasGroup
			//===========================================================================
			#region CanvasGroup Component
			mToastCanvasGroup = gameObject.AddComponent<CanvasGroup>();
			
			mToastCanvasGroup.blocksRaycasts = false;
			#endregion
			
			//***************************************************************************
			// ToastText GameObject
			//***************************************************************************
			#region ToastText GameObject
			GameObject toastTextObject = new GameObject("Text");
			Utils.InitUIObject(toastTextObject, transform);
			
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
			mToastText = toastTextObject.AddComponent<Text>();
			
			mToastText.font      = Assets.Common.Fonts.microsoftSansSerif;
			mToastText.fontSize  = 24;
			mToastText.alignment = TextAnchor.MiddleCenter;
			mToastText.color     = new Color(1f, 1f, 1f, 1f);

			if (tokenId != R.sections.Toasts.strings.Count)
			{
				Translator.addLanguageChangedListener(UpdateText);
				UpdateText();
			}
			else
			{
				mToastText.text = text;
			}
			#endregion
			#endregion
            
            StartTimer(duration);
        }

		/// <summary>
		/// Updates the text.
		/// </summary>
		public void UpdateText()
		{
			if (tokenArguments == null || tokenArguments.Length == 0)
			{
				mToastText.text = Translator.getString(tokenId);
			}
			else
			{
				mToastText.text = Translator.getString(tokenId, tokenArguments);
            }
        }
        
        /// <summary>
        /// Destroies the toast.
        /// </summary>
        private void DestroyToast()
        {
            UnityEngine.Object.DestroyObject(gameObject);
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

