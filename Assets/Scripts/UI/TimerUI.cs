using System;
using Bullets.Containers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bullets.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _text;
        
        private Timer _timer;

        private void Awake()
        {
            _timer = MainContainer.Instance.Timer;
        }

        private void Start()
        {
            _text.text = GetTime(_timer.ReamingTimeInSeconds);
        }

        private void OnEnable()
        {
            _timer.Ticked += OnTicked;
        }

        private void OnDisable()
        {
            _timer.Ticked -= OnTicked;
        }

        private void OnTicked()
        {
            _text.text = GetTime(_timer.ReamingTimeInSeconds);
        }

        private string GetTime(int seconds)
        {
            return $"{seconds / 60}:{seconds % 60}";
        }
    }
}