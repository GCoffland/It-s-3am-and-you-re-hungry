﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmClock : MonoBehaviour
{

    private bool alarm320occured = false;
    private bool alarm340occured = false;
    private bool alarm400occured = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alarm320occured && Timer.getTime() >= 20)
        {
            Events.getEventByType(typeof(AlarmClock320Event)).occur();
            alarm320occured = true;
        }

        if (!alarm340occured && Timer.getTime() >= 40)
        {
            Events.getEventByType(typeof(AlarmClock340Event)).occur();
            alarm340occured = true;
        }

        if (!alarm400occured && Timer.getTime() > 59)
        {
            Events.getEventByType(typeof(PieTakenFromLedgeEvent)).occur();
            alarm400occured = true;
        }
        if(Timer.getTime() >= 70)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
