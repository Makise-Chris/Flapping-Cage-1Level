using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceController : MonoBehaviour
{
    public float speed;
    private bool moveLeft;
    private bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -1.2)
        {
            moveRight = false;
            moveLeft = true;
        }
        if (transform.position.x <= -2.8)
        {
            moveRight = true;
            moveLeft = false;
        }

        if (moveRight)
        {
            float x, y;
            x = transform.position.x + speed * Time.deltaTime;
            y = 1 - Mathf.Sqrt(1 - (x + 2) * (x + 2));
            transform.position = new Vector3(x, y, 0);
        }
        if (moveLeft)
        {
            float x, y;
            x = transform.position.x - speed * Time.deltaTime;
            y = 1 - Mathf.Sqrt(1 - (x + 2) * (x + 2));
            transform.position = new Vector3(x, y, 0);
        }
    }
}
