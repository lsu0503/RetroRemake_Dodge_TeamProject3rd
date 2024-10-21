using Unity.VisualScripting;
using UnityEngine;

public class ScoreItem : Item
{
    [SerializeField] private int Score;
    protected override void ApplyItem(PlayerData playerData)
    {
        ScoreManager.instance.GainScore(playerData.playerNum,Score);
        Destroy(gameObject);
    }
}