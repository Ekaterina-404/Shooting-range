using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private Rigidbody _rigitbodySphere;
    private Transform _transformSphere;
    private readonly float _distance = 5f;
    [SerializeField] private GameObject _sphere;
    //[SerializeField] private GameObject _spherePref;
    [SerializeField] private Material _material;
    [SerializeField] private Quaternion _rotation = Quaternion.Euler(0,0,0);
    [SerializeField] private Vector3 _position;

    private void CreateSphere ()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.GetComponent<Renderer>().material = _material;
        sphere.transform.position = _transformSphere.position;//позиция мыши
        sphere.transform.rotation = _rotation;

    }

    private void Start() //Awake
    {
        _rigitbodySphere = GetComponent<Rigidbody>();
        _transformSphere = GetComponent<Transform>();
        _rigitbodySphere.useGravity = false;
    }

    private void Update()
    {
        if (_rigitbodySphere.useGravity == false)
        {
            FixItToMouse(_transformSphere);
        }

        if (Input.GetMouseButtonUp(0)) //усиливается бросок, зависимость силы от времени, GetMouseButton
        {
            _rigitbodySphere.useGravity = true;

            _rigitbodySphere.AddForce(Camera.main.transform.forward * 3000);
            CreateSphere();
        }
    }

    private void FixItToMouse(Transform transformSphere) //Цепляем объект к курсору мыши
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 mousePositionInTheWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        transformSphere.position = mousePositionInTheWorld;
    }
    
   //private void FixedUpdate()
}