using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] GameObject attackPoint;
    [SerializeField] private float invurability = 0.15f;
    [SerializeField] private float invurabilityFrame;
    [SerializeField] public float currentHealth;
    [SerializeField] private float maxHealth = 10f;
    public string playerID;

    // Start is called before the first frame update
    void Start()
    {
        playerID = gameObject.name;
        currentHealth= maxHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))*movementSpeed);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed);
        //transform.LookAt(cam.ScreenToWorldPoint(Input.mousePosition));
        RotateTowards();
    }


    void RotateTowards()
    {
        Vector3 targ = cam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("Target= " + targ);
        targ.z = 0f;
        targ.x = targ.x - transform.position.x;
        targ.y = targ.y - transform.position.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        //Debug.Log("angle " + angle + "targY=" + targ.y + " targX=" + targ.x + "targY/X=" + (targ.y/targ.x));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    public void takeDamage(float damageAmount)
    {
        if (Time.time > invurabilityFrame)
        {
            currentHealth = currentHealth - damageAmount;
            invurabilityFrame = Time.time + invurability;
        }
        if(currentHealth < 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
