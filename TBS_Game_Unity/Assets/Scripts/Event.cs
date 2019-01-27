using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public abstract class Event<T> where T : Event<T>
    {
        private bool hasFired;
        public delegate void EventListener(T info);
        private static event EventListener events;

        public static void RegisterListener(EventListener listener)
        {
            events += listener;
        }
        public static void UnregisterListener(EventListener listener)
        {
            events -= listener;
        }

        public void FireEvent()
        {
            if (hasFired)
            {
                throw new System.Exception("This event already fired");
            }
            if (events != null)
            {
                events(this as T);
            }
        }

        public class Spawn : Event<Spawn>
        {
            public GameObject Name;
        }


    }
}
