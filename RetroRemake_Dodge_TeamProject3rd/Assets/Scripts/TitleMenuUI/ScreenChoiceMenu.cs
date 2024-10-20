using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChoiceMenu : MonoBehaviour
{
    [SerializeField] private Button windowModeBtn;     // 창모드 버튼
    [SerializeField] private Button fullscreenModeBtn; // 풀스크린 버튼
    [SerializeField] private GameObject windowModeIndicator;   // 창모드 상태를 표시할 삼각형 이미지
    [SerializeField] private GameObject fullscreenModeIndicator; // 풀스크린 상태를 표시할 삼각형 이미지

    private void Start()
    {
        // 초기 상태를 풀스크린으로 설정
        SetFullscreenMode(); // 풀스크린 모드로 시작
    }

    // 창 모드로 전환
    public void SetWindowMode()
    {
        if (Screen.fullScreen) // 이미 풀스크린 모드이면 창 모드로 전환
        {
            Screen.fullScreen = false; // 창 모드로 전환
            Debug.Log("창모드로 변경되었습니다.");
            Triangle(); // UI 업데이트
        }
        else
        {
            Debug.Log("이미 창모드입니다."); // 디버그 로그 추가
        }
    }

    // 풀스크린 모드로 전환
    public void SetFullscreenMode()
    {
        if (!Screen.fullScreen) // 이미 창 모드이면 풀스크린으로 전환
        {
            Screen.fullScreen = true; // 풀스크린 모드로 전환
            Debug.Log("풀스크린 모드로 변경되었습니다.");
            Triangle(); // UI 업데이트
        }
        else
        {
            Debug.Log("이미 풀스크린 모드입니다."); // 디버그 로그 추가
        }
    }

    // 현재 모드에 맞게 삼각형 이미지를 업데이트
    private void Triangle()
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