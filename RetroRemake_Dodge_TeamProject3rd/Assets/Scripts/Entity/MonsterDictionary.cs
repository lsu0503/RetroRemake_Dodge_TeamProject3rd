using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> monsterDict = new Dictionary<int, GameObject>();
    
    public GameObject InstanciateMonster(int monsterId)
    {
        if (!monsterDict.ContainsKey(monsterId))
            return null;

        GameObject spawnMonster = Instantiate(monsterDict[monsterId]);
        spawnMonster.SetActive(false);
        Debug.Log(spawnMonster.name);
        return spawnMonster;
    }
}