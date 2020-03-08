using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOfSpriteBehaviour : MonoBehaviour
{
    Material m;
    List<Color> cs = new List<Color>() { Color.black, Color.blue, Color.cyan, Color.green, Color.red, Color.yellow, Color.magenta };

    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<SpriteRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        m.SetColor("_Color", cs[UnityEngine.Random.Range(0, cs.Count)]);
    }
}
