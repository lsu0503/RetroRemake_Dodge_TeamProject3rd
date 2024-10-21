public class BossAttack : MonsterAttack
{
    private int difficulty;

    protected override void Start()
    {
        base.Start();
        difficulty = GameManager.Instance.difficulty;
    }

    public override void UseAttack()
    {
        float angle = 180.0f;
        if (isLockOn)
            angle = SetTargetTransform();

        float minAngle = -(projsPerShot[difficulty] - 1) / 2f * projAngleSpace[difficulty];

        for (int j = 0; j < shotsPerAttack[difficulty]; j++)
        {
            for (int i = 0; i < projsPerShot[difficulty]; i++)
            {
                CreateProjectile(angle + minAngle + (projAngleSpace[difficulty] * i), speed - (shotVelTerm[difficulty] * j), projPrefsNum[difficulty]);
            }
        }
    }
}