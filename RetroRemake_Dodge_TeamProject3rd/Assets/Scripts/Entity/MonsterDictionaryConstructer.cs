using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionaryConstructer : MonoBehaviour
{
    [SerializeField] private List<GameObject> monsters;
    private MonsterDictionary monsterDictComponent;

    public void Awake()
    {
        monsterDictComponent = GetComponent<MonsterDictionary>();

        for(int i = 0; i < monsters.Count; i++)
            monsterDictComponent.monsterDict.Add(i, monsters[i]);

        Destroy(this);
    }
}