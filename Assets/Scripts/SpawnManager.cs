using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int bonusAmount;
    [SerializeField] float bonusSpawnCooldown;
    [SerializeField] EventManager em;
    [SerializeField] Transform playerSpawn;
    //[SerializeField] Transform [] enemySpawn;
    [SerializeField] Transform[] bonusSpawns;
    [SerializeField] Text scoreText;

    List<int> occupied = new List<int>();
    List<int> unoccupied = new List<int>();

    SnowMan player;

    float timeToSpawn = 0;
    int activeBonuses = 0;


    void Start()
    {
        Spawn_Player();
        for (int i = 0; i < bonusSpawns.Length; i++)
            unoccupied.Add(i);
    }

    void Update()
    {
        if (activeBonuses < bonusAmount)
            Spawn_Bonus();
        scoreText.text = player.score.ToString();
    }

    void Spawn_Player()
    {
        player = Instantiate(ResourceLoader.PLAYER, playerSpawn).GetComponent<SnowMan>();
        player.Connect_With_EventManager(em);
    }

    void Spawn_Bonus()
    {
        if (timeToSpawn < Time.time)
        {
            int bonus_id = Bonus_Occupy();
            GameObject bonus = Instantiate(ResourceLoader.BONUS, bonusSpawns[bonus_id]);
            bonus.GetComponent<Bonus>().Connect_With_SpawnManager(this, bonus_id);
            ++activeBonuses;
            timeToSpawn = Time.time + bonusSpawnCooldown;
        }
    }

    int Bonus_Occupy()
    {
        int choice = Random.Range(0, unoccupied.Count);
        int bonus_id = unoccupied[choice];
        unoccupied.Remove(bonus_id);
        occupied.Add(bonus_id);
        return bonus_id;
    }

    public void Bonus_Respawn(int bonus_id)
    {
        Spawn_Bonus();
        --activeBonuses;
        occupied.Remove(bonus_id);
        unoccupied.Add(bonus_id);
    }
}
