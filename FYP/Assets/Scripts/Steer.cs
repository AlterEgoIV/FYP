using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{
    GameObject player;
    float waitTime, elapsedTime, speed, maxSteerForce, minDistance;
    Vector3 target, offset, min, max;
    bool isMoving, isWaiting, isReadyToMove;
    Vector3 acceleration, velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        waitTime = 120f;
        elapsedTime = 0;
        speed = 3f;
        maxSteerForce = .08f;
        minDistance = 3f;
        target = new Vector3();
        offset = new Vector3(0, 5, 10);
        min = new Vector3(-10, -3, -2);
        max = new Vector3(10, 3, 2);
        isMoving = false;
        isWaiting = false;
        isReadyToMove = true;

        acceleration = new Vector3();
        velocity = new Vector3();

        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime == waitTime)
        {
            SetTarget();

            elapsedTime = 0;
        }

        SeekTarget();
        Move();

        ++elapsedTime;
    }

    void SetTarget()
    {
        target.Set(player.transform.position.x + offset.x + Random.Range(min.x, max.x),
                       player.transform.position.y + offset.y + Random.Range(min.y, max.y),
                       player.transform.position.z + offset.z + Random.Range(min.z, max.z));
    }

    void SeekTarget()
    {
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= speed;

        Vector3 steeringForce = desiredVelocity - velocity;
        steeringForce.Normalize();
        steeringForce *= maxSteerForce;

        acceleration += steeringForce;
    }

    void Move()
    {
        velocity += acceleration;
        velocity.Normalize();
        velocity *= speed;
        transform.Translate(velocity * Time.deltaTime);
        acceleration.Set(0, 0, 0);
    }
}
