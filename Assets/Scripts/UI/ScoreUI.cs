using System;
using Bullets.Containers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bullets.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _text;

        private Game _game;
        private int _currentScore;

        private void Awake()
        {
            _game = MainContainer.Instance.Game;
        }

        private void OnEnable()
        {
            _game.EnemyDied += OnEnemyDied;
        }

        private void OnDisable()
        {
            _game.EnemyDied -= OnEnemyDied;
        }
        
        private void OnEnemyDied()
        {
            _currentScore++;
            _text.text = _currentScore.ToString();
        }
    }
}