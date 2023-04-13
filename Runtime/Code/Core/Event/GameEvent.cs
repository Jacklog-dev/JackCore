using System;
using System.Collections.Generic;
using JackCore.Event;
using UnityEngine;

namespace Core.Event
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();
        public event Action Callback;
        
        public void Dispatch()
        {
            for (int i = _listeners.Count-1; i >= 0 ; i--)
            {
                _listeners[i].Invoke();
            }
            Callback?.Invoke();
        }

        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}