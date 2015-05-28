using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using common.ui;



namespace ui
{
	/// <summary>
	/// Script that realize behaviour for PopupMenus controller.
	/// </summary>
	public class PopupMenuAreaScript : MonoBehaviour
	{	
		private static float TIMER_NOT_ACTIVE = -10000f;



		private List<PopupMenu>     mPopupMenus;
		private AutoPopupItemScript mAutoPopupItem;
		private float               mRemainingTime;
		
		
		
		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			mPopupMenus    = new List<PopupMenu>();
			mAutoPopupItem = null;
			mRemainingTime = TIMER_NOT_ACTIVE;
		}
		
		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			if (mPopupMenus.Count > 0)
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
		}

		public void OnAutoPopupItemDestroy(AutoPopupItemScript item)
		{
			if (mPopupMenus.Count > 0)
			{
				if (mAutoPopupItem == item)
				{
					mAutoPopupItem = null;
					StopTimer();
				}
			}
		}

		public void OnAutoPopupItemDisable(AutoPopupItemScript item)
		{
			if (mPopupMenus.Count > 0)
			{
				if (mAutoPopupItem == item)
				{
					mAutoPopupItem = null;
					StopTimer();
				}
			}
		}

		public void OnAutoPopupItemEnter(AutoPopupItemScript item)
		{
			if (mPopupMenus.Count > 0)
			{
				mAutoPopupItem = item;
				StartTimer(mAutoPopupItem.delay);
			}
		}

		public void OnAutoPopupItemExit(AutoPopupItemScript item)
		{
			if (mPopupMenus.Count > 0)
			{
				mAutoPopupItem = null;
				StopTimer();
			}
		}
		
		/// <summary>
		/// Registers specified popup menu.
		/// </summary>
		/// <param name="menu">Popup menu.</param>
		public void RegisterPopupMenu(PopupMenu menu)
		{
			mPopupMenus.Add(menu);
		}
		
		/// <summary>
		/// Deregisters specified popup menu.
		/// </summary>
		/// <param name="menu">Popup menu.</param>
		public void DeregisterPopupMenu(PopupMenu menu)
		{
			mPopupMenus.Remove(menu);

			if (mPopupMenus.Count == 0)
			{
				mAutoPopupItem = null;
				StopTimer();
			}
		}
		
		/// <summary>
		/// This method will destroy all popup menus.
		/// </summary>
		public void DestroyAll()
		{
			if (mPopupMenus.Count > 0)
			{
				mPopupMenus[0].Destroy();
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
