using System.Collections.Generic;
using UnityEngine;

public class MagneticEffect : MonoBehaviour
{
    [SerializeField] private float speed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Vector2 distance = transform.position - collision.transform.position;
            collision.GetComponent<Rigidbody2D>().AddForce(distance.normalized * speed,ForceMode2D.Impulse);
        }
    }
}