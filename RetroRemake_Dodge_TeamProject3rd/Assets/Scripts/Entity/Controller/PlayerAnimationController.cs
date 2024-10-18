using System;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    private static readonly int isStop = Animator.StringToHash("isStop");
    private static readonly int runningVelocity = Animator.StringToHash("runningVelocity");
    private readonly float magnituteThreshold = 0.5f;

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        if (vector.magnitude > magnituteThreshold)
        {
            if (FieldScroll.isScrollStopped)
            {
                animator.SetBool(isStop, false);
                if (vector.x > 0)
                    animator.SetFloat(runningVelocity, 1.0f);
                else
                    animator.SetFloat(runningVelocity, -1.0f);
            }

            else
            {
                if (vector.x > 0)
                    animator.SetFloat(runningVelocity, 2.0f);
                else
                    animator.SetFloat(runningVelocity, 0.5f);
            }
        }

        else
        {
            if (FieldScroll.isScrollStopped)
                animator.SetBool(isStop, true);
            else
            {
                animator.SetBool(isStop, false);
                animator.SetFloat(runningVelocity, 0.8f);
            }
        }
    }
}