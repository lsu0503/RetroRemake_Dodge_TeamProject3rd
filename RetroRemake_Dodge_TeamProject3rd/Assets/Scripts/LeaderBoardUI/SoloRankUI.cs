using System;
using TMPro;
using UnityEngine;

public class SoloRankUI : LeaderBoardUI
{
    [SerializeField] private TextMeshProUGUI[] SoloPlayerTextList;
    private int[] SoloRankingList = new int[4];

    private void Start()
    {
        SoloLoadScore();
    }

    private void SoloRankChange(int currentScore)
    {
        if (currentScore > PlayerPrefs.GetInt("SoloRank2",0))
        {
            for (int i = 0; i < 3; i++)
            {
                SoloRankingList[i] = PlayerPrefs.GetInt($"SoloRank{i}", 0);
            }

            SoloRankingList[3] = currentScore;
            Array.Sort(SoloRankingList);
            Array.Reverse(SoloRankingList);

            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt($"SoloRank{i}", SoloRankingList[i]);
            }
        }
    }

    private void SoloLoadScore()
    {
        for (int i = 0; i < 3; i ++)
        {
            SoloPlayerTextList[0].text = PlayerPrefs.GetInt($"SoloRank{i}",0).ToString("D10");
        }
    } 
}
