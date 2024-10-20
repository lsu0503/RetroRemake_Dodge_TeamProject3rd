using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    protected virtual void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -18)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerData playerData = collision.gameObject.GetComponent<PlayerData>();
            ApplyItem(playerData);
        }
    }

    private void Movement()
    {
        rigidbody2D.AddForce(transform.right * -1.5f ,ForceMode2D.Impulse);
    }

    protected virtual void ApplyItem(PlayerData playerData)
    {

    }
}