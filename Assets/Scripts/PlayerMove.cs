using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float moveSpeed = 5;
    private const float rotSpeed = 90;

    private Transform ts;

    private void Awake()
    {
        ts = transform;
    }

    private void Update()
    {
        Vector3 vec3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            vec3 += ts.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vec3 -= ts.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vec3 -= ts.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vec3 += ts.right;
        }

        vec3.Normalize();

        ts.localPosition += vec3 * moveSpeed * Time.deltaTime;


        vec3 = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            vec3 = Vector3.down;

        }
        else if (Input.GetKey(KeyCode.E))
        {
            vec3 = Vector3.up;
        }
        ts.localEulerAngles += vec3 * rotSpeed * Time.deltaTime;
    }
}
