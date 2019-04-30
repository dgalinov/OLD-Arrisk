
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform Bullet;
    public GameObject DefaultBulletPrefab;
    public GameObject FireBulletPrefab;
    public GameObject FireGreenBulletPrefab;
    public float defaultFireRate;
    public float fireRate;
    public float greenFireRate;
    private float nextFire;
    public int defaultMana = 100;
    public int mana = 100;
    public bool fireShoot = false;
    public bool greenFireShoot = false;
    public bool defaultShoot = true;
    public int fireShootMana = 15;
    public int greenFireShootMana = 25;
    public int defaultShootMana = 10;
    // Update is called once per frame
    
    void Update () {
        if (mana > defaultMana)
        {
            mana = defaultMana;
        }
        if (Input.GetButtonDown("SetBullet3"))
        {
            defaultShoot = false;
            fireShoot = false;
            greenFireShoot = true;
        }
        else if (Input.GetButtonDown("SetBullet2"))
        {
            fireShoot = true;
            greenFireShoot = false;
            defaultShoot = false;
        }
        else if (Input.GetButtonDown("SetBullet1"))
        {
            defaultShoot = true;
            fireShoot = false;
            greenFireShoot = false;
        }
            if (Input.GetButtonDown("Bullet1") && Time.time > nextFire) {
            if (defaultShoot == true)
            {
                mana = mana + defaultShootMana;
                nextFire = Time.time + defaultFireRate;
                Shoot1();
                
            }
            else if (fireShoot == true && mana >= fireShootMana)
            {
                mana = mana - fireShootMana;
                nextFire = Time.time + fireRate;
                Shoot2();                
            }
            else if(greenFireShoot == true && mana >= greenFireShootMana)
            {
                mana = mana - greenFireShootMana;
                nextFire = Time.time + greenFireRate;
                Shoot3();                
            }
        }

    }
    void Shoot1()
    {
        Instantiate(DefaultBulletPrefab, Bullet.position, Bullet.rotation);
    }
    void Shoot2()
    {
        Instantiate(FireBulletPrefab, Bullet.position, Bullet.rotation);
    }
    void Shoot3()
    {
        Instantiate(FireGreenBulletPrefab, Bullet.position, Bullet.rotation);
    }
}