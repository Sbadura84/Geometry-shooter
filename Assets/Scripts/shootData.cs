using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootData : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float bulletDamage;
    private float bulletLifeTime =3f;
    [SerializeField] public string shooterId;
    // [SerializeField] public string ownerID;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(speed + "= speed before adding force");
        rb.velocity = transform.up * speed;
        Debug.Log(speed + "= speed after adding force");
        bulletLifeTime += Time.time;
    }
    private void Update()
    {
        if(bulletLifeTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Enemy")
        {
            //Debug.Log(collision.tag);
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) {
                Debug.Log("Found enemy: "+enemy.name);
                int bulletScore = enemy.TakeDamage(bulletDamage);
                if (bulletScore > 0)
                {
                    KillCountAdd();
                }
                Destroy(gameObject);
            }
            
        }
    }

    private void KillCountAdd()
    {
        Debug.Log("Sending killer ID =" + shooterId + " to TurretMenager");
        FindObjectOfType<TurretMenager>().RecieveKillData(shooterId);
    }
    public void SetSpeed(int newSpeed)
    {
        speed =newSpeed ;
    }
}
