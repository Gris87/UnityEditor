using UnityEngine;



public static class Global
{
	private static PopupMenuAreaScript mPopupMenuArea;

	static Global ()
	{
		mPopupMenuArea = GameObject.Find("/UI/Canvas/PopupMenuArea").GetComponent<PopupMenuAreaScript>();
	}

	public static PopupMenuAreaScript PopupMenuArea
	{
		get { return mPopupMenuArea; }
	}

	public static Transform PopupMenuAreaTransform
	{
		get { return mPopupMenuArea.transform; }
	}
}