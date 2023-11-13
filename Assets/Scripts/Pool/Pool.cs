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
        
        private List<T> _pool = new();
        private LinkedList<T> _inactivePoolables = new();

        private void Awake()
        {
            InitializeObjectPool(_initalPoolSize);
        }

        private void InitializeObjectPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                var poolable = Instantiate(_poolabePrefab, Vector3.zero, Quaternion.identity, transform);
                poolable.SetActive(false);
                _pool.Add(poolable);
                poolable.LifeCycleEnded -= () => OnLifeCycleEnded(poolable);
                poolable.LifeCycleEnded += () => OnLifeCycleEnded(poolable);
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
            
            var poolable = Instantiate(_poolabePrefab, Vector3.zero, Quaternion.identity, transform);
            poolable.LifeCycleEnded -= () => OnLifeCycleEnded(poolable);
            poolable.LifeCycleEnded += () => OnLifeCycleEnded(poolable);
            _pool.Add(poolable);
            return poolable;
        }

        private void ReturnObjectToPool(T poolable)
        {
            poolable.gameObject.SetActive(false);
            poolable.transform.position = Vector3.zero;
            _inactivePoolables.AddFirst(poolable);
        }
        
        private void OnLifeCycleEnded(T poolable)
        {
            ReturnObjectToPool(poolable);
        }
    }
}