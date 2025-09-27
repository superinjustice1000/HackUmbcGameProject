using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControls : MonoBehaviour
   
{

    public Rigidbody2D rbLink;
    public float speed = 5;
    float moveX;
    float moveY;
    Vector2 moveVector;
    public Transform movePoint;




    // Start is called before the first frame update
    void Start()
    {
        rbLink = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(moveX) == 1f)
            {
                movePoint.position += new Vector3(moveX, 0);
            }
            if (Mathf.Abs(moveY) == 1f)
            {
                movePoint.position += new Vector3(0, moveY);
            }
        }
    }

    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;

    }

}
