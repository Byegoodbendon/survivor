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
    public TMP_Text coinText;
    private float maxExp;
    public LevelUpSelectionBotton[] levelUpBottons;
    public GameObject levelUpPanel;
    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;
    void Start()
    {
        expSlider.value = 0.0f;
        
    }
    
    public void UpdateExperience(int currentExp, int levelExp, int currentLevel)
    {
        expSlider.value = currentExp;
        expSlider.maxValue = levelExp;
        LvlText.text = "Level " + currentLevel;

    }
    public void UpdateCoin()
    {
        coinText.text = CoinController.instance.currentCoins.ToString();

    }
}
