using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo:MonoBehaviour
{

    public int currentHP;
    public int maximumHP;

    public int shield;


    public float dashCooldown = 3.0f;
    public float movementSpeed = 0.1f;

    //player's currently equipped weapon
    public WeaponInfo currentWeapon;

    public List<WeaponInfo> ownedWeapons = new List<WeaponInfo>();

    private void Start()
    {
        currentHP = maximumHP;
    }




}
