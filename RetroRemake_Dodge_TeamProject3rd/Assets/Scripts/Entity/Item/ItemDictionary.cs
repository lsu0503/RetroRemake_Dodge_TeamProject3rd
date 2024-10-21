using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    public Dictionary<int, GameObject> itemDict;

    public void Awake()
    {
        itemDict = new Dictionary<int, GameObject>();

        for (int i = 0; i < items.Count; i++)
        {
            itemDict.Add(i, items[i]);
        }
    }

    public GameObject InstanciateItem(int itemId)
    {
        if (!itemDict.ContainsKey(itemId)) 
            return null;

        GameObject spawnItem = Instantiate(itemDict[itemId]);
        spawnItem.SetActive(false);
        return spawnItem;
    }
}
