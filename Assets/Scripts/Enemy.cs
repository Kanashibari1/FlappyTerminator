using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Remover;
    private int _speed = 3;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void Remove()
    {
        Remover?.Invoke(this);
    }
}
