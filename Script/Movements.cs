using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float speed;

    new private CharacterController characterController;

    private Animator animator;

    private float inputX, inputY;

    private float stopX, stopY;

    //private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = Camera.main.transform.position - transform.position;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        /*Vector2 input=(transform.right*inputX+transform.up*inputY).normalized;
        rigidbody.velocity = input * speed;*/

        Vector3 velocity = new Vector3(inputX * speed, 0f, inputY * speed);
        characterController.SimpleMove(velocity * speed);



        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);
        //Camera.main.transform.position = transform.position + offset;
    }
}
