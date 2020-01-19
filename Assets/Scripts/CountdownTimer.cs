using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float timer = 0f;
    float startTimer = 13;
    float starter = 0f;
    public Text countdownText;
    public Text startText;
   
    void Start()
    {
        startText.gameObject.SetActive(true);
        timer = startTimer;
        startText.text = starter.ToString("Catch 5 other falling stars before you run out of power!");
        countdownText.gameObject.SetActive(false);
        
    }

    
    void FixedUpdate()
    {
        timer -= 1 * Time.deltaTime;

        if (timer <= 10)
        {
            startText.gameObject.SetActive(false);
       
            countdownText.gameObject.SetActive(true);
            countdownText.text = timer.ToString("0");
            countdownText.color = Color.white;
        }

        if (timer <=3)
        {
            countdownText.color = Color.red;
        }

        if (timer <= 0) 
        {
            timer = 0;
        }
    }
}
