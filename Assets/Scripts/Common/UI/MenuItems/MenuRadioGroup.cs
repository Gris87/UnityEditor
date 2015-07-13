using System.Collections.Generic;
using UnityEngine;



namespace Common.UI.MenuItems
{
    /// <summary>
    /// Menu radio group.
    /// </summary>
    public class MenuRadioGroup
    {
        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public MenuItem selectedItem
        {
            get
            {
                return mSelectedItem;
            }

            set
            {
                if (mSelectedItem != value)
                {
                    if (value.radioGroup == this)
                    {
                        mSelectedItem = value;
                    }
                    else
                    {
                        Debug.LogError("Trying to select item \"" + value.name + "\" that is not registered in this radio group");
                    }
                }
            }
        }



        private List<MenuItem> mItems;
        private MenuItem       mSelectedItem;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.MenuItems.MenuRadioGroup"/> class.
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
            if (item.radioGroup == null)
            {
                mItems.Add(item);

                item.radioGroup = this;

                if (mItems.Count == 1)
                {
                    mSelectedItem = item;
                }
            }
            else
            {
                Debug.LogError("Item \"" + item.name + "\" already registered in radio group");
            }
        }

        /// <summary>
        /// Deregister the specified menu item from radio group.
        /// </summary>
        /// <param name="item">Menu item.</param>
        public void Deregister(MenuItem item)
        {
            if (item.radioGroup == this)
            {
                if (mItems.Remove(item))
                {
                    item.radioGroup = null;

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
                    Debug.LogError("Failed to deregister item \"" + item.name + "\" from radio froup");
                }
            }
            else
            {
                Debug.LogError("Item \"" + item.name + "\" is not registered in this radio group");
            }
        }
    }
}

