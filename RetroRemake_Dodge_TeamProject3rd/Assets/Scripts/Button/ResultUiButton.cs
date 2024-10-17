using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUiButton : MonoBehaviour
{
    public void ReturnTitileBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
