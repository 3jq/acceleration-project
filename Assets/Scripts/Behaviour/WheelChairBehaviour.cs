using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairBehaviour : MonoBehaviour
{
    public Transform human;
    public Transform target;
    public float speed;
    private float usedSpeed;
    private Vector3 originalDistance;
    private bool isYPressed;

    void Start()
    {
        originalDistance = new(human.position.x - transform.position.x, human.position.y - transform.position.y, human.position.z - transform.position.z);
    }

    
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isYPressed = !isYPressed;
        }        
    }

    void FixedUpdate()
    {
        if (!isYPressed) {
            // если не была нажата кнопка "Y" то, соответственно, человек не идет
            // код далее - снижение скорости, если она и так не на нуле
            // это нужно, чтобы у нас колясочник был не на реактивной тяге и моментально разгонялся
            if (usedSpeed != 0) usedSpeed -= speed * 0.03f;
            return; 
        } else if (usedSpeed != speed) usedSpeed += speed * 0.03f; // постепенный набор скорости

        Vector3 a = transform.position;
        Vector3 b = new(target.position.x - originalDistance.x, transform.position.y, target.position.z - originalDistance.z);

        transform.position = Vector3.MoveTowards(a, b, usedSpeed);
    }
}