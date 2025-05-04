using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class WeaponPlayer : ObjectPool<BulletPlayer>
{
    [SerializeField] private BulletPlayer _bulletPlayer;
    [SerializeField] private Transform _transform;

    private InputReader _inputReader;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;
    private float _secondSleep = 2f;
    private bool _isShot = true;

    public event Action Hit;

    private void Awake()
    {
        _waitForSeconds = new(_secondSleep);
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Shotted += Shot;
    }

    private void OnDisable()
    {
        _inputReader.Shotted -= Shot;
    }

    public void Reset()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _isShot = true;
        Restart();
    }

    public void KillEnemy(BulletPlayer bulletPlayer)
    {
        Hit.Invoke();
        bulletPlayer.Hitting -= KillEnemy;
    }

    private void Shot()
    {
        if (_isShot)
        {
            BulletPlayer bulletPlayer = GetObject(_bulletPlayer);
            bulletPlayer.gameObject.SetActive(true);
            bulletPlayer.Removed += Remove;
            bulletPlayer.Hitting += KillEnemy;
            bulletPlayer.transform.position = _transform.position;
            bulletPlayer.SetDirection(_transform.right);
            Recharge();
        }
    }

    private void Remove(BulletPlayer bulletPlayer)
    {
        bulletPlayer.Removed -= Remove;
        bulletPlayer.Hitting -= KillEnemy;
        PutObject(bulletPlayer);
    }

    private IEnumerator Whit()
    {
        yield return _waitForSeconds;
        _isShot = true;
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private void Recharge()
    {
        _isShot = false;

        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(Whit());
        }
    }
}
