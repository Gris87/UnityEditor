using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace ui
{
	/// <summary>
	/// Script that realize behaviour for auto popup item.
	/// </summary>
	public class AutoPopupItemScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{	
		/// <summary>
		/// Delay before showing popup.
		/// </summary>
		public float delay = 0f;



		private Button mButton;



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
			Global.popupMenuAreaScript.OnAutoPopupItemDestroy(this);
		}
		
		/// <summary>
		/// Handler for disable event.
		/// </summary>
		void OnDisable()
		{
			Global.popupMenuAreaScript.OnAutoPopupItemDisable(this);
		}
		
		/// <summary>
		/// Handler for pointer enter event.
		/// </summary>
		public void OnPointerEnter(PointerEventData eventData)
		{
			Global.popupMenuAreaScript.OnAutoPopupItemEnter(this);
		}
		
		/// <summary>
		/// Handler for pointer exit event.
		/// </summary>
		public void OnPointerExit(PointerEventData eventData)
		{
			Global.popupMenuAreaScript.OnAutoPopupItemExit(this);
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