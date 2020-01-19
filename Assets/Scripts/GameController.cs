using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    
    

    public AudioSource startup;
    public AudioSource background;
    public AudioSource winning;
    public AudioSource losing;

    private bool gameOver;
    private bool restart;
    public bool win;
    public int score;

   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        win = false;
        gameOverText.text = "";
        winText.text = "";
    }

    void Awake()
    {
        background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void Win()
    {
        
        
        if (score >= 5)
        {
            background.Stop();
            winning.Play();
            win = true;
            winText.text = "You win!";
        }
    }

    
    public void GameOver()
    {
        background.Stop();
        losing.Play();
        gameOverText.text = "Game Over";
        gameOver = true;
        restart = true;
    }
}
