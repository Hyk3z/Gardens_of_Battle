using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int killedMonsters;
    public int collectedItems;
    public float TimeSpent;
    public List<string> objectsToDestroyByLoad;
    static GameManager m_Instance;
    public List<string> discartList; //list that will only integrate objectsToDestroyByLoad when saving.
    public bool normal;
    public bool hard;
    public bool nightmare;
    public int currentNextLevel;
    public float currentVersion = 0.8f;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            return m_Instance;
        }
    }

    public bool toLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
