using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUIHandler: MonoBehaviour
{
    [SerializeField] private List<PlayerLifeUI> lifeIcons;
    [SerializeField] private List<PlayerBombUI> bombIcons;
    [SerializeField] private PlayerScoreUI scoreHandler;

    private PlayerData thisPlayerData;
    [SerializeField] private int playerNum;

    [SerializeField] private Image imageComponent;
    [SerializeField] private Sprite[] characterImg;

    [SerializeField] private CharacterBehavior behavior;
    [SerializeField] private Controller controller;

    private void Start()
    {
        if (playerNum == 0)
        {
            thisPlayerData = PlayerManager.instance.player1Data;
            imageComponent.sprite = characterImg[0];
        }
        else if (playerNum == 1)
        {
            if (GameManager.Instance.isMultiplay)
            {
                thisPlayerData = PlayerManager.instance.player2Data;
                imageComponent.sprite = characterImg[1];
            }

            else
            {
                Destroy(gameObject);
                return;
            }
        }

        UpdatePlayerLife();
        UpdatePlayerBomb();
        UpdatePlayerScore();

        behavior.OnDieEvent += UpdatePlayerLife;
        controller.OnBombEvent += UpdatePlayerBomb;
        
    }

    private void Update()
    {
        if (!ResultManager.Instance.GameOver)
            UpdatePlayerScore();
    }

    public void UpdatePlayerLife()
    {
        int i;

        for(i = 0; i < thisPlayerData.life; i++)
        {
            lifeIcons[i].SetLife(1);
        }

        for(i = thisPlayerData.life; i < lifeIcons.Count; i++)
        {
            lifeIcons[i].SetLife(0);
        }
    }

    public void UpdatePlayerBomb()
    {
        int i;

        for (i = 0; i < thisPlayerData.bomb; i++)
        {
            bombIcons[i].SetBomb(true);
        }

        for (i = thisPlayerData.bomb; i < bombIcons.Count; i++)
        {
            bombIcons[i].SetBomb(false);
        }
    }

    public void UpdatePlayerScore()
    {
        scoreHandler.UpdateScore(playerNum);
    }
}