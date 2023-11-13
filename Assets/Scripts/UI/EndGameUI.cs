using Bullets.Containers;
using UnityEngine;
using UnityEngine.UI;

namespace Bullets.UI
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] 
        private Button _backgroundButton;

        private Timer _timer;

        private void Awake()
        {
            _timer = MainContainer.Instance.Timer;
        }

        private void OnEnable()
        {
            _backgroundButton.onClick.AddListener(OnButtonClicked);
            _timer.Ended += OnEnded;
        }

        private void OnDisable()
        {
            _backgroundButton.onClick.RemoveListener(OnButtonClicked);
            _timer.Ended -= OnEnded;
        }

        void OnButtonClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        private void OnEnded()
        {
            _backgroundButton.gameObject.SetActive(true);
        }
    }
}