using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class LeaderBoardUI : MonoBehaviour
{
   
}

public class SoloRankUI : LeaderBoardUI
{
    [SerializeField] private TextMeshProUGUI[] SoloPlayerTextList;
    
    private void SoloSaveScore(int totalScore)
    {
       
    }
}
public class MultiRankUI : LeaderBoardUI
{
    [SerializeField] private List<TextMeshProUGUI> MultiPlayerTextList;
    private void MultiSaveScore(int totalScore)
    {

    }
}
