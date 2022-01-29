using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    
    private Rigidbody2D rb;
    
    public bool facingRight = true;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    private bool top = false;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        
        if(facingRight == false && moveInput > 0){
            Flip();
        } else if (facingRight == true && moveInput <0){
            Flip();
        }
    }
    
    void Update(){
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            if (top == true ){
                rb.gravityScale *= -1;
                transform.position += new Vector3(0, 2, 0);
            } else {
                rb.gravityScale *= -1;
                transform.position -= new Vector3(0, 2, 0);
            }
            Rotation();
        }
        if(Input.GetKeyDown(KeyCode.W) && isGrounded == true){
            if (top == true){
                rb.velocity = Vector2.up * -jumpForce;
            } else {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }
    
    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    void Rotation(){
        if(top == false){
            transform.eulerAngles = new Vector3(0,0,180f);
        } else {
            transform.eulerAngles = Vector3.zero;
        }
        
        facingRight = !facingRight;
        top = !top;
    }
}
