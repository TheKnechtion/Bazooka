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

    float splashRadius;
    int splashDamage;

    CapsuleCollider caster;
    SphereCollider thisProjectileCollider;

    private void Start()
    {
        //caster = GetComponent<CapsuleCollider>();
        //thisProjectileCollider = GetComponent<SphereCollider>();
        //Physics.IgnoreCollision(thisProjectileCollider, caster);

        splashDamage = 1;
        splashRadius = 1;

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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EntityInfo>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BounceSurface" && numberOfBounces > 0)
        {
            collisionNormal = new Vector2(collision.contacts[0].normal.x, collision.contacts[0].normal.z).normalized;

            direction2D = (new Vector2(direction.x, direction.z));

            direction2D = (direction2D - 2 * (Vector2.Dot(direction2D, collisionNormal)) * collisionNormal);

            direction = new Vector3(direction2D.x, 0, direction2D.y);
            numberOfBounces--;

            if (numberOfBounces <= 0)
            {
                //If the bullet hits a wall and can't bounce anymore, then we want to do splash damage;

                //IF the splash radius is > 0 then this method will damage, 
                //else nothing will get hit from the 0 radius
                DealSplashDamage();
            }
        }

        if (numberOfBounces <= 0) { Destroy(gameObject); }
  
    }

    
    private void Bounce()
    {

    }

    private void DealSplashDamage()
    {
       
        var collidersHit = Physics.OverlapSphere(gameObject.transform.position, splashRadius);
        for (int i = 0; i < collidersHit.Length; i++)
        {
            collidersHit[i].gameObject.TryGetComponent<EntityInfo>(out EntityInfo en);
            if (en != null)
            {
                Debug.Log("SPLASH DMG");
                //We deal splash damage if what we hit is not null
                en.TakeDamage(splashDamage);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        //Draws splash damage radius
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, splashRadius);
    }

}
