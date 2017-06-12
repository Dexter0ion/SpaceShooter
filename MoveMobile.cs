using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveMobile : MonoBehaviour {
    public int moveMode=0;
    public float speed = 3f;
    public GameObject Shuttle;
    private Rigidbody2D myRigidbody2d;
    private Rigidbody myRigidbody;
    //time control
    private float launchRate = 0.5f;
    private float nextLaunch = 0f;
    // Use this for initialization

    void LaunchShip()
    {
        // if (Time.time > nextLaunch)
        // {
        // nextLaunch += launchRate;
        if (Input.GetMouseButton(0))
        {
            Instantiate(Shuttle, this.transform.localPosition, this.transform.localRotation);
        }
        //}
    }

    void moveObejct()
    {


        //CrossPlat
        float moveHorizontalCross = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVerticalCross = CrossPlatformInputManager.GetAxis("Vertical");
        float roll = CrossPlatformInputManager.GetAxis("Mouse X");
        float pitch = CrossPlatformInputManager.GetAxis("Mouse Y");
        this.transform.rotation *= Quaternion.Euler(0, roll, 0);
        Vector3 movementCross = new Vector3(moveHorizontalCross, pitch, moveVerticalCross);
        myRigidbody.velocity = movementCross * speed;

    }

    void Start()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveObejct();
    }
}
