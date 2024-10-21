using System;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private int[] itemId;
    private CharacterBehavior behavior;

    private void Awake()
    {
        behavior = GetComponent<CharacterBehavior>();
    }

    private void Start()
    {
        behavior.OnDieEvent += SpawnItem;
    }

    private void SpawnItem()
    {
        for (int i = 0; i < itemId.Length; i++)
        {
            GameObject spawnItem = StageManager.Instance.itemDict.InstanciateItem(itemId[i]);
            float xPos = transform.position.x + UnityEngine.Random.Range(0.0f, 2.0f);
            float yPos = transform.position.y + UnityEngine.Random.Range(0.0f, 2.0f);
            spawnItem.transform.position = new Vector2(xPos, yPos);
            spawnItem.SetActive(true);
        }
    }
}