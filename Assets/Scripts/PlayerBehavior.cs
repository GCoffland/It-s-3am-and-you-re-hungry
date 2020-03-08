using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private readonly float MOVE_POWER = 20;
    private readonly float JUMP_POWER = 45;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private List<GameObject> nearbyInteractables;
    private GameObject closestObjectInternal;
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

    // Start is called before the first frame update
    void Start()
    {
        nearbyInteractables = new List<GameObject>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
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
            if(closestObject != null)
            {
                closestObject.GetComponent<Interactable>().Interact();
            }
        }
        if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
        anim.SetFloat("HorizontalVelocity", rb.velocity.x);
        anim.SetFloat("VerticalVelocity", rb.velocity.y);
        anim.SetBool("IsGrounded", grounded);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() != null)
        {
            nearbyInteractables.Remove(collision.gameObject);
        }
    }
}
