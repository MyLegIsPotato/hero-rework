using System;
using UnityEngine;

namespace Project.Common.Time
{
    [Serializable]
    public class Timer
    {
        [field: SerializeField]
        public float TimeToFinish { get; private set; }
        [field: SerializeField]
        public float CountDownTime { get; private set; }
        
        private bool autoRestart = true;
        private bool countdownStarted = false;
        
        public Action OnTimerFinished;
        public Action<float> OnTimerUpdated;

        public Timer(float timeInterval, bool restartAutomatically)
        {
            CountDownTime = timeInterval;
            TimeToFinish = timeInterval;
            autoRestart = restartAutomatically;
        }
        
        public Timer(float timeInterval, bool restartAutomatically, Action onTimerFinished)
        {
            CountDownTime = timeInterval;
            TimeToFinish = timeInterval;
            autoRestart = restartAutomatically;
            OnTimerFinished = onTimerFinished;
        }

        public void StartCountdown()
        {
            countdownStarted = true;
        }
        
        public void StopCountdown()
        {
            countdownStarted = false;
        }

        public void UpdateTimer(float deltaTime)
        {
            TimeToFinish -= deltaTime;
            
            OnTimerUpdated?.Invoke(GetFraction());
            if (TimeToFinish <= 0)
                OnTimerFinished?.Invoke();
        }
        
        public float GetFraction()
        {
            return TimeToFinish / CountDownTime;
        }

        public void Reset()
        {
            TimeToFinish = CountDownTime;
        }
    }
}