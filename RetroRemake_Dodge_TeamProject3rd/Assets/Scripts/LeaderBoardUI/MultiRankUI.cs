using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiRankUI : LeaderBoardUI
{
    [SerializeField] private TextMeshProUGUI[] MultiPlayerTextList1;
    [SerializeField] private TextMeshProUGUI[] MultiPlayerTextList2;

    private int[] MultiRankingList1 = new int[4];
    private int[] MultiRankingList2 = new int[4];

    private void Start()
    {
        MultiLoadScore();
    }

    private void MultiRankChangeP1(int currentScore1)
    {
        if (currentScore1 > PlayerPrefs.GetInt($"Multi0Rank2,", 0) )
        {
            for (int i = 0; i < 3; i++)
            {
                MultiRankingList1[i] = PlayerPrefs.GetInt($"Multi0Rank{i}", 0);
            }

            MultiRankingList1[3] = currentScore1;
            Array.Sort(MultiRankingList1);
            Array.Reverse(MultiRankingList1);

            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt($"Multi0Rank{i}", MultiRankingList1[i]);
                PlayerPrefs.Save();
            }
        }
    }

    private void MultiRankChangeP2(int currentScore2)
    {
        if ( currentScore2 > PlayerPrefs.GetInt($"Multi1Rank2,", 0))
        {
            for (int i = 0; i < 3; i++)
            {
                MultiRankingList2[i] = PlayerPrefs.GetInt($"Multi1Rank{i}", 0);
            }

            MultiRankingList2[3] = currentScore2;
            Array.Sort(MultiRankingList2);
            Array.Reverse(MultiRankingList2);

            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt($"Multi1Rank{i}", MultiRankingList2[i]);
                PlayerPrefs.Save();
            }
        }
    }

    private void MultiLoadScore()
    {
        for (int i = 0; i < 3; i++)
        {
            MultiPlayerTextList1[i].text = PlayerPrefs.GetInt($"Multi0Rank{i}", 0).ToString("D10");
            MultiPlayerTextList2[i].text = PlayerPrefs.GetInt($"Multi1Rank{i}", 0).ToString("D10");
        }
    }
}
