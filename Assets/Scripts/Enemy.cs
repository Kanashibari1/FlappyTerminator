using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private WeaponEnemy _weaponEnemy;
    public event Action<Enemy> Remover;
    private int _speed = 3;
    private Coroutine _coroutine;

    private void Awake()
    {
        _weaponEnemy = GetComponent<WeaponEnemy>();
    }

    //private void OnEnable()
    //{
    //    if (_coroutine == null)
    //    {
    //        _coroutine = StartCoroutine(_weaponEnemy.Shoot());
    //    }
    //}

    //private void OnDisable()
    //{
    //    if (_coroutine != null)
    //    {
    //        StopCoroutine(_weaponEnemy.Shoot());
    //        _coroutine = null;
    //    }
    //}

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void Remove()
    {
        Remover?.Invoke(this);
    }
}
