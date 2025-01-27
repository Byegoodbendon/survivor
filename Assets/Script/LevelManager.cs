using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private bool gameActive;
    public float timer;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        gameActive = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameActive == true)
        {
            timer += Time.deltaTime;
            UiController.instance.timerUpdate(timer);
        }
        
        
    }
    public void EndLevel()
    {
        gameActive = false;
        
        StartCoroutine(DelayDisplay());
    }
    IEnumerator DelayDisplay()
    {
        yield return new WaitForSeconds(1f);
        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60);
        UiController.instance.survivedTimeText.text = minutes.ToString() + "mins" + seconds.ToString("00") + "secs";
        
        UiController.instance.levelEndScreen.SetActive(true);
        

    }
}
