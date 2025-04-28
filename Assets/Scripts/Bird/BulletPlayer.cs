using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _speed = 5f;

    public event Action<BulletPlayer> Remover;
    public event Action<BulletPlayer> Hit;

    public Vector2 Direction { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = Direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Remove();
            Hit?.Invoke(this);
            Remover?.Invoke(this);
        }

        else if (collision.TryGetComponent(out Platform platform))
        {
            Remover?.Invoke(this);
        }
    }
}
