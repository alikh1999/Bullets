using Bullets.Pool;
using UnityEngine;

namespace Bullets.World
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Bullet : Poolable
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<WorldBoundary>() != null)
            {
                Release();
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (!collider2D.TryGetComponent(out Enemy enemy))
                return;
            
            enemy.ApplyDamage();
            Release();
        }
    }
}