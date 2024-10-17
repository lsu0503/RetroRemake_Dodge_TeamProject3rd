using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{

    private ProjectileData data;

    private void Awake()
    {

        data = GetComponent<ProjectileData>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = data.targetTag;

        if (collision.gameObject.CompareTag(tag))
        {

            //태그 같다면 피격 로직을 발동

        }
        gameObject.SetActive(false);
        //충돌한 투사체 오브젝트는 비활성화됨
    }


}