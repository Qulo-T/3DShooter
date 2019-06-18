using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;

    public int speedWalk;
    private int speed;

    void Start()
    {
        player = (GameObject)this.gameObject;
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
    }
}
