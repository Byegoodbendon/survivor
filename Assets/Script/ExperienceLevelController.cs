using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance;
    public GameObject exp;
    public List<int> expLevels;
    public int currentLevel = 1;
    public int levelCount = 100;
    private void Awake() 
    {
        instance = this;   
    }
    public int currentExperience;
    void Start()
    {
       while(expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.1f));
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getExp(int amountToGet)
    {
        currentExperience += amountToGet;
        if(currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }
        UiController.instance.UpdateExperience(currentExperience,expLevels[currentLevel],currentLevel);

    }
    public void SpawnExp(Vector3 position, int expToGive)
    {
       for(int i = 0; i < expToGive ; i++)
       {
        Instantiate(exp, position, quaternion.identity);
       }
        
    }
    void LevelUp()
    {
        
        currentExperience -= expLevels[currentLevel]; 
        currentLevel += 1;
        if(currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }
        //PlayerController.instance.activeWeapon.LevelUp();
        UiController.instance.levelUpPanel.SetActive(true);
        Time.timeScale = 0f;
        UiController.instance.levelUpBottons[1].UpdateBottonDisplay(PlayerController.instance.activeWeapon);

    }
}
