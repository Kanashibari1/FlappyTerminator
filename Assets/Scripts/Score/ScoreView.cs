using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _scoreCounter.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _textMeshPro.text = value.ToString();
    }
}
