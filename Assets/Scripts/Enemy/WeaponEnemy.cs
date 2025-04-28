using UnityEngine;
using System.Collections;

public class WeaponEnemy : ObjectPool<BulletEnemy>
{
    [SerializeField] private BulletEnemy _bulletEnemy;
    [SerializeField] private Transform _position;

    private int _delay = 1;
    private Coroutine _coroutine;

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

    private void Remove(BulletEnemy bulletEnemy)
    {
        PutObject(bulletEnemy);
        bulletEnemy.Remover -= Remove;
    }

    public void StartCoroutine()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Shoot());
        }
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void Reset()
    {
        StopCoroutine();

        foreach(var bullet in AllObjects)
        {
            if (bullet.gameObject.activeSelf)
            {
                bullet.Remover -= Remove;
                PutObject(bullet);
            }
        }
    }
}
