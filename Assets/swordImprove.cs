using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

public class swordImprove : MonoBehaviour
{
    public GameObject gold;
    public GameObject myLight;
    //public AudioSource sound;
    public CheckPoint checkpointToActivate;
    //public GameObject[] oldSwordPieces;
    public StudioEventEmitter emitter;
    private void Start()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                
                gold.SetActive(true);
                Controller.Instance.sword.GetComponent<weaponscript>().damage = 2;
                Destroy(gameObject);
                DeactivateOldSword();
                Controller.Instance.sword.GetComponent<weaponscript>().ChangeColliders();
                Controller.Instance.sword.GetComponent<weaponscript>().lastCollider.enabled = false; // since in absolutely no load the greatsword is chosen as default weapon,
                //we are disabling its collider at every load in order to not bug the projectiles from the guns
                Controller.Instance.sword.GetComponent<Animator>().SetBool("Golden", true);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            emitter.Play();
            gold.SetActive(true);
            gameObject.SetActive(false);
            //myLight.SetActive(false);
            gold.transform.parent.GetComponent<weaponscript>().damage = 2;
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
            if (checkpointToActivate)
            {
                checkpointToActivate.SaveGame();
            }
            
            Controller.Instance.sword.GetComponent<Animator>().SetBool("Golden", true);
            DeactivateOldSword();
            Controller.Instance.sword.GetComponent<weaponscript>().ChangeColliders();
            Controller.Instance.sword.GetComponent<Animator>().SetBool("Off", false);
            if (Controller.Instance.HandBallista.activeInHierarchy && SceneManager.GetActiveScene().name != "HiveMap")
            {
                Controller.Instance.HandBallista.GetComponent<Animator>().SetBool("Off", true);
            }
            
            Controller.Instance.staffAnim.SetBool("Off", true);
            MAchinegunScript.Instance.anim.SetBool("Off", true);
            BazookaScript.Instance.anim.SetBool("Off", true);
            selectionScript.Instance.GetBehindIcon(0);
        }
    }
    void DeactivateOldSword()
    {
        /*
        foreach (var item in oldSwordPieces)
        {
            item.GetComponent<MeshRenderer>().enabled = false; //transformar isso em variaveis publicas
        }
        */
    }
}
