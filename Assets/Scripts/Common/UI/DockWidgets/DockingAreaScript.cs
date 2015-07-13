using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking area behaviour.
	/// </summary>
	public class DockingAreaScript : MonoBehaviour
	{		
		/// <summary>
		/// Mouse location.
		/// </summary>
		private enum MouseLocation
		{
			  Outside
			, North
			, South
			, West
			, East
			, Inside
		}
		
		/// <summary>
		/// Mouse state.
		/// </summary>
		private enum MouseState
		{
			  NoState
			, Resizing
		}



		private const float GAP          = 3f;
		private const float MINIMUM_SIZE = 0.1f;



		/// <summary>
		/// Gets the instances.
		/// </summary>
		/// <value>The instances.</value>
		public static ReadOnlyCollection<DockingAreaScript> instances
		{
			get { return sInstances.AsReadOnly(); }
		}



		private static List<DockingAreaScript> sInstances = new List<DockingAreaScript>();

		private static int                     sLastUpdate            = -1;
		private static DockingAreaScript       sResizingArea          = null;
		private static MouseLocation           sPreviousMouseLocation = MouseLocation.Outside;
		private static MouseLocation           sMouseLocation         = MouseLocation.Outside;
		private static MouseState              sMouseState            = MouseState.NoState;



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
							float newSize = size / total;

							if (newSize < MINIMUM_SIZE)
							{
								Debug.LogError("New size " + newSize + " is less than minimum value: " + MINIMUM_SIZE);
								return;
							}

							newSizes.Add(newSize);
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
					string listStr = "";

					for (int i = 0; i < value.Count; ++i)
					{
						if (i > 0)
						{
							listStr += " ";
						}

						listStr += value[i];
					}

					Debug.LogError("Invalid size list argument: [" + listStr + "]");
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
		private UnityEvent              mChildlessListeners;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingAreaScript"/> class.
		/// </summary>
		public DockingAreaScript()
			: base()
		{
			sInstances.Add(this);

			mOrientation        = DockingAreaOrientation.None;
			mParent             = null;
			mChildren           = new List<DockingAreaScript>();
			mSizes              = new List<float>();
			mDockingGroupScript = null;
			mCachedDragCorners  = null;
			mChildlessListeners = new UnityEvent();
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
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (sResizingArea == this)
			{
				RemoveCursorIfNeeded();

				sResizingArea          = null;
				sPreviousMouseLocation = MouseLocation.Outside;
				sMouseLocation         = MouseLocation.Outside;
				sMouseState            = MouseState.NoState;
			}

			if (!sInstances.Remove(this))
			{
				Debug.LogError("Failed to remove docking area");
			}
		}

		/// <summary>
		/// Removes the cursor if needed.
		/// </summary>
		private void RemoveCursorIfNeeded()
		{
			if (
				sMouseLocation == MouseLocation.North
				||
				sMouseLocation == MouseLocation.South
				||
				sMouseLocation == MouseLocation.West
				||
				sMouseLocation == MouseLocation.East
			   )
			{
				RemoveCursor();
			}
		}
		
		/// <summary>
		/// Removes the cursor.
		/// </summary>
		private void RemoveCursor()
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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

						bool sizeChanged = (
											dockingAreaTransform.sizeDelta.x != dockingAreaWidth
											||
											dockingAreaTransform.sizeDelta.y != totalHeight
										   );

						Utils.AlignRectTransformTopLeft(dockingAreaTransform, dockingAreaWidth, totalHeight, contentWidth, 0f);

						if (sizeChanged)
						{							
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

						bool sizeChanged = (
											dockingAreaTransform.sizeDelta.x != totalWidth
											||
											dockingAreaTransform.sizeDelta.y != dockingAreaHeight
										   );

						Utils.AlignRectTransformTopLeft(dockingAreaTransform, totalWidth, dockingAreaHeight, 0f, contentHeight);

						if (sizeChanged)
						{
							dockingArea.OnResize();
						}
						
	                    contentHeight += dockingAreaHeight + GAP;
	                }
            	}
                break;
                
            	default:
            	{
					Debug.LogError("Unknown orientation: " + mOrientation);
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
		/// Determines whether this instance has drag info.
		/// </summary>
		/// <returns><c>true</c> if this instance has drag info; otherwise, <c>false</c>.</returns>
		public bool HasDragInfo()
		{
			return mCachedDragCorners != null;
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

				float gap    = GAP / 2f + 1f;
				float left   = mCachedDragCorners[0].x - gap;
				float top    = mCachedDragCorners[0].y - gap;
				float right  = mCachedDragCorners[3].x + gap;
				float bottom = mCachedDragCorners[3].y + gap;
				
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
						float value;

						if (mDockingGroupScript != null)
						{
							value = mouseY - top;

							if (value < DragInfoHolder.minimum)
							{
								DragInfoHolder.minimum = value;

								if (value <= gap + 16f)
								{
									DragInfoHolder.dockingArea   = this;
									DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.Tabs;
								}
							}
						}

						value = bottom - mouseY;

						if (value < DragInfoHolder.minimum)
						{
							DragInfoHolder.minimum = value;
							
							if (value <= verticalSection)
							{
								DragInfoHolder.dockingArea   = this;
								DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.BottomSection;
							}
						}

						if (DragInfoHolder.mouseLocation != DragInfoHolder.MouseLocation.Tabs)
						{
							value = mouseX - left;
							
							if (value < DragInfoHolder.minimum)
							{
								DragInfoHolder.minimum = value;
								
								if (value <= horizontalSection)
								{
									DragInfoHolder.dockingArea   = this;
									DragInfoHolder.mouseLocation = DragInfoHolder.MouseLocation.LeftSection;
								}
							}

							value = right - mouseX;
							
							if (value < DragInfoHolder.minimum)
							{
								DragInfoHolder.minimum = value;
								
								if (value <= horizontalSection)
								{
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
		/// <param name="eventData">Pointer data.</param>
		public void ProcessDockWidgetDrag(PointerEventData eventData)
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
							InsertToDockingArea(this);
	                }
            	}
                break;

				case DragInfoHolder.MouseLocation.LeftSection:
				{
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
								else
								{
									DummyDockWidgetScript.DestroyInstance();
								}
							}
							else
							if (
								mOrientation == DockingAreaOrientation.Vertical
								||
								mChildren[0].mDockingGroupScript == null
								||
								mChildren[0].mDockingGroupScript.children.Count != 1
								||
								mChildren[0].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
							   )
							{
								if (
									mOrientation == DockingAreaOrientation.Vertical
									||
									mChildren[0].mDockingGroupScript == null
									||
									mChildren[0].mDockingGroupScript.children.Count != 1
									||
									mChildren[0].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								   )
								{
									DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
										InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 0);
								}
								else
								{
									DummyDockWidgetScript.DestroyInstance();
								}
							}
						}
						else
						{
							DragInfoHolder.dockingArea = mParent;

							if (
								mDockingGroupScript == null
								||
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								int index = mParent.mChildren.IndexOf(this);
													
								if (index >= 0)
								{
									if (
									    index == 0
									    ||
										mParent.mChildren[index - 1].mDockingGroupScript == null
										||
										mParent.mChildren[index - 1].mDockingGroupScript.children.Count != 1
										||
										mParent.mChildren[index - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
									   )
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
										DummyDockWidgetScript.DestroyInstance();
									}
								}
								else
								{
									Debug.LogError("Unexpected behaviour in DockingAreaScript.ProcessDockWidgetDrag");
								}
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
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
							else
							{
								DummyDockWidgetScript.DestroyInstance();
							}
						}
						else
						if (
							mOrientation == DockingAreaOrientation.Vertical
							||
							mChildren[0].mDockingGroupScript == null
							||
							mChildren[0].mDockingGroupScript.children.Count != 1
							||
							mChildren[0].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						   )
						{
							if (
								mOrientation == DockingAreaOrientation.Vertical
								||
								mChildren[0].mDockingGroupScript == null
								||
								mChildren[0].mDockingGroupScript.children.Count != 1
								||
								mChildren[0].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								DummyDockWidgetScript.Create(DragInfoHolder.dockWidget).
									InsertToDockingArea(this, DockingAreaOrientation.Horizontal, 0);
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
							}
						}
					}
				}
				break;

				case DragInfoHolder.MouseLocation.RightSection:
				{					
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
								else
								{
									DummyDockWidgetScript.DestroyInstance();
								}
							}
							else
							if (
								mOrientation == DockingAreaOrientation.Vertical
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript == null
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
							   )
							{
								if (
									mOrientation == DockingAreaOrientation.Vertical
									||
									mChildren[mChildren.Count - 1].mDockingGroupScript == null
									||
									mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
									||
									mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								   )
								{
									int index = mChildren.Count - 1;
									
									int index2 = -1;
									
									if (
										DummyDockWidgetScript.instance != null
										&&
										DummyDockWidgetScript.instance.parent.children.Count == 1
										&&
										DummyDockWidgetScript.instance.parent.parent != null
										&&
										DummyDockWidgetScript.instance.parent.parent.parent == this
								       )
									{
										index2 = mChildren.IndexOf(DummyDockWidgetScript.instance.parent.parent);
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
											InsertToDockingArea(this, DockingAreaOrientation.Horizontal, index + 1);
									}
								}
								else
								{
									DummyDockWidgetScript.DestroyInstance();
								}
							}
						}
						else
						{
							DragInfoHolder.dockingArea = mParent;
							
							if (
								mDockingGroupScript == null
								||
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								int index = mParent.mChildren.IndexOf(this);
								
								if (index >= 0)
								{
									if (
										index == mParent.mChildren.Count - 1
										||
										mParent.mChildren[index + 1].mDockingGroupScript == null
										||
										mParent.mChildren[index + 1].mDockingGroupScript.children.Count != 1
										||
										mParent.mChildren[index + 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
									   )
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
												InsertToDockingArea(mParent, DockingAreaOrientation.Horizontal, index + 1);
										}
									}
									else
									{
										DummyDockWidgetScript.DestroyInstance();
									}
								}
								else
								{
									Debug.LogError("Unexpected behaviour in DockingAreaScript.ProcessDockWidgetDrag");
								}
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
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
							else
							{
								DummyDockWidgetScript.DestroyInstance();
							}
						}
						else
						if (
							mOrientation == DockingAreaOrientation.Vertical
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript == null
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						   )
						{
							if (
								mOrientation == DockingAreaOrientation.Vertical
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript == null
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								int index = mChildren.Count - 1;

								int index2 = -1;
								
								if (
									DummyDockWidgetScript.instance != null
									&&
									DummyDockWidgetScript.instance.parent.children.Count == 1
									&&
									DummyDockWidgetScript.instance.parent.parent != null
									&&
									DummyDockWidgetScript.instance.parent.parent.parent == this
								   )
								{
									index2 = mChildren.IndexOf(DummyDockWidgetScript.instance.parent.parent);
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
										InsertToDockingArea(this, DockingAreaOrientation.Horizontal, index + 1);
								}
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
							}
						}
					}
				}
				break;
				
				case DragInfoHolder.MouseLocation.BottomSection:
				{					
					if (mParent != null)
					{
						if (mParent.mOrientation == DockingAreaOrientation.Horizontal)
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
								else
								{
									DummyDockWidgetScript.DestroyInstance();
								}
							}
							else
							if (
								mOrientation == DockingAreaOrientation.Horizontal
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript == null
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
							   )
							{
								if (
									mOrientation == DockingAreaOrientation.Horizontal
									||
									mChildren[mChildren.Count - 1].mDockingGroupScript == null
									||
									mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
									||
									mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
								   )
								{
									int index = mChildren.Count - 1;
									
									int index2 = -1;
									
									if (
										DummyDockWidgetScript.instance != null
										&&
										DummyDockWidgetScript.instance.parent.children.Count == 1
										&&
										DummyDockWidgetScript.instance.parent.parent != null
										&&
										DummyDockWidgetScript.instance.parent.parent.parent == this
									   )
									{
										index2 = mChildren.IndexOf(DummyDockWidgetScript.instance.parent.parent);
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
											InsertToDockingArea(this, DockingAreaOrientation.Vertical, index + 1);
									}
								}
								else
								{
									DummyDockWidgetScript.DestroyInstance();
								}
							}
						}
						else
						{
							DragInfoHolder.dockingArea = mParent;
							
							if (
								mDockingGroupScript == null
								||
								mDockingGroupScript.children.Count != 1
								||
								mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								int index = mParent.mChildren.IndexOf(this);
								
								if (index >= 0)
								{
									if (
										index == mParent.mChildren.Count - 1
										||
										mParent.mChildren[index + 1].mDockingGroupScript == null
										||
										mParent.mChildren[index + 1].mDockingGroupScript.children.Count != 1
										||
										mParent.mChildren[index + 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
									   )
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
												InsertToDockingArea(mParent, DockingAreaOrientation.Vertical, index + 1);
										}
									}
									else
									{
										DummyDockWidgetScript.DestroyInstance();
									}
								}
								else
								{
									Debug.LogError("Unexpected behaviour in DockingAreaScript.ProcessDockWidgetDrag");
								}
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
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
									InsertToDockingArea(this, DockingAreaOrientation.Vertical, 1);
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
							}
						}
						else
						if (
							mOrientation == DockingAreaOrientation.Horizontal
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript == null
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
							||
							mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DummyDockWidgetScript.instance
						   )
						{
							if (
								mOrientation == DockingAreaOrientation.Horizontal
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript == null
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children.Count != 1
								||
								mChildren[mChildren.Count - 1].mDockingGroupScript.children[0] != DragInfoHolder.dockWidget
							   )
							{
								int index = mChildren.Count - 1;
								
								int index2 = -1;
								
								if (
									DummyDockWidgetScript.instance != null
									&&
									DummyDockWidgetScript.instance.parent.children.Count == 1
									&&
									DummyDockWidgetScript.instance.parent.parent != null
									&&
									DummyDockWidgetScript.instance.parent.parent.parent == this
								   )
								{
									index2 = mChildren.IndexOf(DummyDockWidgetScript.instance.parent.parent);
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
										InsertToDockingArea(this, DockingAreaOrientation.Vertical, index + 1);
								}
							}
							else
							{
								DummyDockWidgetScript.DestroyInstance();
							}
						}
					}
	            }
                break;
                
				case DragInfoHolder.MouseLocation.Tabs:
	            {
					mDockingGroupScript.ProcessDockWidgetDrag(eventData, mCachedDragCorners);
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
        }
        
        /// <summary>
        /// Clears drag info.
        /// </summary>
        public void ClearDragInfo()
        {
            mCachedDragCorners = null;
        }
        
		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			if (
				mParent != null
				&&
				mCachedDragCorners == null
			   )
			{
				switch (sMouseState)
				{
					case MouseState.NoState:
					{
						if (sLastUpdate != Time.frameCount)
						{
							sLastUpdate = Time.frameCount;
							
							sResizingArea  = null;
							sMouseLocation = MouseLocation.Outside;
						}

						if (sResizingArea == null)
						{
							Vector3[] corners = Utils.GetWindowCorners(transform as RectTransform);
							
							float left   = corners[0].x - GAP;
							float top    = corners[0].y - GAP;
							float right  = corners[3].x + GAP;
							float bottom = corners[3].y + GAP;
							
							float mouseX = Mouse.x;
							float mouseY = Mouse.y;

							if (
							    mouseX >= left && mouseX <= right
								&&
								mouseY >= top  && mouseY <= bottom
						       )
							{
								if (mouseY <= top + GAP)
								{
									if (
										mParent.mOrientation == DockingAreaOrientation.Vertical
										&&
										mParent.mChildren.Count > 1
										&&
										mParent.mChildren[0] != this
									   )
									{
										sResizingArea  = this;
										sMouseLocation = MouseLocation.North;
									}
								}
								else
								if (mouseY >= bottom - GAP)
								{
									if (
										mParent.mOrientation == DockingAreaOrientation.Vertical
										&&
										mParent.mChildren.Count > 1
										&&
										mParent.mChildren[mParent.mChildren.Count - 1] != this
									   )
									{
										sResizingArea  = this;
										sMouseLocation = MouseLocation.South;
									}
								}
								else
								{
									if (mouseX <= left + GAP)
									{
										if (
											mParent.mOrientation == DockingAreaOrientation.Horizontal
											&&
											mParent.mChildren.Count > 1
											&&
											mParent.mChildren[0] != this
										   )
										{
											sResizingArea  = this;
											sMouseLocation = MouseLocation.West;
										}
									}
									else
									if (mouseX >= right - GAP)
									{
										if (
											mParent.mOrientation == DockingAreaOrientation.Horizontal
											&&
											mParent.mChildren.Count > 1
											&&
											mParent.mChildren[mParent.mChildren.Count - 1] != this
										   )
										{
											sResizingArea  = this;
											sMouseLocation = MouseLocation.East;
										}
									}
									else
									{
										sMouseLocation = MouseLocation.Inside;
									}
								}
							}
						}
					}
					break;

					case MouseState.Resizing:
					{
						if (sResizingArea == this)
						{
							if (
								mParent != null
								&&
								mParent.mChildren.Count > 1
							   )
							{
								int index = mParent.mChildren.IndexOf(this);

								if (index >= 0)
								{
									MouseLocation usedLocation = sMouseLocation;

									float mouseX = Mouse.x;
									float mouseY = Mouse.y;

									float oldWidth  = 0f;
									float oldHeight = 0f;
									float newWidth  = 0f;									
								    float newHeight = 0f;

									float oldSize = 0f;
									float newSize = 0f;

									for (int attempt = 1; attempt <= 2; ++attempt)
									{
										Vector3[] corners = Utils.GetWindowCorners(mParent.mChildren[index].transform as RectTransform);
										
										float left   = corners[0].x;
										float top    = corners[0].y;
										float right  = corners[3].x;
										float bottom = corners[3].y;

										oldWidth  = right  - left;
										oldHeight = bottom - top;
										newWidth  = oldWidth;
										newHeight = oldHeight;
										
										oldSize = mParent.mSizes[index];
										newSize = oldSize;

										switch (usedLocation)
										{
											case MouseLocation.North:
											{
												newHeight = bottom - mouseY;

												newSize = newHeight / oldHeight * oldSize;
											}
											break;
											
											case MouseLocation.South:
											{
												newHeight = mouseY - top;

												newSize = newHeight / oldHeight * oldSize;
											}
											break;
											
											case MouseLocation.West:
											{
												newWidth = right - mouseX;

												newSize = newWidth / oldWidth * oldSize;
											}
											break;
											
											case MouseLocation.East:
											{
												newWidth = mouseX - left;

												newSize = newWidth / oldWidth * oldSize;
											}
											break;
											
											case MouseLocation.Inside:
											case MouseLocation.Outside:
											{
												Debug.LogError("Incorrect mouse location: " + usedLocation);
											}
											break;
											
											default:
											{
												Debug.LogError("Unknown mouse location: " + usedLocation);
											}
											break;
										}

										if (
											newWidth  >= oldWidth  - 0.1f
											&&
											newHeight >= oldHeight - 0.1f
										   )
										{
											break;
										}

										if (attempt == 2)
										{
											Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
											return;
										}

										switch (usedLocation)
										{
											case MouseLocation.North:
											{
												usedLocation = MouseLocation.South;

												if (index > 0)
												{
													--index;
												}
												else
												{
													Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
													return;
												}
											}
											break;
											
											case MouseLocation.South:
											{
												usedLocation = MouseLocation.North;

												if (index < mParent.mChildren.Count - 1)
												{
													++index;
												}
												else
												{
													Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
													return;
												}
											}
											break;
											
											case MouseLocation.West:
											{
												usedLocation = MouseLocation.East;

												if (index > 0)
												{
													--index;
												}
												else
												{
													Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
													return;
												}
											}
											break;
											
											case MouseLocation.East:
											{
												usedLocation = MouseLocation.West;

												if (index < mParent.mChildren.Count - 1)
												{
													++index;
												}
												else
												{
													Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
													return;
												}
											}
											break;
											
											case MouseLocation.Inside:
											case MouseLocation.Outside:
											{
												Debug.LogError("Incorrect mouse location: " + usedLocation);
											}
											break;
											
											default:
											{
												Debug.LogError("Unknown mouse location: " + usedLocation);
											}
											break;
										}
									}

									if (
										newWidth  > oldWidth  - 0.1f
										||
										newHeight > oldHeight - 0.1f
									   )
									{
										float delta = newSize - oldSize;

										switch (usedLocation)
										{
											case MouseLocation.North:
											case MouseLocation.West:
											{
												for (int i = index - 1; i >= 0; --i)
												{
													float nextSize = mParent.mSizes[i] - delta;

													if (nextSize < MINIMUM_SIZE)
													{
														nextSize = MINIMUM_SIZE;
													}

													float localDelta  = mParent.mSizes[i] - nextSize;
													mParent.mSizes[i] = nextSize;

													delta -= localDelta;

													if (delta == 0f)
													{
														break;
													}
												}

												newSize -= delta;
											}
											break;
											
											case MouseLocation.South:
											case MouseLocation.East:
											{
												for (int i = index + 1; i < mParent.mChildren.Count; ++i)
												{
													float nextSize = mParent.mSizes[i] - delta;
													
													if (nextSize < MINIMUM_SIZE)
													{
														nextSize = MINIMUM_SIZE;
													}
													
													float localDelta  = mParent.mSizes[i] - nextSize;
													mParent.mSizes[i] = nextSize;
													
													delta -= localDelta;
													
													if (delta == 0f)
													{
														break;
													}
												}
												
												newSize -= delta;
											}
											break;										
											
											case MouseLocation.Inside:
											case MouseLocation.Outside:
											{
												Debug.LogError("Incorrect mouse location: " + usedLocation);
											}
											break;
											
											default:
											{
												Debug.LogError("Unknown mouse location: " + usedLocation);
											}
											break;
										}

										mParent.mSizes[index] = newSize;
										mParent.OnResize();
									}
									
									if (InputControl.GetMouseButtonUp(MouseButton.Left))
									{
										sMouseState = MouseState.NoState;
									}
								}
								else
								{
									Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
								}
							}
							else
							{
								Debug.LogError("Unexpected behaviour in DockingAreaScript.Update");
							}
						}
					}
					break;

					default:
					{
						Debug.LogError("Unknown mouse state: " + sMouseState);
					}
					break;
				}
			}
		}

		/// <summary>
		/// LateUpdate is called once per frame after all Updates.
		/// </summary>
		void LateUpdate()
		{
			if (sPreviousMouseLocation != sMouseLocation)
			{
				MouseLocation oldLocation = sPreviousMouseLocation;
				sPreviousMouseLocation    = sMouseLocation;

				if (
					(oldLocation != MouseLocation.North   || sMouseLocation != MouseLocation.South)
					&&
					(oldLocation != MouseLocation.South   || sMouseLocation != MouseLocation.North)
					&& 
					(oldLocation != MouseLocation.East    || sMouseLocation != MouseLocation.West)
					&&
					(oldLocation != MouseLocation.West    || sMouseLocation != MouseLocation.East)
					&&
					(oldLocation != MouseLocation.Inside  || sMouseLocation != MouseLocation.Outside)
					&&
					(oldLocation != MouseLocation.Outside || sMouseLocation != MouseLocation.Inside)
				   )
				{	
					switch (sMouseLocation)
					{
						case MouseLocation.North:
						case MouseLocation.South:
						{
							Cursor.SetCursor(Assets.Cursors.northSouth, new Vector2(16f, 16f), CursorMode.Auto);
						}
						break;
						
						case MouseLocation.West:
						case MouseLocation.East:
						{
							Cursor.SetCursor(Assets.Cursors.eastWest, new Vector2(16f, 16f), CursorMode.Auto);
						}
						break;
										
						case MouseLocation.Inside:
						case MouseLocation.Outside:
						{
							RemoveCursor();
						}
						break;
						
						default:
						{
							Debug.LogError("Unknown mouse location: " + sMouseLocation);
						}
						break;
					}
				}
			}

			if (sResizingArea == this)
			{
				if (InputControl.GetMouseButtonDown(MouseButton.Left))
				{
					sMouseState = MouseState.Resizing;
				}
			}
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
					Debug.LogError("Invalid orientation value: " + orientation);
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

					mChildlessListeners.Invoke();
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

		/// <summary>
		/// Adds the childless listener.
		/// </summary>
		/// <param name="listener">Listener.</param>
		public void AddChildlessListener(UnityAction listener)
		{
			mChildlessListeners.AddListener(listener);
		}

		/// <summary>
		/// Removes the childless listener.
		/// </summary>
		/// <param name="listener">Listener.</param>
		public void RemoveChildlessListener(UnityAction listener)
        {
			mChildlessListeners.RemoveListener(listener);
        }
    }
}
