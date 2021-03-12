using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;
    bool dead = false;

    Transform muzzle;
    public Transform bullet;
    public Slider slider;
    Rigidbody2D bulletForce;

    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }

    public void getDamage(float damage)
    {
        if (health-damage >= 0)
        {
            health -= damage;
        }else
        {
            health = 0;
        }
        slider.value = health;
        onDead();
    }

    public void onDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }

    void shootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }

}
