using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWinMunching : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/MunchingWin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
