using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    float vMovement;
    float hMovement;
    Vector3 movement = Vector3.zero;
    Quaternion rotation = Quaternion.identity;

    Vector3 NewForward = Vector3.zero;

    public float speed = 3f;

    public float turnSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(true){
        vMovement = Input.GetAxis("Vertical");
        hMovement = Input.GetAxis("Horizontal");

        movement = new Vector3(hMovement * speed, 0f, vMovement * speed);
        movement = Vector3.ClampMagnitude(movement, 1f);

        NewForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(NewForward);
        transform.rotation = rotation;
        }

        characterController.Move(movement*Time.deltaTime);

        if(vMovement != 0f || hMovement != 0f){
            animator.SetInteger("state", 1);
        } else{
            animator.SetInteger("state", 0);
        }
        
    }
}
