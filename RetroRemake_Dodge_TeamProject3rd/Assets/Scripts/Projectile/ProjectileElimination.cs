using UnityEngine;

public class ProjectileElimination : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�� ��ũ��Ʈ�� ���� ������Ʈ�� ������ ����ü�� ��Ȱ��ȭ�� 

        if (collision.gameObject.CompareTag("Projectile"))
        {
            collision.gameObject.SetActive(false);
        }

    }
  
}
