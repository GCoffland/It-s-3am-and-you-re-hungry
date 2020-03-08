using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGuyTakesOutTrashEvent : Event
{
    public override void occur()
    {
        if (occured)
            return;
        base.occur();
        if (Events.getEventByType(typeof(CardboardBoxInteractEvent)).occured)
        {
            // Here we get spooked
            Debug.Log("did me a heckin fright!");
        }
        else
        {
            Debug.Log("Takin out the trasshshshshhhhh");
            // Take out trash
        }
    }
}
