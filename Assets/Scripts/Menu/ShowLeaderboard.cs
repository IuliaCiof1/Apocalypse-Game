using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ShowLeaderboard : MonoBehaviour
{
    private Transform content;
    private Transform row;
    public List<ScoreData> scores;

    void Start()
    {
        content = gameObject.transform; //parent of row
        row = transform.Find("Row"); //get row template (child of content)

        row.gameObject.SetActive(false); //disable row template


        readScores();
        quickSort(0,scores.Count-1);
       // scores = scores.OrderBy(
        for (int i = 0; i < scores.Count && i<10; i++)  //get first 10 scores
        {
            float rowHeight = 100;
            Transform newRow = Instantiate(row, content); //clone row and place it in the content parent
            RectTransform newRowRectT = newRow.GetComponent<RectTransform>();
            newRowRectT.anchoredPosition = new Vector2(0, -rowHeight * i);
            newRow.gameObject.SetActive(true);

            TMP_Text rank = newRow.Find("Rank").GetComponent<TMP_Text>();
            TMP_Text name = newRow.Find("Name").GetComponent<TMP_Text>();
            TMP_Text notes = newRow.Find("Notes").GetComponent<TMP_Text>();
            TMP_Text kills = newRow.Find("Kills").GetComponent<TMP_Text>();

            rank.text = (i + 1).ToString();
            name.text = scores[i].name;
            notes.text = scores[i].notesCollected.ToString();
            kills.text = scores[i].enemiesKilled.ToString();
            
        
        }

 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void readScores()
    {
        string path = "MTP Apocalypse_Data/StreamingAssets/Leaderboard.txt";
        StreamReader reader = new StreamReader(path);
        string line;

        while (((line=reader.ReadLine()))!=null)
        {
            string []cells = line.Split(' ');

            ScoreData score = ScriptableObject.CreateInstance("ScoreData") as ScoreData;
            score.scoreData(cells[0], Int32.Parse(cells[1]), Int32.Parse(cells[2]));
            scores.Add(score);
        }
        
        Debug.Log(scores);
    }

    int partition(int low, int high)
    {
        ScoreData temp;
        int pivot = scores[high].notesCollected;

        int i = low - 1;

        for(int j = low; j <= high - 1; j++)
        {
            if (scores[j].notesCollected > pivot)
            {
                i++;

                temp = scores[i];
                scores[i] = scores[j];
                scores[j] = temp;

            }
            else if((scores[j].notesCollected == pivot))
            {
                if (scores[j].enemiesKilled > pivot)
                {
                    i++;

                    temp = scores[i];
                    scores[i] = scores[j];
                    scores[j] = temp;

                }
            }
        }

        temp = scores[i + 1];
        scores[i + 1] = scores[high];
        scores[high] = temp;

        return i + 1;

    }
    void quickSort(int low, int high)
    {
        if (low < high)
        {
            int pi = partition(low, high);

            quickSort(low, pi - 1);
            quickSort(pi + 1, high);
        }
    }
}
