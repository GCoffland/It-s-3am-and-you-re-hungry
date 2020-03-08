using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBoxInteractEvent : Event
{
    public override void occur()
    {
        if (occured)
            return;
        base.occur();
        Debug.Log("Flipped the box!");
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void Update()
    {
        
    }
}
