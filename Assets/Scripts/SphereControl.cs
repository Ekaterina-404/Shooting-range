using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class SphereControl : MonoBehaviour
{
    private readonly float _distance = 5f;
    private Rigidbody _rigitbodySphere;
    private Transform _transformSphere;
    [SerializeField] private Material _material;
    [SerializeField] private Vector3 _position;


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

        if (Input.GetMouseButtonUp(0))
        {
            _rigitbodySphere.useGravity = true;
            _rigitbodySphere.AddForce(Camera.main.transform.forward * 3000);
            CreateSphere();
        }
    }
    private void CreateSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.GetComponent<Renderer>().material = _material;
        _transformSphere = sphere.GetComponent<Transform>();
        _rigitbodySphere = sphere.AddComponent<Rigidbody>();
        _rigitbodySphere.useGravity = false;
    }

    private void FixItToMouse(Transform transformSphere) //Цепляем объект к курсору мыши
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 mousePositionInTheWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        transformSphere.position = mousePositionInTheWorld;
    }
}
