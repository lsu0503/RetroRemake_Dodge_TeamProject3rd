using Unity.VisualScripting;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public static MonsterGenerator Instance;

    [Header("Generation Info")]
    private MonsterDictionary monsterDict;
    [SerializeField] private float generateXPos = 18.0f;
    [SerializeField] private float generateYPosUpperCap = 6.0f;
    [SerializeField] private float generateYPosUnderCap = -5.5f;
    [SerializeField] private int minionDictAmount = 5;

    [Header("Difficulty Info")]
    private bool isBossTime;
    [SerializeField] private float[] generateTimePerDifficulty = new float[] { 5.0f, 4.0f, 3.2f };
    private float triggerTimecurrent;
    [SerializeField] private int[] gererateAmountPerDifficulty = new int[] { 5, 8, 12 };
    private int generateTriggerCount;
    [SerializeField] private int[] BossEncounterCount = new int[] { 5, 8, 12 };
    private int difficulty;
    public int level;
    private bool isLegionSpawned;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        monsterDict = GetComponent<MonsterDictionary>();
    }

    private void Start()
    {
        isBossTime = false;
        difficulty = GameManager.Instance.difficulty;
        triggerTimecurrent = 0.0f;
        generateTriggerCount = 0;
        level = 0;
        isLegionSpawned = false;
    }

    private void FixedUpdate()
    {
        if (!isBossTime)
        {
            triggerTimecurrent += Time.deltaTime;

            if (level < 2)
            {
                if (triggerTimecurrent >= generateTimePerDifficulty[difficulty])
                {
                    triggerTimecurrent -= generateTimePerDifficulty[difficulty];

                    if (generateTriggerCount >= BossEncounterCount[difficulty])
                    {
                        EraseBulletOnBossSpawn();
                        SpawnBoss(level);
                        FieldScroll.SetScrollStop();
                        generateTriggerCount = 0;
                        level++;
                        isBossTime = true;
                    }

                    else
                    {
                        for (int i = 0; i < gererateAmountPerDifficulty[difficulty]; i++)
                            spawnMinion();

                        generateTriggerCount++;
                    }
                }
            }

            else
            {
                if (triggerTimecurrent >= 10.0f && !isLegionSpawned)
                {
                    FieldScroll.SetScrollStop();
                    spawnLegion();
                    isLegionSpawned = true;
                }
                
                if (triggerTimecurrent >= 40.0f)
                {
                    EraseBulletOnBossSpawn();
                    SpawnBoss(2);
                    isBossTime = true;
                }
            }
        }
    }

    private void spawnMinion()
    {
        float posY = Random.Range(generateYPosUnderCap, generateYPosUpperCap);
        int unitNum = Random.Range(0, minionDictAmount);
        GameObject spawnObj = monsterDict.InstanciateMonster(unitNum);
        spawnObj.transform.position = new Vector2(generateXPos, posY);
        spawnObj.SetActive(true);
    }

    private void spawnLegion()
    {
        for(int i = 0; i < minionDictAmount; i++)
        {
            GameObject spawnObj = monsterDict.InstanciateMonster(i);
            spawnObj.transform.position = new Vector2(generateXPos, ((minionDictAmount / 2) - i) * 2.0f );
            spawnObj.SetActive(true);
        }
    }

    private void EraseBulletOnBossSpawn()
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

        foreach (GameObject enemyObj in GameObject.FindGameObjectsWithTag("Enemy"))
            Destroy(enemyObj);
    }

    private void SpawnBoss(int level)
    {
        GameObject spawnObj = monsterDict.InstanciateMonster(minionDictAmount + level);
        spawnObj.transform.position = new Vector2(generateXPos, 0.0f);
        spawnObj.SetActive(true);
    }

    public void SetBossDefeat()
    {
        isBossTime = false;
    }
}