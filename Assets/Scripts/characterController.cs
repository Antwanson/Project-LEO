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
    [Header("Attack Attributes")]
    [SerializeField] public int attackNeutralDistance;
    [SerializeField] public Vector2 attackNeutralHitboxSize = new Vector2(10,10);
    int attackDir = 1;

    public float xDir = 0;
    protected CharacterControls playerControls;
    public StateController stateMachine;

    //Bools for state-machine use
    public bool isAttackingNeutral = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerControls = new CharacterControls();
        stateMachine = gameObject.GetComponent<StateController>();
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

    public void JumpTriggered(){
        if(isGrounded()){
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    public void MovementTriggered(InputValue value){
        //Debug.Log("Moved");
        Vector2 input = value.Get<Vector2>();
        xDir = input.x;
        rb.velocity = new Vector2(xDir * speed, rb.velocity.y);
        if(xDir < 0){
            transform.localScale = new Vector3(-1, 1, 1);
            attackDir = -1;
        } else if(xDir > 0){
            transform.localScale = new Vector3(1, 1, 1);
            attackDir = 1;
        }
        //Debug.Log("Direction: " + xDir);
    }
    public override int takeDamage(int damage, Vector2 knockback, GameObject damageDealer)
    {
        stateMachine.machine.Set(stateMachine.hurtState);

        return damage;
    }

    public void AttackNeutralFront()
    {
        //Debug.Log("Attack Neutral Front");
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, attackNeutralHitboxSize, 0, transform.right * attackDir, attackNeutralDistance, LayerMask.GetMask("Default"));
        //Debug.Log("hit array size: " + hits.Length);

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider.gameObject.GetComponent<characterController>() && hit.collider.gameObject != this.gameObject)
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);

                Entity target = hit.collider.gameObject.GetComponent<characterController>();
                target.takeDamage(100, Vector2.zero, gameObject);
            }
        }
        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireCube(transform.position + transform.right * attackNeutralDistance * attackDir, attackNeutralHitboxSize);
    }
}