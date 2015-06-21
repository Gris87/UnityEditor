using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Common.UI.Toasts;



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



			Transform parent = transform.parent;

			for (int i = 0; i < parent.childCount; ++i)
			{
				Transform child = parent.GetChild(i);

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
							&&
							!(component is ToastScript) // TODO: Remove it, shall destroy on disabling
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
