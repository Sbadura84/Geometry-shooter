using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretMenager : MonoBehaviour
{
    [SerializeField] public Dictionary<string, TurretData> turretMenagement = new Dictionary<string, TurretData>();
    // Start is called before the first frame update
    [SerializeField] public int playerKillCount;
    void Start()
    {
        GameObject[] tempTurrets = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject tempTurret in tempTurrets)
        {
            if (tempTurret.GetComponent<TurretData>() != null)
                turretMenagement.Add(tempTurret.GetComponent<TurretData>().id, tempTurret.GetComponent<TurretData>());
        }
    }

    // Update is called once per frame
    public void RecieveKillData(string killerID)
    {
        Debug.Log("Recieved kill info from: " + killerID);
        playerKillCount++;
        TurretData killerObject;
        if (turretMenagement.TryGetValue(killerID, out killerObject))
        {
            Debug.Log("Found killer in dictionary: " + killerObject.name);
            killerObject.killCount++;

        }
    }
}
