using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    float movementDi;
    float airTime;
    public float speed;
    public float jumpForce;
    public float jumpTimer;
    public float leftSpringPower;
    public float upSpringPower;
    public bool onSpring = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {





        if (Input.GetButtonDown("Jump"))
        {
            airTime = jumpTimer;
        }






    }




    private void FixedUpdate()
    {
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;

         print(airTime);
        if (airTime > 0)
        {
            airTime -= Time.deltaTime;
            rb.velocity = Vector2.up * jumpForce;
        }


        if (!onSpring)
        {
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);
        }
        else
        {
            Invoke("onSpringOff", 0.2f);
        }

    }
    void onSpringOff()
    {
        onSpring = false;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            print("wall");
            SceneManager.LoadScene("GameScene");
        }
        if (col.gameObject.tag == "levelEnd")
        {
            SceneManager.LoadScene("winScene");
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "leftSpring")
        {
            onSpring = true;
            rb.AddForce(new Vector2(-leftSpringPower, 0f), ForceMode2D.Impulse);
        }
        if (col.gameObject.tag == "upSpring")
        {
            onSpring = true;
            rb.AddForce(new Vector2(0, upSpringPower), ForceMode2D.Impulse);
        }
    }
}
