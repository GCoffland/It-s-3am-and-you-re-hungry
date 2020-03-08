using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlDivesRatsEvent : Event
{
    public override void occur()
    {
        base.occur();
        Debug.Log("That owl got kenny! That bastard!");
    }
}
