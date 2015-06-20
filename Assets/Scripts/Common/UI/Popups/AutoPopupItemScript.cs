using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace Common.UI.Popups
{
	/// <summary>
	/// Script that realize behaviour for auto popup item.
	/// </summary>
	public class AutoPopupItemScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{	
		private Button mButton;
		private float  mDelay  = 0f;



		/// <summary>
		/// Delay before showing popup.
		/// </summary>
		public float delay
		{
			get { return mDelay;  }
			set { mDelay = value; }
		}



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			mButton = GetComponent<Button>();

			if (mButton == null)
			{
				Debug.LogError("Button component not found");
			}
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			Global.popupMenuAreaScript.OnAutoPopupItemDestroy(this); // TODO: Remove Global from Common part
		}
		
		/// <summary>
		/// Handler for disable event.
		/// </summary>
		void OnDisable()
		{
			Global.popupMenuAreaScript.OnAutoPopupItemDisable(this); // TODO: Remove Global from Common part
		}
		
		/// <summary>
		/// Handler for pointer enter event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnPointerEnter(PointerEventData eventData)
		{
			Global.popupMenuAreaScript.OnAutoPopupItemEnter(this); // TODO: Remove Global from Common part
		}
		
		/// <summary>
		/// Handler for pointer exit event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void OnPointerExit(PointerEventData eventData)
		{
			Global.popupMenuAreaScript.OnAutoPopupItemExit(this); // TODO: Remove Global from Common part
		}

		/// <summary>
		/// Click the button.
		/// </summary>
		public void Click()
		{
			mButton.onClick.Invoke();
		}
	}
}