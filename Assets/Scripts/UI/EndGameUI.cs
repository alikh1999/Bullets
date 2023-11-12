using System;
using UnityEngine;
using UnityEngine.UI;

namespace Bullets.UI
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] 
        private Button _backgroundButton;

        private void OnEnable()
        {
            _backgroundButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _backgroundButton.onClick.RemoveListener(OnButtonClicked);
        }

        void OnButtonClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}