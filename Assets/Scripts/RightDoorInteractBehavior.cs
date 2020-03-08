using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorInteractBehavior : Interactable
{
    public GameObject FrontWindow;
    public GameObject SideWindows;
    public GameObject Player;


    public override void Interact()
    {
        base.Interact();
        StartCoroutine(goIndoors());
    }

    IEnumerator goIndoors()
    {
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/DoorClosing");
        Player.SetActive(false);
        yield return new WaitForSeconds(1f);
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/LightSwitch");
        FrontWindow.transform.position = FrontWindow.transform.position - new Vector3(0, 0, 2);
        SideWindows.transform.position = SideWindows.transform.position - new Vector3(0, 0, 2);
        yield return new WaitForSeconds(1f);
        AudioSource audios = SoundEffectPlayer.instance.Play("Sounds/SoundEffects/GlassChaos");
        yield return new WaitForSeconds(audios.clip.length + 2f);
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/LightSwitch");
        FrontWindow.transform.position = FrontWindow.transform.position + new Vector3(0, 0, 2);
        SideWindows.transform.position = SideWindows.transform.position + new Vector3(0, 0, 2);
        yield return new WaitForSeconds(1f);
        Player.SetActive(true);
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/DoorClosing");
    }
}
