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

    void Awake()
    {
        player = (GameObject)this.gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
        speed = speedWalk;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            speed = speedWalk * 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speedWalk;
        }



        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= player.transform.forward * speedWalk * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= player.transform.right * speedWalk * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.transform.right * speedWalk * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision) //при необходимости прописать условие, что за коллвйдер вошел
    {
        isGround = true;
    }
}
