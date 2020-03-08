using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParallaxBehaviour : MonoBehaviour
{
    Vector3 scale;
    GameObject player;
    public CameraController cam;
    public float amount = 1;
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
        newScale = scale * .98f + new Vector3(player.transform.position.x * amount / cam.width, 0, 0);
        transform.localScale = newScale;
    }
}
