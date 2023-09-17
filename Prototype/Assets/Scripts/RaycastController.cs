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

    // Start is called before the first frame update
    void Start()
    {
        //get the position of the center of the screen
        centerScreen = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }



    // Update is called once per frame
    void Update()
    {
        //current x,y vector of how far away the cursor is from the bottom left of the screen
        mousePos = Input.mousePosition;


        //translate the mouse coordinates to be based around the center of the screen
        mousePos.x -= centerScreen.x;
        mousePos.y -= centerScreen.y;


        //set line renderer position to current player location
        lineRenderer.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));


        //sets the player look direction based on the player origin and the mouse cursor location
        playerLookDirection = new Vector3(gameObject.transform.position.x + mousePos.x, gameObject.transform.position.y, gameObject.transform.position.z + mousePos.y);



    }

    //Updates after update, used for physics related calculations and functions
    private void FixedUpdate()
    {
        rayDirection = playerLookDirection - gameObject.transform.position;
        if (Physics.Raycast(gameObject.transform.position, rayDirection.normalized, out raycast, Mathf.Infinity))
        {
            Debug.Log(raycast.point);

            //set line renderer end to raycast hit point
            lineRenderer.SetPosition(1, raycast.point);

            reflectionRay = rayDirection.normalized - 2 * Vector3.Dot(rayDirection.normalized, raycast.normal) * raycast.normal;
            lineRenderer.SetPosition(2, raycast.point+reflectionRay);
        }
        else
        {
            //set line renderer end to normalized player look direction
            lineRenderer.SetPosition(1, playerLookDirection);
        }

    }

}
