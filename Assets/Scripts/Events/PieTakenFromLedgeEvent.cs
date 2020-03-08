using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieTakenFromLedgeEvent : Event
{
    public override void occur()
    {
        base.occur();
        GameObject.Find("PieGoneText").GetComponent<PieIsGoneTextBehaviour>().startDisplayingText();
        Debug.Log("THE PIE. THE PIE IS GONE. DEAR SWEET RACCOON JESUS THE PIE HAS BEEN TAKEN. OH GOD NO, I WILL NEVER TASTE THE SWEET FRUITY FLESH OF THAT BEAUTIFUL SUGAR FILLED PASTRY. (game over)");
    }
}
