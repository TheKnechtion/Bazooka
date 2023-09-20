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

    //Utility for finding appropriate weapon data based on passed in string
    public WeaponInfo MakeWeapon(string weaponName)
    {
        weaponDatabase = new WeaponDatabase().Weapon_Database;
        
        tempWeaponInfo = weaponDatabase.First(weapon => weapon.weaponName.Equals(weaponName));
        
        weaponDatabase.Clear();

        return tempWeaponInfo;
    }


    public void Shoot(WeaponInfo weapon, Vector3 currentPosition, Vector3 lookDirection)
    {
        projectilePrefab = Instantiate(Resources.Load(weapon.projectileType.ToString()), currentPosition, new Quaternion(0,0,0,0));
        
        
        /*
        //this is the direction of the ray that's sent out when the player clicks the mouse
        rayDirection = lookDirection - currentPosition;
        if (Physics.Raycast(gameObject.transform.position, rayDirection.normalized, out raycast, Mathf.Infinity))
        {


            //set line renderer end to raycast hit point
            lineRenderer.SetPosition(1, raycast.point);

            reflectionRay = rayDirection.normalized - 2 * Vector3.Dot(rayDirection.normalized, raycast.normal) * raycast.normal;



            lineRenderer.SetPosition(2, raycast.point + (reflectionRay * 3));


            //Physics.Raycast(raycast.point, )


        }
        else
        {
            //set line renderer end to normalized player look direction
            lineRenderer.SetPosition(1, playerLookDirection);
            lineRenderer.SetPosition(2, playerPosition);
        }
        */

    }


    //Instantiate();

    //instantiate bullet prefab

    //destroy the instanitated bullet after the time has expired

}




