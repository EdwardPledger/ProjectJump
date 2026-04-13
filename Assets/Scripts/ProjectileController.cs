using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float MoveSpeed = 3.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Move();
    }

    private void Update()
    {
        
    }

    private void Move()
    {
        rb.linearVelocityX = MoveSpeed;
    }
}
