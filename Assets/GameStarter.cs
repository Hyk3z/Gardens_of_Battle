using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(startValues());
        if (SceneManager.GetActiveScene().name == "SniperMap")
        {
            Controller.Instance.ammo = 0;
        }
    }

    IEnumerator startValues()
    {
        
        if (PlayerPrefs.GetInt("Shield2") == 1)
        {
            Controller.Instance.lvl2Shield = true;
        }
        
        yield return new WaitForSeconds(0.1f);
        

        if (GameManager.Instance && SceneManager.GetActiveScene().name == "SniperMap")
        {
            Controller.Instance.coins = PlayerPrefs.GetInt("Shields", 0);
            Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
            Controller.Instance.maxLife = PlayerPrefs.GetFloat("PlayerMaxHealth", Controller.Instance.maxLife);
            Controller.Instance.life = PlayerPrefs.GetFloat("PlayerCurrentHealth", Controller.Instance.maxLife);
            Controller.Instance.healthBarBackGround.value = Controller.Instance.maxLife / 100;
            Controller.Instance.storedPotions = PlayerPrefs.GetInt("StoredPotions", 0);
            if (Controller.Instance.storedPotions > 0)
            {
                Controller.Instance.potCanvasIcon.SetActive(true);
                Controller.Instance.potCanvasText.gameObject.SetActive(true);
                Controller.Instance.potCanvasText.text = Controller.Instance.storedPotions.ToString();
            }
            PlayerPrefs.SetFloat("TimePassed", 0);
            GameManager.Instance.TimeSpent = 0;
            if (SceneManager.GetActiveScene().name == "SniperMap")
            {
                Controller.Instance.ammo = 0;
            }
            
        }
        if (GameManager.Instance && SceneManager.GetActiveScene().name == "HiveMap")
        {
            Controller.Instance.coins = PlayerPrefs.GetInt("Shields", 0);
            Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
            
            Controller.Instance.maxLife = PlayerPrefs.GetFloat("PlayerMaxHealth", Controller.Instance.maxLife);
            Controller.Instance.life = PlayerPrefs.GetFloat("PlayerCurrentHealth", Controller.Instance.maxLife);
            Controller.Instance.healthBarBackGround.value = Controller.Instance.maxLife / 100;
            Controller.Instance.storedPotions = PlayerPrefs.GetInt("StoredPotions", 0);
            //Controller.Instance.swordAnim.SetBool("Off", true);
            //Controller.Instance.HandBallista.GetComponent<Animator>().SetBool("Off", false);
            
            
            if (Controller.Instance.storedPotions > 0)
            {
                Controller.Instance.potCanvasIcon.SetActive(true);
                Controller.Instance.potCanvasText.gameObject.SetActive(true);
                Controller.Instance.potCanvasText.text = Controller.Instance.storedPotions.ToString();
            }
            PlayerPrefs.SetFloat("TimePassed", 0);
            GameManager.Instance.TimeSpent = 0;
            Controller.Instance.ammo = PlayerPrefs.GetFloat("Ammo", 0);
            

            if (PlayerPrefs.GetInt("GotBallista") == 1)
            {
                Controller.Instance.GotBallista = true;
                if (Controller.Instance.ammo > 0)
                {
                    weaponscript.Instance.SwapToBallista();
                    weaponscript.Instance.Anim.SetBool("Off", true);
                }
            }

        }
    }

}
