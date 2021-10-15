using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.killedMonsters = 0;
            GameManager.Instance.collectedItems = 0;
            GameManager.Instance.TimeSpent = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance)
        {
            
            if (!GameManager.Instance.nightmare)
            {
                
                GameManager.Instance.discartList.Clear();
                GameManager.Instance.toLoad = true;
                if (SceneManager.GetActiveScene().name == "StraightMap")
                {
                    SceneManager.LoadScene("StraightMap");
                }
                else if (SceneManager.GetActiveScene().name == "SniperMap")
                {
                    SceneManager.LoadScene("SniperMap");
                }
                else if (SceneManager.GetActiveScene().name == "HiveMap")
                {
                    SceneManager.LoadScene("HiveMap");
                }
            }
            else
            {
                //GameManager.Instance.discartList.Clear();
                GameManager.Instance.toLoad = false;
                
            }
        }
    }
}
