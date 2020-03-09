using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlHitBuildingEvent : Event
{
    public GameObject clothesLine;
    public ParticleSystem ps;
    public Animator clotheslineanim;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void occur()
    {
        if (occured)
            return;
        base.occur();
        Debug.Log("the owl hit the building!");
        ParticleSystem.EmitParams param = new ParticleSystem.EmitParams();
        param.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ParticleSystem.Particle[] parts = new ParticleSystem.Particle[1];
        ps.GetParticles(parts);
        param.particle = parts[0];
        ps.Emit(30);
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/OwlThud");
        SoundEffectPlayer.instance.Play("Sounds/SoundEffects/OwlScreech");
        clotheslineanim.Play("Clotheslinefalls");
    }
}
