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
    public GameObject currentCheckpoint;
    public GameObject wall;
    public float wallToCheckpointDistance;

    Sound_Effects_Player snd;
    bool playedSound;
    public float springPower;
    public bool onSpring = false;
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameOverScreen.SetActive(false);
        snd = GetComponent<Sound_Effects_Player>();
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
            snd.Jump();
 

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

<<<<<<< Updated upstream


        rb.velocity = new Vector2(velocity.x,rb.velocity.y);
=======
        if(muddy < 1)
        {
            muddy += Time.deltaTime* .5f;


        }
        else if (muddy > 1)
        {
            muddy = 1;

        }
>>>>>>> Stashed changes
    
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
<<<<<<< Updated upstream
            onSpring = true;
            print("spring");
            rb.AddForce(new Vector2(-springPower, 0f), ForceMode2D.Impulse);
=======
            case "spring":
                onSpring = true;
                print("spring");
                rb.AddForce(new Vector2(-springPower, 0.3f), ForceMode2D.Impulse);
                
                break;

            case "wall":
                snd.Death();

                GameOverScreen.SetActive(true);
                Time.timeScale = 0;

                break;

            case "levelEnd":
                SceneManager.LoadScene("winScene");
                
                break;

            case "Mud":
                muddy = mudVar;
                break;
            case "checkpoint":
                currentCheckpoint = col.gameObject;
                col.GetComponent<Sound_Effects_Player>().Checkpoint();
                break;



>>>>>>> Stashed changes
        }
    }


    public void respawn()
    {
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
        wall.transform.position = currentCheckpoint.transform.position - new Vector3(wallToCheckpointDistance, 0, 0);
        transform.position = currentCheckpoint.transform.position;
    }


}
