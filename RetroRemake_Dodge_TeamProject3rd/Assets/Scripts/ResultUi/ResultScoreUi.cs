using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ResultScoreUi : MonoBehaviour
{
    private int totalScore;
    private int remainLife;
    private int remainBomb;

    [SerializeField] private TextMeshProUGUI totalScoreText;

    private void Awake()
    {

    }

    private void Update()
    {
        totalScoreText.text = $"{totalScore}";
    }

    //private void Specificityofhit(int playerNum)
    //{
    //    int i;
    //    int j = 3;

    //    for (i = 0; i < ScoreManager.instance.BDIList.Count; i++)
    //    {
    //        if (playerNum == 0)
    //        {
                
    //        }
    //        else
    //        {

    //        }
    //    }
    //    for (i = ScoreManager.instance.BDIList.Count; i < j; i++)
    //    {

    //    }
    //}

    private void CalculateTotalScore(int playerNum)
    {
        //totalScore = ScoreManager.instance.player1Score + ( remainLife * 1000000 ) + ( remainBomb * 100000 ) + ( 보스1 대미지 * 보스1 점수 ) + ( 보스2 대미지 * 보스2 점수 ) + ( 보스3 대미지 * 보스3 점수 )
    }
}
