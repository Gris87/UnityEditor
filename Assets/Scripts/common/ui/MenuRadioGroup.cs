using System.Collections.Generic;
using UnityEngine;



namespace common
{
	namespace ui
	{
		/// <summary>
		/// Menu radio group.
		/// </summary>
		public class MenuRadioGroup
		{
			private List<MenuItem> mItems;
			private MenuItem       mSelectedItem;



			/// <summary>
			/// Initializes a new instance of the <see cref="common.ui.MenuRadioGroup"/> class.
			/// </summary>
			public MenuRadioGroup()
			{
				mItems        = new List<MenuItem>();
				mSelectedItem = null;
			}

			/// <summary>
			/// Register the specifiedm menu item to radio group.
			/// </summary>
			/// <param name="item">Menu item.</param>
			public void Register(MenuItem item)
			{
				if (item.RadioGroup == null)
				{
					mItems.Add(item);

					item.RadioGroup = this;
					
					if (mItems.Count == 1)
					{
						mSelectedItem = item;
					}
				}
				else
				{
					Debug.LogError("Item \"" + item.Name + "\" already registered");
				}
			}

			/// <summary>
			/// Deregister the specified menu item from radio group.
			/// </summary>
			/// <param name="item">Menu item.</param>
			public void Deregister(MenuItem item)
			{
				if (item.RadioGroup == this)
				{
					if (mItems.Remove(item))
					{
						item.RadioGroup = null;

						if (mSelectedItem == item)
						{
							if (mItems.Count == 0)
							{
								mSelectedItem = null;
							}
							else
							{
								mSelectedItem = mItems[0];
							}
						}
					}
					else
					{
						Debug.LogError("Failed to deregister item \"" + item.Name + "\"");
					}
				}
				else
				{
					Debug.LogError("Item \"" + item.Name + "\" is not registered in this radio group");
				}
			}

			/// <summary>
			/// Gets or sets the selected item.
			/// </summary>
			/// <value>The selected item.</value>
			public MenuItem SelectedItem
			{
				get 
				{
					return mSelectedItem;
				}

				set
				{
					if (mSelectedItem != value)
					{
						if (value.RadioGroup == this)
						{
							mSelectedItem = value;
						}
						else
						{
							Debug.LogError("Trying to select item \"" + value.Name + "\" that is not registered in this radio group");
						}
					}
				}
			}
		}
	}
}

