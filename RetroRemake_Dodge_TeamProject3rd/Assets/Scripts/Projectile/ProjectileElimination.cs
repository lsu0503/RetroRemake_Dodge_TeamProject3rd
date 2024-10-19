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
        // Physics2D�� Layer ������ ���ؼ� �Ʊ��� źȯ Ȥ�� ������ źȯ ������ �浹 ������ �߻����� �ʴ´�.
        // ����, �߻� ��ü�� Ȯ���� �� �ʿ� ���� źȯ ���Ÿ� �ϸ� �ȴ�.
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // ���� ��Ȳ�� ���缭 �� ��� �� �ϳ� �� ���� ��.
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
