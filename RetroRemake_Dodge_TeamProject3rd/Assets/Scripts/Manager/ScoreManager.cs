using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int player1Score { get; private set; }
    public int player2Score { get; private set; }
    

    public List<float[]> DamageRatio = new List<float[]>();  


    private void Awake()
    {
        instance = this;
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }

    public int GainScore(int playerNum, int amount)
    {
        switch (playerNum)
        {
            case 0:

                player1Score += amount;
                return player1Score;

            case 1:
                player2Score += amount;
                return player2Score;

            default:
                return -1;

        } 
    }
    public void AddDamage()
    {
        
    }
    
        
    
}
