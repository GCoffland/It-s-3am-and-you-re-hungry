using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    Vector3 pos;
    GameObject player;
    public CameraController cam;
    public float amount = 1;
    public bool foreground = false;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition;
        if(foreground)
            newPosition = pos - new Vector3(player.transform.position.x * amount / cam.width, 0, 0);
        else
            newPosition = pos + new Vector3(player.transform.position.x * amount / cam.width, 0, 0);
        transform.position = newPosition;
    }
}
