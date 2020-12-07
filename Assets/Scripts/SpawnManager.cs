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
    [SerializeField] Transform [] enemySpawns;
    [SerializeField] Transform[] bonusSpawns;
    [SerializeField] Text scoreText;

    List<int> bonusOccupied = new List<int>();
    List<int> bonusUnoccupied = new List<int>();

    List<int> enemyOccupied = new List<int>();
    List<int> enemyUnoccupied = new List<int>();

    SnowMan player;
    Transform target;

    float timeToSpawn = 0;
    int activeBonuses = 0;


    void Start()
    {
        Spawn_Player();
        for (int i = 0; i < bonusSpawns.Length; i++)
            bonusUnoccupied.Add(i);
        for (int i = 0; i < enemySpawns.Length; i++)
            enemyUnoccupied.Add(i);
    }

    void Update()
    {
        if (activeBonuses < bonusAmount)
            Spawn_Bonus();
        scoreText.text = player.score.ToString();
    }

    void Spawn_Player()
    {
        GameObject clone = Instantiate(ResourceLoader.PLAYER, playerSpawn);
        target = clone.GetComponent<Transform>();
        player = clone.GetComponent<SnowMan>();
        player.Connect_With_EventManager(em);
        em.Connect_With_Player(clone);
    }

    public void Spawn_Enemy()
    {
        int enemy_id = Occupy(enemyOccupied, enemyUnoccupied);
        GameObject clone = Instantiate(ResourceLoader.ENEMY, enemySpawns[enemy_id]);
        clone.GetComponent<EvilSnowMan>().Get_Target(target);
    }

    void Spawn_Bonus()
    {
        if (timeToSpawn < Time.time)
        {
            int bonus_id = Occupy(bonusOccupied, bonusUnoccupied);
            GameObject bonus = Instantiate(ResourceLoader.BONUS, bonusSpawns[bonus_id]);
            bonus.GetComponent<Bonus>().Connect_With_SpawnManager(this, bonus_id);
            ++activeBonuses;
            timeToSpawn = Time.time + bonusSpawnCooldown;
        }
    }

    int Occupy(List<int> occupied, List<int> unoccupied)
    {
        int choice = Random.Range(0, unoccupied.Count);
        int place_id = unoccupied[choice];
        unoccupied.Remove(place_id);
        occupied.Add(place_id);
        return place_id;
    }

    public void Bonus_Respawn(int bonus_id)
    {
        Spawn_Bonus();
        --activeBonuses;
        bonusOccupied.Remove(bonus_id);
        bonusUnoccupied.Add(bonus_id);
    }
}
