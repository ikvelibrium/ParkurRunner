using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float maxChunksOnScene;
    [SerializeField] Chunk[] ChunkPrefabs;
    [SerializeField] Chunk chunkWithCheckLine;
    [SerializeField] private int _lvlSize;
    [SerializeField] private List<Chunk> _spawnedChunks = new List<Chunk>();
    private int _wcichChunkToDelete = 0;
    private void Start()
    {
        for (int i = 0; i < _lvlSize + 1; i++)
        {
            ChunkSpawn();
           
        }

    }
    private void Update()
    {
        
    }
    public void ChunkSpawn()
    {
        if (_spawnedChunks.Count % 3 == 0)
        {
            Chunk newChank = Instantiate(chunkWithCheckLine);

            newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].EndLvl.position - newChank.BeginLvl.localPosition;
            _spawnedChunks.Add(newChank);
        } else
        {
            Chunk newChank = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

            newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].EndLvl.position - newChank.BeginLvl.localPosition;
            _spawnedChunks.Add(newChank);
        }
        


    }
    public void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            ChunkSpawn();
        }
        int costl = _wcichChunkToDelete;
        while( _wcichChunkToDelete < costl + 2 )
        {
            
            _spawnedChunks[_wcichChunkToDelete].Die();
            _wcichChunkToDelete++;
        }
    }

}