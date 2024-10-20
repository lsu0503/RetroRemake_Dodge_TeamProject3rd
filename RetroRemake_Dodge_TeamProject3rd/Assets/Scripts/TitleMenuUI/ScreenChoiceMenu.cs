using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChoiceMenu : MonoBehaviour
{
    private RectTransform triangle; // �ﰢ�� �̹����� RectTransform
    public RectTransform windowedModeButtonRect; // â��� ��ư�� RectTransform
    public RectTransform fullScreenButtonRect; // ��üȭ�� ��ư�� RectTransform
    private float offset = 10f; // ��ư ���� �̵��� �Ÿ�

    public void PushWindowModeBtn() 
    {
        // â��� ��ư Ŭ�� �� â���� ��ȯ �� �ﰢ�� ��ġ �̵�
        windowedModeButtonRect.GetComponent<Button>().onClick.AddListener(() =>
        {
            SetTrianglePosition(windowedModeButtonRect);
            Screen.fullScreenMode = FullScreenMode.Windowed;
        });
    }

    public void PushFullScreenModeBtn()
    {
        // ��üȭ�� ��ư Ŭ�� �� ��üȭ������ ��ȯ �� �ﰢ�� ��ġ �̵�
        fullScreenButtonRect.GetComponent<Button>().onClick.AddListener(() =>
        {
            SetTrianglePosition(fullScreenButtonRect);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        });
    }

    public void SetTrianglePosition(RectTransform buttonRect)
    {
        // ��ư�� ��ġ�� �������� y������ offset��ŭ �߰�
        Vector3 newPosition = buttonRect.position;
        newPosition.y += offset; // y������ 10��ŭ ���� �̵�

        // �ﰢ���� ��ġ�� ������ ��ġ�� ����
        triangle.position = newPosition;
    }
}
