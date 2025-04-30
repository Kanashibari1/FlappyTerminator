using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletPlayer : MonoBehaviour
{
    private float _speed = 5f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public event Action<BulletPlayer> Removed;
    public event Action<BulletPlayer> Hitting;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Remove();
            Hitting?.Invoke(this);
            Removed?.Invoke(this);
        }
        else if (collision.TryGetComponent(out Platform platform))
        {
            Removed?.Invoke(this);
        }
    }

    public void Direction(Vector2 direction)
    {
        _direction = direction;
    }

    private void Move()
    {
        _rigidbody2D.velocity = _direction * _speed;
    }
}