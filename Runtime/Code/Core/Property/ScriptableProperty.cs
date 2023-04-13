using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Property
{
    public abstract class ScriptableProperty<T> : ScriptableObject
    {
        [SerializeField] private T _value;
        public event Action<T> OnChange; 
        public T Value
        {
            get => _value;
            set
            {
                var oldValue = _value;
                _value = value;
                
                if (!oldValue.Equals(_value))
                {
                    OnChange?.Invoke(_value);
                }
            }
        }
    }
}