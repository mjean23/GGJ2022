using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController player;
    
    private bool top = false;
    
    void Start()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.gravityScale *= -1;
            Rotation();
        }
        if(Input.GetKeyDown(KeyCode.W)){
            if (top == true){
                rb.velocity = Vector2.up * -player.jumpForce;
            } else {
                rb.velocity = Vector2.up * player.jumpForce;
            }
        }
        
    }
    
    void Rotation(){
        if(top == false){
            transform.eulerAngles = new Vector3(0,0,180f);
        } else {
            transform.eulerAngles = Vector3.zero;
        }
        
        player.facingRight = !player.facingRight;
        top = !top;
    }
}
