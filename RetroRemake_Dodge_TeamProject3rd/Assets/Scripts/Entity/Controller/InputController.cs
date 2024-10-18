using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);
    }

    public void OnAttack(InputValue value)
    {
        isAttacking = value.isPressed;
    }
}
