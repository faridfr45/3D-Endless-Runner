using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravity = -20;

    private CharacterController controller;
    private Vector3 direction;

    private int desiredLane = 1; //0:kiri 1:tengah 2:kanan
    public float laneDistance = 2.5f;//jarak antar lane

    void Start()
    {
        controller = GetComponent<CharacterController>();
        direction.z = speed;
    }
    
    void Update()
    {
        

        //jump
        if(controller.isGrounded){
            direction.y = -1;
            if(Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
        }else{
            direction.y += gravity * Time.deltaTime;
        }


        // movement
        if(Input.GetKeyDown(KeyCode.D)){
            desiredLane++;
            if(desiredLane==3)
                desiredLane = 2;
        }
        
        if(Input.GetKeyDown(KeyCode.A)){
            desiredLane--;
            if(desiredLane==-1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane==0){
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2){
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        controller.Move(direction * Time.deltaTime);

    }

    private void FixedUpdate() {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump(){
        direction.y = jumpForce;
    }
}
