using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public ObjectPool objectPool { get; private set; }

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
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        objectPool = GameObject.FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        InitializeUi();
    }

    public void InitializeUi()
    {
        if (SoloClearUi == true)
            SoloClearUi.SetActive(false);
        
        else if (MultiClearUi == true)
            MultiClearUi.SetActive(false);
        
        else if (DefeatUi == true)
            DefeatUi.SetActive(false);
    }
    public void GameClear()
    {
        GameOver = true;
        isCleared= true;

        DisplayClearUI(GameManager.Instance.isMultiplay);
    }

    public void GameDefeat() 
    {
        GameOver = true;
        isCleared= false;

        DisplayDefeatUI();
    }
    
    public void DisplayClearUI(bool isMulti) 
    {
        if (!isMulti)
            SoloClearUi.SetActive(true);

        else if (isMulti)
            MultiClearUi.SetActive(true);
    }

    public void DisplayDefeatUI() 
    {
        DefeatUi.SetActive(true);
    }
}
