using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBoxInteractEvent : Event
{
    public GameObject rats;

    public override void occur()
    {
        if (occured)
            return;
        base.occur();
        Debug.Log("Flipped the box!");
        GetComponent<SpriteRenderer>().color = Color.red;
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/RatSqueek");
        GetComponent<Animator>().Play("OpenBox");
    }
    
}
