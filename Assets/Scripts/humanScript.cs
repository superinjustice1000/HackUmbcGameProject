using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanScript : MonoBehaviour
{
    public Animator aniLink;
    bool isScraed = false;

    private void Start()
    {
        aniLink = GetComponent<Animator>();
    }
    private void Update()
    {
        aniLink.SetBool("Scared",isScraed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var hitTag = collision.tag;
        if(hitTag != null )
        {
            if (hitTag == "Player")
            {
                isScraed = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var hitTag = collision.tag;
        if(hitTag != null )
        {
            if(hitTag == "Player")
            {
                isScraed = false;
            }
        }
    }
}
