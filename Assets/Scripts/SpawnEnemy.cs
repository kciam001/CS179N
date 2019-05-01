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
    
    
    // Used for orientation and position of enemy
    private Quaternion spawnRot;
    public Transform[] spawnPoints; 

    // Used for game mechanics
    private int numSpawn;
    public int currSpawn;
    
    private int roundNum;
    public Text round;
    void Start()
    {
        
        spawnRot = this.transform.rotation;
        
        // Intitialize spawn numbers
        roundNum = 1;
        numSpawn = roundNum * 2;
        currSpawn = numSpawn;
        round.text = "Round: " + roundNum.ToString();
        StartCoroutine("StartSpawn");
    }

    void Update(){
        if(currSpawn <= 0){
            StartCoroutine("NewRound");
        }
    }

    IEnumerator StartSpawn()
    {
        for(int i = 0; i < numSpawn; i++){
            SpawnOne();
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator NewRound()
    {
        roundNum++;
        numSpawn = roundNum * 2;
        currSpawn = numSpawn;
        round.text = "Round: " + roundNum.ToString();
        StartCoroutine("StartSpawn");
        yield return new WaitForSeconds(10);
    }

    void SpawnOne()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnRot);
    }

    public void UpdateCount()
    {
        currSpawn--;
    }

    public int GetRound()
    {
        return roundNum;
    }
}
