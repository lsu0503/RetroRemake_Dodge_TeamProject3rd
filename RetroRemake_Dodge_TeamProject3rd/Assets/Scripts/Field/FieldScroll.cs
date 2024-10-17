using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScroll : MonoBehaviour
{
    public float velocity = 1f;
    public float scrollRange = 30f;

    bool isSetBoss;

    private void Update()
    {
        ScrollField();
    }

    public void ScrollField()
    {
        if (isSetBoss == true)
        {
            velocity -= 0.1f * Time.deltaTime;
            if (velocity <= 0f)
            {
                velocity = 0f;
            }
        }

        transform.position += Vector3.left * velocity * Time.deltaTime;
        if (transform.position.x < -scrollRange)
        {
            transform.position += Vector3.right * scrollRange * 3f;
        }
    }
}
