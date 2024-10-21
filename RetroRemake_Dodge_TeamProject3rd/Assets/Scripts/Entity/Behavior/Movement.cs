using System;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Controller controller;
    private Rigidbody2D rigid;
    [SerializeField] private bool isPlayer;

    [SerializeField] float velocity = 8.0f;
    
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        Vector2 movement = direction * velocity;

        rigid.velocity = movement;
        if (isPlayer)
        {
            float posY = Mathf.Clamp(transform.position.y, -5.5f, 6.0f);
            float posX = Mathf.Clamp(transform.position.x, -13.5f, 13.5f);

            transform.position = new Vector2(posX, posY);
        }
    }
}