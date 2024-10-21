using System.Collections.Generic;
using UnityEngine;

public class ItemDictionaryConstructor : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    private ItemDictionary itemDictComponent;

    public void Awake()
    {
        itemDictComponent = GetComponent<ItemDictionary>();

        for (int i = 0; i < items.Count; i++)
        {
            itemDictComponent.itemDict.Add(i, items[i]);
        }
    }
}