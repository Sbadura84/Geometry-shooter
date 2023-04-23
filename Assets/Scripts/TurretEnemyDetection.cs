using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    [SerializeField] private Collider2D detectionCollider;
    public Transform detectedEnemy = null;
    private bool enemyDetection;

    private void Start()
    {
        detectionCollider=GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(detectedEnemy == null)
        {
            enemyDetection = true;
        }
        else
            FollowTarget();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy"&& enemyDetection == true)
        {
            detectedEnemy = collision.transform;
            enemyDetection=false;
        }
    }


    private void FollowTarget()
    {
        Vector3 targ = detectedEnemy.transform.position;
        if (Vector2.Distance(targ, transform.position) >= 5f)
        {
            detectedEnemy = null;
            return;
        }
        
        targ.x = targ.x - transform.position.x;
        targ.y = targ.y - transform.position.y;
        
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
