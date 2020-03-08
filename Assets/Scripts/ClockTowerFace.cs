using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTowerFace : MonoBehaviour
{

    public GameObject minuteHand;
    public GameObject hourHand;
    // Start is called before the first frame update
    void Start()
    {
        hourHand.transform.eulerAngles = new Vector3(0, 0, -30 * 3);
    }

    // Update is called once per frame
    void Update()
    {

        minuteHand.transform.eulerAngles = new Vector3(0, 0, -6 * Timer.getTime());
    }
}
