using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public static Action OnShouldUpdateScoreEvent;
    // This is used to not keep updating the score before the projectile is destroyed
    public bool HasScoreBeenAdded = false;

    private Rigidbody2D rb;
    public float MoveSpeed = 3.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Move();
    }

    private void Update()
    {
        if (!HasScoreBeenAdded)
        {
            UpdateScore();
        }
    }

    private void Move()
    {
        rb.linearVelocityX = MoveSpeed;
    }

    private void UpdateScore()
    {
        if (transform.position.x > 1)
        {
            HasScoreBeenAdded = true;
            OnShouldUpdateScoreEvent();
        }
    }
}                 
