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
        // 초기 상태를 풀스크린 모드로 설정
        UpdateIndicators();
    }

    // 창 모드로 전환
    public void SetWindowMode()
    {
        if (!Screen.fullScreen)
        {
            return;
        }

        Screen.fullScreen = false; 
        UpdateIndicators(); 
        Debug.Log("창모드로 변경되었습니다.");
    }

    // 풀스크린 모드로 전환
    public void SetFullscreenMode()
    {
        if (Screen.fullScreen) 
        {
            return;
        }

        Screen.fullScreen = true; 
        UpdateIndicators();
        Debug.Log("풀스크린 모드로 변경되었습니다.");
    }

    private void UpdateIndicators()
    {
        if (Screen.fullScreen)
        {
            windowModeIndicator.SetActive(false);  // 창 모드 표시 비활성화
            fullscreenModeIndicator.SetActive(true); // 풀스크린 모드 표시 활성화
        }
        else
        {
            windowModeIndicator.SetActive(true);  // 창 모드 표시 활성화
            fullscreenModeIndicator.SetActive(false); // 풀스크린 모드 표시 비활성화
        }
    }
}