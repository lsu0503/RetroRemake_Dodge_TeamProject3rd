using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance;

    [SerializeField] private GameObject SoloClearUi;
    [SerializeField] private GameObject MultiClearUi;
    [SerializeField] private GameObject DefeatUi;
    
    
    PlayerData Player1;
    PlayerData? Player2;

    public bool isCleared {  get; private set; }
    public bool GameOver { get; private set; } = false;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
           
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        InitializeUi();
    }

    public void InitializeUi()
    {
        if (SoloClearUi == true)
        {
            SoloClearUi.SetActive(false);
        }
        else if (MultiClearUi == true)
        {
            MultiClearUi.SetActive(false);
        }
        else if (DefeatUi == true)
        {
            DefeatUi.SetActive(false);
        }
    }


    public void DisplayClearUI(bool isMulti) 
    {

        if (!isMulti)
        {
            SoloClearUi.SetActive(true);
        }
        else if (isMulti)
        {
            MultiClearUi.SetActive(true);  
        }
    }
    public void DisplayDefeatUI() 
    {
        DefeatUi.SetActive(true);
    }
    
}
