using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController thePlayer;

    public float speed = 12f;
    public float gravity = -9.61f;
    public float jumpHeight = 3f;

    private Vector3 move;
    private Camera _camera;

    private void OnEnable()
    {
        _camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float oldY = move.y;

        Vector3 direction = new Vector3(x, 0, y);

        move = _camera.transform.TransformDirection(direction);
        move *= speed;
        move.y = oldY;

        if (Input.GetButtonDown("Jump") && thePlayer.isGrounded)
        {
            move.y = jumpHeight;
        }

        if (!thePlayer.isGrounded)
        {
            move.y += gravity * Time.deltaTime;
        }

        thePlayer.Move(move * Time.deltaTime);
    }
}
