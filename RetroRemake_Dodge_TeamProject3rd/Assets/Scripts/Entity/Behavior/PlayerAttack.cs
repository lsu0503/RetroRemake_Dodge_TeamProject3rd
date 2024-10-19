using System;
using UnityEngine;

public class PlayerAttack : ShotBase
{
    private PlayerData playerData;
    
    [SerializeField] private Transform projSpawnPos;
    [SerializeField] private float projAngleSpace;
    [SerializeField] private int projsPerShot;
    [SerializeField] private string projTag;

    protected override void Awake()
    {
        base.Awake();
        playerData = GetComponent<PlayerData>();
    }

    public override void UseAttack()
    {
        float minAngle = -(projsPerShot - 1) / 2f * projAngleSpace;

        for (int i = 0; i < projsPerShot; i++)
            CreateProjectile(minAngle + (projAngleSpace * i));
    }

    private void CreateProjectile(float angle)
    {
        GameObject obj = ObjectPool.Instance.SpawnFromPool(projTag);
        obj.transform.position = projSpawnPos.position;
        obj.transform.right = Quaternion.Euler(0.0f, 0.0f, angle) * transform.right;

        ProjectileData projData = obj.GetComponent<ProjectileData>();
        projData.type = playerData.playerNum;
        projData.targetTag = "Enemy";
    }
}