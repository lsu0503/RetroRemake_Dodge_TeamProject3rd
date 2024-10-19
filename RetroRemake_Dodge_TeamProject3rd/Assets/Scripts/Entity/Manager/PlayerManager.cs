using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public PlayerData player1Data;
    [SerializeField] private PlayerInfoUIHandler player1Info;

    public PlayerData? player2Data;
    [SerializeField] private PlayerInfoUIHandler? player2Info;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if(instance != this)
            Destroy(gameObject);
    }
}
