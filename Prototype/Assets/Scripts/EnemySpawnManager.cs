using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    EnemyDatabase enemyDatabase = new EnemyDatabase();


    public void SpawnEnemy(string name, Vector3 position)
    {
        GameObject tempGameObject = new GameObject();

        tempGameObject = LoadResource(name);

        Instantiate(tempGameObject, position, new Quaternion(0,0,0,0));        
    }

    public GameObject LoadResource(string name)
    {
        return Resources.Load(name) as GameObject;
    }




    public void SpawnEnemies()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
