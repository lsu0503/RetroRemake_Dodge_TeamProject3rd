using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> itemDict = new Dictionary<int, GameObject>();

    public GameObject InstanciateItem(int itemId)
    {
        if (!itemDict.ContainsKey(itemId)) 
            return null;

        GameObject spawnItem = Instantiate(itemDict[itemId]);
        spawnItem.SetActive(false);
        return spawnItem;
    }
}
