using System.Collections;
using UnityEngine;

public class SpawnerEnemy : ObjectPool<Enemy>
{
    [SerializeField] private Enemy _enemy;

    private float _delay = 3;
    private Coroutine _coroutine;

    private void StartCoroutine()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(GenerateEnemy());
        }
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(GenerateEnemy());
            _coroutine = null;
        }
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
        Enemy enemy = GetObject(_enemy);

        enemy.Remover += Remove;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = transform.position;
    }

    public void Remove(Enemy enemy)
    {
        PutObject(enemy);
        enemy.Remover -= Remove;
    }

    public void Reset()
    {
        StopCoroutine();

        foreach (var item in ActiveObjects)
        {
            PutObject(item);
        }

        StartCoroutine();
    }
}
