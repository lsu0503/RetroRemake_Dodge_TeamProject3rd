using System;
using TMPro;
using UnityEngine;

public class SoloRankUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] SoloPlayerTextList;
    
    private void Start()
    {
        SoloLoadScore();
    }

    private void SoloLoadScore()
    {
        for (int i = 0; i < 3; i ++)
        {
            SoloPlayerTextList[i].text = PlayerPrefs.GetInt($"SoloRank{i}",0).ToString("D10");
        }
    } 
}
