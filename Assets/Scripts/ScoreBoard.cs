using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
   
    GameObject scoreInput;
    Score scoreScript;
    GameObject playerHealth;
    PlayerHealth healthScript;
    bool updatedOnce;

    private Transform eList;
    private Transform eObj;
    private List<Transform> entryTransform;

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

            scoreInput = GameObject.Find("RPGHeroPolyart");
            scoreScript = scoreInput.GetComponent<Score>();

            eList = transform.Find("entryList");
            eObj = eList.Find("entryObj");

            eObj.gameObject.SetActive(false);

            string jsonString = PlayerPrefs.GetString("entryTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            if (highscores == null || healthScript.resetBoard == true)
            {
                //Initialize Table
                PlayerPrefs.DeleteAll();
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
                addEntry(0, "---");
            }
            addEntry(scoreScript.scoreCount, "Team 7");
            jsonString = PlayerPrefs.GetString("entryTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
            //Sort score list
            for (int i = 0; i < highscores.entryList.Count; ++i)
            {
                for (int j = i + 1; j < highscores.entryList.Count; ++j)
                {
                    if (highscores.entryList[j].score > highscores.entryList[i].score)
                    {
                        entryObject temp = highscores.entryList[i];
                        highscores.entryList[i] = highscores.entryList[j];
                        highscores.entryList[j] = temp;
                    }
                }
            }

            entryTransform = new List<Transform>();

            foreach (entryObject entry in highscores.entryList)
            {
                updateBoard(entry, eList, entryTransform);
            }
        }
        updatedOnce = true;
    }

    private void updateBoard(entryObject entry, Transform eList, List<Transform> entryTransform)
    {        
        float h = 30f;
        
        Transform eTransform = Instantiate(eObj, eList);
        RectTransform eRectTransform = eTransform.GetComponent<RectTransform>();
        eRectTransform.anchoredPosition = new Vector2(0, -h * entryTransform.Count);
        eTransform.gameObject.SetActive(true);

        int rank = entryTransform.Count + 1;
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

        int score = entry.score;

        eTransform.Find("score").GetComponent<Text>().text = score.ToString();

        string name = entry.name;

        eTransform.Find("name").GetComponent<Text>().text = name;

        //updatedOnce = true;

        entryTransform.Add(eTransform);
    }

    private void addEntry(int score, string name)
    {
        //Create highscore entry
        entryObject entry = new entryObject {score = score, name = name};

        //Load saved highscores
        string jsonString = PlayerPrefs.GetString("entryTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                entryList= new List<entryObject>()
            };
        }

        //Add new entry to highscores
        highscores.entryList.Add(entry);

        //save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("entryTable", json);
        PlayerPrefs.Save(); 
    }

    private class Highscores
    {
        public List<entryObject> entryList;
    }

    [System.Serializable]

    private class entryObject
    {
        public int score;
        public string name;
    }
}

