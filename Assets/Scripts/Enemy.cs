using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private WeaponEnemy _weaponEnemy;
    private int _speed = 3;
    public event Action<Enemy> Remover;

    private void Awake()
    {
        _weaponEnemy = GetComponent<WeaponEnemy>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void Remove()
    {
        Remover?.Invoke(this);
    }

    public void StartShot()
    {
        _weaponEnemy.StartCoroutine();
    }

    public void StopShot()
    {
        _weaponEnemy.StopCoroutine();
    }

    public void Restart()
    {
        _weaponEnemy.Reset();
    }
}
