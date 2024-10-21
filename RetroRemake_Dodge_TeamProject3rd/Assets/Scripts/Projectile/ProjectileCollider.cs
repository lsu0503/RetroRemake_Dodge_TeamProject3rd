using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    public event Action<Collider2D> OnCollisionEvent;
    private ProjectileData data;
    [SerializeField] private bool isPiercable;

    private void Awake()
    {
        data = GetComponent<ProjectileData>();
    }

    private void Start()
    {
        OnCollisionEvent += TargetHit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollisionEvent?.Invoke(collision);
    }

    public void TargetHit(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(data.targetTag))
        {
            collision.gameObject.GetComponent<CharacterBehavior>().OnHit(data);

            if (!isPiercable)
            {
                if (data.isInPool)
                    gameObject.SetActive(false);

                else
                    Destroy(gameObject);
            }
        }
    }
}