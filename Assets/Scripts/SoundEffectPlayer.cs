using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public static SoundEffectPlayer instance;
    private List<AudioSource> players;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        players = new List<AudioSource>();
    }

    public void Play(string path)
    {
        AudioSource p = getAvailablePlayer();
        p.clip = Resources.Load<AudioClip>(path);
        p.Play();
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
