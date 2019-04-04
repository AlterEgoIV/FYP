using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{
    public GameObject player;
    float waitTime, elapsedTime, speed;
    Vector3 newPosition, offset;
    float minX, minY, minZ, maxX, maxY, maxZ;
    bool isMoving, isWaiting, isReadyToMove, isAtNewPosition;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 120f;
        elapsedTime = 0;
        speed = 10f;
        newPosition = new Vector3();
        offset = new Vector3(0, 5, 10);
        minX = -10;
        minY = -3;
        minZ = -2;
        maxX = 10;
        maxY = 3;
        maxZ = 2;
        isMoving = false;
        isWaiting = false;
        isReadyToMove = true;
        //isAtNewPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReadyToMove)
        {
            newPosition.Set(player.transform.position.x + offset.x + Random.Range(minX, maxX),
            player.transform.position.y + offset.y + Random.Range(minY, maxY),
            player.transform.position.z + offset.z + Random.Range(minZ, maxZ));

            isReadyToMove = false;
            isMoving = true;
        }

        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
        }

        if(Vector3.Equals(transform.position, newPosition) && isMoving)
        {
            //isAtNewPosition = true;
            isMoving = false;
            isWaiting = true;
        }
        
        if(isWaiting)
        {
            if(elapsedTime == waitTime)
            {
                elapsedTime = 0;
                isWaiting = false;
                isReadyToMove = true;
            }
            else
            {
                ++elapsedTime;
            }
        }
    }
}
