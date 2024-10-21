using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayModeMenu : MonoBehaviour
{
    [SerializeField] private GameObject SelectModeUI;
    [SerializeField] private GameObject TitleMenuUI;
    [SerializeField] private GameObject LeaderBoard;

    private void PushSoloPlayBtn() 
    {
        GameManager.Instance.isMultiplay = false; 
   
        SceneManager.LoadScene("MainScene");
    }

    private void PushMultiPlayBtn()
    {
        GameManager.Instance.isMultiplay = true; 
        
        SceneManager.LoadScene("MainScene");
    }

    private void PushBackBtn()
    {
        SelectModeUI.SetActive(false);
        TitleMenuUI.SetActive(true);
        LeaderBoard.SetActive(true);
    }

}
