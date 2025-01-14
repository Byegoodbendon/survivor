using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    private void Awake() {
        instance = this;
    }

    public Slider expSlider;
    public TMP_Text LvlText;
    private float maxExp;
    void Start()
    {
        expSlider.value = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void getExp(int exp)
    {
        expSlider.value += 1 ;
        if(expSlider.value >= expSlider.maxValue)
        {
            expSlider.value -= expSlider.maxValue;
            LevelUp();
        }

    }
    public void LevelUp()
    {
        expSlider.maxValue = ExperienceLevelController.instance.expLevels[ExperienceLevelController.instance.currentLevel];
    }*/
    public void UpdateExperience(int currentExp, int levelExp, int currentLevel)
    {
        expSlider.value = currentExp;
        expSlider.maxValue = levelExp;
        LvlText.text = "Level " + currentLevel;

    }
}
