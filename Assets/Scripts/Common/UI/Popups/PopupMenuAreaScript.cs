using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



namespace Common.UI.Popups
{
    /// <summary>
    /// Script that realize behaviour for PopupMenus controller.
    /// </summary>
    public class PopupMenuAreaScript : MonoBehaviour
    {
        private const float TIMER_NOT_ACTIVE = -10000f;



        /// <summary>
        /// Gets the instance geometry.
        /// </summary>
        /// <value>Instance geometry.</value>
        public static Transform geometry
        {
            get { return sInstance.transform; }
        }



        private static PopupMenuAreaScript sInstance = null;



        private List<PopupMenu>     mPopupMenus;
        private AutoPopupItemScript mAutoPopupItem;
        private float               mRemainingTime;



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
                Debug.LogError("Two instances of PopupMenuAreaScript not supported");
            }

            mPopupMenus    = new List<PopupMenu>();
            mAutoPopupItem = null;
            mRemainingTime = TIMER_NOT_ACTIVE;

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
            if (InputControl.GetMouseButtonDown(MouseButton.Left))
            {
                PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
                pointerEvent.position = InputControl.mousePosition;

                List<RaycastResult> hits = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEvent, hits);

                bool hitPopupMenu = false;

                if (hits.Count > 0)
                {
                    Transform curTransform = hits[0].gameObject.transform;

                    while (curTransform != null)
                    {
                        if (curTransform == transform)
                        {
                            hitPopupMenu = true;
                            break;
                        }

                        curTransform = curTransform.parent;
                    }
                }

                if (!hitPopupMenu)
                {
                    mPopupMenus[0].Destroy();
                }
            }
            else
            if (InputControl.GetButtonDown(Controls.buttons.cancel, true))
            {
                mPopupMenus[mPopupMenus.Count - 1].Destroy();
            }

            if (IsTimerActive())
            {
                mRemainingTime -= Time.deltaTime;

                if (mRemainingTime <= 0)
                {
                    mAutoPopupItem.Click();
                    StopTimer();
                }
            }
        }

        public static void OnAutoPopupItemDestroy(AutoPopupItemScript item)
        {
            if (sInstance != null)
            {
                if (sInstance.mPopupMenus.Count > 0)
                {
                    if (sInstance.mAutoPopupItem == item)
                    {
                        sInstance.mAutoPopupItem = null;
                        sInstance.StopTimer();
                    }
                }
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
        }

        public static void OnAutoPopupItemDisable(AutoPopupItemScript item)
        {
            if (sInstance != null)
            {
                if (sInstance.mPopupMenus.Count > 0)
                {
                    if (sInstance.mAutoPopupItem == item)
                    {
                        sInstance.mAutoPopupItem = null;
                        sInstance.StopTimer();
                    }
                }
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
        }

        public static void OnAutoPopupItemEnter(AutoPopupItemScript item)
        {
            if (sInstance != null)
            {
                if (sInstance.mPopupMenus.Count > 0)
                {
                    sInstance.mAutoPopupItem = item;
                    sInstance.StartTimer(sInstance.mAutoPopupItem.delay);
                }
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
        }

        public static void OnAutoPopupItemExit(AutoPopupItemScript item)
        {
            if (sInstance != null)
            {
                if (sInstance.mPopupMenus.Count > 0)
                {
                    sInstance.mAutoPopupItem = null;
                    sInstance.StopTimer();
                }
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
        }

        /// <summary>
        /// Registers specified popup menu.
        /// </summary>
        /// <param name="menu">Popup menu.</param>
        public static void RegisterPopupMenu(PopupMenu menu)
        {
            if (sInstance != null)
            {
                sInstance.mPopupMenus.Add(menu);
                sInstance.enabled = true;
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
        }

        /// <summary>
        /// Deregisters specified popup menu.
        /// </summary>
        /// <param name="menu">Popup menu.</param>
        public static void DeregisterPopupMenu(PopupMenu menu)
        {
            if (sInstance != null)
            {
                if (sInstance.mPopupMenus.Remove(menu))
                {
                    if (sInstance.mPopupMenus.Count == 0)
                    {
                        sInstance.enabled = false;
                        sInstance.mAutoPopupItem = null;
                        sInstance.StopTimer();
                    }
                }
                else
                {
                    Debug.LogError("Failed to deregister popup menu");
                }
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
        }

        /// <summary>
        /// This method will destroy all popup menus.
        /// </summary>
        public static void DestroyAll()
        {
            if (sInstance != null)
            {
                if (sInstance.mPopupMenus.Count > 0)
                {
                    sInstance.mPopupMenus[0].Destroy();
                }
            }
            else
            {
                Debug.LogError("There is no PopupMenuAreaScript instance");
            }
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
