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

    public float power; //����ü�� ������

    public string targetTag; //��ǥ�� �ϴ� ���
}
