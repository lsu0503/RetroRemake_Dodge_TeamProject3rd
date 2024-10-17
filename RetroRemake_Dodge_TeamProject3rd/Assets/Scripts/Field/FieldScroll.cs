using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScroll : MonoBehaviour
{
    public float velocity = 0f;
    public float scrollRange = 30f;
    public float acceleration = 0.01f;
    public float deceleration = 0.01f;
    public float highVelocity = 4f;

    public static bool isBossSet = false;

    private void Update()
    {
        ScrollField();
    }

    public void ScrollField()
    {
        if (isBossSet == false)
        {
            velocity += acceleration;
            if( velocity >= highVelocity)
            {
                velocity = highVelocity;
            }
        }
        else
        {
            velocity -= deceleration;
            if (velocity <= 0)
            {
                velocity = 0;
            }
        }

        transform.position += Vector3.left * velocity * Time.deltaTime;
        if (transform.position.x < -scrollRange)
        {
            transform.position += Vector3.right * scrollRange * 4f;
        }
    }

    public static void SetBossTrue()
    {
        isBossSet = true;
    }

    public static void SetBossFalse()
    { 
        isBossSet = false; 
    }
}
