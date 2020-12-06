using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] int enemiesOnNormal;
    [SerializeField] int enemiesOnHard;
    [SerializeField] SpawnManager sm;
    public static int EASY { get; private set; } = 10;
    public static int NORMAL { get; private set; } = 20;
    public static int HARD { get; private set; } = 50;
    public static int finalScore { get; private set; }

    GameObject player;

    int spawnedEnemies;

    public int score { get; private set; }

    void Start()
    {

    }


    void Update()
    {
        Difficulty_Control();
    }

    void Difficulty_Control()
    {
        if (spawnedEnemies < enemiesOnNormal)
        {
            sm.Spawn_Enemy();
            ++spawnedEnemies;
        }
    }
    public void Update_Score(int score)
    {
        this.score = score;
    }
    public void End_Game(int score)
    {
        finalScore = score;
    }

    public void Connect_With_Player(GameObject player)
    {
        this.player = player;
    }
}
