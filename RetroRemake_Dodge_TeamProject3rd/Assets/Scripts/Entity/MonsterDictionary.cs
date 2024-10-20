using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionary : MonoBehaviour
{
    public Dictionary<string, GameObject> monsterDict;
    
    public GameObject InstanciateItem(string monsterName)
    {
        if (!monsterDict.ContainsKey(monsterName))
            return null;

        GameObject spawnMonster = Instantiate(monsterDict[monsterName]);
        spawnMonster.SetActive(false);
        return spawnMonster;
    }
}