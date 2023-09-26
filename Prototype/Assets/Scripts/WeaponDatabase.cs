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
        testWeapon.numberOfBounces = 1;
        testWeapon.currentAmmo = 12;
        testWeapon.maxAmmo = 12;

        testWeapon.projectileSpeed = 0.4f;
        testWeapon.radiusOfProjectile = 1.0f;
        testWeapon.splashDamageRadius = 1.0f;
        testWeapon.timeBetweenProjectileFire = 0.3f;
        testWeapon.timeBeforeDespawn = 5.0f;
        testWeapon.homingStrength = 0.0f;

        Weapon_Database.Add(testWeapon);




        WeaponInfo testWeapon2 = new WeaponInfo();
        testWeapon2.weaponName = "Test_Weapon2";
        testWeapon2.projectileType = ProjectileType.Gun;
        testWeapon2.projectilePath = ProjectilePath.Straight;

        testWeapon2.doesSplashDamageOnDespawn = true;
        testWeapon2.doesBounce = true;
        testWeapon2.isHoming = false;

        testWeapon2.damage = 50;
        testWeapon2.splashDamage = 50;
        testWeapon2.maxProjectilesOnScreen = 3;
        testWeapon2.numberOfProjectilesPerShot = 50;
        testWeapon2.numberOfBounces = 67;
        testWeapon2.currentAmmo = 12;
        testWeapon2.maxAmmo = 12;

        testWeapon2.projectileSpeed = 0.8f;
        testWeapon2.radiusOfProjectile = 1.0f;
        testWeapon2.splashDamageRadius = 1.0f;
        testWeapon2.timeBetweenProjectileFire = 0.8f;
        testWeapon2.timeBeforeDespawn = 10.0f;
        testWeapon2.homingStrength = 0.0f;

        Weapon_Database.Add(testWeapon2);


    }


    public List<WeaponInfo> Weapon_Database { get; set; }





}
