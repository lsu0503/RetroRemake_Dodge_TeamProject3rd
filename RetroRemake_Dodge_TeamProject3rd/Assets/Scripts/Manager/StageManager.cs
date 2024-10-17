using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public bool isCleared {  get; private set; }
    public bool GameOver { get; private set; }

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ClearUIDisplay(bool isMulti) 
    {

    }
    public void DefeatUIDisplay() 
    {

    }
}
