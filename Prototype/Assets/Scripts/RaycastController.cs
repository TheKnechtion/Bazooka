using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    //store the lineRenderer on the player
    [SerializeField] LineRenderer lineRenderer;

    //store the player game object
    [SerializeField] GameObject gameObject;

    //store the current player position
    Vector3 playerPosition;

    //variable that holds value for the x,y center of the screen in pixels
    Vector2 centerScreen;

    //variable that holds value of location of the mouse cursor
    Vector3 mousePos;

    //stores the player look direction
    Vector3 playerLookDirection;


    //store hit location of raycast
    RaycastHit raycast;
    Vector3 rayDirection;
    Vector3 reflectionRay;

    Vector2 raycastNormal2D;
    Vector2 direction2D;

    PlayerInfo currentPlayerInfo;

    public LayerMask ignoreProjectileLayerObjects;

    // Start is called before the first frame update
    void Start()
    {
        //get the position of the center of the screen
        centerScreen = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }



    // Update is called once per frame
    void Update()
    {
        currentPlayerInfo = PlayerInfo.instance;


        playerPosition = currentPlayerInfo.playerPosition;


        //set line renderer position to current player location
        lineRenderer.SetPosition(0, playerPosition);


        //sets the player look direction based on the player origin and the mouse cursor location
        playerLookDirection = currentPlayerInfo.playerLookDirection.normalized;

    }

    //Updates after update, used for physics related calculations and functions
    private void FixedUpdate()
    {
        
        
        if (Physics.Raycast(playerPosition, playerLookDirection, out raycast, Mathf.Infinity, ~ignoreProjectileLayerObjects))
        {
            raycastNormal2D = new Vector2(raycast.normal.x, raycast.normal.z).normalized;



            //set line renderer end to raycast hit point
            lineRenderer.SetPosition(1, raycast.point);

            direction2D = new Vector2(playerLookDirection.x, playerLookDirection.z);

            direction2D = direction2D - (2 * Vector2.Dot(direction2D, raycastNormal2D) * raycastNormal2D);

            reflectionRay = new Vector3(direction2D.x, 0, direction2D.y);
            


            lineRenderer.SetPosition(2, raycast.point+(reflectionRay*3));



        }
        else
        {
            //set line renderer end to normalized player look direction
            lineRenderer.SetPosition(1, playerLookDirection);
            lineRenderer.SetPosition(2, playerPosition);
        }

    }

}
