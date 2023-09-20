using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EntityInfo : MonoBehaviour
{
    public string Name { get; set; }

    public int health = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (health == 0) { Destroy(gameObject); }
    }

    //public int CurrentHP { get; set; }

    //public int MaxHP { get; set; }

    //public int CurrentEXP { get; set; }

    //List<WeaponInfo> OwnedWeapons { get; set; }


}
