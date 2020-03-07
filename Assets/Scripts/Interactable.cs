using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private bool highlightedInternal;
    public bool highlighted
    {
        get
        {
            return highlightedInternal;
        }
        set
        {
            if (value)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
            else
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {

    }

}
