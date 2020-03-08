using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlarmClockNumbers : MonoBehaviour
{
    private TextMeshProUGUI text;
    Transform anchor;
    // Start is called before the first frame update
    void Start()
    {
        anchor = GameObject.Find("AlarmClockTransform").transform;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(anchor.position);
        int time = Timer.getTime();
        char firstDigit = '3';
        if (time >= 60)
        {
            time %= 60;
            firstDigit++;
        }
        if (time < 1)
            text.text = firstDigit + ":00";
        else if (time < 10)
            text.text = firstDigit + ":0" + time;
        else if (time < 60)
            text.text = firstDigit + ":" + time;

    }
}
