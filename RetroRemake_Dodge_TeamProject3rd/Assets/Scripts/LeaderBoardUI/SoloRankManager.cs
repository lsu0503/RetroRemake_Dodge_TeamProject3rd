using System;
using UnityEngine;

public class SoloRankManager : LeaderBoardManager
{
    private int[] SoloRankingList = new int[4];

    public void SoloRankUpdate(int playerScore1)
    {
        SoloRankChange(playerScore1);
    }

    private void SoloRankChange(int currentScore)
    {
        if (currentScore > PlayerPrefs.GetInt("SoloRank2", 0))
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
                PlayerPrefs.Save();
            }
        }
    }
}