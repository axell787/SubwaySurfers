using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            return;
        }
        ScoreManager.instance.AddPoint();
        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }
}
