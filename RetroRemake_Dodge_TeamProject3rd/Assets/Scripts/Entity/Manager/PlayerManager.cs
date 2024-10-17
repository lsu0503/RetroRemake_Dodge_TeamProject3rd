using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] public PlayerData player1Data { get; private set; }
    [SerializeField] private PlayerInfoUIHandler player1Info;

    [SerializeField] public PlayerData? player2Data { get; private set;}
    [SerializeField] private PlayerInfoUIHandler? player2Info;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if(instance != this)
            Destroy(gameObject);

        player1Data = new PlayerData();
        player2Data = new PlayerData();
    }

    public bool PlayerDeath(int playerNum)
    {
        bool isLifeRemain = true;

        switch (playerNum)
        {
            case 0:
                isLifeRemain = player1Data.LoseLife();
                player1Info.UpdatePlayerLife();
                break;
            case 1:
                if (player2Data != null)
                {
                    isLifeRemain = player2Data.LoseLife();
                    player2Info.UpdatePlayerLife();
                }
                break;
        }

        return isLifeRemain;
    }
}
