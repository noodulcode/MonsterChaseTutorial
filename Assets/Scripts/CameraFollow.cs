using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX; // can declare two variables of the same type with a comma


    // Start is called before the first frame update
    void Start()
    { // findwithtag function built into gameobject will go inside scene and look for gameobject with a tag of Player and get transform property from gameobject
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate() // called every frame if behaviour is enabled, but called after all calculations inUpdate have finished
    {
        tempPos = transform.position; // current position of the camera, take that and the x of that position set it to the players current x position
        tempPos.x = player.position.x; // and then assign that value back to the curent position of the camera. camera will have its own y,z position but will have the x position of the player.

        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;
        transform.position = tempPos;
    }





} //  class
