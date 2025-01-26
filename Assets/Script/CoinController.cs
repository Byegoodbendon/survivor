using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    public int currentCoins;
    public CoinPickup coin;
    private void Awake() {
        CoinController.instance = this;
    }
    
    public void addCoin(int coinAmount)
    {
        currentCoins += coinAmount;
        UiController.instance.UpdateCoin();

    }
    public void DropCoin(Vector3 position, int value)
    {
        CoinPickup newCoin = Instantiate(coin, position + new Vector3(0.2f,0.1f,0), quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }
    public void SpendCoin(int coinToSpend)
    {
        currentCoins -= coinToSpend;
        UiController.instance.UpdateCoin();
    }
}
