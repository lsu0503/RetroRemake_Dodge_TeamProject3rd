using UnityEngine;

public class MonsterAnimationController : CharacterAnimationController
{
    private static readonly int isAttack = Animator.StringToHash("isAttack");

    protected override void Start()
    {
        base.Start();
        controller.OnAttackEvent += Attack;
    }

    private void Attack()
    {
        animator.SetTrigger(isAttack);
    }
}