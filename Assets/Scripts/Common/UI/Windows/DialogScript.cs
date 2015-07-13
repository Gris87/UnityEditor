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
        private Dictionary<MonoBehaviour, bool> mComponentStates;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        protected override void Start()
        {
            base.Start();

            mComponentStates = new Dictionary<MonoBehaviour, bool>();



            Transform parent = transform.parent;

            for (int i = 0; i < parent.childCount; ++i)
            {
                Transform child = parent.GetChild(i);

                if (child != transform)
                {
                    MonoBehaviour[] components = child.GetComponentsInChildren<MonoBehaviour>(true);

                    foreach (MonoBehaviour component in components)
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

            foreach(KeyValuePair<MonoBehaviour, bool> componentState in mComponentStates)
            {
                if (componentState.Key != null)
                {
                    componentState.Key.enabled = componentState.Value;
                }
            }
        }
    }
}
