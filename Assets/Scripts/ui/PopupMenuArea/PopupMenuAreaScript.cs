using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

using common.ui;



public class PopupMenuAreaScript : MonoBehaviour
{
	public Sprite background;
	public Sprite separator;
	public Button itemButton;
	public Button itemButtonDisabled;

	private List<PopupMenu> mPopupMenus;



	// Use this for initialization
	void Start()
	{
		mPopupMenus = new List<PopupMenu>();
	}

	// Update is called once per frame
	void Update()
	{
		if (mPopupMenus.Count > 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
				pointerEvent.position = Input.mousePosition;
				
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
		    if (Input.GetButtonDown("Cancel"))
			{
				mPopupMenus[mPopupMenus.Count - 1].Destroy();
			}
		}
	}

	public void RegisterPopupMenu(PopupMenu menu)
	{
		mPopupMenus.Add(menu);
	}

	public void DeregisterPopupMenu(PopupMenu menu)
	{
		mPopupMenus.Remove(menu);
	}
}
