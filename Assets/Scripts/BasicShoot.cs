using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    private float shootTime;
    [SerializeField] private float shootCd;
    private bool ownedByPlayer;
    public TurretEnemyDetection detecionScript;
    [SerializeField]
    public string ownerID;
    private GameObject projectile;
    public int killCount;

    // Start is called before the first frame update
    void Start()
    {
       
        if (transform.parent.tag == "Player")
        {
            ownedByPlayer = true;
            ownerID = transform.parent.parent.GetComponent<PlayerControls>().playerID;
        }
        else
        {
            ownedByPlayer=false;
            detecionScript = transform.parent.parent.GetComponent<TurretEnemyDetection>();
            ownerID = transform.parent.parent.GetComponent<TurretData>().id;
            string ownerName = transform.parent.parent.name;
            
            Debug.Log("Got owner ID which is: " +  ownerID + " name: " + ownerName);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ownerID == null)
        {
            ownerID = transform.parent.parent.GetComponent<TurretData>().id;
        }
        if (ownedByPlayer == true)
        {
            if (Input.GetButton("Fire1") && shootTime < Time.time)
            {
                Shoot();
            }
        }
        else
        {
            if (shootTime < Time.time && detecionScript.detectedEnemy != null)
            {
                Debug.Log(detecionScript.detectedEnemy.name);
                Shoot();
            }
        }
        
    }

    void Shoot()
    {
        projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        //projectile.transform.parent = transform;
        projectile.GetComponent<shootData>().shooterId = ownerID;
        //projectile.GetComponent<shootData>().SetSpeed(50);
        shootTime = Time.time+ shootCd;
    }
}
