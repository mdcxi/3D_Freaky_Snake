using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace FreakySnake.Helpers
{
    public class CountUpSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
    
        private TimeSpan _timeSpan;
        private bool _timerGoing;
        private float _elapsedTime;

        private void Start()
        {
            timerText.text = "00:00";
            _timerGoing = false;
        }

        public async void BeginTimer()
        {
            _timerGoing = true;
            _elapsedTime = 0f;
        
            await UpdateTimer();
        }

        public void EndTimer()
        {
            _timerGoing = false;
        }

        private async UniTask UpdateTimer()
        {
            while (_timerGoing)
            {
                if (Time.timeScale > 0)
                {
                    _elapsedTime += Time.deltaTime;
                    _timeSpan = TimeSpan.FromSeconds(_elapsedTime);
                    string timePlayingStr = _timeSpan.ToString("mm':'ss");
                    timerText.text = timePlayingStr;
                }

                await UniTask.Yield();
            }
        }
    }
}

