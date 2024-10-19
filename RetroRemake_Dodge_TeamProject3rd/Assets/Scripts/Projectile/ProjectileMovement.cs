using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D projectileRigidbody;
    [SerializeField] private ProjectileData data;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        data = GetComponent<ProjectileData>();
    }

    private void Update()
    {
        projectileRigidbody.velocity = gameObject.transform.right * data.speed;
    }
}
