using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NoteCollect : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform player;
    public bool playerInRange;
    public float collectRange;
    public static event Action notecollected;
    public PlayerStats health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, collectRange, whatIsPlayer);

        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                health.UpdateHealthBar(10);
                notecollected?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collectRange);
    }
}
