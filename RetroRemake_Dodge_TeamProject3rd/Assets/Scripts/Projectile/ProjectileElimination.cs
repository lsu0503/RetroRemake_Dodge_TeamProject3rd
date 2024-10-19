using UnityEngine;

public class ProjectileElimination : MonoBehaviour
{
    private ProjectileData data;
    private void Awake()
    {
       data = GetComponent<ProjectileData>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�� ��ũ��Ʈ�� ���� ������Ʈ�� ������ ����ü�� ��Ȱ��ȭ�� 
        GameObject callObj = collision.gameObject;
        ProjectileData? targetData = callObj.GetComponent<ProjectileData>();

        if (targetData != null)
        {
            if (targetData.type < 0)
                callObj.SetActive(false);
        }
    }
}
