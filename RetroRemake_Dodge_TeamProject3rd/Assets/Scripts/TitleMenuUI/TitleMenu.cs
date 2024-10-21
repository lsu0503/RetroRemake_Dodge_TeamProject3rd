using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] private GameObject SelectModeUI;
    [SerializeField] private GameObject TitleMenuUI;
    [SerializeField] private GameObject LeaderBoard;

    public void Start()
    {
        SoundManager.Instance.PlayBgm(0);
    }

    public void PushStartBtn()
    {
        SelectModeUI.SetActive(true);
        TitleMenuUI.SetActive(false);
        LeaderBoard.SetActive(false);
    }

    public void PushExitBtn()
    {
        Application.Quit();
        Debug.Log("∞‘¿”≥°");
    }
}