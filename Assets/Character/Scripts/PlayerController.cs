using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData data;
    [SerializeField] Transform view;
    [SerializeField] Animator animator;

    CharacterController controller;
    InputAction moveAction;
    InputAction jumpAction;
    Vector2 movementInput = Vector2.zero;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += OnJump;
        jumpAction.canceled += OnJump;

        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;

        float moveModifier = controller.isGrounded ? 1 : 0.1f;
        
        velocity.x = movement.x * data.speed * moveModifier;
        velocity.z = movement.z * data.speed * moveModifier;

        if(movement.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * data.turnRate);
            //transform.forward = movement;
        }
        
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //set animator
        Vector3 v = velocity;
        v.y = 0;
        animator.SetFloat("Speed", v.magnitude);
        animator.SetFloat("YVelocity", controller.velocity.y);
        animator.SetBool("OnGround", controller.isGrounded);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2 * data.gravity * data.jumpHeight);
        }
    }
}