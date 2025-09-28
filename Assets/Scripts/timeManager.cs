using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeManager : MonoBehaviour
{
    [SerializeField] float vidTime;
    [SerializeField] int sceneLoad;
    [SerializeField] Canvas canvasLink;
    [SerializeField] float time;
    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    { 
        if (time > vidTime)
        {
            SceneManager.LoadScene(sceneLoad);
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    IEnumerator vidTimeStop()
    {
        Debug.Log("STARTING TIMER FOR: "+ vidTime);
        yield return new WaitForSeconds(vidTime);
        //Destroy(canvasLink);
        Debug.Log("LOADING SCENE");
        


    }
    
}
