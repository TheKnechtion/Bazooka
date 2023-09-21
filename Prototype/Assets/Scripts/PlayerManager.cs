using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    PlayerController _playerController;

    WeaponController weaponController = new WeaponController();



    //store the current player position
    Vector3 playerPosition;

    //variable that holds value for the x,y center of the screen in pixels
    Vector2 centerScreen;

    //variable that holds value of location of the mouse cursor
    Vector3 mousePos;

    //stores the player look direction
    Vector3 playerLookDirection;




    float timeBetweenShots = 0.0f;

    WeaponInfo tempWeaponInfo = new WeaponInfo();

    private void Start()
    {
        //get the position of the center of the screen
        centerScreen = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

    }

    private void Update()
    {
        playerPosition = gameObject.transform.position;
        
        
        //current x,y vector of how far away the cursor is from the bottom left of the screen
        mousePos = Input.mousePosition;


        //translate the mouse coordinates to be based around the center of the screen
        mousePos.x -= centerScreen.x;
        mousePos.y -= centerScreen.y;

        //sets the player look direction based on the player origin and the mouse cursor location
        playerLookDirection = new Vector3(playerPosition.x + mousePos.x, playerPosition.y, playerPosition.z + mousePos.y);



        if (_playerController.PlayerActions.Shoot.IsPressed() && timeBetweenShots <= 0.0f)
        {
            timeBetweenShots = tempWeaponInfo.timeBetweenProjectileFire;

            tempWeaponInfo = PlayerInfo.instance.currentWeapon;

            weaponController.Shoot(tempWeaponInfo);
        }

        timeBetweenShots = (timeBetweenShots > 0) ? timeBetweenShots-=Time.deltaTime:0;
    }



    private void Awake()
    {
        _playerController = new PlayerController();

    }


    private void OnEnable()
    {
        //begins player movement functions
        _playerController.PlayerActions.Enable();
    }


    private void OnDisable()
    {
        //ends player movement functions
        _playerController.PlayerActions.Disable();
    }

}
