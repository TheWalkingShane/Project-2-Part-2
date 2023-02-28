using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxspeed = 3f;
    public float jumpForce = 10f;
    public float jumpboost = 5f;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;

        Collider col = GetComponent<Collider>();
        float castamount = col.bounds.extents.y + 0.03f;
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, castamount);
        rbody.velocity = new Vector3(Mathf.Clamp(rbody.velocity.x, -maxspeed, maxspeed), rbody.velocity.y,
            rbody.velocity.z);





            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            
            if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rbody.AddForce(Vector3.up * jumpboost, ForceMode.Force);
            }
            
            //this does the sprint
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rbody.AddForce(Vector3.right * acceleration, ForceMode.Impulse);
            }

        
 


        Color lineColor = (isGrounded) ? Color.blue : Color.red;
        Debug.DrawLine(transform.position, transform.position + Vector3.down * castamount, lineColor, 0f, false);

        float speed = rbody.velocity.magnitude;
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
        animator.SetBool("Jump", !isGrounded);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("you died");
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("you win!");
            Points.points += 100 ;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("coin +1");
            Points.coins += 1;
            Points.points += 100;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("brick"))
        {
            Points.points += 100;
            Debug.Log("destroy brick");
            Destroy(collision.gameObject);
        }
    }
}
