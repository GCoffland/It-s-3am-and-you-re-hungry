using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public static SoundEffectPlayer instance;
    private List<AudioSource> players;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        players = new List<AudioSource>();
    }

    public AudioSource Play(string path)
    {
        AudioSource p = getAvailablePlayer();
        p.clip = Resources.Load<AudioClip>(path);
        p.Play();
        return p;
    }

    public AudioSource PlayOnDelay(string path, float delay)
    {
        AudioSource p = getAvailablePlayer();
        p.clip = Resources.Load<AudioClip>(path);
        p.PlayDelayed(delay);
        return p;
    }

    private AudioSource getAvailablePlayer()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (!players[i].isPlaying)
            {
                return players[i];
            }
        }
        players.Add(gameObject.AddComponent<AudioSource>());
        return players[players.Count - 1];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (!players[i].isPlaying)
            {
                players.Remove(players[i]);
            }
        }
    }
}
