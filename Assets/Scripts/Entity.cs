using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


// Base class for all entities in the game, please extend this class for all entities.
// This class is not abstract, but it is rocommended to only be used for testing purposes if not extended.

public class Entity : MonoBehaviour
{
    
    protected Rigidbody2D rb;
    protected EntityHealth health;

    // common attributes
    [Header("Common Attributes")]
    [SerializeField] protected int damage = 10;
    [SerializeField] protected int speed = 10;
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
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        takeDamage(1, Vector2.zero); 
        if(health.getHP() == 0){
            kill();
        }
    }

    protected virtual void FixedUpdate()
    {
        
    }
    // checks if grounded
    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer)){
            return true;
        } else {
            return false;
        }
    }
    void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
    public void takeDamage(int damage, Vector2 knockback){//TODO: ADD VARIABLE FOR PLAYER REFERENCE
        health.takeDamage(damage);
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    public void kill(){
        Destroy(gameObject);
    }
    
}
//jjkljjk