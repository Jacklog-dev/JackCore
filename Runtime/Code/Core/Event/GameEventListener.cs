using System;
using Core.Event;
using UnityEngine;
using UnityEngine.Events;

namespace JackCore.Event
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _event;
        [SerializeField] private UnityEvent _callback;

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDestroy()
        {
            _event.UnregisterListener(this);
        }

        public void Invoke()
        {
           _callback.Invoke();
        }
    }
}