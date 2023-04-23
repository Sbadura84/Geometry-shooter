using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class DebugSpawnOnClick : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] List<Enemy> enemies  = new List<Enemy>();
    [SerializeField] bool spawnCircular = false;
    [SerializeField] GameObject player;

    [SerializeField]  private float spawnInterval;
    private float spawnTimer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 spawnPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;
            Instantiate(enemies[0], spawnPosition, transform.rotation);
        }
        if (spawnCircular == true && spawnTimer < Time.time)
            SpawnCircular();
    }
    private void SpawnCircular() {
        //poprawic spawnuje tylko prawy gorny
        Vector2 pointOnCircle = Random.insideUnitCircle.normalized * 10;
        Vector3 spawnPosition = player.transform.position + new Vector3(pointOnCircle.x,pointOnCircle.y,0);

        //Vector3 spawnPosition = player.transform.position +Vector3.one*5;
        Instantiate(enemies[0], spawnPosition, transform.rotation);
        spawnTimer = Time.time + spawnInterval;
    }
}
