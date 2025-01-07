using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent startGame;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputSystem_Actions inputActions;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void EndOfAnimation()
    {
        startGame.Invoke();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Start");
    }
}
