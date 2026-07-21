using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Vector2 playerInput;
    private CharacterController controller;
    private Animator animator;
    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] private float playerRotation = 40f;
    private float currentSpeed = 0f;
    public float gravity = -9.8f;
    private Vector3 velocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Gravity();
    }

    private void PlayerMovement()
    {
        Vector3 movement = transform.forward * playerInput * playerSpeed;
        controller.Move((movement + new Vector3(0, velocity.y, 0)) * Time.deltaTime); 
        transform.Rotate(transform.up, playerRotation * playerInput.x * Time.deltaTime);
        currentSpeed = controller.velocity.y;

        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
    }

    void Gravity()
    {
        if(controller.isGrounded)
        {
            velocity.y = 0f;
        }else
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }
    

}
