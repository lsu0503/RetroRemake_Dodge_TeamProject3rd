using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUiButton : MonoBehaviour
{
    public void ReturnTitileBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
    }
    public void RetryBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}
