using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlEvent : Event
{
    public GameObject owl;
    public GameObject exclamation;

    // Update is called once per frame
    void Update()
    {

    }

    public override void occur()
    {
        if (occured)
            return;
        StartCoroutine(occurHelper());
        base.occur();
    }

    public IEnumerator occurHelper()
    {

        Debug.Log("the owl event occured!");
        yield return new WaitForSeconds(.5f);
        exclamation.GetComponent<Animator>().Play("ShowExclamation");
        yield return new WaitForSeconds(1.25f);
        if (Events.getEventByType(typeof(CardboardBoxInteractEvent)).occured)
            owl.GetComponent<Animator>().Play("OwlSwoopAtRats");
        else
            owl.GetComponent<Animator>().Play("OwlSwoopIntoBuilding");
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/OwlTakeOff");
    }

}
