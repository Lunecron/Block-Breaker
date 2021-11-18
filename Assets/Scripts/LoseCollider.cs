using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
    private int ballsLeft;
    private void Start()
    {
        ballsLeft = FindObjectsOfType<Ball>().Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ballsLeft -= 1;
        if(ballsLeft <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        
    }
}

