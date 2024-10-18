using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuUI : MonoBehaviour
{
    public GameObject InGameMenu;

    public void OnPause()
    {
        if (Time.timeScale == 1f)
        {
            InGameMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            InGameMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
