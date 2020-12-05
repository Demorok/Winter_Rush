using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] float timeToLive;

    SpawnManager sm;
    int id;

    float timetoDestroy;

    private void Start()
    {
        timetoDestroy = Time.time + timeToLive;
    }

    private void Update()
    {
        if (timetoDestroy <= Time.time)
            Destroy(gameObject);
    }

    public void Connect_With_SpawnManager(SpawnManager sm, int id)
    {
        this.sm = sm;
        this.id = id;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SnowMan player = collision.GetComponent<SnowMan>();
            player.Collect_Bonus(value);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        sm.Bonus_Respawn(id);
    }
}
