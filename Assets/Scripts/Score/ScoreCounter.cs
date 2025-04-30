using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _value;

    public event Action<int> ValueChanged;

    public void Add()
    {
        _value++;
        ValueChanged?.Invoke(_value);
    }

    public void Reset()
    {
        _value = 0;
        ValueChanged?.Invoke(_value);
    }
}
