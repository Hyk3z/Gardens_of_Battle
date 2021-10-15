using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{

    public GameObject sword;
    public GameObject staff;
    public GameObject ballista;
    public GameObject tutorial;
    public GameObject nextCheckpoint;
    public int CheckpointID;
    public bool sleeping;
    public GameObject DestroyOnGameLoad;
    //public bool goldenSword;
    public UnityEvent thingsToDoOnThisLoad;
    public UnityEvent thingsToDoOnThisLoadDelayed;
    public int difficultyLevel;
    //  public GameObject StaffTutorial;
    //fazer um novo tipo de chceckpoint, o optional. Ele nao devera usar ID, mas ira sobrescrever o checkpoint anterior

    private void Awake()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            LoadGame();
        }
        
        
    }

    

    //fazer duas listas no game manager. Aqueles objetos a ser destruidos de fato (mortos antes do ultimo save), e aqueles destruidos no gameplay atual do player, para caso de morte sem save.
    //Zerar a lista provisoria em caso de morte, e adicionar para a lista verdadeira apenas em save.
    private void Start()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad == false && GetComponent<BoxCollider>()) //new game
        {
            GetComponent<BoxCollider>().enabled = true;
            
        }
        else if (PlayerPrefs.GetInt("CurrentCheckpoint") > CheckpointID)//loading
        {
            gameObject.SetActive(false);
            
        }
        else //if current checkpoint is before than this checkpoint ID and it is loading
        {
            if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            
        }
    }

    public void SaveGame()
    {
        if (!GameManager.Instance)
        {
            return;
        }
        if (GameManager.Instance.nightmare)
        {
            return;
        }

        
        if (!GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
        {
            difficultyLevel = 0;//easy
        }
        if (GameManager.Instance.normal)
        {
            difficultyLevel = 1;//normal
        }
        if (GameManager.Instance.hard)
        {
            difficultyLevel = 2;//hard
        }
        

        PlayerPrefs.SetInt("Difficulty", difficultyLevel);
        PlayerPrefs.SetFloat("TimePassed", Controller.Instance.timePassed);
        PlayerPrefs.SetInt("GameStarted", 1);
        PlayerPrefs.SetInt("Kills", GameManager.Instance.killedMonsters);
        if (Controller.Instance.gotFirstPotion)
        {
            PlayerPrefs.SetInt("GotFirstPotion", 1);
        }

        PlayerPrefs.SetFloat("PlayerMaxHealth", Controller.Instance.maxLife);
        
        PlayerPrefs.SetInt("CurrentCoins", Controller.Instance.coins);
        PlayerPrefs.SetFloat("Ammo", Controller.Instance.ammo);
        PlayerPrefs.SetFloat("Mushrooms", Controller.Instance.Mushrooms);
        PlayerPrefs.SetInt("StoredPotions", Controller.Instance.storedPotions);
        
        
        if (Controller.Instance.GotBallista)
        {
            PlayerPrefs.SetInt("GotBallista", 1);
        }
        if (Controller.Instance.gotStaff)
        {
            PlayerPrefs.SetInt("GotStaff", 1);
        }
        if (Controller.Instance.gotBazooka)
        {
            PlayerPrefs.SetInt("GotBazooka", 1);
        }
        if (Controller.Instance.gotMachinegun)
        {
            PlayerPrefs.SetInt("GotMachinegun", 1);
        }
        if (!GameManager.Instance)
        {
            return;
        }

        foreach (var item in GameManager.Instance.discartList)
        {
            GameManager.Instance.objectsToDestroyByLoad.Add(item);
        }
        GameManager.Instance.discartList.Clear();

        foreach (var item in GameManager.Instance.objectsToDestroyByLoad)
        {
            PlayerPrefs.SetInt(item, 1);//1 significa que deve ser destruido no load.
        }
        GetComponent<AudioSource>().Play();
        if (nextCheckpoint)
        {
            nextCheckpoint.SetActive(true);
        }
        if (GetComponent<BoxCollider>())
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        
        PlayerPrefs.SetInt("CurrentCheckpoint", CheckpointID);
    }

    public void LoadGame()
    {
        if (GameManager.Instance)
        {
            if (PlayerPrefs.GetInt("Difficulty") == 0)
            {
                //
            }
            if (PlayerPrefs.GetInt("Difficulty") == 1)
            {
                GameManager.Instance.normal = true;
            }
            if (PlayerPrefs.GetInt("Difficulty") == 2)
            {
                GameManager.Instance.hard = true;
            }
            //GameManager.Instance = PlayerPrefs.GetInt("Difficulty", 0);
        }
        if (GameManager.Instance)
        {
            GameManager.Instance.killedMonsters = PlayerPrefs.GetInt("Kills", 0);
        }
        
        Controller.Instance.timePassed = PlayerPrefs.GetFloat("TimePassed", 0);
        if (GetComponent<BoxCollider>())
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        
        //sapivangas.Instance.waiting = true;
        selectionScript.Instance.GetComponent<RawImage>().enabled = true;
        if (PlayerPrefs.GetInt("CurrentCheckpoint") != CheckpointID)
        {
            return;
        }
        Controller.Instance.transform.position = transform.position;
        Controller.Instance.transform.rotation = transform.rotation;
        Controller.Instance.maxLife = PlayerPrefs.GetInt("PlayerMaxHealth");
        Controller.Instance.coins = PlayerPrefs.GetInt("CurrentCoins");
        Controller.Instance.ammo = PlayerPrefs.GetFloat("Ammo");
        Controller.Instance.Mushrooms = PlayerPrefs.GetFloat("Mushrooms");
        Controller.Instance.life = PlayerPrefs.GetFloat("PlayerMaxHealth");
        Controller.Instance.storedPotions = PlayerPrefs.GetInt("StoredPotions");
        if (PlayerPrefs.GetInt("GotFirstPotion") == 1)
        {
            Controller.Instance.gotFirstPotion = true;
            Controller.Instance.potCanvasIcon.SetActive(true);
            Controller.Instance.potCanvasText.gameObject.SetActive(true);
            Controller.Instance.potCanvasText.text = "" + PlayerPrefs.GetInt("StoredPotions");
        }
        if (PlayerPrefs.GetInt("GotBallista") == 1)
        {
            Controller.Instance.UpdateArrowText();
            ballista.SetActive(true);
            Controller.Instance.GotBallista = true;
        }
        if (PlayerPrefs.GetInt("GotStaff") == 1)
        {
            staff.SetActive(true);
            Controller.Instance.gotStaff = true;
        }
        if (PlayerPrefs.GetInt("GotBazooka") == 1)
        {
            Controller.Instance.UpdateMushroomText();
            Controller.Instance.gotBazooka = true;
        }
        if (PlayerPrefs.GetInt("GotMachinegun") == 1)
        {
            Controller.Instance.gotMachinegun = true;
            Controller.Instance.bazookaLock = true;
        }

        if (DestroyOnGameLoad)
        {
            Destroy(DestroyOnGameLoad);
        }//Antes era: Destroy(GameObject.Find("Cogumelo"));


        ballista.GetComponent<Animator>().SetBool("Off", true);
        sword.SetActive(true);
        sword.GetComponent<Animator>().SetBool("Off", true);
        
        if (Controller.Instance.gotMachinegun && Controller.Instance.ammo > 0)
        {
            ballista.SetActive(false);
            staff.GetComponent<Animator>().SetBool("Off", true);
            selectionScript.Instance.GetBehindIcon(4);
            
            MAchinegunScript.Instance.GetComponent<Animator>().SetBool("Off", false);
            BazookaScript.Instance.GetComponent<Animator>().SetBool("Off", true);
            sword.GetComponent<Animator>().SetBool("Off", true);
        }
        else if (Controller.Instance.gotBazooka)
        {
            Controller.Instance.UpdateMushroomText();
            if (Controller.Instance.Mushrooms > 0)
            {
                ballista.SetActive(false);
                staff.GetComponent<Animator>().SetBool("Off", true);
                //ballista.GetComponent<Animator>().SetBool("Off", true);
                
                selectionScript.Instance.GetBehindIcon(3);
                
                MAchinegunScript.Instance.GetComponent<Animator>().SetBool("Off", true);
                BazookaScript.Instance.GetComponent<Animator>().SetBool("Off", false);

                
                sword.GetComponent<Animator>().SetBool("Off", true);
            }
            
        }
        else if (Controller.Instance.gotStaff)
        {
            
            selectionScript.Instance.GetBehindIcon(1);
            
            staff.GetComponent<Animator>().SetBool("Off", false);
            sword.GetComponent<Animator>().SetBool("Off", true);
        }
        else if (Controller.Instance.GotBallista)
        {
            
            selectionScript.Instance.GetBehindIcon(2);
            
            staff.GetComponent<Animator>().SetBool("Off", true);
            ballista.SetActive(true);
            ballista.GetComponent<Animator>().SetBool("Off", false);
            sword.GetComponent<Animator>().SetBool("Off", true);
        }
        else
        {
            
            selectionScript.Instance.GetBehindIcon(0);
            
            sword.GetComponent<Animator>().SetBool("Off", false);
        }
        if (tutorial)
        {
            tutorial.SetActive(false);
        }
        if (sapivangas.Instance)
        {
            sapivangas.Instance.explain = true;
            sapivangas.Instance.explainLock = true;
            sapivangas.Instance.GetComponent<Animator>().SetBool("Explain", true);
        }
        
        
        thingsToDoOnThisLoad.Invoke();
        StartCoroutine(DelayedEvent());
        Controller.Instance.coinText.text = "" + Controller.Instance.coins;

        //if (caminhao)
        //{
        //    var caminhao = GameObject.Find("CaminhaoDoSom").GetComponent<SoundScript>(); //mudar para uma referencia publica e checar se ela existe. aqui eh a linha de trilha sonoraLoad
        //    caminhao.danger = true;
       // }
        
    }

    public void WakeUp()
    {
        sleeping = false;
    }

    IEnumerator DelayedEvent()
    {

        yield return new WaitForSeconds(0.05f);
        thingsToDoOnThisLoadDelayed.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !sleeping)
        {
            SaveGame();
            
            if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().enabled = false;
            }
            
        }
    }

}
