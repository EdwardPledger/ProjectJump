using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    private List<GameObject> projectiles = new List<GameObject>();
    private float projectileSpeed = 3.7f;
    private float maxProjectileSpeed = 8.5f;
    private float respawnTimer = 8f;
    private float minRespawnTimer = 4.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }

    // Update is called once per frame
    void Update()
    {
        CheckToDestroyProjectile();
    }

    private IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            SetSpeedAndRespawnTimer();

            var projectileGameObject = Instantiate(projectile, new Vector3(-14f, -2.5f, 0f), Quaternion.identity);
            projectileGameObject.GetComponent<ProjectileController>().MoveSpeed = projectileSpeed;
            projectiles.Add(projectileGameObject);

            yield return new WaitForSeconds(respawnTimer);
        }
    }

    private void CheckToDestroyProjectile()
    {
        GameObject projectileToDestroy = null;

        foreach (var projectile in projectiles)
        {
            if (projectile.transform.position.x > 13)
            {
                projectileToDestroy = projectile;
            }
        }

        if (projectileToDestroy != null)
        {
            projectiles.Remove(projectileToDestroy);
            Destroy(projectileToDestroy);
        }
    }

    private void SetSpeedAndRespawnTimer()
    {
        if (projectileSpeed <= maxProjectileSpeed)
        {
            projectileSpeed += .17f;
        }
        
        if (respawnTimer >= minRespawnTimer)
        {
            respawnTimer -= .14f;
        }
    }
}
