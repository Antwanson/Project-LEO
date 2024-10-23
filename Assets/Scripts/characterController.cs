using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.MPE;
using Unity.Collections;


public class characterController : Entity
{
    float xDir = 0;
    protected CharacterControls playerControls;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerControls = new CharacterControls();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        rb.velocity = new Vector2(xDir * 50 * speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnJump(){
        if(isGrounded()){
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    private void OnMovement(InputValue value){
        //Debug.Log("Moved");
        Vector2 input = value.Get<Vector2>();
        xDir = input.x;
        rb.velocity = new Vector2(xDir * speed, rb.velocity.y);
        if(xDir < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(xDir > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Debug.Log("Direction: " + xDir);
    }
    private void OnDeviceLost(){
        Debug.Log("Cursor Lost");
    }
}