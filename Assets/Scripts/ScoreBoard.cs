using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private Transform eList;
    private Transform eObj;
    GameObject scoreInput;
    GameObject playerHealth;
    Score scoreScript;
    PlayerHealth healthScript;
    public bool updatedOnce;
 
    int i = 0;

    void Start()
    {
        updatedOnce = false;
    }

    void Update()
    {
        playerHealth = GameObject.Find("RPGHeroPolyart");
        healthScript = playerHealth.GetComponent<PlayerHealth>();
        if (healthScript.cur_health <= 0 && !updatedOnce)
        {
            updateBoard();
            //PlayerPrefs.SetString("Rank", rankString);  //loading scoreboard
            //PlayerPrefs.SetString("Score", s.ToString());
            //PlayerPrefs.SetString("Name", name);
        }
    }

    void updateBoard()
    {
        eList = transform.Find("entryList");
        eObj = eList.Find("entryObj");

        scoreInput = GameObject.Find("RPGHeroPolyart");
        scoreScript = scoreInput.GetComponent<Score>();

        eObj.gameObject.SetActive(false);
        
        float h = 30f;
        
        Transform eTransform = Instantiate(eObj, eList);
        RectTransform eRectTransform = eTransform.GetComponent<RectTransform>();
        eRectTransform.anchoredPosition = new Vector2(0, -h * i);
        eTransform.gameObject.SetActive(true);

        int rank = i + 1;
        string rankString;
        switch(rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }

        eTransform.Find("rank").GetComponent<Text>().text = rankString;

        int s = scoreScript.scoreCount;

        eTransform.Find("score").GetComponent<Text>().text = s.ToString();

        string name = "AAA";

        eTransform.Find("name").GetComponent<Text>().text = name;

        ++i;
        //PlayerPrefs.SetString("Rank", rankString);  //saving scoreboard
        //PlayerPrefs.SetString("Score", s.ToString());
        //PlayerPrefs.SetString("Name", name);

        updatedOnce = true;
    }
}
