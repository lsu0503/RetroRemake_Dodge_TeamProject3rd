using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    protected static readonly int isStop = Animator.StringToHash("isStop");
    protected static readonly int runningVelocity = Animator.StringToHash("runningVelocity");
    protected readonly float magnituteThreshold = 0.5f;

    protected virtual void Start()
    {
        controller.OnMoveEvent += Move;
    }

    protected virtual void Move(Vector2 vector)
    {
        if (vector.magnitude > magnituteThreshold)
        {
            if (FieldScroll.isScrollStopped)
            {
                animator.SetBool(isStop, false);
                if (vector.x > 0)
                    animator.SetFloat(runningVelocity, 1.0f);
                else if (vector.x < 0)
                    animator.SetFloat(runningVelocity, -1.0f);
                else
                    animator.SetFloat(runningVelocity, 0.5f);
            }

            else
            {
                if (vector.x > 0)
                    animator.SetFloat(runningVelocity, 2.0f);
                else if (vector.x < 0)
                    animator.SetFloat(runningVelocity, -0.5f);
                else
                    animator.SetFloat(runningVelocity, 1.0f);
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
