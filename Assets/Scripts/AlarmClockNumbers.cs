using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlarmClockNumbers : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.WorldToScreenPoint(GameObject.Find("AlarmClockTransform").transform.position);
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.getTime() < 1)
            text.text = "3:00";
        else if (Timer.getTime() < 10)
            text.text = "3:0" + Timer.getTime();
        else
            text.text = "3:" + Timer.getTime();
        
    }
}
