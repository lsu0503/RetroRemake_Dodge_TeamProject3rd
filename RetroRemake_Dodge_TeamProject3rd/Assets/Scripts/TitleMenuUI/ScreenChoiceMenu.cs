using UnityEngine;
using UnityEngine.UI;

public class ScreenChoiceMenu : MonoBehaviour
{
    public GameObject windowModeIndicator;
    public GameObject fullscreenModeIndicator;

    private void Start()
    {
        SetFullScreenMode();
    }

    public void SetFullScreenMode()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(1920, 1080, true);
        SetTriangle();
    }

    public void SetWindowMode()
    {
        Screen.fullScreen = false;
        SetTriangle();
    }

    private void SetTriangle()
    {
        if (Screen.fullScreen)
        {
            fullscreenModeIndicator.SetActive(false);
            windowModeIndicator.SetActive(true);
        }
        else
        {
            fullscreenModeIndicator.SetActive(true);
            windowModeIndicator.SetActive(false);
        }
    }

}