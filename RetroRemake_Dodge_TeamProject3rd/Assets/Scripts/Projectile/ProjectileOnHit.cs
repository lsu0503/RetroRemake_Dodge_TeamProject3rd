using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnHit : MonoBehaviour
{

    private ProjectileData data;

    private void Awake()
    {

        data = GetComponent<ProjectileData>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = data.targetTag;

        if (Equals(tag, collision.tag))
        {

            //�±� ���ٸ� �ǰ� ������ �ߵ�

        }
        gameObject.SetActive(false);
        //�浹�� ����ü ������Ʈ�� ��Ȱ��ȭ��
    }


}