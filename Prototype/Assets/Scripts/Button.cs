using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Button : MonoBehaviour, IDamagable
{
    List<EnemyInfo> enemyDatabase = new EnemyDatabase().enemyDatabase;
    EnemyInfo tempEnemyInfo = new EnemyInfo();

    public int health;

    float i = 0;

    List<string> unseenEnemies;
    private void Awake()
    {
        unseenEnemies = new List<string>();

        unseenEnemies.Add("knight");
        unseenEnemies.Add("dwarf");
        unseenEnemies.Add("mage");

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("GameManager").GetComponent<EnemySpawnManager>().SpawnEnemy(unseenEnemies[0], this.gameObject.transform.position + new Vector3(2-i,0,i));

        i++;

        unseenEnemies.Remove(unseenEnemies[0]);

        if (health <= 0) { GameObject.Destroy(this.gameObject); }
    }

    public void TakeDamage(int passedDamage)
    {
        health -= passedDamage;

        if(health <= 0) { GameObject.Destroy(this.gameObject); }
    }

}
