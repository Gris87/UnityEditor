using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityTranslation;

using Common;



namespace Common.UI.Tooltips
{
    /// <summary>
    /// Script that realize behaviour for tooltip controller.
    /// </summary>
    public class TooltipAreaScript : MonoBehaviour
    {
        private const float TIMER_NOT_ACTIVE = -10000f;
        private const float SHOW_DELAY       = 500f;
        private const float HIDE_DELAY       = 500f;



        private static TooltipAreaScript sInstance = null;



        private TooltipOwnerScript mCurrentOwner;
        private TooltipOwnerScript mNextOwner;
        private float              mRemainingTime;
        private UnityAction        mOnTimeout;



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
                Debug.LogError("Two instances of TooltipAreaScript not supported");
            }

            mCurrentOwner  = null;
            mNextOwner     = null;
            mRemainingTime = TIMER_NOT_ACTIVE;
            mOnTimeout     = null;
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
        public static void OnTooltipOwnerDestroy(TooltipOwnerScript owner)
        {
            if (sInstance != null)
            {
                if (sInstance.mCurrentOwner == owner)
                {
                    sInstance.DestroyTooltip();
                }
                else
                if (sInstance.mNextOwner == owner)
                {
                    sInstance.mNextOwner = null;
                    sInstance.StopTimer();
                }
            }
            else
            {
                Debug.LogError("There is no TooltipAreaScript instance");
            }
        }

        /// <summary>
        /// Handler on owner disable event.
        /// </summary>
        /// <param name="owner">Tooltip owner.</param>
        public static void OnTooltipOwnerDisable(TooltipOwnerScript owner)
        {
            if (sInstance != null)
            {
                if (sInstance.mCurrentOwner == owner)
                {
                    sInstance.DestroyTooltip();
                }
                else
                if (sInstance.mNextOwner == owner)
                {
                    sInstance.mNextOwner = null;
                    sInstance.StopTimer();
                }
            }
            else
            {
                Debug.LogError("There is no TooltipAreaScript instance");
            }
        }

        /// <summary>
        /// Handler on owner pointer enter event.
        /// </summary>
        /// <param name="owner">Tooltip owner.</param>
        public static void OnTooltipOwnerEnter(TooltipOwnerScript owner)
        {
            if (sInstance != null)
            {
                if (sInstance.mCurrentOwner != null)
                {
                    if (sInstance.mCurrentOwner == owner)
                    {
                        sInstance.mNextOwner = null;
                        sInstance.StopTimer();
                    }
                    else
                    {
                        sInstance.mNextOwner = owner;

                        if (sInstance.IsTimerActive())
                        {
                            sInstance.CreateTooltip();
                            sInstance.StopTimer();
                        }
                        else
                        {
                            sInstance.StartTimer(SHOW_DELAY, sInstance.CreateTooltip);
                        }
                    }
                }
                else
                {
                    sInstance.mNextOwner = owner;
                    sInstance.StartTimer(SHOW_DELAY, sInstance.CreateTooltip);
                }
            }
            else
            {
                Debug.LogError("There is no TooltipAreaScript instance");
            }
        }

        /// <summary>
        /// Handler on owner pointer exit event.
        /// </summary>
        /// <param name="owner">Tooltip owner.</param>
        public static void OnTooltipOwnerExit(TooltipOwnerScript owner)
        {
            if (sInstance != null)
            {
                sInstance.mNextOwner = null;

                if (sInstance.mCurrentOwner != null)
                {
                    if (sInstance.mCurrentOwner == owner)
                    {
                        sInstance.StartTimer(HIDE_DELAY, sInstance.DestroyTooltip);
                    }
                }
                else
                {
                    sInstance.StopTimer();
                }
            }
            else
            {
                Debug.LogError("There is no TooltipAreaScript instance");
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

            tooltipImage.sprite = Assets.Tooltips.Textures.tooltipBackground;
            tooltipImage.type   = Image.Type.Sliced;

            Vector4 tooltipBorders = tooltipImage.sprite.border;

            float tooltipBorderLeft   = tooltipBorders.x + 2f;
            float tooltipBorderTop    = tooltipBorders.w + 4f;
            float tooltipBorderRight  = tooltipBorders.y + 2f;
            float tooltipBorderBottom = tooltipBorders.z + 4f;
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
            Utils.AlignRectTransformStretchStretch(
                                                     tooltipTextTransform
                                                   , tooltipBorderLeft
                                                   , tooltipBorderTop
                                                   , tooltipBorderRight
                                                   , tooltipBorderBottom
                                                  );
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            Text tooltipText = tooltipTextObject.AddComponent<Text>();

            Assets.Tooltips.TextStyles.tooltipText.Apply(tooltipText);

            tooltipText.text = Translator.GetString(mCurrentOwner.tokenId);
            #endregion
            #endregion

			float mouseX = Mouse.scaledX;
			float mouseY = Mouse.scaledY;

            float tooltipWidth = tooltipText.preferredWidth + tooltipBorderLeft + tooltipBorderRight;
            float screenWidth  = Utils.scaledScreenWidth;

            if (tooltipWidth > screenWidth)
            {
                tooltipWidth = screenWidth;
            }

            tooltipTransform.sizeDelta = new Vector2(tooltipWidth, 0f);
            float tooltipHeight = tooltipText.preferredHeight + tooltipBorderTop + tooltipBorderBottom;

			Utils.FitRectTransformToScreen(tooltipTransform, tooltipWidth, tooltipHeight, mouseX, mouseY);
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
