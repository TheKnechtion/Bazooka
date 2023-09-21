using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    WeaponInfo tempWeaponInfo = new WeaponInfo();
    List<WeaponInfo> weaponDatabase = new List<WeaponInfo>();

    //store hit location of raycast
    RaycastHit raycast;
    Vector3 rayDirection;
    Vector3 reflectionRay;

    Object projectilePrefab;

    Object cloneCheck;
    //Utility for finding appropriate weapon data based on passed in string
    public WeaponInfo MakeWeapon(string weaponName)
    {
        weaponDatabase = new WeaponDatabase().Weapon_Database;
        
        tempWeaponInfo = weaponDatabase.First(weapon => weapon.weaponName.Equals(weaponName));
        
        weaponDatabase.Clear();

        return tempWeaponInfo;
    }


    public void Shoot(WeaponInfo weapon)
    {
        projectilePrefab = Resources.Load(weapon.projectileType.ToString());

        /*
        if (cloneCheck != null)
        {
            return;
        }
        */

        cloneCheck = Instantiate(projectilePrefab, PlayerInfo.instance.playerPosition, new Quaternion(0, 0, 0, 0));
    }


}




