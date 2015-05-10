using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using common.ui;



/// <summary>
/// Script that realize behaviour for PopupMenus controller.
/// </summary>
public class PopupMenuAreaScript : MonoBehaviour
{
    /// <summary>
    /// PopupMenu background.
    /// </summary>
    public Sprite background;

    /// <summary>
    /// Separator image.
    /// </summary>
    public Sprite separator;

    /// <summary>
    /// Item button prefab.
    /// </summary>
    public Button itemButton;

    /// <summary>
    /// Disabled item button prefab.
    /// </summary>
    public Button itemButtonDisabled;



    private List<PopupMenu> mPopupMenus;



    /// <summary>
    /// Script starting callback.
    /// </summary>
    void Start()
    {
        mPopupMenus = new List<PopupMenu>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (mPopupMenus.Count > 0)
        {
            if (Input.GetMouseButtonDown(0)) // TODO: InputControl
            {
                PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
                pointerEvent.position = Input.mousePosition; // TODO: InputControl

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
            if (Input.GetButtonDown("Cancel")) // TODO: InputControl
            {
                mPopupMenus[mPopupMenus.Count - 1].Destroy();
            }
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
    }
}
