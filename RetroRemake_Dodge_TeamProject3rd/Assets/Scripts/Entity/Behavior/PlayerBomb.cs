using UnityEngine;

public class PlayerBomb : AttackBase
{
    private PlayerData data;
    [SerializeField] private Transform projSpawnPos;
    [SerializeField] private GameObject projPref;
    [SerializeField] float delayBomb;
    private float timeSinceLastBomb = float.MaxValue;

    protected override void Awake()
    {
        base.Awake();
        data = GetComponent<PlayerData>();
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
            if (data.SpendBomb())
            {
                GameObject projObj = Instantiate(projPref, position: projSpawnPos.transform.position, rotation: Quaternion.identity);
            }
        }
    }
}
