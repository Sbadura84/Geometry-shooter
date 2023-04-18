using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchWeapon : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D playerCollider)
    {
        if (playerCollider.tag == "Player") {
            playerCollider.GetComponent<PlayerControls>().takeDamage(1f);
        }
    }
}
