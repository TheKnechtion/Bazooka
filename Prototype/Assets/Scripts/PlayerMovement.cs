using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    PlayerController _playerController;
    public float speed = 0.1f;

    private void Awake()
    {
        _playerController = new PlayerController();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = _playerController.PlayerMovement.Movement.ReadValue<Vector2>();
        //Debug.Log(moveInput);
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * speed);
    }


    private void OnEnable()
    {
        _playerController.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        _playerController.PlayerMovement.Disable();
    }

}
