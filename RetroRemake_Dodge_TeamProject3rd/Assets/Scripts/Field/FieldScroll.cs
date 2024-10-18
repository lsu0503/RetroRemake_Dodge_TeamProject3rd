using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScroll : MonoBehaviour
{
    private float velocity = 0f;
    private float scrollRange = 30f;
    [SerializeField] private float acceleration = 0.01f;
    [SerializeField] private float deceleration = 0.01f;
    [SerializeField] private float highVelocity = 4f;

    public static bool isScrollStopped = false;

    [SerializeField] private GameObject[] fields;

    private void Update()
    {
        ScrollField();
    }

    private void ScrollField()
    {
        if (isScrollStopped == false)
        {
            velocity += acceleration;
            if (velocity >= highVelocity)
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

        for (int i = 0; i < fields.Length; i++)
        {
            fields[i].transform.position += Vector3.left * velocity * Time.deltaTime;
            if (fields[i].transform.position.x < -scrollRange * 1.5f)
            {
                fields[i].transform.position += Vector3.right * scrollRange * 4f;
            }
        }
    }
    
    public static void SetScrollStop()
    {
        isScrollStopped = true;
    }

    public static void SetScrollRestart()
    {
        isScrollStopped = false; 
    }
}
