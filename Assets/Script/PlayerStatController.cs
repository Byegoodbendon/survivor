using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public static PlayerStatController instance;
    private void Awake() {
        instance = this;
    }
    public List<PlayerStateValue> moveSpeed, pickupRange, health, maxWeapons;
    public int moveSpeedLevelCount,pickupRangeLevelCount,healthLevelCount;
    public int moveSpeedLevel, pickupRangeLevel, healthLevel, maxWeaponsLevel;
        void Start()
    {
        for(int i = moveSpeed.Count - 1; i < moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStateValue(moveSpeed[i].cost + moveSpeed[1].cost, moveSpeed[i].value + moveSpeed[1].value - moveSpeed[0].value));
        }
        for(int i = pickupRange.Count - 1; i < pickupRangeLevelCount; i++)
        {
            pickupRange.Add(new PlayerStateValue(pickupRange[i].cost + pickupRange[1].cost, pickupRange[i].value + pickupRange[1].value - pickupRange[0].value));
        }
        for(int i = health.Count - 1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStateValue(health[i].cost + health[1].cost, health[i].value + health[1].value - health[0].value));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateDisplay()
    {
        UiController.instance.moveSpeedUpgradeDisplay.UpdateDisplay(moveSpeed[moveSpeedLevel+1].cost,moveSpeed[moveSpeedLevel].value,moveSpeed[moveSpeedLevel+1].value);
        UiController.instance.pickupRangeUpgradeDisplay.UpdateDisplay(pickupRange[pickupRangeLevel+1].cost,pickupRange[pickupRangeLevel].value,pickupRange[pickupRangeLevel+1].value);
        UiController.instance.healthUpgradeDisplay.UpdateDisplay(health[healthLevel+1].cost,health[healthLevel].value,health[healthLevel+1].value);
        UiController.instance.maxWeaponsUpgradeDisplay.UpdateDisplay(maxWeapons[maxWeaponsLevel+1].cost,maxWeapons[maxWeaponsLevel].value,maxWeapons[maxWeaponsLevel+1].value);
    }
    [System.Serializable]
    public class PlayerStateValue
    {
        public int cost;
        public float value;
        public PlayerStateValue(int newCost, float newValue)
        {
            cost = newCost;
            value = newValue;
        }
    }
}
