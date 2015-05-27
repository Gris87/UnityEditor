using UnityEngine;
using UnityEngine.EventSystems;
using UnityTranslation;



namespace ui
{
	/// <summary>
	/// Script that realize behaviour for tooltip owner.
	/// </summary>
	public class TooltipOwnerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		/// <summary>
		/// Token ID for translation.
		/// </summary>
		public R.sections.Tooltips.strings tokenId = R.sections.Tooltips.strings.Count;



		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			Global.tooltipAreaScript.OnTooltipOwnerDestroy(this);
		}

		/// <summary>
		/// Handler for disable event.
		/// </summary>
		void OnDisable()
		{
			Global.tooltipAreaScript.OnTooltipOwnerDisable(this);
		}

		/// <summary>
		/// Handler for pointer enter event.
		/// </summary>
		public void OnPointerEnter(PointerEventData eventData)
		{
			Global.tooltipAreaScript.OnTooltipOwnerEnter(this);
		}

		/// <summary>
		/// Handler for pointer exit event.
		/// </summary>
		public void OnPointerExit(PointerEventData eventData)
        {
			Global.tooltipAreaScript.OnTooltipOwnerExit(this);
        }
    }
}