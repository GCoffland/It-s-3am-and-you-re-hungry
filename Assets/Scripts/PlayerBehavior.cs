using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private readonly float MOVE_POWER = 4;
    private readonly float JUMP_POWER = 5;
    [SerializeField]
    private Rigidbody2D rb;
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

    // Start is called before the first frame update
    void Start()
    {
        nearbyInteractables = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        closestObject = getClosestInteractable();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MOVE_POWER, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0) + new Vector2(0, JUMP_POWER);
        }
        if (Input.GetButtonDown("Interact"))
        {
            if(closestObject != null)
            {
                closestObject.GetComponent<Interactable>().Interact();
            }
        }
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
