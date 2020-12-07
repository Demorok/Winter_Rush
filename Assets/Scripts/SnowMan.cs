using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
    [SerializeField] float impulsePower;
    [SerializeField] float impulseAngle;

    KeyCode up = KeyCode.W;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;

    Vector2 leftImpulse;
    Vector2 rightImpulse;

    AudioSource audio_player;
    Rigidbody2D snowman;
    EventManager em;

    public int score { get; private set; }

    void Start()
    {
        audio_player = gameObject.GetComponent<AudioSource>();
        snowman = transform.GetComponent<Rigidbody2D>();
        Calculate_Impulses();
    }

    void Update()
    {
        Player_Controller();
        em.Update_Score(score);
    }

    void Calculate_Impulses()
    {
        leftImpulse = Turn_Vector(impulseAngle);
        rightImpulse = Turn_Vector(-impulseAngle);
    }

    Vector2 Turn_Vector(float angle)
    {
        float x = -(Mathf.Sin(Mathf.Deg2Rad * angle)); //Default direction is Vector2.up, so here is a simplified formula
        float y = Mathf.Cos(Mathf.Deg2Rad * angle);
        return new Vector2(x, y);
    }

    void Player_Controller()
    {
        if (Input.GetKeyDown(up))
            Jump(Vector2.up);
        else if (Input.GetKeyDown(left))
            Jump(leftImpulse);
        else if (Input.GetKeyDown(right))
            Jump(rightImpulse);
    }
    void Jump(Vector2 impulse)
    {
        snowman.AddForce(impulse * impulsePower, ForceMode2D.Impulse);
        audio_player.PlayOneShot(ResourceLoader.JUMP);
    }

    public void Collect_Bonus(int value)
    {
        this.score += value;
        audio_player.PlayOneShot(ResourceLoader.COLLECT);
    }

    public void Connect_With_EventManager(EventManager em)
    {
        this.em = em;
    }

    private void OnDestroy()
    {
        em.End_Game(score);
        GameUtility.End_Game();
    }
}
