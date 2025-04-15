using System;
using UnityEngine;

public class WeaponPlayer : ObjectPool<BulletPlayer>
{
    [SerializeField] private BulletPlayer _bulletPlayer;
    [SerializeField] private Transform _transform;

    private float _shootDelay = 1f;
    private float _timeSinceLastShot;
    public event Action Hit;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && _timeSinceLastShot >= _shootDelay)
        {
            Shoot();

            _timeSinceLastShot = 0f;
        }
    }

    public void Shoot()
    {
        BulletPlayer bulletPlayer = GetObject(_bulletPlayer);
        bulletPlayer.gameObject.SetActive(true);
        bulletPlayer.Remover += Remove;
        bulletPlayer.transform.position = _transform.position;
        bulletPlayer.Direction = _transform.right;
        bulletPlayer.Hit += KillEnemy;
    }

    public void KillEnemy(BulletPlayer bulletPlayer)
    {
        Hit.Invoke();
        bulletPlayer.Hit -= KillEnemy;
    }

    public void Remove(BulletPlayer bulletPlayer)
    {
        PutObject(bulletPlayer);
        bulletPlayer.Remover -= Remove;
    }

}
