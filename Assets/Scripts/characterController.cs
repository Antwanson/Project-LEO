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
    public bool isTaunting = false;

    [Header("Dashing Attributes")]
    [SerializeField] public int dashSpeed = 1;
    public bool isDashing = false;

    int attackDir = 1;
    public float xDir = 0;
    protected CharacterControls playerControls;
    public StateController stateMachine;
    public EntityFavor entityFavor;

    public Vector2 currentInputMovmentDir = Vector2.zero;

    bool isHSWaiting = false;

    [Header("Knockback Multipliers")]
    [SerializeField] public float NeutralKnockbackMulti = 15;
    [SerializeField] public float FavorKnockbackMulti = 60;
    // Start is called before the first frame update

    //Variables related to movementLock
    public bool isMovementLocked = false;
    public Vector2 lockedVelocity = Vector2.zero;
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

        if(isMovementLocked == false){//Direction Sprite flippiage
            if (xDir < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                //reverse attack offset x for favor and neutral
                attackFavorOffset = new Vector3(-1 * Mathf.Abs(attackFavorOffset.x), attackFavorOffset.y, attackFavorOffset.z);
                attackNeutralOffset = new Vector3(-1 * Mathf.Abs(attackNeutralOffset.x), attackNeutralOffset.y, attackNeutralOffset.z);

                attackDir = -1;
            }
            else if (xDir > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                attackDir = 1;
                //reset attack offset x for favor and neutral
                attackFavorOffset = new Vector3(Mathf.Abs(attackFavorOffset.x), attackFavorOffset.y, attackFavorOffset.z);
                attackNeutralOffset = new Vector3(Mathf.Abs(attackNeutralOffset.x), attackNeutralOffset.y, attackNeutralOffset.z);
            }
        }

        /*if you change the velocity calculation you will have to change lockMovement as well
        calculate velocity in it's own function at that point */
        rb.velocity = movementLockCheck(new Vector2((xDir * speed), rb.velocity.y)) + currentEntityKnockback;
    }

    public void lockMovement(bool retainLockedVelocity, Vector2 lockedVelocity){
        this.isMovementLocked = true;
        if(retainLockedVelocity){
            this.lockedVelocity = new Vector2((xDir * speed), rb.velocity.y) + lockedVelocity;
        }
        else {
            this.lockedVelocity = lockedVelocity;
        }
        
    }

    public void unlockMovement(){
        this.isMovementLocked = false;
        this.lockedVelocity = Vector2.zero;
    }

    public Vector2 movementLockCheck(Vector2 velocity){

        if(isMovementLocked){
            return lockedVelocity;
        }

        return velocity;
    }

    public void HSStop(float duration){
        if(isHSWaiting){
            return;
        }
        Time.timeScale = 0.0f;
        StartCoroutine(HSWait(duration));
    }

    IEnumerator HSWait(float duration){
        isHSWaiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        isHSWaiting = false;
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
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + attackNeutralOffset, attackNeutralHitboxSize, 0, transform.right * attackDir, attackNeutralDistance, LayerMask.GetMask("Player"));
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

                HSStop(.1f);

                
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

                HSStop(.2f);
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