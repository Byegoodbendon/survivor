using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LevelUpSelectionBotton : MonoBehaviour
{
    public TMP_Text upgradeText, nameLevelText;
    public Image weaponIcon;
    private Weapon assignedWeapon;
    
    public void UpdateBottonDisplay(Weapon thisWeapon)
    {
        if(thisWeapon.gameObject.activeSelf == true)
        {
            upgradeText.text = thisWeapon.state[thisWeapon.weaponLevel].upgradeText;
            nameLevelText.text = thisWeapon.name + "-Lvl." + thisWeapon.weaponLevel;
            weaponIcon.sprite = thisWeapon.icon;
        }else
        {
            upgradeText.text = "Unlock weapon!" + thisWeapon.name;
            nameLevelText.text = thisWeapon.name;
            weaponIcon.sprite = thisWeapon.icon;
        }
        assignedWeapon = thisWeapon;

    }
    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            if(assignedWeapon.gameObject.activeSelf == true)
            {
                assignedWeapon.LevelUp();
                
            }else
            {
                PlayerController.instance.AddWeapon(assignedWeapon);
            }
            UiController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
