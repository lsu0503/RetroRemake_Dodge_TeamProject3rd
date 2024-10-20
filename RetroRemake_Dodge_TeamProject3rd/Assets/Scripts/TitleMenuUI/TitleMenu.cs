using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] private GameObject SelectModeUI;
    [SerializeField] private GameObject TitleMenuUI;

    public void PushStartBtn()
    {
        SelectModeUI.SetActive(true);
        TitleMenuUI.SetActive(false);
    }

    public void PushExitBtn()
    {
        Application.Quit();
        Debug.Log("∞‘¿”≥°");
    }
}