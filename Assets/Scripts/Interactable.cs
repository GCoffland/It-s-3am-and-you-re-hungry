using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private bool highlightedInternal;
    private Material initalMaterial;
    private Material highlightedMaterial;
    private SpriteRenderer sr;

    
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
                sr.sharedMaterial = highlightedMaterial;
            }
            else
            {
                sr.sharedMaterial = initalMaterial;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highlightedInternal = false;
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            initalMaterial = sr.sharedMaterial;
            highlightedMaterial = (Material)Resources.Load("Materials/ShaderMaterial");
        }
    }
    

    public virtual void Interact()
    {

    }

}
