using UnityEngine;

public class BulletPoolEnemy : MonoBehaviour
{
    [SerializeField] private BulletEnemy _bulletEnemy;

    private ObjectPool<BulletEnemy> _pool;

    private void Awake()
    {
        _pool = new(_bulletEnemy);
    }

    public BulletEnemy OnGet()
    {
        BulletEnemy bullet = _pool.GetObject(_bulletEnemy);
        bullet.Remover += Remove;
        return bullet;
    }

    public void Remove(BulletEnemy bullet)
    {
        _pool.PutObject(bullet);
        bullet.Remover -= Remove;
    }
}
