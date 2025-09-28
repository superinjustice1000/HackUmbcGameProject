using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    AudioSource audioLink;
    [SerializeField] float musicLength;
    // Start is called before the first frame update
    void Start()
    {
        audioLink = GetComponent<AudioSource>();
        if(playlist.Length > 0)
        {
            StartCoroutine(playMusicPiece());
        }
    }

    IEnumerator playMusicPiece()
    {
        for(int i=0; i <= 1; i++)
        {
            if(i == 0)
            {
                audioLink.clip = playlist[i];
                audioLink.Play();
                yield return new WaitForSeconds(2.4f);
            }
           
            if(i == 1)
            {
                while(i == 1)
                {
                    audioLink.clip = playlist[1];
                    audioLink.Play();
                    yield return new WaitForSeconds(musicLength);
                    Debug.Log("LOOP BEGUN");
                }
            }
        }
        
    }

    
    
}
