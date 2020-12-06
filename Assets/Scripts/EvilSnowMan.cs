using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSnowMan : MonoBehaviour
{
    //[SerializeField] Transform leftBoard;
    //[SerializeField] Transform rightBoard;

    [SerializeField] float snowballSpeed;
    [SerializeField] float shootCooldown;

    Transform target;
    float timeToShoot;
    public void Get_Target(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target != null)
            Shoot();
    }

    void Shoot()
    {
        if (timeToShoot <= Time.time)
        {
            GameObject snowball = Instantiate(ResourceLoader.BADSNOWBALL, transform);
            snowball.GetComponent<Rigidbody2D>().AddForce((target.position - transform.position).normalized * snowballSpeed, ForceMode2D.Impulse);
            timeToShoot = Time.time + shootCooldown;
        }
    }
}
