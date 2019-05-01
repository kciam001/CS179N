using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRound : MonoBehaviour
{
    private int roundNum = 1;
    public Text round;

    // Start is called before the first frame update
    void Start()
    {
        round.text = "Round: " + roundNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
