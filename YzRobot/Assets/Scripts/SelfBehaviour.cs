using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBehaviour : MonoBehaviour
{
    public RobotBehaviour robot;
    public Camera shot;

    void Start()
    {
        if (shot != null && robot != null)
        {
            Camera.SetupCurrent(shot);
            transform.position = robot.transform.position;
        }
    }

    void Update()
    {
        if (robot)
        {
            transform.position = robot.transform.position;

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(x, 0.0f, y).normalized;

            if (Input.GetKey(KeyCode.J))
            {
                robot.Beat();
            }
            else if (Input.GetKey(KeyCode.K))
            {
                robot.Fire();
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                robot.Jump();
            }
            else if (direction != Vector3.zero)
            {
                var isDash = Input.GetKey(KeyCode.L);
                robot.Walk(direction);
            }
            else
            {
                robot.Stand();
            }
        }
    }
}
