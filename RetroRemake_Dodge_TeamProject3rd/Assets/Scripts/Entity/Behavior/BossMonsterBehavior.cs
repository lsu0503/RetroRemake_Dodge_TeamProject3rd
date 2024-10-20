using UnityEngine;

public class BossMonsterBehavior: MonsterBehavior
{
    protected override void Start()
    {
        base.Start();
        OnDieEvent += EraseBulletsOnDie;
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
}