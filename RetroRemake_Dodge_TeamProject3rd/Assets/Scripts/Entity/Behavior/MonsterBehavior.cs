using UnityEngine;

public class MonsterBehavior : CharacterBehavior
{
    private MonsterData data;
    private int currentLife;
    private bool isDie;

    private void Awake()
    {
        data = new MonsterData();
    }

    protected virtual void Start()
    {
        currentLife = data.life;
        isDie = false;

        OnHitEvent += GetDamage;
        OnDieEvent += OnDie;
        
        CallSpawnEvent();
    }

    public void GetDamage(ProjectileData projData)
    {
        currentLife -= projData.power;

        if (currentLife < 0)
            CallDieEvent();
    }

    public virtual void OnDie()
    {
        isDie = true;

        foreach(SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        foreach(Controller controller in GetComponentsInChildren<Controller>())
        {
            controller.enabled = false;
        }

        Destroy(gameObject, 2.0f);
    }
}
