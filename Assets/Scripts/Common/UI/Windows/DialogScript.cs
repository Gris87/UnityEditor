using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Common.UI.Windows
{
	/// <summary>
	/// Script that realize behaviour for dialog.
	/// </summary>
	public class DialogScript : WindowScript
	{
		private Dictionary<Behaviour, bool> mComponentStates;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		protected override void Start()
		{
			base.Start();

			mComponentStates = new Dictionary<Behaviour, bool>();

			for (int i = 0; i < Global.windowsTransform.childCount; ++i)
			{
				Transform child = Global.windowsTransform.GetChild(i);

				if (child != transform)
				{
					Behaviour[] components = child.GetComponentsInChildren<Behaviour>(true);
					
					foreach (Behaviour component in components)
					{
						if (
							!(component is Image)
							&&
							!(component is Mask)
							&&
							!(component is Text)
						   )
						{
							mComponentStates.Add(component, component.enabled);
							component.enabled = false;
						}
					}
				}
			}
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		protected override void OnDestroy()
		{
			base.OnDestroy();

			foreach(KeyValuePair<Behaviour, bool> componentState in mComponentStates)
			{
				componentState.Key.enabled = componentState.Value;
			}
		}
	}
}
