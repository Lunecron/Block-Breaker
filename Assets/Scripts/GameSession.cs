using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] int amountball = 1;
    Ball ball;
    Ball[] balls;

    //state
    [SerializeField] int currScore = 0;


    public void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        
        if (gameStatusCount > 1)
        {
            FindObjectsOfType<GameSession>()[0].amountball = FindObjectsOfType<GameSession>()[1].amountball;
            RestoreBalls();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {

        ball = FindObjectOfType<Ball>();
        balls = FindObjectsOfType<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }


    public void AddToScore()
    {
        currScore += PointsPerBlockDestroyed;
        scoreText.text = "Score: " + (currScore.ToString());
    }

    public void ResetScore()
    {
        currScore = 0;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
        
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void SwitchAutoplay()
    {
        if (isAutoPlayEnabled)
        {
            isAutoPlayEnabled = false;
        }
        else
        {
            isAutoPlayEnabled = true;
        }
    }

    public void ExtraBall()
    {
        balls = FindObjectsOfType<Ball>();
        amountball += 1;
        Instantiate<Ball>(ball, ball.transform.position, ball.transform.rotation);

    }

    public void DestroyBalls()
    {
        balls = FindObjectsOfType<Ball>();
        for (int index = 0; index < balls.Length; index++)
        {
            Destroy(balls[index]);
        }
    }

    public void RestoreBalls()
    {
        ball = FindObjectOfType<Ball>();
        balls = FindObjectsOfType<Ball>();
        for (int index = 1; index < amountball; index++)
        {
            Instantiate<Ball>(ball, ball.transform.position, ball.transform.rotation);
        }

    }

}
