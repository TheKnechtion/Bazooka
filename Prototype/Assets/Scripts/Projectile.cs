using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool doesBounce = false;
    public int numberOfBounces = 0;

    public float speed = 1.0f;
    public float despawnTime = 5.0f;

    public int damage = 1;

    public ProjectileType projectileType;
    public ProjectilePath projectilePath;

    Vector3 direction;


    float magnitude;

    Vector2 collisionNormal;
    Vector2 direction2D;

    PlayerInfo currentPlayerInfo = new PlayerInfo();
    WeaponInfo currentWeaponInfo = new WeaponInfo();

    private void Awake()
    {
        currentPlayerInfo = PlayerInfo.instance;
        direction = currentPlayerInfo.playerLookDirection.normalized;
        currentWeaponInfo = currentPlayerInfo.currentWeapon;
        damage = currentWeaponInfo.damage;
        numberOfBounces = currentWeaponInfo.numberOfBounces;
        magnitude = currentWeaponInfo.projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, currentPlayerInfo.currentWeapon.timeBeforeDespawn);
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
        if (collision.gameObject.tag == "BounceSurface" && numberOfBounces != 0)
        {
            collisionNormal = new Vector2(collision.contacts[0].normal.x, collision.contacts[0].normal.z);

            direction2D = new Vector2(direction.x, direction.z);

            direction2D = (direction2D.normalized - 2 * (Vector2.Dot(direction2D.normalized, collisionNormal)) * collisionNormal).normalized;

            direction = new Vector3(direction2D.x, 0, direction2D.y);
            numberOfBounces--;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EntityInfo>().health -= damage;
            Destroy(gameObject);
        }
    }

    
    private void Bounce()
    {

    }

    private void DealSplashDamage()
    {

    }

}
