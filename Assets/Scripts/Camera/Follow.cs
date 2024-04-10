using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private float sens = 100f;
    public float clam = 90f;
    public GameObject player;
    float xRotation = 0;
    float yRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -clam, clam);
            yRotation += mouseX;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
