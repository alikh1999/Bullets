using System;
using UnityEngine;

namespace Bullets.Pool
{
    public class Poolable : MonoBehaviour
    {
        public event Action LifeCycleEnded;

        [SerializeField, Range(1.5f, 6f)] 
        private float _movementMagnitude = 1.5f; 
        
        private Vector3 _movementDirection;

        public void SetActive(bool activeState)
        {
            gameObject.SetActive(activeState);
        }

        public void SetParent(Transform parent)
        {
            gameObject.transform.SetParent(parent);
        }

        public void Release()
        {
            LifeCycleEnded?.Invoke();
        }

        public void Init(Vector3 spawnPosition, Vector3 movementDirection)
        {
            transform.position = spawnPosition;
            
            _movementDirection = movementDirection;
        }

        private void Update()
        {
            transform.position += _movementDirection * (_movementMagnitude * Time.deltaTime);
        }
    }
}