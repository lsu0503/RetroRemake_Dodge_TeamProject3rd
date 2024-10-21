using UnityEngine;

public class MinionAttack : MonsterAttack
{
    [Header("Bullet Info")]
    [SerializeField] private float duration;
    [SerializeField] private float size;
    [SerializeField] private float speed;

    [Header("Shooting Info")]
    [SerializeField] private Transform projSpawnPos;
    [SerializeField] private float[] projAngleSpace;
    [SerializeField] private int[] projsPerShot;
    [SerializeField] private float[] shotVelTerm;
    [SerializeField] private int[] shotsPerAttack;
    [SerializeField] private bool isLockOn;

    private int level;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        level = MonsterGenerator.Instance.level;
    }

    public override void UseAttack()
    {
        float angle = 180.0f;
        if (isLockOn)
            angle = SetTargetTransform();

        float minAngle = -(projsPerShot[level] - 1) / 2f * projAngleSpace[level];

        for (int j = 0; j < shotsPerAttack[level]; j++)
        {
            for (int i = 0; i < projsPerShot[level]; i++)
            {
                CreateProjectile(angle + minAngle + (projAngleSpace[level] * i), speed - (shotVelTerm[level] * j));
            }
        }
    }

    private void CreateProjectile(float angle, float velocity)
    {
        GameObject projObj = Instantiate(projPrefs[0]);
        projObj.SetActive(false);
        projObj.transform.position = projSpawnPos.position;
        projObj.transform.right = Quaternion.Euler(0.0f, 0.0f, angle) * transform.right;

        ProjectileData projData = projObj.GetComponent<ProjectileData>();
        projData.duration = duration;
        projData.size = size;
        projData.speed = velocity;
        projData.power = 0;

        projData.InitializeTime();
        projObj.SetActive(true);
    }
}