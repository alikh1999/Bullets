using System;
using System.Collections.Generic;
using Bullets.Containers;
using Bullets.Pool;
using Bullets.World;
using UnityEngine;

namespace Bullets
{
    public class Game : MonoBehaviour
    {
        public event Action EnemyDied;
        
        [SerializeField] 
        private List<Transform> _enemiesPosition;

        private bool _wasBlueEnemySpawned;
        
        private Pool<Enemy> _redEnemyPool;
        private Pool<Enemy> _blueEnemyPool;

        private void Awake()
        {
            _redEnemyPool = MainContainer.Instance.RedEnemyPool;
            _blueEnemyPool = MainContainer.Instance.BlueEnemyPool;
        }

        private void Start()
        {
            _wasBlueEnemySpawned = false;
            foreach (var enemyPosition in _enemiesPosition)
            {
                var enemy = GetEnemy();
                enemy.transform.position = enemyPosition.position;
                enemy.Death += () =>
                {
                    var enemy1 = GetEnemy();
                    enemy1.transform.position = enemyPosition.position;
                    EnemyDied?.Invoke();
                };
                
                _wasBlueEnemySpawned = !_wasBlueEnemySpawned;
            }

            MainContainer.Instance.Timer.Ended += OnTimerEnded;
            
            MainContainer.Instance.Input.SetActive(true);
        }

        private void OnTimerEnded()
        {
            MainContainer.Instance.Input.SetActive(false);
        }

        private Enemy GetEnemy()
        {
            return _wasBlueEnemySpawned ? _redEnemyPool.GetObjectFromPool() : _blueEnemyPool.GetObjectFromPool();
        }
    }
}