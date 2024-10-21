using UnityEngine;

public class MonsterData: MonoBehaviour
{
    protected CharacterBehavior behavior;

    public int life;
    [SerializeField] protected int scoreAcquireOnHit;
    [SerializeField] protected int scoreAcquireOnDefeat;

    protected int lastAttacked;

    private void Awake()
    {
        behavior = GetComponent<CharacterBehavior>();
    }

    protected virtual void Start()
    {
        behavior.OnHitEvent += SettleScoreOnHit;
        behavior.OnDieEvent += SettleScoreOnDefeat;
        lastAttacked = -1;
    }

    public void SettleScoreOnHit(ProjectileData projData)
    {
        lastAttacked = projData.type;
        ScoreManager.instance.GainScore(lastAttacked, projData.power * scoreAcquireOnHit);
    }

    public void SettleScoreOnDefeat()
    {
        ScoreManager.instance.GainScore(lastAttacked, scoreAcquireOnDefeat);
    }
}