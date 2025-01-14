using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponLevel;
    public List<WeaponStates> state;
    [HideInInspector]
    public bool stateUpdated;
    public Sprite icon;
    
    public void LevelUp()
    {
        if (weaponLevel < state.Count-1)
        {
            weaponLevel +=1;
            stateUpdated = true;
        }
    }
}
[System.Serializable]
public class WeaponStates
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration;
    public string upgradeText;

}
