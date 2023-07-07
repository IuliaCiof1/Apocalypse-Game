using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Image healthBar;
    private float maxHealth = 100;
    private float currentHealth;
    public GameObject gameOver;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealthBar(float damage)
    {
        currentHealth += damage;

        if (currentHealth <= 0f)
        {
            Cursor.lockState = CursorLockMode.None; //unlock cursor
            gameOver.SetActive(true);
            //gameObject.SetActive(false);
            Time.timeScale = 0f;
            
            AudioListener.volume = 0;
        }
        else if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.fillAmount = currentHealth/maxHealth;
    }


}
