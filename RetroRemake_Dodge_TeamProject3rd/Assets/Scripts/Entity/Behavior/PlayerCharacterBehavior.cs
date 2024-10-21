using System.ComponentModel;
using UnityEngine;

public class PlayerCharacterBehavior : CharacterBehavior
{
    private PlayerData data;
    private Controller controller;
    private float recoverTimeMax = 2.5f;
    public float recoverTimeCurrent { get; private set; }

    private bool isDie;

    private void Awake()
    {
        data = GetComponent<PlayerData>();
        controller = GetComponent<Controller>();
    }

    private void Start()
    {
        isDie = false;

        OnDieEvent += BulletEraseOnDie;
        OnDieEvent += OnDie;
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

    public override bool OnHit(ProjectileData projData)
    {
        if (recoverTimeCurrent >= recoverTimeMax)
        {
            CallHitEvent(projData);
            bool isDied = data.LoseLife();
            CallDieEvent();
            CallSpawnEvent();

            if (!isDied)
                StageManager.Instance.PlayerDie();

            return true;
        }

        else
            return false;
    }

    
    public void OnDie()
    {
        isDie = true;
    }

    public void BulletEraseOnDie()
    {
        foreach (GameObject projObj in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            ProjectileData projData = projObj.GetComponent<ProjectileData>();

            if (projData.type < 0)
            {
                if (projData.isInPool)
                    projObj.SetActive(false);

                else
                    Destroy(projObj);
            }
        }
    }

    public void LifeOver()
    {
        if (!data.isAlive)
            gameObject.SetActive(false);
    }

    public void OnSpwan()
    {
        if (data.isAlive)
        {
            if (data.playerNum == 0)
                transform.position = new Vector3(-14.5f, 2.5f, 0.0f);
            else
                transform.position = new Vector3(-14.5f, -2.5f, 0.0f);

            recoverTimeCurrent = -2.5f;

            isDie = false;

            gameObject.SetActive(true);
        }
    }
}
