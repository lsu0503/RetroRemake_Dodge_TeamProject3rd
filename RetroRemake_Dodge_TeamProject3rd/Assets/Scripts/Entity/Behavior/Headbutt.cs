using UnityEngine;

public class Headbutt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitPoint"))
        {
            collision.gameObject.GetComponent<HitPoint>().OnHit(null);
        }
    }
}