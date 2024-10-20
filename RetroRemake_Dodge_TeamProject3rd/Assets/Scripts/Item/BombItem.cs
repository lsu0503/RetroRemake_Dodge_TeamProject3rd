using System;
using Unity.VisualScripting;

public class BombItem : Item
{
    protected override void ApplyItem(PlayerData playerData)
    {
        playerData.GetBomb();
        Destroy(gameObject);
    }
}