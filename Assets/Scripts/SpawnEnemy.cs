using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    // Used to distinguish enemy and player
    public GameObject enemy;
    public GameObject player;

    public enum SpawnState {SPAWNING, WAITING, NEWROUND};
    public SpawnState state = SpawnState.NEWROUND;

    private int roundNum = 1;
    public Text round;
    private float countdown = 10.0f;

    // Used for orientation and position of enemy
    private Quaternion spawnRot;
    public Transform[] spawnPoints; 

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
        if(state == SpawnState.WAITING){
            // Check if enemies are alive
            if(currSpawn == 0){
                // Begin new round
                state = SpawnState.NEWROUND;
                StartNewRound();
            }else{
                return;
            }
        }else if(state == SpawnState.NEWROUND){
            if(countdown <= 0){
                if(state != SpawnState.SPAWNING){
                    // State spawning
                    PrintRound();
                    StartCoroutine("StartSpawn");
                }
            }else{
                round.text = "Round Starting in " + countdown.ToString("0.0");
                countdown -= Time.deltaTime;
            }
        }
    }

    IEnumerator StartSpawn()
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < numSpawn; i++){
            SpawnOne();
            yield return new WaitForSeconds(5);
        }

        state = SpawnState.WAITING;
    }

    void StartNewRound()
    {
        numSpawn *= 2;
        currSpawn = numSpawn;
        roundNum++;
        countdown = 10.0f;
    }

    void SpawnOne()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnRot);
    }

    public void UpdateCount(){
        currSpawn--;
    }

    void PrintRound(){
        round.text = "Round: " + roundNum.ToString();
    }
}
