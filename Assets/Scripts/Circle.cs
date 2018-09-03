using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Circle : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed = new Vector3(0,0,90f);

    private void Update ()
    {
        transform.Rotate(speed * Time.deltaTime);
	}
}
