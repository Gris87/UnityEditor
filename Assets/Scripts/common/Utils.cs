using UnityEngine;
using System;



namespace common
{
    public static class Utils
    {
        public static void InitUIObject(GameObject uiObject, Transform parent)
        {
            uiObject.transform.parent = parent;
            uiObject.layer = LayerMask.NameToLayer("UI");
        }

        public static void AlignRectTransformFill(RectTransform transform)
        {
            transform.localScale         = new Vector2(1f, 1f);
            transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            transform.sizeDelta          = new Vector2(0f, 0f);
            transform.anchorMin          = new Vector2(0f, 0f);
            transform.anchorMax          = new Vector2(1f, 1f);
        }
    }
}

