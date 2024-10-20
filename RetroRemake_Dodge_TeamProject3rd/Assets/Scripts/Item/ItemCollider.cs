using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private ItemData itemData;
    private void Awake()
    {
        itemData = GetComponent<ItemData>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemData.itemType == 0)
            {
                ItemManager itemManager = GetComponent<ItemManager>();
                itemManager.ItemLife();
            }
            else if (itemData.itemType == 1)
            {
                ItemManager itemManager = GetComponent<ItemManager>();
                itemManager.ItemBomb();
            }
            else 
            {
                ItemManager itemManager = GetComponent<ItemManager>();
                itemManager.ItemScore();
            }
        }
    }
}