using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnStalaktyk : MonoBehaviour
{
    public GameObject stalaktytPrefab;
    public Vector3 stalaktytPosition;

    private void Start()
    {
        
    }
    IEnumerator GenerateStalaktykt()
    {
        GameObject stalaktyt = Instantiate(stalaktytPrefab, GenerateSpawnPos(), Quaternion.identity);
        yield return new WaitForSeconds(2);
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
