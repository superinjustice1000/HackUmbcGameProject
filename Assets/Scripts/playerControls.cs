using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playerControls : MonoBehaviour
   
{

    public Rigidbody2D rbLink;
    public float speed = 5;
    float moveX;
    float moveY;
    Vector2 moveVector;
    public Transform movePoint;
    public gameManager gameMangerLink;
    //bool inTargetRange = false;
    bool interaction;
    Animator aniLink;
    public LayerMask mazeWalls;
    
    


    
    void Start()
    {
        rbLink = GetComponent<Rigidbody2D>();
        gameMangerLink = FindObjectOfType<gameManager>();
        movePoint.parent = null;
        aniLink = GetComponent<Animator>();
    }

    
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(moveX) == 1f)
            {
               if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(moveX, 0),.2f, mazeWalls))
               {
                    movePoint.position += new Vector3(moveX, 0);
               }
                
            }
            if (Mathf.Abs(moveY) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0,moveY),.2f, mazeWalls))
                {
                    movePoint.position += new Vector3(0, moveY);
                }
                
            }
            if(moveVector != Vector2.zero)
            {
                aniLink.SetFloat("Last Horizontal", moveVector.x);
                aniLink.SetFloat("Last Vertical", moveVector.y);
            }
        }
        //Debug.Log("moveX:" + moveX);
        //Debug.Log("movY: " + moveY);
        //Debug.Log("Distance: " + Vector3.Distance(transform.position, movePoint.position));
    }

    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var hitTag = collision.tag;
        if (hitTag != null)
        {
            if(hitTag == "Target")
            {
                //inTargetRange = true;
                Debug.Log("IN TARGET RANGE!!!");
                if (interaction)
                {
                    Debug.Log("Target Killed!!!");
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var hitTag = collision.tag;
        if (hitTag != null)
        {
            if(hitTag == "Target")
            {
                //inTargetRange = false;
                Debug.Log("EXITING TARGET RANGE!!!");
            }
        }
    }

    public void OnFire(InputValue value)
    {
        aniLink.SetTrigger("Attack");
        Debug.Log("ATTACKING");

    }
}
