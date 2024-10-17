using System.Collections;
using System.Collections.Generic;

public class PlayerData
{
    public int life { get; private set; }
    public int bomb { get; private set; }

    public bool LoseLife()
    {
        life--;
        if (life < 0)
        {
            OnDeath();
            return false;
        }

        else
            return true;
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
            return true;
        }
        else
            return false;
    }

    public bool GetBomg()
    {
        if(bomb < 5)
        {
            bomb++;
            return true;
        }
        else
            return false;
    }

    public void OnDeath()
    {

    }
}
