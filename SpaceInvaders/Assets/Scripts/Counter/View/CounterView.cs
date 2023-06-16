using System;
using TMPro;
using UnityEngine;

namespace Counter.View
{
    public class CounterView : MonoBehaviour, ICounterView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _roundText;

        private void Start()
        {
            ShowRound(0);
            ShowScore(0);
        }

        public void ShowScore(int score)
        {
            _scoreText.text = "SCORE" + ": " + score;
        }

        public void ShowRound(int round)
        {
            _roundText.text = "ROUND" + ": " + round;
        }
    }
}