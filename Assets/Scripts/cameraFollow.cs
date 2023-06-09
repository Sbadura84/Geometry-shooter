using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float zoom = 5f;
    [SerializeField] Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y > 0 && zoom <10) { zoom = zoom + 1; }
        if (Input.mouseScrollDelta.y < 0 && zoom >5) { zoom = zoom - 1; }
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        mainCamera.orthographicSize = zoom;
    }
}
