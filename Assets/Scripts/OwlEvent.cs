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
        base.occur();
        Debug.Log("the owl event occured!");
        owl.GetComponent<Animator>().Play("OwlSwoopIntoBuilding");

    }

}
