using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    // Used to distinguish enemy and player
    public GameObject Grunt;
    public GameObject Skeleton;
    public GameObject Lich;
    public GameObject TrollGiant;
    public GameObject player;
    GameObject enemy;
    string[] enemySelector = {"Skeleton", "Grunt", "Lich", "TrollGiant"};
    const int NUM_ENEMIES = 4;

    public enum SpawnState {SPAWNING, WAITING, NEWROUND};
    public SpawnState state = SpawnState.NEWROUND;

    private int roundNum = 1;
    public Text round;
    private float countdown = 3.0f;
    private float timeBetweenSpawn = 5.0f;

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
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

        state = SpawnState.WAITING;
    }

    void StartNewRound()
    {
        numSpawn *= 2;
        currSpawn = numSpawn;
        roundNum++;
        countdown = 3.0f;
        if(timeBetweenSpawn > 1.4f)
            timeBetweenSpawn -= 0.4f;
    }

    void SpawnOne()
    {
        int max = 1;
        if(max < roundNum && max < 3)
        {
            max = roundNum;
        }
        if (max >= NUM_ENEMIES)
            max = NUM_ENEMIES;

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int enemySelectorIndex = Random.Range(0, max);

        if(enemySelector[enemySelectorIndex] == "Skeleton")
        {
            enemy = Instantiate(Skeleton, spawnPoints[spawnPointIndex].position, spawnRot) as GameObject;
        }
        else if (enemySelector[enemySelectorIndex] == "Grunt")
        {
            enemy = Instantiate(Grunt, spawnPoints[spawnPointIndex].position, spawnRot) as GameObject;
        }
        else if (enemySelector[enemySelectorIndex] == "Lich")
        {
            enemy = Instantiate(Lich, spawnPoints[spawnPointIndex].position, spawnRot) as GameObject;
        }
        else if (enemySelector[enemySelectorIndex] == "TrollGiant")
        {
            enemy = Instantiate(TrollGiant, spawnPoints[spawnPointIndex].position, spawnRot) as GameObject;
        }



    }

    public void UpdateCount(){
        currSpawn--;
    }

    void PrintRound(){
        round.text = "Round: " + roundNum.ToString();
    }
}
