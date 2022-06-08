using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            //GameObject temp = Instantiate(coinPrefab, transform);
            //
            GameObject obj = ObjectPool.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = GetCoinPosition(GetComponent<Collider>());
            obj.SetActive(true);
        }
    }

    Vector3 GetCoinPosition (Collider collider)
    {
        int[] coinLine = new int[] {-5, 0, 5};
        int randomIndex = Random.Range(0, coinLine.Length);
        int randomLine = coinLine[randomIndex];

        Vector3 point = new Vector3(
            randomLine,
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point))
        {
            point = GetCoinPosition(collider);
        }

        point.y = 1;
        return point;
    }
}
