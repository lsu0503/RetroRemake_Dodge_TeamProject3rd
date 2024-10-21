using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    [SerializeField] private GameObject SoloClearUi;
    [SerializeField] private GameObject MultiClearUi;
    [SerializeField] private GameObject DefeatUi;

    [SerializeField] private BossHealthUI bossHealthUI;

    private int alivePlayerAmount;

    public ObjectPool objectPool { get; private set; }
    public MonsterDictionary monsterDict { get; private set; }
    public bool isEnded { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        objectPool = GetComponent<ObjectPool>();
        monsterDict = GetComponent<MonsterDictionary>();
    }

    private void Start()
    {
        InitializeUi();

        if (GameManager.Instance.isMultiplay)
            alivePlayerAmount = 2;
        else
            alivePlayerAmount = 1;
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

    public void SetBossHealthUIActivation(bool isActive)
    {
        bossHealthUI.SetActiveUI(isActive);
    }

    public void SetBossHealthUIGaugeFillAmount(float amount)
    {
        bossHealthUI.SetGaugeFill(amount);
    }

    public void PlayerDie()
    {
        alivePlayerAmount--;
        if (alivePlayerAmount <= 0)
            GameOver(false);
    }

    public void GameOver(bool isCleared)
    {
        FieldScroll.SetScrollStop();
        Time.timeScale = 0.0f;

        if (isCleared)
            DisplayClearUI(GameManager.Instance.isMultiplay);

        else
            DisplayDefeatUI();
    }
}
