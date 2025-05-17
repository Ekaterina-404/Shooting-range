using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private Rigidbody _rigitbodySphere;
    public float _speed = 5f;
    public int _impulse = 300;

    private void Start() //Awake
    {
        _rigitbodySphere = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FixItToMouse();

            if (Input.GetKey(KeyCode.A))
            {
                _rigitbodySphere.AddForce(0f, 0f, 5f);
            }
        }
        else
        {
        }
    }

    private void FixItToMouse() //Цепляем объект к курсору мыши
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}