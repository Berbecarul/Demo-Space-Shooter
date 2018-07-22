using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Helper
{ 
    public class TaggedEventHelper : MonoBehaviour
    {
        public TaggedEvent[] taggedEvents;

        public void _OnInvokeTaggedEvent(string tagName)
        {
            for (int i = 0; i < taggedEvents.Length; i++)
                if (taggedEvents[i].tag.Equals(tagName))
                    taggedEvents[i].onInvoke.Invoke();
        }

      

    }

    [System.Serializable]
    public struct TaggedEvent
    {
        public string tag;
        public UnityEvent onInvoke;
      
    }

}