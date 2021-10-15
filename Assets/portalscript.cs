using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalscript : MonoBehaviour
{
    public bool forDragon;
    public int NextLevel;
    public StudioEventEmitter passSFX;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Griffin"))
        {
            if (Controller.Instance.lvl2Shield)
            {
                PlayerPrefs.SetInt("Shield2", 1);
            }
            PlayerPrefs.SetInt("Shields", Controller.Instance.coins);
            GameManager.Instance.currentNextLevel = NextLevel;
            if (GameManager.Instance)
            {
                PlayerPrefs.SetFloat("PlayerMaxHealth", Controller.Instance.maxLife);
                PlayerPrefs.SetFloat("PlayerCurrentHealth", Controller.Instance.life);
                
                PlayerPrefs.SetInt("CurrentLevel", NextLevel);
                GameManager.Instance.TimeSpent = Controller.Instance.timePassed;
                PlayerPrefs.SetInt("StoredPotions", Controller.Instance.storedPotions);
                PlayerPrefs.SetFloat("Ammo", Controller.Instance.ammo);
                if (Controller.Instance.GotBallista)
                {
                    PlayerPrefs.SetInt("GotBallista", 1);
                }
            }
            
            if (Controller.Instance.GotBallista)
            {
                PlayerPrefs.SetInt("GotBallista", 1);
            }

            if (forDragon)
            {
                PlayerPrefs.SetInt("forDragon", 1);
            }
            /*
            switch (NextLevel)
            {
                default:
                    break;
                case 2:
                    SceneManager.LoadScene("SniperMap");
                    break;
                case 3:
                    SceneManager.LoadScene("DarkForest");
                    break;
            }
            */
            SceneManager.LoadScene("ScoreScene");
            passSFX.Play();
        }
    }
}
