using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 8.0f;
    public float gravity = -9.81f;

    [Header("Stamina Settings")]
    public float maxStamina = 5f;
    public float staminaDrainRate = 1f;
    public float staminaRegenRate = 0.8f;

    private CharacterController myController;
    private Vector2 inputDir;
    private float verticalVelocity;

    private bool sprintHeld;
    private float currentStamina;
    public TextMeshProUGUI staminaText;

    void Awake()
    {
        myController = GetComponent<CharacterController>();
        currentStamina = maxStamina;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprintHeld = context.ReadValueAsButton();
    }


    void Update()
    {
        bool isMoving = inputDir.magnitude > 0.1f;
        bool canSprint = sprintHeld && isMoving && currentStamina > 0f;

        float currentSpeed = canSprint ? sprintSpeed : walkSpeed;

        Vector3 move = (transform.right * inputDir.x) + (transform.forward * inputDir.y);

        myController.Move(move * currentSpeed * Time.deltaTime);

        if (canSprint)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        if (myController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        myController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);

        staminaText.text = "Stamina: " + Mathf.RoundToInt((currentStamina / maxStamina) * 100) + "%";
    }
}