using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
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
