using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] string newName;
    private float randSize;
    [SerializeField] private int maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        randSize = RandomGaussian(0.5f, 1.5f);
        Debug.Log(randSize);
        transform.name = newName + ";" + randSize;
        currentHealth = maxHealth * randSize; 
        transform.localScale = Vector3.one*randSize;
        enemySpeed = enemySpeed * randSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static float RandomGaussian(float minValue, float maxValue)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}
