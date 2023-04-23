using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public string id;
    public int killCount;
    private bool stage1;

    void OnEnable()
    {
        stage1 = true;
        Debug.Log("SettingID");
        id = System.Guid.NewGuid().ToString();
        Debug.Log("ID of: " + id + "got set");
    }

    // Update is called once per frame
    void Update()
    {
        if (killCount > 5 && stage1 == true)
            Evolve();
    }

    void Evolve()
    {
        

            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);

    }

}
