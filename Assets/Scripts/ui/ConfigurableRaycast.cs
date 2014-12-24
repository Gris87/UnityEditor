using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class ConfigurableRaycast : MonoBehaviour, ICanvasRaycastFilter 
{
	public bool catchTouches = true;

	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return catchTouches;
	}
}
