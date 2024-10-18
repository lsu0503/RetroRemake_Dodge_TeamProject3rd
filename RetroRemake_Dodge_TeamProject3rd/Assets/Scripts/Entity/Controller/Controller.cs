using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnAttackEvent;
    
    protected bool isAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;
    [SerializeField] protected float timeToNextAttack = 0.5f;
    
    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack < timeToNextAttack)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        else if (isAttacking)
        {
            timeSinceLastAttack = 0.0f;
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
