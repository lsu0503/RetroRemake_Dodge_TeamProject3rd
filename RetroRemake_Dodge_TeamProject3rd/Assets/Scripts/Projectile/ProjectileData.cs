using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSO", menuName = "Projectile/ProjectileData/Default", order = 0)]
public class ProjectileData : ScriptableObject
{
    [Header("ProjectileInfo")]
    public float duration;  //투사체의 지속시간

    public float size;  //투사체 크기

    public float speed; //투사체의 속도

    public float power; //투사체의 데미지

    public string targetTag; //목표로 하는 대상
}
