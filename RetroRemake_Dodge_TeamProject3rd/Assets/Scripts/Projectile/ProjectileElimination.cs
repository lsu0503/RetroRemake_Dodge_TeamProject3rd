using UnityEngine;

public class ProjectileElimination : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //이 스크립트를 붙인 오브젝트에 닿으면 투사체가 비활성화됨 

        if (collision.gameObject.CompareTag("Projectile"))
        {
            collision.gameObject.SetActive(false);
        }

    }
  
}
