using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    float speed = 1;
    float distance = 5;
    float distanceTraveled;

    public UnityEvent OnEndTravel = new UnityEvent();

    public void Initialize(float speed, float distance)
    {
        this.speed = speed;
        this.distance = distance;

        distanceTraveled = 0;
    }


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        distanceTraveled += speed * Time.deltaTime;
        if (distanceTraveled >= distance)
        {
            OnEndTravel.Invoke();
        }
    }
}