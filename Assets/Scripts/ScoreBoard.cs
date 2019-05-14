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
    Score scoreScript;
    int i = 0;

    private void Awake()
    {
        eList = transform.Find("entryList");
        eObj = eList.Find("entryObj");

        scoreInput = GameObject.Find("Score");
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

        int score = 111;

        eTransform.Find("score").GetComponent<Text>().text = score.ToString();

        string name = "AAA";

        eTransform.Find("name").GetComponent<Text>().text = name;

        ++i;

    }
}
