using UnityEngine;

public class PlayerCharacterBehavior : CharacterBehavior
{
    private PlayerData data;
    private Controller controller;
    private float recoverTimeMax = 2.5f;
    public float recoverTimeCurrent { get; private set; }

    private void Awake()
    {
        data = GetComponent<PlayerData>();
        controller = GetComponent<Controller>();
    }

    private void Start()
    {
        OnDieEvent += BulletEraseOnDie;
        OnDieEvent += LifeOver;
        OnSpawnEvent += OnSpwan;
    }

    private void Update()
    {
        if (recoverTimeCurrent <= recoverTimeMax)
            recoverTimeCurrent += Time.deltaTime;

        if (recoverTimeCurrent < 0)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }

    public override bool OnHit(int damage)
    {
        if (recoverTimeCurrent >= recoverTimeMax)
        {
            CallHitEvent(damage);
            data.LoseLife();
            Invoke("CallDieEvent", 2.5f);
            Invoke("CallSpawnEvent", 5.0f);
            return true;
        }

        else
            return false;
    }

    private void BulletEraseOnDie()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 100.0f);
        foreach(Collider2D coll in colls)
        {
            GameObject projObj = coll.gameObject;

            if (projObj.CompareTag("Bullet"))
            {
                ProjectileData projData = projObj.GetComponent<ProjectileData>();

                if(projData.type < 0)
                    projObj.SetActive(false);
            }
        }
    }

    private void LifeOver()
    {
        if (!data.isAlive)
            gameObject.SetActive(false);
    }

    private void OnSpwan()
    {
        if (data.playerNum == 0)
            transform.position = new Vector3(-14.5f, 2.5f, 0.0f);
        else
            transform.position = new Vector3(-14.5f, -2.5f, 0.0f);

        recoverTimeCurrent = -2.5f;
    }
}
