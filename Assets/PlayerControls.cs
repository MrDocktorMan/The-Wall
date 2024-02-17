using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    float movementDi;
    float airTime;
    public float speed;
    public float jumpForce;
    public float jumpTimer;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        

        

       if(Input.GetButtonDown("Jump"))
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
        //


        rb.velocity = new Vector2(velocity.x,rb.velocity.y);
    
    }
}
