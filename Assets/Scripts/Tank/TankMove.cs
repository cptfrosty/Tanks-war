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
        Rotation();
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
        if (movement.x > 0) transform.rotation = Quaternion.Euler(0, 0,-90);
        if (movement.x < 0) transform.rotation = Quaternion.Euler(0, 0, 90);
        if (movement.y > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (movement.y < 0) transform.rotation = Quaternion.Euler(0, 0, 180);
    }
}
