using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;
    private void Awake() {
        instance = this;
    }
    public DamageNumber numberToSpawn;
    public Transform numberCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);
        DamageNumber newDamage = Instantiate(numberToSpawn, location, quaternion.identity, numberCanvas);
        newDamage.SetUp(rounded);
        newDamage.gameObject.SetActive(true);
    }
}
