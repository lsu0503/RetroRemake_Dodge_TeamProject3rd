using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayModeMenu : MonoBehaviour
{
    public GameObject SelectModeUI;
    public GameObject TitleMenuUI;

    public void PushSoloPlayBtn() 
    {
        GameManager.Instance.isMultiplay = false; 
   
        SceneManager.LoadScene("MainScene");
    }

    public void PushMultiPlayBtn()
    {
        GameManager.Instance.isMultiplay = true; 
        
        SceneManager.LoadScene("MainScene");
    }

    public void PushBackBtn()
    {
        SelectModeUI.SetActive(false);
        TitleMenuUI.SetActive(true);
    }

}
