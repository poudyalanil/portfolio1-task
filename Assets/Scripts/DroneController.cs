using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody drone;
    public float upForce;
        void Awake(){
        drone = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        movementUpDown();
        movementForward();
        rotation();
        clampSpeed();
        leftRightMotion();
        
        drone.AddRelativeForce(Vector3.up* upForce);
        drone.rotation = Quaternion.Euler(
            new Vector3(tiltAmount,current_y_rotation,titltAmountSideways)
            
            );
    }
    void movementUpDown(){
        if(Input.GetKey(KeyCode.I)){
            upForce = 230;

        }
        else if(Input.GetKey(KeyCode.K)){
           upForce = -150;
        }
        else if(!Input.GetKey(KeyCode.I)&& ! Input.GetKey(KeyCode.K)){

            upForce = 98.1f;
        }


    }
    
    private float forward = 500f;
    private float tiltAmount =0;
    private float tiltVelocityForward;

    void movementForward(){
        if(Input.GetAxis("Vertical") !=0 ){
            drone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * forward);
            tiltAmount = Mathf.SmoothDamp(tiltAmount,20*Input.GetAxis("Vertical"),ref tiltVelocityForward,0.1f);

        }
       
    }
    private float y_rotation;
    private float current_y_rotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;

    void rotation(){

if(Input.GetKey(KeyCode.J)){
    y_rotation -=rotateAmountByKeys;

}
if(Input.GetKey(KeyCode.L)){
    y_rotation += rotateAmountByKeys;
}
current_y_rotation = Mathf.SmoothDamp(current_y_rotation,y_rotation,ref rotationYVelocity,0.25f);

    }
    private Vector3 velocityToSmoothDampToZero;

void clampSpeed(){
    if(Mathf.Abs(Input.GetAxis("Vertical"))> 0.2f && Mathf.Abs(
        Input.GetAxis("Horizontal"))>0.2f){
            drone.velocity = Vector3.ClampMagnitude(drone.velocity,Mathf.Lerp(drone.velocity.magnitude,10f,Time.deltaTime * 5f));

    }
    if(Mathf.Abs(Input.GetAxis("Vertical"))>0.2f && Mathf.Abs(Input.GetAxis("Horizontal"))<0.2f){
        drone.velocity = Vector3.ClampMagnitude(drone.velocity,Mathf.Lerp(drone.velocity.magnitude,10f,Time.deltaTime * 5f));

    }
    if(Mathf.Abs(Input.GetAxis("Vertical"))<0.2f && Mathf.Abs(Input.GetAxis("Horizontal"))>0.2f){
     drone.velocity = Vector3.ClampMagnitude(drone.velocity,Mathf.Lerp(drone.velocity.magnitude,5f,Time.deltaTime * 5f));

    }if(Mathf.Abs(Input.GetAxis("Vertical"))<0.2f && Mathf.Abs(Input.GetAxis("Horizontal"))<0.2f){
        drone.velocity = Vector3.SmoothDamp(drone.velocity,Vector3.zero,ref velocityToSmoothDampToZero,0.95f);
    }

    }
    private float sideMovementAmount = 300f;
    private float titltAmountSideways;
    private float tiltAmountVelocity;

void leftRightMotion(){
    if(Mathf.Abs(Input.GetAxis("Horizontal"))>0.2f){
        drone.AddRelativeForce(Vector3.right*Input.GetAxis("Horizontal")* sideMovementAmount);
        titltAmountSideways = Mathf.SmoothDamp(titltAmountSideways,-20* Input.GetAxis("Horizontal"),ref tiltAmountVelocity,0.1f);
    }else{
        titltAmountSideways = Mathf.SmoothDamp(titltAmountSideways,0,ref tiltAmountVelocity,0.1f);
    }

}



}
