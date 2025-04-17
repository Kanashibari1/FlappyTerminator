using UnityEngine;
using System.Collections;

public class WeaponEnemy : ObjectPool<BulletEnemy>
{
    [SerializeField] private BulletEnemy _bulletEnemy;
    [SerializeField] private Transform _position;

    private int _delay = 2;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Shoot());
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(Shoot());
            _coroutine = null;
        }
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds _waitForSeconds;

        while (enabled)
        {
            BulletEnemy bulletEnemy = GetObject(_bulletEnemy);
            bulletEnemy.Remover += Remove;
            bulletEnemy.gameObject.SetActive(true);
            bulletEnemy.transform.position = _position.position;

            yield return _waitForSeconds = new(_delay);
        }
    }

    public void Remove(BulletEnemy bulletEnemy)
    {
        PutObject(bulletEnemy);
        bulletEnemy.Remover -= Remove;
    }
}
