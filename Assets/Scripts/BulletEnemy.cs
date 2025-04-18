using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public event Action<BulletEnemy> Remover;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(-5,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            bird.Die();
        }
        else if (collision.TryGetComponent(out Platform platform))
        {
            Remover?.Invoke(this);
        }
    }
}
