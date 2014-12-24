using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class PopupMenuAreaScript : MonoBehaviour, IPointerDownHandler
{
	public Sprite background;
	public Sprite separator;
	public Button itemButton;
	public Button itemButtonDisabled;

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("fghfdh");
		eventData.Reset();
	}
}
