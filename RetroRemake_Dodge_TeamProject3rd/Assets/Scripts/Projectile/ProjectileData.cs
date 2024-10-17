using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSO", menuName = "Projectile/ProjectileData/Default", order = 0)]
public class ProjectileData : ScriptableObject
{
    [Header("ProjectileInfo")]
    public float duration;  //����ü�� ���ӽð�

    public float size;  //����ü ũ��

    public float speed; //����ü�� �ӵ�

    public float power; //����ü�� ������

    public string targetTag; //��ǥ�� �ϴ� ���
}
