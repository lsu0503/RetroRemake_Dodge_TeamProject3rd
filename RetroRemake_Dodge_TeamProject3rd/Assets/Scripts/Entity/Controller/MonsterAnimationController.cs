using UnityEngine;

public class MonsterAnimationController : AnimationController
{
    protected static readonly int velocity = Animator.StringToHash("velocity");

    protected virtual void Start()
    {
        controller.OnMoveEvent += Move;
    }

    protected virtual void Move(Vector2 vector)
    {
        if (vector.x < 0)
            animator.SetFloat(velocity, 1.0f);
        else if (vector.x > 0)
            animator.SetFloat(velocity, -2.5f);
        else
            animator.SetFloat(velocity, 0.5f);
    }
}