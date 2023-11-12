using System;
using UnityEngine;

namespace Bullets.Input
{
    public class PCInput : MonoBehaviour, IInput
    {
        public event Action<Vector3> PointerPositionUpdated;
        public event Action RedBulletKeyPressed;
        public event Action BlueBulletKeyPressed;

        private bool _isActive = true;
        
        public void SetActive(bool activeState)
        {
            _isActive = activeState;
        }

        private void Update()
        {
            if (!_isActive)
            {
                return;
            }
            
            PointerPositionUpdated?.Invoke(UnityEngine.Input.mousePosition);

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                RedBulletKeyPressed?.Invoke();
            }
            
            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                BlueBulletKeyPressed?.Invoke();
            }
        }
    }
}