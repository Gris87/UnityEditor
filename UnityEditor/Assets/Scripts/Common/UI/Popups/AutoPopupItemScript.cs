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
            PopupMenuAreaScript.OnAutoPopupItemDestroy(this);
        }

        /// <summary>
        /// Handler for disable event.
        /// </summary>
        void OnDisable()
        {
            PopupMenuAreaScript.OnAutoPopupItemDisable(this);
        }

        /// <summary>
        /// Handler for pointer enter event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            PopupMenuAreaScript.OnAutoPopupItemEnter(this);
        }

        /// <summary>
        /// Handler for pointer exit event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            PopupMenuAreaScript.OnAutoPopupItemExit(this);
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
