﻿using UnityEngine;

public class MonsterBehavior : CharacterBehavior
{
    protected MonsterData data;
    protected int currentLife;
    protected bool isDie;

    private void Awake()
    {
        data = GetComponent<MonsterData>();
    }

    protected virtual void Start()
    {
        currentLife = data.life;

        if (MonsterGenerator.Instance.level >= 2)
            currentLife *= 15;

        isDie = false;

        OnHitEvent += GetDamage;
        OnDieEvent += OnDie;
        
        CallSpawnEvent();
    }

    public virtual void GetDamage(ProjectileData projData)
    {
        currentLife -= projData.power;

        if (currentLife < 0 && !isDie)
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

        Destroy(gameObject);
    }
}
