using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    public Slider slider;

    bool dead = false;
    bool flag = false;
    bool flag2 = false;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !flag) {
            flag = true;
            collision.GetComponent<PlayerManager>().getDamage(damage);
        }
        else if (collision.tag.Equals("Bullet"))
        {
            getDamage(collision.GetComponent<BulletManager>().damage);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            flag = false;
        }
    }

    void getDamage(float damage)
    {
        if (health-damage>=0)
        {
            health -= damage;
        }else
        {
            health = 0;
        }
        slider.value = health;
        onDead();
    }

    void onDead()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
