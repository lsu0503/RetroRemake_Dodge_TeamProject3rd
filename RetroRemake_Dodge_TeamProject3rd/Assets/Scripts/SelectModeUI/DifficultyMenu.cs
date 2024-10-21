using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyMenu : MonoBehaviour
{
    public GameObject EasyBtnIndicator;
    public GameObject NormalBtnIndicator;
    public GameObject HardBtnIndicator;

    private void Start()
    {
        GameManager.Instance.difficulty = 0;
    }
    public void EasyBtnPressed()
    {
        SetDifficulty(0); // 이지 난이도로 설정
    }

    public void NormalBtnPressed()
    {
        SetDifficulty(1); // 노말 난이도로 설정
    }

    public void HardBtnPressed()
    {
        SetDifficulty(2); // 하드 난이도로 설정
    }

    private void SetDifficulty(int difficulty)
    {
        GameManager.Instance.difficulty = difficulty;

        SetTriangle(difficulty);
    }
    private void SetTriangle(int difficulty)
    {
        EasyBtnIndicator.SetActive(false);
        NormalBtnIndicator.SetActive(false);
        HardBtnIndicator.SetActive(false);

        switch (difficulty)
        {
            case 0:
                EasyBtnIndicator.SetActive(true);
                break;
            case 1:
                NormalBtnIndicator.SetActive(true);
                break;
            case 2:
                HardBtnIndicator.SetActive(true);
                break;
        }
    }

}
