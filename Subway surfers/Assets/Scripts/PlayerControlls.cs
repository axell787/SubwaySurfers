using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    //public Rigidbody rb1;

    public AudioSource swipeMove;
    public AudioSource swipeUp;
    public AudioSource swipeDown;

    int line = 1;
    public float lineDistance = 4;

    Animator animator;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        Movement();
        Jump();
        Slide();
    }
    private void FixedUpdate()
    {
        //Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //rb.position = rb.position + forwardMove; 
        //rb.MovePosition(rb.position + forwardMove);
        //Vector3 moveDirection = transform.forward * speed;

        //transform.position += moveDirection;
        //player.Move(direction * Time.fixedDeltaTime);
    }
    private void Movement()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("right",  true);
            line++;
            if(line == 3) line = 2;
            swipeMove.Play();
        }
        else animator.SetBool("right", false);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("left", true);
            line--;
            if(line == -1) line = 0;
            swipeMove.Play();
        }
        else animator.SetBool("left", false);

        Vector3 newPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(line == 0)
        {
            newPosition += Vector3.left * lineDistance;
        }
        else if(line == 2)
        {
            newPosition += Vector3.right * lineDistance;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, 10f * Time.deltaTime);
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("jump", true);
            rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
            swipeUp.Play();
        }
        else animator.SetBool("jump", false);
    }
    private void Slide()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("slide", true);
            swipeDown.Play();
        }
        else animator.SetBool("slide", false);
    }
}
