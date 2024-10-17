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
        currentDuration = 0;
        data = GetComponent<ProjectileData>();

    }


    private void Update()
    {
        currentDuration += Time.deltaTime;

        if (currentDuration > data.duration)
        {
            ObjectPool.Instance.gameObject.SetActive(false);
        }
        projectileRigidbody.velocity = gameObject.transform.right * data.speed;
        //발사각도 
        //
    }


}
