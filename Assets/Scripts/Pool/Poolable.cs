using System;
using UnityEngine;

namespace Bullets.Pool
{
    public class Poolable : MonoBehaviour
    {
        public event Action LifeCycleEnded;

        public void SetActive(bool activeState)
        {
            gameObject.SetActive(activeState);
        }

        public void SetParent(Transform parent)
        {
            gameObject.transform.SetParent(parent);
        }

        protected void Release()
        {
            LifeCycleEnded?.Invoke();
        }
    }
}