using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParallaxBehaviour : MonoBehaviour
{
    Vector3 scale;
    GameObject player;
    public CameraController cam;
    public float amount = 1;
    public bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale;
        if(reverse)
            newScale = scale - new Vector3((player.transform.position.x + 0.2f ) * amount / cam.width, 0, 0);
        else
            newScale = scale * .98f + new Vector3(player.transform.position.x * amount / cam.width, 0, 0);
        transform.localScale = newScale;
    }
}
