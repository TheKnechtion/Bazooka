using System.Collections;
using System.Collections.Generic;

public class WeaponDatabase
{

    //implement singleton functionality in the weapon database
    /*
    static WeaponDatabase _instance;
    public static WeaponDatabase instance
    {
        get
        {
            return _instance;
        }
    }
    */
    public WeaponDatabase()
    {
        Weapon_Database = new List<WeaponInfo>();

        WeaponInfo testWeapon = new WeaponInfo();
        testWeapon.weaponName = "Test_Weapon";
        testWeapon.projectileType = ProjectileType.Gun;
        testWeapon.projectilePath = ProjectilePath.Straight;

        testWeapon.doesSplashDamageOnDespawn = true;
        testWeapon.doesBounce = true;
        testWeapon.isHoming = false;

        testWeapon.damage = 1;
        testWeapon.splashDamage = 1;
        testWeapon.maxProjectilesOnScreen = 3;
        testWeapon.numberOfProjectilesPerShot = 3;
        testWeapon.numberOfBounces = 50;
        testWeapon.currentAmmo = 12;
        testWeapon.maxAmmo = 12;
        
        testWeapon.projectileSpeed = 2.3f;
        testWeapon.radiusOfProjectile = 1.0f;
        testWeapon.splashDamageRadius = 1.0f;
        testWeapon.timeBetweenProjectileFire = 0.3f;
        testWeapon.timeBeforeDespawn = 15.0f;
        testWeapon.homingStrength = 0.0f;

        Weapon_Database.Add(testWeapon);
    }


    public List<WeaponInfo> Weapon_Database { get; set; }





}
