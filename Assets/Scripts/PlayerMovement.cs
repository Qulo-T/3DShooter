using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;

    public int speedWalk;
    private int speed;
    public float jumpForce;
    public bool isGround;
    public bool isCrouch;
    private Animator anim;

    void Awake()
    {
        player = (GameObject)this.gameObject;
        anim = player.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = speedWalk;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Run();
        Crouch();
        MoveForward();
        MoveRight();
        Jump();


    }
    private void MoveForward()
    {
        float mf;
        if (isCrouch)
        {
            mf = 0.5f;
        }
        else
        {
            mf = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("www", true);
            player.transform.position += player.transform.forward * speed *mf * Time.deltaTime;
           
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("www", true);
            player.transform.position -= player.transform.forward * speedWalk/2 * Time.deltaTime;
            
        }
        else
        {
           
            anim.SetBool("www", false);
        }
    }

    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= player.transform.right * speedWalk * Time.deltaTime;
            anim.SetBool("www", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.transform.right * speedWalk * Time.deltaTime;
            anim.SetBool("www", true);
        }
        else
        {
          //  anim.SetBool("www", false);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                anim.SetBool("Jump", true);
                isGround = false;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    private void Run()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            speed = speedWalk * 2;
            anim.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
           
            speed = speedWalk;
            anim.SetBool("Run", false);
            anim.ResetTrigger("Run");
        }

    }
    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouch = true;
            anim.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouch = false;
            anim.SetBool("Crouch", false);
        }
    }

    private void OnCollisionEnter(Collision collision) //при необходимости прописать условие, что за коллвйдер вошел
    {
        isGround = true;
        anim.SetBool("Jump", !isGround);
    }
}
