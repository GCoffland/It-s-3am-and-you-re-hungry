using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanGetsPoweredEvent : Event
{
    public int fanSpeed = 0;
    public bool pieKnockedOff = false;

    public override void occur()
    {
        Animator a = GetComponent<Animator>();
        base.occur();
        if(fanSpeed == 0)
        {
            a.Play("Blowing4Real");
        }
        fanSpeed++;
        a.speed = fanSpeed;
        if(fanSpeed > 4 && !pieKnockedOff)
        {
            Events.getEventByType(typeof(PieGetsKnockedOffEvent)).occur();
        }
    }
}
