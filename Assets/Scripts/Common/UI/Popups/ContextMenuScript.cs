using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;



namespace Common.UI.Popups
{
    /// <summary>
    /// Script that realize behaviour for context menu handling.
    /// </summary>
    public class ContextMenuScript : MonoBehaviour, IPointerDownHandler
    {
        /// <summary>
        /// Gets or sets the source object.
        /// </summary>
        /// <value>The source object.</value>
        public object sourceObject
        {
            get { return mSourceObject;  }
            set { mSourceObject = value; }
        }

        /// <summary>
        /// Gets or sets show context menu callback.
        /// </summary>
        /// <value>Show context menu callback.</value>
        public UnityAction<object> onShowContextMenu
        {
            get { return mOnShowContextMenu;  }
            set { mOnShowContextMenu = value; }
        }



        private object              mSourceObject;
        private UnityAction<object> mOnShowContextMenu;



        /// <summary>
        /// Handler for pointer down event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                mOnShowContextMenu.Invoke(mSourceObject);
            }
        }
    }
}

