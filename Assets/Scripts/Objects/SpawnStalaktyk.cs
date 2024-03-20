using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnStalaktyk : MonoBehaviour
{
    [SerializeField] GameObject stalaktytPrefab;
    [SerializeField] Vector3 stalaktytPosition;
    [SerializeField] float timeSpawn = 1;
    
    private void Update()
    {
        timeSpawn-=Time.deltaTime;
        if (timeSpawn <= 0)
        {
            GenerateStalaktyt();
            timeSpawn = 1;
        }
    }

    void GenerateStalaktyt()
    {
        Instantiate(stalaktytPrefab, GenerateSpawnPos(), stalaktytPrefab.transform.rotation);
    }
     
    Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(transform.position.x-50, transform.position.x+50);
        float spawnPosY = transform.position.y;
        float spawnPosZ = transform.position.z;
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        return spawnPos;
    }
   

}
