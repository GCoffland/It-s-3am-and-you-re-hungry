using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private readonly float MOVE_POWER = 1;
    private readonly float JUMP_POWER = 1;
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
            closestObjectInternal.GetComponent<Interactable>().highlighted = false;
            value.GetComponent<Interactable>().highlighted = true;
            closestObjectInternal = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nearbyInteractables = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        closestObject = getClosestInteractable();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MOVE_POWER, 0f);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = rb.velocity + new Vector2(0, JUMP_POWER);
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
