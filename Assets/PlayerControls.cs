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
    bool isGrounded;
    public float GroundHeight;
    public float collRadius;
    public LayerMask GroundTouchy;
    Vector2 sphereLocation;

    public float springPower;
    public bool onSpring = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        sphereLocation = new Vector2(transform.position.x, transform.position.y - GroundHeight);
        isGrounded = Physics2D.OverlapCircle(sphereLocation,collRadius,GroundTouchy);
        print(isGrounded);

        

       if(Input.GetButtonDown("Jump") && isGrounded == true && airTime <= 0)
        {
            airTime = jumpTimer;
        }




        

    }




    private void FixedUpdate()
    {
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;
       
        //print(airTime);
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



        rb.velocity = new Vector2(velocity.x,rb.velocity.y);
    
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sphereLocation, collRadius);

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
        if (col.gameObject.tag == "spring")
        {
            onSpring = true;
            print("spring");
            rb.AddForce(new Vector2(-springPower, 0f), ForceMode2D.Impulse);
        }
    }





}
