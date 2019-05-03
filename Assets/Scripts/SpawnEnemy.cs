using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    // Used to distinguish enemy and player
    public GameObject enemy;
    public GameObject player;
    public Transform parent;
    public GameObject roundControl;
    
    // Used for orientation and position of enemy
    private Quaternion spawnRot;
    public Transform[] spawnPoints; 
    private bool wait = true;

    // Used for game mechanics
    private int numSpawn;
    public int currSpawn;

    void Start()
    {
        spawnRot = this.transform.rotation;
        
        // Intitialize spawn numbers
        numSpawn = 2;
        currSpawn = numSpawn;
    }

    void Update(){
        if(currSpawn <= 0 && wait){
            roundControl.gameObject.GetComponent<UpdateRound>().NewRound();
            wait = false;
        }
    }

    public IEnumerator StartSpawn()
    {
        for(int i = 0; i < numSpawn; i++){
            SpawnOne();
            yield return new WaitForSeconds(5);
        }
    }

    public void StartNewRound()
    {
        numSpawn *= 2;
        currSpawn = numSpawn;
    }

    void SpawnOne()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnRot);
    }

    public void UpdateCount(){
        currSpawn--;
    }

    public void StopWait(){
        wait = true;
    }
}
