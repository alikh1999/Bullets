using System;
using Bullets.Pool;
using UnityEngine;

namespace Bullets.World
{
    public class Bullet : Poolable
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<WorldBoundary>() != null)
            {
                Release();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            
        }
    }
}