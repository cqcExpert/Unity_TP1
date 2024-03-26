using UnityEngine;
using UnityEngine.InputSystem;

public class CarControl : MonoBehaviour
{
    [SerializeField] public float motorTorque;
    [SerializeField] public float brakeTorque;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float steeringRange;
    [SerializeField] public float steeringRangeAtMaxSpeed;
    [SerializeField] public float centreOfGravityOffset;

    WheelControl[] wheels;
    Rigidbody rigidBody;

    private Vector2 moveInput;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        // Adjust center of mass vertically, to help prevent the car from rolling
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;

        // Find all child GameObjects that have the WheelControl script attached
        wheels = GetComponentsInChildren<WheelControl>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
         var val = context.ReadValue<Vector2>();
         Debug.Log(val);
    }

    private void FixedUpdate()
    {
        
        moveInput = PlayerInput.Car.Movement.ReadValue<Vector2>();

    
    }
}
