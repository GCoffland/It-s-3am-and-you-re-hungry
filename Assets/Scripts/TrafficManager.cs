using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{

    public GameObject carPrefab;
    public float frequency = .000000001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Random.value > (1 - frequency))
        {
            Events.getEventByType(typeof(CarDrivesByEvent)).occur();
        }
        if (UnityEngine.Random.value > (1 - frequency))
        {
            Events.getEventByType(typeof(CarDrivesByFromRightEvent)).occur();
        }
    }
}
