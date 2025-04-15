using System;
using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _speed = 5f;

    public event Action<BulletPlayer> Remover;
    public event Action<BulletPlayer> Hit;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public IEnumerator MoveBullet(Vector2 position)
    {
        while (enabled)
        {
            _rigidbody2D.velocity = position * _speed;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Remove();
            Hit.Invoke(this);
            Remover?.Invoke(this);
        }

        else if (collision.TryGetComponent(out Platform platform))
        {
            Remover?.Invoke(this);
        }
    }
}
