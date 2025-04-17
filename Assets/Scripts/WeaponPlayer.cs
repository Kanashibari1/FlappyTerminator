using System;
using UnityEngine;

public class WeaponPlayer : ObjectPool<BulletPlayer>
{
    [SerializeField] private BulletPlayer _bulletPlayer;
    [SerializeField] private Transform _transform;

    private float _shootDelay = 1f;
    private float _timeSinceLastShot;

    public event Action HitEnemy;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && _timeSinceLastShot >= _shootDelay)
        {
            Shoot();

            _timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        BulletPlayer bulletPlayer = GetObject(_bulletPlayer);
        bulletPlayer.gameObject.SetActive(true);
        bulletPlayer.Remover += Remove;
        bulletPlayer.Hit += KillEnemy;
        bulletPlayer.transform.position = _transform.position;
        bulletPlayer.Direction = _transform.right;
    }

    private void Remove(BulletPlayer bulletPlayer)
    {
        bulletPlayer.Remover -= Remove;
        bulletPlayer.Hit -= KillEnemy;
        PutObject(bulletPlayer);
    }

    public void KillEnemy(BulletPlayer bulletPlayer)
    {
        HitEnemy.Invoke();
        bulletPlayer.Hit -= KillEnemy;
    }
}
