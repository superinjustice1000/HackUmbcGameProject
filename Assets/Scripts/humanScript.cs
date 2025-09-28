using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanScript : MonoBehaviour
{
    [SerializeField] private AudioClip damageSoundClip;
    public Animator aniLink;
    bool isScraed = false;
    public gameManager gameManagerLink;

    private void Start()
    {
        aniLink = GetComponent<Animator>();
        gameManagerLink = FindObjectOfType<gameManager>();
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
            else if(hitTag == "Attack")
            {
                SoundFXManager.instance.PlaySoundFXClip(damageSoundClip, transform, 1f);
                Destroy(gameObject);
                gameManagerLink.increaseScore(1000);
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
