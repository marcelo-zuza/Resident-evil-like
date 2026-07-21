using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float turnSpeed = 180f;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction rotateAction;



    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        // obter referências das ações
        moveAction = playerInput.actions["Move"];
        rotateAction = playerInput.actions["Rotate"];
    }

    void Update()
    {
        // ler valores do inputs
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float rotateInput = rotateAction.ReadValue<float>();

        //rotação horizontal
        transform.Rotate(0, rotateInput * turnSpeed * Time.deltaTime, 0);

        // movimento vertical, pra frente e pra trás
        Vector3 moveDir = transform.forward * moveInput.y * speed;
        controller.Move(moveDir * Time.deltaTime - Vector3.up * 0.1f);
    }
}
