using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnStalaktyk : MonoBehaviour
{
    public GameObject stalaktytPrefab;
    public Vector3 stalaktytPosition;
    public float timeSpawn = 3;
    
    private void Update()
    {
        timeSpawn-=Time.deltaTime;
        if (timeSpawn <= 0)
        {
            GenerateStalaktyt();
            timeSpawn = 3;
        }
    }

    void GenerateStalaktyt()
    {
        Instantiate(stalaktytPrefab, GenerateSpawnPos(), stalaktytPrefab.transform.rotation);
    }
    IEnumerator GenerateStalaktykt()
    {
        yield return new WaitForSeconds(1);
        GameObject stalaktyt = Instantiate(stalaktytPrefab, GenerateSpawnPos(), stalaktytPrefab.transform.rotation);
        
            
    }

    Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(180f, 260f);
        float spawnPosY = 60;
        float spawnPosZ = 0;
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        return spawnPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

    }


}
