using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PoolManager<T> : MonoBehaviour where T : Component
{
    #region singelton

    private static PoolManager<T> _instance;

    public static PoolManager<T> instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolManager<T>>();
            } 
            return _instance;
        }
    }

    #endregion

    [SerializeField] private List<Pool<T>> pools;
    private Dictionary<PoolType, Queue<T>> poolDictionary;


    private void Awake()
    {
        poolDictionary = new Dictionary<PoolType, Queue<T>>();
      
        GameObject poolObjectHolder = new GameObject("Holder");
        poolObjectHolder.transform.parent = transform;
      
        foreach (var pool in pools)
        {
            Queue<T> objectPool = new Queue<T>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                T obj = Instantiate(pool.prefab, poolObjectHolder.transform);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
         
            poolDictionary.Add(pool.poolType, objectPool);  
        }
    }
   
    public T SpawnFromPool(PoolType poolType, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolType))
        {
            return null;
        }
      
        T objectToSpawn = poolDictionary[poolType].Dequeue();
        objectToSpawn.gameObject.SetActive(true);

        var transform1 = objectToSpawn.transform;
        transform1.position = position;
        transform1.rotation = rotation;

        poolDictionary[poolType].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public void Despawn(T objectToDespawn)
    {
        objectToDespawn.gameObject.SetActive(false);
    }
}


[Serializable]
public class Pool<T>
{
    public PoolType poolType;
    public T prefab;
    public int poolSize;
}

public enum PoolType
{
    Obstacle,
    Bullet
}