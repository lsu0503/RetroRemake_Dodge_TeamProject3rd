using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChoiceMenu : MonoBehaviour
{
    private RectTransform triangle; // 삼각형 이미지의 RectTransform
    public RectTransform windowedModeButtonRect; // 창모드 버튼의 RectTransform
    public RectTransform fullScreenButtonRect; // 전체화면 버튼의 RectTransform
    private float offset = 10f; // 버튼 위로 이동할 거리

    public void PushWindowModeBtn() 
    {
        // 창모드 버튼 클릭 시 창모드로 전환 및 삼각형 위치 이동
        windowedModeButtonRect.GetComponent<Button>().onClick.AddListener(() =>
        {
            SetTrianglePosition(windowedModeButtonRect);
            Screen.fullScreenMode = FullScreenMode.Windowed;
        });
    }

    public void PushFullScreenModeBtn()
    {
        // 전체화면 버튼 클릭 시 전체화면으로 전환 및 삼각형 위치 이동
        fullScreenButtonRect.GetComponent<Button>().onClick.AddListener(() =>
        {
            SetTrianglePosition(fullScreenButtonRect);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        });
    }

    public void SetTrianglePosition(RectTransform buttonRect)
    {
        // 버튼의 위치를 가져오고 y축으로 offset만큼 추가
        Vector3 newPosition = buttonRect.position;
        newPosition.y += offset; // y축으로 10만큼 위로 이동

        // 삼각형의 위치를 조정된 위치로 설정
        triangle.position = newPosition;
    }
}
