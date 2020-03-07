using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock340Event : Event
{
    public override void occur()
    {
        Debug.Log("3:40 blaze it");
        base.occur();
    }
}