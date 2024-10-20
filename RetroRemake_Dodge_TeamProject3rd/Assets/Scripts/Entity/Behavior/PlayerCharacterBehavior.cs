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
            data.LoseLife();
            Invoke("CallDieEvent", 2.5f);
            Invoke("CallSpawnEvent", 5.0f);
            return true;
        }

        else
            return false;
    }

    
    public void OnDie()
    {
        isDie = true;

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        foreach (Controller controller in GetComponentsInChildren<Controller>())
        {
            controller.enabled = false;
        }
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
        if (data.playerNum == 0)
            transform.position = new Vector3(-14.5f, 2.5f, 0.0f);
        else
            transform.position = new Vector3(-14.5f, -2.5f, 0.0f);

        recoverTimeCurrent = -2.5f;

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 1.0f;
            renderer.color = color;
        }

        foreach (Controller controller in GetComponentsInChildren<Controller>())
        {
            controller.enabled = true;
        }

        gameObject.SetActive(true);
    }
}
