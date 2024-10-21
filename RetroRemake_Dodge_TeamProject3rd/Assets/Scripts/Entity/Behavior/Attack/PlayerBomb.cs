using UnityEngine;

public class PlayerBomb : AttackBase
{
    private PlayerData playerData;
    [SerializeField] private Transform projSpawnPos;
    [SerializeField] private GameObject projPref;
    [SerializeField] float delayBomb;
    private float timeSinceLastBomb = float.MaxValue;

    [Header("Bullet Info")]
    [SerializeField] private float duration;
    [SerializeField] private float size;
    [SerializeField] private float speed;
    [SerializeField] private int power;

    protected override void Awake()
    {
        base.Awake();
        playerData = GetComponent<PlayerData>();
    }

    private void Start()
    {
        controller.OnBombEvent += UseAttack;
    }

    private void Update()
    {
        if (timeSinceLastBomb <= delayBomb)
            timeSinceLastBomb += Time.deltaTime;
    }

    public override void UseAttack()
    {
        if (timeSinceLastBomb > delayBomb)
        {
            if (playerData.SpendBomb())
            {
                GameObject projObj = Instantiate(projPref, position: projSpawnPos.transform.position, rotation: Quaternion.identity);

                ProjectileData projData = projObj.GetComponent<ProjectileData>();
                projData.duration = duration;
                projData.size = size;
                projData.speed = speed;
                projData.power = power;
                projData.type = playerData.playerNum;
                projData.targetTag = "EnemyHitPoint";
                projData.isInPool = false;
            }
        }
    }
}
