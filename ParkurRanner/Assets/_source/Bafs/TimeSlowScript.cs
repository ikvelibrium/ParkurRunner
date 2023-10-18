using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowScript : MonoBehaviour
{
    [SerializeField] private float _actingTime;
    [SerializeField] private float _howMuchToSlowDawn;
    PlayerController playerController;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.TryGetComponent(out playerController);
           // playerController
            Destroy(gameObject);
        }
    }
}
