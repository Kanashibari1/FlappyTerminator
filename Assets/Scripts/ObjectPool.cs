using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private const int _capacity = 5;

    [SerializeField] private T _prefab;

    private Queue<T> _pool = new();

    //public ObjectPool(T prefab)
    //{
    //    for (int i = 0; i < _capacity; i++)
    //    {
    //        Create(prefab);
    //    }
    //}

    private T Create(T obj)
    {
        T @object = GameObject.Instantiate(obj);

        @object.gameObject.SetActive(false);
        _pool.Enqueue(@object);
        return @object;
    }

    public T GetObject(T @object)
    {
        if(_pool.Count == 0)
        {
            Create(@object);
        }

        return _pool.Dequeue();
    }

    public void PutObject(T @object)
    {
        _pool.Enqueue(@object);
        @object.gameObject.SetActive(false);
    }
}
