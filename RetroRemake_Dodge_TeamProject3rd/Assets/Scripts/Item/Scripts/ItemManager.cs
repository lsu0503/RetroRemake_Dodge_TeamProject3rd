using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void ItemLife(PlayerData playerData)
    {
        playerData.GetLife();
        Destroy(gameObject);
    }
    public void ItemBomb(PlayerData playerData)
    {
        playerData.GetBomb();
        Destroy(gameObject);
    }
    public void ItemScore(ScoreManager scoreManager,int playerNum)
    {
        scoreManager.GainScore(playerNum, 1000);
        Destroy(gameObject);
    }
}
