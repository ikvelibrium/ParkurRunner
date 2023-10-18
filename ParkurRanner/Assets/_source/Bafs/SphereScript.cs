using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    [SerializeField] private float _actingTime;
    [SerializeField] private float _pointsToPlus;
    PlayerController playerController;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.TryGetComponent(out playerController);
            playerController.GotSphere(_pointsToPlus, _actingTime);
            Destroy(gameObject);
        }
    }
}
