using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float currentTime;
    private float scale = 2f;
    private float startTime;
    private static Timer instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - startTime;
        currentTime *= scale;
    }

    public static int getTime()
    {
        return (int)instance.currentTime;
    }
}
