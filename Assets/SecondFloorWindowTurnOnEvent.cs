using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorWindowTurnOnEvent : Event
{
    public override void occur()
    {
        base.occur();
        transform.position = transform.position + new Vector3(0, 0, -2);
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/LightSwitch");
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/Grumpy");

        StartCoroutine(turnOffLight());
    }

    public IEnumerator turnOffLight()
    {
        yield return new WaitForSeconds(4f);
        ((FanGetsPoweredEvent)Events.getEventByType(typeof(FanGetsPoweredEvent))).powerOff();
        yield return new WaitForSeconds(3f);
        transform.position = transform.position + new Vector3(0, 0, 2);
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/LightSwitch");
    }
}
