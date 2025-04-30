using System;
using UnityEngine;

[RequireComponent(typeof(WeaponEnemy))]
public class Enemy : MonoBehaviour
{
    private WeaponEnemy _weaponEnemy;
    private int _speed = 3;

    public event Action<Enemy> Removed;

    private void Awake()
    {
        _weaponEnemy = GetComponent<WeaponEnemy>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void Remove()
    {
        Removed?.Invoke(this);
    }

    public void StartShot()
    {
        _weaponEnemy.Attack();
    }

    public void StopShot()
    {
        _weaponEnemy.StopAttack();
    }

    public void Restart()
    {
        _weaponEnemy.Reset();
    }
}
