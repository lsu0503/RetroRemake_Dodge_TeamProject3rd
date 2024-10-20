using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtnUi : MonoBehaviour
{
    [SerializeField] private GameObject playerdifficultyChoice;
    [SerializeField] private GameObject PlayMenu;

    private void PlayerDifficultyUI() 
    {
        playerdifficultyChoice.SetActive(true);
    }

    private void PlayMenuUI()
    {
        PlayMenu.SetActive(false);
    }

    private void GameOff()
    {
        Application.Quit();
        Debug.Log("∞‘¿”≥°");
    }

}
