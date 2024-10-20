using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    protected virtual void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerData playerData = collision.rigidbody.GetComponent<PlayerData>();
            ApplyItem(playerData);
        }
    }

    protected virtual void ApplyItem(PlayerData playerData)
    {

    }

    private void Movement()
    {
        
        Destroy(gameObject);
    }
}
