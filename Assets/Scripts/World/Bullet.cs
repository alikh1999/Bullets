using Bullets.Pool;
using UnityEngine;

namespace Bullets.World
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Bullet : Poolable
    {
        [SerializeField, Range(1.5f, 6f)] 
        private float _movementMagnitude = 1.5f; 
        
        private Vector3 _movementDirection;
        
        public void Init(Vector3 spawnPosition, Vector3 movementDirection)
        {
            transform.position = spawnPosition;
            
            _movementDirection = new Vector3(movementDirection.x, movementDirection.y, 0);
        }

        private void Update()
        {
            transform.position += _movementDirection * (_movementMagnitude * Time.deltaTime);
        }
        
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
            
            Release();
            enemy.ApplyDamage();
        }
    }
}