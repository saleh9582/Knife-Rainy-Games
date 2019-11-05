using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;

    private Rigidbody2D myBody;
    private float speed = 3f;

    private float min_X = -2.7f;
    private float max_X = 2.7f;

    public Text timer_Text;
    private int timer;

    // Use this for initialization
    void Awake()
    {
      
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
      
        myBody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        StartCoroutine(CountTime());
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // DetectInput();
        PlayerBounds();
    }

    

    public void MoveRight()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);

  
        anim.SetBool("Walk", true);
        sr.flipX = false;

    }



    public void MoveLeft()
    {
        myBody.velocity = new Vector2(-speed, myBody.velocity.y);

        anim.SetBool("Walk", true);
        sr.flipX = true;

    }

    public void StopMoving()
    {
        myBody.velocity = new Vector2(0f, myBody.velocity.y);
        anim.SetBool("Walk", false);

    }

    void DetectInput()
    {
        float h = Input.GetAxisRaw("Horizontal");


        if (h > 0)
        {

            MoveRight();
        }
        else if (h < 0)
        {
            MoveLeft();
           

        }
        else if (h == 0)
        {

            StopMoving();
        }
        
    }








    void PlayerBounds() {

        Vector3 temp = transform.position;

        if(temp.x > max_X) {

            temp.x = max_X;

        } else if(temp.x < min_X) {

            temp.x = min_X;
        }

        transform.position = temp;

    }


    IEnumerator RestartGame() {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }

    IEnumerator CountTime() {

        yield return new WaitForSeconds(1f);
        timer++;

        timer_Text.text = "Score: " + timer;

        StartCoroutine(CountTime());
    }

	void OnTriggerEnter2D(Collider2D target) {
		
        if(target.tag == "Knife") {
            Time.timeScale = 0f;

            StartCoroutine(RestartGame());
        }

	}

} // class































