using System.Collections;
using UnityEngine;

public class SpawnerEnemy : ObjectPool<Enemy>
{
    [SerializeField] private Enemy _enemy;

    private float _delay = 3;
    private Coroutine _coroutine;
    private float _loverLimit = -16;
    private float _upperLimit = 0;

    public void Reset()
    {
        StopSpawning();

        foreach (Enemy enemy in AllObjects)
        {
            enemy.Restart();
            enemy.Removed -= Remove;
        }

        Restart();
        StartSpawning();
    }

    private void StartSpawning()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(GenerateEnemy());
        }
    }

    private void StopSpawning()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator GenerateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnY = Random.Range(_loverLimit, _upperLimit);
        Vector3 spawn = new(transform.position.x, spawnY, transform.position.z);
        Enemy enemy = GetObject(_enemy);
        enemy.Removed += Remove;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawn;
        enemy.StartShot();
    }

    private void Remove(Enemy enemy)
    {
        enemy.StopShot();
        PutObject(enemy);
        enemy.Removed -= Remove;
    }
}