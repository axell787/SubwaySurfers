using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 100;
    public float numOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    

    void Start()
    {
        for (int i = 0; i < numOfTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
        
    }

    void Update()
    {
        if(playerTransform.position.z - 50 > zSpawn - (numOfTiles*tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        // GameObject obj = ObjectPool.current.GetPooledObject();
        // if (obj == null) return;
        // obj.transform.position = transform.forward * zSpawn;
        // obj.transform.rotation = transform.rotation;
        // obj.SetActive(true);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        //gameObject.SetActive(false);
    }

    
}
