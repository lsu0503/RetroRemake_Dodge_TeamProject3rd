using UnityEngine;

public class LeaderBoardRegistrator : MonoBehaviour
{
    private MultiRankManager multiRankManager;
    private SoloRankManager soloRankManager;

    private void Awake()
    {
        multiRankManager = GetComponent<MultiRankManager>();
        soloRankManager = GetComponent<SoloRankManager>();
    }
    public void SetLeaderBoard()
    {
        ScoreManager tmp = ScoreManager.instance;
        if (GameManager.Instance.isMultiplay)
        {
            multiRankManager.MultiRankUpdate(tmp.player1Score, tmp.player2Score);
        }
        else
        {
            soloRankManager.SoloRankUpdate(tmp.player1Score);
        }
    }
}