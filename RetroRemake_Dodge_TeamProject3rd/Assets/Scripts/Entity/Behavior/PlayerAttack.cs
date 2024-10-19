using System;
using UnityEngine;

public class PlayerAttack : ShotBase
{
    private PlayerData playerData;

    [Header("Bullet Info")]
    [SerializeField] private float duration;
    [SerializeField] private float size;
    [SerializeField] private float speed;
    [SerializeField] private int power;
    

    [Header("Shooting Info")]
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
        GameObject projObj = StageManager.Instance.objectPool.SpawnFromPool(projTag);
        projObj.transform.position = projSpawnPos.position;
        projObj.transform.right = Quaternion.Euler(0.0f, 0.0f, angle) * transform.right;

        ProjectileData projData = projObj.GetComponent<ProjectileData>();
        projData.duration = duration;
        projData.size = size;
        projData.speed = speed;
        projData.power = power;
        projData.type = playerData.playerNum;
        projData.targetTag = "Enemy";

        projData.InitializeTime();
        projObj.SetActive(true);
    }
}