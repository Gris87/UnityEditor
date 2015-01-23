using UnityEngine;
using UnityEngine.UI;
using System;



namespace common
{
	/// <summary>
	/// Class for Unity Editor usefull functions.
	/// </summary>
    public static class Utils
    {
		/// <summary>
		/// Put UI object in specified transform and initialize this UI object.
		/// </summary>
		/// <param name="uiObject">User interface object.</param>
		/// <param name="parent">Parent transform.</param>
        public static void InitUIObject(GameObject uiObject, Transform parent)
        {
            uiObject.transform.SetParent(parent);
            uiObject.layer = LayerMask.NameToLayer("UI");
        }

		/// <summary>
		/// Gets the local coordinates for corners of specified transform.
		/// </summary>
		/// <returns>The local coordinates for corners of specified transform.</returns>
		/// <param name="transform">RectTransform instance.</param>
		public static Vector3[] GetWindowCorners(RectTransform transform)
		{
			RectTransform canvasTransform = transform;

			do
			{
				RectTransform tempTransform = canvasTransform.parent.GetComponent<RectTransform>();

				if (tempTransform == null)
				{
					break;
				}

				canvasTransform = tempTransform;
			} while (true);

			Vector3[] res = new Vector3[4];

			Vector3 vMin = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vMax = new Vector3(float.MinValue, float.MinValue, float.MinValue);

			Matrix4x4 toLocal = canvasTransform.worldToLocalMatrix;
			transform.GetWorldCorners(res);

			for (int j = 0; j < 4; j++)
			{
				Vector3 v = toLocal.MultiplyPoint3x4(res[j]);
				vMin = Vector3.Min(v, vMin);
				vMax = Vector3.Max(v, vMax);
			}

			res[0].Set(vMin.x, vMin.y, 0f);
			res[1].Set(vMin.x, vMax.y, 0f);
			res[2].Set(vMax.x, vMax.y, 0f);
			res[3].Set(vMax.x, vMin.y, 0f);

			return res;
		}

		/// <summary>
		/// Setup RectTransform to fill whole space of parent RectTransform.
		/// </summary>
		/// <param name="transform">RectTransform instance.</param>
        public static void AlignRectTransformFill(RectTransform transform)
        {
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
            transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            transform.sizeDelta          = new Vector2(0f, 0f);            
        }

		// TODO: Add more Align functions
    }
}
