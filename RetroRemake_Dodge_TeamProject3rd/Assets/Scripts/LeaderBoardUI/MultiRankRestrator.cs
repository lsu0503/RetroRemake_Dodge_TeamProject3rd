using System;
using System.Collections.Generic;
using UnityEngine;

public struct ScoreSet
{
    public int player1Score;
    public int player2Score;
    public int totalScore;

    public ScoreSet(int _player1Score, int _player2Score)
    {
        player1Score = _player1Score;
        player2Score = _player2Score;
        totalScore = player1Score + player2Score;
    }
}

public class MultiRankRestrator : MonoBehaviour
{
    private ScoreSet[] scoreSets;

    private void OnDestroy()
    {
        ScoreManager temp = ScoreManager.instance;
        CalculateRank(new ScoreSet(temp.player1Score, temp.player2Score));
    }

    private void CalculateRank(ScoreSet curScore)
    {
        List<ScoreSet> rankList = new List<ScoreSet>();
        int[] player1RankList = new int[3];
        int[] player2RankList = new int[3];
        for (int i = 0; i < 3; i++)
        {
            player1RankList[i] = PlayerPrefs.GetInt($"Multi0Rank{i}", 0);
            player2RankList[i] = PlayerPrefs.GetInt($"Multi1Rank{i}", 0);
            rankList[i] = new ScoreSet(player1RankList[i], player2RankList[i]);
        }

        for(int i = 0; i < 3; i++)
        {
            if (rankList[i].totalScore < curScore.totalScore)
            {
                rankList.Insert(i, curScore);
                break;
            }
        }

        for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt($"Multi0Rank{i}", rankList[i].player1Score);
            PlayerPrefs.SetInt($"Multi1Rank{i}", rankList[i].player2Score);
        }
    }
}
