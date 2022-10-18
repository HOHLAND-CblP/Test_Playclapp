using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Controler : MonoBehaviour
{
    float speed = 1;
    float distance = 1;
    float time = 1;


    [SerializeField] Vector3 respawnPosition;
    [SerializeField] GameObject cubePref;

    GameObject cube;
    
    
    void Start()
    {
        cube = Instantiate(cubePref);
        cube.SetActive(false);
        cube.GetComponent<Cube>().OnEndTravel.AddListener(CubeIsFinishedTravel);

        StartCoroutine(TimeToRespawn());
    }



    void RespawnCube()
    {
        cube.GetComponent<Cube>().Initialize(speed, distance);
        cube.transform.position = respawnPosition;
        cube.SetActive(true);
    }

    void CubeIsFinishedTravel()
    {
        cube.SetActive(false);
        StartCoroutine(TimeToRespawn());
    }



    public void ChangeSpeed(TMP_InputField inputField)
    {
        if (inputField.text.Length == 0)
        {
            inputField.text = speed.ToString();
            return;
        }

        speed = Convert.ToSingle(inputField.text);
    }

    public void ChangeDistance(TMP_InputField inputField)
    {
        if (inputField.text.Length == 0)
        {
            inputField.text = distance.ToString();
            return;
        }

        distance = Convert.ToSingle(inputField.text);
    }

    public void ChangeTime(TMP_InputField inputField)
    {
        if (inputField.text.Length == 0)
        {
            inputField.text = time.ToString();
            return;
        }

        time = Convert.ToSingle(inputField.text);
    }

    IEnumerator TimeToRespawn()
    {
        yield return new WaitForSeconds(time);
        RespawnCube();
    }
}