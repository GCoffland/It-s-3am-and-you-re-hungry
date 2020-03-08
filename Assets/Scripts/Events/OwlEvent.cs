using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlEvent : Event
{
    public GameObject owl;

    // Update is called once per frame
    void Update()
    {

    }

    public override void occur()
    {
        if (occured)
            return;
        Debug.Log("the owl event occured!");
        if (owl != null)
        {
            if (Events.getEventByType(typeof(CardboardBoxInteractEvent)).occured)
                owl.GetComponent<Animator>().Play("OwlSwoopAtRats");
            else
                owl.GetComponent<Animator>().Play("OwlSwoopIntoBuilding");
        }
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/OwlTakeOff");
        base.occur();
    }

}
