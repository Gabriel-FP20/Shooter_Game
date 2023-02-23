using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D ship;
    public Rigidbody2D life;
    public Rigidbody2D player;
    public float moveSpeed = 2.5f;
    Vector2 moveDirection;
    Vector2 mousePosition;

    public bool death;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        
        moveDirection = new Vector2(moveX,moveY).normalized;
        if(death)
        {
            mousePosition = new Vector3(0f,0f,0f);
        }
        else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }

    private void FixedUpdate()
    {
        life.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        ship.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        player.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - ship.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg + 90f;
        ship.rotation = aimAngle;
    }

    public void Stop()
    {
        moveSpeed = 0f;
    }

    public void Movement()
    {
        moveSpeed = 2.5f;
    }

    public void Death()
    {
        death = true;
    }
}
