using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float speed;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        moveRight = false;
        moveUp = false;
        moveDown = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft)
        {
            transform.position = new Vector3 (transform.position.x - speed*Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (moveUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
        if (moveDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "left_bot")
        {
            moveLeft = false;
            moveRight = false;
            moveUp = true;
            moveDown = false;
        }
        if (collision.tag == "left_top")
        {
            moveLeft = false;
            moveRight = true;
            moveUp = false;
            moveDown = false;
        }
        if (collision.tag == "right_top")
        {
            moveLeft = false;
            moveRight = false;
            moveUp = false;
            moveDown = true;
        }
        if (collision.tag == "right_bot")
        {
            moveLeft = true;
            moveRight = false;
            moveUp = false;
            moveDown = false;
        }
    }
}
