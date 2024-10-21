using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiRankUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] MultiPlayerTextList1;
    [SerializeField] private TextMeshProUGUI[] MultiPlayerTextList2;

    private void Start()
    {
        MultiLoadScore();
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
