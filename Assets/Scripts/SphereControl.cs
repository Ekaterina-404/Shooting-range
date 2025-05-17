using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private Rigidbody _rigitbodySphere;
    //private Transform _transformSphere;
    public float _speed = 5f;

    private void Start() //Awake
    {
        _rigitbodySphere = GetComponent<Rigidbody>();
        //_transformSphere = GetComponent<Transform>();
    }

    private void Update()
    {
        //Цепляем объект к курсору мыши
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
        //конец
    }
}