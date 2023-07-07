using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;
    float xRotation = 0f;

    public ScoreData score;
    // Start is called before the first frame update
    void Start()
    {
        score.reset();
        Cursor.lockState = CursorLockMode.Locked; //hide mouse cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; //time.deltatime = how much time has passed since last update()
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //for overtotaion

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
