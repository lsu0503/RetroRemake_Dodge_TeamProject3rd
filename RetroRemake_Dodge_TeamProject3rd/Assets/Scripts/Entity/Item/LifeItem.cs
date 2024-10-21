using Unity.VisualScripting;
using UnityEngine;

public class LifeItem : Item
{
    protected override void ApplyItem(PlayerData playerData)
    {
        playerData.GetLife();
        Destroy(gameObject);
    }
}