using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.EventSystems;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking area behaviour.
	/// </summary>
	public class DockingAreaScript : MonoBehaviour
	{
		private static readonly float GAP = 3f;



		/// <summary>
		/// Gets the instances.
		/// </summary>
		/// <value>The instances.</value>
		public static ReadOnlyCollection<DockingAreaScript> instances
		{
			get { return mInstances.AsReadOnly(); }
		}



		private static List<DockingAreaScript> mInstances = new List<DockingAreaScript>();



		/// <summary>
		/// Gets the orientation.
		/// </summary>
		/// <value>Orientation.</value>
		public DockingAreaOrientation orientation
		{
			get { return mOrientation; }
		}

		/// <summary>
		/// Gets the parent docking area.
		/// </summary>
		/// <value>Parent docking area.</value>
		public DockingAreaScript parent
		{
			get { return mParent; }
        }

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		public ReadOnlyCollection<DockingAreaScript> children
		{
			get { return mChildren.AsReadOnly(); }
		}

		/// <summary>
		/// Gets or sets the list of sizes.
		/// </summary>
		/// <value>List of sizes.</value>
		public IList<float> sizes
		{
			get
			{
				return mSizes.AsReadOnly();
			}

			set
			{
				if (value.Count == mChildren.Count)
				{
					if (value.Count > 0)
					{
						float total = 0f;
						
						foreach (float size in value)
						{
							if (size > 0f)
							{
								total += size;
							}
                            else
                            {
                                Debug.LogError("Incorrect size (" + size + ") in size list");
                                return;
                            }
                        }
                        
                        List<float> newSizes = new List<float>();

						foreach (float size in value)
                        {
							newSizes.Add(size / total);
						}

						mSizes = newSizes;

						OnResize();
					}
				}
				else
				if (
					value.Count == 1
					&&
					mChildren.Count == 0
					&&
					value[0] == 1f
			       )
                {
					// Nothing
				}
				else
				{
					Debug.LogError("Invalid size list argument");
				}
			}
		}

		/// <summary>
		/// Gets the docking group.
		/// </summary>
		/// <value>The docking group.</value>
		public DockingGroupScript dockingGroupScript
		{
			get { return mDockingGroupScript; }
		}



		private DockingAreaOrientation  mOrientation;
		private DockingAreaScript       mParent;
		private List<DockingAreaScript> mChildren;
		private List<float>             mSizes;
		private DockingGroupScript      mDockingGroupScript;
		private Vector3[]               mCachedDragCorners;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingAreaScript"/> class.
		/// </summary>
		public DockingAreaScript()
			: base()
		{
			mInstances.Add(this);

			mOrientation        = DockingAreaOrientation.None;
			mParent             = null;
			mChildren           = new List<DockingAreaScript>();
			mSizes              = new List<float>();
			mDockingGroupScript = null;
			mCachedDragCorners  = null;
		}

		/// <summary>
		/// Destroy this instance.
		/// </summary>
		public void Destroy()
		{
			UnityEngine.Object.DestroyObject(gameObject);

			if (mParent != null)
			{
				mParent.RemoveDockingArea(this);
			}

			if (!mInstances.Remove(this))
			{
				Debug.LogError("Failed to remove docking area");
			}
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		public void OnResize()
		{
			switch (mOrientation)
			{
				case DockingAreaOrientation.None:
				{
					// Nothing
				}
				break;

				case DockingAreaOrientation.Horizontal:
				{
					Vector3[] corners = new Vector3[4];
				    (transform as RectTransform).GetLocalCorners(corners);
					float totalWidth  = corners[2].x - corners[0].x - (mChildren.Count - 1) * GAP;
					float totalHeight = corners[2].y - corners[0].y;

					float contentWidth = 0f;

					for (int i = 0; i < mChildren.Count; ++i)
					{
						DockingAreaScript dockingArea      = mChildren[i];
						RectTransform dockingAreaTransform = dockingArea.transform as RectTransform;
	                    
						float dockingAreaWidth = totalWidth * mSizes[i];

						if (
						    dockingAreaTransform.sizeDelta.x != dockingAreaWidth
							||
							dockingAreaTransform.sizeDelta.y != totalHeight
						   )
						{
							Utils.AlignRectTransformTopLeft(dockingAreaTransform, dockingAreaWidth, totalHeight, contentWidth, 0f);
							dockingArea.OnResize();
						}
						
						contentWidth += dockingAreaWidth + GAP;
					}
            	}
                break;

				case DockingAreaOrientation.Vertical:
				{
					Vector3[] corners = new Vector3[4];
					(transform as RectTransform).GetLocalCorners(corners);
					float totalWidth  = corners[2].x - corners[0].x;
					float totalHeight = corners[2].y - corners[0].y - (mChildren.Count - 1) * GAP;
					
					float contentHeight = 0f;
					
					for (int i = 0; i < mChildren.Count; ++i)
					{
						DockingAreaScript dockingArea      = mChildren[i];
						RectTransform dockingAreaTransform = dockingArea.transform as RectTransform;
                    
						float dockingAreaHeight = totalHeight * mSizes[i];

						if (
							dockingAreaTransform.sizeDelta.x != totalWidth
							||
							dockingAreaTransform.sizeDelta.y != dockingAreaHeight
						   )
						{
							Utils.AlignRectTransformTopLeft(dockingAreaTransform, totalWidth, dockingAreaHeight, 0f, contentHeight);
							dockingArea.OnResize();
						}
						
	                    contentHeight += dockingAreaHeight + GAP;
	                }
            	}
                break;
                
            	default:
            	{
					Debug.LogError("Unknown orientation");
				}
                break;
            }

			if (mDockingGroupScript != null)
			{
				mDockingGroupScript.OnResize();
			}
		}

		/// <summary>
		/// Caches drag info.
		/// </summary>
		public void CacheDragInfo()
		{
			mCachedDragCorners = Utils.GetWindowCorners(transform as RectTransform);
		}

		/// <summary>
		/// Mouse location.
		/// </summary>
		private enum MouseLocation
		{
			/// <summary>
			/// Outside of this docking area.
			/// </summary>
			Outside
			,
			/// <summary>
			/// Inside of this docking area.
			/// </summary>
			Inside
			,
			/// <summary>
			/// The left section.
			/// </summary>
			LeftSection
			,
			/// <summary>
			/// The right section.
			/// </summary>
			RightSection
			,
			/// <summary>
			/// The bottom section.
			/// </summary>
			BottomSection
			,
			/// <summary>
			/// In tabs area of docking group.
			/// </summary>
			Tabs
		}

		/// <summary>
		/// Handler for dock widget drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void ProcessDockWidgetDrag(PointerEventData eventData)
		{
			if (mCachedDragCorners != null)
			{
				float screenHeight = Screen.height;
								
				float left   = mCachedDragCorners[0].x;
				float top    = mCachedDragCorners[0].y;
				float right  = mCachedDragCorners[3].x;
				float bottom = mCachedDragCorners[3].y;

				float width             = right  - left;
				float height            = bottom - top;
				float horizontalSection = width  / 3f;
				float verticalSection   = height / 3f;
				
				float mouseX = eventData.position.x;
				float mouseY = screenHeight - eventData.position.y;

				if (
					mouseX >= left && mouseX <= right
					&&
					mouseY >= top  && mouseY <= bottom
				   )
				{
					if (
						mChildren.Count == 0
						&& 
						(
						 mDockingGroupScript == null
						 ||
						 mDockingGroupScript.children.Count == 1
						 &&
						 mDockingGroupScript.children[0] == DummyDockWidgetScript.instance
						)
					   )
					{
						if (DragHandler.minimum > -1f)
						{
							DragHandler.minimum                = -1f;
							DragHandler.dockingArea            = this;
							DragHandler.dockingAreaOrientation = DockingAreaOrientation.None;
							DragHandler.insertIndex            = 0;

							if (mDockingGroupScript == null)
							{
								DummyDockWidgetScript.CreateAndInsert();
							}
						}
					}
					else
					{
						MouseLocation mouseLocation = MouseLocation.Inside;

						if (mouseX <= left + horizontalSection)
						{
							float value = left + horizontalSection - mouseX;

							if (value < DragHandler.minimum)
							{
								DragHandler.minimum = value;
								mouseLocation = MouseLocation.LeftSection;
							}
						}
						else
						if (mouseX >= right - horizontalSection)
						{
							float value = mouseX - (right - horizontalSection);
							
							if (value < DragHandler.minimum)
							{
								DragHandler.minimum = value;
								mouseLocation = MouseLocation.RightSection;
							}
						}

						if (mouseY <= top + 16f)
						{
							float value = top + 16f - mouseY;
							
							if (value < DragHandler.minimum)
							{
								DragHandler.minimum = value;
								mouseLocation = MouseLocation.Tabs;
							}
						}
						else
						if (mouseY >= bottom - verticalSection)
						{
							float value = mouseY - (bottom - verticalSection);
							
							if (value < DragHandler.minimum)
							{
								DragHandler.minimum = value;
								mouseLocation = MouseLocation.BottomSection;
							}
						}

						switch (mouseLocation)
						{
							case MouseLocation.LeftSection:
							{
								DragHandler.dockingAreaOrientation = DockingAreaOrientation.Horizontal;

								if (mParent != null)
								{
								}
								else
								{
									DragHandler.dockingArea = this;
									DragHandler.insertIndex = 0;

									if (
									    mDockingGroupScript != null
									    ||
									    mChildren.Count < 2
									    ||
									    mChildren[0].mDockingGroupScript == null
									    ||
									    mChildren[0].mDockingGroupScript.children.Count != 1
										||
										mChildren[0].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
									   )
									{
										DummyDockWidgetScript.CreateAndInsert();
									}
								}
							}
							break;

							case MouseLocation.RightSection:
							{
								DragHandler.dockingAreaOrientation = DockingAreaOrientation.Horizontal;
								
								if (mParent != null)
								{
								}
								else
								{
									DragHandler.dockingArea = this;
									
									if (
										mDockingGroupScript != null
										||
										mChildren.Count < 2
										||
										mChildren[mChildren.Count - 1].mDockingGroupScript == null
										||
										mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
										||
										mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
									   )
									{
										DragHandler.insertIndex = mChildren.Count;

										DummyDockWidgetScript.CreateAndInsert();
									}
									else
									{
										DragHandler.insertIndex = mChildren.Count - 1;
									}
								}
							}
							break;

							case MouseLocation.BottomSection:
							{
							}
							break;

							case MouseLocation.Tabs:
							{
							}
							break;

							case MouseLocation.Inside:
							{
								// Nothing
							}
							break;

							case MouseLocation.Outside:
							{
								Debug.LogError("Unexpected mouse location: " + mouseLocation);
							}
							break;

							default:
							{
								Debug.LogError("Unknown mouse location: " + mouseLocation);
							}
							break;
						}

						// TODO: Implement ProcessDockWidgetDrag
					}
				}
			}
		}

		/// <summary>
		/// Clears drag info.
		/// </summary>
		public void ClearDragInfo()
		{
			mCachedDragCorners = null;
		}

		/// <summary>
		/// Inserts the specified dock widget.
		/// </summary>
		/// <param name="dockWidget">Dock widget.</param>
		/// <param name="orientation">Orientation.</param>
		/// <param name="index">Index.</param>
		public void InsertDockWidget(DockWidgetScript dockWidget, DockingAreaOrientation orientation = DockingAreaOrientation.Horizontal, int index = 0)
		{
			// TODO: Change index of dock widget

			//***************************************************************************
			// DockingGroup GameObject
			//***************************************************************************
			#region DockingGroup GameObject
			GameObject dockingGroup = new GameObject("DockingGroup");
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform dockingGroupTransform = dockingGroup.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(dockingGroupTransform);
			#endregion
			
			//===========================================================================
			// DockingGroupScript Component
			//===========================================================================
			#region DockingGroupScript Component
			DockingGroupScript dockingGroupScript = dockingGroup.AddComponent<DockingGroupScript>();

			dockingGroupScript.InsertDockWidget(dockWidget);
            #endregion
            #endregion
			            
            if (mChildren.Count == 0 && mDockingGroupScript == null)
            {
                mSizes.Add(1f);

				Utils.InitUIObject(dockingGroup, transform);
				mDockingGroupScript = dockingGroupScript;
				mDockingGroupScript.parent = this;
			}
			else
			if (mChildren.Count == 0 && mDockingGroupScript != null)
			{
				mSizes[0] = 0.5f;
				mSizes.Add(0.5f);

				mOrientation = orientation;

				//***************************************************************************
				// DockingArea GameObject
				//***************************************************************************
				#region DockingArea GameObject
				GameObject dockingArea = new GameObject("DockingArea");
				Utils.InitUIObject(dockingArea, transform);
				
				//===========================================================================
				// RectTransform Component
				//===========================================================================
				#region RectTransform Component
				dockingArea.AddComponent<RectTransform>();
				#endregion
				
				//===========================================================================
				// DockingAreaScript Component
				//===========================================================================
				#region DockingAreaScript Component
				DockingAreaScript dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
				dockingAreaScript.mParent = this;
				mChildren.Add(dockingAreaScript);
				dockingAreaScript.mSizes.Add(1f);

				if (index == 0)
				{
					Utils.InitUIObject(dockingGroup, dockingArea.transform);
					dockingAreaScript.mDockingGroupScript = dockingGroupScript;
					dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;
				}
				else
				{
					Utils.InitUIObject(mDockingGroupScript.gameObject, dockingArea.transform);
					dockingAreaScript.mDockingGroupScript = mDockingGroupScript;
					dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;
				}
                #endregion
                #endregion

				//***************************************************************************
				// DockingArea GameObject
				//***************************************************************************
				#region DockingArea GameObject
				dockingArea = new GameObject("DockingArea");
				Utils.InitUIObject(dockingArea, transform);
				
				//===========================================================================
				// RectTransform Component
				//===========================================================================
				#region RectTransform Component
				dockingArea.AddComponent<RectTransform>();
				#endregion
				
				//===========================================================================
				// DockingAreaScript Component
				//===========================================================================
				#region DockingAreaScript Component
				dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
				dockingAreaScript.mParent = this;
				mChildren.Add(dockingAreaScript);
				dockingAreaScript.mSizes.Add(1f);
                
                if (index == 0)
                {
					Utils.InitUIObject(mDockingGroupScript.gameObject, dockingArea.transform);
					dockingAreaScript.mDockingGroupScript = mDockingGroupScript;
					dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;
                }
                else
                {
					Utils.InitUIObject(dockingGroup, dockingArea.transform);
					dockingAreaScript.mDockingGroupScript = dockingGroupScript;
					dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;
                }
                #endregion
                #endregion
                
                mDockingGroupScript = null;
			}
			else
			{
				if (orientation != DockingAreaOrientation.None)
				{
					if (mOrientation == orientation)
                    {
						float newSize = 1f / (mSizes.Count + 1);
						float sizeMultiplier = 1f - newSize;

						for (int i = 0; i < mSizes.Count; ++i)
						{
							mSizes[i] *= sizeMultiplier;
						}

						mSizes.Insert(index, newSize);

						//***************************************************************************
						// DockingArea GameObject
						//***************************************************************************
						#region DockingArea GameObject
						GameObject dockingArea = new GameObject("DockingArea");
						Utils.InitUIObject(dockingArea, transform);
						dockingArea.transform.SetSiblingIndex(index);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						dockingArea.AddComponent<RectTransform>();
						#endregion
						
						//===========================================================================
						// DockingAreaScript Component
						//===========================================================================
						#region DockingAreaScript Component
						DockingAreaScript dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
						dockingAreaScript.mParent = this;
						mChildren.Insert(index, dockingAreaScript);
                        dockingAreaScript.mSizes.Add(1f);
                        
						Utils.InitUIObject(dockingGroup, dockingArea.transform);
						dockingAreaScript.mDockingGroupScript = dockingGroupScript;
						dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;
						#endregion
                        #endregion
                    }
                    else
                    {
						List<DockingAreaScript> newChildren = new List<DockingAreaScript>();
						List<float>             newSizes    = new List<float>();

						newSizes.Add(0.5f);
						newSizes.Add(0.5f);
						
						//***************************************************************************
						// DockingArea GameObject
						//***************************************************************************
						#region DockingArea GameObject
						GameObject dockingArea = new GameObject("DockingArea");
						Utils.InitUIObject(dockingArea, transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						dockingArea.AddComponent<RectTransform>();
						#endregion
						
						//===========================================================================
						// DockingAreaScript Component
						//===========================================================================
						#region DockingAreaScript Component
						DockingAreaScript dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
						dockingAreaScript.mParent = this;
						newChildren.Add(dockingAreaScript);
                        
                        if (index == 0)
                        {
							Utils.InitUIObject(dockingGroup, dockingArea.transform);
                            dockingAreaScript.mDockingGroupScript = dockingGroupScript;
							dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;
                            
							dockingAreaScript.mSizes.Add(1f);
                        }
                        else
                        {
							foreach (DockingAreaScript child in mChildren)
							{
								child.mParent = dockingAreaScript;
								child.transform.SetParent(dockingArea.transform, false);
							}

							dockingAreaScript.mOrientation = mOrientation;
							dockingAreaScript.mChildren    = mChildren;
							dockingAreaScript.mSizes       = mSizes;
						}
						#endregion
						#endregion

						//***************************************************************************
						// DockingArea GameObject
						//***************************************************************************
						#region DockingArea GameObject
						dockingArea = new GameObject("DockingArea");
						Utils.InitUIObject(dockingArea, transform);
						
						//===========================================================================
						// RectTransform Component
						//===========================================================================
						#region RectTransform Component
						dockingArea.AddComponent<RectTransform>();
						#endregion
						
						//===========================================================================
						// DockingAreaScript Component
						//===========================================================================
						#region DockingAreaScript Component
						dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
						dockingAreaScript.mParent = this;
						newChildren.Add(dockingAreaScript);
						
						if (index == 0)
						{
							foreach (DockingAreaScript child in mChildren)
							{
								child.mParent = dockingAreaScript;
								child.transform.SetParent(dockingArea.transform, false);
							}

							dockingAreaScript.mOrientation = mOrientation;
							dockingAreaScript.mChildren    = mChildren;
							dockingAreaScript.mSizes       = mSizes;
                        }
                        else
                        {
							Utils.InitUIObject(dockingGroup, dockingArea.transform);
                            dockingAreaScript.mDockingGroupScript = dockingGroupScript;
							dockingAreaScript.mDockingGroupScript.parent = dockingAreaScript;                            
							
                            dockingAreaScript.mSizes.Add(1f);
                        }
                        #endregion
                        #endregion

						mOrientation = orientation;
                        
                        mChildren = newChildren;
                        mSizes    = newSizes;
                    }
				}
				else
				{
					Debug.LogError("Invalid orientation value");
				}
			}

			OnResize();
        }

		/// <summary>
		/// Removes the docking group.
		/// </summary>
		/// <param name="dockingGroup">Docking group.</param>
		public void RemoveDockingGroup(DockingGroupScript dockingGroup)
		{
			if (mDockingGroupScript == dockingGroup)
			{
				if (mParent != null)
				{
					Destroy();
				}
				else
				{
					mDockingGroupScript = null;
				}
			}
			else
			{
				Debug.LogError("Failed to remove docking group");
			}
		}

		/// <summary>
		/// Removes the docking area.
		/// </summary>
		/// <param name="dockingArea">Docking area.</param>
		public void RemoveDockingArea(DockingAreaScript dockingArea)
		{
			if (dockingArea.parent == this)
			{
				int index = mChildren.IndexOf(dockingArea);
				
				if (index >= 0)
				{
					mChildren.RemoveAt(index);

					if (mChildren.Count == 1)
					{
						dockingArea = mChildren[0];

						mOrientation        = dockingArea.mOrientation;
						mChildren           = dockingArea.mChildren;
						mSizes              = dockingArea.mSizes;
						mDockingGroupScript = dockingArea.mDockingGroupScript;

						if (mDockingGroupScript != null)
						{
							mDockingGroupScript.parent = this;
							mDockingGroupScript.transform.SetParent(transform, false);
						}
						else
						{
							foreach (DockingAreaScript child in mChildren)
							{
								child.mParent = this;
								child.transform.SetParent(transform, false);
							}
						}

						UnityEngine.Object.DestroyObject(dockingArea.gameObject);
					}

					OnResize();
				}
				else
				{
					Debug.LogError("Failed to remove docking area");
				}
			}			
			else
			{
				Debug.LogError("Docking area belongs not to this docking area");
			}
		}
    }
}
