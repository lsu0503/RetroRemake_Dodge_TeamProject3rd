using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileOnShoot : MonoBehaviour
{
    private Rigidbody2D projectileRigidbody;
    private ProjectileData data;
    private TrailRenderer trailRenderer;

    private float currentDuration;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        data = GetComponent<ProjectileData>();
        trailRenderer = GetComponent<TrailRenderer>();

    }


    private void Update()
    {
        if (currentDuration > data.duration)
        {
            gameObject.SetActive(false);
        }
        projectileRigidbody.velocity = gameObject.transform.right * data.speed;
    }
}
