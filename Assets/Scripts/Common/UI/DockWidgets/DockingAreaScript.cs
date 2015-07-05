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
					mDockingGroupScript != null
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
		/// Preprocessor for dock widget drag event.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public void PreprocessDockWidgetDrag(PointerEventData eventData)
		{
			if (mCachedDragCorners != null)
			{
				float screenHeight = Screen.height;
				
				float left   = mCachedDragCorners[0].x - 2f;
				float top    = mCachedDragCorners[0].y - 2f;
				float right  = mCachedDragCorners[3].x + 2f;
				float bottom = mCachedDragCorners[3].y + 2f;
				
				float horizontalSection = (right  - left) / 3f;
				float verticalSection   = (bottom - top)  / 3f;
				
				float mouseX = eventData.position.x;
				float mouseY = screenHeight - eventData.position.y;

				#region Get mouse location
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
						if (DragInfoHolder.minimum > -1f)
						{
							DragInfoHolder.minimum       = -1f;
							DragInfoHolder.dockingArea   = this;
							DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.Inside;
						}
					}
					else
					{
						if (mouseY <= top + 18f)
						{
							float value = mouseY - top;
							
							if (value < DragInfoHolder.minimum)
							{
								DragInfoHolder.minimum       = value;
								DragInfoHolder.dockingArea   = this;
								DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.Tabs;
							}
						}
						else
						if (mouseY >= bottom - verticalSection)
						{
							float value = bottom - mouseY;
							
							if (value < DragInfoHolder.minimum)
							{
								DragInfoHolder.minimum       = value;
								DragInfoHolder.dockingArea   = this;
								DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.BottomSection;
							}
						}
						
						if (DragInfoHolder.mouseLocation != DragInfoHolder.MouseLocation.Tabs)
						{
							if (mouseX <= left + horizontalSection)
							{
								float value = mouseX - left;
								
								if (value < DragInfoHolder.minimum)
								{
									DragInfoHolder.minimum       = value;
									DragInfoHolder.dockingArea   = this;
									DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.LeftSection;
								}
							}
							else
							if (mouseX >= right - horizontalSection)
							{
								float value = right - mouseX;
								
								if (value < DragInfoHolder.minimum)
								{
									DragInfoHolder.minimum       = value;
									DragInfoHolder.dockingArea   = this;
									DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.RightSection;
								}
							}
						}
					}
				}
				#endregion
			}
			else
			{
				Debug.LogError("Unexpected behaviour in DockingAreaScript.PreprocessDockWidgetDrag");
			}
		}

		/// <summary>
		/// Handler for dock widget drag event.
		/// </summary>
		public void ProcessDockWidgetDrag()
		{
			DragInfoHolder.dockingArea = null;

			switch (DragInfoHolder.mouseLocation)
            {
				case DragInfoHolder.MouseLocation.Inside:
				{
					DragInfoHolder.dockingArea = this;
					
					if (mDockingGroupScript == null)
					{
	                    DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
							InsertToDockingArea(this, DockingAreaOrientation.None, 0);
	                }
            	}
                break;

				case DragInfoHolder.MouseLocation.LeftSection:
				{					
					if (
						DummyDockWidgetScript.instance != null
						&&
						DummyDockWidgetScript.instance.parent.parent.mOrientation == DockingAreaOrientation.Vertical
					   )
					{
						DummyDockWidgetScript.instance.parent.RemoveDockWidget(DummyDockWidgetScript.instance);
					}
					
					if (mParent != null)
					{
						if (mParent.mOrientation == DockingAreaOrientation.Vertical)
						{
							DragInfoHolder.dockingArea = this;
							
							if (mDockingGroupScript != null)
							{
								if (
									mDockingGroupScript.children.Count != 1
									||
									mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								   )
								{
									DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
										InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 0);
								}
							}
							else
							if (
								mOrientation == DockingAreaOrientation.Vertical
								||
								mChildren[0].mDockingGroupScript.children.Count != 1
								||
								mChildren[0].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								&&
								mChildren[0].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
							   )
							{
								DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
									InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 0);
							}
						}
						else
						{
							DragInfoHolder.dockingArea = mParent;

							if (
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								int index = mParent.mChildren.IndexOf(this);
													
								if (index >= 0)
								{
									int index2 = -1;

									if (
										DummyDockWidgetScript.instance != null
										&&
										DummyDockWidgetScript.instance.parent.children.Count == 1
										&&
										DummyDockWidgetScript.instance.parent.parent != null
								    	&&
										DummyDockWidgetScript.instance.parent.parent.parent == mParent
								       )
									{
										index2 = mParent.mChildren.IndexOf(DummyDockWidgetScript.instance.parent.parent);
									}

									if (
										index2 < 0
										||
										index2 != index - 1
									   )
									{
										if (index2 >= 0 && index > index2)
										{
											--index;
										}

										DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
											InsertToDockingArea(mParent, DockingAreaOrientation.Horizontal, index);
									}
								}
								else
								{
									Debug.LogError("Unexpected behaviour in DockingAreaScript.ProcessDockWidgetDrag");
								}
							}
						}						
					}
					else
					{
						DragInfoHolder.dockingArea = this;
						
						if (mDockingGroupScript != null)
						{
							if (
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
									InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 0);
							}
						}
						else
						if (
							mOrientation == DockingAreaOrientation.Vertical
							||
							mChildren[0].mDockingGroupScript.children.Count != 1
							||
						    mChildren[0].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							&&
							mChildren[0].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						   )
						{
							DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
								InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 0);
                    	}
					}
				}
				break;
				
				case DragInfoHolder.MouseLocation.RightSection:
				{					
					if (
						DummyDockWidgetScript.instance != null
						&&
						DummyDockWidgetScript.instance.parent.parent.mOrientation == DockingAreaOrientation.Vertical
					   )
					{
						DummyDockWidgetScript.instance.parent.RemoveDockWidget(DummyDockWidgetScript.instance);
					}
					
					if (mParent != null)
					{
						if (mParent.mOrientation == DockingAreaOrientation.Vertical)
						{
							DragInfoHolder.dockingArea = this;
							
							if (mDockingGroupScript != null)
							{
								if (
									mDockingGroupScript.children.Count != 1
									||
									mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								   )
								{
									DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
										InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 1);
								}
							}
							else
							if (
								mOrientation == DockingAreaOrientation.Vertical
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								&&
								mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						       )
							{
								DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
									InsertToDockingArea(this, DockingAreaOrientation.Horizontal, mChildren.Count);
							}
						}
						else
						{
							DragInfoHolder.dockingArea = mParent;
							
							if (
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								)
							{
								int index = mParent.mChildren.IndexOf(this);
								
								if (index >= 0)
								{
									int index2 = -1;
									
									if (
										DummyDockWidgetScript.instance != null
										&&
										DummyDockWidgetScript.instance.parent.children.Count == 1
										&&
										DummyDockWidgetScript.instance.parent.parent != null
										&&
										DummyDockWidgetScript.instance.parent.parent.parent == mParent
									   )
									{
										index2 = mParent.mChildren.IndexOf(DummyDockWidgetScript.instance.parent.parent);
									}
									
									if (
										index2 < 0
										||
										index2 != index + 1
									   )
									{
										if (index2 >= 0 && index > index2)
										{
											--index;
										}
										
										DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
											InsertToDockingArea(mParent, DockingAreaOrientation.Horizontal, index);
									}
								}
								else
								{
									Debug.LogError("Unexpected behaviour in DockingAreaScript.ProcessDockWidgetDrag");
								}
							}
						}
                	}
                	else
                	{
                    	DragInfoHolder.dockingArea = this;
                    
                    	if (mDockingGroupScript != null)
						{
							if (
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
                            	DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
                                	InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 1);
                        	}
						}
						else
						if (
							mOrientation == DockingAreaOrientation.Vertical
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							&&
							mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						   )
						{
							DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
								InsertToDockingArea(this, DockingAreaOrientation.Horizontal, mChildren.Count);
						}
					}
				}
				break;
				
				case DragInfoHolder.MouseLocation.BottomSection:
				{					
					if (
						DummyDockWidgetScript.instance != null
						&&
						DummyDockWidgetScript.instance.parent.parent.mOrientation == DockingAreaOrientation.Horizontal
					   )
					{
						DummyDockWidgetScript.instance.parent.RemoveDockWidget(DummyDockWidgetScript.instance);
					}
					
					if (mParent != null)
					{
					}
					else
					{
						DragInfoHolder.dockingArea = this;
						
						if (mDockingGroupScript != null)
						{
							if (
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
									InsertToDockingArea(this, DockingAreaOrientation.Vertical, 1);
                        	}
						}
						else
						if (
							mOrientation == DockingAreaOrientation.Horizontal
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							&&
							mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						   )
						{
							DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
								InsertToDockingArea(this, DockingAreaOrientation.Vertical, mChildren.Count);
						}
	                }
	            }
                break;
                
				case DragInfoHolder.MouseLocation.Tabs:
	            {
				 	// TODO: Implement
	            }
                break;
                
				case DragInfoHolder.MouseLocation.Outside:
	            {
					Debug.LogError("Unexpected mouse location: " + DragInfoHolder.mouseLocation);
	            }
                break;
                
	            default:
	            {
	                Debug.LogError("Unknown mouse location: " + DragInfoHolder.mouseLocation);
	            }
                break;
            }
            
            // TODO: Implement ProcessDockWidgetDrag            
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
					mSizes.Clear();
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
					float size = mSizes[index];

					mChildren.RemoveAt(index);
					mSizes.RemoveAt(index);

					if (size < 1f)
					{
						float sizeMultiplier = 1 / (1f - size);

						for (int i = 0; i < mSizes.Count; ++i)
						{
							mSizes[i] *= sizeMultiplier;
						}
					}
					else
					{
						if (mSizes.Count > 0)
						{
							float newSize = 1f / mSizes.Count;
							
							for (int i = 0; i < mSizes.Count; ++i)
							{
								mSizes[i] = newSize;
							}
						}
					}

					if (mChildren.Count == 1)
					{
						dockingArea = mChildren[0];

						DockingAreaOrientation  orientation        = dockingArea.mOrientation;
						List<DockingAreaScript> children           = dockingArea.mChildren;
						List<float>             sizes              = dockingArea.mSizes;
						DockingGroupScript      dockingGroupScript = dockingArea.mDockingGroupScript;

						if (dockingGroupScript != null)
						{
							dockingGroupScript.parent = this;
							dockingGroupScript.transform.SetParent(transform, false);
						}
						else
						{
							foreach (DockingAreaScript child in children)
							{
								child.mParent = this;
								child.transform.SetParent(transform, false);
							}
						}

						dockingArea.Destroy();

						mOrientation        = orientation;
						mChildren           = children;
						mSizes              = sizes;
						mDockingGroupScript = dockingGroupScript;
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
