using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MagneticEffect : MonoBehaviour
{
    [SerializeField] private float speed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Vector2 distance = transform.position - collision.gameObject.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(distance * speed, ForceMode2D.Impulse);
        }
    }
}