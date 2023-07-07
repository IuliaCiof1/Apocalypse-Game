using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Score", menuName = "Score")]
public class ScoreData : ScriptableObject
{

    public TextAsset asset;

    public int enemiesKilled=0;
    public int notesCollected=0;
    public new string name="";

    public void scoreData(string name,int notesCollected, int enemiesKilled)
    {
        this.name = name;
        this.notesCollected = notesCollected;
        this.enemiesKilled = enemiesKilled;
    }

    public void reset()
    {
        enemiesKilled = 0;
        notesCollected = 0;
        name = "";
    }

    public void setName(string input)
    {
        name = input;
    }

    public void writeToLeaderboard()
    {
        string path = "MTP Apocalypse_Data/StreamingAssets/Leaderboard.txt";
        
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(name + " " + notesCollected + " " + enemiesKilled);
        writer.Close();

        //reimport file
        //AssetDatabase.ImportAsset(path);
        
        asset = (TextAsset)Resources.Load("Leaderboard",typeof(TextAsset));
        Debug.Log(asset);
    }

    //function to write score to txt
}
