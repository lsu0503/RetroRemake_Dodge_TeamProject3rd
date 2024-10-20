using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDifficultyUI : MonoBehaviour
{
    public GameObject playerdifficultyChoice;
    public GameObject playMenu;


    public void SinglePlay() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MultiPlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackPlayBtnUI()
    {
        playerdifficultyChoice.SetActive(false);
        playMenu.SetActive(true);
    }

}
