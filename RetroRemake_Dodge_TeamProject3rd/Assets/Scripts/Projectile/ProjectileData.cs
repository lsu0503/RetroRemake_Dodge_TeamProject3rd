using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[Serializable]
public class ProjectileData : MonoBehaviour
{
    public float duration;  //����ü�� ���ӽð�
    public float size;  //����ü ũ��
    public float speed; //����ü�� �ӵ�
    public int power; //����ü�� ������
    public string targetTag; //��ǥ�� �ϴ� ���
    public int type; //�߻�ü ����� Ÿ��

    private float currentDuration;

    private void Update()
    {
        transform.localScale = Vector3.one * size;

        currentDuration += Time.deltaTime;
        if (currentDuration > duration)
        {
            gameObject.SetActive(false);
        }
    }

    public void InitializeTime()
    {
        currentDuration = 0;
    }
}
