using System;
using UnityEngine;

public class WeaponPlayer : BulletPoolPlayer
{
    [SerializeField] private Transform _transform;
    private ShotHandler _shotHandler;
    public event Action Hit;

    private void Awake()
    {
        _shotHandler = GetComponent<ShotHandler>();
    }

    private void OnEnable()
    {
        _shotHandler.Shoot += Shoot;
    }

    private void OnDisable()
    {
        _shotHandler.Shoot -= Shoot;
    }

    public void Shoot()
    {
        BulletPlayer bulletPlayer = OnGet();
        bulletPlayer.gameObject.SetActive(true);
        bulletPlayer.transform.position = _transform.position;
        StartCoroutine(bulletPlayer.MoveBullet(_transform.right));
        bulletPlayer.Hit += KillEnemy;
    }

    public void KillEnemy(BulletPlayer bulletPlayer)
    {
        Hit.Invoke();
        bulletPlayer.Hit -= KillEnemy;
    }
}
