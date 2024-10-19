using UnityEngine;

public class ProjectileRicochet : MonoBehaviour
{
    [SerializeField] private bool isProofUp;
    [SerializeField] private bool isProofDown;
    [SerializeField] private bool isProofRight;
    [SerializeField] private bool isProofLeft;

    private Rigidbody2D rb2D;

    private ProjectileCollider projectileCollider;

    public void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        projectileCollider = GetComponent<ProjectileCollider>();
    }
    private void Start()
    {
        projectileCollider.OnCollisionEvent += AdjustRicochet;
    }

    public void AdjustRicochet(string collisionTag)
    {
        //충돌 지점 첫번째 접촉점의 벡터값
        if (collisionTag =="BorderUp" && isProofUp)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,-rb2D.velocity.y);
        }
        else if (collisionTag == "BorderDown" && isProofDown)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -rb2D.velocity.y);
        }
        else if (collisionTag == "BorderRight" && isProofRight)
        {
            rb2D.velocity = new Vector2(-rb2D.velocity.x, rb2D.velocity.y);
        }
        else if (collisionTag == "BorderLeft" && isProofLeft)
        {
            rb2D.velocity = new Vector2(-rb2D.velocity.x, rb2D.velocity.y);
        }
    }
}