using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static GlobalSettings;

public class ShipBehaviour : MonoBehaviour
{
    // Максимальная скорость корабля
    public float maxSpeedPerSec;
    public float accelerationPerSec;
    public float rotateSpeed;

    private float maxSpeedPerTick;
    private float accelerationPerTick;
    private float speed = 0;
    private GameObject cam;
    private GameObject ocean;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        cameraOffset = cam.transform.position;

        ocean = GameObject.Find("Ocean");

    }

    private void Update()
    {
        MoveShip();
        MoveOcean();
    }

    bool buttonW = false;
    bool buttonA = false;
    bool buttonS = false;
    bool buttonD = false;
    private Vector3 cameraOffset = new Vector3(0, 28, -30);
    private void MoveShip()
    {
        maxSpeedPerTick = maxSpeedPerSec * Time.deltaTime;
        accelerationPerTick = accelerationPerSec * Time.deltaTime;

        buttonW = Input.GetKey("w");
        buttonA = Input.GetKey("a");
        buttonS = Input.GetKey("s");
        buttonD = Input.GetKey("d");


        if (buttonA)
            transform.Rotate(0, rotateSpeed, 0);
        if (buttonD)
            transform.Rotate(0, -rotateSpeed, 0);

        if (speed < maxSpeedPerTick && buttonW)
            speed += accelerationPerTick;
        if (speed > -maxSpeedPerTick / 2 && buttonS)
            speed -= accelerationPerTick;

        bool noSpeedButtonIsActive = (buttonW || buttonS) == false;
        if (noSpeedButtonIsActive && speed > waterResistance)
            speed -= waterResistance;
        else if (noSpeedButtonIsActive && speed < -waterResistance)
            speed += waterResistance;
        else if (noSpeedButtonIsActive)
            speed = 0;

        transform.position += transform.forward * speed;
        transform.position.Set(transform.position.x, 0.0f, transform.position.z);
        cam.transform.position = transform.position + cameraOffset;
    }

    private void MoveOcean()
    {
        Vector3 newPos = new Vector3(roundAxis(transform.position.x), 0, roundAxis(transform.position.z));
        ocean.transform.position = newPos;
        LowPolyWater.LowPolyWater.waveOriginPosition = -newPos;
    }

    private float roundAxis(float axis)
    {
        return axis - axis % gridStep;
    }
}
