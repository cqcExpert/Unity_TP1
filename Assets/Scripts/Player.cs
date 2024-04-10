using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public WheelCollider FRWheel;
    [SerializeField] public WheelCollider FLWheel;
    [SerializeField] public WheelCollider RRWheel;
    [SerializeField] public WheelCollider RLWheel;

    private Vector2 input;
    private Rigidbody _rb; 
    public float xInput;
    public float yInput;

    private float steeringAngle;
    public float brakeForce;

    public int _points;



    public float maxSteerAngle;
    public float motorForce;

    private float speed;
    public AnimationCurve steeringCurve;

    private float brakeInput;

    public void Controls(InputAction.CallbackContext context)
    {
        input=context.ReadValue<Vector2>();
        xInput=input.x;
        yInput=input.y;
    }

    public void ApplyBrakes(InputAction.CallbackContext context)
    {
        if(context.started)
        brakeInput=1f;
        if(context.canceled)
        brakeInput=0f;
    }


    private void Steer(){
        float steeringAngle=xInput*steeringCurve.Evaluate(speed);
        FRWheel.steerAngle= steeringAngle;
        FLWheel.steerAngle= steeringAngle;
    }

    private void Accelerate(){
        FRWheel.motorTorque=yInput*motorForce;
        FLWheel.motorTorque=yInput*motorForce;
    }

    private void FixedUpdate()
    {
        Steer();
        Accelerate();
        speed=_rb.velocity.magnitude;
        Brakes();
    }

    private void Brakes(){
        FRWheel.brakeTorque=brakeInput*brakeForce;
        FLWheel.brakeTorque=brakeInput*brakeForce;
        RRWheel.brakeTorque=brakeInput*brakeForce*0.5f;
        RLWheel.brakeTorque=brakeInput*brakeForce*0.5f;
    }


 




    void Start(){
        _rb=gameObject.GetComponent<Rigidbody>();
        
    }




   //SIMULATED ANTI-ROLL BARS 

    public WheelCollider wheelL;
	public WheelCollider wheelR;
	public float antiRollVal = 5000f;

	void Update () {
		WheelHit hit;
		float travelL=1.0f;
		float travelR=1.0f;
		bool groundedL = wheelL.GetGroundHit(out hit);
		if (groundedL){
				travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;
		}
		bool groundedR = wheelR.GetGroundHit(out hit);
		if (groundedR){
				 travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;

 
		}
		
    float antiRollForce = (travelL - travelR) * antiRollVal;

 

    if (groundedL)

        GetComponent<Rigidbody>().AddForceAtPosition(wheelL.transform.up * -antiRollForce,

               wheelL.transform.position);  

    if (groundedR)

        GetComponent<Rigidbody>().AddForceAtPosition(wheelR.transform.up * antiRollForce,

               wheelR.transform.position);  
	}












    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            _points++;
            Destroy(other.gameObject);
            Debug.Log("points:"+_points);
            if(_points==6){
                        SceneManager.LoadSceneAsync(3);
            }
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Roche"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadSceneAsync(4);
        }
    }
}