using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBuilding : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] List<GameObject> turrets = new List <GameObject>();
    [SerializeField] Tilemap tilemap;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Vector2 worldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(turrets[0], worldPosition, transform.rotation);
        }
    }
}
