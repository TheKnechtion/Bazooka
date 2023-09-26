using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool doesBounce = false;


    public ProjectileType projectileType;
    public ProjectilePath projectilePath;


    Vector2 collisionNormal;
    Vector2 direction2D;

    public PlayerInfo currentPlayerInfo;
    WeaponInfo weapon;


    Vector3 direction;

    int damage;
    float despawnTime;
    float magnitude;
    int numberOfBounces;



    private void Start()
    {
        weapon = currentPlayerInfo.currentWeapon;

        damage = weapon.damage;

        numberOfBounces = weapon.numberOfBounces;

        magnitude = weapon.projectileSpeed;

        direction = currentPlayerInfo.playerLookDirection.normalized;

        despawnTime = weapon.timeBeforeDespawn;

    }


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, despawnTime);
    }


    private void FixedUpdate()
    {
        gameObject.transform.Translate(direction * magnitude);
    }


    private void OnDestroy()
    {
        //deal splash damage in splash damage radius
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EntityInfo>().health -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BounceSurface" && numberOfBounces > 0)
        {
            collisionNormal = new Vector2(collision.contacts[0].normal.x, collision.contacts[0].normal.z).normalized;

            direction2D = (new Vector2(direction.x, direction.z));

            direction2D = (direction2D - 2 * (Vector2.Dot(direction2D, collisionNormal)) * collisionNormal);

            direction = new Vector3(direction2D.x, 0, direction2D.y);
            numberOfBounces--;
        }

        if (numberOfBounces <= 0) { Destroy(gameObject); }
  
    }

    
    private void Bounce()
    {

    }

    private void DealSplashDamage()
    {

    }

}
