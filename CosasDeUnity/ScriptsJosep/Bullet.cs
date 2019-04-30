using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    
    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
	}

    

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
