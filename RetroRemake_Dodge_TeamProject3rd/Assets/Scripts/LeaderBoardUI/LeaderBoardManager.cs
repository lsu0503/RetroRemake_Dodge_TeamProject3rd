using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public void ScoreUpdate(int playerScore1, int playerScore2)
    {
        if (GameManager.Instance.isMultiplay)
        {
            MultiRankUpdate(playerScore1,playerScore2);
        }
        else
        {
            SoloRankUpdate(playerScore1);
        }
    }

    protected virtual void MultiRankUpdate(int playerScore1, int playerScore2)
    {
        
    }

    protected virtual void SoloRankUpdate(int playerScore1)
    {
        
    }
}
    