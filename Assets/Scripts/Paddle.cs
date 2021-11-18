using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameSession gameStatus;
    Ball[] ball;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        ball = FindObjectsOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x , transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }


    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled()) 
        {
            int lowestball = 0;
            for (int index = 0; index < ball.Length; index++)
            {
                if (ball[lowestball].transform.position.y > ball[index].transform.position.y)
                {
                    lowestball = index;
                }
                
            }
            return ball[lowestball].transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        }
        
    }
}
