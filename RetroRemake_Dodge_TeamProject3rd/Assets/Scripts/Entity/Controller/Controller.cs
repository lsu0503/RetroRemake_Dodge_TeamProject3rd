using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Controller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnAttackEvent;
    public event Action OnBombEvent;

    public bool isAttacking = false;
    private float timeSinceLastAttack = float.MaxValue;
    [SerializeField] protected float timeToNextAttack = 0.5f;

    private void FixedUpdate()
    {
        HandleAttackDelay();
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
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    public void CallBombEvent()
    {
        OnBombEvent?.Invoke();
    }
}
