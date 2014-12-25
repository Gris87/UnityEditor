using UnityEngine;



public static class Global
{
	private static MainMenuScript      mMainMenu;
	private static PopupMenuAreaScript mPopupMenuArea;



	static Global ()
	{
		mMainMenu      = GameObject.Find("/UI/Canvas/MainMenu").GetComponent<MainMenuScript>();
		mPopupMenuArea = GameObject.Find("/UI/Canvas/PopupMenuArea").GetComponent<PopupMenuAreaScript>();
	}

	public static MainMenuScript MainMenu
	{
		get { return mMainMenu; }
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