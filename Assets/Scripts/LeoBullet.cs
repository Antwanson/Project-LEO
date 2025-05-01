using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LeoBullet : Entity
{
    [SerializeField] public Vector2 hitBoxSize = Vector2.zero;
    [SerializeField] public int hitDistance = 1;
    [SerializeField] public int knockbackMulti = 60;
    [SerializeField] Vector3 dir;

    [SerializeField] GameObject parentObject;
    LayerMask characterLayer;

    protected override void Start()
    {
        base.Start();
        //rb.velocity = new Vector2(100, 0);

        characterLayer = LayerMask.GetMask("Player");

        Debug.Log("Bullet Velocity: " + rb.velocity);
    }

    protected override void FixedUpdate()
    {
        //checkForHit();

        //transform.position += dir * speed * Time.deltaTime;
    }

    public void SetUp(int dir, GameObject parent)
    {

        //rigidbody doesn't always read, re-getting it fixes this
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("rb !null: " + (rb != null));

        rb.velocity = new Vector2(dir * 100, 0);
        this.parentObject = parent;
    }

    public void checkForHit()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, hitBoxSize, 0, transform.right, hitDistance, characterLayer);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<characterController>() && hit.collider.gameObject != this.gameObject && hit.collider.gameObject != parentObject)
            {
                Debug.Log("Bullet hit: " + hit.collider.gameObject.name);

                Entity target = hit.collider.gameObject.GetComponent<characterController>();
                Debug.Log("gameobject: " + gameObject);
                Debug.Log("damage:" + this.damage + " knockbac" + Vector2.zero);
                int damageDealt = target.takeDamage(this.damage, new Vector2(knockbackMulti, 2), gameObject);

                //HSStop(.1f); //<- unsure what this function does


            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;

        if (target.GetComponent<characterController>() != null && target != this.parentObject)
            target.GetComponent<characterController>().takeDamage(this.damage, new Vector2(knockbackMulti, 2), gameObject);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireCube(transform.position, hitBoxSize);
    }
}
