using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    Rigidbody rb;
    PlayerController playerController;

    void Awake(){
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        Vector2 Movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * playerController.MoveSpeed;
        rb.velocity = Movement;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, Boundaries.LeftWall, Boundaries.RightWall),
            Mathf.Clamp(transform.position.y, Boundaries.BottomWall, Boundaries.TopWall)
            );
    }
}
