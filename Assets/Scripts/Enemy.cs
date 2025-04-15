using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private WeaponEnemy _weaponEnemy;
    public event Action<Enemy> Remover;
    private Coroutine _coroutine;
    private int _speed = 3;
    private bool coroutineStatus = false;

    private void Awake()
    {
        _weaponEnemy = GetComponent<WeaponEnemy>();
    }

    private void Update()
    {
        if(coroutineStatus != true)
        {
            StartCoroutine();
            coroutineStatus = true;
        }

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(_weaponEnemy.Shoot());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_weaponEnemy.Shoot());
            coroutineStatus = false;
        }
    }

    public void Remove()
    {
        Remover?.Invoke(this);
    }
}
