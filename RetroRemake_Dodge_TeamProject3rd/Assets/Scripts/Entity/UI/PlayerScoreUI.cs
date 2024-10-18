using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreMesh;
    [SerializeField] private TextMeshProUGUI playerNumberText;

    public void UpdateScore(int playerNum)
    {
        switch (playerNum)
        {
            case 0:
                playerNumberText.text = "P1";
                playerNumberText.text = ScoreManager.instance.player1Score.ToString();
                break;
            case 1:
                playerNumberText.text = "P2";
                playerNumberText.text = ScoreManager.instance.player2Score.ToString();
                break;
        }
    }
}
