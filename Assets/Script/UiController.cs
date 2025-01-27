using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    private void Awake() {
        instance = this;
    }

    public Slider expSlider;
    public TMP_Text LvlText;
    public TMP_Text coinText;
    public TMP_Text timeText;
    public GameObject levelEndScreen;
    public TMP_Text survivedTimeText;
   
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
    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void UpdateCoin()
    {
        coinText.text = CoinController.instance.currentCoins.ToString();

    }
    public void PurchaseMoveSpeed()
    {
        PlayerStatController.instance.PurchaseMoveSpeed();
        SkipLevelUp();

    }
    public void PurchaseHealth()
    {
        PlayerStatController.instance.PurchaseHealth();
        SkipLevelUp();
        
    }
    public void PurchasePickupRange()
    {
        PlayerStatController.instance.PurchasePickupRange();
        SkipLevelUp();
        
    }
    public void PurchaseMaxWeapons()
    {
        PlayerStatController.instance.PurchaseMaxWeapons();
        SkipLevelUp();
        
    }
    public void timerUpdate(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = "Time: " + minutes + ":" + seconds.ToString("00"); 
     }
    public void GoToMenu()
    {

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
