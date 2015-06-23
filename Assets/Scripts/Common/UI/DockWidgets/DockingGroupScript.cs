using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking group behaviour.
	/// </summary>
	public class DockingGroupScript : MonoBehaviour
	{
		/// <summary>
		/// Gets or sets parent docking area.
		/// </summary>
		/// <value>Parent docking area.</value>
		public DockingAreaScript parent
		{
			get { return mParent;  }
			set { mParent = value; }
		}

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		public ReadOnlyCollection<DockWidgetScript> children
		{
			get { return mChildren.AsReadOnly(); }
		}

		/// <summary>
		/// Gets or sets the index of selected tab.
		/// </summary>
		/// <value>The index of selected tab.</value>
		public int selectedIndex
		{
			get
			{
				return mSelectedIndex;
			}

			set
			{
				if (mSelectedIndex != value)
				{
					if (value >= 0 && value < mChildren.Count)
					{
						if (mSelectedIndex != -1)
						{
							mContentTransform.GetChild(mSelectedIndex).gameObject.SetActive(false);
							DockingTabButton tabButton = mTabsTransform.GetChild(mSelectedIndex).GetComponent<DockingTabButton>();

							tabButton.active = false;
						}

						mSelectedIndex = value;

						if (mSelectedIndex != -1)
						{
							mContentTransform.GetChild(mSelectedIndex).gameObject.SetActive(true);
							DockingTabButton tabButton = mTabsTransform.GetChild(mSelectedIndex).GetComponent<DockingTabButton>();
							
                            tabButton.active = true;
                        }
					}
					else
					{
						Debug.LogError("Invalid selected index value");
					}
				}
			}
		}



		private DockingAreaScript      mParent;
		private List<DockWidgetScript> mChildren;
		private int                    mSelectedIndex;

		private RectTransform mTabsTransform;
		private RectTransform mContentTransform;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingGroupScript"/> class.
		/// </summary>
		public DockingGroupScript()
		{
			mParent        = null;
			mChildren      = new List<DockWidgetScript>();
			mSelectedIndex = -1;

			mTabsTransform    = null;
			mContentTransform = null;
		}

		/// <summary>
		/// Script starting callback.
		/// </summary>
        void Awake()
		{
			Translator.addLanguageChangedListener(UpdateTabs);

			CreateUI();
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			Translator.removeLanguageChangedListener(UpdateTabs);
		}

		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			//===========================================================================
			// Tabs GameObject
			//===========================================================================
			#region Tabs GameObject
			GameObject tabs = new GameObject("Tabs");
			Utils.InitUIObject(tabs, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			mTabsTransform = tabs.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(mTabsTransform, 16f);
            #endregion
            #endregion
            
            //===========================================================================
			// Pages GameObject
			//===========================================================================
			#region Pages GameObject
			GameObject pages = new GameObject("Pages");
			Utils.InitUIObject(pages, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform pagesTransform = pages.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(pagesTransform, 0f, 16f, 0f, 0f);
			#endregion

			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			pages.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image pagesImage = pages.AddComponent<Image>();

			pagesImage.sprite = Assets.DockWidgets.Textures.pageBackground;
			pagesImage.type   = Image.Type.Sliced;
			#endregion

			//===========================================================================
			// Content GameObject
			//===========================================================================
			#region Content GameObject
			GameObject content = new GameObject("Content");
			Utils.InitUIObject(content, pages.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			mContentTransform = content.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(
													 mContentTransform
												   , pagesImage.sprite.border.x
												   , pagesImage.sprite.border.w
											  	   , pagesImage.sprite.border.z
												   , pagesImage.sprite.border.y
												  );
			#endregion
			#endregion
			#endregion

			mTabsTransform.SetAsLastSibling();
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		public void OnResize()
		{
			UpdateTabsGeometry();

			foreach (DockWidgetScript child in mChildren)
			{
				child.OnResize();
			}
        }

		/// <summary>
		/// Updates tabs geometry.
		/// </summary>
		private void UpdateTabsGeometry()
		{
			List<float> tabWidths = new List<float>();
			float totalWidth = 0f;

			for (int i = 0; i < mChildren.Count; ++i)
            {
                Text tabText = mTabsTransform.GetChild(i).GetChild(1).GetComponent<Text>(); // Tab/Text

				float tabWidth = tabText.preferredWidth + 40f;

				tabWidths.Add(tabWidth);
				totalWidth += tabWidth;
            }

			Vector3[] corners = new Vector3[4];
			(transform as RectTransform).GetLocalCorners(corners);
			float width = corners[2].x - corners[0].x;
                        
            float contentWidth = 0f;

			if (totalWidth <= width)
			{
				for (int i = 0; i < mChildren.Count; ++i)
				{
					RectTransform tabTransform = mTabsTransform.GetChild(i) as RectTransform;
					
					Utils.AlignRectTransformStretchLeft(tabTransform, tabWidths[i], contentWidth, 0f, -1f);
                    contentWidth += tabWidths[i];
				}
			}
			else
			{
				float tabWidth = width / mChildren.Count;

				for (int i = 0; i < mChildren.Count; ++i)
				{
					RectTransform tabTransform = mTabsTransform.GetChild(i) as RectTransform;
					
					Utils.AlignRectTransformStretchLeft(tabTransform, tabWidth, contentWidth, 0f, -1f);
					contentWidth += tabWidth;
				}
            }
		}

		/// <summary>
		/// Updates tabs.
		/// </summary>
		private void UpdateTabs()
		{
			for (int i = 0; i < mChildren.Count; ++i)
			{
				Text tabText = mTabsTransform.GetChild(i).GetChild(1).GetComponent<Text>(); // Tab/Text
				
				tabText.text = mChildren[i].title;
			}

			UpdateTabsGeometry();
		}

		/// <summary>
		/// Updates tab image.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		public void UpdateTabImage(DockWidgetScript dockWidget)
		{
			if (dockWidget.parent == this)
			{
				int index = mChildren.IndexOf(dockWidget);
				
				if (index >= 0)
				{
					Image tabImage = mTabsTransform.GetChild(index).GetChild(0).GetComponent<Image>(); // Tab/Image
					
					tabImage.sprite = dockWidget.image;
				}
				else
				{
                    Debug.LogError("Failed to update tab image");
                }
            }
            else
            {
				Debug.LogError("Dock widget belongs not to this docking group");
            }
        }
        
        /// <summary>
		/// Updates tab.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		public void UpdateTab(DockWidgetScript dockWidget)
		{
			if (dockWidget.parent == this)
			{
				int index = mChildren.IndexOf(dockWidget);

				if (index >= 0)
				{
					Text tabText = mTabsTransform.GetChild(index).GetChild(1).GetComponent<Text>(); // Tab/Text

					tabText.text = dockWidget.title;
					
					UpdateTabsGeometry();
                }
				else
				{
                    Debug.LogError("Failed to update tab");
				}
			}
			else
			{
				Debug.LogError("Dock widget belongs not to this docking group");
			}
        }

		/// <summary>
		/// Handler for tab select event.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		public void OnSelectTab(DockWidgetScript dockWidget)
        {
			if (dockWidget.parent == this)
			{
				int index = mChildren.IndexOf(dockWidget);
				
				if (index >= 0)
				{
					selectedIndex = index;
				}
				else
				{
                    Debug.LogError("Failed to select tab");
                }
            }
            else
            {
                Debug.LogError("Dock widget belongs not to this docking group");
            }
        }
        
        /// <summary>
        /// Insert the specified dock widget.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		/// <param name="index">Index.</param>
		public void InsertDockWidget(DockWidgetScript dockWidget, int index = 0)
		{
			if (dockWidget.parent != null)
			{
				if (dockWidget.parent == this)
				{
					if (index < mChildren.Count && mChildren[index] == dockWidget)
					{
						// Do nothing
						return;
					}

					int foundIndex = mChildren.IndexOf(dockWidget);

					if (foundIndex >= 0)
					{
						if (mSelectedIndex == foundIndex)
                        {
							mSelectedIndex = index;
						}

						mChildren.RemoveAt(foundIndex);
						mChildren.Insert(index, dockWidget);

						mTabsTransform.GetChild(foundIndex).SetSiblingIndex(index);
						dockWidget.transform.SetSiblingIndex(index);

						UpdateTabsGeometry();
					}
					else
					{
						Debug.LogError("Failed to insert dock widget");
					}

					return;
				}
				else
				{
					dockWidget.parent.RemoveDockWidget(dockWidget);
				}
			}

			dockWidget.parent = this;
			mChildren.Insert(index, dockWidget);

			dockWidget.transform.SetParent(mContentTransform, false);
			dockWidget.transform.SetSiblingIndex(index);

			if (mSelectedIndex == -1)
			{
				mSelectedIndex = index;

				dockWidget.gameObject.SetActive(true);
			}
			else
			{
				dockWidget.gameObject.SetActive(false);
			}

			//===========================================================================
			// Tab GameObject
			//===========================================================================
			#region Tab GameObject
			GameObject tab = new GameObject("Tab");
			Utils.InitUIObject(tab, mTabsTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			tab.AddComponent<RectTransform>();
			#endregion
			
			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			tab.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image tabImage = tab.AddComponent<Image>();

			tabImage.type = Image.Type.Sliced;
			#endregion

			//===========================================================================
			// DockingTabButton Component
			//===========================================================================
			#region DockingTabButton Component
			DockingTabButton tabButton = tab.AddComponent<DockingTabButton>();

			tabButton.dockWidget    = dockWidget;
			tabButton.targetGraphic = tabImage;
			tabButton.active        = (mSelectedIndex == index);
			tabButton.transition    = Selectable.Transition.None;
            #endregion
            
            //===========================================================================
			// Image GameObject
			//===========================================================================
			#region Image GameObject
			GameObject imageGameObject = new GameObject("Image");
			Utils.InitUIObject(imageGameObject, tab.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform imageTransform = imageGameObject.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopLeft(imageTransform, 12f, 12f, 9f, 3f);
			#endregion
			
			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			imageGameObject.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
            #region Image Component
			Image image = imageGameObject.AddComponent<Image>();

			image.sprite = dockWidget.image;
			image.type   = Image.Type.Sliced;
            #endregion
			#endregion

			//===========================================================================
			// Text GameObject
			//===========================================================================
			#region Text GameObject
			GameObject textObject = new GameObject("Text");
			Utils.InitUIObject(textObject, tab.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform textTransform = textObject.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(textTransform, 25f, 0f, 6f, 0f);
			#endregion
						
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text text = textObject.AddComponent<Text>();

			text.font      = Assets.Common.Fonts.microsoftSansSerif;
			text.fontSize  = 12;
			text.alignment = TextAnchor.MiddleLeft;
			text.color     = new Color(0f, 0f, 0f, 1f);
			text.text      = dockWidget.title;
			#endregion
			#endregion
			#endregion

			UpdateTabsGeometry();
		}

		/// <summary>
		/// Removes the dock widget.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		public void RemoveDockWidget(DockWidgetScript dockWidget)
		{
			if (dockWidget.parent == this)
			{
				int index = mChildren.IndexOf(dockWidget);
				
				if (index >= 0)
                {
					mChildren.RemoveAt(index);
					UnityEngine.Object.DestroyObject(mTabsTransform.GetChild(index).gameObject);

					UpdateTabsGeometry();
				}
				else
				{
					Debug.LogError("Failed to remove dock widget");
				}
			}
			else
			{
				Debug.LogError("Dock widget belongs not to this docking group");
			}
		}
	}
}