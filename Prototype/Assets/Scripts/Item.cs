using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    string itemTag;
    WeaponInfo tempWeaponInfo;

    private void OnTriggerEnter(Collider other)
    {
        itemTag = gameObject.tag;

        if (other.gameObject.tag == "Player")
        {
            WeaponController tempWeaponController = new WeaponController();

            tempWeaponInfo = tempWeaponController.MakeWeapon(gameObject.name);

            //on collision, add the weapon to the player's owned weapons
            other.gameObject.GetComponent<PlayerInfo>().ownedWeapons.Add(tempWeaponInfo);

            Destroy(gameObject);
        }
    }


}
