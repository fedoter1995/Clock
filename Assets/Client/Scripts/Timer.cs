using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomTimer
{
    public class Timer : MonoBehaviour
    {
        public event Action OnSecondLeftEvent;
        public event Action OnHourLeftEvent;
        public static Timer instance
        {
            get
            {
                if(_instance == null)
                {
                    var go = new GameObject("[TIMER]");
                    _instance = go.AddComponent<Timer>();
                    DontDestroyOnLoad(go);
                }

                return _instance;
            }
        }

        private static Timer _instance;

        private float secondTimer;


        private void Awake()
        {
            StartCoroutine(HourTimer());
        }
        private void Update()
        {
            SecondTimer();
        }
        private void SecondTimer()
        {
            var deltaTime = Time.deltaTime;

            secondTimer += deltaTime;

            if (secondTimer >= 1f)
            {
                secondTimer -= 1;
                OnSecondLeftEvent?.Invoke();
            }

        }
        private IEnumerator HourTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(3600);
                OnHourLeftEvent?.Invoke();
            }
        }

    }
}

