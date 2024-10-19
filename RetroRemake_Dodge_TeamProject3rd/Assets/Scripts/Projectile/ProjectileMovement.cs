using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D projectileRigidbody;
    [SerializeField] private ProjectileData data;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        data = GetComponent<ProjectileData>();
    }

    private void OnEnable()
    {
        projectileRigidbody.AddForce(transform.right * data.speed, ForceMode2D.Impulse);
    }

    public void SetVelocity(Vector2 _velocity)
    {
        projectileRigidbody.velocity = Vector2.zero;
        projectileRigidbody.AddForce(_velocity, ForceMode2D.Impulse);
    }
}