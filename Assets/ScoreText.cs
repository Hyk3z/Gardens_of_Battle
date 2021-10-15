using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour
{
    Text text;
    float hours;
    float minutes;
    float seconds;
    float t;
    int trueMinutes;
    int trueSeconds;
    int trueHours;

    string secondString;
    string minuteString;
    string hourString;
    public bool isForKill;
    public bool isForTime;
    public bool isForItems;
    //public Text MapName;
    public bool sceneControl;
    public Text mapNameText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.currentNextLevel == 2 && sceneControl)
        {
            mapNameText.text = "Anthill Bay";
        }
        if (GameManager.Instance.currentNextLevel == 3 && sceneControl)
        {
            if (mapNameText)
            {
                mapNameText.text = "Danger Fields";
            }
            
        }
        text = GetComponent<Text>();
        t = GameManager.Instance.TimeSpent;
        

        seconds = (t % 3600) % 60;
        minutes = (t % 3600) / 60;
        hours = t / 3600;

        trueHours = (int)hours;
        
        trueMinutes = (int)minutes;
        trueSeconds = (int)seconds;

        if (trueHours < 10)
        {
            hourString = "0" + trueHours;
        }
        else
        {
            hourString = trueHours.ToString();
        }
        if (trueMinutes < 10)
        {
            minuteString = "0" + trueMinutes;
        }
        else
        {
            minuteString = trueMinutes.ToString();
        }
        if (trueSeconds < 10)
        {
            secondString = "0" + trueSeconds;
        }
        else
        {
            secondString = trueSeconds.ToString();
        }
        if (isForKill)
        {
            text.text = "Kills: " + GameManager.Instance.killedMonsters;
        }
        else if (isForItems)
        {
            text.text = "Items: " + GameManager.Instance.collectedItems;
        }
        else if (isForTime)
        {
            text.text = "Time: " + hourString + "h" + minuteString + "m" + secondString + "s";
        }
        //text.text = "Kills: " + GameManager.Instance.killedMonsters + "\r\n" + "Items: " + GameManager.Instance.collectedItems + "\r\n" + "Time: " + hourString + "h" + minuteString + "m" + secondString + "s";
        
    }
    private void Update()
    {
        if (sceneControl)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameManager.Instance.currentNextLevel == 2)
                {
                    SceneManager.LoadScene("SniperMap");
                    Time.timeScale = 1;
                }
                else if (GameManager.Instance.currentNextLevel == 3)
                {
                    SceneManager.LoadScene("HiveMap"); //Yeeehaw!
                }
                else if (GameManager.Instance.currentNextLevel == 4)
                {
                    SceneManager.LoadScene("CreditsScene");
                }
            }
        }
    }
}

//3.6 