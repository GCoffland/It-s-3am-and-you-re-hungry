using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 pos;
    public float width;
    public float height;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        width = Camera.main.ViewportToScreenPoint(new Vector3(Camera.main.rect.xMax, 0, 0)).x - Camera.main.ViewportToScreenPoint(new Vector3(Camera.main.rect.xMin, 0, 0)).x;
        height = Camera.main.ViewportToScreenPoint(new Vector3(0, Camera.main.rect.yMax, 0)).y - Camera.main.ViewportToScreenPoint(new Vector3(0, Camera.main.rect.yMin, 0)).y;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = pos + new Vector3(player.transform.position.x * 100 / width, player.transform.position.y * 100 / width, -10);
        transform.position = newPosition;
    }
}
