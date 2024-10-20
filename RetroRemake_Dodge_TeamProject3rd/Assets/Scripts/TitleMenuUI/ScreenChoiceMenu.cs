using UnityEngine;
using UnityEngine.UI;

public class ScreenModeManager : MonoBehaviour
{
   
    [SerializeField] private GameObject windowModeIndicator;   
    [SerializeField] private GameObject fullscreenModeIndicator;

    private void Awake()
    {
        Screen.fullScreen = true;
    }

    private void Start()
    {
        UpdateIndicators();
    }

    // â ���� ��ȯ
    public void SetWindowMode()
    {
        if (!Screen.fullScreen)
        {
            return;
        }

        Screen.fullScreen = false; 
        UpdateIndicators(); 
        Debug.Log("â���� ����Ǿ����ϴ�.");
    }

    // Ǯ��ũ�� ���� ��ȯ
    public void SetFullscreenMode()
    {
        if (Screen.fullScreen) 
        {
            return;
        }

        Screen.fullScreen = true; 
        UpdateIndicators();
        Debug.Log("Ǯ��ũ�� ���� ����Ǿ����ϴ�.");
    }

    private void UpdateIndicators()
    {
        if (Screen.fullScreen)
        {
            windowModeIndicator.SetActive(false);  
            fullscreenModeIndicator.SetActive(true); 
        }
        else
        {
            windowModeIndicator.SetActive(true);  
            fullscreenModeIndicator.SetActive(false); 
        }
    }
}