using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainScript : MonoBehaviour
{
    UIDocument mainUI;
    Label healthText;
    Label killCountText;
    PlayerControls statsSheet;
    TurretMenager killCounter;
    // Start is called before the first frame update
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        statsSheet = FindObjectOfType<PlayerControls>();
        killCounter = FindObjectOfType<TurretMenager>();
        healthText = root.Q<Label>("Health");
        killCountText = root.Q<Label>("KillCount");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = ("Health: " + statsSheet.currentHealth.ToString());
        killCountText.text = ("Enemies killed: " + killCounter.playerKillCount.ToString());
}
}
