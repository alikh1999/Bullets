using System;
using System.Collections;
using UnityEngine;

namespace Bullets
{
    public class Timer : MonoBehaviour
    {
        public event Action Ended;

        private int _reamingTimeInSeconds;
        
        public void Init(int totalTimeInSeconds)
        {
            _reamingTimeInSeconds = totalTimeInSeconds;
            StartCoroutine(Coroutine());
        }

        private IEnumerator Coroutine()
        {
            while (_reamingTimeInSeconds != 0)
            {
                yield return new WaitForSeconds(1);
                _reamingTimeInSeconds--;
            }
            
            Ended?.Invoke();
        }
    }
}