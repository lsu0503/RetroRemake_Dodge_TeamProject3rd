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
        ItemManager itemManager = GetComponent<ItemManager>();
        PlayerData playerData = collision.rigidbody.GetComponent<PlayerData>();

        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemData.itemType == 0)
            {
                itemManager.ItemLife(playerData);
            }
            else if (itemData.itemType == 1)
            {
                itemManager.ItemBomb(playerData);
            }
            else 
            {
                ScoreManager scoreManager = collision.rigidbody.GetComponent<ScoreManager>();
                int pnum = playerData.playerNum;
                itemManager.ItemScore(scoreManager,pnum);
            }
        }
    }
}