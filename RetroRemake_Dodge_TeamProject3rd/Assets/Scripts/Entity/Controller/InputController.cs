using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    private PlayerData data;
    private PlayerInput playerInput;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        data = GetComponent<PlayerData>();
        playerInput = GetComponent<PlayerInput>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Start()
    {
        if(data.playerNum == 0)
        {
            if (!GameManager.Instance.isMultiplay)
                playerInput.SwitchCurrentActionMap("SinglePlayer");
            else
                playerInput.SwitchCurrentActionMap("Player1");
        }

        else if(data.playerNum == 1)
        {
            if (!GameManager.Instance.isMultiplay)
                Destroy(gameObject);
            else
                playerInput.SwitchCurrentActionMap("Player2");
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnAttack(InputValue value)
    {
        playerAttack.isAttacking = value.isPressed;
    }

    public void OnBomb(InputValue value)
    {
        CallBombEvent();
    }
}
