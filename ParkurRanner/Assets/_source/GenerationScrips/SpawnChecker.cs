using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChecker : MonoBehaviour
{
    PlayerController playerController;
    private void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
           
            other.gameObject.TryGetComponent(out playerController);
            playerController.SpawnLoc();
        }
    }
}
