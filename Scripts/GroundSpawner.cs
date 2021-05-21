using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] Transform startpoint;
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile (bool spawnItems)
    {
        GameObject temp =  Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        startspawning();
        Debug.Log(transform.position);
    }

    public void startspawning()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

    public void ResetTilePosi()
    {
        transform.position = startpoint.position;
    }
   
}
