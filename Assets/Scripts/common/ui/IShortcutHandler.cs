namespace common
{
	namespace ui
	{
		public interface IShortcutHandler
		{
			void RegisterShortcut(MenuItem shortcut);
			void DeregisterShortcut(MenuItem shortcut);
		}
	}
}

