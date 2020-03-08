using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Events instance;
    public Dictionary<System.Type, Event> events;
    public Event owlEvent;
    public Event owlBouncedOffBuilding;

    private bool owlSpooked;

    // On this line at 1:24 pm, gabe was wrong
    private void Awake()
    {
        instance = this;
        events = new Dictionary<System.Type, Event>();
    }

    public static void addEvent(System.Type type, Event e)
    {
        instance.events.Add(type, e);
    }

    public static Event getEventByType(System.Type type)
    {
        return instance.events[type];
    }

    public void printEventData()
    {
        Debug.Log("----------------Printing all event data------------------");
        foreach(KeyValuePair<System.Type, Event> pair in events)
        {
            Debug.Log(pair.Key.ToString() + " has " + (pair.Value.occured ? "" : " not ") + "occured");
        }
        Debug.Log("--------------------End event data-----------------------");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            printEventData();
    }

}
