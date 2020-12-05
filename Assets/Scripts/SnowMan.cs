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

    Rigidbody2D snowman;
    EventManager em;

    public int score { get; private set; }

    void Start()
    {
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
            snowman.AddForce(Vector2.up * impulsePower, ForceMode2D.Impulse);
        else if (Input.GetKeyDown(left))
            snowman.AddForce(leftImpulse * impulsePower, ForceMode2D.Impulse);
        else if (Input.GetKeyDown(right))
            snowman.AddForce(rightImpulse * impulsePower, ForceMode2D.Impulse);
    }

    public void Collect_Bonus(int value)
    {
        this.score += value;
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
