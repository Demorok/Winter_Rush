using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] EventManager em;

    AudioSource audio_player;
    void Start()
    {
        audio_player = gameObject.GetComponent<AudioSource>();
        audio_player.PlayOneShot(ResourceLoader.INTRO);
    }
    private void Update()
    {
        Play_Music();
    }
    void Play_Music()
    {
        if (!audio_player.isPlaying)
            if (em.score <= EventManager.EASY)
            Play_Easy_Music();
            else if (em.score <= EventManager.NORMAL)
                Play_Normal_Music();
            else
                Play_Hard_Music();
    }

    void Play_Easy_Music()
    {
        audio_player.PlayOneShot(ResourceLoader.INTRO);
        audio_player.PlayOneShot(ResourceLoader.EASY);
    }

    void Play_Normal_Music()
    {
        Play_Easy_Music();
        audio_player.PlayOneShot(ResourceLoader.NORMAL); ;
    }

    void Play_Hard_Music()
    {
        Play_Normal_Music();
        audio_player.PlayOneShot(ResourceLoader.HARD); ;
    }
}
