using System;
using UnityEngine;
using UnityEngine.Events;
using UnityTranslation;



namespace common
{
    namespace ui
    {
        /// <summary>
        /// Menu item.
        /// </summary>
        public class MenuItem
        {
            private TreeNode<MenuItem>           mNode           = null;
            private R.sections.MenuItems.strings mTokenId        = R.sections.MenuItems.strings.Count;
            private object[]                     mTokenArguments = null;
            private string                       mText           = null;
            private UnityAction                  mOnClick        = null;
            private bool                         mEnabled        = false;
            private bool                         mIsSeparator    = false;



            /// <summary>
            /// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class.
            /// </summary>
            public MenuItem()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class with given token ID and with
            /// assigning to specified <see cref="common.TreeNode`1"/> instance.
            /// </summary>
            /// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
            /// <param name="tokenId">Token ID for translation.</param>
            /// <param name="onClick">Click event handler.</param>
            /// <param name="enabled">Is this menu item enabled or not.</param>
            public static TreeNode<MenuItem> Create(TreeNode<MenuItem> owner, R.sections.MenuItems.strings tokenId, UnityAction onClick = null, bool enabled = true)
            {
                TreeNode<MenuItem> node = owner.AddChild(new MenuItem());

                node.Data.mNode    = node;
                node.Data.mTokenId = tokenId;
                node.Data.mOnClick = onClick;
                node.Data.mEnabled = enabled;

                return node;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="common.ui.MenuItem"/> class with given text and with
            /// assigning to specified <see cref="common.TreeNode`1"/> instance.
            /// </summary>
            /// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
            /// <param name="text">Menu item text.</param>
            /// <param name="onClick">Click event handler.</param>
            /// <param name="enabled">Is this menu item enabled or not.</param>
            public static TreeNode<MenuItem> Create(TreeNode<MenuItem> owner, string text, UnityAction onClick = null, bool enabled = true)
            {
                TreeNode<MenuItem> node = owner.AddChild(new MenuItem());
                
                node.Data.mNode    = node;
                node.Data.mText    = text;
                node.Data.mOnClick = onClick;
                node.Data.mEnabled = enabled;
                
                return node;
            }

            /// <summary>
            /// Creates <see cref="common.ui.MenuItem"/> instance that representing separator and adds it to
            /// <see cref="common.TreeNode`1"/> instance.
            /// </summary>
            /// <param name="owner"><see cref="common.TreeNode`1"/> instance.</param>
            public static void InsertSeparator(TreeNode<MenuItem> owner)
            {
                TreeNode<MenuItem> node = owner.AddChild(new MenuItem());

                node.Data.mNode        = node;
                node.Data.mIsSeparator = true;
            }

            /// <summary>
            /// Gets the assigned <see cref="common.TreeNode`1"/> instance.
            /// </summary>
            /// <value>The assigned <see cref="common.TreeNode`1"/> instance.</value>
            public TreeNode<MenuItem> Node
            {
                get { return mNode; }
            }

            
            /// <summary>
            /// Gets or sets the token ID.
            /// </summary>
            /// <value>The token identifier.</value>
            public R.sections.MenuItems.strings TokenId
            {
                get { return mTokenId;  }
                set { mTokenId = value; }
            }

            /// <summary>
            /// Gets or sets the token arguments.
            /// </summary>
            /// <value>The token arguments.</value>
            public object[] TokenArguments
            {
                get { return mTokenArguments;  }
                set { mTokenArguments = value; }
            }

            /// <summary>
            /// Gets the menu item name.
            /// </summary>
            /// <value>The menu item name.</value>
            public string Name
            {
                get
                {
                    if (mText != null)
                    {
                        return mText;
                    }

                    if (mTokenId != R.sections.MenuItems.strings.Count)
                    {
                        return mTokenId.ToString();
                    }

                    Debug.LogError("MenuItem.Name returns empty string");
                    return "";
                }
            }

            /// <summary>
            /// Gets or sets the menu item text.
            /// </summary>
            /// <value>The menu item text.</value>
            public string Text
            {
                get
                {
                    if (mText != null)
                    {
                        return mText;
                    }

                    if (mTokenId != R.sections.MenuItems.strings.Count)
                    {
                        if (mTokenArguments == null || mTokenArguments.Length == 0)
                        {
                            return Translator.getString(mTokenId);
                        }
                        else
                        {
                            return Translator.getString(mTokenId, mTokenArguments);
                        }
                    }

                    Debug.LogError("MenuItem.Text returns empty string");
                    return "";
                }

                set
                {
                    if (value == null || value == "")
                    {
                        mText = null;
                    }
                    else
                    {
                        mText = value;
                    }
                }
            }

            /// <summary>
            /// Gets the click event handler.
            /// </summary>
            /// <value>The click event handler.</value>
            public UnityAction OnClick
            {
                get { return mOnClick; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="common.ui.MenuItem"/> is enabled.
            /// </summary>
            /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
            public bool Enabled
            {
                get { return mEnabled;  }
                set { mEnabled = value; }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is separator.
            /// </summary>
            /// <value><c>true</c> if this instance is separator; otherwise, <c>false</c>.</value>
            public bool IsSeparator
            {
                get { return mIsSeparator; }
            }
        }
    }
}
