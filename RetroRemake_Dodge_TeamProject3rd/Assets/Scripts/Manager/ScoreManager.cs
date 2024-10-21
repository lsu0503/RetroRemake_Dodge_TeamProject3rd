using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BossDefeatInformation
{
    public Sprite bossImg;
    public int totalScore;
    public float[] damageRatio;

    public BossDefeatInformation(Sprite _bossImg, int _totalScore, int[] _damageAmount)
    {
        bossImg = _bossImg;
        totalScore = _totalScore;
        
        int totalDamage = 0;
        List<float> damageRatioList = new List<float>();
        int i;
        for (i = 0; i < _damageAmount.Length; i++)
            totalDamage += _damageAmount[i];

        for(i = 0; i < _damageAmount.Length; i++)
            damageRatioList.Add(_damageAmount[i]/totalDamage);

        damageRatio = damageRatioList.ToArray();
    }
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int player1Score;
    public int player2Score;
    
    public List<BossDefeatInformation> BDIList = new List<BossDefeatInformation>();

    private void Awake()
    {
        instance = this;
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }

    public int GainScore(int playerNum, int amount)
    {
        switch (playerNum)
        {
            case 0:

                player1Score += amount;
                return player1Score;

            case 1:
                player2Score += amount;
                return player2Score;

            default:
                return -1;

        } 
    }

    public void AddBossDefeatInformation(Sprite _img, int _totalScore, int[] _damageList)
    {
        BossDefeatInformation _b_d_i = new BossDefeatInformation(_img, _totalScore, _damageList);
        BDIList.Add(_b_d_i);
    }
}
