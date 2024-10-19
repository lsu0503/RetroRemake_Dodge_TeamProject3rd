using UnityEngine;

public class ProjectileElimination : MonoBehaviour
{
    private ProjectileData data;
    private ProjectileCollider projectileCollider;

    private void Awake()
    {
        data = GetComponent<ProjectileData>();
        projectileCollider = GetComponent<ProjectileCollider>();
    }

    private void Start()
    {
        projectileCollider.OnCollisionEvent += EliminateBullet;
    }

    public void EliminateBullet(Collider2D collision)
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
