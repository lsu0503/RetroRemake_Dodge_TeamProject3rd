using UnityEngine;

public class BossMonsterData : MonsterData
{
    [SerializeField] private Sprite charaImg;
    [SerializeField] private int scoreAcquirOnResult;
    [SerializeField] private int[] damageArray = new int[2];

    protected override void Start()
    {
        base.Start();
        behavior.OnHitEvent += AddDamageWhoAttacked;
        behavior.OnDieEvent += SettleScoreOnResult;
    }

    public void AddDamageWhoAttacked(ProjectileData projData)
    {
        damageArray[projData.type] += projData.power;
    }

    public void SettleScoreOnResult()
    {
        ScoreManager.instance.AddBossDefeatInformation(charaImg, scoreAcquirOnResult, damageArray);
    }
}