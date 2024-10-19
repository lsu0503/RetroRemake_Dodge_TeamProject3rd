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
        // Physics2D의 Layer 설정에 의해서 아군의 탄환 혹은 적군의 탄환 끼리는 충돌 판정이 발생하지 않는다.
        // 따라서, 발사 주체의 확인을 할 필요 없이 탄환 제거만 하면 된다.
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 개발 상황에 맞춰서 두 기능 중 하나 만 남길 것.
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
