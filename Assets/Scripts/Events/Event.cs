﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public bool occured = false;

    void Start()
    {
        Events.addEvent(GetType(), this);
        onStart();
    }

    protected virtual void onStart() { }

    private void Update()
    {

    }

    public virtual void occur()
    {
        occured = true;
    }

}
