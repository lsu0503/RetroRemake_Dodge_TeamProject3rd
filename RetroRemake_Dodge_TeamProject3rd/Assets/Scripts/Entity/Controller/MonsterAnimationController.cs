using UnityEngine;

public class MonsterAnimationController : CharacterAnimationController
{
    private static readonly int isAttack = Animator.StringToHash("isAttack");

    private void Attack()
    {
        animator.SetTrigger(isAttack);
    }
}