using UnityEngine;

namespace Bullets
{
    public class SingletonBehavior<T> : MonoBehaviour
    {
        public static T Instance => _instance;

        private static T _instance;

        private void Awake()
        {
            _instance = GetComponent<T>();
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            
        }
    }
}