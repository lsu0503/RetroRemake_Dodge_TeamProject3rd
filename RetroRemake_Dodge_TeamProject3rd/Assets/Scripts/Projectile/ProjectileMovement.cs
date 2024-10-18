using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D projectileRigidbody;
    [SerializeField] private ProjectileData data;
    private TrailRenderer trailRenderer;

    private float currentDuration;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        data = GetComponent<ProjectileData>();
        currentDuration = 0;

    }
    private void Update()
    {

        currentDuration += Time.deltaTime;
        if (currentDuration > data.duration)
        {
            ObjectPool.Instance.ReturnObject(gameObject);
        }
        projectileRigidbody.velocity = gameObject.transform.right * data.speed;

    }
    public void InitializeAttack(Vector2 direction, Vector3 startPosition)
    {
        currentDuration = 0;
        transform.position = startPosition;
        projectileRigidbody.velocity = direction * data.speed;
        transform.right = direction;

    }


}
