namespace Common.UI.MenuItems
{
    /// <summary>
    /// Shortcut handler interface.
    /// </summary>
    public interface IShortcutHandler
    {
        /// <summary>
        /// Registers the shortcut.
        /// </summary>
        /// <param name="shortcut">Shortcut.</param>
        void RegisterShortcut(MenuItem shortcut);

        /// <summary>
        /// Deregisters the shortcut.
        /// </summary>
        /// <param name="shortcut">Shortcut.</param>
        void DeregisterShortcut(MenuItem shortcut);
    }
}

