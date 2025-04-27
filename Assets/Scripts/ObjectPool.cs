using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _pool = new();
    private List<T> _allObjects = new();

    public IEnumerable<T> AllObjects => _allObjects;

    private T Create(T obj)
    {
        T @object = GameObject.Instantiate(obj);

        @object.gameObject.SetActive(false);
        _allObjects.Add(@object);
        _pool.Enqueue(@object);
        return @object;
    }

    public T GetObject(T @object)
    {
        if (_pool.Count == 0)
        {
            Create(@object);
        }

        T obj = _pool.Dequeue();

        return obj;
    }

    public void PutObject(T @object)
    {
        @object.gameObject.SetActive(false);
        _pool.Enqueue(@object);
    }

    public void Restart()
    {
        foreach (T obj in _allObjects)
        {
            if (obj.gameObject.activeSelf)
            {
                PutObject(obj);
            }
        }
    }
}
