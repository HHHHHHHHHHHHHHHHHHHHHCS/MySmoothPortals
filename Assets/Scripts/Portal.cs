using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private const string player = "Player";
    private static OtherFollow of;

    public Transform otherProtal;

    private Transform target, self;
    private bool isEnter;

    private void Awake()
    {
        self = transform;
        if(!of)
        {
            of = GameObject.Find("CameraB").GetComponent<OtherFollow>();
        }
    }

    private void Update()
    {
        if (isEnter)
        {
            Vector3 offsetPos =  target.position - self.position;
            float dot= Vector3.Dot(offsetPos, self.up);
            if(dot < 0f)
            {
                Vector3 vec3 = otherProtal.position;
                vec3.y = target.position.y;
                target.position = vec3;
                of.ChangePortal(otherProtal);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player))
        {
            isEnter = true;
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(player))
        {
            isEnter = false;
        }
    }
}
