using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFollow : MonoBehaviour
{
    public Transform target;

    private Transform self;

    private Vector3 offsetPos;
    private Vector3 offsetRot;

    private bool isWorldA;

    private void Awake()
    {
        self = transform;
        offsetPos =  self.localPosition- target.localPosition ;
        offsetRot = target.localEulerAngles - self.localEulerAngles;

        isWorldA = true;
    }

    private void Update()
    {
        if (isWorldA)
        {
            InWorldA();
        }
        else
        {
            InWorldB();
        }
    }

    private void InWorldA()
    {
        Vector3 vec3 = target.localPosition + offsetPos;
        vec3.x = Mathf.Min(vec3.x, 0);
        self.localPosition = vec3;

        vec3 = target.localEulerAngles + offsetRot;
        vec3.y = Mathf.Clamp(vec3.y, 240, 300);
        self.localEulerAngles = vec3;
    }

    private void InWorldB()
    {
        Vector3 vec3 = target.localPosition + offsetPos;
        vec3.x = Mathf.Max(vec3.x, 0);
        self.localPosition = vec3;

        vec3 = target.localEulerAngles + offsetRot;
        vec3.y = Mathf.Clamp(vec3.y, 60, 120);
        self.localEulerAngles = vec3;
    }

    public void ChangePortal(Transform ts)
    {
        offsetPos *= -1;
        offsetRot *= -1;
        if (ts.name.IndexOf("B")>=0)
        {
            isWorldA = false;
        }
        else
        {
            isWorldA = true;
        }
    }
}
