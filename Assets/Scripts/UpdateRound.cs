using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRound : MonoBehaviour
{
    private int roundNum = 1;
    public Text round;
    private float timer = 5.0f;
    private bool runOnce = false;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        round.text = "Round Starting...";
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            if(!runOnce){
                spawner.gameObject.GetComponent<SpawnEnemy>().StartCoroutine("StartSpawn");
                runOnce = true;
            }
            PrintRound();
        }else{
            round.text = "Round Starting in " + timer.ToString("0");
        }
    }

    public void PrintRound(){
        round.text = "Round: " + roundNum.ToString();
    }

    public void NewRound(){
        timer = 15.0f;
        runOnce = false;
        roundNum++;
        spawner.gameObject.GetComponent<SpawnEnemy>().StartNewRound();
        spawner.gameObject.GetComponent<SpawnEnemy>().StopWait();
    }
}
