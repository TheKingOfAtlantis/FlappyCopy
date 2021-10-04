using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    static public GameController Instance;

    public GameObject scoreText, gameOverText, startIndicatorText;
    public ObjectPool objectPool;

    public int score = 0;
    public bool gameOver = false;

    // Use this for initialization

    void Awake()
    {
        // If the game controller doesn't exist yet create it
        // If it does and this isn't the same as the instance then destroy this 
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    void Start()
    {

    }

    public void addPoint()
    {
       score++;
       scoreText.GetComponent<Text>().text = "Score: " + score;
    }
    public void triggerGameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        startIndicatorText.SetActive(true);
    }
    public void startGame()
    {
        gameOver = false;
        objectPool.restPool();
        startIndicatorText.SetActive(false);
        gameOverText.SetActive(false);
    }
}
