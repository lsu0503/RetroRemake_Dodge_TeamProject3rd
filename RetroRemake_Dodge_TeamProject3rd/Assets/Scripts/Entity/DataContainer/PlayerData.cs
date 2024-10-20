using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private PlayerInfoUIHandler uiHandler;

    public int playerNum;
    public int life { get; private set; }
    public int bomb { get; private set; }
    public bool isAlive { get; private set; }

    private void Awake()
    {
        life = 3;
        bomb = 3;
        isAlive = true;
    }

    public bool LoseLife()
    {
        life--;
        if (life < 0)
        {
            OnDeath();
            return false;
        }

        else
        {
            bomb += 2;

            if (bomb > 5)
                bomb = 5;

            return true;
        }
    }

    public bool SpendBomb()
    {
        if (bomb > 0)
        {
            bomb--;
            return true;
        }

        else
            return false;
    }

    public bool GetLife()
    {
        if(life < 5)
        {
            life++;
            uiHandler.UpdatePlayerLife();
            return true;
        }
        else
            return false;
    }

    public bool GetBomb()
    {
        if(bomb < 5)
        {
            bomb++;
            uiHandler.UpdatePlayerBomb();
            return true;
        }
        else
            return false;
    }

    public void OnDeath()
    {
        isAlive = false;
    }
}
