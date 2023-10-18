using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform BeginLvl;
    public Transform EndLvl;
    [SerializeField] private List<Transform> _objects = new List<Transform>();

    private void Start()
    {
        int picker = 0;
        for (int i = 0; i < _objects.Count; i++)
        {
            picker = Random.Range(0, _objects.Count);
            _objects[picker].gameObject.SetActive(true);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}