using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float speed;
    [SerializeField] private float maxSpeed;
    public float jumpForce;
    public float gravity = -20;
    private bool isSliding;

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
        if(!GameManager.Instance.isGameStarted)
            return;

        anim.SetBool("isGameStarted", true);
        anim.SetBool("isJump", !controller.isGrounded);

        //speed increase by time
        if(speed < maxSpeed)
            speed += 0.03f * Time.deltaTime;

        if(controller.isGrounded){

            //jump
            if((Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp) && !isSliding)
            {
                Jump();
            }

            //slide
            if(Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown){
                StartCoroutine(Slide());
            }
        }else{
            direction.y += gravity * Time.deltaTime;
        }


        // movement
        if(Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight){
            desiredLane++;
            if(desiredLane==3)
                desiredLane = 2;
        }
        
        if(Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft){
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

    private void Jump(){
        direction.y = jumpForce;
    }

    private IEnumerator Slide(){
        isSliding = true;
        anim.SetBool("isSliding", isSliding);

        yield return new WaitForSeconds(0.2f);

        controller.center = new Vector3(0, 0.7f, 0);
        controller.height = 1.5f;
        
        yield return new WaitForSeconds(0.5f);

        isSliding = false;
        controller.center = new Vector3(0, 1.5f, 0);
        controller.height = 3;

        anim.SetBool("isSliding", isSliding);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.transform.tag == "Obstacle"){
            GameManager.Instance.gameOver = true;
        }
    }
}
