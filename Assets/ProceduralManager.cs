using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ProceduralManager : MonoBehaviour
{
    public GameObject[] TerrainTiles;
    void Start()
    {
        CreateFirstTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateFirstTiles()
    {
        Instantiate(TerrainTiles[0]);
        var currTile = Instantiate(TerrainTiles[1]);
        currTile.transform.position = new Vector3(0, 0, 15);
        currTile = Instantiate(TerrainTiles[0]);
        currTile.transform.position = new Vector3(0, 0, 30);
        currTile = Instantiate(TerrainTiles[1]);
        currTile.transform.position = new Vector3(0, 0, 45);
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

}
