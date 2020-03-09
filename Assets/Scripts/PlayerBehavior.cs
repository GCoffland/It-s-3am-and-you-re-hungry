using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private readonly float MOVE_POWER = 20;
    private readonly float JUMP_POWER = 27;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private List<GameObject> nearbyInteractables;
    private GameObject closestObjectInternal;
    private bool smelling = false;

    public Transform scentTrailEnd;

    public GameObject closestObject
    {
        get
        {
            return closestObjectInternal;
        }
        private set
        {
            if(closestObjectInternal != null)
            {
                closestObjectInternal.GetComponent<Interactable>().highlighted = false;
            }
            if(value != null)
            {
                value.GetComponent<Interactable>().highlighted = true;
            }
            closestObjectInternal = value;
        }
    }
    private bool grounded;
    private bool canClimb;
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        nearbyInteractables = new List<GameObject>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim.SetBool("Smelling", smelling);
    }

    // Update is called once per frame
    void Update()
    {
        if (smelling)
        {
            if (transform.position.x < scentTrailEnd.position.x && transform.position.y < scentTrailEnd.position.y + 5 && transform.position.y > scentTrailEnd.position.y - 5)
            {
                rb.velocity = new Vector2(4, 0);
                sr.flipX = !(transform.position.x < scentTrailEnd.position.x);
            }
            else
            {
                smelling = false;
                anim.SetBool("Smelling", smelling);
                rb.gravityScale = 8;
            }
        }
        else
        {
            grounded = isGrounded();
            closestObject = getClosestInteractable();
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MOVE_POWER, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && grounded)
            {
                anim.Play("RacoonJump");
                rb.velocity = new Vector2(rb.velocity.x, 0) + new Vector2(0, JUMP_POWER);
            }
            if (Input.GetButtonDown("Interact"))
            {
                if (closestObject != null)
                {
                    closestObject.GetComponent<Interactable>().Interact();
                }
            }
            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
            anim.SetFloat("HorizontalVelocity", rb.velocity.x);
            anim.SetFloat("VerticalVelocity", rb.velocity.y);
            anim.SetBool("IsGrounded", grounded);
        }
        if (Input.GetKeyDown("q"))
        {
            grabScentTrail();
        }
        if(canClimb && !isClimbing && Input.GetAxis("Vertical") > 0.1)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            isClimbing = true;
        }
        if (isClimbing)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MOVE_POWER, Input.GetAxis("Vertical") * MOVE_POWER);
        }
        if(isClimbing && !canClimb)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            isClimbing = false;
        }
        anim.SetFloat("HorizontalVelocity", rb.velocity.x);
        anim.SetFloat("VerticalVelocity", rb.velocity.y);
        anim.SetBool("IsGrounded", grounded);
        anim.SetBool("IsClimbing", isClimbing);
    }

    private GameObject getClosestInteractable()
    {
        if(nearbyInteractables.Count == 0)
        {
            return null;
        }
        GameObject closestObject = nearbyInteractables[0];
        foreach(GameObject go in nearbyInteractables)
        {
            float temp = (go.transform.position - transform.position).magnitude;
            if (temp < (closestObject.transform.position - transform.position).magnitude)
            {
                closestObject = go;
            }
        }
        return closestObject;
    }

    private bool isGrounded()
    {
        ContactPoint2D[] points = new ContactPoint2D[10];
        int num = gameObject.GetComponent<BoxCollider2D>().GetContacts(points);
        for(int i = 0; i < num; i++)
        {
            if (points[i].point.y <= gameObject.GetComponent<BoxCollider2D>().bounds.min.y + 0.01)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Interactable>() != null)
        {
            nearbyInteractables.Add(collision.gameObject);
        }else if(collision.gameObject.GetComponent<clotheslineInteractable>() != null)
        {
            canClimb = collision.gameObject.GetComponent<Animator>().GetBool("HasFallen");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() != null)
        {
            nearbyInteractables.Remove(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<clotheslineInteractable>() != null)
        {
            canClimb = false;
        }
    }

    public void grabScentTrail()
    {
        smelling = true;
        anim.SetBool("Smelling", smelling);
        rb.gravityScale = 0;
        anim.Play("Float");
        
    }
}
