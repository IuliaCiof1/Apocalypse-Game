using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWon : MonoBehaviour
{
    public ScoreData score;
    public GameObject youWon;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (score.enemiesKilled == 30 && score.notesCollected == 15)
        {
            Cursor.lockState = CursorLockMode.None;
            youWon.SetActive(true);
            player.SetActive(false);
        }
    }
}
