using UnityEngine;

public class ProjectileRicochet : MonoBehaviour
{
    [SerializeField] private bool isProofUp = false;
    [SerializeField] private bool isProofDown = false;
    [SerializeField] private bool isProofRight = false;
    [SerializeField] private bool isProofLeft = false;

    Rigidbody2D rb2D;

    public void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObj = collision.gameObject;
        Vector2 contact = collision.contacts[0].normal;
        //충돌 지점 첫번째 접촉점의 벡터값
        if (collisionObj.CompareTag("BorderUp") && isProofUp)
        {
            float angle = 0f; //반사각도 조절 
            Vector2 reflect = Vector2.Reflect(rb2D.velocity, contact);
            rb2D.velocity = Quaternion.Euler(0,0,angle) * reflect;
        }
        else if (collisionObj.CompareTag("BorderDown") && isProofDown)
        {
            float angle = 0f;
            Vector2 reflect = Vector2.Reflect(rb2D.velocity, contact);
            rb2D.velocity = Quaternion.Euler(0,0,angle) * reflect;
        }
        else if (collisionObj.CompareTag("BorderRight") && isProofRight)
        {
            float angle = 0f;
            Vector2 reflect = Vector2.Reflect(rb2D.velocity, contact);
            rb2D.velocity = Quaternion.Euler(0, 0, angle) * reflect;
        }
        else if (collisionObj.CompareTag("BorderLeft") && isProofLeft)
        {
            float angle = 0f;
            Vector2 reflect = Vector2.Reflect(rb2D.velocity, contact);
            rb2D.velocity = Quaternion.Euler(0, 0, angle) * reflect;
        }
    }
}