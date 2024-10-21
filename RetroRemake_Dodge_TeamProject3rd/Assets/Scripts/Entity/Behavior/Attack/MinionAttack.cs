using UnityEngine;

public class MinionAttack : MonsterAttack
{
    private int level;

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
                CreateProjectile(angle + minAngle + (projAngleSpace[level] * i), speed - (shotVelTerm[level] * j), projPrefsNum[level]);
            }
        }
    }
}