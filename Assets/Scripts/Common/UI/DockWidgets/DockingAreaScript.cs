using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;



namespace Common.UI.DockWidgets
{
	/// <summary>
	/// Script that realize docking area behaviour.
	/// </summary>
	public class DockingAreaScript : MonoBehaviour
	{
		private static readonly float GAP = 4f;



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



		private RectTransform           mRectTransform;

		private DockingAreaOrientation  mOrientation;
		private DockingAreaScript       mParent;
		private List<DockingAreaScript> mChildren;
		private List<RectTransform>     mChildrenTransforms;
		private List<float>             mSizes;
		private DockingGroupScript      mDockingGroupScript;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingAreaScript"/> class.
		/// </summary>
		public DockingAreaScript()
		{
			mRectTransform = GetComponent<RectTransform>();

			mOrientation        = DockingAreaOrientation.None;
			mParent             = null;
			mChildren           = new List<DockingAreaScript>();
			mChildrenTransforms = new List<RectTransform>();
			mSizes              = new List<float>();
			mDockingGroupScript = null;
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
					mRectTransform.GetLocalCorners(corners);
					float totalWidth = corners[2].x - corners[0].x - (mChildren.Count - 1) * GAP;

					float contentWidth = 0f;

					for (int i = 0; i < mChildren.Count; ++i)
					{
						DockingAreaScript dockingArea      = mChildren[i];
						RectTransform dockingAreaTransform = mChildrenTransforms[i];
	                    
						float dockingAreaWidth = totalWidth * mSizes[i];
                    
						Utils.AlignRectTransformStretchLeft(dockingAreaTransform, dockingAreaWidth, contentWidth);
						contentWidth += dockingAreaWidth + GAP;                        

	                    dockingArea.OnResize();
					}
            	}
                break;

				case DockingAreaOrientation.Vertical:
				{
					Vector3[] corners = new Vector3[4];
					mRectTransform.GetLocalCorners(corners);
					float totalHeight = corners[2].y - corners[0].y - (mChildren.Count - 1) * GAP;
					
					float contentHeight = 0f;
					
					for (int i = 0; i < mChildren.Count; ++i)
					{
						DockingAreaScript dockingArea      = mChildren[i];
						RectTransform dockingAreaTransform = mChildrenTransforms[i];
						
						float dockingAreaHeight = totalHeight * mSizes[i];
						
						Utils.AlignRectTransformTopStretch(dockingAreaTransform, dockingAreaHeight, contentHeight);
	                    contentHeight += dockingAreaHeight + GAP;                        
	                    
	                    dockingArea.OnResize();
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
			dockWidget.transform.SetParent(dockingGroup.transform, false);
            #endregion
            #endregion
			            
            if (mChildren.Count == 0 && mDockingGroupScript == null)
            {
                mSizes.Add(1f);

				Utils.InitUIObject(dockingGroup, transform);
				mDockingGroupScript = dockingGroupScript;
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
				RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
				#endregion
				
				//===========================================================================
				// DockingAreaScript Component
				//===========================================================================
				#region DockingAreaScript Component
				DockingAreaScript dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
				dockingAreaScript.mParent = this;
				mChildren.Add(dockingAreaScript);
				mChildrenTransforms.Add(dockingAreaTransform);
				dockingAreaScript.mSizes.Add(1f);

				if (index == 0)
				{
					dockingAreaScript.mDockingGroupScript = dockingGroupScript;
					Utils.InitUIObject(dockingGroup, dockingArea.transform);
				}
				else
				{
					dockingAreaScript.mDockingGroupScript = mDockingGroupScript;
					Utils.InitUIObject(mDockingGroupScript.gameObject, dockingArea.transform);
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
				dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
				#endregion
				
				//===========================================================================
				// DockingAreaScript Component
				//===========================================================================
				#region DockingAreaScript Component
				dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
				dockingAreaScript.mParent = this;
				mChildren.Add(dockingAreaScript);
				mChildrenTransforms.Add(dockingAreaTransform);
				dockingAreaScript.mSizes.Add(1f);
                
                if (index == 0)
                {
					dockingAreaScript.mDockingGroupScript = mDockingGroupScript;
					Utils.InitUIObject(mDockingGroupScript.gameObject, dockingArea.transform);
                }
                else
                {
					dockingAreaScript.mDockingGroupScript = dockingGroupScript;
					Utils.InitUIObject(dockingGroup, dockingArea.transform);
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
						RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
						#endregion
						
						//===========================================================================
						// DockingAreaScript Component
						//===========================================================================
						#region DockingAreaScript Component
						DockingAreaScript dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
						dockingAreaScript.mParent = this;
						mChildren.Insert(index, dockingAreaScript);
						mChildrenTransforms.Insert(index, dockingAreaTransform);
                        dockingAreaScript.mSizes.Add(1f);
                        
						dockingAreaScript.mDockingGroupScript = dockingGroupScript;
						Utils.InitUIObject(dockingGroup, dockingArea.transform);
						#endregion
                        #endregion
                    }
                    else
                    {
						List<DockingAreaScript> newChildren           = new List<DockingAreaScript>();
						List<RectTransform>     newChildrenTransforms = new List<RectTransform>();
						List<float>             newSizes              = new List<float>();

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
						RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
						#endregion
						
						//===========================================================================
						// DockingAreaScript Component
						//===========================================================================
						#region DockingAreaScript Component
						DockingAreaScript dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
						dockingAreaScript.mParent = this;
						newChildren.Add(dockingAreaScript);
						newChildrenTransforms.Add(dockingAreaTransform);
                        
                        if (index == 0)
                        {
                            dockingAreaScript.mDockingGroupScript = dockingGroupScript;
                            Utils.InitUIObject(dockingGroup, dockingArea.transform);

							dockingAreaScript.mSizes.Add(1f);
                        }
                        else
                        {
							foreach (DockingAreaScript child in mChildren)
							{
								child.mParent = dockingAreaScript;
								child.transform.SetParent(dockingArea.transform, false);
							}

							dockingAreaScript.mOrientation        = mOrientation;
							dockingAreaScript.mChildren           = mChildren;
							dockingAreaScript.mChildrenTransforms = mChildrenTransforms;
							dockingAreaScript.mSizes              = mSizes;
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
						dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
						#endregion
						
						//===========================================================================
						// DockingAreaScript Component
						//===========================================================================
						#region DockingAreaScript Component
						dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
						dockingAreaScript.mParent = this;
						newChildren.Add(dockingAreaScript);
						newChildrenTransforms.Add(dockingAreaTransform);
						
						if (index == 0)
						{
							foreach (DockingAreaScript child in mChildren)
							{
								child.mParent = dockingAreaScript;
								child.transform.SetParent(dockingArea.transform, false);
							}

							dockingAreaScript.mOrientation        = mOrientation;
							dockingAreaScript.mChildren           = mChildren;
							dockingAreaScript.mChildrenTransforms = mChildrenTransforms;
							dockingAreaScript.mSizes              = mSizes;
                        }
                        else
                        {
                            dockingAreaScript.mDockingGroupScript = dockingGroupScript;
                            Utils.InitUIObject(dockingGroup, dockingArea.transform);
							
                            dockingAreaScript.mSizes.Add(1f);
                        }
                        #endregion
                        #endregion

						mOrientation = orientation;
                        
                        mChildren           = newChildren;
                        mChildrenTransforms = newChildrenTransforms;
                        mSizes              = newSizes;
                    }
				}
				else
				{
					Debug.LogError("Invalid orientation value");
				}
			}

			OnResize();
        }
    }
}
