using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanGetsPoweredEvent : Event
{
    public int fanSpeed = 0;
    public bool pieKnockedOff = false;
    public GameObject trail;

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
        if(fanSpeed >= 2 && !pieKnockedOff)
        {
            Events.getEventByType(typeof(PieGetsKnockedOffEvent)).occur();
            pieKnockedOff = true;
            trail.SetActive(false);
        }
        else if (!pieKnockedOff)
        {
            trail.SetActive(true);
        }
    }

    public void powerOff()
    {
        trail.SetActive(false);
        fanSpeed = 0;
        Animator a = GetComponent<Animator>();
        a.Play("FanOff");
    }
}
