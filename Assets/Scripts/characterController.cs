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
    [Header("Attack Neutral Attributes")]
    [SerializeField] public int attackNeutralDistance;
    [SerializeField] public Vector3 attackNeutralOffset = new Vector3(0,0,0);
    [SerializeField] public Vector2 attackNeutralHitboxSize = new Vector2(10,10);
    [SerializeField] public int attackNeutralDamage = 10;
    public bool isAttackingNeutral = false;

    [Header("Attack Favor Attributes")]
    [SerializeField] public int attackFavorDistance;
    [SerializeField] public Vector3 attackFavorOffset = new Vector3(0, 0, 0);
    [SerializeField] public Vector2 attackFavorHitboxSize = new Vector2(10, 10);
    [SerializeField] public int attackFavorDamage = 50;
    public bool isAttackingFavor = false;

    [Header("Dashing Attributes")]
    [SerializeField] public int dashSpeed = 1;
    public bool isDashing = false;

    int attackDir = 1;
    public float xDir = 0;
    protected CharacterControls playerControls;
    public StateController stateMachine;
    public EntityFavor entityFavor;

    public Vector2 currentInputMovmentDir = Vector2.zero;

    [Header("Knockback Multipliers")]
    [SerializeField] public float NeutralKnockbackMulti = 15;
    [SerializeField] public float FavorKnockbackMulti = 60;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerControls = new CharacterControls();
        stateMachine = gameObject.GetComponent<StateController>();
        entityFavor = gameObject.GetComponent<EntityFavor>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        xDir = currentInputMovmentDir.x;

        //Direction Sprite flippiage
        if (xDir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            attackDir = -1;
        }
        else if (xDir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            attackDir = 1;
        }
        //Debug.Log("Direction: " + xDir);
        rb.velocity = new Vector2((xDir * speed), rb.velocity.y) + currentEntityKnockback;
        //rb.velocity = new Vector2((xDir * 50 * speed * dashSpeed * Time.deltaTime) + rb.velocity.x, rb.velocity.y);
    }

    public void JumpTriggered(){
        if(isGrounded()){
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    public void MovementTriggered(InputValue value){
        //Debug.Log("Moved");
        
        currentInputMovmentDir = value.Get<Vector2>();
        //need to give this movement a deadzone so if the the abxolute value of x or y is less than .1 then it is 0
        currentInputMovmentDir.x = Mathf.Abs(currentInputMovmentDir.x) < .6 ? 0 : currentInputMovmentDir.x;
        currentInputMovmentDir.y = Mathf.Abs(currentInputMovmentDir.y) < .6 ? 0 : currentInputMovmentDir.y;

        
    }
    public override int takeDamage(int damage, Vector2 knockback, GameObject damageDealer)
    {
        if (stateMachine.machine.state != stateMachine.dashState)
        {
            base.takeDamage(damage, knockback, damageDealer);
            //stateMachine.machine.Set(stateMachine.hurtState);
        }
            return damage;
        
    }

    public override void kill()
    {
        base.kill();
    }

    public void AttackNeutralFront()
    {
        Debug.Log("Attack Neutral Front");
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + attackNeutralOffset, attackNeutralHitboxSize, 0, transform.right * attackDir, attackNeutralDistance, LayerMask.GetMask("Default"));
        //Debug.Log("hit array size: " + hits.Length);

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider.gameObject.GetComponent<characterController>() && hit.collider.gameObject != this.gameObject)
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);

                Entity target = hit.collider.gameObject.GetComponent<characterController>();
                Debug.Log("gameobject: " + gameObject);
                Debug.Log("damage:" + attackNeutralDamage + " knockbac" + Vector2.zero);
                int damageDealt = target.takeDamage(attackNeutralDamage, new Vector2(NeutralKnockbackMulti*attackDir,2), gameObject);
                //favor
                entityFavor.addFavor(damageDealt);

                
            }
        }
        
    }

    public void AttackFavorFront()
    {
        Debug.Log("Favor Attack");
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + attackFavorOffset, attackFavorHitboxSize, 0, transform.right * attackDir, attackNeutralDistance, LayerMask.GetMask("Default"));
        //Debug.Log("hit array size: " + hits.Length);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<characterController>() && hit.collider.gameObject != this.gameObject)
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);

                Entity target = hit.collider.gameObject.GetComponent<characterController>();
                target.takeDamage(attackFavorDamage, new Vector2(FavorKnockbackMulti*attackDir,3), gameObject);
            }
        }

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        //neutral attack box
        Gizmos.DrawWireCube(transform.position + attackNeutralOffset + transform.right * attackNeutralDistance * attackDir, attackNeutralHitboxSize);
        //favor attack box
        Gizmos.DrawWireCube(transform.position + attackFavorOffset + transform.right * attackFavorDistance * attackDir, attackFavorHitboxSize);
    }
}