using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class WeaponPlayer : ObjectPool<BulletPlayer>
{
    [SerializeField] private BulletPlayer _bulletPlayer;
    [SerializeField] private Transform _transform;

    private InputReader _inputReader;

    public event Action Hit;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.UsingShot += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.UsingShot -= Shoot;
    }

    public void Reset()
    {
        Restart();
    }

    public void KillEnemy(BulletPlayer bulletPlayer)
    {
        Hit.Invoke();
        bulletPlayer.Hitting -= KillEnemy;
    }

    private void Shoot()
    {
        BulletPlayer bulletPlayer = GetObject(_bulletPlayer);
        bulletPlayer.gameObject.SetActive(true);
        bulletPlayer.Removed += Remove;
        bulletPlayer.Hitting += KillEnemy;
        bulletPlayer.transform.position = _transform.position;
        bulletPlayer.Direction(_transform.right);
    }

    private void Remove(BulletPlayer bulletPlayer)
    {
        bulletPlayer.Removed -= Remove;
        bulletPlayer.Hitting -= KillEnemy;
        PutObject(bulletPlayer);
    }
}
