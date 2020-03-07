using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock320Event : Event
{
    public override void occur()
    {
        Debug.Log("3:20 blaze it");
        base.occur();
    }
}
