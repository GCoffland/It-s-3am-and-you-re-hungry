using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieInteractable : Interactable
{
    bool done;
    public override void Interact()
    {
        if (done)
            return;
        base.Interact();
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/GotPie");
        GameObject.Find("pie").GetComponent<Animator>().Play("PieFloat");
        done = true;
    }
}
