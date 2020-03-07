using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{

    private bool alarm320occured = false;
    private bool alarm340occured = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alarm320occured && Timer.getTime() > 20)
        {
            Events.getEventByType(typeof(AlarmClock320Event)).occur();
            alarm320occured = true;
        }

        if (!alarm340occured && Timer.getTime() > 40)
        {
            Events.getEventByType(typeof(AlarmClock340Event)).occur();
            alarm340occured = true;
        }
    }
}
