using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemiesKilledDisplay : MonoBehaviour
{

    public TextMeshProUGUI kills;
    public TextMeshProUGUI notes, notesOnScreen;

    public ScoreData score;
   
    private void OnEnable()
    {
        EnemyHealth.enemyKilled += UpdateKills;
        NoteCollect.notecollected += UpdateNotes;
    }

    private void OnDisable()
    {
        EnemyHealth.enemyKilled -= UpdateKills;
        NoteCollect.notecollected -= UpdateNotes;
    }
    

    public void UpdateKills(EnemyHealth enemyHealthRef)
    {
        score.enemiesKilled++;
        kills.text = "Enemies killed: " + score.enemiesKilled;

    }

    public void UpdateNotes()
    {
        score.notesCollected++;
        notes.text = "Notes collected: " + score.notesCollected + "/15";
        notesOnScreen.text = "Notes : " + score.notesCollected + "/15";
    }
}
