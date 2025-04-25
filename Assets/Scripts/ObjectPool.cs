using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _pool = new();
    private List<T> _activeObjects = new();

    public IEnumerable<T> ActiveObjects => _activeObjects;

    private T Create(T obj)
    {
        T @object = GameObject.Instantiate(obj);

        @object.gameObject.SetActive(false);
        _activeObjects.Add(@object);
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
        @object.gameObject.SetActive(false);
        _pool.Enqueue(@object);
    }

    public void Restart()
    {
        foreach(T obj in _activeObjects)
        {
            PutObject(obj);
        }
    }
}
