using System;
using System.Collections.Generic;

namespace UnityBlocks.Helpers.Data
{
    public abstract class SimpleRegistry<T>
    {
        public List<T> List => _list;
        private readonly List<T> _list = new();

        public event Action<T> OnAdded;
        public event Action<T> OnRemoved;

        public void Add(T value)
        {
            if (!_list.Contains(value))
            {
                _list.Add(value);
                OnAdded?.Invoke(value);
            }
        }

        public bool Remove(T value)
        {
            var isRemoved = _list.Remove(value);
            if (isRemoved)
                OnRemoved?.Invoke(value);
            return isRemoved;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int Count() => _list.Count;
    }
}