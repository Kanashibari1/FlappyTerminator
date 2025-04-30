using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _scoreCounter.ValueChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _textMeshPro.text = score.ToString();
    }
}
