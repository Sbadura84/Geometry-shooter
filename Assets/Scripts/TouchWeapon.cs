using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchWeapon : MonoBehaviour
{
    [SerializeField] private float attackCoolDown =3f;
    [SerializeField] private float attackTime;
    [SerializeField] private Collider2D circleCollider;

    private void Update()
    {
       if( attackTime < Time.time)
            circleCollider.enabled = enabled;
    }
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        Debug.Log(playerCollider.name);
        if (playerCollider.tag == "Player") {
            playerCollider.GetComponent<PlayerControls>().takeDamage(1f);
            attackTime = Time.time + attackCoolDown;
            circleCollider.enabled = false;
        }
    }
}
