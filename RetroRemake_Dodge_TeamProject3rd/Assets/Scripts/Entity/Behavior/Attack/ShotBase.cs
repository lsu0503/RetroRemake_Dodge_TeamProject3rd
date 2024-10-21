using UnityEngine;

public class ShotBase : AttackBase
{
    protected virtual void Start()
    {
        controller.OnAttackEvent += UseAttack;
    }
}
