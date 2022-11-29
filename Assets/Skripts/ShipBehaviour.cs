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
    private GameObject camera;
    private Vector3 cameraOffset;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
        cameraOffset = camera.transform.position;
    }

    private void LateUpdate()
    {
        MoveShip();

    }

    bool buttonW = false;
    bool buttonA = false;
    bool buttonS = false;
    bool buttonD = false;
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
            speed += accelerationPerTick * Time.deltaTime;
        if (speed > -maxSpeedPerTick / 2 && buttonS)
            speed -= accelerationPerTick * Time.deltaTime;

        if (speed > 0 && (buttonW || buttonA || buttonS || buttonD) == false)
            speed -= waterResistance * Time.deltaTime;
        else if (speed < 0 && (buttonW || buttonA || buttonS || buttonD) == false)
            speed += waterResistance * Time.deltaTime;

        transform.position += -transform.right * speed;
        camera.transform.position += -camera.transform.right * speed;
    }
}
