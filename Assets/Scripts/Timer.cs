using System;
using System.Collections;
using UnityEngine;

namespace Bullets
{
    public class Timer : MonoBehaviour
    {
        public int ReamingTimeInSeconds => _reamingTimeInSeconds;
        public event Action Ticked;
        public event Action Ended;

        [SerializeField] private int _reamingTimeInSeconds = 300;

        private void Start()
        {
            StartCoroutine(Coroutine());
        }

        private IEnumerator Coroutine()
        {
            while (_reamingTimeInSeconds != 0)
            {
                yield return new WaitForSeconds(1);
                _reamingTimeInSeconds--;
                Ticked?.Invoke();
            }
            
            Ended?.Invoke();
        }
    }
}