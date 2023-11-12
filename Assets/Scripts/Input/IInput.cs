using System;
using UnityEngine;

namespace Bullets.Input
{
    public interface IInput
    {
        /// <summary>
        /// in screen 
        /// </summary>
        event Action<Vector3> PointerPositionUpdated;
        event Action RedBulletKeyPressed;
        event Action BlueBulletKeyPressed;

        void SetActive(bool activeState);
    }
}