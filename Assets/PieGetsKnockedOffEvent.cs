using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieGetsKnockedOffEvent : Event
{
    public override void occur()
    {
        base.occur();
        Debug.Log("pie fall");
        transform.parent.GetComponent<Animator>().Play("PieFall");
    }
}
