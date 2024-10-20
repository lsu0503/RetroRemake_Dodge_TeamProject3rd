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
        // �ʱ� ���¸� Ǯ��ũ�� ���� ����
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
            windowModeIndicator.SetActive(false);  // â ��� ǥ�� ��Ȱ��ȭ
            fullscreenModeIndicator.SetActive(true); // Ǯ��ũ�� ��� ǥ�� Ȱ��ȭ
        }
        else
        {
            windowModeIndicator.SetActive(true);  // â ��� ǥ�� Ȱ��ȭ
            fullscreenModeIndicator.SetActive(false); // Ǯ��ũ�� ��� ǥ�� ��Ȱ��ȭ
        }
    }
}