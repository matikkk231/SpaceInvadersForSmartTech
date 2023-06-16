using TMPro;
using UnityEngine;

namespace Counter.View
{
    public class CounterView : MonoBehaviour, ICounterView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _roundText;

        public void ShowScore(int score)
        {
            _scoreText.text = "SCORE" + score;
        }

        public void ShowRound(int round)
        {
            _roundText.text = "ROUND" + round;
        }
    }
}