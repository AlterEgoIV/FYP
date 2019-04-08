using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour
{
    GameObject player;
    float waitTime, elapsedTime, speed, maxSteerForce, minDistance;
    Vector3 target, offset;
    float minX, minY, minZ, maxX, maxY, maxZ;
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
        minX = -10;
        minY = -3;
        minZ = -2;
        maxX = 10;
        maxY = 3;
        maxZ = 2;
        isMoving = false;
        isWaiting = false;
        isReadyToMove = true;

        acceleration = new Vector3();
        velocity = new Vector3();
        //steeringForce = new Vector3();

        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime == waitTime)
        {
            SetTarget();
            //target.Set(player.transform.position.x + offset.x + Random.Range(minX, maxX),
            //           player.transform.position.y + offset.y + Random.Range(minY, maxY),
            //           player.transform.position.z + offset.z + Random.Range(minZ, maxZ));

            //if(Vector3.Distance(transform.position, target) < minDistance)
            //{
            //    Vector3 direction = target - transform.position;
            //    direction.Normalize();
            //    direction *= minDistance;
            //    target = transform.position + direction;
            //}

            elapsedTime = 0;
        }

        SeekTarget();
        Move();

        ++elapsedTime;
    }

    void SetTarget()
    {
        target.Set(player.transform.position.x + offset.x + Random.Range(minX, maxX),
                       player.transform.position.y + offset.y + Random.Range(minY, maxY),
                       player.transform.position.z + offset.z + Random.Range(minZ, maxZ));

        //if (Vector3.Distance(transform.position, target) < minDistance)
        //{
        //    Vector3 direction = target - transform.position;
        //    direction.Normalize();
        //    direction *= minDistance;
        //    target = transform.position + direction;
        //}
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

    void blah()
    {
        if (isReadyToMove)
        {
            target.Set(player.transform.position.x + offset.x + Random.Range(minX, maxX),
                       player.transform.position.y + offset.y + Random.Range(minY, maxY),
                       player.transform.position.z + offset.z + Random.Range(minZ, maxZ));

            isReadyToMove = false;
            isMoving = true;
        }

        if (isMoving)
        {
            //Seek();

            velocity += acceleration;
            velocity.Normalize();
            velocity *= speed;

            //if (velocity.x > speed) velocity.x = speed;
            //if (velocity.y > speed) velocity.y = speed;
            //if (velocity.z > speed) velocity.z = speed;

            //transform.position += velocity;
            transform.Translate(velocity);
            acceleration.Set(0, 0, 0);
            //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }

        if (Vector3.Equals(transform.position, target) && isMoving)
        {
            //isAtNewPosition = true;
            isMoving = false;
            isWaiting = true;
        }

        if (isWaiting)
        {
            if (elapsedTime == waitTime)
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

        //acceleration.Set(0, 0, 0);
    }
}
