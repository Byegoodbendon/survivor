using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance;
    public GameObject exp;
    private void Awake() 
    {
        instance = this;   
    }
    public int currentExperience;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getExp(int amountToGet)
    {
        currentExperience += amountToGet;

    }
    public void SpawnExp(Vector3 position, int expToGive)
    {
       for(int i = 0; i < expToGive ; i++)
       {
        Instantiate(exp, position, quaternion.identity);
       }
        
    }
}
