using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private ObjectPool<Enemy> _pool;
    private float _delay = 3;

    private void Awake()
    {
        _pool = new(_enemy);
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        Enemy enemy = _pool.GetObject(_enemy);

        enemy.Remover += Remove;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = transform.position;
    }

    public void Remove(Enemy enemy)
    {
        _pool.PutObject(enemy);
        enemy.Remover -= Remove;
    }
}
