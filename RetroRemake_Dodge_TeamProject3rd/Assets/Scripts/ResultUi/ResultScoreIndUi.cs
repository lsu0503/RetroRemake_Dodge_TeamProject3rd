using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ResultScoreIndUi : MonoBehaviour
{
    private int totalScore;

    [SerializeField] private int playerNum;

    private int scorePerLife = 1000000;
    private int scorePerBomb = 100000;

    private List<int> bossScore = new List<int>();

    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private Transform bossResultCollectionObj;
    [SerializeField] private GameObject bossResultInd;

    [SerializeField] private PlayerData playerData;

    private void OnEnable()
    {
        CalculateBossScore(playerNum);
        CalculateTotalScore(playerNum);
        InstantiateBossResultInd();
    }

    private void CalculateBossScore(int playerNum)
    {
        int i;

        for (i = 0; i < ScoreManager.instance.BDIList.Count; i++)
        {
            if (playerNum == 0)
            {
                bossScore.Add(ScoreManager.instance.BDIList[i].totalScore * (int)ScoreManager.instance.BDIList[i].damageRatio[playerNum]);
            }
            else if (playerNum == 1)
            {
                bossScore.Add(ScoreManager.instance.BDIList[i].totalScore * (int)ScoreManager.instance.BDIList[i].damageRatio[playerNum]);
            }
        }
    }

    private void CalculateTotalScore(int playerNum)
    {
        switch(playerNum)
        {
            case 0:
                totalScore = ScoreManager.instance.player1Score;
                break;
            case 1:
                totalScore = ScoreManager.instance.player2Score;
                break;
        }
        
        totalScore += (playerData.life * scorePerLife) + (playerData.bomb * scorePerBomb);

        for (int i = 0; i < bossScore.Count; i++)
        {
            totalScore += bossScore[i];
        }
        if (playerNum == 0)
        {
            ScoreManager.instance.player1Score = totalScore;
        }
        else
        {
            ScoreManager.instance.player2Score = totalScore;
        }
        totalScoreText.text = $"{totalScore}";
    }

    private void InstantiateBossResultInd()
    {
        List<BossDefeatInformation> bdiList = ScoreManager.instance.BDIList;

        for (int i = 0; i < bdiList.Count; i++)
        {
            GameObject currentUI = Instantiate(bossResultInd, bossResultCollectionObj);
            BossResultUI currentUIComponent = currentUI.GetComponent<BossResultUI>();
            currentUIComponent.UpdateUI(bdiList[i], playerNum);
        }
    }
}
