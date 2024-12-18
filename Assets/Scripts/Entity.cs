using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


// Base class for all entities in the game, please extend this class for all entities.
// This class is not abstract, but it is rocommended to only be used for testing purposes if not extended.

public class Entity : MonoBehaviour
{
    
    protected Rigidbody2D rb;
    protected EntityHealth health;

    protected EntityFavor favor;

    public Vector2 currentEntityKnockback;
    // common attributes
    [Header("Common Attributes")]
    [SerializeField] protected int damage = 10;
    [SerializeField] protected int speed = 15;
    [SerializeField] protected int maxSpeed = 15;
    [SerializeField] protected int jumpPower = 10;
    [SerializeField] protected int attackSpeed = 1;
    

    // boxcast attributes for grounded check
    [Header("Grounded Check Raycast")]
    [SerializeField] public Vector2 boxSize;
    [SerializeField] public float castDistance;
    [SerializeField] public LayerMask groundLayer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<EntityHealth>();
        favor = GetComponent<EntityFavor>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        if(health.getHP() == 0){
            kill();
        }
    }

    protected virtual void FixedUpdate()
    {
        //This is a test for the takeDamage method
        //takeDamage(1, Vector2.zero, gameObject);
        //Debug.Log(takeDamage(1, Vector2.zero, gameObject));
        currentEntityKnockback = currentEntityKnockback * .80f;
        if (Mathf.Abs(currentEntityKnockback.x) < 1)
        {
            currentEntityKnockback.x = 0;
        }
        if (Mathf.Abs(currentEntityKnockback.y) < 1)
        {
            currentEntityKnockback.y = 0;
        }

        
    }
    
    // checks if grounded
    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer)){
            return true;
        } else {
            return false;
        }
    }
    public virtual void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
    public virtual int takeDamage(int damage, Vector2 knockback, GameObject damageDealer){//TODO: ADD VARIABLE FOR PLAYER REFERENCE
        health.takeDamage(damage);
        //rb.AddForce(knockback, ForceMode2D.Impulse);
        //rb.velocity = rb.velocity + knockback;
        currentEntityKnockback = knockback;
        //favor.takeDamage(damage);
        return damage;
    }

    public virtual void kill(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D o){
        if (o.tag == "KillZone"){
            kill();
        }
    }
    
}
//jjkljjkj