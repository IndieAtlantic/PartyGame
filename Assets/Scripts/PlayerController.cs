

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

    public AudioSource startup;
    public AudioSource background;
    public AudioSource winning;
    public AudioSource losing;
    public AudioSource pickup;

    private Rigidbody2D rb2d;

    public float speed;

    public float jumpForce;

    public int scoreValue;

    public Text countText;

    public Text loseText;

    public Text winText;

    private int count;

    private AudioSource audioSource;





    // Start is called before the first frame update

    void Start()

    {
        audioSource = GetComponent<AudioSource>();

        rb2d = GetComponent<Rigidbody2D>();

        count = 0;

        countText.gameObject.SetActive(false);

        loseText.text = "";

        countText.text = "";

        winText.text = "";

        restart = false;

        startText.gameObject.SetActive(true);
        timer = startTimer;
        startText.text = starter.ToString("Catch 5 other falling stars before you run out of power!");
        countdownText.gameObject.SetActive(false);
    }



    private void Awake()
    {
        startup.Play();

        background.Play();
    }

    void Update()

    {

        if (Input.GetKey("escape"))

            Application.Quit();

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("SampleScene");
            }

        }
        if (count >= 5)

        {
            winning.Play();

            countdownText.gameObject.SetActive(false);

            loseText.gameObject.SetActive(false);

            winText.text = "You Win! Press 'X' to play again!";

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
                losing.Play();

                timer = 0;

                restart = true;

                winText.gameObject.SetActive(false);

                loseText.text = "You lose! Try again? (Press 'X')";
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


        

    
