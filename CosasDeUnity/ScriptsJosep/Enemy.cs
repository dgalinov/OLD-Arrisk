
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int healt = 100;

    public GameObject deathEffect;
    public GameObject impactEffect;
    public GameObject shoot;
    public GameObject item;
    public GameObject test;


    public void TakeDamage(int damage)
    {
        healt -= damage;

        if (healt <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (Random.Range(0, 100) <= 100)
        {
            Object.Instantiate(item, transform.position, Quaternion.identity);
        }


    }




}
