using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameter
    [SerializeField] int breakableBlocks; //SerializeField for Debugging
   
    //cached reference
    SceneLoaderScript sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderScript>();
    }
    public void CountBlocks()
   {
        breakableBlocks++;
   }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
