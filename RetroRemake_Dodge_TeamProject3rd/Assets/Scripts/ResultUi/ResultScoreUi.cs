using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ResultScoreUi : MonoBehaviour
{
    public int ResultLifeScore { get; private set; }
    public int ResultBombScore { get; private set; }


    [SerializeField] private TextMeshProUGUI p1ResultLifeScoreText;
    [SerializeField] private TextMeshProUGUI p1ResultBombScoreText;
    [SerializeField] private TextMeshProUGUI p2ResultLifeScoreText;
    [SerializeField] private TextMeshProUGUI p2ResultBombScoreText;


    public void SetResultPlayerScoreUi()
    {
        p1ResultLifeScoreText.text = ResultLifeScore.ToString();
        p1ResultBombScoreText.text = ResultBombScore.ToString();
        p2ResultLifeScoreText.text = ResultLifeScore.ToString();
        p2ResultBombScoreText.text = ResultBombScore.ToString();

    }

    public void Specificityofhit(int playerNum)
    {
        int i;
        int j = 3; // ���� ���� UI ����� �� ���������� ����

        for (i = 0; i < ScoreManager.instance.DamageRatio.Count; i++)
       {
            if(playerNum == 0)
            {

            }
            else if (playerNum == 1)
            {

            }
       }
        for(i = ScoreManager.instance.DamageRatio.Count; i < j; i++)
        {
            
        }

    }


}
