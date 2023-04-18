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
        if (spawnCircular == true)
            SpawnCircular();
    }
    private void SpawnCircular() {
        //poprawic spawnuje tylko prawy gorny
        Vector3 spawnPosition = player.transform.position * 3 + Vector3.one*Random.Range(1, 6);
        Instantiate(enemies[0], spawnPosition, transform.rotation);
    }
}
