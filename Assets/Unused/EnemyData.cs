using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public new string name;
    public float baseHealth;
    public float baseSpeed;
    public GameObject baseWeapon;
    public Sprite sprite;

}
