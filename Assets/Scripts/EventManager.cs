using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] AudioSource intro;
    [SerializeField] AudioSource easy;
    [SerializeField] AudioSource normal;
    [SerializeField] AudioSource hard;
    public static int EASY { get; private set; } = 10;
    public static int NORMAL { get; private set; } = 20;
    public static int HARD { get; private set; } = 50;
    public static int finalScore { get; private set; }

    int score;

    void Start()
    {
        intro.Play();
    }


    void Update()
    {
        Music_Control();
        Difficulty_Control();
    }

    void Difficulty_Control()
    {

    }
    void Music_Control()
    {
        if (!Music_is_Playing())
            Play_Random_Music();
    }

    bool Music_is_Playing()
    {
        if (intro.isPlaying | easy.isPlaying | normal.isPlaying | hard.isPlaying)
            return true;
        return false;
    }

    void Play_Random_Music()
    {
        intro.Play();
        if (Random.Range(0, 2) == 1)
            easy.Play();
        if (Random.Range(0, 2) == 1)
            normal.Play();
        if (Random.Range(0, 2) == 1)
            hard.Play();
    }

    void Play_Music()
    {
        if (score <= EASY)
            Play_Easy_Music();
        else if (score <= NORMAL)
            Play_Normal_Music();
        else
            Play_Hard_Music();
    }

    void Play_Easy_Music()
    {
        intro.Play();
        easy.Play();
    }

    void Play_Normal_Music()
    {
        Play_Easy_Music();
        normal.Play();
    }

    void Play_Hard_Music()
    {
        Play_Normal_Music();
        hard.Play();
    }

    public void Update_Score(int score)
    {
        this.score = score;
    }
    public void End_Game(int score)
    {
        finalScore = score;
    }
}
