using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IDamagable
{
    public string enemyName { get; set; }

    public int HP { get; set; }

    public int MP { get; set; }

    public int AP { get; set; }
    
    public int DEF { get; set; }

    int health = 2;

    //track the current player position
    Vector3 playerPosition;

    //track the current enemy position
    Vector3 enemyPosition;


    Vector3 enemyLookDirection;

    //the current weapon the enemy has
    WeaponInfo currentEnemyWeapon;


    //controls enemy's weapon
    WeaponController weaponController = new WeaponController();


    //Used by the enemy to track how far the player is
    float enemyPlayerTracker;


    float timeBetweenShots;

    //Used to determine how far the player has to be for the enemy to stop attacking
    float enemyAttackRange_BecomeAggro = 5.0f;

    bool isAggrod = false;


    //Used to determine how far the player has to be for the enemy to start attacking
    float enemyAttackRange_ExitAggro = 10.0f;


    Object projectilePrefab;
    GameObject currentEntity;

    Material projectileMaterial;


    private void Start()
    {

        currentEnemyWeapon = weaponController.MakeWeapon("Test_Weapon");



        //create the red projectile material used by the enemy projectiles
        projectileMaterial = Resources.Load("Red") as Material;

    }

    private void Update()
    {
        enemyPosition = this.transform.position;

        playerPosition = PlayerInfo.instance.playerPosition;


        enemyPlayerTracker = Vector3.Distance(playerPosition, enemyPosition);

        enemyLookDirection = (playerPosition - enemyPosition).normalized;

        if (enemyPlayerTracker < enemyAttackRange_BecomeAggro) { isAggrod = true; }

        if (enemyPlayerTracker > enemyAttackRange_ExitAggro) { isAggrod = false; }

        if (isAggrod) { HandleShooting(); }

        //tracks time between shots, stopping at 0.
        timeBetweenShots = (timeBetweenShots > 0) ? timeBetweenShots -= Time.deltaTime : 0;



        if (health <= 0) { Destroy(gameObject); }
    }


    private void HandleShooting()
    {

        if (timeBetweenShots <= 0.0f)
        {
            timeBetweenShots = currentEnemyWeapon.timeBetweenProjectileFire;

            Shoot();
        }
    }


    void Shoot()
    {

        projectilePrefab = Resources.Load(currentEnemyWeapon.projectileType.ToString());

        currentEntity = Instantiate(projectilePrefab as GameObject, enemyPosition, new Quaternion(0, 0, 0, 0));

        currentEntity.GetComponent<Projectile>().currentWeaponInfo = currentEnemyWeapon;
        currentEntity.GetComponent<Projectile>().direction = enemyLookDirection;
        currentEntity.GetComponent<Renderer>().material = projectileMaterial;
    }


    public void TakeDamage(int passedDamage)
    {
        health -= passedDamage;
    }


    private void OnDestroy()
    {
        FindGameObjectInScene("GameManager").GetComponent<GameManager>().UpdateRoomDatabase();
    }


    GameObject FindGameObjectInScene(string gameObjectName)
    {
        return GameObject.Find(gameObjectName);
    }


    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
