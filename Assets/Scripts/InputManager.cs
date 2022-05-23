using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.AliveActions Alive;
    private PlayerMotor motor;
    private PlayerRotation rotation;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        playerInput = new PlayerInput();
        Alive = playerInput.Alive;
        motor = GetComponent<PlayerMotor>();
        rotation = GetComponent<PlayerRotation>();
        Alive.Jump.performed += ctx => motor.Jump();
        
        
            
       
        
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        motor.ProcessMove(Alive.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        rotation.ProcessLook(Alive.Look.ReadValue<Vector2>());
     }
    private void OnEnable()
    {
        Alive.Enable();
    }
    private void OnDisable()
    {
        Alive.Disable();
    }
}
