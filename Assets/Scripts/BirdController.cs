using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float bounceForce;
    public float speed;
    private Rigidbody2D myBody;
    private Animator anim;
    public bool isAlive;
    private int isTrigger;
    private int score;
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        isTrigger = 1;
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMovement();

        Vector3 temp = transform.position;
        if (isTrigger == 1)
        {
            temp.x += speed * Time.deltaTime;
        }
        else
        {
            temp.x -= speed * Time.deltaTime;
        }
        transform.position = temp;
    }

    void _BirdMovement()
    {
        if (isAlive)
        {
            if (Input.GetMouseButton(0))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
            }
        }

        if (myBody.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 60, myBody.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (myBody.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -60, -myBody.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall_y")
        {
            isTrigger = -isTrigger;
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            float z = transform.localScale.z;
            transform.localScale = new Vector3(-x, y, z);
        }

        if (collision.tag == "thorn" || collision.tag == "saw" || collision.tag == "mace")
        {
            anim.SetTrigger("Died");
            Time.timeScale = 0;
            if (PlayController.instance != null)
            {
                PlayController.instance._BirdDied();
            }
        }

        if(collision.tag == "ball")
        {
            if (score < 2)
            {
                score++;
                Destroy(collision.gameObject);
            }
            else
            {
                if (PlayController.instance != null)
                {
                    PlayController.instance._NextLevel();
                }
                Destroy(collision.gameObject);
                Time.timeScale = 0;
            }
        }
    }
}
