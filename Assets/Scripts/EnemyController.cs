using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Enemy enemyScript;
    private Vector2 targetDirection;
    private Transform player;

    private Vector2 DirectionToPlayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyScript = GetComponent<Enemy>();
        player=FindObjectOfType<PlayerControls>().transform;
        
    }

    private void Update()
    {
        speed = enemyScript.enemySpeed;
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer=enemyToPlayerVector.normalized;
    }
    private void FixedUpdate()
    {
        UpdateTarget();
        RotateTowards();
        SetVelocity();
    }

    private void UpdateTarget()
    {
        targetDirection = DirectionToPlayer;
    }

    private void RotateTowards()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        rb.velocity = transform.up * speed;
    }
}
