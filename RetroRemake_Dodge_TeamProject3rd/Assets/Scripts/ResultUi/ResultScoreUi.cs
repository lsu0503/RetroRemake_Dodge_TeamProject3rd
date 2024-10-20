using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ResultScoreUi : MonoBehaviour
{
    public int ResultLifeScore { get; private set; }
    public int ResultBombScore { get; private set; }

    PlayerData playerData;
    [SerializeField] private TextMeshProUGUI p1ResultLifeScoreText;
    [SerializeField] private TextMeshProUGUI p1ResultBombScoreText;
    [SerializeField] private TextMeshProUGUI p2ResultLifeScoreText;
    [SerializeField] private TextMeshProUGUI p2ResultBombScoreText;


    public void SetResultPlayer1ScoreUi()
    {
        p1ResultLifeScoreText.text = $"x {ResultLifeScore}";
        p1ResultBombScoreText.text = $"x {ResultBombScore}";


    }
    public void SetResultPlayer2ScoreUi()
    {
        p2ResultLifeScoreText.text = $"x {ResultLifeScore}";
        p2ResultBombScoreText.text = $"x {ResultBombScore}";
    }

    public void Specificityofhit(int playerNum)
    {
        int i;
        int j = 3; // 아직 몬스터 UI 만들기 전 임의적으로 선언

        for (i = 0; i < ScoreManager.instance.BDIList.Count; i++)
       {
            if(playerNum == 0)
            {

            }
            else if (playerNum == 1)
            {

            }
       }
        for(i = ScoreManager.instance.BDIList.Count; i < j; i++)
        {
            
        }

    }


}
