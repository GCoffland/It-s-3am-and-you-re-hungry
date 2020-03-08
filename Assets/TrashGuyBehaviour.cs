using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGuyBehaviour : MonoBehaviour
{

    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!started && Timer.getTime() > 18)
        {
            GetComponent<Animator>().Play("TrashGuy");
            transform.parent.GetComponent<Animator>().Play("TrashGuyMove");
            started = true;
        }
    }
}
