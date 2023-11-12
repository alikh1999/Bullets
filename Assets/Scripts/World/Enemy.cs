using System;
using Bullets.Pool;
using UnityEngine;

namespace Bullets.World
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Enemy : Poolable
    {
        public event Action Death;

        public void ApplyDamage()
        {
            Death?.Invoke();
            Release();
        }
    }
}