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
    [SerializeField] private float speed =1f;
    [SerializeField] GameObject rotationPoint;
    [SerializeField] private float invurability = 0.15f;
    [SerializeField] private float invurabilityFrame;
    [SerializeField] private float currentHealt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealt= 10;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))*movementSpeed);

        //transform.LookAt(cam.ScreenToWorldPoint(Input.mousePosition));
        rotateTowards();
    }


    void rotateTowards()
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
            currentHealt = currentHealt - damageAmount;
            invurabilityFrame = Time.time + invurability;
        }
        if(currentHealt < 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
