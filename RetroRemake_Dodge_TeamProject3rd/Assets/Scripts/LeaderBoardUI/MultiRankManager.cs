using System;
using UnityEngine;

public class MultiRankManager : LeaderBoardManager
{
    private int[] MultiRankingList1 = new int[4];
    private int[] MultiRankingList2 = new int[4];

    protected override void MultiRankUpdate(int playerScore1, int playerScore2)
    {
        MultiRankChangeP1(playerScore1);
        MultiRankChangeP2(playerScore2);
    }

    private void MultiRankChangeP1(int currentScore1)
    {
        if (currentScore1 > PlayerPrefs.GetInt($"Multi0Rank2,", 0))
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
        if (currentScore2 > PlayerPrefs.GetInt($"Multi1Rank2,", 0))
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
}
