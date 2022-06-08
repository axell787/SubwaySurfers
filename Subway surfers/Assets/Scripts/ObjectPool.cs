using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // public static ObjectPool instance; 

    // private List<GameObject> pooledObjects = new List<GameObject>();
    // private int amountToPool = 6;

    // [SerializeField] private GameObject tilePrefab;

    // private void Awake() 
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }    
    // }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     for (int i = 0; i < amountToPool; i++)
    //     {
    //         GameObject obj = Instantiate(tilePrefab);
    //         obj.SetActive(false);
    //         pooledObjects.Add(obj)
    //     }   
    // }

    // public GameObject GetPooledObject()
    // {
    //     for (int i = 0; i < pooledObjects.Count; i++)
    //     {
    //         if(!pooledObjects[i].activeInHierarchy)
    //         {
    //             retun pooledObjects[i];
    //         }
    //     }

    //     retun null;
    // }
    public static ObjectPool current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;

    private List<GameObject> pooledObjects;

    private void Awake() {
        current = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if(willGrow)
        {
            GameObject obj = Instantiate(pooledObject, transform);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}

