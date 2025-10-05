using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextProximity : MonoBehaviour
{
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject descriptionBox;
    [SerializeField] private GameObject spotlight;
    [SerializeField] private GameObject game;

    [SerializeField] private float radius = 0f;
    [SerializeField] private float rotSpeed = 0f;


    private Quaternion gameRotation;
    private Vector3 gamePosition;
    private float distToRig = 0f;
    void Start()
    {
        gameRotation = game.transform.rotation;
        gamePosition = game.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distToRig = Vector3.Distance(transform.position, cameraRig.transform.position);
        game.transform.position = gamePosition;

        if (distToRig < radius) // Activated
        {
            //Debug.Log("Close enough");
            game.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            descriptionBox.SetActive(true);
            spotlight.SetActive(true);
        }
        else // Deactivated
        {
            game.transform.rotation = gameRotation;
            descriptionBox.SetActive(false);
            spotlight.SetActive(false);
        }
    }
}
