using System.Collections;
using System.Collections.Generic;

public class WeaponDatabase
{

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

        testWeapon.damage = 2;
        testWeapon.splashDamage = 1;
        testWeapon.maxProjectilesOnScreen = 3;
        testWeapon.numberOfProjectilesPerShot = 1;
        testWeapon.numberOfBounces = 1;
        testWeapon.currentAmmo = 12;
        testWeapon.maxAmmo = 12;
        
        testWeapon.projectileSpeed = 0.8f;
        testWeapon.radiusOfProjectile = 1.0f;
        testWeapon.splashDamageRadius = 1.0f;
        testWeapon.timeBetweenProjectileFire = 1.0f;
        testWeapon.timeBeforeDespawn = 5.0f;
        testWeapon.homingStrength = 0.0f;

        Weapon_Database.Add(testWeapon);
    }


    public List<WeaponInfo> Weapon_Database { get; set; }





}
