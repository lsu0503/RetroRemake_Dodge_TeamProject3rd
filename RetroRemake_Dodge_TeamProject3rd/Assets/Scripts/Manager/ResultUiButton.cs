using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUiButton : MonoBehaviour
{
    public void ReturnTitile()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
