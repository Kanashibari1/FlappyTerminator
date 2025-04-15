using UnityEngine;

public class BulletPoolPlayer : MonoBehaviour
{
    [SerializeField] private BulletPlayer _bulletPlayer;

    private ObjectPool<BulletPlayer> _pool;

    private void Awake()
    {
        _pool = new(_bulletPlayer);
    }

    public BulletPlayer OnGet()
    {
        BulletPlayer bullet = _pool.GetObject(_bulletPlayer);
        bullet.Remover += Remove;
        return bullet;  
    }

    public void Remove(BulletPlayer bulletPlayer)
    {
        _pool.PutObject(bulletPlayer);
        bulletPlayer.Remover -= Remove;
    }
}

