using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
   public class Pool
    {
        public string nameTag;
        public GameObject prefab;
        public int poolSize;
        
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            AddDictionary();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }
    public void AddDictionary()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject projectile = Instantiate(pool.prefab);
                projectile.SetActive(false);
                queue.Enqueue(projectile);
            }
            PoolDictionary.Add(pool.nameTag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            return null;
        }
        
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;


    }

}
