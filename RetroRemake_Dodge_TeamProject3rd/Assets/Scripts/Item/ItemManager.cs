using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void ItemLife(PlayerData playerData)
    {
        playerData.GetLife();
    }
    public void ItemBomb(PlayerData playerData)
    {
        playerData.GetBomg();
    }
    public void ItemScore(ScoreManager scoreManager,int playerNum)
    {
        scoreManager.GainScore(playerNum, 1000);
    }
}
