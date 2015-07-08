using System;
using System.Collections.Generic;
using UnityEngine;

using Common.UI.ResourceTypes;



/// <summary>
/// Class for loading assets of UnityEditor project.
/// </summary>
public static class Assets
{
	#region Assets structures
	#region Common assets
	/// <summary>
	/// Common assets.
	/// </summary>
	public static class Common
	{
		/// <summary>
		/// Common fonts.
		/// </summary>
        public static class Fonts
        {
			public static Font defaultFont;



			private static Dictionary<string, Font> fonts;
			private static string[]                 osFonts;



			/// <summary>
			/// Initializes the <see cref="Assets+Common+Fonts"/> class.
			/// </summary>
			static Fonts()
			{
				defaultFont = LoadResource<Font>("Fonts/Default");

				fonts   = new Dictionary<string, Font>();
				osFonts = Font.GetOSInstalledFontNames();

				ResetValues();
			}

			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				fonts.Clear();

				Font[] fontList = Resources.LoadAll<Font>("Fonts/");

				foreach (Font font in fontList)
				{
					string[] fontNames = font.fontNames;

					foreach (string fontName in fontNames)
					{
						if (!fonts.ContainsKey(fontName))
						{
							fonts.Add(fontName, font);
						}
						else
						{
							Debug.LogWarning("Already has a font with name: " + fontName);
						}
					}
				}

				string[] defaultFontNames = defaultFont.fontNames;
				
				foreach (string fontName in defaultFontNames)
				{
					if (!fonts.ContainsKey(fontName))
					{
						fonts.Add(fontName, defaultFont);
					}
				}
			}

			/// <summary>
			/// Gets the font with specified name.
			/// </summary>
			/// <returns>Font.</returns>
			/// <param name="fontName">Font name.</param>
			/// <param name="fontSize">Font size.</param>
			public static Font GetFont(string fontName, int fontSize = 12)
			{
				Font res;

				if (fonts.TryGetValue(fontName, out res))
				{
					return res;
				}

				string nameLower = fontName.ToLower();
				string bestFont  = "";

				foreach (string osFont in osFonts)
				{
					if (osFont == fontName)
					{
						bestFont = osFont;
						break;
					}

					string osNameLower = osFont.ToLower();

					if (osNameLower == nameLower)
					{
						bestFont = osFont;
						break;
					}

					if (osNameLower.Contains(nameLower))
					{
						if (bestFont == "" || osFont.Length < bestFont.Length)
						{
							bestFont = osFont;
						}
					}
				}

				if (bestFont != "")
				{
					res = Font.CreateDynamicFontFromOSFont(bestFont, fontSize);
					fonts.Add(fontName, res);
					
					return res;
				}

				return defaultFont;
			}
        }
	}
	#endregion

	#region Assets for Cursors
	/// <summary>
	/// Assets for Cursors.
	/// </summary>
	public static class Cursors
	{
		public static Texture2D eastWest           = LoadResource<Texture2D>("Cursors/EastWest");
		public static Texture2D northEastSouthWest = LoadResource<Texture2D>("Cursors/NorthEastSouthWest");
		public static Texture2D northSouth         = LoadResource<Texture2D>("Cursors/NorthSouth");
		public static Texture2D northWestSouthEast = LoadResource<Texture2D>("Cursors/NorthWestSouthEast");
	}
	#endregion

	#region Assets for Windows
	/// <summary>
	/// Assets for Windows.
	/// </summary>
	public static class Windows
	{
		#region Common assets for Windows
		/// <summary>
		/// Common assets for Windows.
		/// </summary>
		public static class Common
		{
			/// <summary>
			/// Common color assets for Windows.
			/// </summary>
			public static class Colors
			{
				public static Color background = LoadColor("Colors/Common/UI/Windows/Background");
			}

			/// <summary>
			/// Common text style assets for Windows.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyle title = LoadTextStyle("TextStyles/Common/UI/Windows/Title");
			}

			/// <summary>
			/// Common texture assets for Windows.
			/// </summary>
			public static class Textures
			{
				public static Sprite window                     = LoadResource<Sprite>("Textures/Common/UI/Windows/Window");
				public static Sprite windowDeselected           = LoadResource<Sprite>("Textures/Common/UI/Windows/WindowDeselected");
				public static Sprite subWindow                  = LoadResource<Sprite>("Textures/Common/UI/Windows/SubWindow");
				public static Sprite subWindowDeselected        = LoadResource<Sprite>("Textures/Common/UI/Windows/SubWindowDeselected");
				public static Sprite drawer                     = LoadResource<Sprite>("Textures/Common/UI/Windows/Drawer");
				public static Sprite drawerDeselected           = LoadResource<Sprite>("Textures/Common/UI/Windows/DrawerDeselected");
				public static Sprite singleFrame                = LoadResource<Sprite>("Textures/Common/UI/Windows/SingleFrame");
				public static Sprite singleFrameDeselected      = LoadResource<Sprite>("Textures/Common/UI/Windows/SingleFrameDeselected");
				public static Sprite minimizeButton             = LoadResource<Sprite>("Textures/Common/UI/Windows/MinimizeButton");
				public static Sprite minimizeButtonDeselected   = LoadResource<Sprite>("Textures/Common/UI/Windows/MinimizeButtonDeselected");
				public static Sprite minimizeButtonDisabled     = LoadResource<Sprite>("Textures/Common/UI/Windows/MinimizeButtonDisabled");
				public static Sprite minimizeButtonHighlighted  = LoadResource<Sprite>("Textures/Common/UI/Windows/MinimizeButtonHighlighted");
				public static Sprite minimizeButtonPressed      = LoadResource<Sprite>("Textures/Common/UI/Windows/MinimizeButtonPressed");
				public static Sprite maximizeButton             = LoadResource<Sprite>("Textures/Common/UI/Windows/MaximizeButton");
				public static Sprite maximizeButtonDeselected   = LoadResource<Sprite>("Textures/Common/UI/Windows/MaximizeButtonDeselected");
				public static Sprite maximizeButtonDisabled     = LoadResource<Sprite>("Textures/Common/UI/Windows/MaximizeButtonDisabled");
				public static Sprite maximizeButtonHighlighted  = LoadResource<Sprite>("Textures/Common/UI/Windows/MaximizeButtonHighlighted");
				public static Sprite maximizeButtonPressed      = LoadResource<Sprite>("Textures/Common/UI/Windows/MaximizeButtonPressed");
				public static Sprite normalizeButton            = LoadResource<Sprite>("Textures/Common/UI/Windows/NormalizeButton");
				public static Sprite normalizeButtonDeselected  = LoadResource<Sprite>("Textures/Common/UI/Windows/NormalizeButtonDeselected");
				public static Sprite normalizeButtonDisabled    = LoadResource<Sprite>("Textures/Common/UI/Windows/NormalizeButtonDisabled");
				public static Sprite normalizeButtonHighlighted = LoadResource<Sprite>("Textures/Common/UI/Windows/NormalizeButtonHighlighted");
				public static Sprite normalizeButtonPressed     = LoadResource<Sprite>("Textures/Common/UI/Windows/NormalizeButtonPressed");
				public static Sprite closeButton                = LoadResource<Sprite>("Textures/Common/UI/Windows/CloseButton");
				public static Sprite closeButtonDeselected      = LoadResource<Sprite>("Textures/Common/UI/Windows/CloseButtonDeselected");
				public static Sprite closeButtonDisabled        = LoadResource<Sprite>("Textures/Common/UI/Windows/CloseButtonDisabled");
				public static Sprite closeButtonHighlighted     = LoadResource<Sprite>("Textures/Common/UI/Windows/CloseButtonHighlighted");
				public static Sprite closeButtonPressed         = LoadResource<Sprite>("Textures/Common/UI/Windows/CloseButtonPressed");
				public static Sprite toolCloseButton            = LoadResource<Sprite>("Textures/Common/UI/Windows/ToolCloseButton");
				public static Sprite toolCloseButtonDeselected  = LoadResource<Sprite>("Textures/Common/UI/Windows/ToolCloseButtonDeselected");
				public static Sprite toolCloseButtonDisabled    = LoadResource<Sprite>("Textures/Common/UI/Windows/ToolCloseButtonDisabled");
				public static Sprite toolCloseButtonHighlighted = LoadResource<Sprite>("Textures/Common/UI/Windows/ToolCloseButtonHighlighted");
				public static Sprite toolCloseButtonPressed     = LoadResource<Sprite>("Textures/Common/UI/Windows/ToolCloseButtonPressed");
				public static Sprite replacement                = LoadResource<Sprite>("Textures/Common/UI/Windows/Replacement");
			}
		}
		#endregion

		#region Assets for MainWindow
		/// <summary>
		/// Assets for MainWindow.
		/// </summary>
		public static class MainWindow
		{
			/// <summary>
			/// Color assets for MainWindow.
			/// </summary>
			public static class Colors
			{
				public static Color background = LoadColor("Colors/UI/Windows/MainWindow/Background");
			}

			#region Assets for MainMenu
			/// <summary>
			/// Assets for MainMenu.
			/// </summary>
			public static class MainMenu
			{
				/// <summary>
				/// Text style assets for MainMenu.
				/// </summary>
				public static class TextStyles
				{
					public static TextStyle button = LoadTextStyle("TextStyles/UI/Windows/MainWindow/MainMenu/Button");
				}

				/// <summary>
				/// Texture assets for MainMenu.
				/// </summary>
				public static class Textures
				{
					public static Sprite background        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Background");
					public static Sprite button            = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Button");
					public static Sprite buttonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
					public static Sprite buttonPressed     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
				}
			}
			#endregion
			
			#region Assets for Toolbar
			/// <summary>
			/// Assets for Toolbar.
			/// </summary>
			public static class Toolbar
			{
				/// <summary>
				/// Text style assets for Toolbar.
				/// </summary>
				public static class TextStyles
				{
					public static TextStyle point            = LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/Point");
					public static TextStyle coordinateSystem = LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/CoordinateSystem");
					public static TextStyle layers           = LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/Layers");
					public static TextStyle layout           = LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/Layout");
				}

				/// <summary>
				/// Texture assets for Toolbar.
				/// </summary>
				public static class Textures
				{
					public static Sprite background                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Background");
					public static Sprite toolLeftButton                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButton");
					public static Sprite toolLeftButtonPressed         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonPressed");
					public static Sprite toolLeftButtonActive          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActive");
					public static Sprite toolLeftButtonActivePressed   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActivePressed");
					public static Sprite toolMiddleButton              = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButton");
					public static Sprite toolMiddleButtonPressed       = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonPressed");
					public static Sprite toolMiddleButtonActive        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActive");
					public static Sprite toolMiddleButtonActivePressed = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActivePressed");
					public static Sprite toolRightButton               = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButton");
					public static Sprite toolRightButtonPressed        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonPressed");
					public static Sprite toolRightButtonActive         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActive");
					public static Sprite toolRightButtonActivePressed  = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActivePressed");
					public static Sprite toolHand                      = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHand");
					public static Sprite toolHandActive                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHandActive");
					public static Sprite toolMove                      = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMove");
					public static Sprite toolMoveActive                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMoveActive");
					public static Sprite toolRotate                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotate");
					public static Sprite toolRotateActive              = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotateActive");
					public static Sprite toolScale                     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScale");
					public static Sprite toolScaleActive               = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScaleActive");
					public static Sprite toolRectTransform             = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransform");
					public static Sprite toolRectTransformActive       = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransformActive");
					public static Sprite center                        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Center");
					public static Sprite pivot                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pivot");
					public static Sprite local                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Local");
					public static Sprite global                        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Global");
					public static Sprite play                          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Play");
					public static Sprite playActive                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PlayActive");
					public static Sprite pause                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pause");
					public static Sprite pauseActive                   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PauseActive");
					public static Sprite step                          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Step");
					public static Sprite stepActive                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/StepActive");
					public static Sprite popupButton                   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButton");
				}
			}
			#endregion
		
			#region Assets for DockWidgets
			/// <summary>
			/// Assets for DockWidgets.
			/// </summary>
			public static class DockWidgets
			{
				#region Assets for scene dock widget
				/// <summary>
				/// Assets for scene dock widget.
				/// </summary>
				public static class Scene
				{
					/// <summary>
					/// Color assets for scene dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Scene/Background");
                    }

					/// <summary>
					/// Texture assets for scene dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Scene/Icon");
					}
				}
				#endregion

				#region Assets for game dock widget
				/// <summary>
				/// Assets for game dock widget.
				/// </summary>
				public static class Game
				{
					/// <summary>
					/// Color assets for game dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Game/Background");
                    }

                    /// <summary>
					/// Texture assets for game dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Game/Icon");
					}
				}
				#endregion

				#region Assets for inspector dock widget
				/// <summary>
				/// Assets for inspector dock widget.
				/// </summary>
				public static class Inspector
				{
					/// <summary>
					/// Color assets for inspector dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Inspector/Background");
                    }

                    /// <summary>
					/// Texture assets for inspector dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Inspector/Icon");
					}
				}
				#endregion

				#region Assets for hierarchy dock widget
				/// <summary>
				/// Assets for hierarchy dock widget.
				/// </summary>
				public static class Hierarchy
				{
					/// <summary>
					/// Color assets for hierarchy dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Hierarchy/Background");
                    }

                    /// <summary>
					/// Texture assets for hierarchy dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Hierarchy/Icon");
					}
				}
				#endregion

				#region Assets for project dock widget
				/// <summary>
				/// Assets for project dock widget.
				/// </summary>
				public static class Project
				{
					/// <summary>
					/// Color assets for project dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Project/Background");
                    }

                    /// <summary>
					/// Texture assets for project dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Project/Icon");
					}
				}
				#endregion

				#region Assets for animation dock widget
				/// <summary>
				/// Assets for animation dock widget.
				/// </summary>
				public static class Animation
				{
					/// <summary>
					/// Color assets for animation dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Animation/Background");
                    }

                    /// <summary>
					/// Texture assets for animation dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Animation/Icon");
					}
				}
				#endregion

				#region Assets for profiler dock widget
				/// <summary>
				/// Assets for profiler dock widget.
				/// </summary>
				public static class Profiler
				{
					/// <summary>
					/// Color assets for profiler dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Profiler/Background");
                    }

                    /// <summary>
					/// Texture assets for profiler dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Profiler/Icon");
					}
				}
				#endregion

				#region Assets for audio mixer dock widget
				/// <summary>
				/// Assets for audio mixer dock widget.
				/// </summary>
				public static class AudioMixer
				{
					/// <summary>
					/// Color assets for audio mixer dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AudioMixer/Background");
                    }

                    /// <summary>
					/// Texture assets for audio mixer dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/AudioMixer/Icon");
					}
				}
				#endregion

				#region Assets for asset store dock widget
				/// <summary>
				/// Assets for asset store dock widget.
				/// </summary>
				public static class AssetStore
				{
					/// <summary>
					/// Color assets for asset store dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AssetStore/Background");
                    }

                    /// <summary>
					/// Texture assets for asset store dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/AssetStore/Icon");
					}
				}
				#endregion

				#region Assets for version control dock widget
				/// <summary>
				/// Assets for version control dock widget.
				/// </summary>
				public static class VersionControl
				{
					/// <summary>
					/// Color assets for version control dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/VersionControl/Background");
                    }

                    /// <summary>
					/// Texture assets for version control dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/VersionControl/Icon");
					}
				}
				#endregion

				#region Assets for animator parameter dock widget
				/// <summary>
				/// Assets for animator parameter dock widget.
				/// </summary>
				public static class AnimatorParameter
				{
					/// <summary>
					/// Color assets for animator parameter dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AnimatorParameter/Background");
                    }

                    /// <summary>
					/// Texture assets for animator parameter dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/AnimatorParameter/Icon");
					}
				}
				#endregion

				#region Assets for animator dock widget
				/// <summary>
				/// Assets for animator dock widget.
				/// </summary>
				public static class Animator
				{
					/// <summary>
					/// Color assets for animator dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Animator/Background");
                    }

                    /// <summary>
					/// Texture assets for animator dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Animator/Icon");
					}
				}
				#endregion

				#region Assets for sprite packer dock widget
				/// <summary>
				/// Assets for sprite packer dock widget.
				/// </summary>
				public static class SpritePacker
				{
					/// <summary>
					/// Color assets for sprite packer dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/SpritePacker/Background");
                    }

                    /// <summary>
					/// Texture assets for sprite packer dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/SpritePacker/Icon");
					}
				}
				#endregion

				#region Assets for lighting dock widget
				/// <summary>
				/// Assets for lighting dock widget.
				/// </summary>
				public static class Lighting
				{
					/// <summary>
					/// Color assets for lighting dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Lighting/Background");
                    }

                    /// <summary>
					/// Texture assets for lighting dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Lighting/Icon");
					}
				}
				#endregion

				#region Assets for occlusion culling dock widget
				/// <summary>
				/// Assets for occlusion culling dock widget.
				/// </summary>
				public static class OcclusionCulling
				{
					/// <summary>
					/// Color assets for occlusion culling dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/OcclusionCulling/Background");
                    }

                    /// <summary>
					/// Texture assets for occlusion culling dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/OcclusionCulling/Icon");
					}
				}
				#endregion

				#region Assets for frame debugger dock widget
				/// <summary>
				/// Assets for frame debugger dock widget.
				/// </summary>
				public static class FrameDebugger
				{
					/// <summary>
					/// Color assets for frame debugger dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/FrameDebugger/Background");
                    }

                    /// <summary>
					/// Texture assets for frame debugger dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/FrameDebugger/Icon");
					}
				}
				#endregion

				#region Assets for navigation dock widget
				/// <summary>
				/// Assets for navigation dock widget.
				/// </summary>
				public static class Navigation
				{
					/// <summary>
					/// Color assets for navigation dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Navigation/Background");
                    }

                    /// <summary>
					/// Texture assets for navigation dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Navigation/Icon");
					}
				}
				#endregion
				
				#region Assets for console dock widget
				/// <summary>
				/// Assets for console dock widget.
				/// </summary>
				public static class Console
				{
					/// <summary>
					/// Color assets for console dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Console/Background");
                    }

                    /// <summary>
					/// Texture assets for console dock widget.
					/// </summary>
					public static class Textures
					{
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Console/Icon");
					}
				}
				#endregion
			}
			#endregion
		}
		#endregion

		#region Assets for AboutDialog
		/// <summary>
		/// Assets for AboutDialog.
		/// </summary>
		public static class AboutDialog
		{
			/// <summary>
			/// Color assets for AboutDialog.
			/// </summary>
			public static class Colors
			{
				public static Color background = LoadColor("Colors/UI/Windows/AboutDialog/Background");
            }

			/// <summary>
			/// Text style assets for AboutDialog.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyle version    = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Version");
				public static TextStyle credits    = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Credits");
				public static TextStyle monoLogo   = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo");
				public static TextStyle monoLogo2  = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo2");
				public static TextStyle physXLogo  = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo");
				public static TextStyle physXLogo2 = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo2");
				public static TextStyle copyright  = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Copyright");
				public static TextStyle license    = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/License");
			}

			/// <summary>
			/// Texture assets for AboutDialog.
			/// </summary>
			public static class Textures
			{
				public static Sprite unity = LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Unity");
				public static Sprite mono  = LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Mono");
				public static Sprite physX = LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/PhysX");
			}
		}
		#endregion
	}
	#endregion

	#region Assets for Popups
	/// <summary>
	/// Assets for Popups.
	/// </summary>
	public static class Popups
	{
		/// <summary>
		/// Text style assets for Popups.
		/// </summary>
		public static class TextStyles
		{
			public static TextStyle button         = LoadTextStyle("TextStyles/Common/UI/Popups/Button");
			public static TextStyle buttonDisabled = LoadTextStyle("TextStyles/Common/UI/Popups/ButtonDisabled");
        }

		/// <summary>
		/// Texture assets for Popups.
		/// </summary>
		public static class Textures
		{
			public static Sprite popupBackground   = LoadResource<Sprite>("Textures/Common/UI/Popups/PopupBackground");
			public static Sprite background        = LoadResource<Sprite>("Textures/Common/UI/Popups/Background");
			public static Sprite separator         = LoadResource<Sprite>("Textures/Common/UI/Popups/Separator");
			public static Sprite button            = LoadResource<Sprite>("Textures/Common/UI/Popups/Button");
			public static Sprite buttonDisabled    = LoadResource<Sprite>("Textures/Common/UI/Popups/ButtonDisabled");
			public static Sprite buttonHighlighted = LoadResource<Sprite>("Textures/Common/UI/Popups/ButtonHighlighted");
			public static Sprite arrow             = LoadResource<Sprite>("Textures/Common/UI/Popups/Arrow");
			public static Sprite checkbox          = LoadResource<Sprite>("Textures/Common/UI/Popups/Checkbox");
		}
	}
	#endregion

	#region Assets for Tooltips
	/// <summary>
	/// Assets for Tooltips.
	/// </summary>
	public static class Tooltips
	{
		/// <summary>
		/// Text style assets for Tooltips.
		/// </summary>
		public static class TextStyles
		{
			public static TextStyle tooltipText = LoadTextStyle("TextStyles/Common/UI/Tooltips/TooltipText");
		}

		/// <summary>
		/// Texture assets for Tooltips.
		/// </summary>
		public static class Textures
		{
			public static Sprite tooltipBackground = LoadResource<Sprite>("Textures/Common/UI/Tooltips/TooltipBackground");
        }
    }
	#endregion

	#region Assets for Toasts
	/// <summary>
	/// Assets for Toasts.
	/// </summary>
	public static class Toasts
	{
		/// <summary>
		/// Text style assets for Toasts.
		/// </summary>
		public static class TextStyles
		{
			public static TextStyle toastText = LoadTextStyle("TextStyles/Common/UI/Toasts/ToastText");
        }
        
        /// <summary>
		/// Texture assets for Toasts.
		/// </summary>
		public static class Textures
		{
			public static Sprite toastBackground = LoadResource<Sprite>("Textures/Common/UI/Toasts/ToastBackground");
        }
    }
    #endregion
		
	#region Assets for DockWidgets
	/// <summary>
	/// Assets for DockWidgets.
	/// </summary>
	public static class DockWidgets
	{
		/// <summary>
		/// Color assets for DockWidgets.
		/// </summary>
		public static class Colors
		{
			public static Color background      = LoadColor("Colors/Common/UI/DockWidgets/Background");
			public static Color dummyBackground = LoadColor("Colors/Common/UI/DockWidgets/DummyBackground");
			public static Color dockingWindow   = LoadColor("Colors/Common/UI/DockWidgets/DockingWindow");
		}

		/// <summary>
		/// Text style assets for DockWidgets.
		/// </summary>
		public static class TextStyles
		{
			public static TextStyle title = LoadTextStyle("TextStyles/Common/UI/DockWidgets/Title");
		}

		/// <summary>
		/// Texture assets for DockWidgets.
		/// </summary>
		public static class Textures
		{
			public static Sprite tab            = LoadResource<Sprite>("Textures/Common/UI/DockWidgets/Tab");
			public static Sprite tabActive      = LoadResource<Sprite>("Textures/Common/UI/DockWidgets/TabActive");
			public static Sprite tabSelected    = LoadResource<Sprite>("Textures/Common/UI/DockWidgets/TabSelected");
			public static Sprite icon           = LoadResource<Sprite>("Textures/Common/UI/DockWidgets/Icon");
			public static Sprite pageBackground = LoadResource<Sprite>("Textures/Common/UI/DockWidgets/PageBackground");
		}
	}
	#endregion
	#endregion

	/// <summary>
	/// Loads an asset stored at path in a resources.
	/// </summary>
	/// <returns>The asset at path if it can be found otherwise returns null.</returns>
	/// <param name="path">Pathname of the target asset.</param>
	/// <typeparam name="T">Type of resource.</typeparam>
	private static T LoadResource<T>(string path) where T : UnityEngine.Object
	{
		T res = Resources.Load<T>(path);
		
		if (res == null)
		{
			Debug.LogError("Resource \"" + path + "\" is not found");
		}
		
		return res;
	}

	/// <summary>
	/// Loads color asset stored at path in a resources.
	/// </summary>
	/// <returns>The color.</returns>
	/// <param name="path">Pathname of the target asset.</param>
	private static Color LoadColor(string path)
	{
		Color res = new Color(0f, 0f, 0f);

		TextAsset asset = LoadResource<TextAsset>(path);

		if (asset != null)
		{
			IniFile iniFile = new IniFile(asset);
			LoadColorFromIniFile(iniFile, ref res);
		}

		return res;
	}

	/// <summary>
	/// Loads text style asset stored at path in a resources.
	/// </summary>
	/// <returns>The text style.</returns>
	/// <param name="path">Pathname of the target asset.</param>
	private static TextStyle LoadTextStyle(string path)
	{
		TextAsset asset = LoadResource<TextAsset>(path);
		
		if (asset == null)
		{
			return null;
		}

		TextStyle res = new TextStyle();
		Color color   = new Color(0f, 0f, 0f);


		
		IniFile iniFile = new IniFile(asset);
		iniFile.BeginGroup("Font");

		string font        = iniFile.Get("Font",        "Microsoft Sans Serif");
		string fontStyle   = iniFile.Get("FontStyle",   "Normal");
		int    fontSize    = iniFile.Get("FontSize",    12);
		float  lineSpacing = iniFile.Get("LineSpacing", 1);
		string alignment   = iniFile.Get("Alignment",   "UpperLeft");
		LoadColorFromIniFile(iniFile, ref color);

		iniFile.EndGroup();



		res.font = Common.Fonts.GetFont(font, fontSize);

		try 
		{
			res.fontStyle = (FontStyle) Enum.Parse(typeof(FontStyle), fontStyle);
		}
		catch (Exception)
		{
			Debug.LogError("Invalid font style value \"" + fontStyle + "\" for text style: " + path);
        }

		res.fontSize    = fontSize;
		res.lineSpacing = lineSpacing;

		try 
		{
			res.alignment = (TextAnchor) Enum.Parse(typeof(TextAnchor), alignment);
		}
		catch (Exception)
		{
			Debug.LogError("Invalid alignment value \"" + alignment + "\" for text style: " + path);
		}

		res.color = color;



		return res;
	}

	/// <summary>
	/// Loads the color from ini file.
	/// </summary>
	/// <param name="iniFile">Ini file.</param>
	/// <param name="color">Result color.</param>
	private static void LoadColorFromIniFile(IniFile iniFile, ref Color color)
	{
		iniFile.BeginGroup("Color");

		color.r = iniFile.Get("Red",   0f);
		color.g = iniFile.Get("Green", 0f);
		color.b = iniFile.Get("Blue",  0f);
		color.a = iniFile.Get("Alpha", 1f);

		iniFile.EndGroup();
	}
}