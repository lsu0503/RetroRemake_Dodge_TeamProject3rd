using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[Serializable]
public class ProjectileData : MonoBehaviour
{
    public float duration;  //투사체의 지속시간
    public float size;  //투사체 크기
    public float speed; //투사체의 속도
    public int power; //투사체의 데미지
    public string targetTag; //목표로 하는 대상
    public int type; //발사체 사용자 타입
    
    public bool isInPool; // 풀에 등록되어 있는지 여부

    private float currentDuration;

    private void Update()
    {
        transform.localScale = Vector3.one * size;

        currentDuration += Time.deltaTime;
        if (currentDuration > duration)
        {
            if (isInPool)
                gameObject.SetActive(false);

            else
                Destroy(gameObject);
        }
    }

    public void InitializeTime()
    {
        currentDuration = 0;
    }
}
