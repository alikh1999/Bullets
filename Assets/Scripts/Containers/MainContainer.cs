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
        public Pool<Enemy> RedEnemyPool => _redEnemyPool;
        public Pool<Enemy> BlueEnemyPool => _blueEnemyPool;
        public Timer Timer => _timer;
        public Game Game => _game;

        [SerializeField] 
        private Game _game;
        [SerializeField]
        private PCInput _pcInput;
        [SerializeField]
        private Pool<Bullet> _redBulletPool;
        [SerializeField]
        private Pool<Bullet> _blueBulletPool;
        [SerializeField]
        private Pool<Enemy> _redEnemyPool;
        [SerializeField]
        private Pool<Enemy> _blueEnemyPool;
        [SerializeField] 
        private Timer _timer;
    }
}