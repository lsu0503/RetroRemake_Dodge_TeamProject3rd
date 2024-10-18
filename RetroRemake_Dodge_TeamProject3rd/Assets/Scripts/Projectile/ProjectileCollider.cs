using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{

    private ProjectileData data;

    private void Awake()
    {
        Debug.Log("�����Ͱ� �ʱ�ȭ �Ǿ����ϴ�");
        data = GetComponent<ProjectileData>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(data.targetTag))
        {
            //OnHit();
            gameObject.SetActive(false);

        }

    }

}