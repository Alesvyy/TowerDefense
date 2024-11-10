using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform tarjet;
    private int pathIndex = 0;

    private void Start()
    {
        tarjet = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(tarjet.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                return;
              } else {
                        tarjet = LevelManager.main.path[pathIndex];
                }
            }

        }

    private void FixedUpdate()
    {
        Vector2 direction = (tarjet.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

}
