using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock320Event : Event
{
    public override void occur()
    {
        if (occured)
            return;
        Events.getEventByType(typeof(OwlEvent)).occur();
        base.occur();
    }
}
