using UnityEngine;



/// <summary>
/// Class with global data.
/// </summary>
public static class Global
{
    private static MainMenuScript      mMainMenu;
    private static PopupMenuAreaScript mPopupMenuArea;



    static Global ()
    {
        mMainMenu      = GameObject.Find("/UI/Canvas/MainMenu").GetComponent<MainMenuScript>();
        mPopupMenuArea = GameObject.Find("/UI/Canvas/PopupMenuArea").GetComponent<PopupMenuAreaScript>();
    }

    /// <summary>
    /// MainMenuScript instance.
    /// </summary>
    /// <value>The instance of MainMenuScript.</value>
    public static MainMenuScript MainMenu
    {
        get { return mMainMenu; }
    }

    /// <summary>
    /// PopupMenuAreaScript instance.
    /// </summary>
    /// <value>The instance of PopupMenuAreaScript.</value>
    public static PopupMenuAreaScript PopupMenuArea
    {
        get { return mPopupMenuArea; }
    }

    /// <summary>
    /// Transform of PopupMenuAreaScript instance.
    /// </summary>
    /// <value>The transform of PopupMenuAreaScript instance.</value>
    public static Transform PopupMenuAreaTransform
    {
        get { return mPopupMenuArea.transform; }
    }
}
