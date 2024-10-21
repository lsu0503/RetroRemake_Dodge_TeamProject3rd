using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : ShotBase
{
    protected MonsterData monsterData;
    protected Transform[] targetTransformArray;
    protected int actionSelector;

    [SerializeField] protected GameObject[] projPrefs;

    [Header("Bullet Info")]
    [SerializeField] protected float duration;
    [SerializeField] protected float size;
    [SerializeField] protected float speed;

    [Header("Shooting Info")]
    [SerializeField] protected Transform projSpawnPos;
    [SerializeField] protected float[] projAngleSpace;
    [SerializeField] protected int[] projsPerShot;
    [SerializeField] protected float[] shotVelTerm;
    [SerializeField] protected int[] shotsPerAttack;
    [SerializeField] protected bool isLockOn;
    [SerializeField] protected int[] projPrefsNum;

    protected override void Awake()
    {
        base.Awake();
        monsterData = GetComponent<MonsterData>();
    }

    protected override void Start()
    {
        base.Start();

        GameObject[] targetObjArray = GameObject.FindGameObjectsWithTag("Player");
        List<Transform> targetTransformList = new List<Transform>();

        for (int i = 0; i < targetObjArray.Length; i++)
            targetTransformList.Add(targetObjArray[i].transform);

        targetTransformArray = targetTransformList.ToArray();
    }

    protected float SetTargetTransform()
    {
        Transform target = targetTransformArray[Random.Range(0, targetTransformArray.Length)];
        Vector2 direction = (Vector2)(target.position - gameObject.transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }

    protected void CreateProjectile(float angle, float velocity, int projNum)
    {
        GameObject projObj = Instantiate(projPrefs[projNum]);
        projObj.SetActive(false);
        projObj.transform.position = projSpawnPos.position;
        projObj.transform.right = Quaternion.Euler(0.0f, 0.0f, angle) * transform.right;

        ProjectileData projData = projObj.GetComponent<ProjectileData>();
        projData.duration = duration;
        projData.size = size;
        projData.speed = velocity;
        projData.power = 0;
        projData.targetTag = "HitPoint";
        projData.isInPool = false;

        projData.InitializeTime();
        projObj.SetActive(true);
    }
}