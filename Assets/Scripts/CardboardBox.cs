using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBox : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Events.getEventByType(typeof(CardboardBoxInteractEvent)).occur();
    }
}
