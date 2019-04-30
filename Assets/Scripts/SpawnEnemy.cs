using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private int numSpawn;
    private Vector3 spawnPos;
    private Vector3 correctPos;
    private Quaternion spawnRot;
    private float stayCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        numSpawn = 5;
        spawnPos = this.transform.position;
        correctPos = spawnPos - new Vector3(0, 2, 0);
        spawnRot = this.transform.rotation;
    }

    void Update(){
        if (stayCount > 5.0f)
        {
            stayCount = 0.0f;
            Spawn();
        }
        else
        {
            stayCount += Time.deltaTime;
        }
    }

    void Spawn()
    {
        // If the player has no health left...
        if(player.gameObject.GetComponent<PlayerHealth>().GetHealth() <= 0f)
        {
            // ... exit the function.
            return;
        }
        //Quaternion qRot = Quaternion.Euler(spawnRot);
        Instantiate(enemy, correctPos, spawnRot);
        numSpawn--;
    }
}
