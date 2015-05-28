using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityTranslation;

using common;



namespace ui
{
	/// <summary>
	/// Script that realize behaviour for tooltip controller.
	/// </summary>
	public class TooltipAreaScript : MonoBehaviour
	{
		private static float TIMER_NOT_ACTIVE = -10000f;
		private static float SHOW_DELAY       = 500f;
		private static float HIDE_DELAY       = 500f;



		private TooltipOwnerScript mCurrentOwner;
		private TooltipOwnerScript mNextOwner;
		private float              mRemainingTime;
		private UnityAction        mOnTimeout;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			mCurrentOwner  = null;
			mNextOwner     = null;
			mRemainingTime = TIMER_NOT_ACTIVE;
			mOnTimeout     = null;
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
					mOnTimeout.Invoke();
					StopTimer();
				}
			}

			if (mCurrentOwner != null)
			{
				if (InputControl.GetMouseButtonDown(MouseButton.Left))
				{
					DestroyTooltip();
				}
			}
		}

		/// <summary>
		/// Handler on owner destroy event.
		/// </summary>
		/// <param name="owner">Tooltip owner.</param>
		public void OnTooltipOwnerDestroy(TooltipOwnerScript owner)
		{
			if (mCurrentOwner == owner)
			{
				DestroyTooltip();
			}
			else
			if (mNextOwner == owner)
			{
				mNextOwner = null;
				StopTimer();
			}
		}

		/// <summary>
		/// Handler on owner disable event.
		/// </summary>
		/// <param name="owner">Tooltip owner.</param>
		public void OnTooltipOwnerDisable(TooltipOwnerScript owner)
		{
			if (mCurrentOwner == owner)
			{
				DestroyTooltip();
			}
			else
			if (mNextOwner == owner)
			{
				mNextOwner = null;
				StopTimer();
			}
		}

		/// <summary>
		/// Handler on owner pointer enter event.
		/// </summary>
		/// <param name="owner">Tooltip owner.</param>
		public void OnTooltipOwnerEnter(TooltipOwnerScript owner)
		{
			if (mCurrentOwner != null)
			{
				if (mCurrentOwner == owner)
				{
					mNextOwner = null;
					StopTimer();
				}
				else
				{
					mNextOwner = owner;
					
					if (IsTimerActive())
					{
						CreateTooltip();
						StopTimer();
					}
					else
					{
						StartTimer(SHOW_DELAY, CreateTooltip);
					}
				}
			}
			else
			{
				mNextOwner = owner;
				StartTimer(SHOW_DELAY, CreateTooltip);
			}
		}

		/// <summary>
		/// Handler on owner pointer exit event.
		/// </summary>
		/// <param name="owner">Tooltip owner.</param>
		public void OnTooltipOwnerExit(TooltipOwnerScript owner)
		{
			mNextOwner = null;

			if (mCurrentOwner != null)
			{
				if (mCurrentOwner == owner)
				{
					StartTimer(HIDE_DELAY, DestroyTooltip);
				}
			}
			else
			{
				StopTimer();
			}
		}

		/// <summary>
		/// Creates tooltip for current tooltip owner.
		/// </summary>
		private void CreateTooltip()
		{
			DestroyTooltip();

			mCurrentOwner = mNextOwner;
			mNextOwner    = null;

			//***************************************************************************
			// Tooltip GameObject
			//***************************************************************************
			#region Tooltip GameObject
			GameObject tooltip = new GameObject("Tooltip");
			Utils.InitUIObject(tooltip, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform tooltipTransform = tooltip.AddComponent<RectTransform>();
			#endregion

			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			tooltip.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image tooltipImage = tooltip.AddComponent<Image>();
			
			tooltipImage.sprite = Assets.TooltipArea.Textures.tooltipBackground;
			tooltipImage.type   = Image.Type.Sliced;
			#endregion

			//===========================================================================
			// Image CanvasGroup
			//===========================================================================
			#region CanvasGroup Component
			CanvasGroup tooltipCanvasGroup = tooltip.AddComponent<CanvasGroup>();
			
			tooltipCanvasGroup.blocksRaycasts = false;
			#endregion

			//***************************************************************************
			// TooltipText GameObject
			//***************************************************************************
			#region TooltipText GameObject
			GameObject tooltipTextObject = new GameObject("Text");
			Utils.InitUIObject(tooltipTextObject, tooltip.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform tooltipTextTransform = tooltipTextObject.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(tooltipTextTransform, 3f, 5f, 7f, 9f);
			#endregion

			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text tooltipText = tooltipTextObject.AddComponent<Text>();
			
			tooltipText.font     = Assets.Common.Fonts.microsoftSansSerif;
			tooltipText.fontSize = 11;
			tooltipText.color    = new Color(0f, 0f, 0f, 1f);
			tooltipText.text     = Translator.getString(mCurrentOwner.tokenId);
			#endregion
			#endregion

			Vector3 mousePos = InputControl.mousePosition;

			float tooltipWidth = tooltipText.preferredWidth  + 10f;
			int   screenWidth  = Screen.width;

			if (tooltipWidth > screenWidth)
			{
				tooltipWidth = screenWidth;
			}

			tooltipTransform.sizeDelta = new Vector2(tooltipWidth, 0f);
			float tooltipHeight = tooltipText.preferredHeight + 14f;

			Utils.FitRectTransformToScreen(tooltipTransform, tooltipWidth, tooltipHeight, mousePos.x, -mousePos.y + Screen.height);
			#endregion
		}

		/// <summary>
		/// Destroies previously created tooltip if present.
		/// </summary>
		private void DestroyTooltip()
		{
			if (transform.childCount > 0)
			{
				if (transform.childCount == 1)
				{
					UnityEngine.Object.Destroy(transform.GetChild(0).gameObject);
				}
				else
				{
					Debug.LogError("Unexpected behaviour in TooltipAreaScript.DestroyTooltip");
				}
			}

			mCurrentOwner = null;
		}

		/// <summary>
		/// Starts timer with specified delay and timeout handler.
		/// </summary>
		/// <param name="ms">Delay in ms.</param>
		/// <param name="onTimeout">Timeout handler.</param>
		private void StartTimer(float ms, UnityAction onTimeout)
		{
			if (ms < 0f)
			{
				Debug.LogError("Incorrect delay value: " + ms);
			}

			mRemainingTime = ms / 1000f;
			mOnTimeout     = onTimeout;
		}

		/// <summary>
		/// Stops timer.
		/// </summary>
		private void StopTimer()
		{
			mRemainingTime = TIMER_NOT_ACTIVE;
			mOnTimeout     = null;
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
