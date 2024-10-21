using UnityEngine;

public class MinionAttack : MonsterAttack
{
    [Header("Bullet Info")]
    [SerializeField] private float duration;
    [SerializeField] private float size;
    [SerializeField] private float speed;

    [Header("Shooting Info")]
    [SerializeField] private Transform projSpawnPos;
    [SerializeField] private float projAngleSpace;
    [SerializeField] private int projsPerShot;

    public override void UseAttack()
    {
        if (monsterData.actionSelector == 0)
        {
            Transform targetTransform = SetTargetTransform();

            float minAngle = -(projsPerShot - 1) / 2f * projAngleSpace;

            for (int i = 0; i < projsPerShot; i++)
                CreateProjectile(minAngle + (projAngleSpace * i));
        }
    }

    private void CreateProjectile(float angle)
    {
        GameObject projObj = Instantiate(projPrefs[0]);
        projObj.SetActive(false);
        projObj.transform.position = projSpawnPos.position;
        projObj.transform.right = Quaternion.Euler(0.0f, 0.0f, angle) * (-transform.right);

        ProjectileData projData = projObj.GetComponent<ProjectileData>();
        projData.duration = duration;
        projData.size = size;
        projData.speed = speed;
        projData.power = 0;
        projData.type = -1;
        projData.targetTag = "Player";
        projData.isInPool = false;

        projData.InitializeTime();
        projObj.SetActive(true);
    }
}