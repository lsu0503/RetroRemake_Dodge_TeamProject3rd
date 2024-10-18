using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller
{
    [SerializeField] private int playerNum;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        if(playerNum == 0)
        {
            if (!GameManager.Instance.isMultiplay)
                playerInput.SwitchCurrentActionMap("SinglePlayer");
            else
                playerInput.SwitchCurrentActionMap("Player1");
        }

        else if(playerNum == 1)
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
        isAttacking = value.isPressed;
        Debug.Log(isAttacking);
    }
}
