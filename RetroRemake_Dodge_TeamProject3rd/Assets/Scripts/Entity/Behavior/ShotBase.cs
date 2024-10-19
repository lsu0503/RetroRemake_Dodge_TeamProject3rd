using UnityEngine;

public class ShotBase : AttackBase
{
    public bool isAttacking;
    private float timeSinceLastAttack = float.MaxValue;
    [SerializeField] protected float timeToNextAttack = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        controller.OnAttackEvent += ActivateAttack;
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < timeToNextAttack)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        else if (isAttacking)
        {
            timeSinceLastAttack = 0.0f;
            controller.CallAttackEvent();
        }
    }

    public virtual void ActivateAttack()
    {

    }
}
