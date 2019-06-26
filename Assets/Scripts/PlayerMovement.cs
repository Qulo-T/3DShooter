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
    private Animator anim;

    void Awake()
    {
        player = (GameObject)this.gameObject;
        anim = player.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = speedWalk;

    }

    // Update is called once per frame
    void Update()
    {

        Run();
        MoveForward();
        MoveRight();
        Jump();


    }
    private void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= player.transform.forward * speedWalk * Time.deltaTime;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.ResetTrigger("Walk");
            anim.SetBool("Walk", false);
        }
    }

    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= player.transform.right * speedWalk * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.transform.right * speedWalk * Time.deltaTime;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
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

    private void OnCollisionEnter(Collision collision) //при необходимости прописать условие, что за коллвйдер вошел
    {
        isGround = true;
    }
}
