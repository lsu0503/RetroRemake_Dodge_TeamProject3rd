using UnityEngine;

public class ShotBase : AttackBase
{
    private void Start()
    {
        controller.OnAttackEvent += UseAttack;
    }
}
