using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorInteractable : Interactable
{
    public override void Interact()
    {
        base.Interact();
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/Rattle");
        GetComponent<Animator>().Play("Rattle");
    }
}
