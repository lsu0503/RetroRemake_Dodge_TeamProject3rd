using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChoiceMenu : MonoBehaviour
{
    [SerializeField] private Button windowModeBtn;     // â��� ��ư
    [SerializeField] private Button fullscreenModeBtn; // Ǯ��ũ�� ��ư
    [SerializeField] private GameObject windowModeIndicator;   // â��� ���¸� ǥ���� �ﰢ�� �̹���
    [SerializeField] private GameObject fullscreenModeIndicator; // Ǯ��ũ�� ���¸� ǥ���� �ﰢ�� �̹���

    private void Start()
    {
        // �ʱ� ���¸� Ǯ��ũ������ ����
        SetFullscreenMode(); // Ǯ��ũ�� ���� ����
    }

    // â ���� ��ȯ
    public void SetWindowMode()
    {
        if (Screen.fullScreen) // �̹� Ǯ��ũ�� ����̸� â ���� ��ȯ
        {
            Screen.fullScreen = false; // â ���� ��ȯ
            Debug.Log("â���� ����Ǿ����ϴ�.");
            Triangle(); // UI ������Ʈ
        }
        else
        {
            Debug.Log("�̹� â����Դϴ�."); // ����� �α� �߰�
        }
    }

    // Ǯ��ũ�� ���� ��ȯ
    public void SetFullscreenMode()
    {
        if (!Screen.fullScreen) // �̹� â ����̸� Ǯ��ũ������ ��ȯ
        {
            Screen.fullScreen = true; // Ǯ��ũ�� ���� ��ȯ
            Debug.Log("Ǯ��ũ�� ���� ����Ǿ����ϴ�.");
            Triangle(); // UI ������Ʈ
        }
        else
        {
            Debug.Log("�̹� Ǯ��ũ�� ����Դϴ�."); // ����� �α� �߰�
        }
    }

    // ���� ��忡 �°� �ﰢ�� �̹����� ������Ʈ
    private void Triangle()
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