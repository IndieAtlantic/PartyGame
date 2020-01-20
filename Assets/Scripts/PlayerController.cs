

using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour

{
    float timer = 0f;
    float startTimer = 13;
    float starter = 0f;
    public Text countdownText;
    public Text startText;
    private bool restart;


    public AudioSource losing;
        public AudioSource startup;
    public AudioSource winning;
    public AudioSource pickup;
    public AudioSource beats;

   


    private Rigidbody2D rb2d;

    public float speed;

    public float jumpForce;

    public int scoreValue;

    public Text countText;

    public Text loseText;

    public Text winText;

    private int count;

    

    





    // Start is called before the first frame update

    void Start()

    {
        

        

        rb2d = GetComponent<Rigidbody2D>();

        count = 0;

        countText.gameObject.SetActive(false);

        loseText.text = "";

        countText.text = "";

        winText.text = "";

        restart = false;

        startText.gameObject.SetActive(true);
        timer = startTimer;
        startText.text = starter.ToString("Find 5 other falling stars!             (Arrow keys to move)");
        countdownText.gameObject.SetActive(false);
    }



    private void Awake()
    {
        
        beats.Play();
        startup.Play();
        
    }

    void Update()

    {

       if (Input.GetKeyDown(KeyCode.Q))

        {
            Application.Quit();
        }

        if (restart)
        {
            if (timer <= -3)
            {
                Application.Quit();
            }

        }
        if (count >= 5)

        {

           
            
          //winning.Play();


            countdownText.gameObject.SetActive(false);

            loseText.gameObject.SetActive(false);

            winText.text = "You Win!";

            restart = true;

        }
    }

        void FixedUpdate()

        {

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(moveHorizontal * 9, 0);

            rb2d.AddForce(movement * speed);

            timer -= 1 * Time.deltaTime;

            if (timer <= 10)
            {
                startText.gameObject.SetActive(false);
                
                countdownText.gameObject.SetActive(true);
                countdownText.text = timer.ToString("0");
                countdownText.color = Color.white;
            }

            if (timer <= 3)
            {
                countdownText.color = Color.red;
            }

            if (timer <= 0)
            {


            // losing.Play();
            countdownText.gameObject.SetActive(false);

            restart = true;

                winText.gameObject.SetActive(false);

                loseText.text = "You lose!";
            }

        }

        void OnCollisionStay2D(Collision2D collision)

        {

            if (collision.collider.tag == "Ground")

            {

                if (Input.GetKey(KeyCode.UpArrow))

                {

                    rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                }

            }

        }

        void OnCollisionEnter2D(Collision2D other)

        {

            if (other.gameObject.CompareTag("Pickup"))

            {
                countText.gameObject.SetActive(true);

            pickup.Play();

                other.gameObject.SetActive(false);

                count = count + 1;

                SetCountText();

            }

        }

        void SetCountText()

        {

            countText.text = "Stars Caught: " + count.ToString();

            
        }
    }


        

    
