using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileController : MonoBehaviour
{
    
    private Rigidbody2D rb;

    public static Action OnShouldUpdateScoreEvent;
    public static Action OnShouldUpdateHighScoreEvent;
    public bool HasScoreBeenAdded = false;  // This is used to not keep updating the score before the projectile is destroyed
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnShouldUpdateHighScoreEvent();
    }
}                 
