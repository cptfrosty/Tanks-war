using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Vector2 movement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputKeyboard();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputKeyboard()
    {
        Vector2 direction = movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(movement.x) == 1 && Mathf.Abs(movement.y) == 1)
            movement = direction;
    }

    void Move()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    void Rotation()
    {
        //transform.rotation = new Quaternion()
    }
}
