using UnityEngine;

public class AttackBase : MonoBehaviour
{
    protected Controller controller;

    protected virtual void Awake()
    {
        controller = GetComponent<Controller>();
    }

    public virtual void UseAttack()
    {

    }
}
