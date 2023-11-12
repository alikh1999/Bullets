using Bullets.Input;
using Bullets.Pool;
using Bullets.World;
using UnityEngine;

namespace Bullets.Containers
{
    public class MainContainer : SingletonBehavior<MainContainer>
    {
        public IInput Input => _pcInput;
        public Pool<Bullet> RedBulletPool => _redBulletPool;
        public Pool<Bullet> BlueBulletPool => _blueBulletPool;
        public Pool<Bullet> RedEnemyPool => _redEnemyPool;
        public Pool<Bullet> BlueEnemyPool => _blueEnemyPool;

        [SerializeField]
        private PCInput _pcInput;
        [SerializeField]
        private Pool<Bullet> _redBulletPool;
        [SerializeField]
        private Pool<Bullet> _blueBulletPool;
        [SerializeField]
        private Pool<Bullet> _redEnemyPool;
        [SerializeField]
        private Pool<Bullet> _blueEnemyPool;

    }
}