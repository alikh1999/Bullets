using Bullets.Containers;
using Bullets.Pool;
using Bullets.World;
using UnityEngine;

namespace Bullets
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] 
        private Transform _bulletSpawnPosition;
        
        private Pool<Bullet> _redBulletPool;
        private Pool<Bullet> _blueBulletPool;
        private Vector3 _currentDirection;
        private Camera _camera;

        private void Awake()
        {
            _redBulletPool = MainContainer.Instance.RedBulletPool;
            _blueBulletPool = MainContainer.Instance.BlueBulletPool;
        }

        private void Start()
        {
            MainContainer.Instance.Input.PointerPositionUpdated += OnPointerPositionUpdated;
            MainContainer.Instance.Input.BlueBulletKeyPressed += OnBlueBulletKeyPressed;
            MainContainer.Instance.Input.RedBulletKeyPressed += OnRedBulletKeyPressed;
        }

        private void OnDestroy()
        {
            MainContainer.Instance.Input.PointerPositionUpdated += OnPointerPositionUpdated;
            MainContainer.Instance.Input.BlueBulletKeyPressed += OnBlueBulletKeyPressed;
            MainContainer.Instance.Input.RedBulletKeyPressed += OnRedBulletKeyPressed;
        }
        
        private void OnPointerPositionUpdated(Vector3 position)
        {
            _currentDirection = _camera.ScreenToWorldPoint(position) - transform.position;
            if (_currentDirection == Vector3.zero) 
                return;
            
            Quaternion rotationToTarget = Quaternion.LookRotation(_currentDirection, Vector3.up);
            transform.rotation = rotationToTarget;
        }
        
        private void OnRedBulletKeyPressed()
        {
            SpawnBullet(true);
        }

        private void OnBlueBulletKeyPressed()
        {
            SpawnBullet(false);
        }

        private void SpawnBullet(bool isRedBullet)
        {
            var bullet = isRedBullet ? _redBulletPool.GetObjectFromPool() : _blueBulletPool.GetObjectFromPool();
            bullet.Init(_bulletSpawnPosition.position, _currentDirection);
        }
    }
}