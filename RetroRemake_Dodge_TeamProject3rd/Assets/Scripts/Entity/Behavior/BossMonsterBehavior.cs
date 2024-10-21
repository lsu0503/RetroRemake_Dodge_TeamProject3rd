using UnityEngine;

public class BossMonsterBehavior: MonsterBehavior
{
    private BossHealthUI healthUI;

    protected override void Start()
    {
        OnSpawnEvent += UpdateHealthBar;
        OnSpawnEvent += ActivateHealthBar;
        OnDieEvent += EraseBulletsOnDie;
        OnDieEvent += SetStageSetting;
        OnDieEvent += DeactivateHealthBar;
        base.Start();
        currentLife = data.life;
    }

    public override void GetDamage(ProjectileData projData)
    {
        base.GetDamage(projData);
        UpdateHealthBar();
    }

    public void EraseBulletsOnDie()
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

    public void SetStageSetting()
    {
        FieldScroll.SetScrollRestart();
        MonsterGenerator.Instance.SetBossDefeat();
    }

    public void ActivateHealthBar()
    {
        StageManager.Instance.SetBossHealthUIActivation(true);
    }

    public void UpdateHealthBar()
    {
        StageManager.Instance.SetBossHealthUIGaugeFillAmount(currentLife / (float)data.life);
    }

    public void DeactivateHealthBar()
    {
        StageManager.Instance.SetBossHealthUIActivation(false);
    }
}