using System;
using UnityEngine;

public class SoloRankRestrator : MonoBehaviour
{
    private void OnDestroy()
    {
        ScoreManager temp = ScoreManager.instance;
        CalulateSoloRank(temp.player1Score);
    }

    private void CalulateSoloRank(int currentScore)
    {
        int[] SoloRankList = new int[3];
        int saveNum ;

        for (int i = 0; i < 3; i++)
        {
            SoloRankList[i] = PlayerPrefs.GetInt($"SoloRank{i}", 0);
        }

        for(int i = 0; i < 3; i++)
        {
            if (SoloRankList[i] < currentScore)
            {
                saveNum = SoloRankList[i];
                SoloRankList[i] =currentScore;
                currentScore = saveNum;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt($"SoloRank{i}", SoloRankList[i]);
        }
    }
}