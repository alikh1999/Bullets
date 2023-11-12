using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bullets.Pool
{
    public class Pool<T> : MonoBehaviour where T : Poolable
    {
        [SerializeField]
        private T _poolabePrefab;
        [SerializeField] 
        private int _initalPoolSize = 1;
        
        private List<T> _pool = new List<T>();
        private LinkedList<T> _inactivePoolables = new LinkedList<T>();

        private void Awake()
        {
            InitializeObjectPool(_initalPoolSize);
        }

        private void InitializeObjectPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                var poolable = Instantiate(_poolabePrefab);
                poolable.SetActive(false);
                _pool.Add(poolable);
                _inactivePoolables.AddFirst(poolable);
            }
        }

        public T GetObjectFromPool()
        {
            foreach (var element in _inactivePoolables.Where(t => !t.gameObject.activeInHierarchy))
            {
                element.SetActive(true);
                _inactivePoolables.Remove(element);
                return element;
            }
            
            var poolable = Instantiate(_poolabePrefab);
            _pool.Add(poolable);
            return poolable;
        }

        public void ReturnObjectToPool(T poolable)
        {
            poolable.gameObject.SetActive(false);
        }
    }
}