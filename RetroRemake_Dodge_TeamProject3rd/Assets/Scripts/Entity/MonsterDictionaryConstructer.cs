using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionaryConstructer : MonoBehaviour
{
    [Serializable]
    public class MonsterIndex
    {
        public string monsterName;
        public GameObject monsterObj;
    }

    [SerializeField] private List<MonsterIndex> monsters;
    private MonsterDictionary monsterDictComponent;
    private Dictionary<string, GameObject> monsterDict= new Dictionary<string, GameObject>();

    public void Awake()
    {
        monsterDictComponent = GetComponent<MonsterDictionary>();

        foreach (var monster in monsters)
            monsterDict.Add(monster.monsterName, monster.monsterObj);

        monsterDictComponent.monsterDict = monsterDict;

        Destroy(this);
    }
}