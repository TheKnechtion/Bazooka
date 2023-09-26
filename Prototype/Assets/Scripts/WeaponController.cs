using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController:MonoBehaviour
{
    WeaponInfo tempWeaponInfo = new WeaponInfo();
    List<WeaponInfo> weaponDatabase = new List<WeaponInfo>();



    Vector3 position;

    Object projectilePrefab;

    GameObject currentEntity;

    WeaponInfo weapon;


    private void Awake()
    {
        weaponDatabase = new WeaponDatabase().Weapon_Database;
    }



    //Utility for finding appropriate weapon data based on passed in string
    public WeaponInfo MakeWeapon(string weaponName)
    {
        weaponDatabase = new WeaponDatabase().Weapon_Database;

        tempWeaponInfo = weaponDatabase.First(weapon => weapon.weaponName.Equals(weaponName));

        weaponDatabase.Clear();

        return tempWeaponInfo;
    }


    public void Shoot(PlayerInfo currentPlayerInfo)
    {
        weapon = currentPlayerInfo.currentWeapon;

        position = currentPlayerInfo.playerPosition;

        projectilePrefab = Resources.Load(weapon.projectileType.ToString());

        currentEntity = Instantiate(projectilePrefab as GameObject, position, new Quaternion(0, 0, 0, 0));

        currentEntity.GetComponent<Projectile>().currentPlayerInfo = currentPlayerInfo;


    }


    public void Shoot(EnemyInfo currentEnemyInfo)
    {

    }


}




