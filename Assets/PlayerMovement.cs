using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 movement;
    CharacterController characterController;
    [SerializeField]
    private float playerSpeed;
    Animator animator;
    [SerializeField]
    private float playerRotateSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalMovement, 0, verticalMovement);
        characterController.SimpleMove(movement*playerSpeed*Time.deltaTime);
        animator.SetFloat("Speed", movement.magnitude);
        if (movement.magnitude > 0)
        {
            Quaternion playerRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * playerRotateSpeed);
            
          
        }
        
    }
}
