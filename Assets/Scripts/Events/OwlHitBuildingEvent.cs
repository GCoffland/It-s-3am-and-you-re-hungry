using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlHitBuildingEvent : Event
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void occur()
    {
        if (occured)
            return;
        base.occur();
        Debug.Log("the owl hit the building!");
    }
}
