using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiledScript : MonoBehaviour
{
    [SerializeField] private float _actingTime;
    PlayerController playerController;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.TryGetComponent(out playerController);
            playerController.GotShiled(_actingTime);
            Destroy(gameObject);
        }
    }
}
