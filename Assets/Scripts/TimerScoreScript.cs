using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class TimerScoreScript : MonoBehaviour
{
    public float timeRemaining;
    public string timeText;
    public TextMeshProUGUI HealthCanvas;

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        Debug.Log(StaticDataHolder.timeRemaining);
        if (SceneManager.GetActiveScene().name == "lvl1" && StaticDataHolder.maxlives==StaticDataHolder.maximumLives)
        {
            timeRemaining = 900;
            return;
        }

        timeRemaining = StaticDataHolder.timeRemaining;
    }

    void Update()
    {
        int min, sec;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            StaticDataHolder.timeRemaining = timeRemaining;
            sec = (int)timeRemaining % 60;
            min = (int)timeRemaining / 60;
            if (sec < 10)
            {
                StaticDataHolder.timeText = "" + min + ":0" + sec; 
            }
            else
            {
                StaticDataHolder.timeText = "" + min + ":" + sec;
            }
            timeText = StaticDataHolder.timeText;
            HealthCanvas.text = timeText;
        }
        else
        {
            GameObject sphere = GameObject.FindGameObjectWithTag("EnclosingSphere");
            sphere.GetComponent<EnclosingSphereContact>().GameOver("Time\'s up");
        }
    }
}
